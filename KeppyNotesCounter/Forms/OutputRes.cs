using System;
using System.Drawing;
using System.Windows.Forms;

namespace KeppyCounterGenerator
{
    public partial class OutputRes : Form
    {
        Int32[] PresetWidth = new Int32[10] { 256, 640, 854, 1280, 1920, 2560, 3840, 5120, 7680, 15360 };
        Int32[] PresetHeight = new Int32[10] { 144, 360, 480, 720, 1080, 1440, 2160, 2880, 4320, 8640 };

        public OutputRes()
        {
            InitializeComponent();
        }

        private void OutputRes_Load(object sender, EventArgs e)
        {
            WidthVal.Value = Properties.Settings.Default.WRes;
            HeightVal.Value = Properties.Settings.Default.HRes;
            FPSVal.Value = Properties.Settings.Default.FPSExport;
            CommonRes.SelectedIndex = 0;
            UseCodec.SelectedIndex = Properties.Settings.Default.CodecSelection;
            CalculateAspectRatio();
        }

        private void WidthVal_ValueChanged(object sender, EventArgs e)
        {
            CalculateAspectRatio();
        }

        private void HeightVal_ValueChanged(object sender, EventArgs e)
        {
            CalculateAspectRatio();
        }

        static decimal GCD(decimal a, decimal b)
        {
            decimal Remainder;
            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }
            return a;
        }

        private void CalculateAspectRatio()
        {
            try
            {
                Bitmap bmp;
                double dbl = (double)WidthVal.Value / (double)HeightVal.Value;

                if ((int)((double)ARPanel.Width * dbl) <= ARPanel.Height)
                {
                    bmp = new Bitmap((int)((double)ARPanel.Width * dbl), ARPanel.Height);
                }
                else
                {
                    bmp = new Bitmap(ARPanel.Width, (int)((double)ARPanel.Height / dbl));
                }

                RectangleF rectf = new Rectangle(0, 0, bmp.Width, bmp.Height);

                Brush background = new SolidBrush(Color.Black);

                Graphics g = Graphics.FromImage(bmp);
                g.FillRectangle(background, rectf);

                ARPanel.BackgroundImage = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                ARCurrent.Text = String.Format("{0}:{1}", WidthVal.Value / GCD(WidthVal.Value, HeightVal.Value), HeightVal.Value / GCD(WidthVal.Value, HeightVal.Value));

                background.Dispose();
                g.Flush();
            }
            catch { }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.WRes = WidthVal.Value;
            Properties.Settings.Default.HRes = HeightVal.Value;
            Properties.Settings.Default.FPSExport = (Int32)FPSVal.Value;
            Properties.Settings.Default.CodecSelection = UseCodec.SelectedIndex;
            Properties.Settings.Default.Save();
            MainWin.FFMPEGProcess.Hertz = 1.0 / (Double)Properties.Settings.Default.FPSExport;

            Close();
        }

        private void CommonRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CommonRes.SelectedIndex != 0)
            {
                WidthVal.Value = PresetWidth[CommonRes.SelectedIndex - 1];
                HeightVal.Value = PresetHeight[CommonRes.SelectedIndex - 1];
            }
        }

        private void UseCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UseCodec.SelectedIndex == 1 && !Program.CheckQuickTime())
            {
                UseCodec.SelectedIndex = 0;
                MessageBox.Show("QuickTime is not installed.\nDefault output codec is now PNG video.\n\nPress OK to continue.", "Keppy's Notes Counter - Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RtD_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset the settings?", "Keppy's Notes Counter - Question", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                WidthVal.Value = 1920;
                HeightVal.Value = 1080;
                FPSVal.Value = 60;
                CommonRes.SelectedIndex = 0;
                UseCodec.SelectedIndex = 0;
                CalculateAspectRatio();

                Properties.Settings.Default.WRes = WidthVal.Value;
                Properties.Settings.Default.HRes = HeightVal.Value;
                Properties.Settings.Default.FPSExport = (Int32)FPSVal.Value;
                Properties.Settings.Default.CodecSelection = UseCodec.SelectedIndex;
                Properties.Settings.Default.Save();
                MainWin.FFMPEGProcess.Hertz = 1.0 / (Double)Properties.Settings.Default.FPSExport;
            }
        }
    }
}
