namespace ColorWanted.hotkey
{
    partial class HotkeyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        System.ComponentModel.ComponentResourceManager resources;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeyForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.picLOGO = new System.Windows.Forms.PictureBox();
            this.lbMsg = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.lkReset = new System.Windows.Forms.LinkLabel();
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // picLOGO
            // 
            resources.ApplyResources(this.picLOGO, "picLOGO");
            this.picLOGO.BackColor = System.Drawing.Color.White;
            this.picLOGO.Image = global::ColorWanted.Properties.Resources.logo;
            this.picLOGO.Name = "picLOGO";
            this.picLOGO.TabStop = false;
            // 
            // lbMsg
            // 
            resources.ApplyResources(this.lbMsg, "lbMsg");
            this.lbMsg.Name = "lbMsg";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panel
            // 
            resources.ApplyResources(this.panel, "panel");
            this.panel.Name = "panel";
            // 
            // lkReset
            // 
            resources.ApplyResources(this.lkReset, "lkReset");
            this.lkReset.LinkColor = System.Drawing.Color.Lime;
            this.lkReset.Name = "lkReset";
            this.lkReset.TabStop = true;
            this.lkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkReset_LinkClicked);
            // 
            // HotkeyForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.lkReset);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picLOGO);
            this.Controls.Add(this.btnExit);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeyForm";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.HotkeyForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            ((System.ComponentModel.ISupportInitialize)(this.picLOGO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picLOGO;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.LinkLabel lkReset;
    }
}