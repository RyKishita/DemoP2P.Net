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
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownPortNo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonGlobal = new System.Windows.Forms.RadioButton();
            this.radioButtonAllLinkLocal = new System.Windows.Forms.RadioButton();
            this.radioButtonAvailable = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.buttonStartOrUpdate = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelIntervalUnit = new System.Windows.Forms.Label();
            this.checkBoxShowSystemLog = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoLoad = new System.Windows.Forms.CheckBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPortNo)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelClassifier
            // 
            this.labelClassifier.AutoSize = true;
            this.labelClassifier.Location = new System.Drawing.Point(12, 15);
            this.labelClassifier.Name = "labelClassifier";
            this.labelClassifier.Size = new System.Drawing.Size(35, 12);
            this.labelClassifier.TabIndex = 0;
            this.labelClassifier.Text = "ピア名";
            // 
            // textBoxClassifier
            // 
            this.textBoxClassifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClassifier.Location = new System.Drawing.Point(122, 12);
            this.textBoxClassifier.Name = "textBoxClassifier";
            this.textBoxClassifier.Size = new System.Drawing.Size(331, 19);
            this.textBoxClassifier.TabIndex = 1;
            this.textBoxClassifier.Text = "testpeer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
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
            this.radioButtonUnsecured.Location = new System.Drawing.Point(3, 25);
            this.radioButtonUnsecured.Name = "radioButtonUnsecured";
            this.radioButtonUnsecured.Size = new System.Drawing.Size(117, 16);
            this.radioButtonUnsecured.TabIndex = 1;
            this.radioButtonUnsecured.TabStop = true;
            this.radioButtonUnsecured.Text = "セキュリティ保護なし";
            this.radioButtonUnsecured.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "ポート番号";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.radioButtonSecured);
            this.panel1.Controls.Add(this.radioButtonUnsecured);
            this.panel1.Location = new System.Drawing.Point(122, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 44);
            this.panel1.TabIndex = 3;
            // 
            // numericUpDownPortNo
            // 
            this.numericUpDownPortNo.Location = new System.Drawing.Point(122, 87);
            this.numericUpDownPortNo.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPortNo.Name = "numericUpDownPortNo";
            this.numericUpDownPortNo.Size = new System.Drawing.Size(76, 19);
            this.numericUpDownPortNo.TabIndex = 5;
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
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "ネットワークの範囲";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.radioButtonGlobal);
            this.panel2.Controls.Add(this.radioButtonAllLinkLocal);
            this.panel2.Controls.Add(this.radioButtonAvailable);
            this.panel2.Location = new System.Drawing.Point(122, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 66);
            this.panel2.TabIndex = 7;
            // 
            // radioButtonGlobal
            // 
            this.radioButtonGlobal.AutoSize = true;
            this.radioButtonGlobal.Checked = true;
            this.radioButtonGlobal.Location = new System.Drawing.Point(3, 47);
            this.radioButtonGlobal.Name = "radioButtonGlobal";
            this.radioButtonGlobal.Size = new System.Drawing.Size(61, 16);
            this.radioButtonGlobal.TabIndex = 2;
            this.radioButtonGlobal.TabStop = true;
            this.radioButtonGlobal.Text = "ローカル";
            this.radioButtonGlobal.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllLinkLocal
            // 
            this.radioButtonAllLinkLocal.AutoSize = true;
            this.radioButtonAllLinkLocal.Location = new System.Drawing.Point(3, 25);
            this.radioButtonAllLinkLocal.Name = "radioButtonAllLinkLocal";
            this.radioButtonAllLinkLocal.Size = new System.Drawing.Size(84, 16);
            this.radioButtonAllLinkLocal.TabIndex = 1;
            this.radioButtonAllLinkLocal.Text = "インターネット";
            this.radioButtonAllLinkLocal.UseVisualStyleBackColor = true;
            // 
            // radioButtonAvailable
            // 
            this.radioButtonAvailable.AutoSize = true;
            this.radioButtonAvailable.Location = new System.Drawing.Point(3, 3);
            this.radioButtonAvailable.Name = "radioButtonAvailable";
            this.radioButtonAvailable.Size = new System.Drawing.Size(178, 16);
            this.radioButtonAvailable.TabIndex = 0;
            this.radioButtonAvailable.Text = "現在使用可能なネットワーク全て";
            this.radioButtonAvailable.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "コメント";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxComment.Location = new System.Drawing.Point(122, 212);
            this.textBoxComment.MaxLength = 38;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(331, 19);
            this.textBoxComment.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "データ";
            // 
            // textBoxData
            // 
            this.textBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxData.Location = new System.Drawing.Point(122, 237);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(331, 19);
            this.textBoxData.TabIndex = 11;
            // 
            // buttonStartOrUpdate
            // 
            this.buttonStartOrUpdate.Location = new System.Drawing.Point(125, 262);
            this.buttonStartOrUpdate.Name = "buttonStartOrUpdate";
            this.buttonStartOrUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonStartOrUpdate.TabIndex = 12;
            this.buttonStartOrUpdate.Text = "開始";
            this.buttonStartOrUpdate.UseVisualStyleBackColor = true;
            this.buttonStartOrUpdate.Click += new System.EventHandler(this.buttonStartOrUpdate_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(206, 262);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "停止";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
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
            this.listViewLog.Location = new System.Drawing.Point(6, 18);
            this.listViewLog.MultiSelect = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(427, 122);
            this.listViewLog.TabIndex = 0;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // checkBoxAutoScroll
            // 
            this.checkBoxAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAutoScroll.AutoSize = true;
            this.checkBoxAutoScroll.Checked = true;
            this.checkBoxAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(6, 179);
            this.checkBoxAutoScroll.Name = "checkBoxAutoScroll";
            this.checkBoxAutoScroll.Size = new System.Drawing.Size(94, 16);
            this.checkBoxAutoScroll.TabIndex = 6;
            this.checkBoxAutoScroll.Text = "自動スクロール";
            this.checkBoxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // timerLoad
            // 
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // labelInterval
            // 
            this.labelInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(236, 148);
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
            this.numericUpDownInterval.Location = new System.Drawing.Point(295, 146);
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
            this.labelIntervalUnit.Location = new System.Drawing.Point(400, 148);
            this.labelIntervalUnit.Name = "labelIntervalUnit";
            this.labelIntervalUnit.Size = new System.Drawing.Size(31, 12);
            this.labelIntervalUnit.TabIndex = 5;
            this.labelIntervalUnit.Text = "ミリ秒";
            // 
            // checkBoxShowSystemLog
            // 
            this.checkBoxShowSystemLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowSystemLog.AutoSize = true;
            this.checkBoxShowSystemLog.Checked = true;
            this.checkBoxShowSystemLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowSystemLog.Location = new System.Drawing.Point(117, 179);
            this.checkBoxShowSystemLog.Name = "checkBoxShowSystemLog";
            this.checkBoxShowSystemLog.Size = new System.Drawing.Size(114, 16);
            this.checkBoxShowSystemLog.TabIndex = 7;
            this.checkBoxShowSystemLog.Text = "システムログの表示";
            this.checkBoxShowSystemLog.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoLoad
            // 
            this.checkBoxAutoLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAutoLoad.AutoSize = true;
            this.checkBoxAutoLoad.Checked = true;
            this.checkBoxAutoLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoLoad.Location = new System.Drawing.Point(154, 147);
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
            this.buttonLoad.Location = new System.Drawing.Point(5, 143);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(124, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "最新の情報に更新";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.listViewLog);
            this.groupBoxLog.Controls.Add(this.buttonLoad);
            this.groupBoxLog.Controls.Add(this.checkBoxAutoScroll);
            this.groupBoxLog.Controls.Add(this.labelIntervalUnit);
            this.groupBoxLog.Controls.Add(this.checkBoxAutoLoad);
            this.groupBoxLog.Controls.Add(this.numericUpDownInterval);
            this.groupBoxLog.Controls.Add(this.labelInterval);
            this.groupBoxLog.Controls.Add(this.checkBoxShowSystemLog);
            this.groupBoxLog.Location = new System.Drawing.Point(14, 291);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(439, 201);
            this.groupBoxLog.TabIndex = 14;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "ログ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 504);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonStartOrUpdate);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownPortNo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxClassifier);
            this.Controls.Add(this.labelClassifier);
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
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClassifier;
        private System.Windows.Forms.TextBox textBoxClassifier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonSecured;
        private System.Windows.Forms.RadioButton radioButtonUnsecured;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownPortNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonGlobal;
        private System.Windows.Forms.RadioButton radioButtonAllLinkLocal;
        private System.Windows.Forms.RadioButton radioButtonAvailable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Button buttonStartOrUpdate;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.CheckBox checkBoxAutoScroll;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label labelIntervalUnit;
        private System.Windows.Forms.CheckBox checkBoxShowSystemLog;
        private System.Windows.Forms.CheckBox checkBoxAutoLoad;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxLog;
    }
}

