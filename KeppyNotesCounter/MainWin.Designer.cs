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
            this.CurrentMIDILoaded = new System.Windows.Forms.Label();
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
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.NativeMode = new System.Windows.Forms.MenuItem();
            this.X2Mode = new System.Windows.Forms.MenuItem();
            this.X4Mode = new System.Windows.Forms.MenuItem();
            this.X8Mode = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.ChangeFontTypeface = new System.Windows.Forms.MenuItem();
            this.ChangeBackgroundColor = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.CCT = new System.Windows.Forms.MenuItem();
            this.OpenMIDI = new System.Windows.Forms.OpenFileDialog();
            this.FrameConverter = new System.ComponentModel.BackgroundWorker();
            this.CheckPos = new System.ComponentModel.BackgroundWorker();
            this.NoTrimMillisecs = new System.Windows.Forms.MenuItem();
            this.MIDIName = new System.Windows.Forms.ToolTip(this.components);
            this.GarbageCollector = new System.ComponentModel.BackgroundWorker();
            this.XHalfMode = new System.Windows.Forms.MenuItem();
            this.XHalfHalfMode = new System.Windows.Forms.MenuItem();
            this.XHalfHalfHalfMode = new System.Windows.Forms.MenuItem();
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
            // CurrentMIDILoaded
            // 
            this.CurrentMIDILoaded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentMIDILoaded.Location = new System.Drawing.Point(225, 443);
            this.CurrentMIDILoaded.Name = "CurrentMIDILoaded";
            this.CurrentMIDILoaded.Size = new System.Drawing.Size(215, 13);
            this.CurrentMIDILoaded.TabIndex = 7;
            this.CurrentMIDILoaded.Text = "No MIDI loaded";
            this.CurrentMIDILoaded.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.PreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.menuItem3,
            this.NoTrimMillisecs,
            this.menuItem7,
            this.ChangeFontTypeface,
            this.ChangeBackgroundColor,
            this.menuItem2,
            this.CCT});
            this.menuItem6.Text = "Settings";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.XHalfHalfHalfMode,
            this.XHalfHalfMode,
            this.XHalfMode,
            this.NativeMode,
            this.X2Mode,
            this.X4Mode,
            this.X8Mode,
            this.menuItem13,
            this.menuItem14});
            this.menuItem3.Text = "Resolution";
            // 
            // NativeMode
            // 
            this.NativeMode.Index = 3;
            this.NativeMode.Text = "1x (Native)";
            this.NativeMode.Click += new System.EventHandler(this.NativeMode_Click);
            // 
            // X2Mode
            // 
            this.X2Mode.Index = 4;
            this.X2Mode.Text = "2x";
            this.X2Mode.Click += new System.EventHandler(this.X2Mode_Click);
            // 
            // X4Mode
            // 
            this.X4Mode.Index = 5;
            this.X4Mode.Text = "4x";
            this.X4Mode.Click += new System.EventHandler(this.X4Mode_Click);
            // 
            // X8Mode
            // 
            this.X8Mode.Index = 6;
            this.X8Mode.Text = "8x";
            this.X8Mode.Click += new System.EventHandler(this.X8Mode_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 7;
            this.menuItem13.Text = "-";
            // 
            // menuItem14
            // 
            this.menuItem14.Enabled = false;
            this.menuItem14.Index = 8;
            this.menuItem14.Text = "Native is 1024x1024";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "-";
            // 
            // ChangeFontTypeface
            // 
            this.ChangeFontTypeface.Index = 3;
            this.ChangeFontTypeface.Text = "Change font (Final output)";
            this.ChangeFontTypeface.Click += new System.EventHandler(this.ChangeFontTypeface_Click);
            // 
            // ChangeBackgroundColor
            // 
            this.ChangeBackgroundColor.Index = 4;
            this.ChangeBackgroundColor.Text = "Change background color (Preview)";
            this.ChangeBackgroundColor.Click += new System.EventHandler(this.ChangeBackgroundColor_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 5;
            this.menuItem2.Text = "-";
            // 
            // CCT
            // 
            this.CCT.Index = 6;
            this.CCT.Text = "Change counter template";
            this.CCT.Click += new System.EventHandler(this.CCT_Click);
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
            // NoTrimMillisecs
            // 
            this.NoTrimMillisecs.Index = 1;
            this.NoTrimMillisecs.Text = "Do not trim milliseconds";
            this.NoTrimMillisecs.Click += new System.EventHandler(this.NoTrimMillisecs_Click);
            // 
            // GarbageCollector
            // 
            this.GarbageCollector.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GarbageCollector_DoWork);
            // 
            // XHalfMode
            // 
            this.XHalfMode.Index = 2;
            this.XHalfMode.Text = "0.5x";
            this.XHalfMode.Click += new System.EventHandler(this.XHalfMode_Click);
            // 
            // XHalfHalfMode
            // 
            this.XHalfHalfMode.Index = 1;
            this.XHalfHalfMode.Text = "0.25x";
            this.XHalfHalfMode.Click += new System.EventHandler(this.XHalfHalfMode_Click);
            // 
            // XHalfHalfHalfMode
            // 
            this.XHalfHalfHalfMode.Index = 0;
            this.XHalfHalfHalfMode.Text = "0.125x";
            this.XHalfHalfHalfMode.Click += new System.EventHandler(this.XHalfHalfHalfMode_Click);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 465);
            this.Controls.Add(this.CurrentStatus);
            this.Controls.Add(this.DoNotUse);
            this.Controls.Add(this.CurrentMIDILoaded);
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
        private System.Windows.Forms.Label CurrentMIDILoaded;
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
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem CCT;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem NativeMode;
        private System.Windows.Forms.MenuItem X2Mode;
        private System.Windows.Forms.MenuItem X4Mode;
        private System.Windows.Forms.MenuItem X8Mode;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem NoTrimMillisecs;
        private System.Windows.Forms.ToolTip MIDIName;
        private System.ComponentModel.BackgroundWorker GarbageCollector;
        private System.Windows.Forms.MenuItem XHalfHalfHalfMode;
        private System.Windows.Forms.MenuItem XHalfHalfMode;
        private System.Windows.Forms.MenuItem XHalfMode;
    }
}

