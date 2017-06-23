using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyNotesCounter
{
    public partial class CounterTemplate : Form
    {
        public CounterTemplate()
        {
            InitializeComponent();
        }

        private void CounterTemplate_Load(object sender, EventArgs e)
        {
            TemplateEditor.Text = Properties.Settings.Default.CounterTemplate;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CounterTemplate = TemplateEditor.Text;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
