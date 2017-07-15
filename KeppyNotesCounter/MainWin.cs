﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            public static UInt32 Frames = 0;
            public static UInt32 FramesAvg = 0;
        }

        public class Data
        {
            public static BASS_MIDI_MARK Mark = new BASS_MIDI_MARK();
            public static String PercentageProgress = "0%";
            public static String MIDIToLoad;
            public static String TextTemplate = "";
            public static String AverageNotesPerSecond = "0";
            public static SYNCPROC NoteSync;
            public static SYNCPROC TimeSigSync;
            public static Int32 StreamHandle;
            public static Single PPQN = 0.0f; 
            public static TimeSpan CurrentTime = TimeSpan.Zero;
            public static TimeSpan TotalTime = TimeSpan.Zero;
            public static String HowManyZeroesNotes = "";
            public static String HowManyZeroesBars = "";
            public static Int32 Tempo = 0;
            public static Int64 TotalBars = 0;
            public static Int64 Bar = 0;
            public static Int64 TotalNotes = 0;
            public static Int64 TotalTicks = 0;
            public static Int64 Tick = 0;
            public static Int64 PlayedNotes = 0;
            public static Int64 PlayedNotesAvg = 0;
        }

        public class Settings
        {
            public static Boolean Interrupt = false;
        }

        public MainWin()
        {
            InitializeComponent();
        }

        private string ReturnText()
        {
            try
            {
                String Beat = Regex.Match(Data.Mark.text, "^[^ ]+").Value;

                return String.Format(Data.TextTemplate,
                    ReturnOutputText(Data.CurrentTime),
                    ReturnOutputText(Data.TotalTime),
                    Data.Tempo.ToString("000"),
                    Data.PlayedNotes.ToString(Data.HowManyZeroesNotes),
                    Data.TotalNotes,
                    String.IsNullOrEmpty(Beat) ? "0/0" : Beat,
                    Data.PPQN,
                    Data.Tick,
                    Data.TotalTicks,
                    ((Data.Bar / 2) + 1).ToString(Data.HowManyZeroesBars),
                    ((Data.TotalBars / 2) + 1).ToString(Data.HowManyZeroesBars),
                    Data.AverageNotesPerSecond
                    );
            }
            catch { return "Unknown template. Please check it for errors."; }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            CheckPos.RunWorkerAsync();
            GarbageCollector.RunWorkerAsync();
            if (Properties.Settings.Default.ResMulti == 8.0f) XHalfHalfHalfMode.Checked = true;
            else if (Properties.Settings.Default.ResMulti == 4.0f) XHalfHalfMode.Checked = true;
            else if (Properties.Settings.Default.ResMulti == 2.0f) XHalfMode.Checked = true;
            else if (Properties.Settings.Default.ResMulti == 1.5f) XLessQuarterMode.Checked = true;
            else if (Properties.Settings.Default.ResMulti == 1.0f) NativeMode.Checked = true;
            else if (Properties.Settings.Default.ResMulti == 0.75f) XQuarterMode.Checked = true;
            else if (Properties.Settings.Default.ResMulti == 0.5f) X2Mode.Checked = true;
            else if (Properties.Settings.Default.ResMulti == 0.25f) X4Mode.Checked = true;
            else if (Properties.Settings.Default.ResMulti == 0.125f) X8Mode.Checked = true;
            else
            {
                Properties.Settings.Default.ResMulti = 1.0f;
                Properties.Settings.Default.Save();
                NativeMode.Checked = true;
            }
            NoTrimMillisecs.Checked = Properties.Settings.Default.NoTrimMilliseconds;
            if (Properties.Settings.Default.TemplatesCounterIndex == 0) Data.TextTemplate = Properties.Settings.Default.CustomCounterTemplate;
            else Data.TextTemplate = Properties.Settings.Default.TemplatesCounter[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
            PushFrame(ReturnText(), true);
        }

        private void NoteSyncProc(int handle, int channel, int data, IntPtr user)
        {
            if ((data & 0xff00) != 0)
            {
                Data.PlayedNotes++;
                Data.PlayedNotesAvg++;
            }
        }

        private void TimeSigSyncProc(int handle, int channel, int data, IntPtr user)
        {
            BassMidi.BASS_MIDI_StreamGetMark(Data.StreamHandle, BASSMIDIMarker.BASS_MIDI_MARK_TIMESIG, data, Data.Mark);
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
                psi.FileName = "ffmpeg.exe";
                psi.WorkingDirectory = Directory.GetCurrentDirectory();
                psi.Arguments = String.Format("-y -vsync 2 {0} -r {1} -i - -vcodec qtrle \"{2}.mov\"",
                    Properties.Settings.Default.UseAllThreads ? String.Format("-threads {0}", Environment.ProcessorCount) : "", // Use all threads or not?
                    60, // Framerate
                    Path.GetFileNameWithoutExtension(str).Replace(" ", "_")); // File output
                FFMPEGProcess.FFMPEG = Process.Start(psi);
            }
            catch (Exception err)
            {
                Settings.Interrupt = true;
                MessageBox.Show(err.ToString());
            }
        }

        public void PushFrame(string text, bool isexample)
        {
            Bitmap bmp = new Bitmap(
                (Int32)(Properties.Settings.Default.WRes / Properties.Settings.Default.ResMulti),
                (Int32)(Properties.Settings.Default.HRes / Properties.Settings.Default.ResMulti)
                );

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

            g.DrawString(text, Properties.Settings.Default.CounterFont, brush2, rectf, format);

            // Flush all graphics changes to the bitmap
            g.Flush();

            if (isexample == true)
            {
                PreviewBox.Image = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.PixelFormat.DontCare);
            }
            else
            {
                FFMPEGProcess.Preview = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                Byte[] Bitmap = GetBytesOfImage(bmp);
                FFMPEGProcess.FFMPEG.StandardInput.BaseStream.Write(Bitmap, 0, Bitmap.Length);
            }

            bmp.Dispose();
            brush.Dispose();
            brush2.Dispose();
            g.Dispose();
        }

        private void FrameConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Initialize BASS and variables
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 0);
                Data.StreamHandle = BassMidi.BASS_MIDI_StreamCreateFile(Data.MIDIToLoad, 0L, 0L, BASSFlag.BASS_MIDI_NOCROP | BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_MIDI_DECAYEND, 0);

                // Check if the MIDI file is valid
                BASSError Error = Bass.BASS_ErrorGetCode();
                if (Error == BASSError.BASS_ERROR_ILLPARAM || 
                    Error == BASSError.BASS_ERROR_FILEOPEN || 
                    Error == BASSError.BASS_ERROR_FILEFORM)
                {
                    MessageBox.Show("Invalid MIDI file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Settings.Interrupt = true;
                    return;
                }

                Int64 StreamLength = Bass.BASS_ChannelGetLength(Data.StreamHandle);
                Int32 ChunkLength = Convert.ToInt32(Bass.BASS_ChannelSeconds2Bytes(Data.StreamHandle, FFMPEGProcess.Hertz));
                Byte[] Buffer;

                // Initialize played notes sync
                Data.NoteSync = new SYNCPROC(NoteSyncProc);
                Bass.BASS_ChannelSetSync(Data.StreamHandle, BASSSync.BASS_SYNC_MIDI_EVENT, (long)BASSMIDIEvent.MIDI_EVENT_NOTE, Data.NoteSync, IntPtr.Zero);

                // Initialize time signature sync
                BassMidi.BASS_MIDI_StreamGetMark(Data.StreamHandle, BASSMIDIMarker.BASS_MIDI_MARK_TIMESIG, 0, Data.Mark);
                Data.TimeSigSync = new SYNCPROC(TimeSigSyncProc);
                Bass.BASS_ChannelSetSync(Data.StreamHandle, BASSSync.BASS_SYNC_MIDI_TIMESIG, (long)BASSMIDIMarker.BASS_MIDI_MARK_TIMESIG, Data.TimeSigSync, IntPtr.Zero);

                // Initialize note count
                Data.TotalNotes = BassMidi.BASS_MIDI_StreamGetEvents(Data.StreamHandle, -1, (BASSMIDIEvent)0x20000, null);
                Data.HowManyZeroesNotes = String.Concat(Enumerable.Repeat("0", Data.TotalNotes.ToString().Length));

                // Initialize conversion
                StartConversion(Data.MIDIToLoad);

                for (int a = 0; a <= 300; a++)
                {
                    // 5 seconds of nothing
                    if (Settings.Interrupt == true) break;
                    Data.AverageNotesPerSecond = "0";
                    PushFrame(ReturnText(), false);
                    FFMPEGProcess.Frames++;
                }

                while (Bass.BASS_ChannelIsActive(Data.StreamHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    if (Settings.Interrupt == true) break;
                    Buffer = new Byte[ChunkLength];
                    Bass.BASS_ChannelGetData(Data.StreamHandle, Buffer, ChunkLength);
                    if (FFMPEGProcess.Frames % 60 == 0)
                    {
                        Data.AverageNotesPerSecond = Data.PlayedNotesAvg.ToString();
                        Data.PlayedNotesAvg = 0;
                    }
                    PushFrame(ReturnText(), false);
                    FFMPEGProcess.Frames++;
                }

                Buffer = new Byte[ChunkLength];
                Bass.BASS_ChannelGetData(Data.StreamHandle, Buffer, ChunkLength);

                for (int a = 0; a <= 300; a++)
                {
                    // 5 seconds of nothing
                    if (Settings.Interrupt == true) break;
                    Data.AverageNotesPerSecond = "0";
                    PushFrame(ReturnText(), false);
                    FFMPEGProcess.Frames++;
                }

                Data.PlayedNotes = 0;
                Data.Mark = new BASS_MIDI_MARK();
                FFMPEGProcess.Frames = 0;
                FFMPEGProcess.FFMPEG.StandardInput.Close();

                Bass.BASS_StreamFree(Data.StreamHandle);
                Bass.BASS_Free();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static String ReturnOutputText(TimeSpan TimeToCheck)
        {
            String F = "f";
            if (Properties.Settings.Default.NoTrimMilliseconds == true) { F = "fff"; }
            if (Data.TotalTime.Hours >= 10) return TimeToCheck.ToString(String.Format(@"hh\:mm\:ss\.{0}", F));
            else
            {
                if (Data.TotalTime.Hours >= 1) return TimeToCheck.ToString(String.Format(@"h\:mm\:ss\.{0}", F));
                else
                {
                    if (Data.TotalTime.Minutes >= 10) return TimeToCheck.ToString(String.Format(@"mm\:ss\.{0}", F));
                    else return TimeToCheck.ToString(String.Format(@"m\:ss\.{0}", F));
                }
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
                    Double LenRAWToDouble = Bass.BASS_ChannelBytes2Seconds(Data.StreamHandle, MIDILengthRAW);
                    Double CurRAWToDouble = Bass.BASS_ChannelBytes2Seconds(Data.StreamHandle, MIDICurrentPosRAW);
                    Data.TotalTime = TimeSpan.FromSeconds(LenRAWToDouble);
                    Data.CurrentTime = TimeSpan.FromSeconds(CurRAWToDouble);
                    Bass.BASS_ChannelGetAttribute(Data.StreamHandle, BASSAttribute.BASS_ATTRIB_MIDI_PPQN, ref Data.PPQN);
                    Data.TotalTicks = Bass.BASS_ChannelGetLength(Data.StreamHandle, BASSMode.BASS_POS_MIDI_TICK);
                    Data.Tick = Bass.BASS_ChannelGetPosition(Data.StreamHandle, BASSMode.BASS_POS_MIDI_TICK);
                    Int32 Tempo = 60000000 / BassMidi.BASS_MIDI_StreamGetEvent(Data.StreamHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO);
                    Data.Tempo = Tempo.LimitIntegerToRange(0, 999);

                    try
                    {
                        Data.Bar = ((Int64)(Data.Tick / (Data.PPQN / (8 / 4) * 4))).LimitLongToRange(0, 9223372036854775807);
                        Data.TotalBars = ((Int64)(Data.TotalTicks / (Data.PPQN / (8 / 4) * 4))).LimitLongToRange(0, 9223372036854775807);
                        Data.HowManyZeroesBars = String.Concat(Enumerable.Repeat("0", Data.TotalBars.ToString().Length));
                    }
                    catch
                    {
                        Data.Bar = 0;
                        Data.TotalBars = 0;
                    }

                    float percentage = RAWConverted / RAWTotal;
                    float percentagefinal;
                    if (percentage * 100 < 0)
                        percentagefinal = 0.0f;
                    else if (percentage * 100 > 100)
                        percentagefinal = 1.0f;
                    else
                        percentagefinal = percentage;
                    Data.PercentageProgress = percentagefinal.ToString("0.0%");

                    System.Threading.Thread.Sleep(1);
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
                    CurrentMIDILoaded.Text = Path.GetFileName(Data.MIDIToLoad);
                    MIDIName.SetToolTip(CurrentMIDILoaded, String.Format("Selected MIDI:\n{0}", Data.MIDIToLoad));
                }
            }
        }

        private void StartConvThread_Click(object sender, EventArgs e)
        {
            Settings.Interrupt = false;
            if (File.Exists(Data.MIDIToLoad))
            {
                FrameConverter.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Invalid MIDI file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                NoTrimMillisecs.Enabled = false;
                CCT.Enabled = false;
                menuItem3.Enabled = false;

                CurrentStatus.Text = String.Format("{0} ({1} frames done)", Data.PercentageProgress, FFMPEGProcess.Frames);

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
                NoTrimMillisecs.Enabled = true;
                CCT.Enabled = true;
                menuItem3.Enabled = true;

                CurrentStatus.Text = "Idle";
            }
        }

        private void ChangeFontTypeface_Click(object sender, EventArgs e)
        {
            Redo:
            try
            {
                FontTypeface.Font = Properties.Settings.Default.CounterFont;
                if (FontTypeface.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Properties.Settings.Default.CounterFont = FontTypeface.Font;
                        Properties.Settings.Default.Save();
                        PushFrame(ReturnText(), true);
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
                        PushFrame(ReturnText(), true);
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

        private void CCT_Click(object sender, EventArgs e)
        {
            new CounterTemplate().ShowDialog();
            if (Properties.Settings.Default.TemplatesCounterIndex == 0) Data.TextTemplate = Properties.Settings.Default.CustomCounterTemplate;
            else Data.TextTemplate = Properties.Settings.Default.TemplatesCounter[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
            PushFrame(ReturnText(), true);
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItem29_Click(object sender, EventArgs e)
        {
            new Info().ShowDialog();
        }

        private void XHalfHalfHalfMode_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResMulti = 8.0f;
            Properties.Settings.Default.Save();
            XHalfHalfHalfMode.Checked = true;
            XHalfHalfMode.Checked = false;
            XHalfMode.Checked = false;
            XLessQuarterMode.Checked = false;
            NativeMode.Checked = false;
            XQuarterMode.Checked = false;
            X2Mode.Checked = false;
            X4Mode.Checked = false;
            X8Mode.Checked = false;
            PushFrame(ReturnText(), true);
        }

        private void XHalfHalfMode_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResMulti = 4.0f;
            Properties.Settings.Default.Save();
            XHalfHalfHalfMode.Checked = false;
            XHalfHalfMode.Checked = true;
            XHalfMode.Checked = false;
            XLessQuarterMode.Checked = false;
            NativeMode.Checked = false;
            XQuarterMode.Checked = false;
            X2Mode.Checked = false;
            X4Mode.Checked = false;
            X8Mode.Checked = false;
            PushFrame(ReturnText(), true);
        }

        private void XHalfMode_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResMulti = 2.0f;
            Properties.Settings.Default.Save();
            XHalfHalfHalfMode.Checked = false;
            XHalfHalfMode.Checked = false;
            XHalfMode.Checked = true;
            XLessQuarterMode.Checked = false;
            NativeMode.Checked = false;
            XQuarterMode.Checked = false;
            X2Mode.Checked = false;
            X4Mode.Checked = false;
            X8Mode.Checked = false;
            PushFrame(ReturnText(), true);
        }

        private void XLessQuarterMode_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResMulti = 1.5f;
            Properties.Settings.Default.Save();
            XHalfHalfHalfMode.Checked = false;
            XHalfHalfMode.Checked = false;
            XHalfMode.Checked = false;
            XLessQuarterMode.Checked = true;
            NativeMode.Checked = false;
            XQuarterMode.Checked = false;
            X2Mode.Checked = false;
            X4Mode.Checked = false;
            X8Mode.Checked = false;
            PushFrame(ReturnText(), true);
        }

        private void NativeMode_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResMulti = 1.0f;
            Properties.Settings.Default.Save();
            XHalfHalfHalfMode.Checked = false;
            XHalfHalfMode.Checked = false;
            XHalfMode.Checked = false;
            XLessQuarterMode.Checked = false;
            NativeMode.Checked = true;
            XQuarterMode.Checked = false;
            X2Mode.Checked = false;
            X4Mode.Checked = false;
            X8Mode.Checked = false;
            PushFrame(ReturnText(), true);
        }

        private void XQuarterMode_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResMulti = 0.75f;
            Properties.Settings.Default.Save();
            XHalfHalfHalfMode.Checked = false;
            XHalfHalfMode.Checked = false;
            XHalfMode.Checked = false;
            XLessQuarterMode.Checked = false;
            NativeMode.Checked = false;
            XQuarterMode.Checked = true;
            X2Mode.Checked = false;
            X4Mode.Checked = false;
            X8Mode.Checked = false;
            PushFrame(ReturnText(), true);
        }

        private void X2Mode_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResMulti = 0.5f;
            Properties.Settings.Default.Save();
            XHalfHalfHalfMode.Checked = false;
            XHalfHalfMode.Checked = false;
            XHalfMode.Checked = false;
            XLessQuarterMode.Checked = false;
            NativeMode.Checked = false;
            XQuarterMode.Checked = false;
            X2Mode.Checked = true;
            X4Mode.Checked = false;
            X8Mode.Checked = false;
            PushFrame(ReturnText(), true);
        }

        private void X4Mode_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResMulti = 0.25f;
            Properties.Settings.Default.Save();
            XHalfHalfHalfMode.Checked = false;
            XHalfHalfMode.Checked = false;
            XHalfMode.Checked = false;
            XLessQuarterMode.Checked = false;
            NativeMode.Checked = false;
            XQuarterMode.Checked = false;
            X2Mode.Checked = false;
            X4Mode.Checked = true;
            X8Mode.Checked = false;
            PushFrame(ReturnText(), true);
        }

        private void X8Mode_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResMulti = 0.125f;
            Properties.Settings.Default.Save();
            XHalfHalfHalfMode.Checked = false;
            XHalfHalfMode.Checked = false;
            XHalfMode.Checked = false;
            XLessQuarterMode.Checked = false;
            NativeMode.Checked = false;
            XQuarterMode.Checked = false;
            X2Mode.Checked = false;
            X4Mode.Checked = false;
            X8Mode.Checked = true;
            PushFrame(ReturnText(), true);
        }

        private void NoTrimMillisecs_Click(object sender, EventArgs e)
        {
            if (NoTrimMillisecs.Checked != true)
            {
                NoTrimMillisecs.Checked = true;
                Properties.Settings.Default.NoTrimMilliseconds = true;
            }
            else
            {
                NoTrimMillisecs.Checked = false;
                Properties.Settings.Default.NoTrimMilliseconds = false;
            }
            Properties.Settings.Default.Save();
            PushFrame(ReturnText(), true);
        }

        private void UseAllThreads_Click(object sender, EventArgs e)
        {
            if (UseAllThreads.Checked != true)
            {
                UseAllThreads.Checked = true;
                Properties.Settings.Default.UseAllThreads = true;
            }
            else
            {
                UseAllThreads.Checked = false;
                Properties.Settings.Default.UseAllThreads = false;
            }
            Properties.Settings.Default.Save();
        }

        private void GarbageCollector_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Threading.Thread.Sleep(100);
            }
        }
    }

    public static class InputExtensions
    {
        public static int LimitIntegerToRange(this int value, int inclusiveMinimum, int inclusiveMaximum)
        {
            if (value < inclusiveMinimum) { return inclusiveMinimum; }
            if (value > inclusiveMaximum) { return inclusiveMaximum; }
            return value;
        }

        public static long LimitLongToRange(this long value, long inclusiveMinimum, long inclusiveMaximum)
        {
            if (value < inclusiveMinimum) { return inclusiveMinimum; }
            if (value > inclusiveMaximum) { return inclusiveMaximum; }
            return value;
        }
    }
}
