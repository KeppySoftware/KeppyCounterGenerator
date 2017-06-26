using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyNotesCounter
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            InfoApp.Text = String.Format("Keppy's Notes Counter {0}.{1}{2}\nCopyright(C) KaleidonKep99 2017\nAll rights reserved.",
                 fvi.FileMajorPart, fvi.FileMinorPart, Properties.Settings.Default.IsUnstableRelease ? "a" : "");
        }
    }
}
