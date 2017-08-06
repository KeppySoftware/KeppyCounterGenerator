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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(825, 78);
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
            this.ConfirmBtn.Location = new System.Drawing.Point(766, 423);
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
            this.CancelBtn.Location = new System.Drawing.Point(701, 423);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(63, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // TemplateEditorBL
            // 
            this.TemplateEditorBL.Location = new System.Drawing.Point(12, 214);
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
            this.label3.Text = "Current/Total bars: {9}/{10}\r\nAverage notes per second: {11}\r\n\r\n\r\n\r\n[[CVn]]: Play" +
    "ed notes on channel (n = Channel number)";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 312);
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
            this.TemplatesLabel.Location = new System.Drawing.Point(12, 428);
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
            this.TemplatesBox.Location = new System.Drawing.Point(76, 425);
            this.TemplatesBox.Name = "TemplatesBox";
            this.TemplatesBox.Size = new System.Drawing.Size(211, 21);
            this.TemplatesBox.TabIndex = 9;
            this.TemplatesBox.SelectedIndexChanged += new System.EventHandler(this.TemplatesBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Bottom left";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(565, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bottom right";
            // 
            // TemplateEditorBR
            // 
            this.TemplateEditorBR.Location = new System.Drawing.Point(566, 214);
            this.TemplateEditorBR.Name = "TemplateEditorBR";
            this.TemplateEditorBR.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorBR.TabIndex = 12;
            this.TemplateEditorBR.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(565, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Top right";
            // 
            // TemplateEditorTR
            // 
            this.TemplateEditorTR.Location = new System.Drawing.Point(566, 103);
            this.TemplateEditorTR.Name = "TemplateEditorTR";
            this.TemplateEditorTR.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorTR.TabIndex = 16;
            this.TemplateEditorTR.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Top left";
            // 
            // TemplateEditorTL
            // 
            this.TemplateEditorTL.Location = new System.Drawing.Point(12, 103);
            this.TemplateEditorTL.Name = "TemplateEditorTL";
            this.TemplateEditorTL.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorTL.TabIndex = 14;
            this.TemplateEditorTL.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Top center";
            // 
            // TemplateEditorTC
            // 
            this.TemplateEditorTC.Location = new System.Drawing.Point(289, 103);
            this.TemplateEditorTC.Name = "TemplateEditorTC";
            this.TemplateEditorTC.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorTC.TabIndex = 20;
            this.TemplateEditorTC.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Bottom center";
            // 
            // TemplateEditorBC
            // 
            this.TemplateEditorBC.Location = new System.Drawing.Point(289, 214);
            this.TemplateEditorBC.Name = "TemplateEditorBC";
            this.TemplateEditorBC.Size = new System.Drawing.Size(271, 92);
            this.TemplateEditorBC.TabIndex = 18;
            this.TemplateEditorBC.Text = "";
            // 
            // CounterTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(841, 458);
            this.ControlBox = false;
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
    }
}