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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbHex = new System.Windows.Forms.Label();
            this.lbRgb = new System.Windows.Forms.Label();
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.visibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followCaretToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRgbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoPinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.pnColor = new System.Windows.Forms.Panel();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.显示模式MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.固定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.跟随ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.嵌入任务栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.pnColor.SuspendLayout();
            this.pnContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHex
            // 
            this.lbHex.BackColor = System.Drawing.Color.Black;
            this.lbHex.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHex.ForeColor = System.Drawing.Color.Lime;
            this.lbHex.Location = new System.Drawing.Point(0, 0);
            this.lbHex.Name = "lbHex";
            this.lbHex.Padding = new System.Windows.Forms.Padding(2);
            this.lbHex.Size = new System.Drawing.Size(68, 20);
            this.lbHex.TabIndex = 0;
            this.lbHex.Text = "#FFFFFF";
            this.lbHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tooltip.SetToolTip(this.lbHex, "十六进制颜色值，快速复制：Alt+C");
            this.lbHex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // lbRgb
            // 
            this.lbRgb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRgb.BackColor = System.Drawing.Color.Black;
            this.lbRgb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRgb.ForeColor = System.Drawing.Color.Lime;
            this.lbRgb.Location = new System.Drawing.Point(389, 0);
            this.lbRgb.Name = "lbRgb";
            this.lbRgb.Padding = new System.Windows.Forms.Padding(2);
            this.lbRgb.Size = new System.Drawing.Size(140, 20);
            this.lbRgb.TabIndex = 0;
            this.lbRgb.Text = "RGB(255,255,255)";
            this.lbRgb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tooltip.SetToolTip(this.lbRgb, "RGB通道颜色值，快速复制：Alt+G");
            this.lbRgb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // tray
            // 
            this.tray.BalloonTipText = "屏幕取色器正在工作";
            this.tray.BalloonTipTitle = "赏色";
            this.tray.ContextMenuStrip = this.contextMenu;
            this.tray.Icon = ((System.Drawing.Icon)(resources.GetObject("tray.Icon")));
            this.tray.Text = "赏色-取色器";
            this.tray.Visible = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visibleToolStripMenuItem,
            this.followCaretToolStripMenuItem,
            this.显示模式MToolStripMenuItem,
            this.showRgbToolStripMenuItem,
            this.toolStripSeparator2,
            this.restoreLocationToolStripMenuItem,
            this.autoPinToolStripMenuItem,
            this.autoStartToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "trayMenu";
            this.contextMenu.Size = new System.Drawing.Size(194, 236);
            // 
            // visibleToolStripMenuItem
            // 
            this.visibleToolStripMenuItem.Checked = true;
            this.visibleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visibleToolStripMenuItem.Name = "visibleToolStripMenuItem";
            this.visibleToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.visibleToolStripMenuItem.Text = "窗口可见(Alt+H)";
            this.visibleToolStripMenuItem.Click += new System.EventHandler(this.toggleVisible);
            // 
            // followCaretToolStripMenuItem
            // 
            this.followCaretToolStripMenuItem.Name = "followCaretToolStripMenuItem";
            this.followCaretToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.followCaretToolStripMenuItem.Text = "启动跟随模式(Alt+F1)";
            this.followCaretToolStripMenuItem.Click += new System.EventHandler(this.followCaretToolStripMenuItem_Click);
            // 
            // showRgbToolStripMenuItem
            // 
            this.showRgbToolStripMenuItem.Name = "showRgbToolStripMenuItem";
            this.showRgbToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.showRgbToolStripMenuItem.Text = "显示RGB通道值(&R)";
            this.showRgbToolStripMenuItem.Click += new System.EventHandler(this.showRgbToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // restoreLocationToolStripMenuItem
            // 
            this.restoreLocationToolStripMenuItem.Name = "restoreLocationToolStripMenuItem";
            this.restoreLocationToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.restoreLocationToolStripMenuItem.Text = "重置窗口位置(&L)";
            this.restoreLocationToolStripMenuItem.Click += new System.EventHandler(this.restoreLocationToolStripMenuItem_Click);
            // 
            // autoPinToolStripMenuItem
            // 
            this.autoPinToolStripMenuItem.Checked = true;
            this.autoPinToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoPinToolStripMenuItem.Name = "autoPinToolStripMenuItem";
            this.autoPinToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.autoPinToolStripMenuItem.Text = "边缘自动吸附(&P)";
            this.autoPinToolStripMenuItem.Click += new System.EventHandler(this.autoPinToolStripMenuItem_Click);
            // 
            // autoStartToolStripMenuItem
            // 
            this.autoStartToolStripMenuItem.Name = "autoStartToolStripMenuItem";
            this.autoStartToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.autoStartToolStripMenuItem.Text = "开机启动(&B)";
            this.autoStartToolStripMenuItem.Click += new System.EventHandler(this.autoStartToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutToolStripMenuItem.Text = "关于(&A)";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "退出(&E)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnColor
            // 
            this.pnColor.BackColor = System.Drawing.Color.White;
            this.pnColor.Controls.Add(this.lbHex);
            this.pnColor.Location = new System.Drawing.Point(0, 0);
            this.pnColor.Name = "pnColor";
            this.pnColor.Size = new System.Drawing.Size(88, 20);
            this.pnColor.TabIndex = 1;
            // 
            // pnContainer
            // 
            this.pnContainer.Controls.Add(this.lbRgb);
            this.pnContainer.Controls.Add(this.pnColor);
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(529, 289);
            this.pnContainer.TabIndex = 2;
            // 
            // 显示模式MToolStripMenuItem
            // 
            this.显示模式MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.隐藏ToolStripMenuItem,
            this.固定ToolStripMenuItem,
            this.跟随ToolStripMenuItem,
            this.嵌入任务栏ToolStripMenuItem});
            this.显示模式MToolStripMenuItem.Name = "显示模式MToolStripMenuItem";
            this.显示模式MToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.显示模式MToolStripMenuItem.Text = "窗口可见(Alt+H)";
            // 
            // 隐藏ToolStripMenuItem
            // 
            this.隐藏ToolStripMenuItem.Name = "隐藏ToolStripMenuItem";
            this.隐藏ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.隐藏ToolStripMenuItem.Text = "隐藏窗口";
            // 
            // 固定ToolStripMenuItem
            // 
            this.固定ToolStripMenuItem.Name = "固定ToolStripMenuItem";
            this.固定ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.固定ToolStripMenuItem.Text = "屏幕固定位置";
            // 
            // 跟随ToolStripMenuItem
            // 
            this.跟随ToolStripMenuItem.Name = "跟随ToolStripMenuItem";
            this.跟随ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.跟随ToolStripMenuItem.Text = "跟随光标";
            // 
            // 嵌入任务栏ToolStripMenuItem
            // 
            this.嵌入任务栏ToolStripMenuItem.Name = "嵌入任务栏ToolStripMenuItem";
            this.嵌入任务栏ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.嵌入任务栏ToolStripMenuItem.Text = "嵌入任务栏";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 289);
            this.ControlBox = false;
            this.Controls.Add(this.pnContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "赏色";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            this.contextMenu.ResumeLayout(false);
            this.pnColor.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbRgb;
        private System.Windows.Forms.Label lbHex;
        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoPinToolStripMenuItem;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.ToolStripMenuItem showRgbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followCaretToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem autoStartToolStripMenuItem;
        private System.Windows.Forms.Panel pnColor;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.ToolStripMenuItem 显示模式MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 固定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 跟随ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 嵌入任务栏ToolStripMenuItem;
    }
}

