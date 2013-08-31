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
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonSecured = new System.Windows.Forms.RadioButton();
            this.radioButtonUnsecured = new System.Windows.Forms.RadioButton();
            this.labelPortNo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownPortNo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonGlobal = new System.Windows.Forms.RadioButton();
            this.radioButtonAllLinkLocal = new System.Windows.Forms.RadioButton();
            this.radioButtonAvailable = new System.Windows.Forms.RadioButton();
            this.buttonStartOrUpdate = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
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
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPortNo)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelClassifier
            // 
            this.labelClassifier.AutoSize = true;
            this.labelClassifier.Location = new System.Drawing.Point(7, 9);
            this.labelClassifier.Name = "labelClassifier";
            this.labelClassifier.Size = new System.Drawing.Size(35, 12);
            this.labelClassifier.TabIndex = 0;
            this.labelClassifier.Text = "ピア名";
            // 
            // textBoxClassifier
            // 
            this.textBoxClassifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClassifier.Location = new System.Drawing.Point(163, 6);
            this.textBoxClassifier.Name = "textBoxClassifier";
            this.textBoxClassifier.Size = new System.Drawing.Size(264, 19);
            this.textBoxClassifier.TabIndex = 1;
            this.textBoxClassifier.Text = "testpeer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ピア種類";
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
            this.labelPortNo.Location = new System.Drawing.Point(7, 114);
            this.labelPortNo.Name = "labelPortNo";
            this.labelPortNo.Size = new System.Drawing.Size(57, 12);
            this.labelPortNo.TabIndex = 8;
            this.labelPortNo.Text = "ポート番号";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.radioButtonSecured);
            this.panel1.Controls.Add(this.radioButtonUnsecured);
            this.panel1.Location = new System.Drawing.Point(163, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 22);
            this.panel1.TabIndex = 3;
            // 
            // numericUpDownPortNo
            // 
            this.numericUpDownPortNo.Location = new System.Drawing.Point(163, 112);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "ネットワークの範囲";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.radioButtonGlobal);
            this.panel2.Controls.Add(this.radioButtonAllLinkLocal);
            this.panel2.Controls.Add(this.radioButtonAvailable);
            this.panel2.Location = new System.Drawing.Point(163, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 22);
            this.panel2.TabIndex = 5;
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
            // buttonStartOrUpdate
            // 
            this.buttonStartOrUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStartOrUpdate.Location = new System.Drawing.Point(3, 133);
            this.buttonStartOrUpdate.Name = "buttonStartOrUpdate";
            this.buttonStartOrUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonStartOrUpdate.TabIndex = 4;
            this.buttonStartOrUpdate.Text = "開始";
            this.buttonStartOrUpdate.UseVisualStyleBackColor = true;
            this.buttonStartOrUpdate.Click += new System.EventHandler(this.buttonStartOrUpdate_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.Location = new System.Drawing.Point(84, 133);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "停止";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // listViewLog
            // 
            this.listViewLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewLog.Location = new System.Drawing.Point(3, 3);
            this.listViewLog.MultiSelect = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(427, 397);
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
            this.labelInterval.Location = new System.Drawing.Point(224, 475);
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
            this.numericUpDownInterval.Location = new System.Drawing.Point(283, 472);
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
            this.labelIntervalUnit.Location = new System.Drawing.Point(388, 475);
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
            this.checkBoxAutoLoad.Location = new System.Drawing.Point(142, 473);
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
            this.buttonLoad.Location = new System.Drawing.Point(12, 469);
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
            this.labelIndexServerAddress.Location = new System.Drawing.Point(7, 90);
            this.labelIndexServerAddress.Name = "labelIndexServerAddress";
            this.labelIndexServerAddress.Size = new System.Drawing.Size(133, 12);
            this.labelIndexServerAddress.TabIndex = 6;
            this.labelIndexServerAddress.Text = "インデックスサーバーアドレス";
            // 
            // textBoxIndexServerAddress
            // 
            this.textBoxIndexServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIndexServerAddress.Location = new System.Drawing.Point(163, 87);
            this.textBoxIndexServerAddress.Name = "textBoxIndexServerAddress";
            this.textBoxIndexServerAddress.Size = new System.Drawing.Size(264, 19);
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
            this.tabControl1.Size = new System.Drawing.Size(441, 451);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageInput
            // 
            this.tabPageInput.Controls.Add(this.splitContainer2);
            this.tabPageInput.Location = new System.Drawing.Point(4, 22);
            this.tabPageInput.Name = "tabPageInput";
            this.tabPageInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInput.Size = new System.Drawing.Size(433, 425);
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
            this.splitContainer2.Panel1.Controls.Add(this.buttonClose);
            this.splitContainer2.Panel1.Controls.Add(this.buttonStartOrUpdate);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(427, 419);
            this.splitContainer2.SplitterDistance = 159;
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
            this.propertyGridMyData.Size = new System.Drawing.Size(421, 124);
            this.propertyGridMyData.TabIndex = 6;
            this.propertyGridMyData.ToolbarVisible = false;
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
            this.splitContainer1.Size = new System.Drawing.Size(427, 256);
            this.splitContainer1.SplitterDistance = 142;
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
            this.listViewOtherUser.Size = new System.Drawing.Size(142, 256);
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
            this.propertyGridOtherData.Size = new System.Drawing.Size(281, 256);
            this.propertyGridOtherData.TabIndex = 7;
            this.propertyGridOtherData.ToolbarVisible = false;
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.labelClassifier);
            this.tabPageSetting.Controls.Add(this.textBoxIndexServerAddress);
            this.tabPageSetting.Controls.Add(this.textBoxClassifier);
            this.tabPageSetting.Controls.Add(this.labelIndexServerAddress);
            this.tabPageSetting.Controls.Add(this.label2);
            this.tabPageSetting.Controls.Add(this.labelPortNo);
            this.tabPageSetting.Controls.Add(this.panel1);
            this.tabPageSetting.Controls.Add(this.numericUpDownPortNo);
            this.tabPageSetting.Controls.Add(this.label4);
            this.tabPageSetting.Controls.Add(this.panel2);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(433, 425);
            this.tabPageSetting.TabIndex = 1;
            this.tabPageSetting.Text = "設定";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.checkBoxAutoScroll);
            this.tabPageLog.Controls.Add(this.listViewLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Size = new System.Drawing.Size(433, 425);
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
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(3, 406);
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
            this.ClientSize = new System.Drawing.Size(465, 504);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkBoxAutoLoad);
            this.Controls.Add(this.labelIntervalUnit);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.numericUpDownInterval);
            this.Name = "Form1";
            this.Text = "P2Pデモ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPortNo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
            this.tabPageSetting.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClassifier;
        private System.Windows.Forms.TextBox textBoxClassifier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonSecured;
        private System.Windows.Forms.RadioButton radioButtonUnsecured;
        private System.Windows.Forms.Label labelPortNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownPortNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonGlobal;
        private System.Windows.Forms.RadioButton radioButtonAllLinkLocal;
        private System.Windows.Forms.RadioButton radioButtonAvailable;
        private System.Windows.Forms.Button buttonStartOrUpdate;
        private System.Windows.Forms.Button buttonClose;
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
    }
}

