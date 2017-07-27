using System;
using System.IO;
using System.Windows.Forms;

namespace KeppyNotesCounter
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (CheckQuickTime())
            {
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
            else
            {
                MessageBox.Show("QuickTime is required for this tool to work.\nAborting.\n\nPress OK to close the program.", "Keppy's Notes Counter - Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        static bool CheckQuickTime()
        {
            if (Directory.Exists(String.Format("{0}\\QuickTime\\", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)))) return true;
            else return false;
        }
    }
}
