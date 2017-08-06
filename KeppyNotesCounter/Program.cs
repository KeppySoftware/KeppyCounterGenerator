using System;
using System.IO;
using System.Windows.Forms;

namespace KeppyCounterGenerator
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.CodecSelection == 1 && !CheckQuickTime())
            {
                Properties.Settings.Default.CodecSelection = 0;
                Properties.Settings.Default.Save();
                MessageBox.Show("QuickTime is not installed.\nDefault output codec is now PNG video.\n\nPress OK to continue.", "Keppy's Notes Counter - Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWin());
        }

        public static bool CheckQuickTime()
        {
            if (Directory.Exists(String.Format("{0}\\QuickTime\\", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)))) return true;
            else return false;
        }
    }
}
