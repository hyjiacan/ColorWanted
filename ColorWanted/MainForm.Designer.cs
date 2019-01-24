namespace ColorWanted
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        System.ComponentModel.ComponentResourceManager resources;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbHex = new System.Windows.Forms.Label();
            this.lbRgb = new System.Windows.Forms.Label();
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuDisplayMode = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHideWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFollowCaret = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFixed = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFormatMode = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFormatMini = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFormatStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFormatExtention = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuCopyPolicy = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuCopyPolicyHexValueOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuCopyPolicyRgbValueOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHsiAlgorithm = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHsiAlgorithmGeometry = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHsiAlgorithmAxis = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHsiAlgorithmSegment = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHsiAlgorithmBajon = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHsiAlgorithmStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuShowPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuShowColorPicker = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuPixelScale = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuAutoPin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHotkey = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuRestoreLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuAutoStart = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuOpenConfigFile = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuCheckUpdateOnStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuShowAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lbColorPreview = new System.Windows.Forms.Label();
            this.lbHsl = new System.Windows.Forms.Label();
            this.lbHsb = new System.Windows.Forms.Label();
            this.pnExt = new System.Windows.Forms.Panel();
            this.lbHsi = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.pnExt.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHex
            // 
            resources.ApplyResources(this.lbHex, "lbHex");
            this.lbHex.Name = "lbHex";
            this.tooltip.SetToolTip(this.lbHex, resources.GetString("lbHex.ToolTip"));
            this.lbHex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbRgb
            // 
            resources.ApplyResources(this.lbRgb, "lbRgb");
            this.lbRgb.Name = "lbRgb";
            this.tooltip.SetToolTip(this.lbRgb, resources.GetString("lbRgb.ToolTip"));
            this.lbRgb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // tray
            // 
            resources.ApplyResources(this.tray, "tray");
            this.tray.ContextMenuStrip = this.menu;
            this.tray.Icon = global::ColorWanted.Properties.Resources.ico;
            this.tray.Click += new System.EventHandler(this.tray_Click);
            // 
            // menu
            // 
            resources.ApplyResources(this.menu, "menu");
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuDisplayMode,
            this.trayMenuFormatMode,
            this.trayMenuCopyPolicy,
            this.trayMenuHsiAlgorithm,
            this.toolStripSeparator3,
            this.trayMenuShowPreview,
            this.trayMenuShowColorPicker,
            this.trayMenuPixelScale,
            this.trayMenuAutoPin,
            this.toolStripSeparator2,
            this.trayMenuTheme,
            this.trayMenuHotkey,
            this.trayMenuRestoreLocation,
            this.trayMenuAutoStart,
            this.trayMenuOpenConfigFile,
            this.trayMenuHistory,
            this.toolStripSeparator1,
            this.trayMenuCheckUpdate,
            this.trayMenuRestart,
            this.trayMenuShowAbout,
            this.trayMenuExit});
            this.menu.Name = "trayMenu";
            this.tooltip.SetToolTip(this.menu, resources.GetString("menu.ToolTip"));
            // 
            // trayMenuDisplayMode
            // 
            resources.ApplyResources(this.trayMenuDisplayMode, "trayMenuDisplayMode");
            this.trayMenuDisplayMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuHideWindow,
            this.trayMenuFollowCaret,
            this.trayMenuFixed});
            this.trayMenuDisplayMode.Name = "trayMenuDisplayMode";
            // 
            // trayMenuHideWindow
            // 
            resources.ApplyResources(this.trayMenuHideWindow, "trayMenuHideWindow");
            this.trayMenuHideWindow.Checked = true;
            this.trayMenuHideWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuHideWindow.Name = "trayMenuHideWindow";
            this.trayMenuHideWindow.Click += new System.EventHandler(this.trayMenuHideWindow_Click);
            // 
            // trayMenuFollowCaret
            // 
            resources.ApplyResources(this.trayMenuFollowCaret, "trayMenuFollowCaret");
            this.trayMenuFollowCaret.Name = "trayMenuFollowCaret";
            this.trayMenuFollowCaret.Click += new System.EventHandler(this.trayMenuFollowCaret_Click);
            // 
            // trayMenuFixed
            // 
            resources.ApplyResources(this.trayMenuFixed, "trayMenuFixed");
            this.trayMenuFixed.Name = "trayMenuFixed";
            this.trayMenuFixed.Click += new System.EventHandler(this.trayMenuFixed_Click);
            // 
            // trayMenuFormatMode
            // 
            resources.ApplyResources(this.trayMenuFormatMode, "trayMenuFormatMode");
            this.trayMenuFormatMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuFormatMini,
            this.trayMenuFormatStandard,
            this.trayMenuFormatExtention});
            this.trayMenuFormatMode.Name = "trayMenuFormatMode";
            // 
            // trayMenuFormatMini
            // 
            resources.ApplyResources(this.trayMenuFormatMini, "trayMenuFormatMini");
            this.trayMenuFormatMini.Checked = true;
            this.trayMenuFormatMini.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuFormatMini.Name = "trayMenuFormatMini";
            this.trayMenuFormatMini.Click += new System.EventHandler(this.trayMenuFormatMini_Click);
            // 
            // trayMenuFormatStandard
            // 
            resources.ApplyResources(this.trayMenuFormatStandard, "trayMenuFormatStandard");
            this.trayMenuFormatStandard.Name = "trayMenuFormatStandard";
            this.trayMenuFormatStandard.Click += new System.EventHandler(this.trayMenuFormatStandard_Click);
            // 
            // trayMenuFormatExtention
            // 
            resources.ApplyResources(this.trayMenuFormatExtention, "trayMenuFormatExtention");
            this.trayMenuFormatExtention.Name = "trayMenuFormatExtention";
            this.trayMenuFormatExtention.Click += new System.EventHandler(this.trayMenuFormatExtention_Click);
            // 
            // trayMenuCopyPolicy
            // 
            resources.ApplyResources(this.trayMenuCopyPolicy, "trayMenuCopyPolicy");
            this.trayMenuCopyPolicy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuCopyPolicyHexValueOnly,
            this.trayMenuCopyPolicyRgbValueOnly});
            this.trayMenuCopyPolicy.Name = "trayMenuCopyPolicy";
            // 
            // trayMenuCopyPolicyHexValueOnly
            // 
            resources.ApplyResources(this.trayMenuCopyPolicyHexValueOnly, "trayMenuCopyPolicyHexValueOnly");
            this.trayMenuCopyPolicyHexValueOnly.Name = "trayMenuCopyPolicyHexValueOnly";
            this.trayMenuCopyPolicyHexValueOnly.Click += new System.EventHandler(this.trayMenuCopyPolicyHexValueOnly_Click);
            // 
            // trayMenuCopyPolicyRgbValueOnly
            // 
            resources.ApplyResources(this.trayMenuCopyPolicyRgbValueOnly, "trayMenuCopyPolicyRgbValueOnly");
            this.trayMenuCopyPolicyRgbValueOnly.Name = "trayMenuCopyPolicyRgbValueOnly";
            this.trayMenuCopyPolicyRgbValueOnly.Click += new System.EventHandler(this.trayMenuCopyPolicyRgbValueOnly_Click);
            // 
            // trayMenuHsiAlgorithm
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithm, "trayMenuHsiAlgorithm");
            this.trayMenuHsiAlgorithm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuHsiAlgorithmGeometry,
            this.trayMenuHsiAlgorithmAxis,
            this.trayMenuHsiAlgorithmSegment,
            this.trayMenuHsiAlgorithmBajon,
            this.trayMenuHsiAlgorithmStandard});
            this.trayMenuHsiAlgorithm.Name = "trayMenuHsiAlgorithm";
            // 
            // trayMenuHsiAlgorithmGeometry
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmGeometry, "trayMenuHsiAlgorithmGeometry");
            this.trayMenuHsiAlgorithmGeometry.Name = "trayMenuHsiAlgorithmGeometry";
            this.trayMenuHsiAlgorithmGeometry.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmAxis
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmAxis, "trayMenuHsiAlgorithmAxis");
            this.trayMenuHsiAlgorithmAxis.Name = "trayMenuHsiAlgorithmAxis";
            this.trayMenuHsiAlgorithmAxis.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmSegment
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmSegment, "trayMenuHsiAlgorithmSegment");
            this.trayMenuHsiAlgorithmSegment.Name = "trayMenuHsiAlgorithmSegment";
            this.trayMenuHsiAlgorithmSegment.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmBajon
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmBajon, "trayMenuHsiAlgorithmBajon");
            this.trayMenuHsiAlgorithmBajon.Name = "trayMenuHsiAlgorithmBajon";
            this.trayMenuHsiAlgorithmBajon.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmStandard
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmStandard, "trayMenuHsiAlgorithmStandard");
            this.trayMenuHsiAlgorithmStandard.Checked = true;
            this.trayMenuHsiAlgorithmStandard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuHsiAlgorithmStandard.Name = "trayMenuHsiAlgorithmStandard";
            this.trayMenuHsiAlgorithmStandard.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // trayMenuShowPreview
            // 
            resources.ApplyResources(this.trayMenuShowPreview, "trayMenuShowPreview");
            this.trayMenuShowPreview.Name = "trayMenuShowPreview";
            this.trayMenuShowPreview.Click += new System.EventHandler(this.trayMenuShowPreview_Click);
            // 
            // trayMenuShowColorPicker
            // 
            resources.ApplyResources(this.trayMenuShowColorPicker, "trayMenuShowColorPicker");
            this.trayMenuShowColorPicker.Name = "trayMenuShowColorPicker";
            this.trayMenuShowColorPicker.Click += new System.EventHandler(this.trayMenuShowColorPicker_Click);
            // 
            // trayMenuPixelScale
            // 
            resources.ApplyResources(this.trayMenuPixelScale, "trayMenuPixelScale");
            this.trayMenuPixelScale.Name = "trayMenuPixelScale";
            this.trayMenuPixelScale.Click += new System.EventHandler(this.trayMenuPixelScale_Click);
            // 
            // trayMenuAutoPin
            // 
            resources.ApplyResources(this.trayMenuAutoPin, "trayMenuAutoPin");
            this.trayMenuAutoPin.Checked = true;
            this.trayMenuAutoPin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuAutoPin.Name = "trayMenuAutoPin";
            this.trayMenuAutoPin.Click += new System.EventHandler(this.trayMenuAutoPin_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // trayMenuTheme
            // 
            resources.ApplyResources(this.trayMenuTheme, "trayMenuTheme");
            this.trayMenuTheme.Name = "trayMenuTheme";
            this.trayMenuTheme.Click += new System.EventHandler(this.trayMenuTheme_Click);
            // 
            // trayMenuHotkey
            // 
            resources.ApplyResources(this.trayMenuHotkey, "trayMenuHotkey");
            this.trayMenuHotkey.Name = "trayMenuHotkey";
            this.trayMenuHotkey.Click += new System.EventHandler(this.trayMenuHotkey_Click);
            // 
            // trayMenuRestoreLocation
            // 
            resources.ApplyResources(this.trayMenuRestoreLocation, "trayMenuRestoreLocation");
            this.trayMenuRestoreLocation.Name = "trayMenuRestoreLocation";
            this.trayMenuRestoreLocation.Click += new System.EventHandler(this.trayMenuRestoreLocation_Click);
            // 
            // trayMenuAutoStart
            // 
            resources.ApplyResources(this.trayMenuAutoStart, "trayMenuAutoStart");
            this.trayMenuAutoStart.Name = "trayMenuAutoStart";
            this.trayMenuAutoStart.Click += new System.EventHandler(this.trayMenuAutoStart_Click);
            // 
            // trayMenuOpenConfigFile
            // 
            resources.ApplyResources(this.trayMenuOpenConfigFile, "trayMenuOpenConfigFile");
            this.trayMenuOpenConfigFile.Name = "trayMenuOpenConfigFile";
            this.trayMenuOpenConfigFile.Click += new System.EventHandler(this.trayMenuOpenConfigFile_Click);
            // 
            // trayMenuHistory
            // 
            resources.ApplyResources(this.trayMenuHistory, "trayMenuHistory");
            this.trayMenuHistory.Name = "trayMenuHistory";
            this.trayMenuHistory.Click += new System.EventHandler(this.trayMenuHistory_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // trayMenuCheckUpdate
            // 
            resources.ApplyResources(this.trayMenuCheckUpdate, "trayMenuCheckUpdate");
            this.trayMenuCheckUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuCheckUpdateOnStartup});
            this.trayMenuCheckUpdate.Name = "trayMenuCheckUpdate";
            this.trayMenuCheckUpdate.Click += new System.EventHandler(this.trayMenuCheckUpdate_Click);
            // 
            // trayMenuCheckUpdateOnStartup
            // 
            resources.ApplyResources(this.trayMenuCheckUpdateOnStartup, "trayMenuCheckUpdateOnStartup");
            this.trayMenuCheckUpdateOnStartup.Name = "trayMenuCheckUpdateOnStartup";
            this.trayMenuCheckUpdateOnStartup.Click += new System.EventHandler(this.trayMenuCheckUpdateOnStartup_Click);
            // 
            // trayMenuRestart
            // 
            resources.ApplyResources(this.trayMenuRestart, "trayMenuRestart");
            this.trayMenuRestart.Name = "trayMenuRestart";
            this.trayMenuRestart.Click += new System.EventHandler(this.trayMenuRestart_Click);
            // 
            // trayMenuShowAbout
            // 
            resources.ApplyResources(this.trayMenuShowAbout, "trayMenuShowAbout");
            this.trayMenuShowAbout.Name = "trayMenuShowAbout";
            this.trayMenuShowAbout.Click += new System.EventHandler(this.trayMenuShowHelp_Click);
            // 
            // trayMenuExit
            // 
            resources.ApplyResources(this.trayMenuExit, "trayMenuExit");
            this.trayMenuExit.Name = "trayMenuExit";
            this.trayMenuExit.Click += new System.EventHandler(this.trayMenuExit_Click);
            // 
            // lbColorPreview
            // 
            resources.ApplyResources(this.lbColorPreview, "lbColorPreview");
            this.lbColorPreview.Name = "lbColorPreview";
            this.tooltip.SetToolTip(this.lbColorPreview, resources.GetString("lbColorPreview.ToolTip"));
            // 
            // lbHsl
            // 
            resources.ApplyResources(this.lbHsl, "lbHsl");
            this.lbHsl.Name = "lbHsl";
            this.tooltip.SetToolTip(this.lbHsl, resources.GetString("lbHsl.ToolTip"));
            this.lbHsl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbHsb
            // 
            resources.ApplyResources(this.lbHsb, "lbHsb");
            this.lbHsb.Name = "lbHsb";
            this.tooltip.SetToolTip(this.lbHsb, resources.GetString("lbHsb.ToolTip"));
            this.lbHsb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // pnExt
            // 
            resources.ApplyResources(this.pnExt, "pnExt");
            this.pnExt.Controls.Add(this.lbHsb);
            this.pnExt.Controls.Add(this.lbHsi);
            this.pnExt.Controls.Add(this.lbHsl);
            this.pnExt.Name = "pnExt";
            this.tooltip.SetToolTip(this.pnExt, resources.GetString("pnExt.ToolTip"));
            // 
            // lbHsi
            // 
            resources.ApplyResources(this.lbHsi, "lbHsi");
            this.lbHsi.Name = "lbHsi";
            this.tooltip.SetToolTip(this.lbHsi, resources.GetString("lbHsi.ToolTip"));
            this.lbHsi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ContextMenuStrip = this.menu;
            this.ControlBox = false;
            this.Controls.Add(this.pnExt);
            this.Controls.Add(this.lbHex);
            this.Controls.Add(this.lbRgb);
            this.Controls.Add(this.lbColorPreview);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.tooltip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            this.menu.ResumeLayout(false);
            this.pnExt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbRgb;
        private System.Windows.Forms.Label lbHex;
        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuShowAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem trayMenuExit;
        private System.Windows.Forms.ToolStripMenuItem trayMenuHideWindow;
        private System.Windows.Forms.ToolStripMenuItem trayMenuAutoPin;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.ToolStripMenuItem trayMenuShowPreview;
        private System.Windows.Forms.ToolStripMenuItem trayMenuRestoreLocation;
        private System.Windows.Forms.ToolStripMenuItem trayMenuFollowCaret;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem trayMenuAutoStart;
        private System.Windows.Forms.ToolStripMenuItem trayMenuFixed;
        private System.Windows.Forms.ToolStripMenuItem trayMenuDisplayMode;
        private System.Windows.Forms.ToolStripMenuItem trayMenuShowColorPicker;
        private System.Windows.Forms.ToolStripMenuItem trayMenuOpenConfigFile;
        private System.Windows.Forms.ToolStripMenuItem trayMenuFormatMode;
        private System.Windows.Forms.ToolStripMenuItem trayMenuFormatMini;
        private System.Windows.Forms.ToolStripMenuItem trayMenuFormatExtention;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem trayMenuCopyPolicy;
        private System.Windows.Forms.ToolStripMenuItem trayMenuCopyPolicyHexValueOnly;
        private System.Windows.Forms.ToolStripMenuItem trayMenuCopyPolicyRgbValueOnly;
        private System.Windows.Forms.ToolStripMenuItem trayMenuCheckUpdate;
        private System.Windows.Forms.ToolStripMenuItem trayMenuHistory;
        private System.Windows.Forms.ToolStripMenuItem trayMenuCheckUpdateOnStartup;
        private System.Windows.Forms.ToolStripMenuItem trayMenuHotkey;
        private System.Windows.Forms.ToolStripMenuItem trayMenuRestart;
        private System.Windows.Forms.ToolStripMenuItem trayMenuTheme;
        private System.Windows.Forms.Label lbColorPreview;
        private System.Windows.Forms.ToolStripMenuItem trayMenuPixelScale;
        private System.Windows.Forms.ToolStripMenuItem trayMenuFormatStandard;
        private System.Windows.Forms.Label lbHsl;
        private System.Windows.Forms.Label lbHsb;
        private System.Windows.Forms.Panel pnExt;
        private System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithm;
        private System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmGeometry;
        private System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmAxis;
        private System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmSegment;
        private System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmBajon;
        private System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmStandard;
        private System.Windows.Forms.Label lbHsi;
    }
}

