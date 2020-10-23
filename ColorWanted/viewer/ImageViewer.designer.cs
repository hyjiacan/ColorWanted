namespace ColorWanted.viewer
{
    partial class ImageViewer
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewer));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lbTip = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBorder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCenterLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeBar = new System.Windows.Forms.TrackBar();
            this.lbRange = new System.Windows.Forms.Label();
            this.pnBar = new System.Windows.Forms.Panel();
            this.btnBgColor = new System.Windows.Forms.Button();
            this.lkNext = new System.Windows.Forms.Button();
            this.lkPrev = new System.Windows.Forms.Button();
            this.lbPicIndex = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.pnContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rangeBar)).BeginInit();
            this.pnBar.SuspendLayout();
            this.pnContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(125, 94);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 50);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // lbTip
            // 
            this.lbTip.AutoSize = true;
            this.lbTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbTip.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbTip.Location = new System.Drawing.Point(228, 103);
            this.lbTip.Name = "lbTip";
            this.lbTip.Padding = new System.Windows.Forms.Padding(2);
            this.lbTip.Size = new System.Drawing.Size(4, 16);
            this.lbTip.TabIndex = 7;
            this.lbTip.Visible = false;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Gray;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuPaste,
            this.toolStripSeparator1,
            this.menuBorder,
            this.menuCenterLine,
            this.toolStripSeparator3,
            this.menuReset,
            this.toolStripSeparator2,
            this.menuDelete});
            this.menu.Name = "menu";
            this.menu.ShowItemToolTips = false;
            this.menu.Size = new System.Drawing.Size(168, 154);
            // 
            // menuOpen
            // 
            this.menuOpen.ForeColor = System.Drawing.Color.White;
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpen.Size = new System.Drawing.Size(167, 22);
            this.menuOpen.Text = "打开";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.BackColor = System.Drawing.Color.Gray;
            this.menuPaste.ForeColor = System.Drawing.Color.White;
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuPaste.Size = new System.Drawing.Size(167, 22);
            this.menuPaste.Text = "粘贴";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // menuBorder
            // 
            this.menuBorder.ForeColor = System.Drawing.Color.White;
            this.menuBorder.Name = "menuBorder";
            this.menuBorder.Size = new System.Drawing.Size(167, 22);
            this.menuBorder.Text = "边框";
            this.menuBorder.ToolTipText = "是否显示区域边框";
            this.menuBorder.Click += new System.EventHandler(this.menuBorder_Click);
            // 
            // menuCenterLine
            // 
            this.menuCenterLine.ForeColor = System.Drawing.Color.White;
            this.menuCenterLine.Name = "menuCenterLine";
            this.menuCenterLine.Size = new System.Drawing.Size(167, 22);
            this.menuCenterLine.Text = "中心标线";
            this.menuCenterLine.ToolTipText = "是否显示光标中心点标线";
            this.menuCenterLine.Click += new System.EventHandler(this.menuCenterLine_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // menuReset
            // 
            this.menuReset.ForeColor = System.Drawing.Color.White;
            this.menuReset.Name = "menuReset";
            this.menuReset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuReset.Size = new System.Drawing.Size(167, 22);
            this.menuReset.Text = "重置位置";
            this.menuReset.Click += new System.EventHandler(this.menuReset_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // menuDelete
            // 
            this.menuDelete.BackColor = System.Drawing.Color.Gray;
            this.menuDelete.ForeColor = System.Drawing.Color.White;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuDelete.Size = new System.Drawing.Size(167, 22);
            this.menuDelete.Text = "清除";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "允许色差";
            this.tooltip.SetToolTip(this.label1, "将小于此色差的颜色认为是相同的范围。以 255 为基数。");
            // 
            // rangeBar
            // 
            this.rangeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rangeBar.AutoSize = false;
            this.rangeBar.Location = new System.Drawing.Point(61, 6);
            this.rangeBar.Maximum = 64;
            this.rangeBar.Name = "rangeBar";
            this.rangeBar.Size = new System.Drawing.Size(104, 24);
            this.rangeBar.TabIndex = 11;
            this.rangeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tooltip.SetToolTip(this.rangeBar, "允许的色差范围，值越大，允许的色差越大");
            this.rangeBar.Value = 3;
            this.rangeBar.Scroll += new System.EventHandler(this.rangeBar_Scroll);
            // 
            // lbRange
            // 
            this.lbRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRange.AutoSize = true;
            this.lbRange.Location = new System.Drawing.Point(164, 11);
            this.lbRange.Name = "lbRange";
            this.lbRange.Size = new System.Drawing.Size(11, 12);
            this.lbRange.TabIndex = 12;
            this.lbRange.Text = "3";
            // 
            // pnBar
            // 
            this.pnBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pnBar.Controls.Add(this.btnBgColor);
            this.pnBar.Controls.Add(this.lkNext);
            this.pnBar.Controls.Add(this.lkPrev);
            this.pnBar.Controls.Add(this.lbPicIndex);
            this.pnBar.Controls.Add(this.rangeBar);
            this.pnBar.Controls.Add(this.lbRange);
            this.pnBar.Controls.Add(this.label1);
            this.pnBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnBar.Location = new System.Drawing.Point(0, 529);
            this.pnBar.Name = "pnBar";
            this.pnBar.Size = new System.Drawing.Size(784, 32);
            this.pnBar.TabIndex = 15;
            // 
            // btnBgColor
            // 
            this.btnBgColor.BackColor = System.Drawing.SystemColors.Control;
            this.btnBgColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBgColor.Location = new System.Drawing.Point(349, 9);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(16, 17);
            this.btnBgColor.TabIndex = 18;
            this.tooltip.SetToolTip(this.btnBgColor, "更改背景色");
            this.btnBgColor.UseVisualStyleBackColor = false;
            this.btnBgColor.Click += new System.EventHandler(this.btnBgColor_Click);
            // 
            // lkNext
            // 
            this.lkNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lkNext.Location = new System.Drawing.Point(302, 5);
            this.lkNext.Name = "lkNext";
            this.lkNext.Size = new System.Drawing.Size(29, 23);
            this.lkNext.TabIndex = 17;
            this.lkNext.Text = ">";
            this.tooltip.SetToolTip(this.lkNext, "查看下一张，快捷键: PageDown");
            this.lkNext.UseVisualStyleBackColor = true;
            this.lkNext.Click += new System.EventHandler(this.lkNext_LinkClicked);
            // 
            // lkPrev
            // 
            this.lkPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lkPrev.Location = new System.Drawing.Point(196, 5);
            this.lkPrev.Name = "lkPrev";
            this.lkPrev.Size = new System.Drawing.Size(29, 23);
            this.lkPrev.TabIndex = 17;
            this.lkPrev.Text = "<";
            this.tooltip.SetToolTip(this.lkPrev, "查看上一张，快捷键: PageUp");
            this.lkPrev.UseVisualStyleBackColor = true;
            this.lkPrev.Click += new System.EventHandler(this.lkPrev_LinkClicked);
            // 
            // lbPicIndex
            // 
            this.lbPicIndex.Location = new System.Drawing.Point(231, 5);
            this.lbPicIndex.Name = "lbPicIndex";
            this.lbPicIndex.Size = new System.Drawing.Size(65, 23);
            this.lbPicIndex.TabIndex = 16;
            this.lbPicIndex.Text = "0/0";
            this.lbPicIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnContainer
            // 
            this.pnContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pnContainer.Controls.Add(this.pictureBox);
            this.pnContainer.Controls.Add(this.lbTip);
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(784, 561);
            this.pnContainer.TabIndex = 16;
            // 
            // ImageViewer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ContextMenuStrip = this.menu;
            this.Controls.Add(this.pnBar);
            this.Controls.Add(this.pnContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ImageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片查看器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImageViewer_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageViewer_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageViewer_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.ImageViewer_DragOver);
            this.DragLeave += new System.EventHandler(this.ImageViewer_DragLeave);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageViewer_KeyDown);
            this.Resize += new System.EventHandler(this.ImageViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rangeBar)).EndInit();
            this.pnBar.ResumeLayout(false);
            this.pnBar.PerformLayout();
            this.pnContainer.ResumeLayout(false);
            this.pnContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lbTip;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar rangeBar;
        private System.Windows.Forms.Label lbRange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.Panel pnBar;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lbPicIndex;
        private System.Windows.Forms.Button lkNext;
        private System.Windows.Forms.Button lkPrev;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Button btnBgColor;
        private System.Windows.Forms.ToolStripMenuItem menuBorder;
        private System.Windows.Forms.ToolStripMenuItem menuCenterLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel pnContainer;
    }
}

