namespace KeppyCounterGenerator
{
    partial class OutputRes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HeightVal = new System.Windows.Forms.NumericUpDown();
            this.WidthVal = new System.Windows.Forms.NumericUpDown();
            this.HeightLab = new System.Windows.Forms.Label();
            this.WidthLab = new System.Windows.Forms.Label();
            this.ARPanel = new System.Windows.Forms.Panel();
            this.ARCurrent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CommonRes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UseCodec = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthVal)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HeightVal);
            this.groupBox1.Controls.Add(this.WidthVal);
            this.groupBox1.Controls.Add(this.HeightLab);
            this.groupBox1.Controls.Add(this.WidthLab);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resolution settings";
            // 
            // HeightVal
            // 
            this.HeightVal.Location = new System.Drawing.Point(207, 40);
            this.HeightVal.Maximum = new decimal(new int[] {
            8640,
            0,
            0,
            0});
            this.HeightVal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightVal.Name = "HeightVal";
            this.HeightVal.Size = new System.Drawing.Size(50, 20);
            this.HeightVal.TabIndex = 3;
            this.HeightVal.Value = new decimal(new int[] {
            8640,
            0,
            0,
            0});
            this.HeightVal.ValueChanged += new System.EventHandler(this.HeightVal_ValueChanged);
            // 
            // WidthVal
            // 
            this.WidthVal.Location = new System.Drawing.Point(106, 40);
            this.WidthVal.Maximum = new decimal(new int[] {
            15360,
            0,
            0,
            0});
            this.WidthVal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthVal.Name = "WidthVal";
            this.WidthVal.Size = new System.Drawing.Size(50, 20);
            this.WidthVal.TabIndex = 2;
            this.WidthVal.Value = new decimal(new int[] {
            15360,
            0,
            0,
            0});
            this.WidthVal.ValueChanged += new System.EventHandler(this.WidthVal_ValueChanged);
            // 
            // HeightLab
            // 
            this.HeightLab.AutoSize = true;
            this.HeightLab.Location = new System.Drawing.Point(168, 42);
            this.HeightLab.Name = "HeightLab";
            this.HeightLab.Size = new System.Drawing.Size(41, 13);
            this.HeightLab.TabIndex = 1;
            this.HeightLab.Text = "Height:";
            // 
            // WidthLab
            // 
            this.WidthLab.AutoSize = true;
            this.WidthLab.Location = new System.Drawing.Point(70, 42);
            this.WidthLab.Name = "WidthLab";
            this.WidthLab.Size = new System.Drawing.Size(38, 13);
            this.WidthLab.TabIndex = 0;
            this.WidthLab.Text = "Width:";
            // 
            // ARPanel
            // 
            this.ARPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ARPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ARPanel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ARPanel.Location = new System.Drawing.Point(188, 16);
            this.ARPanel.Name = "ARPanel";
            this.ARPanel.Size = new System.Drawing.Size(128, 128);
            this.ARPanel.TabIndex = 4;
            // 
            // ARCurrent
            // 
            this.ARCurrent.BackColor = System.Drawing.Color.Transparent;
            this.ARCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARCurrent.ForeColor = System.Drawing.Color.Black;
            this.ARCurrent.Location = new System.Drawing.Point(6, 38);
            this.ARCurrent.Name = "ARCurrent";
            this.ARCurrent.Size = new System.Drawing.Size(176, 43);
            this.ARCurrent.TabIndex = 0;
            this.ARCurrent.Text = "None";
            this.ARCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Change the resolution of the final output here:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.Location = new System.Drawing.Point(263, 304);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 2;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.Location = new System.Drawing.Point(187, 304);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CommonRes);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ARCurrent);
            this.groupBox2.Controls.Add(this.ARPanel);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 153);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aspect ratio preview / Common resolutions";
            // 
            // CommonRes
            // 
            this.CommonRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CommonRes.FormattingEnabled = true;
            this.CommonRes.Items.AddRange(new object[] {
            "Select one...",
            "256x144",
            "640x360",
            "854x480",
            "1280x720",
            "1920x1080",
            "2560x1440",
            "3840x2160",
            "5120x2880",
            "7680x4320",
            "15360x8640"});
            this.CommonRes.Location = new System.Drawing.Point(55, 101);
            this.CommonRes.Name = "CommonRes";
            this.CommonRes.Size = new System.Drawing.Size(121, 21);
            this.CommonRes.TabIndex = 6;
            this.CommonRes.SelectedIndexChanged += new System.EventHandler(this.CommonRes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Presets:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output codec:";
            // 
            // UseCodec
            // 
            this.UseCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UseCodec.FormattingEnabled = true;
            this.UseCodec.Items.AddRange(new object[] {
            "PNG video",
            "QT Animation"});
            this.UseCodec.Location = new System.Drawing.Point(85, 305);
            this.UseCodec.Name = "UseCodec";
            this.UseCodec.Size = new System.Drawing.Size(95, 21);
            this.UseCodec.TabIndex = 6;
            this.UseCodec.SelectedIndexChanged += new System.EventHandler(this.UseCodec_SelectedIndexChanged);
            // 
            // OutputRes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(348, 339);
            this.Controls.Add(this.UseCodec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutputRes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change output resolution";
            this.Load += new System.EventHandler(this.OutputRes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthVal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown HeightVal;
        private System.Windows.Forms.NumericUpDown WidthVal;
        private System.Windows.Forms.Label HeightLab;
        private System.Windows.Forms.Label WidthLab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ARPanel;
        private System.Windows.Forms.Label ARCurrent;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CommonRes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox UseCodec;
    }
}