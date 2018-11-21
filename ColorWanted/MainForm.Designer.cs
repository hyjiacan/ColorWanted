namespace ColorWanted
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.trayMenuTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.lbHex.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHex.Location = new System.Drawing.Point(0, 0);
            this.lbHex.Name = "lbHex";
            this.lbHex.Padding = new System.Windows.Forms.Padding(2);
            this.lbHex.Size = new System.Drawing.Size(68, 20);
            this.lbHex.TabIndex = 0;
            this.lbHex.Text = "#FFFFFF";
            this.lbHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbRgb
            // 
            this.lbRgb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRgb.Location = new System.Drawing.Point(0, 20);
            this.lbRgb.Name = "lbRgb";
            this.lbRgb.Padding = new System.Windows.Forms.Padding(2);
            this.lbRgb.Size = new System.Drawing.Size(140, 20);
            this.lbRgb.TabIndex = 0;
            this.lbRgb.Text = "RGB(0,0,0)";
            this.lbRgb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbRgb.Visible = false;
            this.lbRgb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // tray
            // 
            this.tray.BalloonTipText = "屏幕取色器正在工作";
            this.tray.BalloonTipTitle = "赏色";
            this.tray.ContextMenuStrip = this.menu;
            this.tray.Icon = global::ColorWanted.Properties.Resources.ico;
            this.tray.Text = "赏色-好用的Windows屏幕取色器";
            this.tray.Visible = true;
            this.tray.Click += new System.EventHandler(this.tray_Click);
            // 
            // menu
            // 
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
            this.menu.Size = new System.Drawing.Size(181, 440);
            // 
            // trayMenuDisplayMode
            // 
            this.trayMenuDisplayMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuHideWindow,
            this.trayMenuFollowCaret,
            this.trayMenuFixed});
            this.trayMenuDisplayMode.Name = "trayMenuDisplayMode";
            this.trayMenuDisplayMode.Size = new System.Drawing.Size(180, 22);
            this.trayMenuDisplayMode.Text = "窗口模式";
            this.trayMenuDisplayMode.ToolTipText = "切换不同的窗口模式";
            // 
            // trayMenuHideWindow
            // 
            this.trayMenuHideWindow.Checked = true;
            this.trayMenuHideWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuHideWindow.Name = "trayMenuHideWindow";
            this.trayMenuHideWindow.Size = new System.Drawing.Size(180, 22);
            this.trayMenuHideWindow.Text = "隐藏窗口";
            this.trayMenuHideWindow.Click += new System.EventHandler(this.trayMenuHideWindow_Click);
            // 
            // trayMenuFollowCaret
            // 
            this.trayMenuFollowCaret.Name = "trayMenuFollowCaret";
            this.trayMenuFollowCaret.Size = new System.Drawing.Size(180, 22);
            this.trayMenuFollowCaret.Text = "跟随模式";
            this.trayMenuFollowCaret.Click += new System.EventHandler(this.trayMenuFollowCaret_Click);
            // 
            // trayMenuFixed
            // 
            this.trayMenuFixed.Name = "trayMenuFixed";
            this.trayMenuFixed.Size = new System.Drawing.Size(180, 22);
            this.trayMenuFixed.Text = "固定模式";
            this.trayMenuFixed.Click += new System.EventHandler(this.trayMenuFixed_Click);
            // 
            // trayMenuFormatMode
            // 
            this.trayMenuFormatMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuFormatMini,
            this.trayMenuFormatStandard,
            this.trayMenuFormatExtention});
            this.trayMenuFormatMode.Name = "trayMenuFormatMode";
            this.trayMenuFormatMode.Size = new System.Drawing.Size(180, 22);
            this.trayMenuFormatMode.Text = "显示格式";
            this.trayMenuFormatMode.ToolTipText = "设置是否显示RGB颜色值";
            // 
            // trayMenuFormatMini
            // 
            this.trayMenuFormatMini.Checked = true;
            this.trayMenuFormatMini.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuFormatMini.Name = "trayMenuFormatMini";
            this.trayMenuFormatMini.Size = new System.Drawing.Size(124, 22);
            this.trayMenuFormatMini.Text = "迷你模式";
            this.trayMenuFormatMini.ToolTipText = "只显示HEX格式";
            this.trayMenuFormatMini.Click += new System.EventHandler(this.trayMenuFormatMini_Click);
            // 
            // trayMenuFormatStandard
            // 
            this.trayMenuFormatStandard.Name = "trayMenuFormatStandard";
            this.trayMenuFormatStandard.Size = new System.Drawing.Size(124, 22);
            this.trayMenuFormatStandard.Text = "标准模式";
            this.trayMenuFormatStandard.ToolTipText = "显示HEX格式和GRB格式";
            this.trayMenuFormatStandard.Click += new System.EventHandler(this.trayMenuFormatStandard_Click);
            // 
            // trayMenuFormatExtention
            // 
            this.trayMenuFormatExtention.Name = "trayMenuFormatExtention";
            this.trayMenuFormatExtention.Size = new System.Drawing.Size(124, 22);
            this.trayMenuFormatExtention.Text = "扩展模式";
            this.trayMenuFormatExtention.ToolTipText = "显示HEX格式和GRB格式以及HSVB信息";
            this.trayMenuFormatExtention.Click += new System.EventHandler(this.trayMenuFormatExtention_Click);
            // 
            // trayMenuCopyPolicy
            // 
            this.trayMenuCopyPolicy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuCopyPolicyHexValueOnly,
            this.trayMenuCopyPolicyRgbValueOnly});
            this.trayMenuCopyPolicy.Name = "trayMenuCopyPolicy";
            this.trayMenuCopyPolicy.Size = new System.Drawing.Size(180, 22);
            this.trayMenuCopyPolicy.Text = "复制策略";
            this.trayMenuCopyPolicy.ToolTipText = "在复制颜色值时是否只复制值";
            // 
            // trayMenuCopyPolicyHexValueOnly
            // 
            this.trayMenuCopyPolicyHexValueOnly.Name = "trayMenuCopyPolicyHexValueOnly";
            this.trayMenuCopyPolicyHexValueOnly.Size = new System.Drawing.Size(180, 22);
            this.trayMenuCopyPolicyHexValueOnly.Text = "仅HEX值";
            this.trayMenuCopyPolicyHexValueOnly.ToolTipText = "只复制HEX值，此时不包含前面的#符号";
            this.trayMenuCopyPolicyHexValueOnly.Click += new System.EventHandler(this.trayMenuCopyPolicyHexValueOnly_Click);
            // 
            // trayMenuCopyPolicyRgbValueOnly
            // 
            this.trayMenuCopyPolicyRgbValueOnly.Name = "trayMenuCopyPolicyRgbValueOnly";
            this.trayMenuCopyPolicyRgbValueOnly.Size = new System.Drawing.Size(180, 22);
            this.trayMenuCopyPolicyRgbValueOnly.Text = "仅RGB值";
            this.trayMenuCopyPolicyRgbValueOnly.ToolTipText = "只复制RGB值，此时不包含RGBA()，只有值，如: 255,255,255";
            this.trayMenuCopyPolicyRgbValueOnly.Click += new System.EventHandler(this.trayMenuCopyPolicyRgbValueOnly_Click);
            // 
            // trayMenuHsiAlgorithm
            // 
            this.trayMenuHsiAlgorithm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuHsiAlgorithmGeometry,
            this.trayMenuHsiAlgorithmAxis,
            this.trayMenuHsiAlgorithmSegment,
            this.trayMenuHsiAlgorithmBajon,
            this.trayMenuHsiAlgorithmStandard});
            this.trayMenuHsiAlgorithm.Name = "trayMenuHsiAlgorithm";
            this.trayMenuHsiAlgorithm.Size = new System.Drawing.Size(180, 22);
            this.trayMenuHsiAlgorithm.Text = "HSI算法";
            // 
            // trayMenuHsiAlgorithmGeometry
            // 
            this.trayMenuHsiAlgorithmGeometry.Name = "trayMenuHsiAlgorithmGeometry";
            this.trayMenuHsiAlgorithmGeometry.Size = new System.Drawing.Size(180, 22);
            this.trayMenuHsiAlgorithmGeometry.Text = "几何推导法";
            this.trayMenuHsiAlgorithmGeometry.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmAxis
            // 
            this.trayMenuHsiAlgorithmAxis.Name = "trayMenuHsiAlgorithmAxis";
            this.trayMenuHsiAlgorithmAxis.Size = new System.Drawing.Size(180, 22);
            this.trayMenuHsiAlgorithmAxis.Text = "坐标变换法";
            this.trayMenuHsiAlgorithmAxis.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmSegment
            // 
            this.trayMenuHsiAlgorithmSegment.Name = "trayMenuHsiAlgorithmSegment";
            this.trayMenuHsiAlgorithmSegment.Size = new System.Drawing.Size(180, 22);
            this.trayMenuHsiAlgorithmSegment.Text = "分段定义法";
            this.trayMenuHsiAlgorithmSegment.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmBajon
            // 
            this.trayMenuHsiAlgorithmBajon.Name = "trayMenuHsiAlgorithmBajon";
            this.trayMenuHsiAlgorithmBajon.Size = new System.Drawing.Size(180, 22);
            this.trayMenuHsiAlgorithmBajon.Text = "Bajon近似算法";
            this.trayMenuHsiAlgorithmBajon.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // trayMenuHsiAlgorithmStandard
            // 
            this.trayMenuHsiAlgorithmStandard.Checked = true;
            this.trayMenuHsiAlgorithmStandard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuHsiAlgorithmStandard.Name = "trayMenuHsiAlgorithmStandard";
            this.trayMenuHsiAlgorithmStandard.Size = new System.Drawing.Size(180, 22);
            this.trayMenuHsiAlgorithmStandard.Text = "标准模型法";
            this.trayMenuHsiAlgorithmStandard.Click += new System.EventHandler(this.trayMenuHsiAlgorithmChange);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // trayMenuShowPreview
            // 
            this.trayMenuShowPreview.Name = "trayMenuShowPreview";
            this.trayMenuShowPreview.Size = new System.Drawing.Size(180, 22);
            this.trayMenuShowPreview.Text = "显示预览窗口";
            this.trayMenuShowPreview.Click += new System.EventHandler(this.trayMenuShowPreview_Click);
            // 
            // trayMenuShowColorPicker
            // 
            this.trayMenuShowColorPicker.Name = "trayMenuShowColorPicker";
            this.trayMenuShowColorPicker.Size = new System.Drawing.Size(180, 22);
            this.trayMenuShowColorPicker.Text = "打开调色板";
            this.trayMenuShowColorPicker.Click += new System.EventHandler(this.trayMenuShowColorPicker_Click);
            // 
            // trayMenuPixelScale
            // 
            this.trayMenuPixelScale.Name = "trayMenuPixelScale";
            this.trayMenuPixelScale.Size = new System.Drawing.Size(180, 22);
            this.trayMenuPixelScale.Text = "像素放大算法";
            this.trayMenuPixelScale.ToolTipText = "预览窗口使用像素放大算法预览图片";
            this.trayMenuPixelScale.Click += new System.EventHandler(this.trayMenuPixelScale_Click);
            // 
            // trayMenuAutoPin
            // 
            this.trayMenuAutoPin.Checked = true;
            this.trayMenuAutoPin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayMenuAutoPin.Name = "trayMenuAutoPin";
            this.trayMenuAutoPin.Size = new System.Drawing.Size(180, 22);
            this.trayMenuAutoPin.Text = "边缘自动吸附";
            this.trayMenuAutoPin.Click += new System.EventHandler(this.trayMenuAutoPin_Click);
            // 
            // trayMenuTheme
            // 
            this.trayMenuTheme.Name = "trayMenuTheme";
            this.trayMenuTheme.Size = new System.Drawing.Size(180, 22);
            this.trayMenuTheme.Text = "主题配色";
            this.trayMenuTheme.Click += new System.EventHandler(this.trayMenuTheme_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // trayMenuHotkey
            // 
            this.trayMenuHotkey.Name = "trayMenuHotkey";
            this.trayMenuHotkey.Size = new System.Drawing.Size(180, 22);
            this.trayMenuHotkey.Text = "快捷键";
            this.trayMenuHotkey.Click += new System.EventHandler(this.trayMenuHotkey_Click);
            // 
            // trayMenuRestoreLocation
            // 
            this.trayMenuRestoreLocation.Name = "trayMenuRestoreLocation";
            this.trayMenuRestoreLocation.Size = new System.Drawing.Size(180, 22);
            this.trayMenuRestoreLocation.Text = "重置窗口位置";
            this.trayMenuRestoreLocation.Click += new System.EventHandler(this.trayMenuRestoreLocation_Click);
            // 
            // trayMenuAutoStart
            // 
            this.trayMenuAutoStart.Name = "trayMenuAutoStart";
            this.trayMenuAutoStart.Size = new System.Drawing.Size(180, 22);
            this.trayMenuAutoStart.Text = "开机启动";
            this.trayMenuAutoStart.ToolTipText = "设置或取消开机自动启动";
            this.trayMenuAutoStart.Click += new System.EventHandler(this.trayMenuAutoStart_Click);
            // 
            // trayMenuOpenConfigFile
            // 
            this.trayMenuOpenConfigFile.Name = "trayMenuOpenConfigFile";
            this.trayMenuOpenConfigFile.Size = new System.Drawing.Size(180, 22);
            this.trayMenuOpenConfigFile.Text = "查看配置文件";
            this.trayMenuOpenConfigFile.ToolTipText = "打开配置文件";
            this.trayMenuOpenConfigFile.Click += new System.EventHandler(this.trayMenuOpenConfigFile_Click);
            // 
            // trayMenuHistory
            // 
            this.trayMenuHistory.Name = "trayMenuHistory";
            this.trayMenuHistory.Size = new System.Drawing.Size(180, 22);
            this.trayMenuHistory.Text = "取色历史";
            this.trayMenuHistory.ToolTipText = "查看取色历史记录";
            this.trayMenuHistory.Click += new System.EventHandler(this.trayMenuHistory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // trayMenuCheckUpdate
            // 
            this.trayMenuCheckUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuCheckUpdateOnStartup});
            this.trayMenuCheckUpdate.Name = "trayMenuCheckUpdate";
            this.trayMenuCheckUpdate.Size = new System.Drawing.Size(180, 22);
            this.trayMenuCheckUpdate.Text = "检查更新";
            this.trayMenuCheckUpdate.Click += new System.EventHandler(this.trayMenuCheckUpdate_Click);
            // 
            // trayMenuCheckUpdateOnStartup
            // 
            this.trayMenuCheckUpdateOnStartup.Name = "trayMenuCheckUpdateOnStartup";
            this.trayMenuCheckUpdateOnStartup.Size = new System.Drawing.Size(136, 22);
            this.trayMenuCheckUpdateOnStartup.Text = "启动时检查";
            this.trayMenuCheckUpdateOnStartup.ToolTipText = "每天首次启动时检查更新";
            this.trayMenuCheckUpdateOnStartup.Click += new System.EventHandler(this.trayMenuCheckUpdateOnStartup_Click);
            // 
            // trayMenuRestart
            // 
            this.trayMenuRestart.Name = "trayMenuRestart";
            this.trayMenuRestart.Size = new System.Drawing.Size(180, 22);
            this.trayMenuRestart.Text = "重新启动";
            this.trayMenuRestart.Click += new System.EventHandler(this.trayMenuRestart_Click);
            // 
            // trayMenuShowAbout
            // 
            this.trayMenuShowAbout.Name = "trayMenuShowAbout";
            this.trayMenuShowAbout.Size = new System.Drawing.Size(180, 22);
            this.trayMenuShowAbout.Text = "关于";
            this.trayMenuShowAbout.Click += new System.EventHandler(this.trayMenuShowHelp_Click);
            // 
            // trayMenuExit
            // 
            this.trayMenuExit.Name = "trayMenuExit";
            this.trayMenuExit.Size = new System.Drawing.Size(180, 22);
            this.trayMenuExit.Text = "退出";
            this.trayMenuExit.Click += new System.EventHandler(this.trayMenuExit_Click);
            // 
            // lbColorPreview
            // 
            this.lbColorPreview.Location = new System.Drawing.Point(69, 0);
            this.lbColorPreview.Name = "lbColorPreview";
            this.lbColorPreview.Size = new System.Drawing.Size(20, 20);
            this.lbColorPreview.TabIndex = 1;
            // 
            // lbHsl
            // 
            this.lbHsl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHsl.Location = new System.Drawing.Point(0, 0);
            this.lbHsl.Name = "lbHsl";
            this.lbHsl.Padding = new System.Windows.Forms.Padding(2);
            this.lbHsl.Size = new System.Drawing.Size(180, 20);
            this.lbHsl.TabIndex = 2;
            this.lbHsl.Text = "HSL(0,0,0)";
            this.lbHsl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHsl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbHsb
            // 
            this.lbHsb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHsb.Location = new System.Drawing.Point(0, 20);
            this.lbHsb.Name = "lbHsb";
            this.lbHsb.Padding = new System.Windows.Forms.Padding(2);
            this.lbHsb.Size = new System.Drawing.Size(180, 20);
            this.lbHsb.TabIndex = 3;
            this.lbHsb.Text = "HSB(0,0,0)";
            this.lbHsb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHsb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // pnExt
            // 
            this.pnExt.Controls.Add(this.lbHsb);
            this.pnExt.Controls.Add(this.lbHsi);
            this.pnExt.Controls.Add(this.lbHsl);
            this.pnExt.Location = new System.Drawing.Point(0, 40);
            this.pnExt.Name = "pnExt";
            this.pnExt.Size = new System.Drawing.Size(180, 60);
            this.pnExt.TabIndex = 4;
            // 
            // lbHsi
            // 
            this.lbHsi.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHsi.Location = new System.Drawing.Point(0, 40);
            this.lbHsi.Name = "lbHsi";
            this.lbHsi.Padding = new System.Windows.Forms.Padding(2);
            this.lbHsi.Size = new System.Drawing.Size(180, 20);
            this.lbHsi.TabIndex = 5;
            this.lbHsi.Text = "HSI(0,0,0)";
            this.lbHsi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHsi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(348, 236);
            this.ContextMenuStrip = this.menu;
            this.ControlBox = false;
            this.Controls.Add(this.pnExt);
            this.Controls.Add(this.lbHex);
            this.Controls.Add(this.lbRgb);
            this.Controls.Add(this.lbColorPreview);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::ColorWanted.Properties.Resources.ico;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "赏色";
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

