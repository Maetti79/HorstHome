namespace FritzHome
{
    partial class LicenseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseForm));
            this.LicenseBox = new System.Windows.Forms.ListView();
            this.licenseIcons = new System.Windows.Forms.ImageList(this.components);
            this.LabelKey = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.ReloadBtn = new System.Windows.Forms.Button();
            this.EulaRtf = new System.Windows.Forms.RichTextBox();
            this.LabelExpires = new System.Windows.Forms.Label();
            this.LabelType = new System.Windows.Forms.Label();
            this.DonateBtn = new System.Windows.Forms.Button();
            this.LabelBuild = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LicenseBox
            // 
            this.LicenseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LicenseBox.HideSelection = false;
            this.LicenseBox.Location = new System.Drawing.Point(12, 54);
            this.LicenseBox.Name = "LicenseBox";
            this.LicenseBox.Size = new System.Drawing.Size(192, 469);
            this.LicenseBox.SmallImageList = this.licenseIcons;
            this.LicenseBox.TabIndex = 12;
            this.LicenseBox.UseCompatibleStateImageBehavior = false;
            this.LicenseBox.View = System.Windows.Forms.View.List;
            // 
            // licenseIcons
            // 
            this.licenseIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("licenseIcons.ImageStream")));
            this.licenseIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.licenseIcons.Images.SetKeyName(0, "cross.png");
            this.licenseIcons.Images.SetKeyName(1, "accept.png");
            // 
            // LabelKey
            // 
            this.LabelKey.AutoSize = true;
            this.LabelKey.Location = new System.Drawing.Point(12, 9);
            this.LabelKey.Name = "LabelKey";
            this.LabelKey.Size = new System.Drawing.Size(192, 13);
            this.LabelKey.TabIndex = 11;
            this.LabelKey.Text = "License Key: ####-####-####-####";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(700, 526);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(72, 23);
            this.CloseBtn.TabIndex = 10;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReloadBtn.Location = new System.Drawing.Point(12, 529);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(75, 23);
            this.ReloadBtn.TabIndex = 9;
            this.ReloadBtn.Text = "Reload";
            this.ReloadBtn.UseVisualStyleBackColor = true;
            this.ReloadBtn.Click += new System.EventHandler(this.OkBtn_Click_1);
            // 
            // EulaRtf
            // 
            this.EulaRtf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EulaRtf.Location = new System.Drawing.Point(210, 54);
            this.EulaRtf.Name = "EulaRtf";
            this.EulaRtf.Size = new System.Drawing.Size(562, 469);
            this.EulaRtf.TabIndex = 16;
            this.EulaRtf.Text = "";
            this.EulaRtf.TextChanged += new System.EventHandler(this.EulaRtf_TextChanged);
            // 
            // LabelExpires
            // 
            this.LabelExpires.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelExpires.AutoSize = true;
            this.LabelExpires.Location = new System.Drawing.Point(674, 9);
            this.LabelExpires.Name = "LabelExpires";
            this.LabelExpires.Size = new System.Drawing.Size(101, 13);
            this.LabelExpires.TabIndex = 15;
            this.LabelExpires.Text = "Expires: 2020-12-31";
            this.LabelExpires.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelType
            // 
            this.LabelType.AutoSize = true;
            this.LabelType.Location = new System.Drawing.Point(12, 30);
            this.LabelType.Name = "LabelType";
            this.LabelType.Size = new System.Drawing.Size(61, 13);
            this.LabelType.TabIndex = 14;
            this.LabelType.Text = "Type: GNU";
            // 
            // DonateBtn
            // 
            this.DonateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DonateBtn.Location = new System.Drawing.Point(697, 25);
            this.DonateBtn.Name = "DonateBtn";
            this.DonateBtn.Size = new System.Drawing.Size(75, 23);
            this.DonateBtn.TabIndex = 13;
            this.DonateBtn.Text = "Donate";
            this.DonateBtn.UseVisualStyleBackColor = true;
            this.DonateBtn.Click += new System.EventHandler(this.donateBtn_Click_1);
            // 
            // LabelBuild
            // 
            this.LabelBuild.AutoSize = true;
            this.LabelBuild.Location = new System.Drawing.Point(207, 9);
            this.LabelBuild.Name = "LabelBuild";
            this.LabelBuild.Size = new System.Drawing.Size(48, 13);
            this.LabelBuild.TabIndex = 17;
            this.LabelBuild.Text = "Version: ";
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.LabelBuild);
            this.Controls.Add(this.LicenseBox);
            this.Controls.Add(this.LabelKey);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.ReloadBtn);
            this.Controls.Add(this.EulaRtf);
            this.Controls.Add(this.LabelExpires);
            this.Controls.Add(this.LabelType);
            this.Controls.Add(this.DonateBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LicenseForm";
            this.Text = "License Information";
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LicenseBox;
        private System.Windows.Forms.ImageList licenseIcons;
        private System.Windows.Forms.Label LabelKey;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button ReloadBtn;
        private System.Windows.Forms.RichTextBox EulaRtf;
        private System.Windows.Forms.Label LabelExpires;
        private System.Windows.Forms.Label LabelType;
        private System.Windows.Forms.Button DonateBtn;
        private System.Windows.Forms.Label LabelBuild;
    }
}