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
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolOK = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.pictureMask = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMask)).BeginInit();
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
            this.toolbar.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1,
            this.toolStripButton7,
            this.toolStripSeparator1,
            this.toolOK,
            this.toolSave,
            this.toolCancel});
            this.toolbar.Location = new System.Drawing.Point(108, 301);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(655, 36);
            this.toolbar.TabIndex = 5;
            this.toolbar.Text = "toolStrip1";
            this.toolbar.Visible = false;
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
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(72, 33);
            this.toolStripDropDownButton2.Text = "LineType";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(75, 33);
            this.toolStripDropDownButton1.Text = "lineWidth";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(44, 33);
            this.toolStripButton7.Text = "Color";
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
            // ScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.toolbar);
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
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolOK;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.PictureBox pictureMask;
    }
}