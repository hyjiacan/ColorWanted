using ColorWanted.util;
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuShowColorPicker = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuRestoreLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuShowAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuScreenShot = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuScreenRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuShowClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnScreenshot.Location = new System.Drawing.Point(Util.ScaleX(0), Util.ScaleY(0));
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Padding = new System.Windows.Forms.Padding(0);
            this.btnScreenshot.Size = new System.Drawing.Size(Util.ScaleX(20), Util.ScaleY(20));
            this.btnScreenshot.TabIndex = 0;
            this.btnScreenshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScreenshot.AutoSize = false;
            this.btnScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScreenshot.FlatAppearance.BorderSize = 0;
            this.tooltip.SetToolTip(this.btnScreenshot, resources.GetString("btnScreenshot.ToolTip"));
            this.btnScreenshot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnScreenshot_MouseDown);
            this.btnScreenshot.MouseHover += new System.EventHandler(this.BtnScreenshot_MouseHover);
            // 
            // lbHex
            // 
            resources.ApplyResources(this.lbHex, "lbHex");
            this.lbHex.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHex.Location = new System.Drawing.Point(Util.ScaleX(20), Util.ScaleY(0));
            this.lbHex.Name = "lbHex";
            this.lbHex.Padding = new System.Windows.Forms.Padding(2);
            this.lbHex.Size = new System.Drawing.Size(Util.ScaleX(68), Util.ScaleY(20));
            this.lbHex.TabIndex = 0;
            this.tooltip.SetToolTip(this.lbHex, resources.GetString("lbHex.ToolTip"));
            this.lbHex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbRgb
            // 
            resources.ApplyResources(this.lbRgb, "lbRgb");
            this.lbRgb.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRgb.Location = new System.Drawing.Point(Util.ScaleX(0), Util.ScaleY(20));
            this.lbRgb.Name = "lbRgb";
            this.lbRgb.Padding = new System.Windows.Forms.Padding(2);
            this.lbRgb.Size = new System.Drawing.Size(Util.ScaleX(140), Util.ScaleY(20));
            this.lbRgb.TabIndex = 0;
            this.tooltip.SetToolTip(this.lbRgb, resources.GetString("lbRgb.ToolTip"));
            this.lbRgb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbRgb.Visible = false;
            this.lbRgb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbColorPreview
            // 
            this.lbColorPreview.Location = new System.Drawing.Point(Util.ScaleX(89), Util.ScaleY(0));
            resources.ApplyResources(this.lbColorPreview, "lbColorPreview");
            this.lbColorPreview.Name = "lbColorPreview";
            this.lbColorPreview.Size = new System.Drawing.Size(Util.ScaleX(20), Util.ScaleY(20));
            this.lbColorPreview.TabIndex = 1;
            this.tooltip.SetToolTip(this.lbColorPreview, resources.GetString("lbColorPreview.ToolTip"));
            // 
            // lbHsl
            // 
            this.lbHsl.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            resources.ApplyResources(this.lbHsl, "lbHsl");
            this.lbHsl.Location = new System.Drawing.Point(Util.ScaleX(0), Util.ScaleY(0));
            this.lbHsl.Name = "lbHsl";
            this.lbHsl.Padding = new System.Windows.Forms.Padding(2);
            this.tooltip.SetToolTip(this.lbHsl, resources.GetString("lbHsl.ToolTip"));
            this.lbHsl.Size = new System.Drawing.Size(Util.ScaleX(180), Util.ScaleY(20));
            this.lbHsl.TabIndex = 2;
            this.lbHsl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHsl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbHsb
            // 
            this.lbHsb.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHsb.Location = new System.Drawing.Point(Util.ScaleX(0), Util.ScaleY(20));
            resources.ApplyResources(this.lbHsb, "lbHsb");
            this.lbHsb.Name = "lbHsb";
            this.lbHsb.Padding = new System.Windows.Forms.Padding(2);
            this.lbHsb.Size = new System.Drawing.Size(Util.ScaleX(180), Util.ScaleY(20));
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
            this.pnExt.Location = new System.Drawing.Point(Util.ScaleX(0), Util.ScaleY(40));
            this.pnExt.Name = "pnExt";
            this.pnExt.Size = new System.Drawing.Size(Util.ScaleX(180), Util.ScaleY(60));
            this.pnExt.TabIndex = 4;
            this.tooltip.SetToolTip(this.pnExt, resources.GetString("pnExt.ToolTip"));
            // 
            // lbHsi
            // 
            this.lbHsi.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHsi.Location = new System.Drawing.Point(Util.ScaleX(0), Util.ScaleY(40));
            resources.ApplyResources(this.lbHsi, "lbHsi");
            this.lbHsi.Name = "lbHsi";
            this.lbHsi.Padding = new System.Windows.Forms.Padding(2);
            this.lbHsi.Size = new System.Drawing.Size(Util.ScaleX(180), Util.ScaleY(20));
            this.lbHsi.TabIndex = 5;
            this.tooltip.SetToolTip(this.lbHsi, resources.GetString("lbHsi.ToolTip"));
            this.lbHsi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHsi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // tray
            // 
            resources.ApplyResources(this.tray, "tray");
            this.tray.ContextMenuStrip = this.menu;
            this.tray.Icon = Properties.Resources.ico;
            this.tray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tray_MouseClick);
            this.tray.Visible = true;
            // 
            // menu
            // 
            resources.ApplyResources(this.menu, "menu");
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuShowColorPicker,
            this.trayMenuRestoreLocation,
            this.trayMenuHistory,
            this.trayMenuShowClipboard,
            this.toolStripSeparator2,
            this.trayMenuScreenShot,
            this.trayMenuScreenRecord,
            this.trayMenuOpenImage,
            this.toolStripSeparator4,
            this.trayMenuSettings,
            this.toolStripSeparator1,
            this.trayMenuCheckUpdate,
            this.trayMenuRestart,
            this.toolStripSeparator5,
            this.trayMenuShowAbout,
            this.trayMenuExit});
            this.menu.Name = "trayMenu";
            this.menu.Size = new System.Drawing.Size(Util.ScaleX(149), Util.ScaleY(418));
            this.tooltip.SetToolTip(this.menu, resources.GetString("menu.ToolTip"));
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(Util.ScaleX(145), Util.ScaleY(6));           
            // 
            // trayMenuShowColorPicker
            // 
            resources.ApplyResources(this.trayMenuShowColorPicker, "trayMenuShowColorPicker");
            this.trayMenuShowColorPicker.Name = "trayMenuShowColorPicker";
            this.trayMenuShowColorPicker.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuShowColorPicker.Click += new EventHandler(this.trayMenuShowColorPicker_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(Util.ScaleX(145), Util.ScaleY(6));
            // 
            // trayMenuRestoreLocation
            // 
            resources.ApplyResources(this.trayMenuRestoreLocation, "trayMenuRestoreLocation");
            this.trayMenuRestoreLocation.Name = "trayMenuRestoreLocation";
            this.trayMenuRestoreLocation.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuRestoreLocation.Click += new EventHandler(this.trayMenuRestoreLocation_Click);
            // 
            // trayMenuHistory
            // 
            resources.ApplyResources(this.trayMenuHistory, "trayMenuHistory");
            this.trayMenuHistory.Name = "trayMenuHistory";
            this.trayMenuHistory.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuHistory.Click += new EventHandler(this.trayMenuHistory_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(Util.ScaleX(145), Util.ScaleY(6));
            // 
            // trayMenuScreenShot
            // 
            resources.ApplyResources(this.trayMenuScreenShot, "trayMenuScreenShot");
            this.trayMenuScreenShot.Name = "trayMenuScreenShot";
            this.trayMenuScreenShot.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuScreenShot.Click += new EventHandler(this.trayMenuScreenShot_Click);
            // 
            // trayMenuScreenRecord
            // 
            resources.ApplyResources(this.trayMenuScreenRecord, "trayMenuScreenRecord");
            this.trayMenuScreenRecord.Name = "trayMenuScreenRecord";
            this.trayMenuScreenRecord.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuScreenRecord.Click += new EventHandler(this.trayMenuScreenRecord_Click);
            // 
            // trayMenuOpenImage
            // 
            resources.ApplyResources(this.trayMenuOpenImage, "trayMenuOpenImage");
            this.trayMenuOpenImage.Name = "trayMenuOpenImage";
            this.trayMenuOpenImage.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuOpenImage.Click += new EventHandler(this.trayMenuOpenImage_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(Util.ScaleX(145), Util.ScaleY(6));
            // 
            // trayMenuShowClipboard
            // 
            resources.ApplyResources(this.trayMenuShowClipboard, "trayMenuShowClipboard");
            this.trayMenuShowClipboard.Name = "trayMenuShowClipboard";
            this.trayMenuShowClipboard.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuShowClipboard.Click += new EventHandler(this.trayMenuShowClipboard_Click);
            // 
            // trayMenuSettings
            // 
            resources.ApplyResources(this.trayMenuSettings, "trayMenuSettings");
            this.trayMenuSettings.Name = "trayMenuSettings";
            this.trayMenuSettings.Text = "选项";
            this.trayMenuSettings.Size = new System.Drawing.Size(Util.ScaleX(136), Util.ScaleY(22));
            this.trayMenuSettings.Click += new EventHandler(this.trayMenuSettings_Click);
            // 
            // trayMenuCheckUpdate
            // 
            resources.ApplyResources(this.trayMenuCheckUpdate, "trayMenuCheckUpdate");
            this.trayMenuCheckUpdate.Name = "trayMenuCheckUpdate";
            this.trayMenuCheckUpdate.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuCheckUpdate.Click += new EventHandler(this.trayMenuCheckUpdate_Click);
            // 
            // trayMenuRestart
            // 
            resources.ApplyResources(this.trayMenuRestart, "trayMenuRestart");
            this.trayMenuRestart.Name = "trayMenuRestart";
            this.trayMenuRestart.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuRestart.Click += new EventHandler(this.trayMenuRestart_Click);
            // 
            // trayMenuShowAbout
            // 
            resources.ApplyResources(this.trayMenuShowAbout, "trayMenuShowAbout");
            this.trayMenuShowAbout.Name = "trayMenuShowAbout";
            this.trayMenuShowAbout.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuShowAbout.Click += new EventHandler(this.trayMenuShowAbout_Click);
            // 
            // trayMenuExit
            // 
            resources.ApplyResources(this.trayMenuExit, "trayMenuExit");
            this.trayMenuExit.Name = "trayMenuExit";
            this.trayMenuExit.Size = new System.Drawing.Size(Util.ScaleX(148), Util.ScaleY(22));
            this.trayMenuExit.Click += new EventHandler(this.trayMenuExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(Util.ScaleX(348), Util.ScaleY(236));
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
        public System.Windows.Forms.ToolTip tooltip;
        public System.Windows.Forms.ToolStripMenuItem trayMenuRestoreLocation;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem trayMenuShowColorPicker;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripMenuItem trayMenuCheckUpdate;
        public System.Windows.Forms.ToolStripMenuItem trayMenuHistory;
        public System.Windows.Forms.ToolStripMenuItem trayMenuRestart;
        public System.Windows.Forms.Label lbColorPreview;
        public System.Windows.Forms.Label lbHsl;
        public System.Windows.Forms.Label lbHsb;
        public System.Windows.Forms.Panel pnExt;
        public System.Windows.Forms.Label lbHsi;
        public System.Windows.Forms.ToolStripMenuItem trayMenuScreenShot;
        public System.Windows.Forms.ToolStripMenuItem trayMenuScreenRecord;
        public System.Windows.Forms.ToolStripMenuItem trayMenuOpenImage;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripMenuItem trayMenuShowClipboard;

        public System.Windows.Forms.ToolStripMenuItem trayMenuSettings;
    }
}
