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

        #endregion

        #region プロパティ

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

        #endregion

        #region イベント

        private void Form1_Load(object sender, EventArgs e)
        {
            MyData = new UserData();
            UpdateUI();
        }

        private void ButtonStartOrStop_Click(object sender, EventArgs e)
        {
            if (IsPeerOpened())
            {
                ClosePeer();

                OtherData = null;
                listViewOtherUser.Items.Clear();
                UpdateUI();
            }
            else
            {
                if (IsTargetGrobal())
                {
                    #region インデックスサーバー名の確認

                    string indexServerAddress = GetInputIndexServerAddress();

                    if (string.IsNullOrWhiteSpace(indexServerAddress))
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
                        peerName = PeerName.CreateFromPeerHostName(indexServerAddress);
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

                    string classifier = GetInputClassifier();

                    if (string.IsNullOrWhiteSpace(classifier))
                    {
                        MessageBox.Show(labelClassifier.Text + "を入力してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.SelectedTab = tabPageSetting;
                        textBoxClassifier.SelectAll();
                        textBoxClassifier.Focus();
                        return;
                    }

                    #endregion

                    peerName = new PeerName(classifier, GetSelectedPeerNameType());
                }

                OpenPeer();

                UpdateUI();
                buttonLoad.PerformClick();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePeer();
        }

        private void TimerLoad_Tick(object sender, EventArgs e)
        {
            timerLoad.Stop();
            buttonLoad.PerformClick();
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            if (!IsPeerOpened())
            {
                MessageBox.Show("開始していません。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AddLog("StartLoad", "");
            SetLoadButton(true);
            resolver.ResolveAsync();
        }

        private void CheckBoxAutoLoad_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
            if (checkBoxAutoLoad.Checked)
            {
                buttonLoad.PerformClick();
            }
        }

        private void RadioButtonNetwork_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void ListViewOtherUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            OtherData = GetSelectedOtherData();
        }

        private void PropertyGridMyData_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (IsPeerOpened())
            {
                register.RegistData(MyData);
                AddLog("RegistData", MyData.ToString());
            }
        }

        #region ピアイベント

        private void Resolver_AddNode(string id)
        {
            SetOtherUser(id);
            AddLog(nameof(Resolver_AddNode), id);
        }

        private void Resolver_UpdatNodeData(string id)
        {
            SetOtherUser(id);
            AddLog(nameof(Resolver_UpdatNodeData), id);
        }

        private void Resolver_DeleteNode(string id, UserData data)
        {
            DeleteOtherUser(id);
            AddLog(nameof(Resolver_DeleteNode), id);
        }

        private void Resolver_ProgressChanged(string userState, int progressPercentage)
        {
            AddLog(nameof(Resolver_ProgressChanged) + $"({progressPercentage})", $"UserState:{userState}");
        }

        private void Resolver_Completed(string userState, bool cancelled)
        {
            string messsage = $"UserState:{userState}";
            if (cancelled)
            {
                messsage = "[Cancelled]" + messsage;
            }
            AddLog(nameof(Resolver_Completed), messsage);

            RestartTimer();
            SetLoadButton(false);
        }

        void SetLoadButton(bool bON)
        {
            buttonLoad.Enabled = !bON;
            buttonLoad.Text = bON ? "読み込み中" : "最新の情報に更新";
        }

        #endregion

        #endregion

        #region メソッド

        private void OpenPeer()
        {
            if (null == peerName) return;

            AddLog(nameof(OpenPeer), "");

            MakeResolver();
            MakeRegister();
        }

        private void ClosePeer()
        {
            timerLoad.Stop();
            DestroyResolver();
            DestroyRegister();

            AddLog(nameof(ClosePeer), "");
        }

        private void SetOtherUser(string id)
        {
            UserData userData = resolver.GetItemData(id);

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

        private void DeleteOtherUser(string id)
        {
            UserData userData = resolver.GetItemData(id);

            var items = listViewOtherUser.Items.Find(id, false);
            if (items.Length == 1)
            {
                listViewOtherUser.Items.Remove(items[0]);
            }
        }

        private void UpdateUI()
        {
            #region Input

            buttonStartOrStop.Text = IsPeerOpened() ? "停止" : "開始";

            #endregion

            #region Setting

            panelSetting.Enabled = !IsPeerOpened();

            labelSecured.Enabled = !IsTargetGrobal();
            panelSecured.Enabled = !IsTargetGrobal();
            labelClassifier.Enabled = !IsTargetGrobal();
            textBoxClassifier.Enabled = !IsTargetGrobal();
            labelIndexServerAddress.Enabled = IsTargetGrobal();
            textBoxIndexServerAddress.Enabled = IsTargetGrobal();

            #endregion

            numericUpDownInterval.Enabled = checkBoxAutoLoad.Checked;
        }

        private void RestartTimer()
        {
            if (checkBoxAutoLoad.Checked)
            {
                timerLoad.Interval = Convert.ToInt32(numericUpDownInterval.Value) * 1000;
                timerLoad.Start();
            }
            else
            {
                timerLoad.Stop();
            }
        }

        private void MakeRegister()
        {
            DestroyRegister();

            register = new Register<UserData>(GetInputCloud(), peerName, GetInputPortNo());
            register.RegistData(MyData);
        }

        private void DestroyRegister()
        {
            if (null == register) return;

            register.Dispose();
            register = null;
        }

        private void MakeResolver()
        {
            DestroyResolver();

            resolver = new Resolver<UserData>(peerName);
            resolver.AddNode += Resolver_AddNode;
            resolver.UpdateNodeData += Resolver_UpdatNodeData;
            resolver.DeleteNode += Resolver_DeleteNode;
            resolver.ProgressChanged += Resolver_ProgressChanged;
            resolver.Completed += Resolver_Completed;
        }

        private void DestroyResolver()
        {
            if (null == resolver) return;

            resolver.AddNode -= Resolver_AddNode;
            resolver.UpdateNodeData -= Resolver_UpdatNodeData;
            resolver.DeleteNode -= Resolver_DeleteNode;
            resolver.ProgressChanged -= Resolver_ProgressChanged;
            resolver.Completed -= Resolver_Completed;
            resolver.Dispose();
            resolver = null;
        }

        #region AddLog

        void AddLog(string actionName, string message)
        {
            listViewLog.BeginUpdate();
            try
            {
                var item = listViewLog.Items.Add(DateTime.Now.ToLongTimeString());
                item.SubItems.Add(actionName);
                item.SubItems.Add(message);
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

        private string GetInputClassifier() => textBoxClassifier.Text.Trim();

        private string GetInputIndexServerAddress() => textBoxIndexServerAddress.Text.Trim();

        private bool IsPeerOpened() => register != null;

        private PeerNameType GetSelectedPeerNameType()
        {
            if (radioButtonSecured.Checked) return PeerNameType.Secured;
            if (radioButtonUnsecured.Checked) return PeerNameType.Unsecured;
            throw new NotImplementedException();
        }

        private int GetInputPortNo() => Convert.ToInt32(numericUpDownPortNo.Value);

        private Cloud GetInputCloud()
        {
            if (radioButtonGlobal.Checked) return Cloud.Global;
            if (radioButtonAllLinkLocal.Checked) return Cloud.AllLinkLocal;
            if (radioButtonAvailable.Checked) return Cloud.Available;
            throw new NotImplementedException();
        }

        private bool IsTargetGrobal() => radioButtonGlobal.Checked || radioButtonAvailable.Checked;

        private UserData GetSelectedOtherData()
        {
            UserData userData = null;
            if (listViewOtherUser.SelectedItems.Count == 1)
            {
                userData = listViewOtherUser.SelectedItems[0].Tag as UserData;
            }
            return userData;
        }

        #endregion

        #endregion
    }
}
