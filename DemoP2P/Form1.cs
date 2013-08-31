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

namespace DemoP2P
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PeerName peerName = null;
        PeerNameRegistration peerNameRegistration = null;
        PeerNameResolver peerNameResolver = null;
        bool bLoading = false;

        bool PeerOpened
        {
            get
            {
                return peerNameRegistration != null;
            }
        }

        #region 入力

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

        string Comment
        {
            get
            {
                return textBoxComment.Text.Trim();
            }
        }

        byte[] Data
        {
            get
            {
                string data = textBoxData.Text.Trim();
                return Encoding.Unicode.GetBytes(data);
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

        #endregion

        private void SetupPeer()
        {
            peerName = new PeerName(Classifier, PeerNameType);
            peerNameRegistration = new PeerNameRegistration(peerName, PortNo) { Cloud = Cloud };
            SetSendData();
            peerNameResolver = new PeerNameResolver();
            peerNameResolver.ResolveProgressChanged += peerNameResolver_ResolveProgressChanged;
            peerNameResolver.ResolveCompleted += peerNameResolver_ResolveCompleted;
        }

        private void UpdateUI()
        {
            textBoxClassifier.Enabled = !PeerOpened;
            radioButtonSecured.Enabled = !PeerOpened;
            radioButtonUnsecured.Enabled = !PeerOpened;
            numericUpDownPortNo.Enabled = !PeerOpened;
            radioButtonAvailable.Enabled = !PeerOpened;
            radioButtonAllLinkLocal.Enabled = !PeerOpened;
            radioButtonGlobal.Enabled = !PeerOpened;

            buttonStartOrUpdate.Text = PeerOpened ? "更新" : "開始";
            buttonClose.Enabled = PeerOpened;
            buttonLoad.Enabled = PeerOpened;

            labelInterval.Enabled = checkBoxAutoLoad.Checked;
            numericUpDownInterval.Enabled = checkBoxAutoLoad.Checked;
            labelIntervalUnit.Enabled = checkBoxAutoLoad.Checked;
        }

        private void SetSendData()
        {
            peerNameRegistration.Comment = Comment;
            peerNameRegistration.Data = Data;
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

        private void buttonStartOrUpdate_Click(object sender, EventArgs e)
        {
            if (PeerOpened)
            {
                SetSendData();
                peerNameRegistration.Update();

                AddLog("UpdateSend", LogType.System);
                AddLog(Comment, Data, LogType.Send);
            }
            else
            {
                #region 入力ピア名の検証

                if (string.IsNullOrWhiteSpace(Classifier))
                {
                    MessageBox.Show(labelClassifier.Text + "を入力してください。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxClassifier.SelectAll();
                    textBoxClassifier.Focus();
                    return;
                }

                #endregion

                SetupPeer();
                UpdateUI();

                peerNameRegistration.Start();

                AddLog("StartPeer", LogType.System);
                AddLog(Comment, Data, LogType.Send);

                buttonLoad.PerformClick();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePeer();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            ClosePeer();
            UpdateUI();
            AddLog("ClosePeer", LogType.System);
        }

        void peerNameResolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            string messsage = string.Format("ResolveCompleted UserState:{0}", e.UserState);
            if (e.Cancelled)
            {
                messsage = "[Cancelled]" + messsage;
            }
            AddLog(messsage, LogType.System);

            if (checkBoxAutoLoad.Checked)
            {
                timerLoad.Interval = Convert.ToInt32(numericUpDownInterval.Value);
                timerLoad.Start();
            }
            bLoading = false;
        }

        void peerNameResolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            string messsage = string.Format("ResolveProgressChanged UserState:{0} ProgressPercentage:{1}", e.UserState, e.ProgressPercentage);
            AddLog(messsage, LogType.System);

            AddLog(e.PeerNameRecord);
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
            if (!bLoading && checkBoxAutoLoad.Checked)
            {
                buttonLoad.PerformClick();
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
            AddLog(peerNameRecord.Comment, peerNameRecord.Data, LogType.Received);
        }

        private void AddLog(PeerNameRecordCollection peerNameRecordCollection)
        {
            foreach (PeerNameRecord peerNameRecord in peerNameRecordCollection)
            {
                AddLog(peerNameRecord);
            }
        }

        void AddLog(string comment, byte[] data, LogType logType)
        {
            string dataText = Encoding.Unicode.GetString(data);
            AddLog(string.Format("{0} : {1}", comment, dataText), logType);
        }

        void AddLog(string message, LogType logType)
        {
            Action addLog = () =>
            {
                #region addLog

                if (checkBoxShowSystemLog.Checked && logType == LogType.System) return;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
