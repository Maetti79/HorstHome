namespace HorstHome
{
    partial class GroupView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupView));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.Modell = new System.Windows.Forms.TextBox();
            this.LabelModel = new System.Windows.Forms.Label();
            this.BatteryIcons = new System.Windows.Forms.ImageList(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.deviceList = new System.Windows.Forms.ListView();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.OffBtn = new System.Windows.Forms.Button();
            this.OnBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.InitialImage")));
            this.pictureBox6.Location = new System.Drawing.Point(100, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 104;
            this.pictureBox6.TabStop = false;
            // 
            // Modell
            // 
            this.Modell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Modell.Location = new System.Drawing.Point(137, 10);
            this.Modell.Name = "Modell";
            this.Modell.ReadOnly = true;
            this.Modell.Size = new System.Drawing.Size(260, 20);
            this.Modell.TabIndex = 103;
            // 
            // LabelModel
            // 
            this.LabelModel.Location = new System.Drawing.Point(4, 3);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LabelModel.Size = new System.Drawing.Size(90, 32);
            this.LabelModel.TabIndex = 102;
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
            // refreshTimer
            // 
            this.refreshTimer.Interval = 5000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // deviceList
            // 
            this.deviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceList.HideSelection = false;
            this.deviceList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.deviceList.LargeImageList = this.Icons;
            this.deviceList.Location = new System.Drawing.Point(137, 36);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(260, 382);
            this.deviceList.SmallImageList = this.Icons;
            this.deviceList.TabIndex = 105;
            this.deviceList.TileSize = new System.Drawing.Size(32, 32);
            this.deviceList.UseCompatibleStateImageBehavior = false;
            this.deviceList.View = System.Windows.Forms.View.List;
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "DECT100.png");
            this.Icons.Images.SetKeyName(1, "DECT200.png");
            this.Icons.Images.SetKeyName(2, "DECT201.png");
            this.Icons.Images.SetKeyName(3, "DECT300.png");
            this.Icons.Images.SetKeyName(4, "DECT301.png");
            this.Icons.Images.SetKeyName(5, "DECT400.png");
            this.Icons.Images.SetKeyName(6, "DECT440.png");
            this.Icons.Images.SetKeyName(7, "DECT500.png");
            this.Icons.Images.SetKeyName(8, "CometDECT.png");
            this.Icons.Images.SetKeyName(9, "Han-Fun-Motion.png");
            this.Icons.Images.SetKeyName(10, "Han-Fun-Smoke.png");
            this.Icons.Images.SetKeyName(11, "7590.png");
            this.Icons.Images.SetKeyName(12, "7490.png");
            // 
            // OffBtn
            // 
            this.OffBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OffBtn.Enabled = false;
            this.OffBtn.Location = new System.Drawing.Point(340, 424);
            this.OffBtn.Name = "OffBtn";
            this.OffBtn.Size = new System.Drawing.Size(57, 23);
            this.OffBtn.TabIndex = 107;
            this.OffBtn.Text = "Off";
            this.OffBtn.UseVisualStyleBackColor = true;
            // 
            // OnBtn
            // 
            this.OnBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OnBtn.Enabled = false;
            this.OnBtn.Location = new System.Drawing.Point(137, 424);
            this.OnBtn.Name = "OnBtn";
            this.OnBtn.Size = new System.Drawing.Size(46, 23);
            this.OnBtn.TabIndex = 106;
            this.OnBtn.Text = "On";
            this.OnBtn.UseVisualStyleBackColor = true;
            // 
            // GroupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.OffBtn);
            this.Controls.Add(this.OnBtn);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.Modell);
            this.Controls.Add(this.LabelModel);
            this.DoubleBuffered = true;
            this.Name = "GroupView";
            this.Size = new System.Drawing.Size(400, 450);
            this.Load += new System.EventHandler(this.GroupView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox Modell;
        private System.Windows.Forms.Label LabelModel;
        private System.Windows.Forms.ImageList BatteryIcons;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ListView deviceList;
        private System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.Button OffBtn;
        private System.Windows.Forms.Button OnBtn;
    }
}
