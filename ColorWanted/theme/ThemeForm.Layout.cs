namespace ColorWanted.theme
{
    partial class ThemeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer componentsSet = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (componentsSet != null))
            {
                componentsSet.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void componentsLayout()
        {
            i18n.I18nManager resources = new i18n.I18nManager(typeof(ThemeForm));
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
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Text = "×";
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Location = new System.Drawing.Point(436, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 15;
            // 
            // lbFg
            // 
            this.lbFg.Location = new System.Drawing.Point(3, 3);
            resources.ApplyResources(this.lbFg, "lbFg");
            this.lbFg.Name = "lbFg";
            this.lbFg.Size = new System.Drawing.Size(64, 36);
            this.lbFg.TabIndex = 19;
            this.lbFg.Text = "#FFFFFF";
            this.lbFg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbBg
            // 
            this.lbBg.Location = new System.Drawing.Point(203, 3);
            resources.ApplyResources(this.lbBg, "lbBg");
            this.lbBg.Name = "lbBg";
            this.lbBg.Size = new System.Drawing.Size(64, 36);
            this.lbBg.TabIndex = 20;
            this.lbBg.Text = "#000000";
            this.lbBg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trOpacity
            // 
            this.trOpacity.AutoSize = false;
            this.trOpacity.Location = new System.Drawing.Point(55, 78);
            resources.ApplyResources(this.trOpacity, "trOpacity");
            this.trOpacity.Maximum = 100;
            this.trOpacity.Minimum = 36;
            this.trOpacity.Name = "trOpacity";
            this.trOpacity.Size = new System.Drawing.Size(348, 28);
            this.trOpacity.TabIndex = 0;
            this.trOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trOpacity.Value = 80;
            this.trOpacity.Scroll += new System.EventHandler(this.trOpacity_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(53, 50);
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 22;
            // 
            // linkFg
            // 
            this.linkFg.AutoSize = true;
            resources.ApplyResources(this.linkFg, "linkFg");
            this.linkFg.LinkColor = System.Drawing.Color.Lime;
            this.linkFg.Location = new System.Drawing.Point(73, 15);
            this.linkFg.Name = "linkFg";
            this.linkFg.Size = new System.Drawing.Size(41, 12);
            this.linkFg.TabIndex = 23;
            this.linkFg.TabStop = true;
            this.linkFg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFg_LinkClicked);
            // 
            // linkBg
            // 
            this.linkBg.AutoSize = true;
            resources.ApplyResources(this.linkBg, "linkBg");
            this.linkBg.LinkColor = System.Drawing.Color.Lime;
            this.linkBg.Location = new System.Drawing.Point(273, 15);
            this.linkBg.Name = "linkBg";
            this.linkBg.Size = new System.Drawing.Size(41, 12);
            this.linkBg.TabIndex = 23;
            this.linkBg.TabStop = true;
            this.linkBg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBg_LinkClicked);
            // 
            // btnThemeDark
            // 
            this.btnThemeDark.BackColor = System.Drawing.Color.Black;
            this.btnThemeDark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemeDark.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            resources.ApplyResources(this.btnThemeDark, "btnThemeDark");
            this.btnThemeDark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThemeDark.Location = new System.Drawing.Point(66, 160);
            this.btnThemeDark.Name = "btnThemeDark";
            this.btnThemeDark.Size = new System.Drawing.Size(156, 63);
            this.btnThemeDark.TabIndex = 24;
            this.btnThemeDark.Tag = "Dark";
            this.btnThemeDark.UseVisualStyleBackColor = false;
            this.btnThemeDark.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // btnThemeLight
            // 
            this.btnThemeLight.BackColor = System.Drawing.Color.White;
            this.btnThemeLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.btnThemeLight, "btnThemeLight");
            this.btnThemeLight.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnThemeLight.ForeColor = System.Drawing.Color.Black;
            this.btnThemeLight.Location = new System.Drawing.Point(238, 160);
            this.btnThemeLight.Name = "btnThemeLight";
            this.btnThemeLight.Size = new System.Drawing.Size(156, 63);
            this.btnThemeLight.TabIndex = 24;
            this.btnThemeLight.Tag = "Light";
            this.btnThemeLight.UseVisualStyleBackColor = false;
            this.btnThemeLight.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // btnThemeCustom
            // 
            this.btnThemeCustom.BackColor = System.Drawing.Color.Black;
            this.btnThemeCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemeCustom.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            resources.ApplyResources(this.btnThemeCustom, "btnThemeCustom");
            this.btnThemeCustom.ForeColor = System.Drawing.Color.White;
            this.btnThemeCustom.Location = new System.Drawing.Point(66, 329);
            this.btnThemeCustom.Name = "btnThemeCustom";
            this.btnThemeCustom.Size = new System.Drawing.Size(328, 63);
            this.btnThemeCustom.TabIndex = 24;
            this.btnThemeCustom.Tag = "Custom";
            this.btnThemeCustom.UseVisualStyleBackColor = false;
            this.btnThemeCustom.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 109);
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 109);
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 52);
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 12);
            this.label5.TabIndex = 26;
            // 
            // pnChoose
            // 
            this.pnChoose.Controls.Add(this.lbFg);
            this.pnChoose.Controls.Add(this.lbBg);
            this.pnChoose.Controls.Add(this.linkFg);
            this.pnChoose.Controls.Add(this.linkBg);
            this.pnChoose.Location = new System.Drawing.Point(55, 402);
            resources.ApplyResources(this.pnChoose, "pnChoose");
            this.pnChoose.Name = "pnChoose";
            this.pnChoose.Size = new System.Drawing.Size(345, 42);
            this.pnChoose.TabIndex = 27;
            // 
            // btnThemeGreen
            // 
            this.btnThemeGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(187)))), ((int)(((byte)(106)))));
            this.btnThemeGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemeGreen.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            resources.ApplyResources(this.btnThemeGreen, "btnThemeGreen");
            this.btnThemeGreen.ForeColor = System.Drawing.Color.White;
            this.btnThemeGreen.Location = new System.Drawing.Point(66, 243);
            this.btnThemeGreen.Name = "btnThemeGreen";
            this.btnThemeGreen.Size = new System.Drawing.Size(156, 63);
            this.btnThemeGreen.TabIndex = 24;
            this.btnThemeGreen.Tag = "Green";
            this.btnThemeGreen.UseVisualStyleBackColor = false;
            this.btnThemeGreen.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // btnThemeBlue
            // 
            this.btnThemeBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(141)))), ((int)(((byte)(238)))));
            this.btnThemeBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemeBlue.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            resources.ApplyResources(this.btnThemeBlue, "btnThemeBlue");
            this.btnThemeBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(217)))));
            this.btnThemeBlue.Location = new System.Drawing.Point(238, 243);
            this.btnThemeBlue.Name = "btnThemeBlue";
            this.btnThemeBlue.Size = new System.Drawing.Size(156, 63);
            this.btnThemeBlue.TabIndex = 28;
            this.btnThemeBlue.Tag = "Blue";
            this.btnThemeBlue.UseVisualStyleBackColor = false;
            this.btnThemeBlue.Click += new System.EventHandler(this.btnThemeClick);
            // 
            // ThemeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(463, 454);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ThemeForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEventHandler);
            ((System.ComponentModel.ISupportInitialize)(this.trOpacity)).EndInit();
            this.Icon = global::ColorWanted.Properties.Resources.ico;
            this.pnChoose.ResumeLayout(false);
            this.pnChoose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbFg;
        public System.Windows.Forms.Label lbBg;
        public System.Windows.Forms.TrackBar trOpacity;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.LinkLabel linkFg;
        public System.Windows.Forms.LinkLabel linkBg;
        public System.Windows.Forms.Button btnThemeDark;
        public System.Windows.Forms.Button btnThemeLight;
        public System.Windows.Forms.Button btnThemeCustom;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Panel pnChoose;
        public System.Windows.Forms.Button btnThemeGreen;
        public System.Windows.Forms.Button btnThemeBlue;
    }
}