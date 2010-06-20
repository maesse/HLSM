namespace HLSM
{
    partial class SoundItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundItem));
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelBind = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.pictureBoxWarning = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Image = ((System.Drawing.Image)(resources.GetObject("buttonBrowse.Image")));
            this.buttonBrowse.Location = new System.Drawing.Point(315, 3);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(34, 25);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(355, 3);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(30, 25);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.11003F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.88997F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.labelFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelBind, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxWarning, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 30);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFile.Location = new System.Drawing.Point(3, 0);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(208, 30);
            this.labelFile.TabIndex = 1;
            this.labelFile.Text = "N/A";
            this.labelFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBind
            // 
            this.labelBind.AutoSize = true;
            this.labelBind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBind.Location = new System.Drawing.Point(217, 0);
            this.labelBind.Name = "labelBind";
            this.labelBind.Size = new System.Drawing.Size(68, 30);
            this.labelBind.TabIndex = 2;
            this.labelBind.Text = "N/A";
            this.labelBind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.Location = new System.Drawing.Point(391, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(33, 25);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBoxWarning
            // 
            this.pictureBoxWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxWarning.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWarning.Image")));
            this.pictureBoxWarning.Location = new System.Drawing.Point(291, 3);
            this.pictureBoxWarning.Name = "pictureBoxWarning";
            this.pictureBoxWarning.Size = new System.Drawing.Size(15, 24);
            this.pictureBoxWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxWarning.TabIndex = 3;
            this.pictureBoxWarning.TabStop = false;
            this.pictureBoxWarning.Visible = false;
            // 
            // SoundItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonBrowse);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Name = "SoundItem";
            this.Size = new System.Drawing.Size(427, 30);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelBind;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.PictureBox pictureBoxWarning;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
