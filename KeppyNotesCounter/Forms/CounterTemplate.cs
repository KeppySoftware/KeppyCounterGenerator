using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyCounterGenerator
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
            OsuModeTL.Checked = Properties.Settings.Default.OsuModeTL;
            OsuModeTC.Checked = Properties.Settings.Default.OsuModeTC;
            OsuModeTR.Checked = Properties.Settings.Default.OsuModeTR;
            OsuModeML.Checked = Properties.Settings.Default.OsuModeML;
            OsuModeMC.Checked = Properties.Settings.Default.OsuModeMC;
            OsuModeMR.Checked = Properties.Settings.Default.OsuModeMR;
            OsuModeBL.Checked = Properties.Settings.Default.OsuModeBL;
            OsuModeBC.Checked = Properties.Settings.Default.OsuModeBC;
            OsuModeBR.Checked = Properties.Settings.Default.OsuModeBR;
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
                Properties.Settings.Default.CustomCounterTemplateML = TemplateEditorML.Text;
                Properties.Settings.Default.CustomCounterTemplateMC = TemplateEditorMC.Text;
                Properties.Settings.Default.CustomCounterTemplateMR = TemplateEditorMR.Text;
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
                    TemplateEditorML.ReadOnly = true;
                    TemplateEditorMC.ReadOnly = true;
                    TemplateEditorMR.ReadOnly = true;
                    TemplateEditorTL.ReadOnly = true;
                    TemplateEditorTC.ReadOnly = true;
                    TemplateEditorTR.ReadOnly = true;
                    TemplateEditorBL.Text = Properties.Settings.Default.TemplatesCounterBL[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorBC.Text = Properties.Settings.Default.TemplatesCounterBC[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorBR.Text = Properties.Settings.Default.TemplatesCounterBR[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorML.Text = Properties.Settings.Default.TemplatesCounterML[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorMC.Text = Properties.Settings.Default.TemplatesCounterMC[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorMR.Text = Properties.Settings.Default.TemplatesCounterMR[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorTL.Text = Properties.Settings.Default.TemplatesCounterTL[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorTC.Text = Properties.Settings.Default.TemplatesCounterTC[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");
                    TemplateEditorTR.Text = Properties.Settings.Default.TemplatesCounterTR[TemplatesBox.SelectedIndex - 1].Replace("\\n", "\n");

                }
                else
                {
                    TemplateEditorBL.ReadOnly = false;
                    TemplateEditorBC.ReadOnly = false;
                    TemplateEditorBR.ReadOnly = false;
                    TemplateEditorML.ReadOnly = false;
                    TemplateEditorMC.ReadOnly = false;
                    TemplateEditorMR.ReadOnly = false;
                    TemplateEditorTL.ReadOnly = false;
                    TemplateEditorTC.ReadOnly = false;
                    TemplateEditorTR.ReadOnly = false;
                    TemplateEditorBL.Text = Properties.Settings.Default.CustomCounterTemplateBL;
                    TemplateEditorBC.Text = Properties.Settings.Default.CustomCounterTemplateBC;
                    TemplateEditorBR.Text = Properties.Settings.Default.CustomCounterTemplateBR;
                    TemplateEditorML.Text = Properties.Settings.Default.CustomCounterTemplateML;
                    TemplateEditorMC.Text = Properties.Settings.Default.CustomCounterTemplateMC;
                    TemplateEditorMR.Text = Properties.Settings.Default.CustomCounterTemplateMR;
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

        private void OsuModeTL_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OsuModeTL = OsuModeTL.Checked;
            Properties.Settings.Default.Save();
        }

        private void OsuModeTC_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OsuModeTC = OsuModeTC.Checked;
            Properties.Settings.Default.Save();
        }

        private void OsuModeTR_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OsuModeTR = OsuModeTR.Checked;
            Properties.Settings.Default.Save();
        }

        private void OsuModeML_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OsuModeML = OsuModeML.Checked;
            Properties.Settings.Default.Save();
        }

        private void OsuModeMC_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OsuModeMC = OsuModeMC.Checked;
            Properties.Settings.Default.Save();
        }

        private void OsuModeMR_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OsuModeMR = OsuModeMR.Checked;
            Properties.Settings.Default.Save();
        }

        private void OsuModeBR_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OsuModeBR = OsuModeBR.Checked;
            Properties.Settings.Default.Save();
        }

        private void OsuModeBC_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OsuModeBC = OsuModeBC.Checked;
            Properties.Settings.Default.Save();
        }

        private void OsuModeBL_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OsuModeBL = OsuModeBL.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
