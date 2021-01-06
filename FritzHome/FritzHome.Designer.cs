namespace FritzHome
{
    partial class FritzHome
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FritzHome));
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.TrayIcons = new System.Windows.Forms.ImageList(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FritzboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageDEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SmartDeviceTreeView = new System.Windows.Forms.TreeView();
            this.SmartDeviceTabContainer = new System.Windows.Forms.TabControl();
            this.SmartDeviceTab = new System.Windows.Forms.TabPage();
            this.ReloadTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SmartDeviceTabContainer.SuspendLayout();
            this.SuspendLayout();
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
            this.Icons.Images.SetKeyName(11, "7490.png");
            this.Icons.Images.SetKeyName(12, "7590.png");
            // 
            // TrayIcons
            // 
            this.TrayIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TrayIcons.ImageStream")));
            this.TrayIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.TrayIcons.Images.SetKeyName(0, "smarthome_icon.ico");
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FritzboxToolStripMenuItem,
            this.LanguageToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FritzboxToolStripMenuItem
            // 
            this.FritzboxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.QuitToolStripMenuItem});
            this.FritzboxToolStripMenuItem.Name = "FritzboxToolStripMenuItem";
            this.FritzboxToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.FritzboxToolStripMenuItem.Text = "FritzBox";
            this.FritzboxToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.SettingsToolStripMenuItem.Text = "Settings";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.QuitToolStripMenuItem.Text = "Quit";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // LanguageToolStripMenuItem
            // 
            this.LanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageDEToolStripMenuItem,
            this.LanguageENToolStripMenuItem});
            this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            this.LanguageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.LanguageToolStripMenuItem.Text = "Language";
            this.LanguageToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // LanguageDEToolStripMenuItem
            // 
            this.LanguageDEToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LanguageDEToolStripMenuItem.Image")));
            this.LanguageDEToolStripMenuItem.Name = "LanguageDEToolStripMenuItem";
            this.LanguageDEToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.LanguageDEToolStripMenuItem.Text = "German (DE)";
            this.LanguageDEToolStripMenuItem.Click += new System.EventHandler(this.deutschdeToolStripMenuItem_Click);
            // 
            // LanguageENToolStripMenuItem
            // 
            this.LanguageENToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LanguageENToolStripMenuItem.Image")));
            this.LanguageENToolStripMenuItem.Name = "LanguageENToolStripMenuItem";
            this.LanguageENToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.LanguageENToolStripMenuItem.Text = "English (EN)";
            this.LanguageENToolStripMenuItem.Click += new System.EventHandler(this.englischENToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LicenseToolStripMenuItem,
            this.UpdateToolStripMenuItem});
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // LicenseToolStripMenuItem
            // 
            this.LicenseToolStripMenuItem.Name = "LicenseToolStripMenuItem";
            this.LicenseToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.LicenseToolStripMenuItem.Text = "License";
            this.LicenseToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.UpdateToolStripMenuItem.Text = "Update";
            this.UpdateToolStripMenuItem.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SmartDeviceTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SmartDeviceTabContainer);
            this.splitContainer1.Size = new System.Drawing.Size(784, 537);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 5;
            // 
            // SmartDeviceTreeView
            // 
            this.SmartDeviceTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SmartDeviceTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmartDeviceTreeView.ImageIndex = 0;
            this.SmartDeviceTreeView.ImageList = this.Icons;
            this.SmartDeviceTreeView.ItemHeight = 22;
            this.SmartDeviceTreeView.Location = new System.Drawing.Point(0, 0);
            this.SmartDeviceTreeView.Name = "SmartDeviceTreeView";
            this.SmartDeviceTreeView.SelectedImageIndex = 0;
            this.SmartDeviceTreeView.Size = new System.Drawing.Size(261, 537);
            this.SmartDeviceTreeView.TabIndex = 3;
            this.SmartDeviceTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.deviceTree_AfterSelect);
            // 
            // SmartDeviceTabContainer
            // 
            this.SmartDeviceTabContainer.Controls.Add(this.SmartDeviceTab);
            this.SmartDeviceTabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SmartDeviceTabContainer.Location = new System.Drawing.Point(0, 0);
            this.SmartDeviceTabContainer.Name = "SmartDeviceTabContainer";
            this.SmartDeviceTabContainer.SelectedIndex = 0;
            this.SmartDeviceTabContainer.Size = new System.Drawing.Size(519, 537);
            this.SmartDeviceTabContainer.TabIndex = 0;
            // 
            // SmartDeviceTab
            // 
            this.SmartDeviceTab.Location = new System.Drawing.Point(4, 22);
            this.SmartDeviceTab.Name = "SmartDeviceTab";
            this.SmartDeviceTab.Padding = new System.Windows.Forms.Padding(3);
            this.SmartDeviceTab.Size = new System.Drawing.Size(511, 511);
            this.SmartDeviceTab.TabIndex = 0;
            this.SmartDeviceTab.Text = "SmartDeviceTab";
            this.SmartDeviceTab.UseVisualStyleBackColor = true;
            this.SmartDeviceTab.Click += new System.EventHandler(this.SmartDeviceTab_Click);
            // 
            // ReloadTimer
            // 
            this.ReloadTimer.Interval = 60000;
            this.ReloadTimer.Tick += new System.EventHandler(this.ReloadTimer_Tick);
            // 
            // FritzHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FritzHome";
            this.Text = "FritzHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FritzHome_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.FritzHome_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.SmartDeviceTabContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.ImageList TrayIcons;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView SmartDeviceTreeView;
        private System.Windows.Forms.TabControl SmartDeviceTabContainer;
        private System.Windows.Forms.TabPage SmartDeviceTab;
        private System.Windows.Forms.ToolStripMenuItem FritzboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageDEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageENToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.Timer ReloadTimer;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
    }
}

