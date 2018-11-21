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
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(62, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "关于赏色";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "开源的屏幕取色器";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lkLicense
            // 
            this.lkLicense.AutoSize = true;
            this.lkLicense.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkLicense.LinkColor = System.Drawing.Color.Lime;
            this.lkLicense.Location = new System.Drawing.Point(129, 149);
            this.lkLicense.Name = "lkLicense";
            this.lkLicense.Size = new System.Drawing.Size(55, 15);
            this.lkLicense.TabIndex = 9;
            this.lkLicense.TabStop = true;
            this.lkLicense.Text = "GPL V3";
            this.lkLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.lkLicense, "使用本程序源码请遵守此开源协议");
            this.lkLicense.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // picLOGO
            // 
            this.picLOGO.BackColor = System.Drawing.Color.White;
            this.picLOGO.Image = global::ColorWanted.Properties.Resources.logo;
            this.picLOGO.Location = new System.Drawing.Point(300, 25);
            this.picLOGO.Name = "picLOGO";
            this.picLOGO.Size = new System.Drawing.Size(64, 64);
            this.picLOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLOGO.TabIndex = 12;
            this.picLOGO.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Location = new System.Drawing.Point(436, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "×";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lkSite
            // 
            this.lkSite.AutoSize = true;
            this.lkSite.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkSite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkSite.Location = new System.Drawing.Point(130, 114);
            this.lkSite.Name = "lkSite";
            this.lkSite.Size = new System.Drawing.Size(227, 12);
            this.lkSite.TabIndex = 7;
            this.lkSite.TabStop = true;
            this.lkSite.Text = "http://hyjiacan.github.io/ColorWanted";
            this.lkSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lkSite.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkSite_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(58, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "官方网站";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lkGithub
            // 
            this.lkGithub.AutoSize = true;
            this.lkGithub.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkGithub.Location = new System.Drawing.Point(130, 177);
            this.lkGithub.Name = "lkGithub";
            this.lkGithub.Size = new System.Drawing.Size(239, 12);
            this.lkGithub.TabIndex = 5;
            this.lkGithub.TabStop = true;
            this.lkGithub.Text = "https://github.com/hyjiacan/ColorWanted";
            this.lkGithub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lkGithub.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkGithub_LinkClicked);
            // 
            // lkQQGroup
            // 
            this.lkQQGroup.AutoSize = true;
            this.lkQQGroup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkQQGroup.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkQQGroup.Location = new System.Drawing.Point(175, 271);
            this.lkQQGroup.Name = "lkQQGroup";
            this.lkQQGroup.Size = new System.Drawing.Size(59, 12);
            this.lkQQGroup.TabIndex = 7;
            this.lkQQGroup.TabStop = true;
            this.lkQQGroup.Text = "187786345";
            this.lkQQGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.lkQQGroup, "点击加入QQ群(Javascript爱好者)");
            this.lkQQGroup.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkQQGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkQQGroup_LinkClicked);
            // 
            // lkVersion
            // 
            this.lkVersion.AutoSize = true;
            this.lkVersion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkVersion.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkVersion.Location = new System.Drawing.Point(170, 43);
            this.lkVersion.Name = "lkVersion";
            this.lkVersion.Size = new System.Drawing.Size(41, 12);
            this.lkVersion.TabIndex = 7;
            this.lkVersion.TabStop = true;
            this.lkVersion.Text = "v1.0.0";
            this.lkVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.lkVersion, "点击检查更新");
            this.lkVersion.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkVersion_LinkClicked_1);
            // 
            // lkMail
            // 
            this.lkMail.AutoSize = true;
            this.lkMail.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkMail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkMail.Location = new System.Drawing.Point(175, 246);
            this.lkMail.Name = "lkMail";
            this.lkMail.Size = new System.Drawing.Size(101, 12);
            this.lkMail.TabIndex = 7;
            this.lkMail.TabStop = true;
            this.lkMail.Text = "hyjiacan@163.com";
            this.lkMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.lkMail, "向我发送邮件");
            this.lkMail.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkMail_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(90, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "源码";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(58, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "联系方式";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lkHotkey
            // 
            this.lkHotkey.AutoSize = true;
            this.lkHotkey.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkHotkey.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkHotkey.Location = new System.Drawing.Point(214, 78);
            this.lkHotkey.Name = "lkHotkey";
            this.lkHotkey.Size = new System.Drawing.Size(65, 12);
            this.lkHotkey.TabIndex = 7;
            this.lkHotkey.TabStop = true;
            this.lkHotkey.Text = "查看快捷键";
            this.lkHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lkHotkey.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkHotkey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkHotkey_LinkClicked);
            // 
            // lkFeedback
            // 
            this.lkFeedback.AutoSize = true;
            this.lkFeedback.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkFeedback.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lkFeedback.Location = new System.Drawing.Point(129, 217);
            this.lkFeedback.Name = "lkFeedback";
            this.lkFeedback.Size = new System.Drawing.Size(89, 12);
            this.lkFeedback.TabIndex = 7;
            this.lkFeedback.TabStop = true;
            this.lkFeedback.Text = "反馈问题或建议";
            this.lkFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lkFeedback.VisitedLinkColor = System.Drawing.Color.Lime;
            this.lkFeedback.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkFeedback_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(129, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "QQ群";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(94, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(281, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "本程序版权归 hyjiacan 所有，版权受到法律保护。";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(127, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(257, 36);
            this.label9.TabIndex = 13;
            this.label9.Text = "对因使用本程序导致的直接或间接的一切损失，\r\n\r\n须使用者自行承担，本人不承担任何责任。";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(58, 310);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "免责声明";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(129, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "E-Mail";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(463, 425);
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
            this.Icon = global::ColorWanted.Properties.Resources.ico;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于-赏色";
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