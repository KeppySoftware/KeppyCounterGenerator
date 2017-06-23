using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Midi;

namespace KeppyNotesCounter
{
    public partial class MainWin : Form
    {
        public class FFMPEGProcess
        {
            public static Process FFMPEG;
            public static Double Hertz = 1.0 / 60.0;
            public static Bitmap Preview;
        }

        public class Data
        {
            public static String PercentageProgress = "0%";
            public static String MIDIToLoad;
            public static SYNCPROC NoteSync;
            public static Int32 StreamHandle;
            public static Int64 TotalNotes;
            public static Int64 PlayedNotes;
        }

        public class Settings
        {
            public static Font FontConversion = new Font("Tahoma", 12);
            public static Boolean Interrupt = false;
        }

        public MainWin()
        {
            InitializeComponent();
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            CheckPos.RunWorkerAsync();
        }

        private void NoteSyncProc(int handle, int channel, int data, IntPtr user)
        {
            if ((data & 0xff00) != 0) Data.PlayedNotes++;
        }

        private void StartConversion(string str)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.RedirectStandardInput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.FileName = "kffmpeg.exe";
                psi.WorkingDirectory = Directory.GetCurrentDirectory();
                psi.Arguments = String.Format("-y -vsync 2 -r {0} -i - -vcodec qtrle \"{1}.mov\"", 60, Path.GetFileNameWithoutExtension(str).Replace(" ", "_"));
                FFMPEGProcess.FFMPEG = Process.Start(psi);
            }
            catch (Exception err)
            {
                Settings.Interrupt = true;
                MessageBox.Show(err.ToString());
            }
        }

        private void PushFrame(string text)
        {
            Bitmap bmp = new Bitmap(1000, 1000);
            Bitmap bmpgen = new Bitmap(1000, 1000);

            RectangleF rectf = new RectangleF(0, 0, bmp.Width, bmp.Height);

            Brush brush = new SolidBrush(Color.Transparent);
            Brush brush2 = new SolidBrush(Color.White);

            Graphics g = Graphics.FromImage(bmp);

            g.FillRectangle(brush, rectf);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            StringFormat format = new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Far,
            };

            g.DrawString(text, Settings.FontConversion, brush2, rectf, format);

            // Flush all graphics changes to the bitmap
            g.Flush();

            FFMPEGProcess.Preview = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.PixelFormat.DontCare);

            Byte[] Bitmap = GetBytesOfImage(bmp);
            bmp.Dispose();

            FFMPEGProcess.FFMPEG.StandardInput.BaseStream.Write(Bitmap, 0, Bitmap.Length);
        }

        private void FrameConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Initialize BASS and variables
                String ReturnToFrameWriter = "";
                String HowManyZeros = "";
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 0);
                Data.StreamHandle = BassMidi.BASS_MIDI_StreamCreateFile(Data.MIDIToLoad, 0L, 0L, BASSFlag.BASS_MIDI_NOCROP | BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_MIDI_DECAYEND, 0);
                Int64 StreamLength = Bass.BASS_ChannelGetLength(Data.StreamHandle);
                Int32 ChunkLength = Convert.ToInt32(Bass.BASS_ChannelSeconds2Bytes(Data.StreamHandle, FFMPEGProcess.Hertz));
                Byte[] Buffer;

                // Initialize played notes sync
                Data.NoteSync = new SYNCPROC(NoteSyncProc);
                Bass.BASS_ChannelSetSync(Data.StreamHandle, BASSSync.BASS_SYNC_MIDI_EVENT, (long)BASSMIDIEvent.MIDI_EVENT_NOTE, Data.NoteSync, IntPtr.Zero);

                // Initialize note count
                Data.TotalNotes = BassMidi.BASS_MIDI_StreamGetEvents(Data.StreamHandle, -1, (BASSMIDIEvent)0x20000, null);
                HowManyZeros = String.Concat(Enumerable.Repeat("0", Data.TotalNotes.ToString().Length));

                // Initialize conversion
                StartConversion(Data.MIDIToLoad);
             
                Buffer = new Byte[ChunkLength];
                Bass.BASS_ChannelGetData(Data.StreamHandle, Buffer, ChunkLength);

                ReturnToFrameWriter = String.Format("{0}/{1}", (0).ToString(HowManyZeros), Data.TotalNotes.ToString());
                PushFrame(ReturnToFrameWriter);

                while (Bass.BASS_ChannelIsActive(Data.StreamHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    if (Settings.Interrupt == true) break;
                    Buffer = new Byte[ChunkLength];
                    Bass.BASS_ChannelGetData(Data.StreamHandle, Buffer, ChunkLength);
                    ReturnToFrameWriter = String.Format("{0}/{1}", (Data.PlayedNotes).ToString(HowManyZeros), Data.TotalNotes.ToString());
                    PushFrame(ReturnToFrameWriter);
                }

                FFMPEGProcess.FFMPEG.StandardInput.Close();

                Bass.BASS_StreamFree(Data.StreamHandle);
                Bass.BASS_Free();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CheckPos_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    Int64 MIDILengthRAW = Bass.BASS_ChannelGetLength(Data.StreamHandle);
                    Int64 MIDICurrentPosRAW = Bass.BASS_ChannelGetPosition(Data.StreamHandle);
                    Single RAWTotal = ((float)MIDILengthRAW) / 1048576f;
                    Single RAWConverted = ((float)MIDICurrentPosRAW) / 1048576f;

                    float percentage = RAWConverted / RAWTotal;
                    float percentagefinal;
                    if (percentage * 100 < 0)
                        percentagefinal = 0.0f;
                    else if (percentage * 100 > 100)
                        percentagefinal = 1.0f;
                    else
                        percentagefinal = percentage;
                    Data.PercentageProgress = percentagefinal.ToString("0.0%");

                    System.Threading.Thread.Sleep(10);
                }
                catch { }
            }
        }

        private void SelectMIDIDialog_Click(object sender, EventArgs e)
        {
            Init:
            if (this.OpenMIDI.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.Path.GetExtension(OpenMIDI.FileName).ToLower() != ".mid")
                {
                    MessageBox.Show("Select a MIDI!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto Init;
                }
                else
                {
                    Data.MIDIToLoad = OpenMIDI.FileName;
                    label1.Text = Data.MIDIToLoad;
                }
            }
        }

        private void StartConvThread_Click(object sender, EventArgs e)
        {
            Settings.Interrupt = false;
            FrameConverter.RunWorkerAsync();
        }

        private void StopConvThread_Click(object sender, EventArgs e)
        {
            Settings.Interrupt = true;
        }

        public static byte[] GetBytesOfImage(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void LivePreview_Tick(object sender, EventArgs e)
        {
            if (Bass.BASS_ChannelIsActive(Data.StreamHandle) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                SelectMIDIDialog.Enabled = false;
                StartConvThread.Enabled = false;
                ChangeFontTypeface.Enabled = false;

                CurrentStatus.Text = String.Format("{0} of the MIDI done", Data.PercentageProgress);

                if (PreviewBox.Image != null) PreviewBox.Image.Dispose();
                try
                {
                    PreviewBox.Image = FFMPEGProcess.Preview.Clone(new Rectangle(0, 0, FFMPEGProcess.Preview.Width, FFMPEGProcess.Preview.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                }
                catch { }

                System.Threading.Thread.Sleep(1);
            }
            else
            {
                SelectMIDIDialog.Enabled = true;
                StartConvThread.Enabled = true;
                ChangeFontTypeface.Enabled = true;

                CurrentStatus.Text = "Idle";
            }
        }

        private void ChangeFontTypeface_Click(object sender, EventArgs e)
        {
            Redo:
            try
            {
                if (FontTypeface.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Settings.FontConversion = FontTypeface.Font;
                    }
                    catch
                    {
                        MessageBox.Show("Error.");
                        goto Redo;
                    }
                }
            }
            catch
            {
                MessageBox.Show("You can only use TrueType fonts!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto Redo;
            }
        }

        private void ChangeBackgroundColor_Click(object sender, EventArgs e)
        {
            Redo:
            try
            {
                BackgroundColor.AllowFullOpen = true;
                if (BackgroundColor.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PreviewBox.BackColor = BackgroundColor.Color;
                    }
                    catch
                    {
                        MessageBox.Show("Error.");
                        goto Redo;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unknown error, try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto Redo;
            }
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItem29_Click(object sender, EventArgs e)
        {
            new Info().ShowDialog();
        }
    }
}
