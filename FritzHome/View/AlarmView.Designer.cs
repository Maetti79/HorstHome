namespace FritzHome
{
    partial class AlarmView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmView));
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.DeviceName = new System.Windows.Forms.TextBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.Firmware = new System.Windows.Forms.TextBox();
            this.Manufacturer = new System.Windows.Forms.TextBox();
            this.Identifier = new System.Windows.Forms.TextBox();
            this.Modell = new System.Windows.Forms.TextBox();
            this.LabelFirmware = new System.Windows.Forms.Label();
            this.LabelManufacturer = new System.Windows.Forms.Label();
            this.LabelIdentifier = new System.Windows.Forms.Label();
            this.LabelModel = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.LabelBattery = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BatteryIcons = new System.Windows.Forms.ImageList(this.components);
            this.DeviceIcons = new System.Windows.Forms.ImageList(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox10.InitialImage")));
            this.pictureBox10.Location = new System.Drawing.Point(70, 41);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(32, 32);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 105;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox9.InitialImage")));
            this.pictureBox9.Location = new System.Drawing.Point(70, 117);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(32, 32);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 104;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::FritzHome.Properties.Resources.cpu;
            this.pictureBox8.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.InitialImage")));
            this.pictureBox8.Location = new System.Drawing.Point(70, 155);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 103;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.InitialImage")));
            this.pictureBox7.Location = new System.Drawing.Point(70, 79);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 102;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.InitialImage")));
            this.pictureBox6.Location = new System.Drawing.Point(70, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 101;
            this.pictureBox6.TabStop = false;
            // 
            // DeviceName
            // 
            this.DeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceName.Location = new System.Drawing.Point(108, 46);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.Size = new System.Drawing.Size(290, 20);
            this.DeviceName.TabIndex = 97;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(29, 50);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(35, 13);
            this.LabelName.TabIndex = 96;
            this.LabelName.Text = "Name";
            // 
            // Firmware
            // 
            this.Firmware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Firmware.Location = new System.Drawing.Point(108, 162);
            this.Firmware.Name = "Firmware";
            this.Firmware.ReadOnly = true;
            this.Firmware.Size = new System.Drawing.Size(290, 20);
            this.Firmware.TabIndex = 95;
            // 
            // Manufacturer
            // 
            this.Manufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manufacturer.Location = new System.Drawing.Point(108, 124);
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            this.Manufacturer.Size = new System.Drawing.Size(290, 20);
            this.Manufacturer.TabIndex = 94;
            // 
            // Identifier
            // 
            this.Identifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Identifier.Location = new System.Drawing.Point(108, 86);
            this.Identifier.Name = "Identifier";
            this.Identifier.ReadOnly = true;
            this.Identifier.Size = new System.Drawing.Size(290, 20);
            this.Identifier.TabIndex = 93;
            // 
            // Modell
            // 
            this.Modell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Modell.Location = new System.Drawing.Point(108, 12);
            this.Modell.Name = "Modell";
            this.Modell.ReadOnly = true;
            this.Modell.Size = new System.Drawing.Size(290, 20);
            this.Modell.TabIndex = 92;
            // 
            // LabelFirmware
            // 
            this.LabelFirmware.AutoSize = true;
            this.LabelFirmware.Location = new System.Drawing.Point(15, 164);
            this.LabelFirmware.Name = "LabelFirmware";
            this.LabelFirmware.Size = new System.Drawing.Size(49, 13);
            this.LabelFirmware.TabIndex = 91;
            this.LabelFirmware.Text = "Firmware";
            // 
            // LabelManufacturer
            // 
            this.LabelManufacturer.AutoSize = true;
            this.LabelManufacturer.Location = new System.Drawing.Point(33, 127);
            this.LabelManufacturer.Name = "LabelManufacturer";
            this.LabelManufacturer.Size = new System.Drawing.Size(31, 13);
            this.LabelManufacturer.TabIndex = 90;
            this.LabelManufacturer.Text = "OEM";
            // 
            // LabelIdentifier
            // 
            this.LabelIdentifier.AutoSize = true;
            this.LabelIdentifier.Location = new System.Drawing.Point(17, 88);
            this.LabelIdentifier.Name = "LabelIdentifier";
            this.LabelIdentifier.Size = new System.Drawing.Size(47, 13);
            this.LabelIdentifier.TabIndex = 89;
            this.LabelIdentifier.Text = "Identifier";
            // 
            // LabelModel
            // 
            this.LabelModel.AutoSize = true;
            this.LabelModel.Location = new System.Drawing.Point(26, 13);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.Size = new System.Drawing.Size(38, 13);
            this.LabelModel.TabIndex = 88;
            this.LabelModel.Text = "Modell";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(70, 193);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 115;
            this.pictureBox5.TabStop = false;
            // 
            // LabelBattery
            // 
            this.LabelBattery.AutoSize = true;
            this.LabelBattery.Location = new System.Drawing.Point(24, 202);
            this.LabelBattery.Name = "LabelBattery";
            this.LabelBattery.Size = new System.Drawing.Size(40, 13);
            this.LabelBattery.TabIndex = 114;
            this.LabelBattery.Text = "Battery";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(108, 200);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(289, 20);
            this.progressBar1.TabIndex = 113;
            // 
            // BatteryIcons
            // 
            this.BatteryIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BatteryIcons.ImageStream")));
            this.BatteryIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.BatteryIcons.Images.SetKeyName(0, "battery_0.png");
            this.BatteryIcons.Images.SetKeyName(1, "battery_10.png");
            this.BatteryIcons.Images.SetKeyName(2, "battery_20.png");
            this.BatteryIcons.Images.SetKeyName(3, "battery_30.png");
            this.BatteryIcons.Images.SetKeyName(4, "battery_40.png");
            this.BatteryIcons.Images.SetKeyName(5, "battery_50.png");
            this.BatteryIcons.Images.SetKeyName(6, "battery_60.png");
            this.BatteryIcons.Images.SetKeyName(7, "battery_70.png");
            this.BatteryIcons.Images.SetKeyName(8, "battery_80.png");
            this.BatteryIcons.Images.SetKeyName(9, "battery_90.png");
            this.BatteryIcons.Images.SetKeyName(10, "battery_100.png");
            // 
            // DeviceIcons
            // 
            this.DeviceIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DeviceIcons.ImageStream")));
            this.DeviceIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.DeviceIcons.Images.SetKeyName(0, "Han-Fun-Motion.png");
            this.DeviceIcons.Images.SetKeyName(1, "Han-Fun-Smoke.png");
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 5000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // AlarmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.LabelBattery);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.DeviceName);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.Firmware);
            this.Controls.Add(this.Manufacturer);
            this.Controls.Add(this.Identifier);
            this.Controls.Add(this.Modell);
            this.Controls.Add(this.LabelFirmware);
            this.Controls.Add(this.LabelManufacturer);
            this.Controls.Add(this.LabelIdentifier);
            this.Controls.Add(this.LabelModel);
            this.Name = "AlarmView";
            this.Size = new System.Drawing.Size(400, 450);
            this.Load += new System.EventHandler(this.AlarmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox DeviceName;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox Firmware;
        private System.Windows.Forms.TextBox Manufacturer;
        private System.Windows.Forms.TextBox Identifier;
        private System.Windows.Forms.TextBox Modell;
        private System.Windows.Forms.Label LabelFirmware;
        private System.Windows.Forms.Label LabelManufacturer;
        private System.Windows.Forms.Label LabelIdentifier;
        private System.Windows.Forms.Label LabelModel;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label LabelBattery;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ImageList BatteryIcons;
        private System.Windows.Forms.ImageList DeviceIcons;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
