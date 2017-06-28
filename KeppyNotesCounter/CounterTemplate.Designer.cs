namespace KeppyNotesCounter
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
            this.TemplateEditor = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TemplatesLabel = new System.Windows.Forms.Label();
            this.TemplatesBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit the following text, to edit the final output of the note counter generator.\r" +
    "\n\r\nExample:\r\nInput: Time {0}/{1} - Tempo {2}BPM\r\nOutput: Time 0:26.232/1:00.000 " +
    "- Tempo: 140BPM";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 70);
            this.label2.TabIndex = 2;
            this.label2.Text = "Passed/Total time: {0}/{1}\r\nTempo: {2}\r\nPlayed/Total notes: {3}/{4}\r\nTime signatu" +
    "re: {5}\r\nPPQN value: {6}";
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.Location = new System.Drawing.Point(296, 278);
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
            this.CancelBtn.Location = new System.Drawing.Point(231, 278);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(63, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // TemplateEditor
            // 
            this.TemplateEditor.Location = new System.Drawing.Point(9, 93);
            this.TemplateEditor.Name = "TemplateEditor";
            this.TemplateEditor.Size = new System.Drawing.Size(351, 83);
            this.TemplateEditor.TabIndex = 5;
            this.TemplateEditor.Text = "";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(175, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 70);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current/Total ticks: {7}/{8}\r\nCurrent/Total bars: {9}/{10}\r\nAverage notes per sec" +
    "ond: {11}";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 89);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legend";
            // 
            // TemplatesLabel
            // 
            this.TemplatesLabel.AutoSize = true;
            this.TemplatesLabel.Location = new System.Drawing.Point(7, 282);
            this.TemplatesLabel.Name = "TemplatesLabel";
            this.TemplatesLabel.Size = new System.Drawing.Size(59, 13);
            this.TemplatesLabel.TabIndex = 8;
            this.TemplatesLabel.Text = "Templates:";
            // 
            // TemplatesBox
            // 
            this.TemplatesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TemplatesBox.FormattingEnabled = true;
            this.TemplatesBox.Items.AddRange(new object[] {
            "Custom",
            "MIDITrail Standard",
            "MIDITrail Vertical",
            "Essential"});
            this.TemplatesBox.Location = new System.Drawing.Point(67, 279);
            this.TemplatesBox.Name = "TemplatesBox";
            this.TemplatesBox.Size = new System.Drawing.Size(134, 21);
            this.TemplatesBox.TabIndex = 9;
            this.TemplatesBox.SelectedIndexChanged += new System.EventHandler(this.TemplatesBox_SelectedIndexChanged);
            // 
            // CounterTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 309);
            this.ControlBox = false;
            this.Controls.Add(this.TemplatesBox);
            this.Controls.Add(this.TemplatesLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TemplateEditor);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.RichTextBox TemplateEditor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TemplatesLabel;
        private System.Windows.Forms.ComboBox TemplatesBox;
    }
}