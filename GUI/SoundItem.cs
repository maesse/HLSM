using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace HLSM
{
    public partial class SoundItem : UserControl
    {
        public Sound sound;
        public SoundItem(Sound sound)
        {
            InitializeComponent();
            this.sound = sound;
            SetFields();
            if (!Hook.GetForm().CheckWave(sound.Filename))
            {
                // Show warning
                toolTip1.SetToolTip(pictureBoxWarning, "Invalid Wav format");
                pictureBoxWarning.Visible = true;
            }
            else
            {
                toolTip1.RemoveAll();
                pictureBoxWarning.Visible = false;
            }
        }

        // Updateui
        void SetFields()
        {
            labelBind.Text = sound.BindToString();

            if (Properties.Settings.Default.CleanupFilenames)
                labelFile.Text = System.IO.Path.GetFileName(sound.Filename);
            else 
                labelFile.Text = sound.Filename;
        }

        public void LockChanges(bool value)
        {
            buttonBrowse.Enabled = value;
            buttonRemove.Enabled = value;
            buttonSettings.Enabled = value;
        }

        // Handle resize event
        public void HandleResize(int width)
        {
            this.Width = width;
        }

        // Select file
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = Hook.GetForm().openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // handle browse result
                sound.Filename = Hook.GetForm().openFileDialog1.FileName;
                SetFields();
                Hook.GetForm().GotChanges = true;
            }

            if (!Hook.GetForm().CheckWave(sound.Filename))
            {
                // Show warning
                toolTip1.SetToolTip(pictureBoxWarning, "Invalid Wav format");
                pictureBoxWarning.Visible = true;
            }
            else
            {
                toolTip1.RemoveAll();
                pictureBoxWarning.Visible = false;
            }
        }

        // Set bind
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            BindControl ctl = new BindControl(sound);
            ctl.ShowDialog(this);
            SetFields();
        }

        // remove
        private void button1_Click(object sender, EventArgs e)
        {
            Hook.GetForm().flowLayoutPanel1.Controls.Remove(this);
            Hook.GetForm().GotChanges = true;
        }
    }
}
