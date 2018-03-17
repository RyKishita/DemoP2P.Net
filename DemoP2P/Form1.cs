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
        Cloud cloud = null;
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

                cloud = GetInputCloud();

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
            SetLoadButton(true);
            AddLog("StartLoad", resolver.ResolveAsync());
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
                AddLog("RegistData", null, MyData.ToString());
            }
        }

        #region ピアイベント

        private void Resolver_ProgressChanged(ResolveToken token, int progressPercentage, UserData userData)
        {
            SetUserData(userData);
            AddLog(nameof(Resolver_ProgressChanged) + $"({progressPercentage})", token, userData.ToString());
        }

        private void Resolver_Completed(ResolveToken token, IEnumerable<UserData> userDatas, bool cancelled)
        {
            AddLog(nameof(Resolver_Completed), token, cancelled ? "Cancelled" : userDatas.Count().ToString() + "項目");

            if (!cancelled)
            {
                CheckDeleted(userDatas);
            }

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

            AddLog(nameof(OpenPeer));

            MakeResolver();
            MakeRegister();
        }

        private void ClosePeer()
        {
            timerLoad.Stop();
            DestroyResolver();
            DestroyRegister();

            AddLog(nameof(ClosePeer));
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

            resolver = new Resolver<UserData>(cloud, peerName);
            resolver.ProgressChanged += Resolver_ProgressChanged;
            resolver.Completed += Resolver_Completed;
        }

        private void DestroyResolver()
        {
            if (null == resolver) return;

            resolver.ProgressChanged -= Resolver_ProgressChanged;
            resolver.Completed -= Resolver_Completed;
            resolver.Dispose();
            resolver = null;
        }

        #region AddLog

        void AddLog(string actionName, ResolveToken token = null, string message = "")
        {
            listViewLog.BeginUpdate();
            try
            {
                var item = listViewLog.Items.Add(DateTime.Now.ToLongTimeString());
                item.SubItems.Add(null == token? "": token.ToString());
                item.SubItems.Add(actionName);
                item.SubItems.Add(message);
                if (checkBoxAutoScroll.Checked)
                {
                    item.EnsureVisible();
                }
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

        private void SetUserData(UserData userData)
        {
            listViewOtherUser.BeginUpdate();
            try
            {
                var items = listViewOtherUser.Items.Find(userData.ID, false);
                if (0 < items.Length)
                {
                    var item = items[0];
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
                addItem.Name = userData.ID;
                addItem.Tag = userData;
            }
            finally
            {
                listViewOtherUser.EndUpdate();
            }
        }

        private void CheckDeleted(IEnumerable<UserData> userDatas)
        {
            listViewOtherUser.BeginUpdate();
            try
            {
                var existIDs = userDatas.Select(userData => userData.ID);
                foreach(ListViewItem item in listViewOtherUser.Items)
                {
                    if (!existIDs.Contains(item.Name))
                    {
                        item.Remove();
                    }
                }
            }
            finally
            {
                listViewOtherUser.EndUpdate();
            }
        }

        #endregion

        #endregion
    }
}
