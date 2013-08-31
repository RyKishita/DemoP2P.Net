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
        PeerNameRegistration peerNameRegistration = null;
        PeerNameResolver peerNameResolver = null;
        volatile bool bLoading = false;
        readonly string myID = Guid.NewGuid().ToString();

        #endregion

        #region プロパティ

        bool PeerOpened
        {
            get
            {
                return peerNameRegistration != null;
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
                UpdateMyData();
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

        private void buttonClose_Click(object sender, EventArgs e)
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

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            timerLoad.Stop();
            buttonLoad.PerformClick();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (bLoading) return;
            bLoading = true;
            peerNameResolver.ResolveAsync(peerName, "Load");
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

        #region ピアイベント

        void peerNameResolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            string messsage = string.Format("ResolveCompleted UserState:{0}", e.UserState);
            if (e.Cancelled)
            {
                messsage = "[Cancelled]" + messsage;
            }
            AddLog(messsage, LogType.System);

            RestartTimer();
            bLoading = false;
        }

        void peerNameResolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            string messsage = string.Format("ResolveProgressChanged UserState:{0} ProgressPercentage:{1}", e.UserState, e.ProgressPercentage);
            AddLog(messsage, LogType.System);

            AddLog(e.PeerNameRecord);
            SetOtherUser(e.PeerNameRecord);
        }

        #endregion

        #endregion

        #region メソッド

        private void OpenPeer()
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

            IPAddress[] hostAddresses = null;
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

                hostAddresses = Dns.GetHostAddresses(textBoxIndexServerAddress.Text);
                if (hostAddresses == null || hostAddresses.Length == 0)
                {
                    MessageBox.Show(labelIndexServerAddress.Text + "が正しくありません。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabPageSetting;
                    textBoxIndexServerAddress.SelectAll();
                    textBoxIndexServerAddress.Focus();
                    return;
                }

                #endregion
            }

            #region 表示名の確認

            string displayName = MyData.DisplayName.Trim();
            if (string.IsNullOrWhiteSpace(displayName))
            {
                MessageBox.Show("DisplayNameを入力してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                propertyGridMyData.Focus();
                return;
            }

            #endregion

            peerName = new PeerName(Classifier, PeerNameType);

            peerNameRegistration = new PeerNameRegistration(peerName, PortNo)
            {
                Cloud = Cloud,
                Comment = myID
            };
            if (TargetGrobal)
            {
                #region インデックスサーバーの設定

                peerNameRegistration.UseAutoEndPointSelection = false;
                foreach (var hostAddress in hostAddresses)
                {
                    peerNameRegistration.EndPointCollection.Add(new IPEndPoint(hostAddress, PortNo));
                }

                #endregion
            }
            SetSendData();

            peerNameResolver = new PeerNameResolver();
            peerNameResolver.ResolveProgressChanged += peerNameResolver_ResolveProgressChanged;
            peerNameResolver.ResolveCompleted += peerNameResolver_ResolveCompleted;

            UpdateUI();

            peerNameRegistration.Start();

            AddLog("StartPeer", LogType.System);

            buttonLoad.PerformClick();
        }

        private void UpdateMyData()
        {
            SetSendData();
            peerNameRegistration.Update();

            AddLog("UpdateSend", LogType.System);
        }

        private void SetOtherUser(PeerNameRecord peerNameRecord)
        {
            Action action = () =>
                {
                    string id = peerNameRecord.Comment;
                    var userData = UserData.Deserialize(peerNameRecord.Data);

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

                            var addItem = listViewOtherUser.Items.Add(userData.DisplayName);
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

        private void UpdateUI()
        {
            textBoxClassifier.Enabled = !PeerOpened;
            radioButtonSecured.Enabled = !PeerOpened;
            radioButtonUnsecured.Enabled = !PeerOpened;
            radioButtonGlobal.Enabled = !PeerOpened;
            radioButtonAllLinkLocal.Enabled = !PeerOpened;
            radioButtonAvailable.Enabled = !PeerOpened;

            labelIndexServerAddress.Enabled = TargetGrobal && !PeerOpened;
            textBoxIndexServerAddress.Enabled = TargetGrobal && !PeerOpened;

            labelPortNo.Enabled = !PeerOpened;
            numericUpDownPortNo.Enabled = !PeerOpened;

            buttonStartOrUpdate.Text = PeerOpened ? "更新" : "開始";
            buttonClose.Enabled = PeerOpened;
            buttonLoad.Enabled = PeerOpened;

            labelInterval.Enabled = checkBoxAutoLoad.Checked;
            numericUpDownInterval.Enabled = checkBoxAutoLoad.Checked;
            labelIntervalUnit.Enabled = checkBoxAutoLoad.Checked;
        }

        private void SetSendData()
        {
            peerNameRegistration.Data = MyData.Serialize();
            AddLog(peerNameRegistration.Comment, MyData, LogType.Send);
        }

        private void ClosePeer()
        {
            if (!PeerOpened) return;

            timerLoad.Stop();

            peerNameResolver.ResolveProgressChanged -= peerNameResolver_ResolveProgressChanged;
            peerNameResolver.ResolveCompleted -= peerNameResolver_ResolveCompleted;
            peerNameResolver = null;

            peerNameRegistration.Stop();
            peerNameRegistration = null;
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

        #region AddLog

        enum LogType
        {
            System,
            Send,
            Received,
        }

        void AddLog(PeerNameRecord peerNameRecord)
        {
            AddLog(peerNameRecord.Comment, UserData.Deserialize(peerNameRecord.Data), LogType.Received);
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
