namespace KeppyCounterGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.BackgroundColor = new System.Windows.Forms.ColorDialog();
            this.FontColor = new System.Windows.Forms.ColorDialog();
            this.FontTypeface = new System.Windows.Forms.FontDialog();
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
            this.UseAllThreads = new System.Windows.Forms.MenuItem();
            this.DebugInfo = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.ResItems = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.HideMilliseconds = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.NoTrimMillisecs = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.ChangeFontTypeface = new System.Windows.Forms.MenuItem();
            this.ChangeBackgroundColor = new System.Windows.Forms.MenuItem();
            this.ChangeBackgroundImg = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.CCT = new System.Windows.Forms.MenuItem();
            this.OpenMIDI = new System.Windows.Forms.OpenFileDialog();
            this.FrameConverter = new System.ComponentModel.BackgroundWorker();
            this.CheckPos = new System.ComponentModel.BackgroundWorker();
            this.MIDIName = new System.Windows.Forms.ToolTip(this.components);
            this.GarbageCollector = new System.ComponentModel.BackgroundWorker();
            this.SaveMovieTo = new System.Windows.Forms.SaveFileDialog();
            this.ImportBackground = new System.Windows.Forms.OpenFileDialog();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.DoNotUse = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentMIDILoaded = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).BeginInit();
            this.StatusStrip.SuspendLayout();
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
            this.PreviewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PreviewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PreviewBox.Location = new System.Drawing.Point(12, 12);
            this.PreviewBox.Name = "PreviewBox";
            this.PreviewBox.Size = new System.Drawing.Size(853, 480);
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
            this.menuItem9,
            this.ResItems,
            this.menuItem8,
            this.menuItem7,
            this.ChangeFontTypeface,
            this.ChangeBackgroundColor,
            this.ChangeBackgroundImg,
            this.menuItem2,
            this.CCT});
            this.menuItem6.Text = "Settings";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.UseAllThreads,
            this.DebugInfo});
            this.menuItem3.Text = "Advanced";
            // 
            // UseAllThreads
            // 
            this.UseAllThreads.Index = 0;
            this.UseAllThreads.Text = "Allow FFMpeg to use all cores/threads";
            this.UseAllThreads.Click += new System.EventHandler(this.UseAllThreads_Click);
            // 
            // DebugInfo
            // 
            this.DebugInfo.Index = 1;
            this.DebugInfo.Text = "Show debug info from FFMpeg";
            this.DebugInfo.Click += new System.EventHandler(this.DebugInfo_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "-";
            // 
            // ResItems
            // 
            this.ResItems.Index = 2;
            this.ResItems.Text = "Change output resolution";
            this.ResItems.Click += new System.EventHandler(this.ResItems_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.HideMilliseconds,
            this.menuItem10,
            this.NoTrimMillisecs});
            this.menuItem8.Text = "Milliseconds in timestamp";
            // 
            // HideMilliseconds
            // 
            this.HideMilliseconds.Index = 0;
            this.HideMilliseconds.Text = "Hide milliseconds";
            this.HideMilliseconds.Click += new System.EventHandler(this.HideMillseconds_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.Text = "-";
            // 
            // NoTrimMillisecs
            // 
            this.NoTrimMillisecs.Index = 2;
            this.NoTrimMillisecs.Text = "Do not trim milliseconds";
            this.NoTrimMillisecs.Click += new System.EventHandler(this.NoTrimMillisecs_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.Text = "-";
            // 
            // ChangeFontTypeface
            // 
            this.ChangeFontTypeface.Index = 5;
            this.ChangeFontTypeface.Text = "Change font (Final output)";
            this.ChangeFontTypeface.Click += new System.EventHandler(this.ChangeFontTypeface_Click);
            // 
            // ChangeBackgroundColor
            // 
            this.ChangeBackgroundColor.Index = 6;
            this.ChangeBackgroundColor.Text = "Change background color (Preview)";
            this.ChangeBackgroundColor.Click += new System.EventHandler(this.ChangeBackgroundColor_Click);
            // 
            // ChangeBackgroundImg
            // 
            this.ChangeBackgroundImg.Index = 7;
            this.ChangeBackgroundImg.Text = "Change background image (Preview)";
            this.ChangeBackgroundImg.Click += new System.EventHandler(this.ChangeBackgroundImg_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 8;
            this.menuItem2.Text = "-";
            // 
            // CCT
            // 
            this.CCT.Index = 9;
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
            // GarbageCollector
            // 
            this.GarbageCollector.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GarbageCollector_DoWork);
            // 
            // SaveMovieTo
            // 
            this.SaveMovieTo.Filter = "QuickTime movie (*.mov)|*.mov";
            // 
            // ImportBackground
            // 
            this.ImportBackground.FileName = "ImportBackground";
            this.ImportBackground.Filter = "Image files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            // 
            // StatusStrip
            // 
            this.StatusStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoNotUse,
            this.CurrentStatus,
            this.CurrentMIDILoaded});
            this.StatusStrip.Location = new System.Drawing.Point(0, 503);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.ShowItemToolTips = true;
            this.StatusStrip.Size = new System.Drawing.Size(877, 22);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 8;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // DoNotUse
            // 
            this.DoNotUse.Name = "DoNotUse";
            this.DoNotUse.Size = new System.Drawing.Size(42, 17);
            this.DoNotUse.Text = "Status:";
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.Size = new System.Drawing.Size(727, 17);
            this.CurrentStatus.Spring = true;
            this.CurrentStatus.Text = "Idle";
            this.CurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentMIDILoaded
            // 
            this.CurrentMIDILoaded.Name = "CurrentMIDILoaded";
            this.CurrentMIDILoaded.Size = new System.Drawing.Size(93, 17);
            this.CurrentMIDILoaded.Text = "No MIDI loaded.";
            this.CurrentMIDILoaded.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(877, 525);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.PreviewBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.MenuBar;
            this.Name = "MainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keppy\'s Counter Generator";
            this.Load += new System.EventHandler(this.MainWin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBox)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem29;
        private System.Windows.Forms.ColorDialog BackgroundColor;
        private System.Windows.Forms.ColorDialog FontColor;
        private System.Windows.Forms.FontDialog FontTypeface;
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
        private System.Windows.Forms.MenuItem ResItems;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem NoTrimMillisecs;
        private System.Windows.Forms.ToolTip MIDIName;
        private System.ComponentModel.BackgroundWorker GarbageCollector;
        private System.Windows.Forms.MenuItem UseAllThreads;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem HideMilliseconds;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.SaveFileDialog SaveMovieTo;
        private System.Windows.Forms.MenuItem ChangeBackgroundImg;
        private System.Windows.Forms.OpenFileDialog ImportBackground;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel DoNotUse;
        private System.Windows.Forms.ToolStripStatusLabel CurrentStatus;
        private System.Windows.Forms.ToolStripStatusLabel CurrentMIDILoaded;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem DebugInfo;
        private System.Windows.Forms.MenuItem menuItem9;
    }
}

