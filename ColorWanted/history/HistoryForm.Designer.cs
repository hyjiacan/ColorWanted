namespace ColorWanted.history
{
    partial class HistoryForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picLOGO = new System.Windows.Forms.PictureBox();
            this.list = new System.Windows.Forms.ListView();
            this.linkFile = new System.Windows.Forms.LinkLabel();
            this.linkClear = new System.Windows.Forms.LinkLabel();
            this.linkReload = new System.Windows.Forms.LinkLabel();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.linkHex = new System.Windows.Forms.LinkLabel();
            this.linkRgb = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Location = new System.Drawing.Point(443, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "×";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "赏色 - 取色历史";
            // 
            // picLOGO
            // 
            this.picLOGO.BackColor = System.Drawing.Color.White;
            this.picLOGO.Image = global::ColorWanted.Properties.Resources.logo;
            this.picLOGO.Location = new System.Drawing.Point(10, 6);
            this.picLOGO.Name = "picLOGO";
            this.picLOGO.Size = new System.Drawing.Size(16, 16);
            this.picLOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLOGO.TabIndex = 12;
            this.picLOGO.TabStop = false;
            // 
            // list
            // 
            this.list.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list.AutoArrange = false;
            this.list.BackColor = System.Drawing.Color.Gray;
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list.ForeColor = System.Drawing.Color.White;
            this.list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.list.HideSelection = false;
            this.list.LabelWrap = false;
            this.list.Location = new System.Drawing.Point(12, 32);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.ShowItemToolTips = true;
            this.list.Size = new System.Drawing.Size(446, 234);
            this.list.TabIndex = 0;
            this.list.TileSize = new System.Drawing.Size(80, 32);
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Tile;
            this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
            // 
            // linkFile
            // 
            this.linkFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkFile.AutoSize = true;
            this.linkFile.LinkColor = System.Drawing.Color.Lime;
            this.linkFile.Location = new System.Drawing.Point(308, 8);
            this.linkFile.Name = "linkFile";
            this.linkFile.Size = new System.Drawing.Size(53, 12);
            this.linkFile.TabIndex = 2;
            this.linkFile.TabStop = true;
            this.linkFile.Text = "打开文件";
            this.linkFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFile_LinkClicked);
            // 
            // linkClear
            // 
            this.linkClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkClear.AutoSize = true;
            this.linkClear.LinkColor = System.Drawing.Color.Lime;
            this.linkClear.Location = new System.Drawing.Point(382, 8);
            this.linkClear.Name = "linkClear";
            this.linkClear.Size = new System.Drawing.Size(29, 12);
            this.linkClear.TabIndex = 3;
            this.linkClear.TabStop = true;
            this.linkClear.Text = "清空";
            this.linkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClear_LinkClicked);
            // 
            // linkReload
            // 
            this.linkReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkReload.AutoSize = true;
            this.linkReload.LinkColor = System.Drawing.Color.Lime;
            this.linkReload.Location = new System.Drawing.Point(259, 8);
            this.linkReload.Name = "linkReload";
            this.linkReload.Size = new System.Drawing.Size(29, 12);
            this.linkReload.TabIndex = 1;
            this.linkReload.TabStop = true;
            this.linkReload.Text = "刷新";
            this.linkReload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReload_LinkClicked);
            // 
            // linkHex
            // 
            this.linkHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkHex.AutoSize = true;
            this.linkHex.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkHex.Location = new System.Drawing.Point(294, 280);
            this.linkHex.Name = "linkHex";
            this.linkHex.Size = new System.Drawing.Size(47, 12);
            this.linkHex.TabIndex = 17;
            this.linkHex.TabStop = true;
            this.linkHex.Text = "#000000";
            this.tooltip.SetToolTip(this.linkHex, "点击复制");
            this.linkHex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHex_LinkClicked);
            // 
            // linkRgb
            // 
            this.linkRgb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkRgb.AutoSize = true;
            this.linkRgb.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkRgb.Location = new System.Drawing.Point(353, 280);
            this.linkRgb.Name = "linkRgb";
            this.linkRgb.Size = new System.Drawing.Size(65, 12);
            this.linkRgb.TabIndex = 17;
            this.linkRgb.TabStop = true;
            this.linkRgb.Text = "RGB(0,0,0)";
            this.tooltip.SetToolTip(this.linkRgb, "点击复制");
            this.linkRgb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRgb_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "点击复制 →";
            this.tooltip.SetToolTip(this.label2, "从这里复制不会添加到历史记录中");
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(470, 303);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkRgb);
            this.Controls.Add(this.linkHex);
            this.Controls.Add(this.linkReload);
            this.Controls.Add(this.linkClear);
            this.Controls.Add(this.linkFile);
            this.Controls.Add(this.list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.picLOGO);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryForm";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取色历史 - 赏色";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            ((System.ComponentModel.ISupportInitialize)(this.picLOGO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLOGO;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView list;
        private System.Windows.Forms.LinkLabel linkFile;
        private System.Windows.Forms.LinkLabel linkClear;
        private System.Windows.Forms.LinkLabel linkReload;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.LinkLabel linkHex;
        private System.Windows.Forms.LinkLabel linkRgb;
        private System.Windows.Forms.Label label2;
    }
}