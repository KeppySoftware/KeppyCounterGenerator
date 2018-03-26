using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Midi;

namespace KeppyCounterGenerator
{
    public partial class MainWin : Form
    {
        public class FFMPEGProcess
        {
            public static Process FFMPEG;
            public static Double Hertz = 1.0 / (Double)Properties.Settings.Default.FPSExport;
            public static Bitmap Preview;
            public static UInt64 Frames = 0;
            public static UInt64 FramesAvg = 0;
        }

        public class Data
        {
            public static BASS_MIDI_MARK Mark = new BASS_MIDI_MARK();
            public static String PercentageProgress = "0%";
            public static String MIDIToLoad;
            public static String MovieOutput;
            public static String TextTemplateBL = "";
            public static String TextTemplateBC = "";
            public static String TextTemplateBR = "";
            public static String TextTemplateML = "";
            public static String TextTemplateMC = "";
            public static String TextTemplateMR = "";
            public static String TextTemplateTL = "";
            public static String TextTemplateTC = "";
            public static String TextTemplateTR = "";
            public static float OsuemSize = Properties.Settings.Default.CounterFont.Size;
            public static String NotesPerSecond = "0";
            public static String AverageNotesPerSecond = "0";
            public static SYNCPROC NoteSync;
            public static SYNCPROC TimeSigSync;
            public static Int32 StreamHandle;
            public static Single PPQN = 0.0f; 
            public static TimeSpan CurrentTime = TimeSpan.Zero;
            public static TimeSpan TotalTime = TimeSpan.Zero;
            public static String HowManyZeroesNotes = "";
            public static String HowManyZeroesBars = "";
            public static UInt32 Tempo = 0;
            public static UInt64 TotalBars = 0;
            public static UInt64 Bar = 0;
            public static UInt64 TotalNotes = 0;
            public static UInt64 TotalTicks = 0;
            public static UInt64 Tick = 0;
            public static UInt64[] PlayedNotesChan = new UInt64[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            public static UInt64 PlayedNotesFrame = 0;
            public static List<Double> PlayedNotesAvg = new List<Double>();
        }

        public class Framerate
        {
            public static DateTime _lastTime; // marks the beginning the measurement began
            public static UInt64 _framesRendered; // an increasing count
            public static UInt64 _fps;
        }

        public class Settings
        {
            public static Boolean Interrupt = false;
        }

        public MainWin()
        {
            InitializeComponent();
            StatusStrip.Padding = new Padding(StatusStrip.Padding.Left, StatusStrip.Padding.Top, StatusStrip.Padding.Left, StatusStrip.Padding.Bottom);
        }

        private string ReturnText(string template)
        {
            try
            {
                String Beat = Regex.Match(Data.Mark.text, "^[^ ]+").Value;
                UInt64 PlayedNotes = 0;

                for (int i = 0; i < Data.PlayedNotesChan.Length; i++) PlayedNotes += Data.PlayedNotesChan[i];

                String ToReturn = String.Format(template,
                    ReturnOutputText(Data.CurrentTime),                                 // Current time
                    ReturnOutputText(Data.TotalTime),
                    Data.Tempo.ToString("000"),
                    PlayedNotes.ToString(Properties.Settings.Default.RemoveAdditionalZeroes ? null : Data.HowManyZeroesNotes),
                    Data.TotalNotes,
                    String.IsNullOrEmpty(Beat) ? "0/0" : Beat,
                    Data.PPQN,
                    Data.Tick,
                    Data.TotalTicks,
                    ((Data.Bar / 2) + 1).ToString(Properties.Settings.Default.RemoveAdditionalZeroes ? null : Data.HowManyZeroesBars),
                    ((Data.TotalBars / 2) + 1).ToString(Properties.Settings.Default.RemoveAdditionalZeroes ? null : Data.HowManyZeroesBars),
                    Data.NotesPerSecond,
                    Data.AverageNotesPerSecond
                    );

                try
                {
                    ToReturn = ToReturn
                    .Replace("[[CV1]]", Data.PlayedNotesChan[0].ToString())
                    .Replace("[[CV2]]", Data.PlayedNotesChan[1].ToString())
                    .Replace("[[CV3]]", Data.PlayedNotesChan[2].ToString())
                    .Replace("[[CV4]]", Data.PlayedNotesChan[3].ToString())
                    .Replace("[[CV5]]", Data.PlayedNotesChan[4].ToString())
                    .Replace("[[CV6]]", Data.PlayedNotesChan[5].ToString())
                    .Replace("[[CV7]]", Data.PlayedNotesChan[6].ToString())
                    .Replace("[[CV8]]", Data.PlayedNotesChan[7].ToString())
                    .Replace("[[CV9]]", Data.PlayedNotesChan[8].ToString())
                    .Replace("[[CV10]]", Data.PlayedNotesChan[9].ToString())
                    .Replace("[[CV11]]", Data.PlayedNotesChan[10].ToString())
                    .Replace("[[CV12]]", Data.PlayedNotesChan[11].ToString())
                    .Replace("[[CV13]]", Data.PlayedNotesChan[12].ToString())
                    .Replace("[[CV14]]", Data.PlayedNotesChan[13].ToString())
                    .Replace("[[CV15]]", Data.PlayedNotesChan[14].ToString())
                    .Replace("[[CV16]]", Data.PlayedNotesChan[15].ToString());
                }
                catch { }

                return ToReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "Unknown template. Please check it for errors.";
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            CheckPos.RunWorkerAsync();
            GarbageCollector.RunWorkerAsync();

            DebugInfo.Checked = Properties.Settings.Default.DebugInfo;
            NoTrimMillisecs.Checked = Properties.Settings.Default.NoTrimMilliseconds;
            HideMilliseconds.Checked = Properties.Settings.Default.RemoveMilliseconds;
            StillFramesEnd.Checked = Properties.Settings.Default.StillFramesEnd;
            StillFramesBeginning.Checked = Properties.Settings.Default.StillFramesBeginning;
            RemoveAdditionalZeroes.Checked = Properties.Settings.Default.RemoveAdditionalZeroes;

            if (Properties.Settings.Default.TemplatesCounterIndex == 0)
            {
                Data.TextTemplateBL = Properties.Settings.Default.CustomCounterTemplateBL;
                Data.TextTemplateBC = Properties.Settings.Default.CustomCounterTemplateBC;
                Data.TextTemplateBR = Properties.Settings.Default.CustomCounterTemplateBR;
                Data.TextTemplateML = Properties.Settings.Default.CustomCounterTemplateML;
                Data.TextTemplateMC = Properties.Settings.Default.CustomCounterTemplateMC;
                Data.TextTemplateMR = Properties.Settings.Default.CustomCounterTemplateMR;
                Data.TextTemplateTL = Properties.Settings.Default.CustomCounterTemplateTL;
                Data.TextTemplateTC = Properties.Settings.Default.CustomCounterTemplateTC;
                Data.TextTemplateTR = Properties.Settings.Default.CustomCounterTemplateTR;
            }
            else
            {
                Data.TextTemplateBL = Properties.Settings.Default.TemplatesCounterBL[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateBC = Properties.Settings.Default.TemplatesCounterBC[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateBR = Properties.Settings.Default.TemplatesCounterBR[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateML = Properties.Settings.Default.TemplatesCounterML[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateMC = Properties.Settings.Default.TemplatesCounterMC[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateMR = Properties.Settings.Default.TemplatesCounterMR[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateTL = Properties.Settings.Default.TemplatesCounterTL[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateTC = Properties.Settings.Default.TemplatesCounterTC[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateTR = Properties.Settings.Default.TemplatesCounterTR[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
            }

            PushFrame(true);
        }

        private void NoteSyncProc(int handle, int channel, int data, IntPtr user)
        {
            int midichan = data >> 16; // MIDI channel
            if ((data & 0xff00) != 0)
            {
                Data.PlayedNotesChan[midichan]++;
                Data.PlayedNotesFrame++;
                if (Data.OsuemSize <= Properties.Settings.Default.CounterFont.Size + (Properties.Settings.Default.CounterFont.Size / 8))
                    Data.OsuemSize = Properties.Settings.Default.CounterFont.Size + (Properties.Settings.Default.CounterFont.Size / 8) + (Properties.Settings.Default.CounterFont.Size / 20);
            }
        }

        private void TimeSigSyncProc(int handle, int channel, int data, IntPtr user)
        {
            BassMidi.BASS_MIDI_StreamGetMark(Data.StreamHandle, BASSMIDIMarker.BASS_MIDI_MARK_TIMESIG, data, Data.Mark);
        }

        private void FPSUpdate()
        {
            Framerate._framesRendered++;

            if ((DateTime.Now - Framerate._lastTime).TotalSeconds >= 1)
            {
                // one second has elapsed 

                Framerate._fps = Framerate._framesRendered;
                Framerate._framesRendered = 0;
                Framerate._lastTime = DateTime.Now;
            }   
        }

        private bool IsFFMpegPresent()
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.FFMpegLocation)) return false;
            else
            {
                try
                {
                    return File.Exists(Properties.Settings.Default.FFMpegLocation);
                }
                catch
                {
                    return false;
                }
            }
        }

        private void CheckFFMpegFirst()
        {
            if (!IsFFMpegPresent())
            {
                OpenFileDialog FFMpegDirectory = new OpenFileDialog();

                RETRY:
                MessageBox.Show(
                    String.Format("FFMpeg is missing.\n\nDownload it from {0}, move it in a directory, then click OK to select it.", "http://ffmpeg.zeranoe.com/builds/"),
                    "Error while starting the conversion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                FFMpegDirectory.FileName = "FFMpeg.exe";
                FFMpegDirectory.Filter = "FFMpeg.exe|ffmpeg.exe";
                FFMpegDirectory.Title = "Select the location of the FFMpeg encoding library";
                FFMpegDirectory.InitialDirectory = Properties.Settings.Default.LastExportFolder;
                if (FFMpegDirectory.ShowDialog() == DialogResult.OK)
                {
                    if (!File.Exists(FFMpegDirectory.FileName))
                    {
                        MessageBox.Show("Invalid executable.\n\nTry again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        goto RETRY;
                    }
                    else
                    {
                        Properties.Settings.Default.FFMpegLocation = FFMpegDirectory.FileName;
                        Properties.Settings.Default.LastExportFolder = Path.GetDirectoryName(FFMpegDirectory.FileName);
                        Properties.Settings.Default.Save();
                    }
                }
                else return;

                FFMpegDirectory.Dispose();
            }
        }

        private bool StartConversion(string str)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.RedirectStandardInput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = !Properties.Settings.Default.DebugInfo;
                psi.FileName = Properties.Settings.Default.FFMpegLocation;
                psi.WorkingDirectory = Directory.GetCurrentDirectory();
                psi.Arguments = String.Format("-y -vsync 2 {0} -r {1} -i - -vcodec {2} \"{3}\"",
                    Properties.Settings.Default.UseAllThreads ? String.Format("-threads {0}", Environment.ProcessorCount) : "", // Use all threads or not?
                    Properties.Settings.Default.FPSExport, // Framerate
                    Properties.Settings.Default.CodecOutput[Properties.Settings.Default.CodecSelection], // Codec
                    Data.MovieOutput); // File output
                FFMPEGProcess.FFMPEG = Process.Start(psi);
                return true;
            }
            catch
            {
                Settings.Interrupt = true;
                Bass.BASS_StreamFree(Data.StreamHandle);
                Bass.BASS_Free();

                Thread thread = new Thread(() => Clipboard.SetText("http://ffmpeg.zeranoe.com/builds/"));
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                thread.Start();
                thread.Join(); //Wait for the thread to end

                MessageBox.Show(
                    String.Format("FFMpeg is missing.\n\nTo configure the Please download it from {0}, and move it to {1}, then try again.\n\nThe link for the compiled libraries has been copied to the clipboard.",
                    "http://ffmpeg.zeranoe.com/builds/", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)), "Error while starting the conversion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public void AddTextToFrame(string text, Boolean Osu, Brush textcolor, RectangleF rectf, StringAlignment X, StringAlignment Y, Graphics g)
        {
            Font Ses = new Font(Properties.Settings.Default.CounterFont.FontFamily, Osu ? Data.OsuemSize : Properties.Settings.Default.CounterFont.Size, FontStyle.Regular);

            StringFormat format = new StringFormat()
            {
                Alignment = X,
                LineAlignment = Y,
            };

            g.DrawString(text, Ses, textcolor, rectf, format);
        }

        public void AddWatermarkToFrame(RectangleF rectf, Graphics g)
        {
            Brush textcolorp = new SolidBrush(Color.Red);
            Font preview = new Font(Properties.Settings.Default.CounterFont.FontFamily, (18.0f / (float)(PreviewBox.Width / Properties.Settings.Default.WRes)), FontStyle.Regular);

            StringFormat format = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            g.DrawString(String.Format("This is a preview in {0}x{1}\nThis text will not appear in the final render",
                    (Int32)(Properties.Settings.Default.WRes),
                    (Int32)(Properties.Settings.Default.HRes)),
                    preview, textcolorp, rectf, format);

            textcolorp.Dispose();
        }

        public void PushFrame(bool isexample)
        {
            try
            {
                Bitmap bmp = new Bitmap(
                    (Int32)(Properties.Settings.Default.WRes),
                    (Int32)(Properties.Settings.Default.HRes)
                    );

                RectangleF rectf = new RectangleF(0, 0, bmp.Width, bmp.Height);

                Brush background = new SolidBrush(Color.Transparent);
                Brush textcolor = new SolidBrush(Color.White);

                Graphics g = Graphics.FromImage(bmp);

                g.FillRectangle(background, rectf);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                AddTextToFrame(ReturnText(Data.TextTemplateBL), Properties.Settings.Default.OsuModeBL, textcolor, rectf, StringAlignment.Near, StringAlignment.Far, g);
                AddTextToFrame(ReturnText(Data.TextTemplateBC), Properties.Settings.Default.OsuModeBC, textcolor, rectf, StringAlignment.Center, StringAlignment.Far, g);
                AddTextToFrame(ReturnText(Data.TextTemplateBR), Properties.Settings.Default.OsuModeBR, textcolor, rectf, StringAlignment.Far, StringAlignment.Far, g);
                AddTextToFrame(ReturnText(Data.TextTemplateML), Properties.Settings.Default.OsuModeML, textcolor, rectf, StringAlignment.Near, StringAlignment.Center, g);
                AddTextToFrame(ReturnText(Data.TextTemplateMC), Properties.Settings.Default.OsuModeMC, textcolor, rectf, StringAlignment.Center, StringAlignment.Center, g);
                AddTextToFrame(ReturnText(Data.TextTemplateMR), Properties.Settings.Default.OsuModeMR, textcolor, rectf, StringAlignment.Far, StringAlignment.Center, g);
                AddTextToFrame(ReturnText(Data.TextTemplateTL), Properties.Settings.Default.OsuModeTL, textcolor, rectf, StringAlignment.Near, StringAlignment.Near, g);
                AddTextToFrame(ReturnText(Data.TextTemplateTC), Properties.Settings.Default.OsuModeTC, textcolor, rectf, StringAlignment.Center, StringAlignment.Near, g);
                AddTextToFrame(ReturnText(Data.TextTemplateTR), Properties.Settings.Default.OsuModeTR, textcolor, rectf, StringAlignment.Far, StringAlignment.Near, g);

                if (isexample == true)
                {
                    AddWatermarkToFrame(rectf, g);
                }

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
                background.Dispose();
                textcolor.Dispose();
                g.Dispose();
            }
            catch (Exception ex)
            {
                Settings.Interrupt = true;
                Bass.BASS_StreamFree(Data.StreamHandle);
                Bass.BASS_Free();

                MessageBox.Show(
                    String.Format(ex.ToString(), Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)), "Error while converting the MIDI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrameConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Initialize BASS and variables
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 0);
                Data.StreamHandle = BassMidi.BASS_MIDI_StreamCreateFile(Data.MIDIToLoad, 0L, 0L, BASSFlag.BASS_MIDI_NOCROP | BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_MIDI_DECAYEND, 0);
                Data.PlayedNotesAvg = new List<Double>();

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

                Data.OsuemSize = Properties.Settings.Default.CounterFont.Size;

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
                Data.TotalNotes = Convert.ToUInt32(BassMidi.BASS_MIDI_StreamGetEvents(Data.StreamHandle, -1, (BASSMIDIEvent)0x20000, null));
                Data.HowManyZeroesNotes = String.Concat(Enumerable.Repeat("0", Data.TotalNotes.ToString().Length));

                // Initialize conversion
                if (!StartConversion(Data.MIDIToLoad)) return;
                FPSUpdate();

                if (Properties.Settings.Default.StillFramesBeginning)
                {
                    for (int a = 0; a <= (Properties.Settings.Default.FPSExport * 5); a++)
                    {
                        // 5 seconds of nothing
                        if (Settings.Interrupt == true) break;
                        CheckPosition();
                        Data.NotesPerSecond = "0";
                        PushFrame(false);
                        FFMPEGProcess.Frames++;
                        FPSUpdate();
                    }
                }

                while (Bass.BASS_ChannelIsActive(Data.StreamHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    if (Data.OsuemSize > Properties.Settings.Default.CounterFont.Size)
                    {
                        Data.OsuemSize -= (Properties.Settings.Default.CounterFont.Size / 24);
                        if (Data.OsuemSize < Properties.Settings.Default.CounterFont.Size) Data.OsuemSize = Properties.Settings.Default.CounterFont.Size;
                    }
                    else Data.OsuemSize = Properties.Settings.Default.CounterFont.Size;

                    if (Settings.Interrupt == true) break;
                    Buffer = new Byte[ChunkLength];
                    Bass.BASS_ChannelGetData(Data.StreamHandle, Buffer, ChunkLength);
                    CheckPosition();

                    if (FFMPEGProcess.Frames % (ulong)Properties.Settings.Default.FPSExport == 0)
                    {
                        Data.NotesPerSecond = Data.PlayedNotesFrame.ToString();
                        Data.PlayedNotesAvg.Add(Data.PlayedNotesFrame);
                        Data.AverageNotesPerSecond = Data.PlayedNotesAvg.Average().ToString("0.0");
                        Data.PlayedNotesFrame = 0;
                    }

                    PushFrame(false);
                    FFMPEGProcess.Frames++;
                    FPSUpdate();
                }

                Buffer = new Byte[ChunkLength];
                Bass.BASS_ChannelGetData(Data.StreamHandle, Buffer, ChunkLength);

                if (Properties.Settings.Default.StillFramesEnd)
                {
                    for (int a = 0; a <= (Properties.Settings.Default.FPSExport * 5); a++)
                    {
                        if (Data.OsuemSize > Properties.Settings.Default.CounterFont.Size)
                        {
                            Data.OsuemSize -= (Properties.Settings.Default.CounterFont.Size / 24);
                            if (Data.OsuemSize < Properties.Settings.Default.CounterFont.Size) Data.OsuemSize = Properties.Settings.Default.CounterFont.Size;
                        }
                        else Data.OsuemSize = Properties.Settings.Default.CounterFont.Size;

                        // 5 seconds of nothing
                        if (Settings.Interrupt == true) break;
                        CheckPosition();
                        Data.NotesPerSecond = "0";
                        PushFrame(false);
                        FFMPEGProcess.Frames++;
                        FPSUpdate();
                    }
                }

                for (int i = 0; i < Data.PlayedNotesChan.Length; i++) Data.PlayedNotesChan[i] = 0;

                Data.Mark = new BASS_MIDI_MARK();
                FFMPEGProcess.Frames = 0;
                FFMPEGProcess.FFMPEG.StandardInput.Close();

                Bass.BASS_StreamFree(Data.StreamHandle);
                Bass.BASS_Free();

                Settings.Interrupt = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static String ReturnOutputText(TimeSpan TimeToCheck)
        {
            String F;
            if (Properties.Settings.Default.RemoveMilliseconds == false)
            {
                if (Properties.Settings.Default.NoTrimMilliseconds == true)
                {
                    F = @"\.fff";
                }
                else
                {
                    F = @"\.f";
                }
            }
            else
            {
                F = null;
            }

            if (Data.TotalTime.Hours >= 10) return TimeToCheck.ToString(String.Format(@"hh\:mm\:ss{0}", F));
            else
            {
                if (Data.TotalTime.Hours >= 1) return TimeToCheck.ToString(String.Format(@"h\:mm\:ss{0}", F));
                else
                {
                    if (Data.TotalTime.Minutes >= 10) return TimeToCheck.ToString(String.Format(@"mm\:ss{0}", F));
                    else return TimeToCheck.ToString(String.Format(@"m\:ss{0}", F));
                }
            }
        }

        Single RAWTotal;
        Single RAWConverted;
        private void CheckPosition()
        {
            Int64 MIDILengthRAW = Bass.BASS_ChannelGetLength(Data.StreamHandle);
            Int64 MIDICurrentPosRAW = Bass.BASS_ChannelGetPosition(Data.StreamHandle);
            RAWTotal = ((float)MIDILengthRAW) / 1048576f;
            RAWConverted = ((float)MIDICurrentPosRAW) / 1048576f;
            Double LenRAWToDouble = Bass.BASS_ChannelBytes2Seconds(Data.StreamHandle, MIDILengthRAW);
            Double CurRAWToDouble = Bass.BASS_ChannelBytes2Seconds(Data.StreamHandle, MIDICurrentPosRAW);
            Data.TotalTime = TimeSpan.FromSeconds(LenRAWToDouble);
            Data.CurrentTime = TimeSpan.FromSeconds(CurRAWToDouble);
            Bass.BASS_ChannelGetAttribute(Data.StreamHandle, BASSAttribute.BASS_ATTRIB_MIDI_PPQN, ref Data.PPQN);
            Data.TotalTicks = Convert.ToUInt32(Bass.BASS_ChannelGetLength(Data.StreamHandle, BASSMode.BASS_POS_MIDI_TICK));
            Data.Tick = Convert.ToUInt32(Bass.BASS_ChannelGetPosition(Data.StreamHandle, BASSMode.BASS_POS_MIDI_TICK));
            Int32 Tempo = 60000000 / BassMidi.BASS_MIDI_StreamGetEvent(Data.StreamHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO);
            Data.Tempo = Convert.ToUInt32(Tempo.LimitIntegerToRange(0, 999));

            try
            {
                Data.Bar = Convert.ToUInt32(((Int64)(Data.Tick / (Data.PPQN / (8 / 4) * 4))).LimitLongToRange(0, 9223372036854775807));
                Data.TotalBars = Convert.ToUInt32(((Int64)(Data.TotalTicks / (Data.PPQN / (8 / 4) * 4))).LimitLongToRange(0, 9223372036854775807));
                Data.HowManyZeroesBars = String.Concat(Enumerable.Repeat("0", Data.TotalBars.ToString().Length));
            }
            catch
            {
                Data.Bar = 0;
                Data.TotalBars = 0;
            }
        }

        private void CheckPos_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
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
            OpenMIDI.InitialDirectory = Properties.Settings.Default.LastMIDIFolder;
            if (OpenMIDI.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(OpenMIDI.FileName).ToLower() != ".mid")
                {
                    MessageBox.Show("Select a MIDI!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto Init;
                }
                else
                {
                    Data.MIDIToLoad = OpenMIDI.FileName;

                    String MIDIFileName = Path.GetFileName(Data.MIDIToLoad);
                    if (MIDIFileName.Length > 55) CurrentMIDILoaded.Text = Path.GetFileName(Data.MIDIToLoad).Truncate(55) + "...";
                    else CurrentMIDILoaded.Text = Path.GetFileName(Data.MIDIToLoad);

                    Properties.Settings.Default.LastMIDIFolder = Path.GetDirectoryName(OpenMIDI.FileName);
                    Properties.Settings.Default.Save();

                    CurrentMIDILoaded.ToolTipText = String.Format("Selected MIDI:\n{0}", Data.MIDIToLoad);
                }
            }
        }

        private void StartConvThread_Click(object sender, EventArgs e)
        {
            Settings.Interrupt = false;
            if (File.Exists(Data.MIDIToLoad))
            {
                if (IntPtr.Size == 4)
                {
                    FileInfo MIDISizeCheck = new System.IO.FileInfo(Data.MIDIToLoad);
                    if (MIDISizeCheck.Length >= 1073741824) {
                        MessageBox.Show("The MIDI is too big.\n\nConsider using the 64-bit release.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                CheckFFMpegFirst();
                SaveMovieTo.InitialDirectory = Properties.Settings.Default.LastExportFolder;
                SaveMovieTo.FileName = String.Format("{0}.mov", Path.GetFileNameWithoutExtension(Data.MIDIToLoad));
                if (SaveMovieTo.ShowDialog() == DialogResult.OK)
                {
                    Data.MovieOutput = SaveMovieTo.FileName;
                    Properties.Settings.Default.LastExportFolder = Path.GetDirectoryName(SaveMovieTo.FileName);
                    Properties.Settings.Default.Save();
                    try { FrameConverter.RunWorkerAsync(); } catch { MessageBox.Show("The generator is busy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
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

        bool alreadyidle = false;
        private void LivePreview_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Bass.BASS_ChannelIsActive(Data.StreamHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    if (alreadyidle)
                    {
                        SelectMIDIDialog.Enabled = false;
                        StartConvThread.Enabled = false;
                        ChangeFontTypeface.Enabled = false;
                        MillMenu.Enabled = false;
                        AdvancedMenu.Enabled = false;
                        CCT.Enabled = false;
                        ResItems.Enabled = false;

                        CurrentStatus.Text = "Idle";

                        alreadyidle = false;
                    }

                    CurrentStatus.Text = String.Format("{0} ({1} frames done, {2} frame(s) rendered every one second)", Data.PercentageProgress, FFMPEGProcess.Frames, Framerate._fps);

                    if (PreviewBox.Image != null) PreviewBox.Image.Dispose();
                    try
                    {
                        PreviewBox.Image = FFMPEGProcess.Preview.Clone(new Rectangle(0, 0, FFMPEGProcess.Preview.Width, FFMPEGProcess.Preview.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                    }
                    catch { }
                }
                else
                {
                    if (!alreadyidle)
                    {
                        SelectMIDIDialog.Enabled = true;
                        StartConvThread.Enabled = true;
                        ChangeFontTypeface.Enabled = true;
                        MillMenu.Enabled = true;
                        AdvancedMenu.Enabled = true;
                        CCT.Enabled = true;
                        ResItems.Enabled = true;

                        CurrentStatus.Text = "Idle";

                        alreadyidle = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                        Data.OsuemSize = Properties.Settings.Default.CounterFont.Size;
                        PushFrame(true);
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
                        PushFrame(true);
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

        private void ChangeBackgroundImg_Click(object sender, EventArgs e)
        {
            Init:
            ImportBackground.InitialDirectory = Properties.Settings.Default.LastBackgroundFolder;
            if (ImportBackground.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PreviewBox.BackgroundImage = Image.FromFile(ImportBackground.FileName);
                    Properties.Settings.Default.LastBackgroundFolder = Path.GetDirectoryName(ImportBackground.FileName);
                    Properties.Settings.Default.Save();
                }
                catch
                {
                    MessageBox.Show("Error.");
                    goto Init;
                }
            }
        }

        private void CCT_Click(object sender, EventArgs e)
        {
            new CounterTemplate().ShowDialog();

            if (Properties.Settings.Default.TemplatesCounterIndex == 0)
            {
                Data.TextTemplateBL = Properties.Settings.Default.CustomCounterTemplateBL;
                Data.TextTemplateBC = Properties.Settings.Default.CustomCounterTemplateBC;
                Data.TextTemplateBR = Properties.Settings.Default.CustomCounterTemplateBR;
                Data.TextTemplateML = Properties.Settings.Default.CustomCounterTemplateML;
                Data.TextTemplateMC = Properties.Settings.Default.CustomCounterTemplateMC;
                Data.TextTemplateMR = Properties.Settings.Default.CustomCounterTemplateMR;
                Data.TextTemplateTL = Properties.Settings.Default.CustomCounterTemplateTL;
                Data.TextTemplateTC = Properties.Settings.Default.CustomCounterTemplateTC;
                Data.TextTemplateTR = Properties.Settings.Default.CustomCounterTemplateTR;
            }
            else
            {
                Data.TextTemplateBL = Properties.Settings.Default.TemplatesCounterBL[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateBC = Properties.Settings.Default.TemplatesCounterBC[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateBR = Properties.Settings.Default.TemplatesCounterBR[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateML = Properties.Settings.Default.TemplatesCounterML[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateMC = Properties.Settings.Default.TemplatesCounterMC[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateMR = Properties.Settings.Default.TemplatesCounterMR[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateTL = Properties.Settings.Default.TemplatesCounterTL[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateTC = Properties.Settings.Default.TemplatesCounterTC[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
                Data.TextTemplateTR = Properties.Settings.Default.TemplatesCounterTR[Properties.Settings.Default.TemplatesCounterIndex - 1].Replace("\\n", "\n");
            }

            PushFrame(true);
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItem29_Click(object sender, EventArgs e)
        {
            new Info().ShowDialog();
        }

        private void ResItems_Click(object sender, EventArgs e)
        {
            new OutputRes().ShowDialog();
            PushFrame(true);
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
            PushFrame(true);
        }

        private void HideMillseconds_Click(object sender, EventArgs e)
        {
            if (HideMilliseconds.Checked != true)
            {
                HideMilliseconds.Checked = true;
                Properties.Settings.Default.RemoveMilliseconds = true;
            }
            else
            {
                HideMilliseconds.Checked = false;
                Properties.Settings.Default.RemoveMilliseconds = false;
            }
            Properties.Settings.Default.Save();
            PushFrame(true);
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

        private void DebugInfo_Click(object sender, EventArgs e)
        {
            if (DebugInfo.Checked != true)
            {
                DebugInfo.Checked = true;
                Properties.Settings.Default.DebugInfo = true;
            }
            else
            {
                DebugInfo.Checked = false;
                Properties.Settings.Default.DebugInfo = false;
            }
            Properties.Settings.Default.Save();
        }

        private void StillFramesBeginning_Click(object sender, EventArgs e)
        {
            if (StillFramesBeginning.Checked != true)
            {
                StillFramesBeginning.Checked = true;
                Properties.Settings.Default.StillFramesBeginning = true;
            }
            else
            {
                StillFramesBeginning.Checked = false;
                Properties.Settings.Default.StillFramesBeginning = false;
            }
            Properties.Settings.Default.Save();
        }

        private void StillFramesEnd_Click(object sender, EventArgs e)
        {
            if (StillFramesEnd.Checked != true)
            {
                StillFramesEnd.Checked = true;
                Properties.Settings.Default.StillFramesEnd = true;
            }
            else
            {
                StillFramesEnd.Checked = false;
                Properties.Settings.Default.StillFramesEnd = false;
            }
            Properties.Settings.Default.Save();
        }

        private void RemoveAdditionalZeroes_Click(object sender, EventArgs e)
        {
            if (RemoveAdditionalZeroes.Checked != true)
            {
                RemoveAdditionalZeroes.Checked = true;
                Properties.Settings.Default.RemoveAdditionalZeroes = true;
            }
            else
            {
                RemoveAdditionalZeroes.Checked = false;
                Properties.Settings.Default.RemoveAdditionalZeroes = false;
            }
            Properties.Settings.Default.Save();
            PushFrame(true);
        }

        private void MainWin_Resize(object sender, EventArgs e)
        {
            if (Bass.BASS_ChannelIsActive(Data.StreamHandle) != BASSActive.BASS_ACTIVE_PLAYING) PushFrame(true);
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

    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
