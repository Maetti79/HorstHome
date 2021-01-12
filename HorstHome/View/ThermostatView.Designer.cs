namespace HorstHome
{
    partial class ThermostatView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThermostatView));
            this.Firmware = new System.Windows.Forms.TextBox();
            this.Manufacturer = new System.Windows.Forms.TextBox();
            this.Identifier = new System.Windows.Forms.TextBox();
            this.Modell = new System.Windows.Forms.TextBox();
            this.LabelFirmware = new System.Windows.Forms.Label();
            this.LabelManufacturer = new System.Windows.Forms.Label();
            this.LabelIdentifier = new System.Windows.Forms.Label();
            this.LabelModel = new System.Windows.Forms.Label();
            this.LabelName = new System.Windows.Forms.Label();
            this.DeviceName = new System.Windows.Forms.TextBox();
            this.TempLow = new System.Windows.Forms.TextBox();
            this.TempHigh = new System.Windows.Forms.TextBox();
            this.Tempratur = new System.Windows.Forms.TextBox();
            this.TempTarget = new System.Windows.Forms.TextBox();
            this.LabelTemperaturLow = new System.Windows.Forms.Label();
            this.LabelTemperaturComfort = new System.Windows.Forms.Label();
            this.LabelTemperaturTarget = new System.Windows.Forms.Label();
            this.LabelTemperatur = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LabelBattery = new System.Windows.Forms.Label();
            this.BatteryIcons = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.TempratureSetBtn = new System.Windows.Forms.Button();
            this.TempTargetBar = new System.Windows.Forms.TrackBar();
            this.TempLowBar = new System.Windows.Forms.TrackBar();
            this.TempHighBar = new System.Windows.Forms.TrackBar();
            this.DeviceIcons = new System.Windows.Forms.ImageList(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.OffBtn = new System.Windows.Forms.Button();
            this.OnBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempTargetBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempLowBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempHighBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Firmware
            // 
            this.Firmware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Firmware.Location = new System.Drawing.Point(138, 162);
            this.Firmware.Name = "Firmware";
            this.Firmware.ReadOnly = true;
            this.Firmware.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Firmware.Size = new System.Drawing.Size(260, 20);
            this.Firmware.TabIndex = 23;
            this.Firmware.TextChanged += new System.EventHandler(this.Firmware_TextChanged);
            // 
            // Manufacturer
            // 
            this.Manufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manufacturer.Location = new System.Drawing.Point(138, 124);
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            this.Manufacturer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Manufacturer.Size = new System.Drawing.Size(260, 20);
            this.Manufacturer.TabIndex = 22;
            this.Manufacturer.TextChanged += new System.EventHandler(this.Manufacturer_TextChanged);
            // 
            // Identifier
            // 
            this.Identifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Identifier.Location = new System.Drawing.Point(138, 86);
            this.Identifier.Name = "Identifier";
            this.Identifier.ReadOnly = true;
            this.Identifier.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Identifier.Size = new System.Drawing.Size(260, 20);
            this.Identifier.TabIndex = 21;
            this.Identifier.TextChanged += new System.EventHandler(this.Identifier_TextChanged);
            // 
            // Modell
            // 
            this.Modell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Modell.Location = new System.Drawing.Point(138, 10);
            this.Modell.Name = "Modell";
            this.Modell.ReadOnly = true;
            this.Modell.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Modell.Size = new System.Drawing.Size(260, 20);
            this.Modell.TabIndex = 20;
            this.Modell.TextChanged += new System.EventHandler(this.Modell_TextChanged);
            // 
            // LabelFirmware
            // 
            this.LabelFirmware.Location = new System.Drawing.Point(4, 155);
            this.LabelFirmware.Name = "LabelFirmware";
            this.LabelFirmware.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelFirmware.Size = new System.Drawing.Size(90, 32);
            this.LabelFirmware.TabIndex = 19;
            this.LabelFirmware.Text = "Firmware";
            this.LabelFirmware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelFirmware.Click += new System.EventHandler(this.label6_Click);
            // 
            // LabelManufacturer
            // 
            this.LabelManufacturer.Location = new System.Drawing.Point(4, 117);
            this.LabelManufacturer.Name = "LabelManufacturer";
            this.LabelManufacturer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelManufacturer.Size = new System.Drawing.Size(90, 32);
            this.LabelManufacturer.TabIndex = 16;
            this.LabelManufacturer.Text = "OEM";
            this.LabelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelManufacturer.Click += new System.EventHandler(this.label3_Click);
            // 
            // LabelIdentifier
            // 
            this.LabelIdentifier.Location = new System.Drawing.Point(4, 79);
            this.LabelIdentifier.Name = "LabelIdentifier";
            this.LabelIdentifier.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelIdentifier.Size = new System.Drawing.Size(90, 32);
            this.LabelIdentifier.TabIndex = 15;
            this.LabelIdentifier.Text = "Identifier";
            this.LabelIdentifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelIdentifier.Click += new System.EventHandler(this.label2_Click);
            // 
            // LabelModel
            // 
            this.LabelModel.Location = new System.Drawing.Point(4, 3);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelModel.Size = new System.Drawing.Size(90, 32);
            this.LabelModel.TabIndex = 14;
            this.LabelModel.Text = "Modell";
            this.LabelModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelModel.Click += new System.EventHandler(this.label1_Click);
            // 
            // LabelName
            // 
            this.LabelName.Location = new System.Drawing.Point(4, 41);
            this.LabelName.Name = "LabelName";
            this.LabelName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelName.Size = new System.Drawing.Size(90, 32);
            this.LabelName.TabIndex = 24;
            this.LabelName.Text = "Name";
            this.LabelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelName.Click += new System.EventHandler(this.label4_Click);
            // 
            // DeviceName
            // 
            this.DeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceName.Location = new System.Drawing.Point(138, 48);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DeviceName.Size = new System.Drawing.Size(260, 20);
            this.DeviceName.TabIndex = 25;
            this.DeviceName.TextChanged += new System.EventHandler(this.DeviceName_TextChanged);
            // 
            // TempLow
            // 
            this.TempLow.Location = new System.Drawing.Point(138, 276);
            this.TempLow.Name = "TempLow";
            this.TempLow.ReadOnly = true;
            this.TempLow.Size = new System.Drawing.Size(46, 20);
            this.TempLow.TabIndex = 29;
            this.TempLow.TextChanged += new System.EventHandler(this.TempLow_TextChanged);
            // 
            // TempHigh
            // 
            this.TempHigh.Location = new System.Drawing.Point(138, 313);
            this.TempHigh.Name = "TempHigh";
            this.TempHigh.ReadOnly = true;
            this.TempHigh.Size = new System.Drawing.Size(46, 20);
            this.TempHigh.TabIndex = 30;
            this.TempHigh.TextChanged += new System.EventHandler(this.TempHigh_TextChanged);
            // 
            // Tempratur
            // 
            this.Tempratur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tempratur.Location = new System.Drawing.Point(138, 238);
            this.Tempratur.Name = "Tempratur";
            this.Tempratur.ReadOnly = true;
            this.Tempratur.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tempratur.Size = new System.Drawing.Size(260, 20);
            this.Tempratur.TabIndex = 33;
            this.Tempratur.TextChanged += new System.EventHandler(this.Tempratur_TextChanged);
            // 
            // TempTarget
            // 
            this.TempTarget.Location = new System.Drawing.Point(138, 351);
            this.TempTarget.Name = "TempTarget";
            this.TempTarget.ReadOnly = true;
            this.TempTarget.Size = new System.Drawing.Size(46, 20);
            this.TempTarget.TabIndex = 35;
            this.TempTarget.TextChanged += new System.EventHandler(this.TempTarget_TextChanged);
            // 
            // LabelTemperaturLow
            // 
            this.LabelTemperaturLow.Location = new System.Drawing.Point(4, 269);
            this.LabelTemperaturLow.Name = "LabelTemperaturLow";
            this.LabelTemperaturLow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelTemperaturLow.Size = new System.Drawing.Size(90, 32);
            this.LabelTemperaturLow.TabIndex = 37;
            this.LabelTemperaturLow.Text = "Low";
            this.LabelTemperaturLow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTemperaturLow.Click += new System.EventHandler(this.label5_Click);
            // 
            // LabelTemperaturComfort
            // 
            this.LabelTemperaturComfort.Location = new System.Drawing.Point(4, 306);
            this.LabelTemperaturComfort.Name = "LabelTemperaturComfort";
            this.LabelTemperaturComfort.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelTemperaturComfort.Size = new System.Drawing.Size(90, 32);
            this.LabelTemperaturComfort.TabIndex = 38;
            this.LabelTemperaturComfort.Text = "Comfort";
            this.LabelTemperaturComfort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTemperaturComfort.Click += new System.EventHandler(this.label7_Click);
            // 
            // LabelTemperaturTarget
            // 
            this.LabelTemperaturTarget.Location = new System.Drawing.Point(4, 344);
            this.LabelTemperaturTarget.Name = "LabelTemperaturTarget";
            this.LabelTemperaturTarget.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelTemperaturTarget.Size = new System.Drawing.Size(90, 32);
            this.LabelTemperaturTarget.TabIndex = 39;
            this.LabelTemperaturTarget.Text = "Target";
            this.LabelTemperaturTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTemperaturTarget.Click += new System.EventHandler(this.label8_Click);
            // 
            // LabelTemperatur
            // 
            this.LabelTemperatur.Location = new System.Drawing.Point(4, 231);
            this.LabelTemperatur.Name = "LabelTemperatur";
            this.LabelTemperatur.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelTemperatur.Size = new System.Drawing.Size(90, 32);
            this.LabelTemperatur.TabIndex = 40;
            this.LabelTemperatur.Text = "Tempratur";
            this.LabelTemperatur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTemperatur.Click += new System.EventHandler(this.label9_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(138, 201);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(259, 20);
            this.progressBar1.TabIndex = 41;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // LabelBattery
            // 
            this.LabelBattery.Location = new System.Drawing.Point(4, 193);
            this.LabelBattery.Name = "LabelBattery";
            this.LabelBattery.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelBattery.Size = new System.Drawing.Size(90, 32);
            this.LabelBattery.TabIndex = 42;
            this.LabelBattery.Text = "Battery";
            this.LabelBattery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelBattery.Click += new System.EventHandler(this.label10_Click);
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
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(100, 193);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 43;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.InitialImage")));
            this.pictureBox4.Location = new System.Drawing.Point(100, 231);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 36;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.InitialImage")));
            this.pictureBox3.Location = new System.Drawing.Point(100, 344);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(100, 306);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(100, 269);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.InitialImage")));
            this.pictureBox6.Location = new System.Drawing.Point(100, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 44;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.InitialImage")));
            this.pictureBox7.Location = new System.Drawing.Point(100, 79);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 45;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox8.Image = global::HorstHome.Properties.Resources.cpu;
            this.pictureBox8.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.InitialImage")));
            this.pictureBox8.Location = new System.Drawing.Point(100, 155);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 46;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox9.InitialImage")));
            this.pictureBox9.Location = new System.Drawing.Point(100, 117);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(32, 32);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 47;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox10.InitialImage")));
            this.pictureBox10.Location = new System.Drawing.Point(100, 41);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(32, 32);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 48;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Click += new System.EventHandler(this.pictureBox10_Click);
            // 
            // TempratureSetBtn
            // 
            this.TempratureSetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TempratureSetBtn.Image = ((System.Drawing.Image)(resources.GetObject("TempratureSetBtn.Image")));
            this.TempratureSetBtn.Location = new System.Drawing.Point(138, 377);
            this.TempratureSetBtn.Name = "TempratureSetBtn";
            this.TempratureSetBtn.Size = new System.Drawing.Size(260, 36);
            this.TempratureSetBtn.TabIndex = 49;
            this.TempratureSetBtn.UseVisualStyleBackColor = true;
            this.TempratureSetBtn.Click += new System.EventHandler(this.TempratureSetBtn_Click);
            // 
            // TempTargetBar
            // 
            this.TempTargetBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TempTargetBar.Location = new System.Drawing.Point(190, 347);
            this.TempTargetBar.Maximum = 28;
            this.TempTargetBar.Minimum = 8;
            this.TempTargetBar.Name = "TempTargetBar";
            this.TempTargetBar.Size = new System.Drawing.Size(208, 45);
            this.TempTargetBar.TabIndex = 50;
            this.TempTargetBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TempTargetBar.Value = 18;
            this.TempTargetBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // TempLowBar
            // 
            this.TempLowBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TempLowBar.Location = new System.Drawing.Point(190, 272);
            this.TempLowBar.Maximum = 28;
            this.TempLowBar.Minimum = 8;
            this.TempLowBar.Name = "TempLowBar";
            this.TempLowBar.Size = new System.Drawing.Size(208, 45);
            this.TempLowBar.TabIndex = 51;
            this.TempLowBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TempLowBar.Value = 18;
            this.TempLowBar.Scroll += new System.EventHandler(this.TempLowBar_Scroll);
            // 
            // TempHighBar
            // 
            this.TempHighBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TempHighBar.Location = new System.Drawing.Point(190, 309);
            this.TempHighBar.Maximum = 28;
            this.TempHighBar.Minimum = 8;
            this.TempHighBar.Name = "TempHighBar";
            this.TempHighBar.Size = new System.Drawing.Size(208, 45);
            this.TempHighBar.TabIndex = 52;
            this.TempHighBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TempHighBar.Value = 18;
            this.TempHighBar.Scroll += new System.EventHandler(this.TempHighBar_Scroll);
            // 
            // DeviceIcons
            // 
            this.DeviceIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DeviceIcons.ImageStream")));
            this.DeviceIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.DeviceIcons.Images.SetKeyName(0, "DECT300.png");
            this.DeviceIcons.Images.SetKeyName(1, "DECT301.png");
            this.DeviceIcons.Images.SetKeyName(2, "CometDECT.png");
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // OffBtn
            // 
            this.OffBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OffBtn.Enabled = false;
            this.OffBtn.Location = new System.Drawing.Point(341, 419);
            this.OffBtn.Name = "OffBtn";
            this.OffBtn.Size = new System.Drawing.Size(57, 23);
            this.OffBtn.TabIndex = 84;
            this.OffBtn.Text = "Off";
            this.OffBtn.UseVisualStyleBackColor = true;
            this.OffBtn.Click += new System.EventHandler(this.OffBtn_Click);
            // 
            // OnBtn
            // 
            this.OnBtn.Enabled = false;
            this.OnBtn.Location = new System.Drawing.Point(138, 419);
            this.OnBtn.Name = "OnBtn";
            this.OnBtn.Size = new System.Drawing.Size(46, 23);
            this.OnBtn.TabIndex = 83;
            this.OnBtn.Text = "On";
            this.OnBtn.UseVisualStyleBackColor = true;
            this.OnBtn.Click += new System.EventHandler(this.OnBtn_Click);
            // 
            // ThermostatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.OffBtn);
            this.Controls.Add(this.OnBtn);
            this.Controls.Add(this.TempratureSetBtn);
            this.Controls.Add(this.TempTargetBar);
            this.Controls.Add(this.TempHighBar);
            this.Controls.Add(this.TempLowBar);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.LabelBattery);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.LabelTemperatur);
            this.Controls.Add(this.Tempratur);
            this.Controls.Add(this.TempLow);
            this.Controls.Add(this.TempHigh);
            this.Controls.Add(this.LabelTemperaturTarget);
            this.Controls.Add(this.LabelTemperaturComfort);
            this.Controls.Add(this.LabelTemperaturLow);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.TempTarget);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
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
            this.Name = "ThermostatView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(400, 450);
            this.Load += new System.EventHandler(this.ThermostatView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempTargetBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempLowBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempHighBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Firmware;
        private System.Windows.Forms.TextBox Manufacturer;
        private System.Windows.Forms.TextBox Identifier;
        private System.Windows.Forms.TextBox Modell;
        private System.Windows.Forms.Label LabelFirmware;
        private System.Windows.Forms.Label LabelManufacturer;
        private System.Windows.Forms.Label LabelIdentifier;
        private System.Windows.Forms.Label LabelModel;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox DeviceName;
        private System.Windows.Forms.TextBox TempLow;
        private System.Windows.Forms.TextBox TempHigh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Tempratur;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox TempTarget;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label LabelTemperaturLow;
        private System.Windows.Forms.Label LabelTemperaturComfort;
        private System.Windows.Forms.Label LabelTemperaturTarget;
        private System.Windows.Forms.Label LabelTemperatur;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LabelBattery;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ImageList BatteryIcons;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Button TempratureSetBtn;
        private System.Windows.Forms.TrackBar TempTargetBar;
        private System.Windows.Forms.TrackBar TempLowBar;
        private System.Windows.Forms.TrackBar TempHighBar;
        private System.Windows.Forms.ImageList DeviceIcons;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Button OffBtn;
        private System.Windows.Forms.Button OnBtn;
    }
}
