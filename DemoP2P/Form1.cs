using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.PeerToPeer;
using System.Net;

namespace DemoP2P
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region フィールド

        PeerName peerName = null;
        Register<UserData> register = null;
        Resolver<UserData> resolver = null;
        volatile bool bLoading = false;
        readonly string myID = Guid.NewGuid().ToString();

        #endregion

        #region プロパティ

        bool PeerOpened
        {
            get
            {
                return register != null;
            }
        }

        public string Classifier
        {
            get
            {
                return textBoxClassifier.Text.Trim();
            }
        }

        PeerNameType PeerNameType
        {
            get
            {
                if (radioButtonSecured.Checked) return PeerNameType.Secured;
                if (radioButtonUnsecured.Checked) return PeerNameType.Unsecured;
                throw new NotImplementedException();
            }
        }

        int PortNo
        {
            get
            {
                return Convert.ToInt32(numericUpDownPortNo.Value);
            }
        }

        Cloud Cloud
        {
            get
            {
                if (radioButtonGlobal.Checked) return Cloud.Global;
                if (radioButtonAllLinkLocal.Checked) return Cloud.AllLinkLocal;
                if (radioButtonAvailable.Checked) return Cloud.Available;
                throw new NotImplementedException();
            }
        }

        bool TargetGrobal
        {
            get { return radioButtonGlobal.Checked || radioButtonAvailable.Checked; }
        }

        UserData MyData
        {
            get { return propertyGridMyData.SelectedObject as UserData; }
            set { propertyGridMyData.SelectedObject = value; }
        }

        UserData OtherData
        {
            get { return propertyGridOtherData.SelectedObject as UserData; }
            set { propertyGridOtherData.SelectedObject = value; }
        }

        UserData SelectedOtherData
        {
            get
            {
                UserData userData = null;
                lock (listViewOtherUser)
                {
                    if (listViewOtherUser.SelectedItems.Count == 1)
                    {
                        userData = listViewOtherUser.SelectedItems[0].Tag as UserData;
                    }
                }
                return userData;
            }
        }

        #endregion

        #region イベント

        private void Form1_Load(object sender, EventArgs e)
        {
            MyData = new UserData();
            UpdateUI();
        }

        private void buttonStartOrUpdate_Click(object sender, EventArgs e)
        {
            if (PeerOpened)
            {
                ClosePeer();
                AddLog("ClosePeer", LogType.System);

                OtherData = null;
                lock (listViewOtherUser)
                {
                    listViewOtherUser.Items.Clear();
                }
                UpdateUI();
            }
            else
            {
                OpenPeer();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePeer();
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            timerLoad.Stop();
            buttonLoad.PerformClick();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (bLoading) return;
            bLoading = true;
            resolver.ResolveAsync();
        }

        private void checkBoxAutoLoad_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
            if (checkBoxAutoLoad.Checked)
            {
                buttonLoad.PerformClick();
            }
        }

        private void radioButtonNetwork_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void listViewOtherUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            OtherData = SelectedOtherData;
        }

        private void propertyGridMyData_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (PeerOpened)
            {
                register.SetData(MyData);
                AddLog("SetData", LogType.System);
            }
        }

        #region ピアイベント

        void resolver_AddItem(string id)
        {
            SetOtherUser(id);
            AddLog("resolver_AddItem", LogType.System);
        }

        void resolver_UpdatedItem(string id)
        {
            SetOtherUser(id);
            AddLog("resolver_UpdatedItem", LogType.System);
        }

        void resolver_DeletedItem(string id)
        {
            DeleteOtherUser(id);
            AddLog("resolver_DeletedItem", LogType.System);
        }

        void resolver_ProgressChanged(string userState, int progressPercentage)
        {
            string messsage = string.Format("ResolveProgressChanged UserState:{0} ProgressPercentage:{1}", userState, progressPercentage);
            AddLog(messsage, LogType.System);
        }

        void resolver_Completed(string userState, bool cancelled)
        {
            string messsage = string.Format("ResolveCompleted UserState:{0}", userState);
            if (cancelled)
            {
                messsage = "[Cancelled]" + messsage;
            }
            AddLog(messsage, LogType.System);

            RestartTimer();
            bLoading = false;
        }

        #endregion

        #endregion

        #region メソッド

        private void OpenPeer()
        {
            if (TargetGrobal)
            {
                #region インデックスサーバー名の確認

                if (string.IsNullOrWhiteSpace(textBoxIndexServerAddress.Text))
                {
                    MessageBox.Show(labelIndexServerAddress.Text + "を入力してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabPageSetting;
                    textBoxIndexServerAddress.SelectAll();
                    textBoxIndexServerAddress.Focus();
                    return;
                }

                #endregion

                try
                {
                    peerName = PeerName.CreateFromPeerHostName(textBoxIndexServerAddress.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabPageSetting;
                    textBoxIndexServerAddress.SelectAll();
                    textBoxIndexServerAddress.Focus();
                    return;
                }
            }
            else
            {
                #region 入力ピア名の検証

                if (string.IsNullOrWhiteSpace(Classifier))
                {
                    MessageBox.Show(labelClassifier.Text + "を入力してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabPageSetting;
                    textBoxClassifier.SelectAll();
                    textBoxClassifier.Focus();
                    return;
                }

                #endregion

                peerName = new PeerName(Classifier, PeerNameType);
            }

            MakeResolver();

            register = new Register<UserData>(Cloud, peerName, PortNo, myID);
            register.SetData(MyData);

            UpdateUI();

            AddLog("StartPeer", LogType.System);

            buttonLoad.PerformClick();
        }

        private void SetOtherUser(string id)
        {
            Action action = () =>
                {
                    UserData userData = resolver.GetItem(id);

                    lock (listViewOtherUser)
                    {
                        listViewOtherUser.BeginUpdate();
                        try
                        {
                            foreach (ListViewItem item in listViewOtherUser.Items)
                            {
                                if (item.Name != id) continue;

                                item.Text = userData.DisplayName;
                                item.Tag = userData;
                                if (item.Selected)
                                {
                                    OtherData = userData;
                                }
                                return;
                            }

                            string displayName = string.IsNullOrWhiteSpace(userData.DisplayName)
                                ? "名前なし"
                                : userData.DisplayName;
                            var addItem = listViewOtherUser.Items.Add(displayName);
                            addItem.Name = id;
                            addItem.Tag = userData;
                        }
                        finally
                        {
                            listViewOtherUser.EndUpdate();
                        }
                    }
                };
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(action));
            }
            else
            {
                action();
            }
        }

        private void DeleteOtherUser(string id)
        {
            Action action = () =>
                {
                    UserData userData = resolver.GetItem(id);

                    lock (listViewOtherUser)
                    {
                        var items = listViewOtherUser.Items.Find(id, false);
                        if (items.Length == 1)
                        {
                            listViewOtherUser.Items.Remove(items[0]);
                        }
                    }
                };
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(action));
            }
            else
            {
                action();
            }
        }

        private void UpdateUI()
        {
            #region Input

            buttonStartOrUpdate.Text = PeerOpened ? "停止" : "開始";

            #endregion

            #region Setting

            panelSetting.Enabled = !PeerOpened;

            labelSecured.Enabled = !TargetGrobal;
            panelSecured.Enabled = !TargetGrobal;
            labelClassifier.Enabled = !TargetGrobal;
            textBoxClassifier.Enabled = !TargetGrobal;
            labelIndexServerAddress.Enabled = TargetGrobal;
            textBoxIndexServerAddress.Enabled = TargetGrobal;

            #endregion

            #region Log

            buttonLoad.Enabled = PeerOpened;

            #endregion

            labelInterval.Enabled = checkBoxAutoLoad.Checked;
            numericUpDownInterval.Enabled = checkBoxAutoLoad.Checked;
            labelIntervalUnit.Enabled = checkBoxAutoLoad.Checked;
        }

        private void ClosePeer()
        {
            if (!PeerOpened) return;

            timerLoad.Stop();

            DestroyResolver();

            register.Dispose();
            register = null;
        }

        private void RestartTimer()
        {
            Action action = () =>
                {
                    if (checkBoxAutoLoad.Checked)
                    {
                        timerLoad.Interval = Convert.ToInt32(numericUpDownInterval.Value);
                        timerLoad.Start();
                    }
                };
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(action));
            }
            else
            {
                action();
            }
        }

        private void MakeResolver()
        {
            resolver = new Resolver<UserData>(peerName);
            resolver.AddItem += resolver_AddItem;
            resolver.UpdatedItem += resolver_UpdatedItem;
            resolver.DeletedItem += resolver_DeletedItem;
            resolver.ProgressChanged += resolver_ProgressChanged;
            resolver.Completed += resolver_Completed;
        }

        private void DestroyResolver()
        {
            resolver.AddItem -= resolver_AddItem;
            resolver.UpdatedItem -= resolver_UpdatedItem;
            resolver.DeletedItem -= resolver_DeletedItem;
            resolver.ProgressChanged -= resolver_ProgressChanged;
            resolver.Completed -= resolver_Completed;
            resolver.Dispose();
            resolver = null;
        }

        #region AddLog

        enum LogType
        {
            System,
            Send,
            Received,
        }

        void AddLog(PeerNameRecord peerNameRecord)
        {
            AddLog(peerNameRecord.Comment, Serializer.Deserialize<UserData>(peerNameRecord.Data), LogType.Received);
        }

        private void AddLog(PeerNameRecordCollection peerNameRecordCollection)
        {
            foreach (PeerNameRecord peerNameRecord in peerNameRecordCollection)
            {
                AddLog(peerNameRecord);
            }
        }

        void AddLog(string comment, UserData userData, LogType logType)
        {
            AddLog(string.Format("{0} : {1}", comment, userData), logType);
        }

        void AddLog(string message, LogType logType)
        {
            Action addLog = () =>
            {
                #region addLog

                lock (listViewLog)
                {
                    listViewLog.BeginUpdate();
                    try
                    {
                        var item = listViewLog.Items.Add(message);
                        switch (logType)
                        {
                            case LogType.System: item.ForeColor = Color.Gray; break;
                            case LogType.Send: item.ForeColor = Color.Black; break;
                            case LogType.Received: item.ForeColor = Color.Blue; break;
                            default: throw new NotImplementedException();
                        }
                        if (checkBoxAutoScroll.Checked)
                        {
                            item.EnsureVisible();
                        }

                        listViewLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                    finally
                    {
                        listViewLog.EndUpdate();
                    }
                }

                #endregion
            };

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(addLog));
            }
            else
            {
                addLog();
            }
        }

        #endregion

        #endregion
    }
}
