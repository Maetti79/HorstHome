namespace HorstHome
{
    partial class FritzboxView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FritzboxView));
            this.LabelModel = new System.Windows.Forms.Label();
            this.LabelManufacturer = new System.Windows.Forms.Label();
            this.LabelAnnex = new System.Windows.Forms.Label();
            this.LabelRevision = new System.Windows.Forms.Label();
            this.LabelFirmware = new System.Windows.Forms.Label();
            this.DeviceName = new System.Windows.Forms.TextBox();
            this.Serial = new System.Windows.Forms.TextBox();
            this.Manufacturer = new System.Windows.Forms.TextBox();
            this.Firmware = new System.Windows.Forms.TextBox();
            this.Annex = new System.Windows.Forms.TextBox();
            this.Revision = new System.Windows.Forms.TextBox();
            this.LabelSerial = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.DeviceIcons = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelModel
            // 
            this.LabelModel.Location = new System.Drawing.Point(4, 3);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelModel.Size = new System.Drawing.Size(90, 32);
            this.LabelModel.TabIndex = 0;
            this.LabelModel.Text = "FritzBox";
            this.LabelModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelManufacturer
            // 
            this.LabelManufacturer.Location = new System.Drawing.Point(4, 41);
            this.LabelManufacturer.Name = "LabelManufacturer";
            this.LabelManufacturer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelManufacturer.Size = new System.Drawing.Size(90, 32);
            this.LabelManufacturer.TabIndex = 2;
            this.LabelManufacturer.Text = "OEM";
            this.LabelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelAnnex
            // 
            this.LabelAnnex.Location = new System.Drawing.Point(4, 193);
            this.LabelAnnex.Name = "LabelAnnex";
            this.LabelAnnex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelAnnex.Size = new System.Drawing.Size(90, 32);
            this.LabelAnnex.TabIndex = 3;
            this.LabelAnnex.Text = "Annex";
            this.LabelAnnex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelRevision
            // 
            this.LabelRevision.Location = new System.Drawing.Point(4, 79);
            this.LabelRevision.Name = "LabelRevision";
            this.LabelRevision.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelRevision.Size = new System.Drawing.Size(90, 32);
            this.LabelRevision.TabIndex = 4;
            this.LabelRevision.Text = "Revision";
            this.LabelRevision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelFirmware
            // 
            this.LabelFirmware.Location = new System.Drawing.Point(4, 117);
            this.LabelFirmware.Name = "LabelFirmware";
            this.LabelFirmware.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelFirmware.Size = new System.Drawing.Size(90, 32);
            this.LabelFirmware.TabIndex = 5;
            this.LabelFirmware.Text = "Firmware";
            this.LabelFirmware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeviceName
            // 
            this.DeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceName.Location = new System.Drawing.Point(137, 10);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.Size = new System.Drawing.Size(260, 20);
            this.DeviceName.TabIndex = 6;
            // 
            // Serial
            // 
            this.Serial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Serial.Location = new System.Drawing.Point(137, 162);
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            this.Serial.Size = new System.Drawing.Size(260, 20);
            this.Serial.TabIndex = 7;
            this.Serial.TextChanged += new System.EventHandler(this.Serial_TextChanged);
            // 
            // Manufacturer
            // 
            this.Manufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manufacturer.Location = new System.Drawing.Point(138, 48);
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            this.Manufacturer.Size = new System.Drawing.Size(260, 20);
            this.Manufacturer.TabIndex = 8;
            // 
            // Firmware
            // 
            this.Firmware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Firmware.Location = new System.Drawing.Point(137, 124);
            this.Firmware.Name = "Firmware";
            this.Firmware.ReadOnly = true;
            this.Firmware.Size = new System.Drawing.Size(260, 20);
            this.Firmware.TabIndex = 9;
            // 
            // Annex
            // 
            this.Annex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Annex.Location = new System.Drawing.Point(137, 200);
            this.Annex.Name = "Annex";
            this.Annex.ReadOnly = true;
            this.Annex.Size = new System.Drawing.Size(260, 20);
            this.Annex.TabIndex = 10;
            // 
            // Revision
            // 
            this.Revision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Revision.Location = new System.Drawing.Point(137, 86);
            this.Revision.Name = "Revision";
            this.Revision.ReadOnly = true;
            this.Revision.Size = new System.Drawing.Size(260, 20);
            this.Revision.TabIndex = 11;
            // 
            // LabelSerial
            // 
            this.LabelSerial.Location = new System.Drawing.Point(4, 155);
            this.LabelSerial.Name = "LabelSerial";
            this.LabelSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelSerial.Size = new System.Drawing.Size(90, 32);
            this.LabelSerial.TabIndex = 1;
            this.LabelSerial.Text = "Serial";
            this.LabelSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(100, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(100, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(100, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(100, 155);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::HorstHome.Properties.Resources.cpu;
            this.pictureBox5.Location = new System.Drawing.Point(100, 117);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(100, 193);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            // 
            // DeviceIcons
            // 
            this.DeviceIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DeviceIcons.ImageStream")));
            this.DeviceIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.DeviceIcons.Images.SetKeyName(0, "7490.png");
            this.DeviceIcons.Images.SetKeyName(1, "7590.png");
            // 
            // FritzboxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Revision);
            this.Controls.Add(this.Annex);
            this.Controls.Add(this.Firmware);
            this.Controls.Add(this.Manufacturer);
            this.Controls.Add(this.Serial);
            this.Controls.Add(this.DeviceName);
            this.Controls.Add(this.LabelFirmware);
            this.Controls.Add(this.LabelRevision);
            this.Controls.Add(this.LabelAnnex);
            this.Controls.Add(this.LabelManufacturer);
            this.Controls.Add(this.LabelSerial);
            this.Controls.Add(this.LabelModel);
            this.DoubleBuffered = true;
            this.Name = "FritzboxView";
            this.Size = new System.Drawing.Size(400, 450);
            this.Load += new System.EventHandler(this.FritzboxView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelModel;
        private System.Windows.Forms.Label LabelManufacturer;
        private System.Windows.Forms.Label LabelAnnex;
        private System.Windows.Forms.Label LabelRevision;
        private System.Windows.Forms.Label LabelFirmware;
        private System.Windows.Forms.TextBox DeviceName;
        private System.Windows.Forms.TextBox Serial;
        private System.Windows.Forms.TextBox Manufacturer;
        private System.Windows.Forms.TextBox Firmware;
        private System.Windows.Forms.TextBox Annex;
        private System.Windows.Forms.TextBox Revision;
        private System.Windows.Forms.Label LabelSerial;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ImageList DeviceIcons;
    }
}
