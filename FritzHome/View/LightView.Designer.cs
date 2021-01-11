namespace FritzHome
{
    partial class LightView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightView));
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.BatteryIcons = new System.Windows.Forms.ImageList(this.components);
            this.DeviceIcons = new System.Windows.Forms.ImageList(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.LightColor = new Cyotek.Windows.Forms.ColorWheel();
            this.OffBtn = new System.Windows.Forms.Button();
            this.OnBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
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
            this.pictureBox10.TabIndex = 105;
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
            this.pictureBox9.TabIndex = 104;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox8.Image = global::FritzHome.Properties.Resources.cpu;
            this.pictureBox8.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.InitialImage")));
            this.pictureBox8.Location = new System.Drawing.Point(100, 155);
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
            this.pictureBox7.Location = new System.Drawing.Point(100, 79);
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
            this.pictureBox6.Location = new System.Drawing.Point(100, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 101;
            this.pictureBox6.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(4, 187);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(90, 32);
            this.label9.TabIndex = 100;
            this.label9.Text = "Color";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeviceName
            // 
            this.DeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceName.Location = new System.Drawing.Point(137, 48);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.Size = new System.Drawing.Size(260, 20);
            this.DeviceName.TabIndex = 97;
            // 
            // LabelName
            // 
            this.LabelName.Location = new System.Drawing.Point(4, 41);
            this.LabelName.Name = "LabelName";
            this.LabelName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelName.Size = new System.Drawing.Size(90, 32);
            this.LabelName.TabIndex = 96;
            this.LabelName.Text = "Name";
            this.LabelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Firmware
            // 
            this.Firmware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Firmware.Location = new System.Drawing.Point(137, 162);
            this.Firmware.Name = "Firmware";
            this.Firmware.ReadOnly = true;
            this.Firmware.Size = new System.Drawing.Size(260, 20);
            this.Firmware.TabIndex = 95;
            // 
            // Manufacturer
            // 
            this.Manufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manufacturer.Location = new System.Drawing.Point(137, 124);
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            this.Manufacturer.Size = new System.Drawing.Size(260, 20);
            this.Manufacturer.TabIndex = 94;
            // 
            // Identifier
            // 
            this.Identifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Identifier.Location = new System.Drawing.Point(137, 86);
            this.Identifier.Name = "Identifier";
            this.Identifier.ReadOnly = true;
            this.Identifier.Size = new System.Drawing.Size(260, 20);
            this.Identifier.TabIndex = 93;
            // 
            // Modell
            // 
            this.Modell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Modell.Location = new System.Drawing.Point(137, 10);
            this.Modell.Name = "Modell";
            this.Modell.ReadOnly = true;
            this.Modell.Size = new System.Drawing.Size(260, 20);
            this.Modell.TabIndex = 92;
            // 
            // LabelFirmware
            // 
            this.LabelFirmware.Location = new System.Drawing.Point(4, 155);
            this.LabelFirmware.Name = "LabelFirmware";
            this.LabelFirmware.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelFirmware.Size = new System.Drawing.Size(90, 32);
            this.LabelFirmware.TabIndex = 91;
            this.LabelFirmware.Text = "Firmware";
            this.LabelFirmware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelManufacturer
            // 
            this.LabelManufacturer.Location = new System.Drawing.Point(4, 117);
            this.LabelManufacturer.Name = "LabelManufacturer";
            this.LabelManufacturer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelManufacturer.Size = new System.Drawing.Size(90, 32);
            this.LabelManufacturer.TabIndex = 90;
            this.LabelManufacturer.Text = "OEM";
            this.LabelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelIdentifier
            // 
            this.LabelIdentifier.Location = new System.Drawing.Point(4, 79);
            this.LabelIdentifier.Name = "LabelIdentifier";
            this.LabelIdentifier.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelIdentifier.Size = new System.Drawing.Size(90, 32);
            this.LabelIdentifier.TabIndex = 89;
            this.LabelIdentifier.Text = "Identifier";
            this.LabelIdentifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelModel
            // 
            this.LabelModel.Location = new System.Drawing.Point(4, 3);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelModel.Size = new System.Drawing.Size(90, 32);
            this.LabelModel.TabIndex = 88;
            this.LabelModel.Text = "Modell";
            this.LabelModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.DeviceIcons.Images.SetKeyName(0, "DECT500.png");
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 5000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // LightColor
            // 
            this.LightColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LightColor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.LightColor.Location = new System.Drawing.Point(137, 188);
            this.LightColor.Name = "LightColor";
            this.LightColor.Size = new System.Drawing.Size(196, 196);
            this.LightColor.TabIndex = 107;
            this.LightColor.ColorChanged += new System.EventHandler(this.colorWheel1_ColorChanged);
            // 
            // OffBtn
            // 
            this.OffBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OffBtn.Enabled = false;
            this.OffBtn.Location = new System.Drawing.Point(257, 390);
            this.OffBtn.Name = "OffBtn";
            this.OffBtn.Size = new System.Drawing.Size(76, 23);
            this.OffBtn.TabIndex = 109;
            this.OffBtn.Text = "Off";
            this.OffBtn.UseVisualStyleBackColor = true;
            this.OffBtn.Click += new System.EventHandler(this.OffBtn_Click);
            // 
            // OnBtn
            // 
            this.OnBtn.Enabled = false;
            this.OnBtn.Location = new System.Drawing.Point(137, 390);
            this.OnBtn.Name = "OnBtn";
            this.OnBtn.Size = new System.Drawing.Size(76, 23);
            this.OnBtn.TabIndex = 108;
            this.OnBtn.Text = "On";
            this.OnBtn.UseVisualStyleBackColor = true;
            this.OnBtn.Click += new System.EventHandler(this.OnBtn_Click);
            // 
            // LightView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.OffBtn);
            this.Controls.Add(this.OnBtn);
            this.Controls.Add(this.LightColor);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label9);
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
            this.DoubleBuffered = true;
            this.Name = "LightView";
            this.Size = new System.Drawing.Size(400, 450);
            this.Load += new System.EventHandler(this.LightView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.ImageList BatteryIcons;
        private System.Windows.Forms.ImageList DeviceIcons;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private Cyotek.Windows.Forms.ColorWheel LightColor;
        private System.Windows.Forms.Button OffBtn;
        private System.Windows.Forms.Button OnBtn;
    }
}
