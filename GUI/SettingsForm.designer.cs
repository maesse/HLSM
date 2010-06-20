namespace HLSM
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxHLPath = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxCleanup = new System.Windows.Forms.CheckBox();
            this.checkBoxExclBinds = new System.Windows.Forms.CheckBox();
            this.checkBoxTray = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTick = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxHLPath.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxHLPath
            // 
            this.groupBoxHLPath.Controls.Add(this.button1);
            this.groupBoxHLPath.Controls.Add(this.textBoxPath);
            this.groupBoxHLPath.Location = new System.Drawing.Point(12, 12);
            this.groupBoxHLPath.Name = "groupBoxHLPath";
            this.groupBoxHLPath.Size = new System.Drawing.Size(424, 55);
            this.groupBoxHLPath.TabIndex = 0;
            this.groupBoxHLPath.TabStop = false;
            this.groupBoxHLPath.Text = "Half-Life Folder Path";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select Folder...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Location = new System.Drawing.Point(6, 19);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(308, 20);
            this.textBoxPath.TabIndex = 0;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.textBoxTick);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.checkBoxCleanup);
            this.groupBoxSettings.Controls.Add(this.checkBoxExclBinds);
            this.groupBoxSettings.Controls.Add(this.checkBoxTray);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 73);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(331, 93);
            this.groupBoxSettings.TabIndex = 1;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // checkBoxCleanup
            // 
            this.checkBoxCleanup.AutoSize = true;
            this.checkBoxCleanup.Location = new System.Drawing.Point(6, 64);
            this.checkBoxCleanup.Name = "checkBoxCleanup";
            this.checkBoxCleanup.Size = new System.Drawing.Size(166, 17);
            this.checkBoxCleanup.TabIndex = 2;
            this.checkBoxCleanup.Text = "Clean up display of filenames*";
            this.checkBoxCleanup.UseVisualStyleBackColor = true;
            // 
            // checkBoxExclBinds
            // 
            this.checkBoxExclBinds.AutoSize = true;
            this.checkBoxExclBinds.Location = new System.Drawing.Point(6, 42);
            this.checkBoxExclBinds.Name = "checkBoxExclBinds";
            this.checkBoxExclBinds.Size = new System.Drawing.Size(99, 17);
            this.checkBoxExclBinds.TabIndex = 1;
            this.checkBoxExclBinds.Text = "Exclusive binds";
            this.checkBoxExclBinds.UseVisualStyleBackColor = true;
            // 
            // checkBoxTray
            // 
            this.checkBoxTray.AutoSize = true;
            this.checkBoxTray.Checked = true;
            this.checkBoxTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTray.Location = new System.Drawing.Point(6, 19);
            this.checkBoxTray.Name = "checkBoxTray";
            this.checkBoxTray.Size = new System.Drawing.Size(98, 17);
            this.checkBoxTray.TabIndex = 0;
            this.checkBoxTray.Text = "Minimize to tray";
            this.checkBoxTray.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(361, 172);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(268, 172);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Install Script";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tick Interval";
            // 
            // textBoxTick
            // 
            this.textBoxTick.Location = new System.Drawing.Point(256, 17);
            this.textBoxTick.Name = "textBoxTick";
            this.textBoxTick.Size = new System.Drawing.Size(69, 20);
            this.textBoxTick.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "* Changed settings may require restart.";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(448, 207);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxHLPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBoxHLPath.ResumeLayout(false);
            this.groupBoxHLPath.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHLPath;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBoxTray;
        private System.Windows.Forms.CheckBox checkBoxExclBinds;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxCleanup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxTick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}