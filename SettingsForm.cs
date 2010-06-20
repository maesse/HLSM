using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HLSM
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            // Set values
            textBoxPath.Text = Properties.Settings.Default.HLPath;
            checkBoxTray.Checked = Properties.Settings.Default.MinimizeToTray;
            checkBoxExclBinds.Checked = Properties.Settings.Default.ExclusiveKeys;
            checkBoxCleanup.Checked = Properties.Settings.Default.CleanupFilenames;
            textBoxTick.Text = "" + Properties.Settings.Default.TickInterval;
            toolTip1.SetToolTip(checkBoxExclBinds, "When disabled, binds will also trigger when other keys are held down (so you don't have to release forward button, etc)");
            toolTip1.SetToolTip(button2, "This will install the voice script from HLSS, in the selected folder.\nIf you already have an autoexec, it will be backed up");
            toolTip1.SetToolTip(label1, "Advanced: Time between polling of keyboard (in ms)");
        }

        // Select folder
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                textBoxPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // Check settings
        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Check path
            string path = textBoxPath.Text;
            if (!Directory.Exists(path))
            {
                DialogResult result = MessageBox.Show(this, "Path is not valid. Continue?", "Half-Life path doesnt exist", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                // Abort
                if (result == System.Windows.Forms.DialogResult.No)
                    return;
            }
            else
            {
                // Save path
                Properties.Settings.Default.HLPath = path;
            }

            // Save minimize-setting
            Properties.Settings.Default.MinimizeToTray = checkBoxTray.Checked;
            Properties.Settings.Default.ExclusiveKeys = checkBoxExclBinds.Checked;
            Properties.Settings.Default.CleanupFilenames = checkBoxCleanup.Checked;
            try
            {
                Properties.Settings.Default.TickInterval = int.Parse(textBoxTick.Text);
            }
            catch (Exception ex)
            {
                // Do nothing...
            }

            // Save settings
            Properties.Settings.Default.Save();

            // Close
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // Install voice script in hl mod
        private void button2_Click(object sender, EventArgs e)
        {
            // Script data
            string ScriptData =
            "// Half-Life Sound Selector Script\n" +
            "//\n" +
            "// Script by Solid Snake 88 & Disk2\n\n" +

            "alias +PlayWAV \"voice_inputfromfile 1; voice_loopback 1; +voicerecord\"\n" +
            "alias -PlayWAV \"voice_inputfromfile 0; voice_loopback 0; -voicerecord\"\n\n" +

            "alias StartWAV \"voice_inputfromfile 1; voice_loopback 1; +voicerecord; alias ToggleWAV StopWAV\"\n" +
            "alias StopWAV  \"voice_inputfromfile 0; voice_loopback 0; -voicerecord; alias ToggleWAV StartWAV\"\n\n" +

            "alias ToggleWAV \"StartWAV\"\n\n" +

            "echo \"Hold down INSERT to play a WAV.\"\n" +
            "echo \"Press DELETE to toggle the WAV On/Off.\"";
            string path = textBoxPath.Text + "/autoexec.cfg";

            try
            {
                // Backup old autoexec
                if (File.Exists(path))
                    File.Copy(path, path + ".bak", true);

                // Write file
                StreamWriter writer = new StreamWriter(File.Create(path));
                writer.Write(ScriptData);
                writer.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error while writing autoexec.cfg");
            }
        }
    }
}
