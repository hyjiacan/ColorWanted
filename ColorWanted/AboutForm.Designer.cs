namespace ColorWanted
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lkLicense = new System.Windows.Forms.LinkLabel();
            this.picLOGO = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lkSite = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lkGithub = new System.Windows.Forms.LinkLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lkQQGroup = new System.Windows.Forms.LinkLabel();
            this.lkVersion = new System.Windows.Forms.LinkLabel();
            this.lkMail = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lkHotkey = new System.Windows.Forms.LinkLabel();
            this.lkFeedback = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // lkLicense
            // 
            resources.ApplyResources(this.lkLicense, "lkLicense");
            this.lkLicense.LinkColor = System.Drawing.Color.Lime;
            this.lkLicense.Name = "lkLicense";
            this.lkLicense.TabStop = true;
            this.toolTip.SetToolTip(this.lkLicense, resources.GetString("lkLicense.ToolTip"));
            this.lkLicense.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // picLOGO
            // 
            resources.ApplyResources(this.picLOGO, "picLOGO");
            this.picLOGO.BackColor = System.Drawing.Color.White;
            this.picLOGO.Image = global::ColorWanted.Properties.Resources.logo;
            this.picLOGO.Name = "picLOGO";
            this.picLOGO.TabStop = false;
            this.toolTip.SetToolTip(this.picLOGO, resources.GetString("picLOGO.ToolTip"));
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Name = "btnExit";
            this.toolTip.SetToolTip(this.btnExit, resources.GetString("btnExit.ToolTip"));
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lkSite
            // 
            resources.ApplyResources(this.lkSite, "lkSite");
            this.lkSite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkSite.Name = "lkSite";
            this.lkSite.TabStop = true;
            this.toolTip.SetToolTip(this.lkSite, resources.GetString("lkSite.ToolTip"));
            this.lkSite.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkSite_LinkClicked);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.toolTip.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // lkGithub
            // 
            resources.ApplyResources(this.lkGithub, "lkGithub");
            this.lkGithub.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkGithub.Name = "lkGithub";
            this.lkGithub.TabStop = true;
            this.toolTip.SetToolTip(this.lkGithub, resources.GetString("lkGithub.ToolTip"));
            this.lkGithub.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkGithub_LinkClicked);
            // 
            // lkQQGroup
            // 
            resources.ApplyResources(this.lkQQGroup, "lkQQGroup");
            this.lkQQGroup.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkQQGroup.Name = "lkQQGroup";
            this.lkQQGroup.TabStop = true;
            this.toolTip.SetToolTip(this.lkQQGroup, resources.GetString("lkQQGroup.ToolTip"));
            this.lkQQGroup.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkQQGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkQQGroup_LinkClicked);
            // 
            // lkVersion
            // 
            resources.ApplyResources(this.lkVersion, "lkVersion");
            this.lkVersion.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkVersion.Name = "lkVersion";
            this.lkVersion.TabStop = true;
            this.toolTip.SetToolTip(this.lkVersion, resources.GetString("lkVersion.ToolTip"));
            this.lkVersion.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkVersion_LinkClicked_1);
            // 
            // lkMail
            // 
            resources.ApplyResources(this.lkMail, "lkMail");
            this.lkMail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkMail.Name = "lkMail";
            this.lkMail.TabStop = true;
            this.toolTip.SetToolTip(this.lkMail, resources.GetString("lkMail.ToolTip"));
            this.lkMail.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkMail_LinkClicked);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // lkHotkey
            // 
            resources.ApplyResources(this.lkHotkey, "lkHotkey");
            this.lkHotkey.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkHotkey.Name = "lkHotkey";
            this.lkHotkey.TabStop = true;
            this.toolTip.SetToolTip(this.lkHotkey, resources.GetString("lkHotkey.ToolTip"));
            this.lkHotkey.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkHotkey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkHotkey_LinkClicked);
            // 
            // lkFeedback
            // 
            resources.ApplyResources(this.lkFeedback, "lkFeedback");
            this.lkFeedback.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkFeedback.Name = "lkFeedback";
            this.lkFeedback.TabStop = true;
            this.toolTip.SetToolTip(this.lkFeedback, resources.GetString("lkFeedback.ToolTip"));
            this.lkFeedback.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkFeedback.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkFeedback_LinkClicked);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            this.toolTip.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            this.toolTip.SetToolTip(this.label8, resources.GetString("label8.ToolTip"));
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            this.toolTip.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            this.toolTip.SetToolTip(this.label10, resources.GetString("label10.ToolTip"));
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.toolTip.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picLOGO);
            this.Controls.Add(this.lkLicense);
            this.Controls.Add(this.lkVersion);
            this.Controls.Add(this.lkHotkey);
            this.Controls.Add(this.lkFeedback);
            this.Controls.Add(this.lkQQGroup);
            this.Controls.Add(this.lkMail);
            this.Controls.Add(this.lkSite);
            this.Controls.Add(this.lkGithub);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            ((System.ComponentModel.ISupportInitialize)(this.picLOGO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lkLicense;
        private System.Windows.Forms.PictureBox picLOGO;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.LinkLabel lkSite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lkGithub;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lkHotkey;
        private System.Windows.Forms.LinkLabel lkFeedback;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel lkQQGroup;
        private System.Windows.Forms.LinkLabel lkVersion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lkMail;
    }
}