namespace ColorWanted.theme
{
    partial class ThemeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFg = new System.Windows.Forms.Label();
            this.lbBg = new System.Windows.Forms.Label();
            this.trOpacity = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.linkFg = new System.Windows.Forms.LinkLabel();
            this.linkBg = new System.Windows.Forms.LinkLabel();
            this.btnThemeDark = new System.Windows.Forms.Button();
            this.btnThemeLight = new System.Windows.Forms.Button();
            this.btnThemeCustom = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnChoose = new System.Windows.Forms.Panel();
            this.btnThemeGreen = new System.Windows.Forms.Button();
            this.btnThemeBlue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trOpacity)).BeginInit();
            this.pnChoose.SuspendLayout();
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
            // lbFg
            // 
            resources.ApplyResources(this.lbFg, "lbFg");
            this.lbFg.Name = "lbFg";
            // 
            // lbBg
            // 
            resources.ApplyResources(this.lbBg, "lbBg");
            this.lbBg.Name = "lbBg";
            // 
            // trOpacity
            // 
            resources.ApplyResources(this.trOpacity, "trOpacity");
            this.trOpacity.Maximum = 100;
            this.trOpacity.Minimum = 36;
            this.trOpacity.Name = "trOpacity";
            this.trOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trOpacity.Value = 80;
            this.trOpacity.Scroll += new System.EventHandler(this.trOpacity_Scroll);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // linkFg
            // 
            resources.ApplyResources(this.linkFg, "linkFg");
            this.linkFg.LinkColor = System.Drawing.Color.Lime;
            this.linkFg.Name = "linkFg";
            this.linkFg.TabStop = true;
            this.linkFg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFg_LinkClicked);
            // 
            // linkBg
            // 
            resources.ApplyResources(this.linkBg, "linkBg");
            this.linkBg.LinkColor = System.Drawing.Color.Lime;
            this.linkBg.Name = "linkBg";
            this.linkBg.TabStop = true;
            this.linkBg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBg_LinkClicked);
            // 
            // btnThemeDark
            // 
            this.btnThemeDark.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnThemeDark, "btnThemeDark");
            this.btnThemeDark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThemeDark.Name = "btnThemeDark";
            this.btnThemeDark.Tag = "Dark";
            this.btnThemeDark.UseVisualStyleBackColor = false;
            this.btnThemeDark.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // btnThemeLight
            // 
            this.btnThemeLight.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnThemeLight, "btnThemeLight");
            this.btnThemeLight.ForeColor = System.Drawing.Color.Black;
            this.btnThemeLight.Name = "btnThemeLight";
            this.btnThemeLight.Tag = "Light";
            this.btnThemeLight.UseVisualStyleBackColor = false;
            this.btnThemeLight.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // btnThemeCustom
            // 
            this.btnThemeCustom.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnThemeCustom, "btnThemeCustom");
            this.btnThemeCustom.ForeColor = System.Drawing.Color.White;
            this.btnThemeCustom.Name = "btnThemeCustom";
            this.btnThemeCustom.Tag = "Custom";
            this.btnThemeCustom.UseVisualStyleBackColor = false;
            this.btnThemeCustom.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // pnChoose
            // 
            this.pnChoose.Controls.Add(this.lbFg);
            this.pnChoose.Controls.Add(this.lbBg);
            this.pnChoose.Controls.Add(this.linkFg);
            this.pnChoose.Controls.Add(this.linkBg);
            resources.ApplyResources(this.pnChoose, "pnChoose");
            this.pnChoose.Name = "pnChoose";
            // 
            // btnThemeGreen
            // 
            this.btnThemeGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            resources.ApplyResources(this.btnThemeGreen, "btnThemeGreen");
            this.btnThemeGreen.ForeColor = System.Drawing.Color.White;
            this.btnThemeGreen.Name = "btnThemeGreen";
            this.btnThemeGreen.Tag = "Green";
            this.btnThemeGreen.UseVisualStyleBackColor = false;
            this.btnThemeGreen.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // btnThemeBlue
            // 
            this.btnThemeBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(141)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.btnThemeBlue, "btnThemeBlue");
            this.btnThemeBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(217)))));
            this.btnThemeBlue.Name = "btnThemeBlue";
            this.btnThemeBlue.Tag = "Blue";
            this.btnThemeBlue.UseVisualStyleBackColor = false;
            this.btnThemeBlue.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // ThemeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.btnThemeBlue);
            this.Controls.Add(this.pnChoose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnThemeCustom);
            this.Controls.Add(this.btnThemeGreen);
            this.Controls.Add(this.btnThemeLight);
            this.Controls.Add(this.btnThemeDark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trOpacity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeForm";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ThemeForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            ((System.ComponentModel.ISupportInitialize)(this.trOpacity)).EndInit();
            this.pnChoose.ResumeLayout(false);
            this.pnChoose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFg;
        private System.Windows.Forms.Label lbBg;
        private System.Windows.Forms.TrackBar trOpacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkFg;
        private System.Windows.Forms.LinkLabel linkBg;
        private System.Windows.Forms.Button btnThemeDark;
        private System.Windows.Forms.Button btnThemeLight;
        private System.Windows.Forms.Button btnThemeCustom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnChoose;
        private System.Windows.Forms.Button btnThemeGreen;
        private System.Windows.Forms.Button btnThemeBlue;
    }
}