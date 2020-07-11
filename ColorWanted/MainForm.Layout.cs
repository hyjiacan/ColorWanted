using System;

namespace ColorWanted
{
    partial class MainForm
    {/// <summary>
     /// 必需的设计器变量。
     /// </summary>
        private System.ComponentModel.IContainer componentsSet = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (componentsSet != null))
            {
                componentsSet.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void componentsLayout()
        {
            this.componentsSet = new System.ComponentModel.Container();
            i18n.I18nManager resources = new i18n.I18nManager(typeof(MainForm));
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.lbHex = new System.Windows.Forms.Label();
            this.lbRgb = new System.Windows.Forms.Label();
            this.tray = new System.Windows.Forms.NotifyIcon(this.componentsSet);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.componentsSet);
            this.trayMenuDisplayMode = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHideWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFollowCaret = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFixed = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFormatMode = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFormatMini = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFormatStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFormatExtention = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuFormatShot = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuCopyPolicy = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuCopyPolicyHexValueOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuCopyPolicyRgbValueOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuCopyPolicyUpperCase = new System.Windows.Forms.ToolStripMenuItem();
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
            this.trayMenuLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuLanguageEN = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuLanguageZH = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuCheckUpdateOnStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuShowAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuScreenShot = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuScreenRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuShootOnCurrentScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuEnableClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuShowClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuImgViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.tooltip = new System.Windows.Forms.ToolTip(this.componentsSet);
            this.lbColorPreview = new System.Windows.Forms.Label();
            this.lbHsl = new System.Windows.Forms.Label();
            this.lbHsb = new System.Windows.Forms.Label();
            this.pnExt = new System.Windows.Forms.Panel();
            this.lbHsi = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.pnExt.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScreenshot
            // 
            resources.ApplyResources(this.btnScreenshot, "btnScreenshot");
            this.btnScreenshot.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScreenshot.Location = new System.Drawing.Point(0, 0);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Padding = new System.Windows.Forms.Padding(0);
            this.btnScreenshot.Size = new System.Drawing.Size(20, 20);
            this.btnScreenshot.TabIndex = 0;
            this.btnScreenshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScreenshot.AutoSize = false;
            this.btnScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScreenshot.FlatAppearance.BorderSize = 0;
            this.tooltip.SetToolTip(this.btnScreenshot, resources.GetString("btnScreenshot.ToolTip"));
            this.btnScreenshot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnScreenshot_MouseDown);
            // 
            // lbHex
            // 
            resources.ApplyResources(this.lbHex, "lbHex");
            this.lbHex.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHex.Location = new System.Drawing.Point(20, 0);
            this.lbHex.Name = "lbHex";
            this.lbHex.Padding = new System.Windows.Forms.Padding(2);
            this.lbHex.Size = new System.Drawing.Size(68, 20);
            this.lbHex.TabIndex = 0;
            this.tooltip.SetToolTip(this.lbHex, resources.GetString("lbHex.ToolTip"));
            this.lbHex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbRgb
            // 
            resources.ApplyResources(this.lbRgb, "lbRgb");
            this.lbRgb.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRgb.Location = new System.Drawing.Point(0, 20);
            this.lbRgb.Name = "lbRgb";
            this.lbRgb.Padding = new System.Windows.Forms.Padding(2);
            this.lbRgb.Size = new System.Drawing.Size(140, 20);
            this.lbRgb.TabIndex = 0;
            this.tooltip.SetToolTip(this.lbRgb, resources.GetString("lbRgb.ToolTip"));
            this.lbRgb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbRgb.Visible = false;
            this.lbRgb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbColorPreview
            // 
            this.lbColorPreview.Location = new System.Drawing.Point(89, 0);
            resources.ApplyResources(this.lbColorPreview, "lbColorPreview");
            this.lbColorPreview.Name = "lbColorPreview";
            this.lbColorPreview.Size = new System.Drawing.Size(20, 20);
            this.lbColorPreview.TabIndex = 1;
            this.tooltip.SetToolTip(this.lbColorPreview, resources.GetString("lbColorPreview.ToolTip"));
            // 
            // lbHsl
            // 
            this.lbHsl.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            resources.ApplyResources(this.lbHsl, "lbHsl");
            this.lbHsl.Location = new System.Drawing.Point(0, 0);
            this.lbHsl.Name = "lbHsl";
            this.lbHsl.Padding = new System.Windows.Forms.Padding(2);
            this.tooltip.SetToolTip(this.lbHsl, resources.GetString("lbHsl.ToolTip"));
            this.lbHsl.Size = new System.Drawing.Size(180, 20);
            this.lbHsl.TabIndex = 2;
            this.lbHsl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHsl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbHsb
            // 
            this.lbHsb.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHsb.Location = new System.Drawing.Point(0, 20);
            resources.ApplyResources(this.lbHsb, "lbHsb");
            this.lbHsb.Name = "lbHsb";
            this.lbHsb.Padding = new System.Windows.Forms.Padding(2);
            this.lbHsb.Size = new System.Drawing.Size(180, 20);
            this.lbHsb.TabIndex = 3;
            this.tooltip.SetToolTip(this.lbHsb, resources.GetString("lbHsb.ToolTip"));
            this.lbHsb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHsb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // pnExt
            // 
            resources.ApplyResources(this.pnExt, "pnExt");
            this.pnExt.Controls.Add(this.lbHsb);
            this.pnExt.Controls.Add(this.lbHsi);
            this.pnExt.Controls.Add(this.lbHsl);
            this.pnExt.Location = new System.Drawing.Point(0, 40);
            this.pnExt.Name = "pnExt";
            this.pnExt.Size = new System.Drawing.Size(180, 60);
            this.pnExt.TabIndex = 4;
            this.tooltip.SetToolTip(this.pnExt, resources.GetString("pnExt.ToolTip"));
            // 
            // lbHsi
            // 
            this.lbHsi.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHsi.Location = new System.Drawing.Point(0, 40);
            resources.ApplyResources(this.lbHsi, "lbHsi");
            this.lbHsi.Name = "lbHsi";
            this.lbHsi.Padding = new System.Windows.Forms.Padding(2);
            this.lbHsi.Size = new System.Drawing.Size(180, 20);
            this.lbHsi.TabIndex = 5;
            this.tooltip.SetToolTip(this.lbHsi, resources.GetString("lbHsi.ToolTip"));
            this.lbHsi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHsi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // tray
            // 
            resources.ApplyResources(this.tray, "tray");
            this.tray.ContextMenuStrip = this.menu;
            this.tray.Icon = global::ColorWanted.Properties.Resources.ico;
            this.tray.Click += new EventHandler(this.tray_Click);
            this.tray.Visible = true;
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
            this.trayMenuScreenShot,
            this.trayMenuScreenRecord,
            this.trayMenuShootOnCurrentScreen,
            this.toolStripSeparator4,
            this.trayMenuEnableClipboard,
            this.trayMenuShowClipboard,
            this.trayMenuImgViewer,
            this.toolStripSeparator1,
            this.trayMenuLanguage,
            this.trayMenuCheckUpdate,
            this.trayMenuRestart,
            this.trayMenuShowAbout,
            this.trayMenuExit});
            this.menu.Name = "trayMenu";
            this.menu.Size = new System.Drawing.Size(149, 418);
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
            this.trayMenuDisplayMode.Size = new System.Drawing.Size(148, 22);
            this.trayMenuDisplayMode.ToolTipText = "切换不同的窗口模式";
            // 
            // trayMenuHideWindow
            // 
            resources.ApplyResources(this.trayMenuHideWindow, "trayMenuHideWindow");
            this.trayMenuHideWindow.Checked = true;
            this.trayMenuHideWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuHideWindow.Name = "trayMenuHideWindow";
            this.trayMenuHideWindow.Size = new System.Drawing.Size(124, 22);
            this.trayMenuHideWindow.Click += new EventHandler(this.trayMenuHideWindow_Click);
            // 
            // trayMenuFollowCaret
            // 
            resources.ApplyResources(this.trayMenuFollowCaret, "trayMenuFollowCaret");
            this.trayMenuFollowCaret.Name = "trayMenuFollowCaret";
            this.trayMenuFollowCaret.Size = new System.Drawing.Size(124, 22);
            this.trayMenuFollowCaret.Click += new EventHandler(this.trayMenuFollowCaret_Click);
            // 
            // trayMenuFixed
            // 
            resources.ApplyResources(this.trayMenuFixed, "trayMenuFixed");
            this.trayMenuFixed.Name = "trayMenuFixed";
            this.trayMenuFixed.Size = new System.Drawing.Size(124, 22);
            this.trayMenuFixed.Click += new EventHandler(this.trayMenuFixed_Click);
            // 
            // trayMenuFormatMode
            // 
            resources.ApplyResources(this.trayMenuFormatMode, "trayMenuFormatMode");
            this.trayMenuFormatMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuFormatMini,
            this.trayMenuFormatStandard,
            this.trayMenuFormatExtention,
            this.trayMenuFormatShot});
            this.trayMenuFormatMode.Name = "trayMenuFormatMode";
            this.trayMenuFormatMode.Size = new System.Drawing.Size(148, 22);
            // 
            // trayMenuFormatMini
            // 
            resources.ApplyResources(this.trayMenuFormatMini, "trayMenuFormatMini");
            this.trayMenuFormatMini.Checked = true;
            this.trayMenuFormatMini.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuFormatMini.Name = "trayMenuFormatMini";
            this.trayMenuFormatMini.Size = new System.Drawing.Size(124, 22);
            this.trayMenuFormatMini.Click += new EventHandler(this.trayMenuFormatMini_Click);
            // 
            // trayMenuFormatStandard
            // 
            resources.ApplyResources(this.trayMenuFormatStandard, "trayMenuFormatStandard");
            this.trayMenuFormatStandard.Name = "trayMenuFormatStandard";
            this.trayMenuFormatStandard.Size = new System.Drawing.Size(124, 22);
            this.trayMenuFormatStandard.Click += new EventHandler(this.trayMenuFormatStandard_Click);
            // 
            // trayMenuFormatExtention
            // 
            resources.ApplyResources(this.trayMenuFormatExtention, "trayMenuFormatExtention");
            this.trayMenuFormatExtention.Name = "trayMenuFormatExtention";
            this.trayMenuFormatExtention.Size = new System.Drawing.Size(124, 22);
            this.trayMenuFormatExtention.Click += new EventHandler(this.trayMenuFormatExtention_Click);
            // 
            // trayMenuFormatShot
            // 
            resources.ApplyResources(this.trayMenuFormatShot, "trayMenuFormatShot");
            this.trayMenuFormatShot.Name = "trayMenuFormatShot";
            this.trayMenuFormatShot.Size = new System.Drawing.Size(124, 22);
            this.trayMenuFormatShot.Click += new EventHandler(this.trayMenuFormatShot_Click);
            // 
            // trayMenuCopyPolicy
            // 
            resources.ApplyResources(this.trayMenuCopyPolicy, "trayMenuCopyPolicy");
            this.trayMenuCopyPolicy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuCopyPolicyHexValueOnly,
            this.trayMenuCopyPolicyRgbValueOnly,
            this.trayMenuCopyPolicyUpperCase,
            });
            this.trayMenuCopyPolicy.Name = "trayMenuCopyPolicy";
            this.trayMenuCopyPolicy.Size = new System.Drawing.Size(148, 22);
            // 
            // trayMenuCopyPolicyHexValueOnly
            // 
            resources.ApplyResources(this.trayMenuCopyPolicyHexValueOnly, "trayMenuCopyPolicyHexValueOnly");
            this.trayMenuCopyPolicyHexValueOnly.Name = "trayMenuCopyPolicyHexValueOnly";
            this.trayMenuCopyPolicyHexValueOnly.Size = new System.Drawing.Size(125, 22);
            this.trayMenuCopyPolicyHexValueOnly.Click += new EventHandler(this.trayMenuCopyPolicyHexValueOnly_Click);
            // 
            // trayMenuCopyPolicyRgbValueOnly
            // 
            resources.ApplyResources(this.trayMenuCopyPolicyRgbValueOnly, "trayMenuCopyPolicyRgbValueOnly");
            this.trayMenuCopyPolicyRgbValueOnly.Name = "trayMenuCopyPolicyRgbValueOnly";
            this.trayMenuCopyPolicyRgbValueOnly.Size = new System.Drawing.Size(125, 22);
            this.trayMenuCopyPolicyRgbValueOnly.Click += new EventHandler(this.trayMenuCopyPolicyRgbValueOnly_Click); // 
            // trayMenuCopyPolicyUpperCase
            // 
            resources.ApplyResources(this.trayMenuCopyPolicyUpperCase, "trayMenuCopyPolicyUpperCase");
            this.trayMenuCopyPolicyUpperCase.Name = "trayMenuCopyPolicyUpperCase";
            this.trayMenuCopyPolicyUpperCase.Size = new System.Drawing.Size(125, 22);
            this.trayMenuCopyPolicyUpperCase.Click += new EventHandler(this.trayMenuCopyPolicyUpperCase_Click);
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
            this.trayMenuHsiAlgorithm.Size = new System.Drawing.Size(148, 22);
            // 
            // trayMenuHsiAlgorithmGeometry
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmGeometry, "trayMenuHsiAlgorithmGeometry");
            this.trayMenuHsiAlgorithmGeometry.Name = "trayMenuHsiAlgorithmGeometry";
            this.trayMenuHsiAlgorithmGeometry.Size = new System.Drawing.Size(157, 22);
            this.trayMenuHsiAlgorithmGeometry.Click += new EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmAxis
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmAxis, "trayMenuHsiAlgorithmAxis");
            this.trayMenuHsiAlgorithmAxis.Name = "trayMenuHsiAlgorithmAxis";
            this.trayMenuHsiAlgorithmAxis.Size = new System.Drawing.Size(157, 22);
            this.trayMenuHsiAlgorithmAxis.Click += new EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmSegment
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmSegment, "trayMenuHsiAlgorithmSegment");
            this.trayMenuHsiAlgorithmSegment.Name = "trayMenuHsiAlgorithmSegment";
            this.trayMenuHsiAlgorithmSegment.Size = new System.Drawing.Size(157, 22);
            this.trayMenuHsiAlgorithmSegment.Click += new EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmBajon
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmBajon, "trayMenuHsiAlgorithmBajon");
            this.trayMenuHsiAlgorithmBajon.Name = "trayMenuHsiAlgorithmBajon";
            this.trayMenuHsiAlgorithmBajon.Size = new System.Drawing.Size(157, 22);
            this.trayMenuHsiAlgorithmBajon.Click += new EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmStandard
            // 
            resources.ApplyResources(this.trayMenuHsiAlgorithmStandard, "trayMenuHsiAlgorithmStandard");
            this.trayMenuHsiAlgorithmStandard.Checked = true;
            this.trayMenuHsiAlgorithmStandard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuHsiAlgorithmStandard.Name = "trayMenuHsiAlgorithmStandard";
            this.trayMenuHsiAlgorithmStandard.Size = new System.Drawing.Size(157, 22);
            this.trayMenuHsiAlgorithmStandard.Click += new EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // trayMenuShowPreview
            // 
            resources.ApplyResources(this.trayMenuShowPreview, "trayMenuShowPreview");
            this.trayMenuShowPreview.Name = "trayMenuShowPreview";
            this.trayMenuShowPreview.Size = new System.Drawing.Size(148, 22);
            this.trayMenuShowPreview.Click += new EventHandler(this.trayMenuShowPreview_Click);
            // 
            // trayMenuShowColorPicker
            // 
            resources.ApplyResources(this.trayMenuShowColorPicker, "trayMenuShowColorPicker");
            this.trayMenuShowColorPicker.Name = "trayMenuShowColorPicker";
            this.trayMenuShowColorPicker.Size = new System.Drawing.Size(148, 22);
            this.trayMenuShowColorPicker.Click += new EventHandler(this.trayMenuShowColorPicker_Click);
            // 
            // trayMenuPixelScale
            // 
            resources.ApplyResources(this.trayMenuPixelScale, "trayMenuPixelScale");
            this.trayMenuPixelScale.Name = "trayMenuPixelScale";
            this.trayMenuPixelScale.Size = new System.Drawing.Size(148, 22);
            this.trayMenuPixelScale.Click += new EventHandler(this.trayMenuPixelScale_Click);
            // 
            // trayMenuAutoPin
            // 
            resources.ApplyResources(this.trayMenuAutoPin, "trayMenuAutoPin");
            this.trayMenuAutoPin.Checked = true;
            this.trayMenuAutoPin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuAutoPin.Name = "trayMenuAutoPin";
            this.trayMenuAutoPin.Size = new System.Drawing.Size(148, 22);
            this.trayMenuAutoPin.Click += new EventHandler(this.trayMenuAutoPin_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // trayMenuTheme
            // 
            resources.ApplyResources(this.trayMenuTheme, "trayMenuTheme");
            this.trayMenuTheme.Name = "trayMenuTheme";
            this.trayMenuTheme.Size = new System.Drawing.Size(148, 22);
            this.trayMenuTheme.Click += new EventHandler(this.trayMenuTheme_Click);
            // 
            // trayMenuHotkey
            // 
            resources.ApplyResources(this.trayMenuHotkey, "trayMenuHotkey");
            this.trayMenuHotkey.Name = "trayMenuHotkey";
            this.trayMenuHotkey.Size = new System.Drawing.Size(148, 22);
            this.trayMenuHotkey.Click += new EventHandler(this.trayMenuHotkey_Click);
            // 
            // trayMenuRestoreLocation
            // 
            resources.ApplyResources(this.trayMenuRestoreLocation, "trayMenuRestoreLocation");
            this.trayMenuRestoreLocation.Name = "trayMenuRestoreLocation";
            this.trayMenuRestoreLocation.Size = new System.Drawing.Size(148, 22);
            this.trayMenuRestoreLocation.Click += new EventHandler(this.trayMenuRestoreLocation_Click);
            // 
            // trayMenuAutoStart
            // 
            resources.ApplyResources(this.trayMenuAutoStart, "trayMenuAutoStart");
            this.trayMenuAutoStart.Name = "trayMenuAutoStart";
            this.trayMenuAutoStart.Size = new System.Drawing.Size(148, 22);
            this.trayMenuAutoStart.Click += new EventHandler(this.trayMenuAutoStart_Click);
            // 
            // trayMenuOpenConfigFile
            // 
            resources.ApplyResources(this.trayMenuOpenConfigFile, "trayMenuOpenConfigFile");
            this.trayMenuOpenConfigFile.Name = "trayMenuOpenConfigFile";
            this.trayMenuOpenConfigFile.Size = new System.Drawing.Size(148, 22);
            this.trayMenuOpenConfigFile.Click += new EventHandler(this.trayMenuOpenConfigFile_Click);
            // 
            // trayMenuHistory
            // 
            resources.ApplyResources(this.trayMenuHistory, "trayMenuHistory");
            this.trayMenuHistory.Name = "trayMenuHistory";
            this.trayMenuHistory.Size = new System.Drawing.Size(148, 22);
            this.trayMenuHistory.Click += new EventHandler(this.trayMenuHistory_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // trayMenuLanguage
            // 
            resources.ApplyResources(this.trayMenuLanguage, "trayMenuLanguage");
            this.trayMenuLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuLanguageZH, this.trayMenuLanguageEN
            });
            this.trayMenuLanguage.Name = "trayMenuLanguage";
            this.trayMenuLanguage.Size = new System.Drawing.Size(148, 22);
            // 
            // trayMenuScreenShot
            // 
            resources.ApplyResources(this.trayMenuScreenShot, "trayMenuScreenShot");
            this.trayMenuScreenShot.Name = "trayMenuScreenShot";
            this.trayMenuScreenShot.Size = new System.Drawing.Size(148, 22);
            this.trayMenuScreenShot.Click += new EventHandler(this.trayMenuScreenShot_Click);
            // 
            // trayMenuScreenShot
            // 
            resources.ApplyResources(this.trayMenuScreenRecord, "trayMenuScreenRecord");
            this.trayMenuScreenRecord.Name = "trayMenuScreenRecord";
            this.trayMenuScreenRecord.Size = new System.Drawing.Size(148, 22);
            this.trayMenuScreenRecord.Click += new EventHandler(this.trayMenuScreenRecord_Click);
            // 
            // trayMenuShootOnCurrentScreen
            // 
            resources.ApplyResources(this.trayMenuShootOnCurrentScreen, "trayMenuShootOnCurrentScreen");
            this.trayMenuShootOnCurrentScreen.Name = "trayMenuShootOnCurrentScreen";
            this.trayMenuShootOnCurrentScreen.Size = new System.Drawing.Size(148, 22);
            this.trayMenuShootOnCurrentScreen.Click += new EventHandler(this.trayMenuShootOnCurrentScreen_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // trayMenuEnableClipboard
            // 
            resources.ApplyResources(this.trayMenuEnableClipboard, "trayMenuEnableClipboard");
            this.trayMenuEnableClipboard.Name = "trayMenuEnableClipboard";
            this.trayMenuEnableClipboard.Size = new System.Drawing.Size(148, 22);
            this.trayMenuEnableClipboard.Click += new EventHandler(this.trayMenuEnableClipboard_Click);
            // 
            // trayMenuShowClipboard
            // 
            resources.ApplyResources(this.trayMenuShowClipboard, "trayMenuShowClipboard");
            this.trayMenuShowClipboard.Name = "trayMenuShowClipboard";
            this.trayMenuShowClipboard.Size = new System.Drawing.Size(148, 22);
            this.trayMenuShowClipboard.Click += new EventHandler(this.trayMenuShowClipboard_Click);
            // 
            // trayMenuImgViewer
            // 
            resources.ApplyResources(this.trayMenuImgViewer, "trayMenuImgViewer");
            this.trayMenuImgViewer.Name = "trayMenuImgViewer";
            this.trayMenuImgViewer.Size = new System.Drawing.Size(148, 22);
            this.trayMenuImgViewer.Click += new EventHandler(this.trayMenuImgViewer_Click);
            // 
            // trayMenuLanguageZH
            // 
            resources.ApplyResources(this.trayMenuLanguageZH, "trayMenuLanguageZH");
            this.trayMenuLanguageZH.Name = "trayMenuLanguageZH";
            this.trayMenuLanguageZH.CheckOnClick = true;
            this.trayMenuLanguageZH.Text = "中文";
            this.trayMenuLanguageZH.Size = new System.Drawing.Size(136, 22);
            this.trayMenuLanguageZH.Click += new EventHandler(this.trayMenuLanguageZH_Click);
            // 
            // trayMenuLanguageEN
            // 
            resources.ApplyResources(this.trayMenuLanguageEN, "trayMenuLanguageEN");
            this.trayMenuLanguageEN.Name = "trayMenuLanguageEN";
            this.trayMenuLanguageEN.CheckOnClick = true;
            this.trayMenuLanguageEN.Text = "English";
            this.trayMenuLanguageEN.Size = new System.Drawing.Size(136, 22);
            this.trayMenuLanguageEN.Click += new EventHandler(this.trayMenuLanguageEN_Click);
            // 
            // trayMenuCheckUpdate
            // 
            resources.ApplyResources(this.trayMenuCheckUpdate, "trayMenuCheckUpdate");
            this.trayMenuCheckUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuCheckUpdateOnStartup});
            this.trayMenuCheckUpdate.Name = "trayMenuCheckUpdate";
            this.trayMenuCheckUpdate.Size = new System.Drawing.Size(148, 22);
            this.trayMenuCheckUpdate.Click += new EventHandler(this.trayMenuCheckUpdate_Click);
            // 
            // trayMenuCheckUpdateOnStartup
            // 
            resources.ApplyResources(this.trayMenuCheckUpdateOnStartup, "trayMenuCheckUpdateOnStartup");
            this.trayMenuCheckUpdateOnStartup.Name = "trayMenuCheckUpdateOnStartup";
            this.trayMenuCheckUpdateOnStartup.Size = new System.Drawing.Size(136, 22);
            this.trayMenuCheckUpdateOnStartup.Click += new EventHandler(this.trayMenuCheckUpdateOnStartup_Click);
            // 
            // trayMenuRestart
            // 
            resources.ApplyResources(this.trayMenuRestart, "trayMenuRestart");
            this.trayMenuRestart.Name = "trayMenuRestart";
            this.trayMenuRestart.Size = new System.Drawing.Size(148, 22);
            this.trayMenuRestart.Click += new EventHandler(this.trayMenuRestart_Click);
            // 
            // trayMenuShowAbout
            // 
            resources.ApplyResources(this.trayMenuShowAbout, "trayMenuShowAbout");
            this.trayMenuShowAbout.Name = "trayMenuShowAbout";
            this.trayMenuShowAbout.Size = new System.Drawing.Size(148, 22);
            this.trayMenuShowAbout.Click += new EventHandler(this.trayMenuShowAbout_Click);
            // 
            // trayMenuExit
            // 
            resources.ApplyResources(this.trayMenuExit, "trayMenuExit");
            this.trayMenuExit.Name = "trayMenuExit";
            this.trayMenuExit.Size = new System.Drawing.Size(148, 22);
            this.trayMenuExit.Click += new EventHandler(this.trayMenuExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(348, 236);
            this.ContextMenuStrip = this.menu;
            this.ControlBox = false;
            this.Controls.Add(this.pnExt);
            this.Controls.Add(this.btnScreenshot);
            this.Controls.Add(this.lbHex);
            this.Controls.Add(this.lbRgb);
            this.Controls.Add(this.lbColorPreview);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ForeColorChanged += MainForm_ForeColorChanged;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.tooltip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new EventHandler(this.MainForm_Load);
            this.LocationChanged += new EventHandler(this.MainForm_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            this.menu.ResumeLayout(false);
            this.pnExt.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        public System.Windows.Forms.Button btnScreenshot;
        public System.Windows.Forms.Label lbRgb;
        public System.Windows.Forms.Label lbHex;
        public System.Windows.Forms.NotifyIcon tray;
        public System.Windows.Forms.ContextMenuStrip menu;
        public System.Windows.Forms.ToolStripMenuItem trayMenuShowAbout;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem trayMenuExit;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHideWindow;
        public System.Windows.Forms.ToolStripMenuItem trayMenuAutoPin;
        public System.Windows.Forms.ToolTip tooltip;
        public System.Windows.Forms.ToolStripMenuItem trayMenuShowPreview;
        public System.Windows.Forms.ToolStripMenuItem trayMenuRestoreLocation;
        public System.Windows.Forms.ToolStripMenuItem trayMenuFollowCaret;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem trayMenuAutoStart;
        public System.Windows.Forms.ToolStripMenuItem trayMenuFixed;
        public System.Windows.Forms.ToolStripMenuItem trayMenuDisplayMode;
        public System.Windows.Forms.ToolStripMenuItem trayMenuShowColorPicker;
        public System.Windows.Forms.ToolStripMenuItem trayMenuOpenConfigFile;
        public System.Windows.Forms.ToolStripMenuItem trayMenuFormatMode;
        public System.Windows.Forms.ToolStripMenuItem trayMenuFormatMini;
        public System.Windows.Forms.ToolStripMenuItem trayMenuFormatStandard;
        public System.Windows.Forms.ToolStripMenuItem trayMenuFormatExtention;
        public System.Windows.Forms.ToolStripMenuItem trayMenuFormatShot;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripMenuItem trayMenuCopyPolicy;
        public System.Windows.Forms.ToolStripMenuItem trayMenuCopyPolicyHexValueOnly;
        public System.Windows.Forms.ToolStripMenuItem trayMenuCopyPolicyRgbValueOnly;
        public System.Windows.Forms.ToolStripMenuItem trayMenuCopyPolicyUpperCase;
        public System.Windows.Forms.ToolStripMenuItem trayMenuCheckUpdate;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHistory;
        public System.Windows.Forms.ToolStripMenuItem trayMenuLanguage;
        public System.Windows.Forms.ToolStripMenuItem trayMenuLanguageZH;
        public System.Windows.Forms.ToolStripMenuItem trayMenuLanguageEN;
        public System.Windows.Forms.ToolStripMenuItem trayMenuCheckUpdateOnStartup;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHotkey;
        public System.Windows.Forms.ToolStripMenuItem trayMenuRestart;
        public System.Windows.Forms.ToolStripMenuItem trayMenuTheme;
        public System.Windows.Forms.Label lbColorPreview;
        public System.Windows.Forms.ToolStripMenuItem trayMenuPixelScale;
        public System.Windows.Forms.Label lbHsl;
        public System.Windows.Forms.Label lbHsb;
        public System.Windows.Forms.Panel pnExt;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithm;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmGeometry;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmAxis;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmSegment;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmBajon;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHsiAlgorithmStandard;
        public System.Windows.Forms.Label lbHsi;
        public System.Windows.Forms.ToolStripMenuItem trayMenuScreenShot;
        public System.Windows.Forms.ToolStripMenuItem trayMenuScreenRecord;
        public System.Windows.Forms.ToolStripMenuItem trayMenuShootOnCurrentScreen;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripMenuItem trayMenuEnableClipboard;
        public System.Windows.Forms.ToolStripMenuItem trayMenuShowClipboard;
        public System.Windows.Forms.ToolStripMenuItem trayMenuImgViewer;
    }
}
