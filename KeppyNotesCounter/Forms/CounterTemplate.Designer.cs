namespace KeppyCounterGenerator
{
    partial class CounterTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.TemplateEditorBL = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TemplatesLabel = new System.Windows.Forms.Label();
            this.TemplatesBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TemplateEditorBR = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TemplateEditorTR = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TemplateEditorTL = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TemplateEditorTC = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TemplateEditorBC = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TemplateEditorMC = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TemplateEditorMR = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TemplateEditorML = new System.Windows.Forms.RichTextBox();
            this.OsuModeTL = new System.Windows.Forms.CheckBox();
            this.OsuModeTC = new System.Windows.Forms.CheckBox();
            this.OsuModeTR = new System.Windows.Forms.CheckBox();
            this.OsuModeML = new System.Windows.Forms.CheckBox();
            this.OsuModeMC = new System.Windows.Forms.CheckBox();
            this.OsuModeMR = new System.Windows.Forms.CheckBox();
            this.OsuModeBR = new System.Windows.Forms.CheckBox();
            this.OsuModeBC = new System.Windows.Forms.CheckBox();
            this.OsuModeBL = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(833, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit the following text, to edit the final output of the note counter generator.\r" +
    "\n\r\nExample:\r\nInput: Time {0}/{1} - Tempo {2}BPM\r\nOutput: Time 0:26.232/1:00.000 " +
    "- Tempo: 140BPM";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 82);
            this.label2.TabIndex = 2;
            this.label2.Text = "Passed/Total time: {0}/{1}\r\nTempo: {2}\r\nPlayed/Total notes: {3}/{4}\r\nTime signatu" +
    "re: {5}\r\nPPQN value: {6}\r\nCurrent/Total ticks: {7}/{8}";
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.Location = new System.Drawing.Point(774, 531);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(63, 23);
            this.ConfirmBtn.TabIndex = 3;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.Location = new System.Drawing.Point(709, 531);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(63, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // TemplateEditorBL
            // 
            this.TemplateEditorBL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TemplateEditorBL.Location = new System.Drawing.Point(12, 325);
            this.TemplateEditorBL.Name = "TemplateEditorBL";
            this.TemplateEditorBL.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorBL.TabIndex = 5;
            this.TemplateEditorBL.Text = "";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(547, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 82);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current/Total bars: {9}/{10}\r\nNotes per second: {11}\r\nAverage notes per second: {" +
    "12}\r\n\r\n\r\n[[CVn]]: Played notes on channel (n = Channel number)";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 420);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 102);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legend";
            // 
            // TemplatesLabel
            // 
            this.TemplatesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TemplatesLabel.AutoSize = true;
            this.TemplatesLabel.Location = new System.Drawing.Point(12, 536);
            this.TemplatesLabel.Name = "TemplatesLabel";
            this.TemplatesLabel.Size = new System.Drawing.Size(60, 13);
            this.TemplatesLabel.TabIndex = 8;
            this.TemplatesLabel.Text = "Templates:";
            // 
            // TemplatesBox
            // 
            this.TemplatesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TemplatesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TemplatesBox.FormattingEnabled = true;
            this.TemplatesBox.Items.AddRange(new object[] {
            "Custom",
            "MIDITrail Standard",
            "MIDITrail Vertical",
            "Essential",
            "WeimTime Template"});
            this.TemplatesBox.Location = new System.Drawing.Point(76, 533);
            this.TemplatesBox.Name = "TemplatesBox";
            this.TemplatesBox.Size = new System.Drawing.Size(211, 21);
            this.TemplatesBox.TabIndex = 9;
            this.TemplatesBox.SelectedIndexChanged += new System.EventHandler(this.TemplatesBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Bottom left";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(565, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bottom right";
            // 
            // TemplateEditorBR
            // 
            this.TemplateEditorBR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TemplateEditorBR.Location = new System.Drawing.Point(566, 325);
            this.TemplateEditorBR.Name = "TemplateEditorBR";
            this.TemplateEditorBR.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorBR.TabIndex = 12;
            this.TemplateEditorBR.Text = "";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(565, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Top right";
            // 
            // TemplateEditorTR
            // 
            this.TemplateEditorTR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TemplateEditorTR.Location = new System.Drawing.Point(566, 103);
            this.TemplateEditorTR.Name = "TemplateEditorTR";
            this.TemplateEditorTR.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorTR.TabIndex = 16;
            this.TemplateEditorTR.Text = "";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Top left";
            // 
            // TemplateEditorTL
            // 
            this.TemplateEditorTL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TemplateEditorTL.Location = new System.Drawing.Point(12, 103);
            this.TemplateEditorTL.Name = "TemplateEditorTL";
            this.TemplateEditorTL.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorTL.TabIndex = 14;
            this.TemplateEditorTL.Text = "";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Top center";
            // 
            // TemplateEditorTC
            // 
            this.TemplateEditorTC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TemplateEditorTC.Location = new System.Drawing.Point(289, 103);
            this.TemplateEditorTC.Name = "TemplateEditorTC";
            this.TemplateEditorTC.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorTC.TabIndex = 20;
            this.TemplateEditorTC.Text = "";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Bottom center";
            // 
            // TemplateEditorBC
            // 
            this.TemplateEditorBC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TemplateEditorBC.Location = new System.Drawing.Point(289, 325);
            this.TemplateEditorBC.Name = "TemplateEditorBC";
            this.TemplateEditorBC.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorBC.TabIndex = 18;
            this.TemplateEditorBC.Text = "";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(288, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Middle center";
            // 
            // TemplateEditorMC
            // 
            this.TemplateEditorMC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TemplateEditorMC.Location = new System.Drawing.Point(289, 214);
            this.TemplateEditorMC.Name = "TemplateEditorMC";
            this.TemplateEditorMC.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorMC.TabIndex = 26;
            this.TemplateEditorMC.Text = "";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(565, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Middle right";
            // 
            // TemplateEditorMR
            // 
            this.TemplateEditorMR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TemplateEditorMR.Location = new System.Drawing.Point(566, 214);
            this.TemplateEditorMR.Name = "TemplateEditorMR";
            this.TemplateEditorMR.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorMR.TabIndex = 24;
            this.TemplateEditorMR.Text = "";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 198);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Middle left";
            // 
            // TemplateEditorML
            // 
            this.TemplateEditorML.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TemplateEditorML.Location = new System.Drawing.Point(12, 214);
            this.TemplateEditorML.Name = "TemplateEditorML";
            this.TemplateEditorML.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorML.TabIndex = 22;
            this.TemplateEditorML.Text = "";
            // 
            // OsuModeTL
            // 
            this.OsuModeTL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OsuModeTL.AutoSize = true;
            this.OsuModeTL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OsuModeTL.Location = new System.Drawing.Point(205, 86);
            this.OsuModeTL.Name = "OsuModeTL";
            this.OsuModeTL.Size = new System.Drawing.Size(78, 17);
            this.OsuModeTL.TabIndex = 28;
            this.OsuModeTL.Text = "Osu! mode";
            this.OsuModeTL.UseVisualStyleBackColor = true;
            this.OsuModeTL.CheckedChanged += new System.EventHandler(this.OsuModeTL_CheckedChanged);
            // 
            // OsuModeTC
            // 
            this.OsuModeTC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OsuModeTC.AutoSize = true;
            this.OsuModeTC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OsuModeTC.Location = new System.Drawing.Point(482, 86);
            this.OsuModeTC.Name = "OsuModeTC";
            this.OsuModeTC.Size = new System.Drawing.Size(78, 17);
            this.OsuModeTC.TabIndex = 29;
            this.OsuModeTC.Text = "Osu! mode";
            this.OsuModeTC.UseVisualStyleBackColor = true;
            this.OsuModeTC.CheckedChanged += new System.EventHandler(this.OsuModeTC_CheckedChanged);
            // 
            // OsuModeTR
            // 
            this.OsuModeTR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OsuModeTR.AutoSize = true;
            this.OsuModeTR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OsuModeTR.Location = new System.Drawing.Point(759, 86);
            this.OsuModeTR.Name = "OsuModeTR";
            this.OsuModeTR.Size = new System.Drawing.Size(78, 17);
            this.OsuModeTR.TabIndex = 30;
            this.OsuModeTR.Text = "Osu! mode";
            this.OsuModeTR.UseVisualStyleBackColor = true;
            this.OsuModeTR.CheckedChanged += new System.EventHandler(this.OsuModeTR_CheckedChanged);
            // 
            // OsuModeML
            // 
            this.OsuModeML.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OsuModeML.AutoSize = true;
            this.OsuModeML.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OsuModeML.Location = new System.Drawing.Point(205, 197);
            this.OsuModeML.Name = "OsuModeML";
            this.OsuModeML.Size = new System.Drawing.Size(78, 17);
            this.OsuModeML.TabIndex = 31;
            this.OsuModeML.Text = "Osu! mode";
            this.OsuModeML.UseVisualStyleBackColor = true;
            this.OsuModeML.CheckedChanged += new System.EventHandler(this.OsuModeML_CheckedChanged);
            // 
            // OsuModeMC
            // 
            this.OsuModeMC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OsuModeMC.AutoSize = true;
            this.OsuModeMC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OsuModeMC.Location = new System.Drawing.Point(482, 197);
            this.OsuModeMC.Name = "OsuModeMC";
            this.OsuModeMC.Size = new System.Drawing.Size(78, 17);
            this.OsuModeMC.TabIndex = 32;
            this.OsuModeMC.Text = "Osu! mode";
            this.OsuModeMC.UseVisualStyleBackColor = true;
            this.OsuModeMC.CheckedChanged += new System.EventHandler(this.OsuModeMC_CheckedChanged);
            // 
            // OsuModeMR
            // 
            this.OsuModeMR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OsuModeMR.AutoSize = true;
            this.OsuModeMR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OsuModeMR.Location = new System.Drawing.Point(759, 197);
            this.OsuModeMR.Name = "OsuModeMR";
            this.OsuModeMR.Size = new System.Drawing.Size(78, 17);
            this.OsuModeMR.TabIndex = 33;
            this.OsuModeMR.Text = "Osu! mode";
            this.OsuModeMR.UseVisualStyleBackColor = true;
            this.OsuModeMR.CheckedChanged += new System.EventHandler(this.OsuModeMR_CheckedChanged);
            // 
            // OsuModeBR
            // 
            this.OsuModeBR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OsuModeBR.AutoSize = true;
            this.OsuModeBR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OsuModeBR.Location = new System.Drawing.Point(759, 308);
            this.OsuModeBR.Name = "OsuModeBR";
            this.OsuModeBR.Size = new System.Drawing.Size(78, 17);
            this.OsuModeBR.TabIndex = 34;
            this.OsuModeBR.Text = "Osu! mode";
            this.OsuModeBR.UseVisualStyleBackColor = true;
            this.OsuModeBR.CheckedChanged += new System.EventHandler(this.OsuModeBR_CheckedChanged);
            // 
            // OsuModeBC
            // 
            this.OsuModeBC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OsuModeBC.AutoSize = true;
            this.OsuModeBC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OsuModeBC.Location = new System.Drawing.Point(482, 308);
            this.OsuModeBC.Name = "OsuModeBC";
            this.OsuModeBC.Size = new System.Drawing.Size(78, 17);
            this.OsuModeBC.TabIndex = 35;
            this.OsuModeBC.Text = "Osu! mode";
            this.OsuModeBC.UseVisualStyleBackColor = true;
            this.OsuModeBC.CheckedChanged += new System.EventHandler(this.OsuModeBC_CheckedChanged);
            // 
            // OsuModeBL
            // 
            this.OsuModeBL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OsuModeBL.AutoSize = true;
            this.OsuModeBL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OsuModeBL.Location = new System.Drawing.Point(205, 308);
            this.OsuModeBL.Name = "OsuModeBL";
            this.OsuModeBL.Size = new System.Drawing.Size(78, 17);
            this.OsuModeBL.TabIndex = 36;
            this.OsuModeBL.Text = "Osu! mode";
            this.OsuModeBL.UseVisualStyleBackColor = true;
            this.OsuModeBL.CheckedChanged += new System.EventHandler(this.OsuModeBL_CheckedChanged);
            // 
            // CounterTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(849, 566);
            this.ControlBox = false;
            this.Controls.Add(this.OsuModeBL);
            this.Controls.Add(this.OsuModeBC);
            this.Controls.Add(this.OsuModeBR);
            this.Controls.Add(this.OsuModeMR);
            this.Controls.Add(this.OsuModeMC);
            this.Controls.Add(this.OsuModeML);
            this.Controls.Add(this.OsuModeTR);
            this.Controls.Add(this.OsuModeTC);
            this.Controls.Add(this.OsuModeTL);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TemplateEditorMC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TemplateEditorMR);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TemplateEditorML);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TemplateEditorTC);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TemplateEditorBC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TemplateEditorTR);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TemplateEditorTL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TemplateEditorBR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TemplatesBox);
            this.Controls.Add(this.TemplatesLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TemplateEditorBL);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CounterTemplate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Counter template editor";
            this.Load += new System.EventHandler(this.CounterTemplate_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.RichTextBox TemplateEditorBL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TemplatesLabel;
        private System.Windows.Forms.ComboBox TemplatesBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox TemplateEditorBR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox TemplateEditorTR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox TemplateEditorTL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TemplateEditorTC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox TemplateEditorBC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox TemplateEditorMC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox TemplateEditorMR;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox TemplateEditorML;
        private System.Windows.Forms.CheckBox OsuModeTL;
        private System.Windows.Forms.CheckBox OsuModeTC;
        private System.Windows.Forms.CheckBox OsuModeTR;
        private System.Windows.Forms.CheckBox OsuModeML;
        private System.Windows.Forms.CheckBox OsuModeMC;
        private System.Windows.Forms.CheckBox OsuModeMR;
        private System.Windows.Forms.CheckBox OsuModeBR;
        private System.Windows.Forms.CheckBox OsuModeBC;
        private System.Windows.Forms.CheckBox OsuModeBL;
    }
}