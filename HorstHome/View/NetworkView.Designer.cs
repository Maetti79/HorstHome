namespace HorstHome
{
    partial class NetworkView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkView));
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.IP = new System.Windows.Forms.TextBox();
            this.LabelIP = new System.Windows.Forms.Label();
            this.Manufacturer = new System.Windows.Forms.TextBox();
            this.Hostname = new System.Windows.Forms.TextBox();
            this.Mac = new System.Windows.Forms.TextBox();
            this.LabelManufacturer = new System.Windows.Forms.Label();
            this.LabelHostname = new System.Windows.Forms.Label();
            this.LabelMac = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox10.InitialImage")));
            this.pictureBox10.Location = new System.Drawing.Point(100, 41);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(32, 32);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 130;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox9.InitialImage")));
            this.pictureBox9.Location = new System.Drawing.Point(100, 117);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(32, 32);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 129;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.InitialImage")));
            this.pictureBox7.Location = new System.Drawing.Point(100, 79);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 127;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.InitialImage")));
            this.pictureBox6.Location = new System.Drawing.Point(100, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 126;
            this.pictureBox6.TabStop = false;
            // 
            // IP
            // 
            this.IP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IP.Location = new System.Drawing.Point(137, 48);
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Size = new System.Drawing.Size(260, 20);
            this.IP.TabIndex = 125;
            // 
            // LabelIP
            // 
            this.LabelIP.Location = new System.Drawing.Point(4, 41);
            this.LabelIP.Name = "LabelIP";
            this.LabelIP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelIP.Size = new System.Drawing.Size(90, 32);
            this.LabelIP.TabIndex = 124;
            this.LabelIP.Text = "IP Address";
            this.LabelIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Manufacturer
            // 
            this.Manufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manufacturer.Location = new System.Drawing.Point(137, 124);
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            this.Manufacturer.Size = new System.Drawing.Size(260, 20);
            this.Manufacturer.TabIndex = 122;
            // 
            // Hostname
            // 
            this.Hostname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Hostname.Location = new System.Drawing.Point(137, 86);
            this.Hostname.Name = "Hostname";
            this.Hostname.ReadOnly = true;
            this.Hostname.Size = new System.Drawing.Size(260, 20);
            this.Hostname.TabIndex = 121;
            // 
            // Mac
            // 
            this.Mac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Mac.Location = new System.Drawing.Point(137, 10);
            this.Mac.Name = "Mac";
            this.Mac.ReadOnly = true;
            this.Mac.Size = new System.Drawing.Size(260, 20);
            this.Mac.TabIndex = 120;
            // 
            // LabelManufacturer
            // 
            this.LabelManufacturer.Location = new System.Drawing.Point(4, 117);
            this.LabelManufacturer.Name = "LabelManufacturer";
            this.LabelManufacturer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelManufacturer.Size = new System.Drawing.Size(90, 32);
            this.LabelManufacturer.TabIndex = 118;
            this.LabelManufacturer.Text = "OEM";
            this.LabelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelHostname
            // 
            this.LabelHostname.Location = new System.Drawing.Point(4, 79);
            this.LabelHostname.Name = "LabelHostname";
            this.LabelHostname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelHostname.Size = new System.Drawing.Size(90, 32);
            this.LabelHostname.TabIndex = 117;
            this.LabelHostname.Text = "Identifier";
            this.LabelHostname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelMac
            // 
            this.LabelMac.Location = new System.Drawing.Point(4, 3);
            this.LabelMac.Name = "LabelMac";
            this.LabelMac.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelMac.Size = new System.Drawing.Size(90, 32);
            this.LabelMac.TabIndex = 116;
            this.LabelMac.Text = "Mac Address";
            this.LabelMac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 5000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // NetworkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.LabelIP);
            this.Controls.Add(this.Manufacturer);
            this.Controls.Add(this.Hostname);
            this.Controls.Add(this.Mac);
            this.Controls.Add(this.LabelManufacturer);
            this.Controls.Add(this.LabelHostname);
            this.Controls.Add(this.LabelMac);
            this.Name = "NetworkView";
            this.Size = new System.Drawing.Size(400, 450);
            this.Load += new System.EventHandler(this.NetworkView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Label LabelIP;
        private System.Windows.Forms.TextBox Manufacturer;
        private System.Windows.Forms.TextBox Hostname;
        private System.Windows.Forms.TextBox Mac;
        private System.Windows.Forms.Label LabelManufacturer;
        private System.Windows.Forms.Label LabelHostname;
        private System.Windows.Forms.Label LabelMac;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
