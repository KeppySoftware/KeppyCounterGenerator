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
            TemplatesBox.SelectedIndex = Properties.Settings.Default.TemplatesCounterIndex;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (TemplatesBox.SelectedIndex == 0)
            {
                Properties.Settings.Default.CustomCounterTemplate = TemplateEditor.Text;
                Properties.Settings.Default.Save();
            }
            Close();
        }

        private void TemplatesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TemplatesBox.SelectedIndex > 0)
            {
                TemplateEditor.ReadOnly = true;
                TemplateEditor.Text = Properties.Settings.Default.TemplatesCounter[TemplatesBox.SelectedIndex - 1];               
            }
            else
            {
                TemplateEditor.ReadOnly = false;
                TemplateEditor.Text = Properties.Settings.Default.CustomCounterTemplate;
            }
            Properties.Settings.Default.TemplatesCounterIndex = TemplatesBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
