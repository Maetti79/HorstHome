namespace HorstHome
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.FritzBoxGroup = new System.Windows.Forms.GroupBox();
            this.LabelConnection = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.errorTxt = new System.Windows.Forms.TextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.UriTxt = new System.Windows.Forms.TextBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.ValidateBtn = new System.Windows.Forms.Button();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.LabelUsername = new System.Windows.Forms.Label();
            this.LabelUri = new System.Windows.Forms.Label();
            this.ConnectIcons = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FritzBoxGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // FritzBoxGroup
            // 
            this.FritzBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FritzBoxGroup.Controls.Add(this.label1);
            this.FritzBoxGroup.Controls.Add(this.NameTxt);
            this.FritzBoxGroup.Controls.Add(this.pictureBox2);
            this.FritzBoxGroup.Controls.Add(this.LabelConnection);
            this.FritzBoxGroup.Controls.Add(this.pictureBox1);
            this.FritzBoxGroup.Controls.Add(this.CancelBtn);
            this.FritzBoxGroup.Controls.Add(this.errorTxt);
            this.FritzBoxGroup.Controls.Add(this.pictureBox8);
            this.FritzBoxGroup.Controls.Add(this.pictureBox7);
            this.FritzBoxGroup.Controls.Add(this.pictureBox9);
            this.FritzBoxGroup.Controls.Add(this.pictureBox10);
            this.FritzBoxGroup.Controls.Add(this.UsernameTxt);
            this.FritzBoxGroup.Controls.Add(this.PasswordTxt);
            this.FritzBoxGroup.Controls.Add(this.UriTxt);
            this.FritzBoxGroup.Controls.Add(this.OkBtn);
            this.FritzBoxGroup.Controls.Add(this.ValidateBtn);
            this.FritzBoxGroup.Controls.Add(this.LabelPassword);
            this.FritzBoxGroup.Controls.Add(this.LabelUsername);
            this.FritzBoxGroup.Controls.Add(this.LabelUri);
            this.FritzBoxGroup.Location = new System.Drawing.Point(12, 12);
            this.FritzBoxGroup.Name = "FritzBoxGroup";
            this.FritzBoxGroup.Size = new System.Drawing.Size(297, 354);
            this.FritzBoxGroup.TabIndex = 0;
            this.FritzBoxGroup.TabStop = false;
            this.FritzBoxGroup.Text = "FritzBox";
            this.FritzBoxGroup.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // LabelConnection
            // 
            this.LabelConnection.AutoSize = true;
            this.LabelConnection.Location = new System.Drawing.Point(36, 134);
            this.LabelConnection.Name = "LabelConnection";
            this.LabelConnection.Size = new System.Drawing.Size(61, 13);
            this.LabelConnection.TabIndex = 55;
            this.LabelConnection.Text = "Connection";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 129);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(211, 315);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // errorTxt
            // 
            this.errorTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorTxt.Location = new System.Drawing.Point(39, 163);
            this.errorTxt.Multiline = true;
            this.errorTxt.Name = "errorTxt";
            this.errorTxt.ReadOnly = true;
            this.errorTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorTxt.Size = new System.Drawing.Size(247, 123);
            this.errorTxt.TabIndex = 52;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(12, 163);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(18, 17);
            this.pictureBox8.TabIndex = 51;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(12, 47);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(18, 16);
            this.pictureBox7.TabIndex = 50;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(12, 103);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(18, 17);
            this.pictureBox9.TabIndex = 49;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(12, 76);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(18, 16);
            this.pictureBox10.TabIndex = 48;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Click += new System.EventHandler(this.pictureBox10_Click);
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Location = new System.Drawing.Point(131, 76);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(155, 20);
            this.UsernameTxt.TabIndex = 2;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(131, 102);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(155, 20);
            this.PasswordTxt.TabIndex = 3;
            this.PasswordTxt.UseSystemPasswordChar = true;
            // 
            // UriTxt
            // 
            this.UriTxt.Location = new System.Drawing.Point(131, 47);
            this.UriTxt.Name = "UriTxt";
            this.UriTxt.Size = new System.Drawing.Size(155, 20);
            this.UriTxt.TabIndex = 1;
            this.UriTxt.Text = "http://fritz.box/";
            this.UriTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkBtn.Location = new System.Drawing.Point(39, 315);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 5;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // ValidateBtn
            // 
            this.ValidateBtn.Location = new System.Drawing.Point(131, 129);
            this.ValidateBtn.Name = "ValidateBtn";
            this.ValidateBtn.Size = new System.Drawing.Size(155, 23);
            this.ValidateBtn.TabIndex = 4;
            this.ValidateBtn.Text = "Validate";
            this.ValidateBtn.UseVisualStyleBackColor = true;
            this.ValidateBtn.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Location = new System.Drawing.Point(36, 106);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(53, 13);
            this.LabelPassword.TabIndex = 2;
            this.LabelPassword.Text = "Password";
            // 
            // LabelUsername
            // 
            this.LabelUsername.AutoSize = true;
            this.LabelUsername.Location = new System.Drawing.Point(36, 79);
            this.LabelUsername.Name = "LabelUsername";
            this.LabelUsername.Size = new System.Drawing.Size(55, 13);
            this.LabelUsername.TabIndex = 1;
            this.LabelUsername.Text = "Username";
            // 
            // LabelUri
            // 
            this.LabelUri.AutoSize = true;
            this.LabelUri.Location = new System.Drawing.Point(36, 50);
            this.LabelUri.Name = "LabelUri";
            this.LabelUri.Size = new System.Drawing.Size(20, 13);
            this.LabelUri.TabIndex = 0;
            this.LabelUri.Text = "Uri";
            // 
            // ConnectIcons
            // 
            this.ConnectIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ConnectIcons.ImageStream")));
            this.ConnectIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ConnectIcons.Images.SetKeyName(0, "connecti.png");
            this.ConnectIcons.Images.SetKeyName(1, "connect.png");
            this.ConnectIcons.Images.SetKeyName(2, "disconnect.png");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 16);
            this.pictureBox2.TabIndex = 56;
            this.pictureBox2.TabStop = false;
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(131, 19);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(155, 20);
            this.NameTxt.TabIndex = 57;
            this.NameTxt.Text = "FritzBox";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Name";
            // 
            // Settings
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(321, 378);
            this.Controls.Add(this.FritzBoxGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.FritzBoxGroup.ResumeLayout(false);
            this.FritzBoxGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FritzBoxGroup;
        private System.Windows.Forms.Label LabelUri;
        private System.Windows.Forms.Label LabelUsername;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.TextBox UriTxt;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button ValidateBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox errorTxt;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList ConnectIcons;
        private System.Windows.Forms.Label LabelConnection;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}