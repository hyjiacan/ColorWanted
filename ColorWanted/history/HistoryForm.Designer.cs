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
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // picLOGO
            // 
            this.picLOGO.BackColor = System.Drawing.Color.White;
            this.picLOGO.Image = global::ColorWanted.Properties.Resources.logo;
            resources.ApplyResources(this.picLOGO, "picLOGO");
            this.picLOGO.Name = "picLOGO";
            this.picLOGO.TabStop = false;
            // 
            // list
            // 
            resources.ApplyResources(this.list, "list");
            this.list.AutoArrange = false;
            this.list.BackColor = System.Drawing.Color.White;
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list.ForeColor = System.Drawing.Color.Black;
            this.list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.list.HideSelection = false;
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.ShowItemToolTips = true;
            this.list.TileSize = new System.Drawing.Size(80, 32);
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Tile;
            this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
            // 
            // linkFile
            // 
            resources.ApplyResources(this.linkFile, "linkFile");
            this.linkFile.LinkColor = System.Drawing.Color.Lime;
            this.linkFile.Name = "linkFile";
            this.linkFile.TabStop = true;
            this.linkFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFile_LinkClicked);
            // 
            // linkClear
            // 
            resources.ApplyResources(this.linkClear, "linkClear");
            this.linkClear.LinkColor = System.Drawing.Color.Lime;
            this.linkClear.Name = "linkClear";
            this.linkClear.TabStop = true;
            this.linkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClear_LinkClicked);
            // 
            // linkReload
            // 
            resources.ApplyResources(this.linkReload, "linkReload");
            this.linkReload.LinkColor = System.Drawing.Color.Lime;
            this.linkReload.Name = "linkReload";
            this.linkReload.TabStop = true;
            this.linkReload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReload_LinkClicked);
            // 
            // linkHex
            // 
            resources.ApplyResources(this.linkHex, "linkHex");
            this.linkHex.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkHex.Name = "linkHex";
            this.linkHex.TabStop = true;
            this.tooltip.SetToolTip(this.linkHex, resources.GetString("linkHex.ToolTip"));
            this.linkHex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHex_LinkClicked);
            // 
            // linkRgb
            // 
            resources.ApplyResources(this.linkRgb, "linkRgb");
            this.linkRgb.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkRgb.Name = "linkRgb";
            this.linkRgb.TabStop = true;
            this.tooltip.SetToolTip(this.linkRgb, resources.GetString("linkRgb.ToolTip"));
            this.linkRgb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRgb_LinkClicked);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.tooltip.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // HistoryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.label3);
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
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryForm";
            this.Opacity = 0.8D;
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
        private System.Windows.Forms.Label label3;
    }
}