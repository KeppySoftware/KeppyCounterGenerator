namespace KeppyNotesCounter
{
    partial class MainWin
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.BackgroundColor = new System.Windows.Forms.ColorDialog();
            this.FontColor = new System.Windows.Forms.ColorDialog();
            this.FontTypeface = new System.Windows.Forms.FontDialog();
            this.CurrentStatus = new System.Windows.Forms.Label();
            this.DoNotUse = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LivePreview = new System.Windows.Forms.Timer(this.components);
            this.PreviewBox = new System.Windows.Forms.PictureBox();
            this.MenuBar = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.SelectMIDIDialog = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.StartConvThread = new System.Windows.Forms.MenuItem();
            this.StopConvThread = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.ChangeFontTypeface = new System.Windows.Forms.MenuItem();
            this.ChangeBackgroundColor = new System.Windows.Forms.MenuItem();
            this.OpenMIDI = new System.Windows.Forms.OpenFileDialog();
            this.FrameConverter = new System.ComponentModel.BackgroundWorker();
            this.CheckPos = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 2;
            this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem29});
            this.menuItem12.Text = "?";
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 0;
            this.menuItem29.Text = "About the software";
            this.menuItem29.Click += new System.EventHandler(this.menuItem29_Click);
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentStatus.Location = new System.Drawing.Point(46, 443);
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.Size = new System.Drawing.Size(171, 13);
            this.CurrentStatus.TabIndex = 6;
            this.CurrentStatus.Text = "Idle";
            // 
            // DoNotUse
            // 
            this.DoNotUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DoNotUse.AutoSize = true;
            this.DoNotUse.Location = new System.Drawing.Point(9, 443);
            this.DoNotUse.Name = "DoNotUse";
            this.DoNotUse.Size = new System.Drawing.Size(40, 13);
            this.DoNotUse.TabIndex = 5;
            this.DoNotUse.Text = "Status:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(225, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "No MIDI loaded";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LivePreview
            // 
            this.LivePreview.Enabled = true;
            this.LivePreview.Interval = 500;
            this.LivePreview.Tick += new System.EventHandler(this.LivePreview_Tick);
            // 
            // PreviewBox
            // 
            this.PreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewBox.BackColor = System.Drawing.Color.Black;
            this.PreviewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PreviewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PreviewBox.Location = new System.Drawing.Point(12, 12);
            this.PreviewBox.Name = "PreviewBox";
            this.PreviewBox.Size = new System.Drawing.Size(426, 426);
            this.PreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewBox.TabIndex = 4;
            this.PreviewBox.TabStop = false;
            // 
            // MenuBar
            // 
            this.MenuBar.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem6,
            this.menuItem12});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SelectMIDIDialog,
            this.menuItem21,
            this.StartConvThread,
            this.StopConvThread,
            this.menuItem4,
            this.menuItem5});
            this.menuItem1.Text = "File";
            // 
            // SelectMIDIDialog
            // 
            this.SelectMIDIDialog.Index = 0;
            this.SelectMIDIDialog.Text = "Select MIDI";
            this.SelectMIDIDialog.Click += new System.EventHandler(this.SelectMIDIDialog_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 1;
            this.menuItem21.Text = "-";
            // 
            // StartConvThread
            // 
            this.StartConvThread.Index = 2;
            this.StartConvThread.Text = "Start conversion";
            this.StartConvThread.Click += new System.EventHandler(this.StartConvThread_Click);
            // 
            // StopConvThread
            // 
            this.StopConvThread.Index = 3;
            this.StopConvThread.Text = "Stop conversion";
            this.StopConvThread.Click += new System.EventHandler(this.StopConvThread_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 5;
            this.menuItem5.Text = "Exit";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ChangeFontTypeface,
            this.ChangeBackgroundColor});
            this.menuItem6.Text = "Settings";
            // 
            // ChangeFontTypeface
            // 
            this.ChangeFontTypeface.Index = 0;
            this.ChangeFontTypeface.Text = "Change font (Final output)";
            this.ChangeFontTypeface.Click += new System.EventHandler(this.ChangeFontTypeface_Click);
            // 
            // ChangeBackgroundColor
            // 
            this.ChangeBackgroundColor.Index = 1;
            this.ChangeBackgroundColor.Text = "Change background color (Preview)";
            this.ChangeBackgroundColor.Click += new System.EventHandler(this.ChangeBackgroundColor_Click);
            // 
            // OpenMIDI
            // 
            this.OpenMIDI.Filter = "MIDI files|*.mid;*.midi;*.rmi";
            // 
            // FrameConverter
            // 
            this.FrameConverter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FrameConverter_DoWork);
            // 
            // CheckPos
            // 
            this.CheckPos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CheckPos_DoWork);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 465);
            this.Controls.Add(this.CurrentStatus);
            this.Controls.Add(this.DoNotUse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PreviewBox);
            this.Menu = this.MenuBar;
            this.Name = "MainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keppy\'s Counter Generator";
            this.Load += new System.EventHandler(this.MainWin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem29;
        private System.Windows.Forms.ColorDialog BackgroundColor;
        private System.Windows.Forms.ColorDialog FontColor;
        private System.Windows.Forms.FontDialog FontTypeface;
        private System.Windows.Forms.Label CurrentStatus;
        private System.Windows.Forms.Label DoNotUse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer LivePreview;
        private System.Windows.Forms.PictureBox PreviewBox;
        private System.Windows.Forms.MainMenu MenuBar;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem SelectMIDIDialog;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.MenuItem StartConvThread;
        private System.Windows.Forms.MenuItem StopConvThread;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem ChangeFontTypeface;
        private System.Windows.Forms.MenuItem ChangeBackgroundColor;
        private System.Windows.Forms.OpenFileDialog OpenMIDI;
        private System.ComponentModel.BackgroundWorker FrameConverter;
        private System.ComponentModel.BackgroundWorker CheckPos;
    }
}

