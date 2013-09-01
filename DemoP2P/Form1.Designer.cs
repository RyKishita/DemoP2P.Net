namespace DemoP2P
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelClassifier = new System.Windows.Forms.Label();
            this.textBoxClassifier = new System.Windows.Forms.TextBox();
            this.labelSecured = new System.Windows.Forms.Label();
            this.radioButtonSecured = new System.Windows.Forms.RadioButton();
            this.radioButtonUnsecured = new System.Windows.Forms.RadioButton();
            this.labelPortNo = new System.Windows.Forms.Label();
            this.panelSecured = new System.Windows.Forms.Panel();
            this.numericUpDownPortNo = new System.Windows.Forms.NumericUpDown();
            this.labelNetwork = new System.Windows.Forms.Label();
            this.panelNetwork = new System.Windows.Forms.Panel();
            this.radioButtonGlobal = new System.Windows.Forms.RadioButton();
            this.radioButtonAllLinkLocal = new System.Windows.Forms.RadioButton();
            this.radioButtonAvailable = new System.Windows.Forms.RadioButton();
            this.buttonStartOrStop = new System.Windows.Forms.Button();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelIntervalUnit = new System.Windows.Forms.Label();
            this.checkBoxAutoLoad = new System.Windows.Forms.CheckBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.labelIndexServerAddress = new System.Windows.Forms.Label();
            this.textBoxIndexServerAddress = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInput = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.propertyGridMyData = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewOtherUser = new System.Windows.Forms.ListView();
            this.columnHeaderDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.propertyGridOtherData = new System.Windows.Forms.PropertyGrid();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            this.panelSecured.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPortNo)).BeginInit();
            this.panelNetwork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPageSetting.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelClassifier
            // 
            this.labelClassifier.AutoSize = true;
            this.labelClassifier.Location = new System.Drawing.Point(4, 36);
            this.labelClassifier.Name = "labelClassifier";
            this.labelClassifier.Size = new System.Drawing.Size(35, 12);
            this.labelClassifier.TabIndex = 2;
            this.labelClassifier.Text = "ピア名";
            // 
            // textBoxClassifier
            // 
            this.textBoxClassifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClassifier.Location = new System.Drawing.Point(160, 33);
            this.textBoxClassifier.Name = "textBoxClassifier";
            this.textBoxClassifier.Size = new System.Drawing.Size(263, 19);
            this.textBoxClassifier.TabIndex = 3;
            this.textBoxClassifier.Text = "testpeer";
            // 
            // labelSecured
            // 
            this.labelSecured.AutoSize = true;
            this.labelSecured.Location = new System.Drawing.Point(4, 63);
            this.labelSecured.Name = "labelSecured";
            this.labelSecured.Size = new System.Drawing.Size(47, 12);
            this.labelSecured.TabIndex = 4;
            this.labelSecured.Text = "ピア種類";
            // 
            // radioButtonSecured
            // 
            this.radioButtonSecured.AutoSize = true;
            this.radioButtonSecured.Location = new System.Drawing.Point(3, 3);
            this.radioButtonSecured.Name = "radioButtonSecured";
            this.radioButtonSecured.Size = new System.Drawing.Size(116, 16);
            this.radioButtonSecured.TabIndex = 0;
            this.radioButtonSecured.Text = "セキュリティ保護あり";
            this.radioButtonSecured.UseVisualStyleBackColor = true;
            // 
            // radioButtonUnsecured
            // 
            this.radioButtonUnsecured.AutoSize = true;
            this.radioButtonUnsecured.Checked = true;
            this.radioButtonUnsecured.Location = new System.Drawing.Point(130, 3);
            this.radioButtonUnsecured.Name = "radioButtonUnsecured";
            this.radioButtonUnsecured.Size = new System.Drawing.Size(117, 16);
            this.radioButtonUnsecured.TabIndex = 1;
            this.radioButtonUnsecured.TabStop = true;
            this.radioButtonUnsecured.Text = "セキュリティ保護なし";
            this.radioButtonUnsecured.UseVisualStyleBackColor = true;
            // 
            // labelPortNo
            // 
            this.labelPortNo.AutoSize = true;
            this.labelPortNo.Location = new System.Drawing.Point(4, 113);
            this.labelPortNo.Name = "labelPortNo";
            this.labelPortNo.Size = new System.Drawing.Size(57, 12);
            this.labelPortNo.TabIndex = 8;
            this.labelPortNo.Text = "ポート番号";
            // 
            // panelSecured
            // 
            this.panelSecured.AutoSize = true;
            this.panelSecured.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSecured.Controls.Add(this.radioButtonSecured);
            this.panelSecured.Controls.Add(this.radioButtonUnsecured);
            this.panelSecured.Location = new System.Drawing.Point(160, 58);
            this.panelSecured.Name = "panelSecured";
            this.panelSecured.Size = new System.Drawing.Size(250, 22);
            this.panelSecured.TabIndex = 5;
            // 
            // numericUpDownPortNo
            // 
            this.numericUpDownPortNo.Location = new System.Drawing.Point(160, 111);
            this.numericUpDownPortNo.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPortNo.Name = "numericUpDownPortNo";
            this.numericUpDownPortNo.Size = new System.Drawing.Size(76, 19);
            this.numericUpDownPortNo.TabIndex = 9;
            this.numericUpDownPortNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPortNo.Value = new decimal(new int[] {
            45678,
            0,
            0,
            0});
            // 
            // labelNetwork
            // 
            this.labelNetwork.AutoSize = true;
            this.labelNetwork.Location = new System.Drawing.Point(4, 12);
            this.labelNetwork.Name = "labelNetwork";
            this.labelNetwork.Size = new System.Drawing.Size(91, 12);
            this.labelNetwork.TabIndex = 0;
            this.labelNetwork.Text = "ネットワークの範囲";
            // 
            // panelNetwork
            // 
            this.panelNetwork.AutoSize = true;
            this.panelNetwork.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelNetwork.Controls.Add(this.radioButtonGlobal);
            this.panelNetwork.Controls.Add(this.radioButtonAllLinkLocal);
            this.panelNetwork.Controls.Add(this.radioButtonAvailable);
            this.panelNetwork.Location = new System.Drawing.Point(160, 5);
            this.panelNetwork.Name = "panelNetwork";
            this.panelNetwork.Size = new System.Drawing.Size(197, 22);
            this.panelNetwork.TabIndex = 1;
            // 
            // radioButtonGlobal
            // 
            this.radioButtonGlobal.AutoSize = true;
            this.radioButtonGlobal.Location = new System.Drawing.Point(3, 3);
            this.radioButtonGlobal.Name = "radioButtonGlobal";
            this.radioButtonGlobal.Size = new System.Drawing.Size(71, 16);
            this.radioButtonGlobal.TabIndex = 0;
            this.radioButtonGlobal.Text = "グローバル";
            this.radioButtonGlobal.UseVisualStyleBackColor = true;
            this.radioButtonGlobal.CheckedChanged += new System.EventHandler(this.radioButtonNetwork_CheckedChanged);
            // 
            // radioButtonAllLinkLocal
            // 
            this.radioButtonAllLinkLocal.AutoSize = true;
            this.radioButtonAllLinkLocal.Checked = true;
            this.radioButtonAllLinkLocal.Location = new System.Drawing.Point(80, 3);
            this.radioButtonAllLinkLocal.Name = "radioButtonAllLinkLocal";
            this.radioButtonAllLinkLocal.Size = new System.Drawing.Size(61, 16);
            this.radioButtonAllLinkLocal.TabIndex = 1;
            this.radioButtonAllLinkLocal.TabStop = true;
            this.radioButtonAllLinkLocal.Text = "ローカル";
            this.radioButtonAllLinkLocal.UseVisualStyleBackColor = true;
            this.radioButtonAllLinkLocal.CheckedChanged += new System.EventHandler(this.radioButtonNetwork_CheckedChanged);
            // 
            // radioButtonAvailable
            // 
            this.radioButtonAvailable.AutoSize = true;
            this.radioButtonAvailable.Location = new System.Drawing.Point(147, 3);
            this.radioButtonAvailable.Name = "radioButtonAvailable";
            this.radioButtonAvailable.Size = new System.Drawing.Size(47, 16);
            this.radioButtonAvailable.TabIndex = 2;
            this.radioButtonAvailable.Text = "両方";
            this.radioButtonAvailable.UseVisualStyleBackColor = true;
            this.radioButtonAvailable.CheckedChanged += new System.EventHandler(this.radioButtonNetwork_CheckedChanged);
            // 
            // buttonStartOrStop
            // 
            this.buttonStartOrStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStartOrStop.Location = new System.Drawing.Point(3, 109);
            this.buttonStartOrStop.Name = "buttonStartOrStop";
            this.buttonStartOrStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStartOrStop.TabIndex = 4;
            this.buttonStartOrStop.Text = "開始";
            this.buttonStartOrStop.UseVisualStyleBackColor = true;
            this.buttonStartOrStop.Click += new System.EventHandler(this.buttonStartOrStop_Click);
            // 
            // listViewLog
            // 
            this.listViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewLog.Location = new System.Drawing.Point(3, 3);
            this.listViewLog.MultiSelect = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(426, 335);
            this.listViewLog.TabIndex = 0;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // timerLoad
            // 
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // labelInterval
            // 
            this.labelInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(224, 413);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(53, 12);
            this.labelInterval.TabIndex = 3;
            this.labelInterval.Text = "更新間隔";
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownInterval.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownInterval.Location = new System.Drawing.Point(283, 410);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(99, 19);
            this.numericUpDownInterval.TabIndex = 4;
            this.numericUpDownInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // labelIntervalUnit
            // 
            this.labelIntervalUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIntervalUnit.AutoSize = true;
            this.labelIntervalUnit.Location = new System.Drawing.Point(388, 413);
            this.labelIntervalUnit.Name = "labelIntervalUnit";
            this.labelIntervalUnit.Size = new System.Drawing.Size(31, 12);
            this.labelIntervalUnit.TabIndex = 5;
            this.labelIntervalUnit.Text = "ミリ秒";
            // 
            // checkBoxAutoLoad
            // 
            this.checkBoxAutoLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAutoLoad.AutoSize = true;
            this.checkBoxAutoLoad.Checked = true;
            this.checkBoxAutoLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoLoad.Location = new System.Drawing.Point(142, 411);
            this.checkBoxAutoLoad.Name = "checkBoxAutoLoad";
            this.checkBoxAutoLoad.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoLoad.TabIndex = 2;
            this.checkBoxAutoLoad.Text = "自動更新";
            this.checkBoxAutoLoad.UseVisualStyleBackColor = true;
            this.checkBoxAutoLoad.CheckedChanged += new System.EventHandler(this.checkBoxAutoLoad_CheckedChanged);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoad.Location = new System.Drawing.Point(12, 407);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(124, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "最新の情報に更新";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // labelIndexServerAddress
            // 
            this.labelIndexServerAddress.AutoSize = true;
            this.labelIndexServerAddress.Location = new System.Drawing.Point(4, 89);
            this.labelIndexServerAddress.Name = "labelIndexServerAddress";
            this.labelIndexServerAddress.Size = new System.Drawing.Size(133, 12);
            this.labelIndexServerAddress.TabIndex = 6;
            this.labelIndexServerAddress.Text = "インデックスサーバーアドレス";
            // 
            // textBoxIndexServerAddress
            // 
            this.textBoxIndexServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIndexServerAddress.Location = new System.Drawing.Point(160, 86);
            this.textBoxIndexServerAddress.Name = "textBoxIndexServerAddress";
            this.textBoxIndexServerAddress.Size = new System.Drawing.Size(263, 19);
            this.textBoxIndexServerAddress.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageInput);
            this.tabControl1.Controls.Add(this.tabPageSetting);
            this.tabControl1.Controls.Add(this.tabPageLog);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(440, 389);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageInput
            // 
            this.tabPageInput.Controls.Add(this.splitContainer2);
            this.tabPageInput.Location = new System.Drawing.Point(4, 22);
            this.tabPageInput.Name = "tabPageInput";
            this.tabPageInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInput.Size = new System.Drawing.Size(432, 363);
            this.tabPageInput.TabIndex = 0;
            this.tabPageInput.Text = "入力";
            this.tabPageInput.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.propertyGridMyData);
            this.splitContainer2.Panel1.Controls.Add(this.buttonStartOrStop);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(426, 357);
            this.splitContainer2.SplitterDistance = 135;
            this.splitContainer2.TabIndex = 9;
            // 
            // propertyGridMyData
            // 
            this.propertyGridMyData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridMyData.HelpVisible = false;
            this.propertyGridMyData.Location = new System.Drawing.Point(3, 3);
            this.propertyGridMyData.Name = "propertyGridMyData";
            this.propertyGridMyData.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridMyData.Size = new System.Drawing.Size(420, 100);
            this.propertyGridMyData.TabIndex = 6;
            this.propertyGridMyData.ToolbarVisible = false;
            this.propertyGridMyData.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridMyData_PropertyValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewOtherUser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGridOtherData);
            this.splitContainer1.Size = new System.Drawing.Size(426, 218);
            this.splitContainer1.SplitterDistance = 141;
            this.splitContainer1.TabIndex = 8;
            // 
            // listViewOtherUser
            // 
            this.listViewOtherUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewOtherUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDisplayName});
            this.listViewOtherUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOtherUser.FullRowSelect = true;
            this.listViewOtherUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOtherUser.HideSelection = false;
            this.listViewOtherUser.Location = new System.Drawing.Point(0, 0);
            this.listViewOtherUser.MultiSelect = false;
            this.listViewOtherUser.Name = "listViewOtherUser";
            this.listViewOtherUser.Size = new System.Drawing.Size(141, 218);
            this.listViewOtherUser.TabIndex = 7;
            this.listViewOtherUser.UseCompatibleStateImageBehavior = false;
            this.listViewOtherUser.View = System.Windows.Forms.View.Details;
            this.listViewOtherUser.SelectedIndexChanged += new System.EventHandler(this.listViewOtherUser_SelectedIndexChanged);
            // 
            // columnHeaderDisplayName
            // 
            this.columnHeaderDisplayName.Text = "DisplayName";
            this.columnHeaderDisplayName.Width = 118;
            // 
            // propertyGridOtherData
            // 
            this.propertyGridOtherData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridOtherData.HelpVisible = false;
            this.propertyGridOtherData.Location = new System.Drawing.Point(0, 0);
            this.propertyGridOtherData.Name = "propertyGridOtherData";
            this.propertyGridOtherData.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridOtherData.Size = new System.Drawing.Size(281, 218);
            this.propertyGridOtherData.TabIndex = 7;
            this.propertyGridOtherData.ToolbarVisible = false;
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.panelSetting);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(432, 363);
            this.tabPageSetting.TabIndex = 1;
            this.tabPageSetting.Text = "設定";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.panelNetwork);
            this.panelSetting.Controls.Add(this.labelClassifier);
            this.panelSetting.Controls.Add(this.labelNetwork);
            this.panelSetting.Controls.Add(this.textBoxIndexServerAddress);
            this.panelSetting.Controls.Add(this.numericUpDownPortNo);
            this.panelSetting.Controls.Add(this.textBoxClassifier);
            this.panelSetting.Controls.Add(this.panelSecured);
            this.panelSetting.Controls.Add(this.labelIndexServerAddress);
            this.panelSetting.Controls.Add(this.labelPortNo);
            this.panelSetting.Controls.Add(this.labelSecured);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(3, 3);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(426, 357);
            this.panelSetting.TabIndex = 10;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.checkBoxAutoScroll);
            this.tabPageLog.Controls.Add(this.listViewLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Size = new System.Drawing.Size(432, 363);
            this.tabPageLog.TabIndex = 2;
            this.tabPageLog.Text = "ログ";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoScroll
            // 
            this.checkBoxAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAutoScroll.AutoSize = true;
            this.checkBoxAutoScroll.Checked = true;
            this.checkBoxAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(3, 344);
            this.checkBoxAutoScroll.Name = "checkBoxAutoScroll";
            this.checkBoxAutoScroll.Size = new System.Drawing.Size(94, 16);
            this.checkBoxAutoScroll.TabIndex = 1;
            this.checkBoxAutoScroll.Text = "自動スクロール";
            this.checkBoxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 442);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkBoxAutoLoad);
            this.Controls.Add(this.labelIntervalUnit);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.numericUpDownInterval);
            this.MinimumSize = new System.Drawing.Size(480, 480);
            this.Name = "Form1";
            this.Text = "P2Pデモ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSecured.ResumeLayout(false);
            this.panelSecured.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPortNo)).EndInit();
            this.panelNetwork.ResumeLayout(false);
            this.panelNetwork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageInput.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPageSetting.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelSetting.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClassifier;
        private System.Windows.Forms.TextBox textBoxClassifier;
        private System.Windows.Forms.Label labelSecured;
        private System.Windows.Forms.RadioButton radioButtonSecured;
        private System.Windows.Forms.RadioButton radioButtonUnsecured;
        private System.Windows.Forms.Label labelPortNo;
        private System.Windows.Forms.Panel panelSecured;
        private System.Windows.Forms.NumericUpDown numericUpDownPortNo;
        private System.Windows.Forms.Label labelNetwork;
        private System.Windows.Forms.Panel panelNetwork;
        private System.Windows.Forms.RadioButton radioButtonGlobal;
        private System.Windows.Forms.RadioButton radioButtonAllLinkLocal;
        private System.Windows.Forms.RadioButton radioButtonAvailable;
        private System.Windows.Forms.Button buttonStartOrStop;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label labelIntervalUnit;
        private System.Windows.Forms.CheckBox checkBoxAutoLoad;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label labelIndexServerAddress;
        private System.Windows.Forms.TextBox textBoxIndexServerAddress;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInput;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.CheckBox checkBoxAutoScroll;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid propertyGridMyData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewOtherUser;
        private System.Windows.Forms.ColumnHeader columnHeaderDisplayName;
        private System.Windows.Forms.PropertyGrid propertyGridOtherData;
        private System.Windows.Forms.Panel panelSetting;
    }
}

