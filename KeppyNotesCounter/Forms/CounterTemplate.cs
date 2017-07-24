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
                Properties.Settings.Default.CustomCounterTemplateBL = TemplateEditorBL.Text;
                Properties.Settings.Default.CustomCounterTemplateBC = TemplateEditorBC.Text;
                Properties.Settings.Default.CustomCounterTemplateBR = TemplateEditorBR.Text;
                Properties.Settings.Default.CustomCounterTemplateTL = TemplateEditorTL.Text;
                Properties.Settings.Default.CustomCounterTemplateTC = TemplateEditorTC.Text;
                Properties.Settings.Default.CustomCounterTemplateTR = TemplateEditorTR.Text;
                Properties.Settings.Default.Save();
            }
            Close();
        }

        private void TemplatesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TemplatesBox.SelectedIndex > 0)
                {
                    TemplateEditorBL.ReadOnly = true;
                    TemplateEditorBC.ReadOnly = true;
                    TemplateEditorBR.ReadOnly = true;
                    TemplateEditorTL.ReadOnly = true;
                    TemplateEditorTC.ReadOnly = true;
                    TemplateEditorTR.ReadOnly = true;
                    TemplateEditorBL.Text = Properties.Settings.Default.TemplatesCounterBL[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorBC.Text = Properties.Settings.Default.TemplatesCounterBC[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorBR.Text = Properties.Settings.Default.TemplatesCounterBR[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorTL.Text = Properties.Settings.Default.TemplatesCounterTL[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorTC.Text = Properties.Settings.Default.TemplatesCounterTC[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorTR.Text = Properties.Settings.Default.TemplatesCounterTR[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");

                }
                else
                {
                    TemplateEditorBL.ReadOnly = false;
                    TemplateEditorBC.ReadOnly = false;
                    TemplateEditorBR.ReadOnly = false;
                    TemplateEditorTL.ReadOnly = false;
                    TemplateEditorTC.ReadOnly = false;
                    TemplateEditorTR.ReadOnly = false;
                    TemplateEditorBL.Text = Properties.Settings.Default.CustomCounterTemplateBL;
                    TemplateEditorBC.Text = Properties.Settings.Default.CustomCounterTemplateBC;
                    TemplateEditorBR.Text = Properties.Settings.Default.CustomCounterTemplateBR;
                    TemplateEditorTL.Text = Properties.Settings.Default.CustomCounterTemplateTL;
                    TemplateEditorTC.Text = Properties.Settings.Default.CustomCounterTemplateTC;
                    TemplateEditorTR.Text = Properties.Settings.Default.CustomCounterTemplateTR;
                }
                Properties.Settings.Default.TemplatesCounterIndex = TemplatesBox.SelectedIndex;
                Properties.Settings.Default.Save();
            }
            catch
            {

            }
        }
    }
}
