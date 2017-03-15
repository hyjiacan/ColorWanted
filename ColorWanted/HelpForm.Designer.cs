namespace ColorWanted
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.llScm = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.llCopy = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picLOGO = new System.Windows.Forms.PictureBox();
            this.lbVersion = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(65, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "赏色(ColorWanted)";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "这是一个屏幕取色器，源码放在";
            // 
            // llScm
            // 
            this.llScm.AutoSize = true;
            this.llScm.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.llScm.Location = new System.Drawing.Point(67, 156);
            this.llScm.Name = "llScm";
            this.llScm.Size = new System.Drawing.Size(293, 12);
            this.llScm.TabIndex = 5;
            this.llScm.TabStop = true;
            this.llScm.Text = "https://git.oschina.net/hyjiacan/ColorWanted.git";
            this.llScm.VisitedLinkColor = System.Drawing.Color.Lime;
            this.llScm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llScm_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(67, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "快捷键说明";
            // 
            // llCopy
            // 
            this.llCopy.AutoSize = true;
            this.llCopy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llCopy.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.llCopy.Location = new System.Drawing.Point(284, 132);
            this.llCopy.Name = "llCopy";
            this.llCopy.Size = new System.Drawing.Size(77, 12);
            this.llCopy.TabIndex = 7;
            this.llCopy.TabStop = true;
            this.llCopy.Text = "复制这个地址";
            this.llCopy.VisitedLinkColor = System.Drawing.Color.Lime;
            this.llCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCopy_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "本软件使用";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Lime;
            this.linkLabel1.Location = new System.Drawing.Point(130, 183);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(47, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "MIT协议";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Lime;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "，意味着可以随便改着玩";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(329, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Alt+C 复制十六进制颜色值，1秒内连续按两次复制RGB颜色值";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "Alt+R 显示/隐藏RGB通道颜色板";
            // 
            // picLOGO
            // 
            this.picLOGO.BackColor = System.Drawing.Color.White;
            this.picLOGO.Image = global::ColorWanted.Properties.Resources.logo;
            this.picLOGO.Location = new System.Drawing.Point(296, 36);
            this.picLOGO.Name = "picLOGO";
            this.picLOGO.Size = new System.Drawing.Size(64, 64);
            this.picLOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLOGO.TabIndex = 12;
            this.picLOGO.TabStop = false;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(70, 78);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(47, 12);
            this.lbVersion.TabIndex = 13;
            this.lbVersion.Text = "v 1.0.0";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Location = new System.Drawing.Point(445, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "×";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "Alt+F1 切换显示模式 (隐藏/固定/跟随)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "Alt+F2 显示/隐藏预览面板";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "Alt+F3 显示调色板";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(68, 381);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(323, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "Alt+` 暂停/开始绘制预览窗(`在美标键盘左上角，ESC下面)";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(472, 429);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.picLOGO);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.llCopy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.llScm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
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
        private System.Windows.Forms.LinkLabel llScm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llCopy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picLOGO;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}