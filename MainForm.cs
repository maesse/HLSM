using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.DirectX.DirectInput;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

namespace HLSM
{
    public partial class MainForm : Form
    {
        Device keyboard;
        bool gotKeyboard = false;

        public bool GotChanges; // Got stuff to save?
        string currentConfig = null; // Current config opened

        Sounds sounds; // List of sounds when HLSM is active
        Sound ActiveSound;
        Timer timer;
        long lastBind;

        public MainForm()
        {
            InitializeComponent();
            Hook.SetForm(this);

            // Load last loaded config
            string config = Properties.Settings.Default.ConfigFile;
            if (config != null && File.Exists(config))
                LoadConfig(config);
        }

        // Start listening, moving files, etc.
        public void Enable()
        {
            // Disable UI
            LockChanged(false);

            if (!Directory.Exists(Properties.Settings.Default.HLPath))
            {
                Disable();
                MessageBox.Show(this, "Path to HL/Mod is invalid. Check your settings", "Invalid HLPath", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gather up sounds
            sounds = new Sounds();
            sounds.SoundList = new List<Sound>();
            foreach (SoundItem item in flowLayoutPanel1.Controls)
            {
                sounds.SoundList.Add(item.sound);
            }

            // Init Keyboard
            InitKeyboard();

            // Start timer for checking keyboard binds
            if(timer == null)
                timer = new Timer();

            timer.Interval = Properties.Settings.Default.TickInterval;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        // Check binds
        void timer_Tick(object sender, EventArgs e)
        {
            if (lastBind != 0)
            {
                float time = (float)(HighResolutionTimer.Ticks-lastBind) / (float)HighResolutionTimer.Frequency * 1000f;
                if (time < 500f) // wait 500ms between accepting binds
                    return;
            }
            
            List<Key> keys = PollKeyboard();
            // Compare all binds against held keys
            bool ExclusiveKeys = Properties.Settings.Default.ExclusiveKeys;
            foreach (Sound sound in sounds.SoundList)
            {
                bool allDown = false;

                if (!ExclusiveKeys)
                {
                    foreach (Key bindKey in sound.Bind)
                    {
                        bool thisDown = false;
                        foreach (Key downKey in keys)
                        {
                            if (downKey == bindKey)
                            {
                                thisDown = true;
                                break;
                            }
                        }

                        if (!thisDown)
                            break;
                        else
                            allDown = true;
                    }
                }
                else
                {
                    int numFound = 0;
                    foreach (Key downKey in keys)
                    {
                        bool thisDown = false;
                        foreach (Key bindKey in sound.Bind)
                        {
                            if (downKey == bindKey)
                            {
                                thisDown = true;
                                numFound++;
                                break;
                            }
                        }

                        if (!thisDown)
                            break;
                        else if(numFound == sound.Bind.Count)
                            allDown = true;
                    }
                }

                // This bind has been activated...
                if (allDown && ActiveSound != sound && File.Exists(sound.Filename))
                {
                    ActiveSound = sound;
                    File.Copy(sound.Filename, Properties.Settings.Default.HLPath + "/" + Properties.Settings.Default.SoundDestName, true);
                    System.Console.WriteLine("Copying " + sound.Filename);
                    lastBind = HighResolutionTimer.Ticks;
                    break;
                }
            }
        }

        // stop listening, moving files, etc.
        public void Disable()
        {
            // Enable UI
            LockChanged(true);
            sounds = null;
            ActiveSound = null;
            if (timer != null)
                timer.Stop();
            CloseKeyboard();
        }

        // Check if wave file haves a good format
        public bool CheckWave(string file)
        {
            if (!File.Exists(file))
                return true;
            BinaryReader reader = new BinaryReader(File.OpenRead(file));

            reader.BaseStream.Seek(22, SeekOrigin.Begin);
            short channels = reader.ReadInt16();
            int sampleRate = reader.ReadInt32();
            reader.BaseStream.Seek(34, SeekOrigin.Begin);
            short bpsample = reader.ReadInt16();
            reader.Close();

            // Needs to be mono, 16bits, 8000hz or 11025hz
            if (channels != 1 || bpsample != 16 || (sampleRate != 8000 && sampleRate != 11025))
            {
                return false;
            }
            return true;
        }

        //
        // Keyboard Stuff
        //

        // Start listening to keyboard
        public void InitKeyboard()
        {
            if (keyboard != null && gotKeyboard)
            {
                CloseKeyboard();
            }
            else if (keyboard == null)
            {
                keyboard = new Device(SystemGuid.Keyboard);
            }

            keyboard.SetCooperativeLevel(this, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
            keyboard.Acquire();
            
            gotKeyboard = true;
        }

        // Get list of keys held down
        public List<Key> PollKeyboard()
        {
            if (!gotKeyboard)
                return null;

            KeyboardState state = keyboard.GetCurrentKeyboardState();
            List<Key> keysDown = new List<Key>();
            foreach (Key key in Enum.GetValues(typeof(Key)))
            {
                if (state[key])
                    keysDown.Add(key);
            }
            return keysDown;
        }

        // Stop listening to keyboard
        public void CloseKeyboard()
        {
            if (keyboard != null && gotKeyboard)
            {
                keyboard.Unacquire();
                gotKeyboard = false;
            }
        }

        public bool DoesBindExist(List<Key> bind)
        {
            if (bind == null)
                return false;

            foreach (SoundItem item in flowLayoutPanel1.Controls)
            {
                if (item.sound.Bind.Count == bind.Count)
                {
                    bool found = false;
                    foreach (Key bindKey in bind)
                    {
                        found = false;
                        foreach (Key bindedKey in item.sound.Bind)
                        {
                            if (bindKey == bindedKey)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            break;
                    }
                    if (found)
                        return true;
                }
            }

            return false;
        }

        
        //
        // Load And Save
        //

        // Save to currentConfig path
        void SaveConfig()
        {
            SaveConfigAs(currentConfig);
        }

        // Save to given path
        void SaveConfigAs(string file)
        {
            // Gather sounds
            List<Sound> sounds = new List<Sound>();
            foreach (SoundItem item in flowLayoutPanel1.Controls)
                sounds.Add(item.sound);

            //Sound[] soundArr = sounds.ToArray();
            Sounds s = new Sounds();
            s.SoundList = sounds;

            // Serialize
            XmlSerializer x = new XmlSerializer(typeof(Sounds));
            FileStream str = File.Create(file);
            StreamWriter w = new StreamWriter(str);
            x.Serialize(w, s);
            w.Dispose();
            str.Dispose();

            // Save config path
            currentConfig = file;
            GotChanges = false;
        }

        // Load from given path
        void LoadConfig(string file)
        {
            if (!File.Exists(file))
            {
                MessageBox.Show(this, "File doesn't exist.", "Error", MessageBoxButtons.OK);
                return;
            }
            Sounds s;
            try
            {
                XmlSerializer x = new XmlSerializer(typeof(Sounds));
                StreamReader r = new StreamReader(File.OpenRead(file));
                s = (Sounds)x.Deserialize(r);
                r.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load config file: " + file + "\n\nException: " + ex.InnerException, "Error while loading config...", MessageBoxButtons.OK);
                return;
            }

            // Add to ui
            flowLayoutPanel1.Controls.Clear();
            foreach (Sound snd in s.SoundList)
            {
                flowLayoutPanel1.Controls.Add(new SoundItem(snd));
            }
            ResizeEvent(this, null);
            currentConfig = file;
            GotChanges = false;
        }

        //
        // Form Stuff
        //

        // Handle saving when form closes
        private void OnClose(object sender, FormClosingEventArgs e)
        {
            // Save old changes
            if (GotChanges)
            {
                DialogResult result = MessageBox.Show(this, "Your config has changed. Do you want to save before exiting?", "Save config?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (currentConfig == null)
                    {
                        // Let user select a path
                        DialogResult res = saveFileDialog1.ShowDialog(this);
                        if (res == DialogResult.OK)
                        {
                            SaveConfigAs(saveFileDialog1.FileName);
                        }
                        else
                            e.Cancel = true;
                    } else
                        SaveConfig();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            Properties.Settings.Default.ConfigFile = currentConfig;
            Properties.Settings.Default.Save();
        }

        // Resize UI element to fit width
        void ResizeSoundItem(SoundItem item)
        {
            int style = GetWindowLong(flowLayoutPanel1.Handle, GWL_STYLE);
            bool hasVScroll = ((style & WS_VSCROLL) != 0);
            item.HandleResize(flowLayoutPanel1.Width - 8 - ((hasVScroll) ? SystemInformation.VerticalScrollBarWidth : 0));
        }

        // Lock off UI when HLSM enabled
        public void LockChanged(bool value)
        {
            // Lock SoundItems
            foreach (SoundItem item in flowLayoutPanel1.Controls)
            {
                item.LockChanges(value);
            }
            // Lock menus
            toolStripButtonAdd.Enabled = value;
            toolStripButtonOpen.Enabled = value;
            openToolStripMenuItem.Enabled = value;
            settingsToolStripMenuItem.Enabled = value;
            newToolStripMenuItem.Enabled = value;
            toolStripMenuItemAction.Text = (value) ? "Enable HLSM" : "Disable HLSM";
            toolStripButtonStart.Checked = !value;
            this.Text = value ? "HLSM" : "HLSM - Activated";
        }

        // Handle Minimize to tray
        private void FormResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && Properties.Settings.Default.MinimizeToTray)
            {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        // FlowLayout Resize event -> Resize Children
        private void ResizeEvent(object sender, EventArgs e)
        {
            foreach (SoundItem item in flowLayoutPanel1.Controls)
            {
                ResizeSoundItem(item);
            }
        }

        // Scrollbar detection magic
        [DllImport("user32.dll", ExactSpelling = false, CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        private const int GWL_STYLE = -16;
        private const int WS_VSCROLL = 0x00200000;
        private const int WS_HSCROLL = 0x00100000;

        //
        // Menu Bar
        //
        
        // New Config Button
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save old changes
            if (GotChanges)
            {
                DialogResult result = MessageBox.Show(this, "Your config has changed. Do you want to save before creating a new one?", "Save config?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveConfig();
                }
                else if (result == DialogResult.Cancel)
                    return;
                GotChanges = false;
            }

            currentConfig = null;
            flowLayoutPanel1.Controls.Clear();
        }

        // Open Config Button
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save old changes
            if (GotChanges)
            {
                DialogResult result = MessageBox.Show(this, "You have made changes. Do you want to save before continuing?", "Save changes?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveConfig();
                }
                else if (result == DialogResult.Cancel)
                    return;
                GotChanges = false;
            }

            // Load new config
            DialogResult res = openFileDialog2.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                // Try to load file
                LoadConfig(openFileDialog2.FileName);
            }
        }

        // Save Config button
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Already has a file
            if (currentConfig != null && System.IO.File.Exists(currentConfig))
                SaveConfig();
            else
            {
                // Let user select a path
                DialogResult res = saveFileDialog1.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    SaveConfigAs(saveFileDialog1.FileName);
                }
            }
        }

        // Save As Config Button
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Let user select a path
            DialogResult res = saveFileDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                SaveConfigAs(saveFileDialog1.FileName);
            }
        }

        // ExitButton
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        // Open options
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog(this);
        }

        // AboutButton
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog(this);
        }


        //
        // Tool Strip Menu
        //

        // Add Sound button
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            SoundItem sItem = new SoundItem(new Sound("Select a sound file", null));
            flowLayoutPanel1.Controls.Add(sItem);
            ResizeSoundItem(sItem);
            GotChanges = true;
        }

        // Open Config Button
        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        // Save Config Button
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        // Save As Config Button
        private void toolStripButtonSaveAs_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem_Click(sender, e);
        }

        // Start/Stop Button
        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonStart.Checked)
                Disable();
            else
                Enable();
        }

        //
        // Tray Menu
        //

        // Start/Stop Menu Item
        private void toolStripMenuItemAction_Click(object sender, EventArgs e)
        {
            if (toolStripButtonStart.Checked)
                Disable();
            else
                Enable();
        }

        // Exit HLSM button
        private void exitHLSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disable();
            this.Close();
        }

        // Show form when dbl-clicking tray-icon
        private void ShowForm(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void addDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                foreach (string file in files)
                {
                    if (file.EndsWith(".wav"))
                        flowLayoutPanel1.Controls.Add(new SoundItem(new Sound(file, null)));
                }
            }
        }
    }

    // Encapsulate Sound's for Serialization
    public class Sounds
    {
        private List<Sound> sounds;
        public List<Sound> SoundList { get { return sounds; } set { sounds = value; } }
    }

    // Create a static class to access MainForm
    public class Hook
    {
        private static MainForm Form;
        public static MainForm GetForm() { return Form; }
        public static void SetForm(MainForm form) { Form = form; }
    }
}
