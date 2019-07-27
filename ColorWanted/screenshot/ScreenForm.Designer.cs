namespace ColorWanted.screenshot
{
    partial class ScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenForm));
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolText = new System.Windows.Forms.ToolStripButton();
            this.toolPen = new System.Windows.Forms.ToolStripButton();
            this.toolLine = new System.Windows.Forms.ToolStripButton();
            this.toolRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolCircle = new System.Windows.Forms.ToolStripButton();
            this.toolArrow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolOK = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.pictureMask = new System.Windows.Forms.PictureBox();
            this.toolbarColor = new System.Windows.Forms.ToolStrip();
            this.toolColorRed = new System.Windows.Forms.ToolStripButton();
            this.toolColorGreen = new System.Windows.Forms.ToolStripButton();
            this.toolColorBlue = new System.Windows.Forms.ToolStripButton();
            this.toolColorPurple = new System.Windows.Forms.ToolStripButton();
            this.toolColorBlack = new System.Windows.Forms.ToolStripButton();
            this.toolColorSelect = new System.Windows.Forms.ToolStripButton();
            this.toolbarWidth = new System.Windows.Forms.ToolStrip();
            this.toolWidth1 = new System.Windows.Forms.ToolStripButton();
            this.toolWidth2 = new System.Windows.Forms.ToolStripButton();
            this.toolWidth4 = new System.Windows.Forms.ToolStripButton();
            this.toolPanel = new System.Windows.Forms.Panel();
            this.toolbarExtPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolbarStyle = new System.Windows.Forms.ToolStrip();
            this.toolStyleSolid = new System.Windows.Forms.ToolStripButton();
            this.toolStyleDotted = new System.Windows.Forms.ToolStripButton();
            this.toolStyleDashed = new System.Windows.Forms.ToolStripButton();
            this.toolbarTextStyle = new System.Windows.Forms.ToolStrip();
            this.toolTextStyle = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMask)).BeginInit();
            this.toolbarColor.SuspendLayout();
            this.toolbarWidth.SuspendLayout();
            this.toolPanel.SuspendLayout();
            this.toolbarExtPanel.SuspendLayout();
            this.toolbarStyle.SuspendLayout();
            this.toolbarTextStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // picturePreview
            // 
            this.picturePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePreview.Location = new System.Drawing.Point(0, 0);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(800, 450);
            this.picturePreview.TabIndex = 0;
            this.picturePreview.TabStop = false;
            this.picturePreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicturePreview_MouseDown);
            this.picturePreview.MouseLeave += new System.EventHandler(this.PicturePreview_MouseLeave);
            this.picturePreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicturePreview_MouseMove);
            this.picturePreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicturePreview_MouseUp);
            // 
            // toolbar
            // 
            this.toolbar.AutoSize = false;
            this.toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolText,
            this.toolPen,
            this.toolLine,
            this.toolRectangle,
            this.toolEllipse,
            this.toolCircle,
            this.toolArrow,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.toolOK,
            this.toolSave,
            this.toolCancel});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(439, 36);
            this.toolbar.TabIndex = 5;
            this.toolbar.Text = "toolStrip1";
            this.toolbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Toolbar_ItemClicked);
            // 
            // toolText
            // 
            this.toolText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolText.Image = ((System.Drawing.Image)(resources.GetObject("toolText.Image")));
            this.toolText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolText.Name = "toolText";
            this.toolText.Size = new System.Drawing.Size(36, 33);
            this.toolText.Tag = "Text";
            this.toolText.Text = "Text";
            // 
            // toolPen
            // 
            this.toolPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPen.Image = ((System.Drawing.Image)(resources.GetObject("toolPen.Image")));
            this.toolPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPen.Name = "toolPen";
            this.toolPen.Size = new System.Drawing.Size(33, 33);
            this.toolPen.Tag = "Pen";
            this.toolPen.Text = "Pen";
            // 
            // toolLine
            // 
            this.toolLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLine.Image = ((System.Drawing.Image)(resources.GetObject("toolLine.Image")));
            this.toolLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLine.Name = "toolLine";
            this.toolLine.Size = new System.Drawing.Size(35, 33);
            this.toolLine.Tag = "Line";
            this.toolLine.Text = "Line";
            // 
            // toolRectangle
            // 
            this.toolRectangle.Checked = true;
            this.toolRectangle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolRectangle.Image = ((System.Drawing.Image)(resources.GetObject("toolRectangle.Image")));
            this.toolRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRectangle.Name = "toolRectangle";
            this.toolRectangle.Size = new System.Drawing.Size(37, 33);
            this.toolRectangle.Tag = "Rectangle";
            this.toolRectangle.Text = "Rect";
            // 
            // toolEllipse
            // 
            this.toolEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolEllipse.Image = ((System.Drawing.Image)(resources.GetObject("toolEllipse.Image")));
            this.toolEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEllipse.Name = "toolEllipse";
            this.toolEllipse.Size = new System.Drawing.Size(49, 33);
            this.toolEllipse.Tag = "Ellipse";
            this.toolEllipse.Text = "Ellipse";
            // 
            // toolCircle
            // 
            this.toolCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCircle.Image = ((System.Drawing.Image)(resources.GetObject("toolCircle.Image")));
            this.toolCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCircle.Name = "toolCircle";
            this.toolCircle.Size = new System.Drawing.Size(44, 33);
            this.toolCircle.Tag = "Circle";
            this.toolCircle.Text = "Circle";
            // 
            // toolArrow
            // 
            this.toolArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolArrow.Image = ((System.Drawing.Image)(resources.GetObject("toolArrow.Image")));
            this.toolArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolArrow.Name = "toolArrow";
            this.toolArrow.Size = new System.Drawing.Size(47, 33);
            this.toolArrow.Tag = "Arrow";
            this.toolArrow.Text = "Arrow";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // toolOK
            // 
            this.toolOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolOK.Image = ((System.Drawing.Image)(resources.GetObject("toolOK.Image")));
            this.toolOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOK.Name = "toolOK";
            this.toolOK.Size = new System.Drawing.Size(30, 33);
            this.toolOK.Text = "OK";
            this.toolOK.Click += new System.EventHandler(this.ToolOK_Click);
            // 
            // toolSave
            // 
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(39, 33);
            this.toolSave.Text = "Save";
            this.toolSave.Click += new System.EventHandler(this.ToolSave_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(50, 33);
            this.toolCancel.Text = "Cancel";
            this.toolCancel.Click += new System.EventHandler(this.ToolCancel_Click);
            // 
            // pictureMask
            // 
            this.pictureMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureMask.Location = new System.Drawing.Point(0, 0);
            this.pictureMask.Name = "pictureMask";
            this.pictureMask.Size = new System.Drawing.Size(800, 450);
            this.pictureMask.TabIndex = 6;
            this.pictureMask.TabStop = false;
            this.pictureMask.Visible = false;
            // 
            // toolbarColor
            // 
            this.toolbarColor.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbarColor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolColorRed,
            this.toolColorGreen,
            this.toolColorBlue,
            this.toolColorPurple,
            this.toolColorBlack,
            this.toolColorSelect});
            this.toolbarColor.Location = new System.Drawing.Point(264, 0);
            this.toolbarColor.Name = "toolbarColor";
            this.toolbarColor.Size = new System.Drawing.Size(163, 25);
            this.toolbarColor.TabIndex = 7;
            this.toolbarColor.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolbarColor_ItemClicked);
            // 
            // toolColorRed
            // 
            this.toolColorRed.AutoSize = false;
            this.toolColorRed.BackColor = System.Drawing.Color.Red;
            this.toolColorRed.Checked = true;
            this.toolColorRed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolColorRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolColorRed.ForeColor = System.Drawing.Color.Red;
            this.toolColorRed.Image = ((System.Drawing.Image)(resources.GetObject("toolColorRed.Image")));
            this.toolColorRed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColorRed.Name = "toolColorRed";
            this.toolColorRed.Size = new System.Drawing.Size(23, 22);
            // 
            // toolColorGreen
            // 
            this.toolColorGreen.AutoSize = false;
            this.toolColorGreen.BackColor = System.Drawing.Color.Green;
            this.toolColorGreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolColorGreen.ForeColor = System.Drawing.Color.Green;
            this.toolColorGreen.Image = ((System.Drawing.Image)(resources.GetObject("toolColorGreen.Image")));
            this.toolColorGreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColorGreen.Name = "toolColorGreen";
            this.toolColorGreen.Size = new System.Drawing.Size(23, 22);
            // 
            // toolColorBlue
            // 
            this.toolColorBlue.AutoSize = false;
            this.toolColorBlue.BackColor = System.Drawing.Color.Blue;
            this.toolColorBlue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolColorBlue.ForeColor = System.Drawing.Color.Blue;
            this.toolColorBlue.Image = ((System.Drawing.Image)(resources.GetObject("toolColorBlue.Image")));
            this.toolColorBlue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColorBlue.Name = "toolColorBlue";
            this.toolColorBlue.Size = new System.Drawing.Size(23, 22);
            // 
            // toolColorPurple
            // 
            this.toolColorPurple.AutoSize = false;
            this.toolColorPurple.BackColor = System.Drawing.Color.Purple;
            this.toolColorPurple.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolColorPurple.ForeColor = System.Drawing.Color.Purple;
            this.toolColorPurple.Image = ((System.Drawing.Image)(resources.GetObject("toolColorPurple.Image")));
            this.toolColorPurple.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColorPurple.Name = "toolColorPurple";
            this.toolColorPurple.Size = new System.Drawing.Size(23, 22);
            // 
            // toolColorBlack
            // 
            this.toolColorBlack.AutoSize = false;
            this.toolColorBlack.BackColor = System.Drawing.Color.Black;
            this.toolColorBlack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolColorBlack.ForeColor = System.Drawing.Color.Black;
            this.toolColorBlack.Image = ((System.Drawing.Image)(resources.GetObject("toolColorBlack.Image")));
            this.toolColorBlack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColorBlack.Name = "toolColorBlack";
            this.toolColorBlack.Size = new System.Drawing.Size(23, 22);
            // 
            // toolColorSelect
            // 
            this.toolColorSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolColorSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolColorSelect.Image")));
            this.toolColorSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColorSelect.Name = "toolColorSelect";
            this.toolColorSelect.Size = new System.Drawing.Size(36, 22);
            this.toolColorSelect.Tag = "customize";
            this.toolColorSelect.Text = "选择";
            // 
            // toolbarWidth
            // 
            this.toolbarWidth.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbarWidth.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolWidth1,
            this.toolWidth2,
            this.toolWidth4});
            this.toolbarWidth.Location = new System.Drawing.Point(132, 0);
            this.toolbarWidth.Name = "toolbarWidth";
            this.toolbarWidth.Size = new System.Drawing.Size(132, 25);
            this.toolbarWidth.TabIndex = 8;
            this.toolbarWidth.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolbarWidth_ItemClicked);
            // 
            // toolWidth1
            // 
            this.toolWidth1.AutoSize = false;
            this.toolWidth1.Checked = true;
            this.toolWidth1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolWidth1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolWidth1.Image = ((System.Drawing.Image)(resources.GetObject("toolWidth1.Image")));
            this.toolWidth1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolWidth1.Name = "toolWidth1";
            this.toolWidth1.Size = new System.Drawing.Size(40, 22);
            this.toolWidth1.Tag = "1";
            this.toolWidth1.Text = "细";
            // 
            // toolWidth2
            // 
            this.toolWidth2.AutoSize = false;
            this.toolWidth2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolWidth2.Image = ((System.Drawing.Image)(resources.GetObject("toolWidth2.Image")));
            this.toolWidth2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolWidth2.Name = "toolWidth2";
            this.toolWidth2.Size = new System.Drawing.Size(40, 22);
            this.toolWidth2.Tag = "2";
            this.toolWidth2.Text = "中";
            // 
            // toolWidth4
            // 
            this.toolWidth4.AutoSize = false;
            this.toolWidth4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolWidth4.Image = ((System.Drawing.Image)(resources.GetObject("toolWidth4.Image")));
            this.toolWidth4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolWidth4.Name = "toolWidth4";
            this.toolWidth4.Size = new System.Drawing.Size(40, 22);
            this.toolWidth4.Tag = "4";
            this.toolWidth4.Text = "粗";
            // 
            // toolPanel
            // 
            this.toolPanel.AutoSize = true;
            this.toolPanel.Controls.Add(this.toolbarExtPanel);
            this.toolPanel.Controls.Add(this.toolbar);
            this.toolPanel.Location = new System.Drawing.Point(12, 197);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(798, 67);
            this.toolPanel.TabIndex = 9;
            this.toolPanel.Visible = false;
            // 
            // toolbarExtPanel
            // 
            this.toolbarExtPanel.AutoSize = true;
            this.toolbarExtPanel.Controls.Add(this.toolbarStyle);
            this.toolbarExtPanel.Controls.Add(this.toolbarWidth);
            this.toolbarExtPanel.Controls.Add(this.toolbarColor);
            this.toolbarExtPanel.Controls.Add(this.toolbarTextStyle);
            this.toolbarExtPanel.Location = new System.Drawing.Point(3, 39);
            this.toolbarExtPanel.Name = "toolbarExtPanel";
            this.toolbarExtPanel.Size = new System.Drawing.Size(792, 25);
            this.toolbarExtPanel.TabIndex = 10;
            // 
            // toolbarStyle
            // 
            this.toolbarStyle.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbarStyle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStyleSolid,
            this.toolStyleDotted,
            this.toolStyleDashed});
            this.toolbarStyle.Location = new System.Drawing.Point(0, 0);
            this.toolbarStyle.Name = "toolbarStyle";
            this.toolbarStyle.Size = new System.Drawing.Size(132, 25);
            this.toolbarStyle.TabIndex = 9;
            this.toolbarStyle.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolbarStyle_ItemClicked);
            // 
            // toolStyleSolid
            // 
            this.toolStyleSolid.AutoSize = false;
            this.toolStyleSolid.Checked = true;
            this.toolStyleSolid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStyleSolid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStyleSolid.Image = ((System.Drawing.Image)(resources.GetObject("toolStyleSolid.Image")));
            this.toolStyleSolid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStyleSolid.Name = "toolStyleSolid";
            this.toolStyleSolid.Size = new System.Drawing.Size(40, 22);
            this.toolStyleSolid.Tag = "Solid";
            this.toolStyleSolid.Text = "实线";
            // 
            // toolStyleDotted
            // 
            this.toolStyleDotted.AutoSize = false;
            this.toolStyleDotted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStyleDotted.Image = ((System.Drawing.Image)(resources.GetObject("toolStyleDotted.Image")));
            this.toolStyleDotted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStyleDotted.Name = "toolStyleDotted";
            this.toolStyleDotted.Size = new System.Drawing.Size(40, 22);
            this.toolStyleDotted.Tag = "Dotted";
            this.toolStyleDotted.Text = "点线";
            // 
            // toolStyleDashed
            // 
            this.toolStyleDashed.AutoSize = false;
            this.toolStyleDashed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStyleDashed.Image = ((System.Drawing.Image)(resources.GetObject("toolStyleDashed.Image")));
            this.toolStyleDashed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStyleDashed.Name = "toolStyleDashed";
            this.toolStyleDashed.Size = new System.Drawing.Size(40, 22);
            this.toolStyleDashed.Tag = "Dashed";
            this.toolStyleDashed.Text = "虚线";
            // 
            // toolbarTextStyle
            // 
            this.toolbarTextStyle.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbarTextStyle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTextStyle});
            this.toolbarTextStyle.Location = new System.Drawing.Point(427, 0);
            this.toolbarTextStyle.Name = "toolbarTextStyle";
            this.toolbarTextStyle.Size = new System.Drawing.Size(103, 25);
            this.toolbarTextStyle.TabIndex = 10;
            // 
            // toolTextStyle
            // 
            this.toolTextStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolTextStyle.Image = ((System.Drawing.Image)(resources.GetObject("toolTextStyle.Image")));
            this.toolTextStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTextStyle.Name = "toolTextStyle";
            this.toolTextStyle.Size = new System.Drawing.Size(60, 22);
            this.toolTextStyle.Text = "文字样式";
            this.toolTextStyle.Click += new System.EventHandler(this.ToolTextStyle_Click);
            // 
            // ScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.pictureMask);
            this.Controls.Add(this.picturePreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScreenForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenForm_FormClosing);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ScreenForm_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMask)).EndInit();
            this.toolbarColor.ResumeLayout(false);
            this.toolbarColor.PerformLayout();
            this.toolbarWidth.ResumeLayout(false);
            this.toolbarWidth.PerformLayout();
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            this.toolbarExtPanel.ResumeLayout(false);
            this.toolbarExtPanel.PerformLayout();
            this.toolbarStyle.ResumeLayout(false);
            this.toolbarStyle.PerformLayout();
            this.toolbarTextStyle.ResumeLayout(false);
            this.toolbarTextStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton toolText;
        private System.Windows.Forms.ToolStripButton toolPen;
        private System.Windows.Forms.ToolStripButton toolLine;
        private System.Windows.Forms.ToolStripButton toolRectangle;
        private System.Windows.Forms.ToolStripButton toolEllipse;
        private System.Windows.Forms.ToolStripButton toolCircle;
        private System.Windows.Forms.ToolStripButton toolArrow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolOK;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.PictureBox pictureMask;
        private System.Windows.Forms.ToolStrip toolbarColor;
        private System.Windows.Forms.ToolStripButton toolColorRed;
        private System.Windows.Forms.ToolStripButton toolColorGreen;
        private System.Windows.Forms.ToolStripButton toolColorBlue;
        private System.Windows.Forms.ToolStripButton toolColorPurple;
        private System.Windows.Forms.ToolStripButton toolColorBlack;
        private System.Windows.Forms.ToolStrip toolbarWidth;
        private System.Windows.Forms.ToolStripButton toolWidth4;
        private System.Windows.Forms.ToolStripButton toolWidth1;
        private System.Windows.Forms.ToolStripButton toolWidth2;
        private System.Windows.Forms.Panel toolPanel;
        private System.Windows.Forms.ToolStrip toolbarStyle;
        private System.Windows.Forms.ToolStripButton toolStyleSolid;
        private System.Windows.Forms.ToolStripButton toolStyleDotted;
        private System.Windows.Forms.ToolStripButton toolStyleDashed;
        private System.Windows.Forms.FlowLayoutPanel toolbarExtPanel;
        private System.Windows.Forms.ToolStrip toolbarTextStyle;
        private System.Windows.Forms.ToolStripButton toolTextStyle;
        private System.Windows.Forms.ToolStripButton toolColorSelect;
    }
}