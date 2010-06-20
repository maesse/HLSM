using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;

namespace HLSM
{
    public partial class BindControl : Form
    {
        Sound sound;
        Timer timer;
        List<Key> KeysDown;
        bool holdKeys = true; // wait for all keys to be release to update fields

        public BindControl(Sound sound)
        {
            InitializeComponent();
            this.sound = sound;
            textBoxBind.Text = sound.BindToString();

            Hook.GetForm().InitKeyboard();
            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            toolTip1.SetToolTip(textBoxBind, "Bind already exists");
            
        }

        // Updates keyboard input
        void timer_Tick(object sender, EventArgs e)
        {
            List<Key> keysDown = Hook.GetForm().PollKeyboard();

            // If 1 key and it's Enter, then press Apply key
            if (keysDown.Count == 1 && keysDown[0] == Key.Return)
                buttonApply_Click(this, null);

            // "Sticky" keys implementation
            if (KeysDown != null && KeysDown.Count > 0 && keysDown.Count > 0 && holdKeys)
            {
                foreach (Key down in KeysDown)
                {
                    bool found = false;
                    foreach (Key newDown in keysDown)
                    {
                        if (down == newDown)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        return;
                }
            }
            else if (keysDown == null || keysDown.Count == 0)
            {
                holdKeys = false;
                return;
            }

            // Make string to show
            string data = "";
            foreach (Key key in keysDown)
            {
                data += key.ToString() + "+";
            }
            
            if (data.Length > 0)
            {   
                // Show in ui
                textBoxBind.Text = data.Substring(0, data.Length - 1);
                KeysDown = keysDown;
                holdKeys = true;
                if (Hook.GetForm().DoesBindExist(keysDown))
                {
                    textBoxBind.BackColor = Color.OrangeRed;

                    toolTip1.Show("Bind already exists", this, textBoxBind.Location.X + textBoxBind.Size.Width, textBoxBind.Location.Y + textBoxBind.Size.Height*2);
                }
                else
                {
                    toolTip1.Hide(this);
                    textBoxBind.BackColor = this.BackColor;
                }
            }
        }

        // Form closing
        private void OnCLose(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            Hook.GetForm().CloseKeyboard();
        }

        // CancelButton
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ApplyButton
        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Update sound
            if(KeysDown != null)
                sound.Bind = KeysDown;
            Hook.GetForm().GotChanges = true;
            this.Close();
        }


    }
}
