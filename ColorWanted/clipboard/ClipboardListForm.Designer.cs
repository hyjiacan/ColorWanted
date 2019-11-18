namespace ColorWanted.clipboard
{
    partial class ClipboardListForm
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
            this.btnMore = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeDate = new System.Windows.Forms.TreeView();
            this.clipboardTreeNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.list = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clipboardTreeNodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMore
            // 
            this.btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMore.BackColor = System.Drawing.Color.Gray;
            this.btnMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMore.Font = new System.Drawing.Font("宋体", 12F);
            this.btnMore.ForeColor = System.Drawing.Color.White;
            this.btnMore.Location = new System.Drawing.Point(3, 521);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(635, 37);
            this.btnMore.TabIndex = 1;
            this.btnMore.Text = "加载更多";
            this.btnMore.UseVisualStyleBackColor = false;
            this.btnMore.Click += new System.EventHandler(this.BtnMore_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeDate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.list);
            this.splitContainer1.Panel2.Controls.Add(this.btnMore);
            this.splitContainer1.Size = new System.Drawing.Size(904, 561);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeDate
            // 
            this.treeDate.BackColor = System.Drawing.Color.White;
            this.treeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDate.Font = new System.Drawing.Font("宋体", 10F);
            this.treeDate.HideSelection = false;
            this.treeDate.HotTracking = true;
            this.treeDate.ItemHeight = 18;
            this.treeDate.Location = new System.Drawing.Point(0, 0);
            this.treeDate.Name = "treeDate";
            this.treeDate.Size = new System.Drawing.Size(259, 561);
            this.treeDate.TabIndex = 0;
            this.treeDate.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeDate_NodeMouseClick);
            // 
            // clipboardTreeNodeBindingSource
            // 
            this.clipboardTreeNodeBindingSource.DataSource = typeof(ColorWanted.clipboard.ClipboardTreeNode);
            // 
            // list
            // 
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list.AutoScroll = true;
            this.list.BackColor = System.Drawing.Color.White;
            this.list.Location = new System.Drawing.Point(3, 3);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(635, 512);
            this.list.TabIndex = 0;
            // 
            // ClipboardListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 561);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "ClipboardListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "剪贴板数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClipboardListForm_FormClosing);
            this.Load += new System.EventHandler(this.ClipboardListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClipboardListForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clipboardTreeNodeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeDate;
        private System.Windows.Forms.BindingSource clipboardTreeNodeBindingSource;
        private System.Windows.Forms.FlowLayoutPanel list;
    }
}