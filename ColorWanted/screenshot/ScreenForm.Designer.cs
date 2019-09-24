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
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolText = new System.Windows.Forms.ToolStripButton();
            this.toolCurve = new System.Windows.Forms.ToolStripButton();
            this.toolLine = new System.Windows.Forms.ToolStripButton();
            this.toolRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolArrow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolOK = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolbarColor = new System.Windows.Forms.ToolStrip();
            this.toolColorRed = new System.Windows.Forms.ToolStripButton();
            this.toolColorGreen = new System.Windows.Forms.ToolStripButton();
            this.toolColorBlue = new System.Windows.Forms.ToolStripButton();
            this.toolColorPurple = new System.Windows.Forms.ToolStripButton();
            this.toolColorBlack = new System.Windows.Forms.ToolStripButton();
            this.toolColorSelect = new System.Windows.Forms.ToolStripButton();
            this.toolPanel = new System.Windows.Forms.Panel();
            this.toolbarExtPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolbarLineType = new System.Windows.Forms.ToolStrip();
            this.toolStyleSolid = new System.Windows.Forms.ToolStripButton();
            this.toolStyleDotted = new System.Windows.Forms.ToolStripButton();
            this.toolStyleDashed = new System.Windows.Forms.ToolStripButton();
            this.toolLineWidth = new System.Windows.Forms.TrackBar();
            this.toolbarTextStyle = new System.Windows.Forms.ToolStrip();
            this.toolTextStyle = new System.Windows.Forms.ToolStripButton();
            this.toolbarMask = new System.Windows.Forms.ToolStrip();
            this.toolMaskEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolMaskSave = new System.Windows.Forms.ToolStripButton();
            this.toolMaskOK = new System.Windows.Forms.ToolStripButton();
            this.toolMaskCancel = new System.Windows.Forms.ToolStripButton();
            this.editorContainer = new System.Windows.Forms.Integration.ElementHost();
            this.editor = new ColorWanted.screenshot.ImageEditor();
            this.toolbar.SuspendLayout();
            this.toolbarColor.SuspendLayout();
            this.toolPanel.SuspendLayout();
            this.toolbarExtPanel.SuspendLayout();
            this.toolbarLineType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolLineWidth)).BeginInit();
            this.toolbarTextStyle.SuspendLayout();
            this.toolbarMask.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolText,
            this.toolCurve,
            this.toolLine,
            this.toolRectangle,
            this.toolEllipse,
            this.toolArrow,
            this.toolStripSeparator2,
            this.toolSave,
            this.toolOK,
            this.toolCancel});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(225, 25);
            this.toolbar.TabIndex = 5;
            this.toolbar.Text = "toolStrip1";
            this.toolbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Toolbar_ItemClicked);
            // 
            // toolText
            // 
            this.toolText.AutoSize = false;
            this.toolText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolText.Image = global::ColorWanted.Properties.Resources.text;
            this.toolText.Name = "toolText";
            this.toolText.Size = new System.Drawing.Size(23, 22);
            this.toolText.Tag = "Text";
            // 
            // toolCurve
            // 
            this.toolCurve.AutoSize = false;
            this.toolCurve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCurve.Image = global::ColorWanted.Properties.Resources.curve;
            this.toolCurve.Name = "toolCurve";
            this.toolCurve.Size = new System.Drawing.Size(23, 22);
            this.toolCurve.Tag = "Curve";
            // 
            // toolLine
            // 
            this.toolLine.AutoSize = false;
            this.toolLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLine.Image = global::ColorWanted.Properties.Resources.line;
            this.toolLine.Name = "toolLine";
            this.toolLine.Size = new System.Drawing.Size(23, 22);
            this.toolLine.Tag = "Line";
            // 
            // toolRectangle
            // 
            this.toolRectangle.Checked = true;
            this.toolRectangle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRectangle.Image = global::ColorWanted.Properties.Resources.rect;
            this.toolRectangle.Name = "toolRectangle";
            this.toolRectangle.Size = new System.Drawing.Size(23, 22);
            this.toolRectangle.Tag = "Rectangle";
            // 
            // toolEllipse
            // 
            this.toolEllipse.AutoSize = false;
            this.toolEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEllipse.Image = global::ColorWanted.Properties.Resources.ellipse;
            this.toolEllipse.Name = "toolEllipse";
            this.toolEllipse.Size = new System.Drawing.Size(23, 22);
            this.toolEllipse.Tag = "Ellipse";
            // 
            // toolArrow
            // 
            this.toolArrow.AutoSize = false;
            this.toolArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolArrow.Image = global::ColorWanted.Properties.Resources.arrow;
            this.toolArrow.Name = "toolArrow";
            this.toolArrow.Size = new System.Drawing.Size(23, 22);
            this.toolArrow.Tag = "Arrow";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolSave
            // 
            this.toolSave.AutoSize = false;
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSave.Image = global::ColorWanted.Properties.Resources.save;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(23, 22);
            this.toolSave.Click += new System.EventHandler(this.ToolSave_Click);
            // 
            // toolOK
            // 
            this.toolOK.AutoSize = false;
            this.toolOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOK.Image = global::ColorWanted.Properties.Resources.ok;
            this.toolOK.Name = "toolOK";
            this.toolOK.Size = new System.Drawing.Size(23, 22);
            this.toolOK.Click += new System.EventHandler(this.ToolOK_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.AutoSize = false;
            this.toolCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCancel.Image = global::ColorWanted.Properties.Resources.cancel;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(23, 22);
            this.toolCancel.Click += new System.EventHandler(this.ToolCancel_Click);
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
            this.toolbarColor.Location = new System.Drawing.Point(212, 0);
            this.toolbarColor.Name = "toolbarColor";
            this.toolbarColor.Size = new System.Drawing.Size(150, 25);
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
            this.toolColorBlack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColorBlack.Name = "toolColorBlack";
            this.toolColorBlack.Size = new System.Drawing.Size(23, 22);
            // 
            // toolColorSelect
            // 
            this.toolColorSelect.AutoSize = false;
            this.toolColorSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolColorSelect.Image = global::ColorWanted.Properties.Resources.picker;
            this.toolColorSelect.Name = "toolColorSelect";
            this.toolColorSelect.Size = new System.Drawing.Size(23, 22);
            this.toolColorSelect.Tag = "customize";
            // 
            // toolPanel
            // 
            this.toolPanel.AutoSize = true;
            this.toolPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolPanel.Controls.Add(this.toolbarExtPanel);
            this.toolPanel.Controls.Add(this.toolbar);
            this.toolPanel.Location = new System.Drawing.Point(12, 197);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(372, 67);
            this.toolPanel.TabIndex = 9;
            this.toolPanel.Visible = false;
            // 
            // toolbarExtPanel
            // 
            this.toolbarExtPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolbarExtPanel.Controls.Add(this.toolbarLineType);
            this.toolbarExtPanel.Controls.Add(this.toolLineWidth);
            this.toolbarExtPanel.Controls.Add(this.toolbarColor);
            this.toolbarExtPanel.Controls.Add(this.toolbarTextStyle);
            this.toolbarExtPanel.Location = new System.Drawing.Point(3, 39);
            this.toolbarExtPanel.Name = "toolbarExtPanel";
            this.toolbarExtPanel.Size = new System.Drawing.Size(366, 25);
            this.toolbarExtPanel.TabIndex = 10;
            // 
            // toolbarLineType
            // 
            this.toolbarLineType.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbarLineType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStyleSolid,
            this.toolStyleDotted,
            this.toolStyleDashed});
            this.toolbarLineType.Location = new System.Drawing.Point(0, 0);
            this.toolbarLineType.Name = "toolbarLineType";
            this.toolbarLineType.Size = new System.Drawing.Size(132, 25);
            this.toolbarLineType.TabIndex = 9;
            this.toolbarLineType.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolbarLineType_ItemClicked);
            // 
            // toolStyleSolid
            // 
            this.toolStyleSolid.AutoSize = false;
            this.toolStyleSolid.Checked = true;
            this.toolStyleSolid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStyleSolid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStyleSolid.Image = global::ColorWanted.Properties.Resources.solid_line;
            this.toolStyleSolid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStyleSolid.Name = "toolStyleSolid";
            this.toolStyleSolid.Size = new System.Drawing.Size(40, 22);
            this.toolStyleSolid.Tag = "Solid";
            // 
            // toolStyleDotted
            // 
            this.toolStyleDotted.AutoSize = false;
            this.toolStyleDotted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStyleDotted.Image = global::ColorWanted.Properties.Resources.dot_line;
            this.toolStyleDotted.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStyleDotted.Name = "toolStyleDotted";
            this.toolStyleDotted.Size = new System.Drawing.Size(40, 22);
            this.toolStyleDotted.Tag = "Dotted";
            // 
            // toolStyleDashed
            // 
            this.toolStyleDashed.AutoSize = false;
            this.toolStyleDashed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStyleDashed.Image = global::ColorWanted.Properties.Resources.dash_line;
            this.toolStyleDashed.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStyleDashed.Name = "toolStyleDashed";
            this.toolStyleDashed.Size = new System.Drawing.Size(40, 22);
            this.toolStyleDashed.Tag = "Dashed";
            // 
            // toolLineWidth
            // 
            this.toolLineWidth.AutoSize = false;
            this.toolLineWidth.LargeChange = 2;
            this.toolLineWidth.Location = new System.Drawing.Point(135, 3);
            this.toolLineWidth.Maximum = 32;
            this.toolLineWidth.Minimum = 1;
            this.toolLineWidth.Name = "toolLineWidth";
            this.toolLineWidth.Size = new System.Drawing.Size(74, 22);
            this.toolLineWidth.TabIndex = 11;
            this.toolLineWidth.TickFrequency = 4;
            this.toolLineWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolLineWidth.Value = 2;
            this.toolLineWidth.Scroll += new System.EventHandler(this.ToolLineWidth_Scroll);
            // 
            // toolbarTextStyle
            // 
            this.toolbarTextStyle.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbarTextStyle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTextStyle});
            this.toolbarTextStyle.Location = new System.Drawing.Point(0, 28);
            this.toolbarTextStyle.Name = "toolbarTextStyle";
            this.toolbarTextStyle.Size = new System.Drawing.Size(66, 25);
            this.toolbarTextStyle.TabIndex = 10;
            this.toolbarTextStyle.Visible = false;
            // 
            // toolTextStyle
            // 
            this.toolTextStyle.AutoSize = false;
            this.toolTextStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolTextStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.toolTextStyle.Image = global::ColorWanted.Properties.Resources.font;
            this.toolTextStyle.Name = "toolTextStyle";
            this.toolTextStyle.Size = new System.Drawing.Size(23, 22);
            this.toolTextStyle.Click += new System.EventHandler(this.ToolTextStyle_Click);
            // 
            // toolbarMask
            // 
            this.toolbarMask.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbarMask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMaskEdit,
            this.toolStripSeparator1,
            this.toolMaskSave,
            this.toolMaskOK,
            this.toolMaskCancel});
            this.toolbarMask.Location = new System.Drawing.Point(110, 301);
            this.toolbarMask.Name = "toolbarMask";
            this.toolbarMask.Size = new System.Drawing.Size(110, 25);
            this.toolbarMask.TabIndex = 11;
            this.toolbarMask.Visible = false;
            // 
            // toolMaskEdit
            // 
            this.toolMaskEdit.AutoSize = false;
            this.toolMaskEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMaskEdit.Image = global::ColorWanted.Properties.Resources.edit;
            this.toolMaskEdit.Name = "toolMaskEdit";
            this.toolMaskEdit.Size = new System.Drawing.Size(23, 22);
            this.toolMaskEdit.Click += new System.EventHandler(this.ToolMaskEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolMaskSave
            // 
            this.toolMaskSave.AutoSize = false;
            this.toolMaskSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMaskSave.Image = global::ColorWanted.Properties.Resources.save;
            this.toolMaskSave.Name = "toolMaskSave";
            this.toolMaskSave.Size = new System.Drawing.Size(23, 22);
            this.toolMaskSave.Click += new System.EventHandler(this.ToolSave_Click);
            // 
            // toolMaskOK
            // 
            this.toolMaskOK.AutoSize = false;
            this.toolMaskOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMaskOK.Image = global::ColorWanted.Properties.Resources.ok;
            this.toolMaskOK.Name = "toolMaskOK";
            this.toolMaskOK.Size = new System.Drawing.Size(23, 22);
            this.toolMaskOK.Click += new System.EventHandler(this.ToolOK_Click);
            // 
            // toolMaskCancel
            // 
            this.toolMaskCancel.AutoSize = false;
            this.toolMaskCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMaskCancel.Image = global::ColorWanted.Properties.Resources.cancel;
            this.toolMaskCancel.Name = "toolMaskCancel";
            this.toolMaskCancel.Size = new System.Drawing.Size(23, 22);
            this.toolMaskCancel.Click += new System.EventHandler(this.ToolCancel_Click);
            // 
            // editorContainer
            // 
            this.editorContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorContainer.Location = new System.Drawing.Point(0, 0);
            this.editorContainer.Name = "editorContainer";
            this.editorContainer.Size = new System.Drawing.Size(800, 450);
            this.editorContainer.TabIndex = 12;
            this.editorContainer.Child = this.editor;
            // 
            // ScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.toolbarMask);
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.editorContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScreenForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenForm_FormClosing);
            this.Load += new System.EventHandler(this.ScreenForm_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.toolbarColor.ResumeLayout(false);
            this.toolbarColor.PerformLayout();
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            this.toolbarExtPanel.ResumeLayout(false);
            this.toolbarExtPanel.PerformLayout();
            this.toolbarLineType.ResumeLayout(false);
            this.toolbarLineType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolLineWidth)).EndInit();
            this.toolbarTextStyle.ResumeLayout(false);
            this.toolbarTextStyle.PerformLayout();
            this.toolbarMask.ResumeLayout(false);
            this.toolbarMask.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton toolText;
        private System.Windows.Forms.ToolStripButton toolCurve;
        private System.Windows.Forms.ToolStripButton toolLine;
        private System.Windows.Forms.ToolStripButton toolRectangle;
        private System.Windows.Forms.ToolStripButton toolEllipse;
        private System.Windows.Forms.ToolStripButton toolArrow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolOK;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStrip toolbarColor;
        private System.Windows.Forms.ToolStripButton toolColorRed;
        private System.Windows.Forms.ToolStripButton toolColorGreen;
        private System.Windows.Forms.ToolStripButton toolColorBlue;
        private System.Windows.Forms.ToolStripButton toolColorPurple;
        private System.Windows.Forms.ToolStripButton toolColorBlack;
        private System.Windows.Forms.Panel toolPanel;
        private System.Windows.Forms.ToolStrip toolbarLineType;
        private System.Windows.Forms.ToolStripButton toolStyleSolid;
        private System.Windows.Forms.ToolStripButton toolStyleDotted;
        private System.Windows.Forms.ToolStripButton toolStyleDashed;
        private System.Windows.Forms.FlowLayoutPanel toolbarExtPanel;
        private System.Windows.Forms.ToolStrip toolbarTextStyle;
        private System.Windows.Forms.ToolStripButton toolTextStyle;
        private System.Windows.Forms.ToolStripButton toolColorSelect;
        private System.Windows.Forms.ToolStrip toolbarMask;
        private System.Windows.Forms.ToolStripButton toolMaskEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolMaskOK;
        private System.Windows.Forms.ToolStripButton toolMaskSave;
        private System.Windows.Forms.ToolStripButton toolMaskCancel;
        private System.Windows.Forms.TrackBar toolLineWidth;
        private System.Windows.Forms.Integration.ElementHost editorContainer;
        private ImageEditor editor;
    }
}