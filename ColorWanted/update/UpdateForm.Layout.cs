namespace ColorWanted.update
{
    partial class UpdateForm
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
            i18n.I18nManager resources = new i18n.I18nManager(typeof(UpdateForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMsg = new System.Windows.Forms.Label();
            this.lbCurrent = new System.Windows.Forms.Label();
            this.linkNow = new System.Windows.Forms.LinkLabel();
            this.linkIgnore = new System.Windows.Forms.LinkLabel();
            this.linkNext = new System.Windows.Forms.LinkLabel();
            this.picLOGO = new System.Windows.Forms.PictureBox();
            this.lbPercentage = new System.Windows.Forms.Label();
            this.lbProgress = new System.Windows.Forms.Label();
            this.pnDetail = new System.Windows.Forms.Panel();
            this.lbLog = new System.Windows.Forms.Label();
            this.lbUpdateDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLOGO)).BeginInit();
            this.pnDetail.SuspendLayout();
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
            this.btnExit.Location = new System.Drawing.Point(213, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 12);
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 15;
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(10, 60);
            resources.ApplyResources(this.lbMsg, "lbMsg");
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(119, 12);
            this.lbMsg.TabIndex = 16;
            // 
            // lbCurrent
            // 
            this.lbCurrent.AutoSize = true;
            this.lbCurrent.Location = new System.Drawing.Point(10, 38);
            resources.ApplyResources(this.lbCurrent, "lbCurrent");
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(95, 12);
            this.lbCurrent.TabIndex = 16;
            // 
            // linkNow
            // 
            this.linkNow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkNow.AutoSize = true;
            resources.ApplyResources(this.linkNow, "linkNow");
            this.linkNow.LinkColor = System.Drawing.Color.Lime;
            this.linkNow.Location = new System.Drawing.Point(17, 86);
            this.linkNow.Name = "linkNow";
            this.linkNow.Size = new System.Drawing.Size(53, 12);
            this.linkNow.TabIndex = 18;
            this.linkNow.TabStop = true;
            this.linkNow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNow_LinkClicked);
            // 
            // linkIgnore
            // 
            this.linkIgnore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkIgnore.AutoSize = true;
            resources.ApplyResources(this.linkIgnore, "linkIgnore");
            this.linkIgnore.LinkColor = System.Drawing.Color.Lime;
            this.linkIgnore.Location = new System.Drawing.Point(86, 86);
            this.linkIgnore.Name = "linkIgnore";
            this.linkIgnore.Size = new System.Drawing.Size(65, 12);
            this.linkIgnore.TabIndex = 18;
            this.linkIgnore.TabStop = true;
            this.linkIgnore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIgnore_LinkClicked);
            // 
            // linkNext
            // 
            this.linkNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkNext.AutoSize = true;
            resources.ApplyResources(this.linkNext, "linkNext");
            this.linkNext.LinkColor = System.Drawing.Color.Lime;
            this.linkNext.Location = new System.Drawing.Point(166, 86);
            this.linkNext.Name = "linkNext";
            this.linkNext.Size = new System.Drawing.Size(53, 12);
            this.linkNext.TabIndex = 18;
            this.linkNext.TabStop = true;
            this.linkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNext_LinkClicked);
            // 
            // picLOGO
            // 
            resources.ApplyResources(this.picLOGO, "picLOGO");
            this.picLOGO.BackColor = System.Drawing.Color.White;
            this.picLOGO.Image = global::ColorWanted.Properties.Resources.logo;
            this.picLOGO.Location = new System.Drawing.Point(12, 10);
            this.picLOGO.Name = "picLOGO";
            this.picLOGO.Size = new System.Drawing.Size(16, 16);
            this.picLOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLOGO.TabIndex = 12;
            this.picLOGO.TabStop = false;
            // 
            // lbPercentage
            // 
            resources.ApplyResources(this.lbPercentage, "lbPercentage");
            this.lbPercentage.Name = "lbPercentage";
            // 
            // lbProgress
            // 
            this.lbProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            resources.ApplyResources(this.lbProgress, "lbProgress");
            this.lbProgress.BackColor = System.Drawing.Color.Lime;
            this.lbProgress.Location = new System.Drawing.Point(12, 94);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(0, 5);
            this.lbProgress.TabIndex = 19;
            this.lbProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbProgress.Visible = false;
            // 
            // pnDetail
            // 
            this.pnDetail.AutoScroll = true;
            resources.ApplyResources(this.pnDetail, "pnDetail");
            this.pnDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDetail.Controls.Add(this.lbLog);
            this.pnDetail.Controls.Add(this.lbUpdateDate);
            this.pnDetail.Controls.Add(this.label3);
            this.pnDetail.Controls.Add(this.label2);
            this.pnDetail.Location = new System.Drawing.Point(2, 75);
            this.pnDetail.Name = "pnDetail";
            this.pnDetail.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnDetail.Size = new System.Drawing.Size(251, 135);
            this.pnDetail.TabIndex = 20;
            this.pnDetail.MouseEnter += new System.EventHandler(this.UpdateForm_MouseEnter);
            this.pnDetail.MouseLeave += new System.EventHandler(this.UpdateForm_MouseLeave);
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.AutoSize = true;
            this.lbLog.Location = new System.Drawing.Point(40, 53);
            resources.ApplyResources(this.lbLog, "lbLog");
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(0, 12);
            this.lbLog.TabIndex = 2;
            // 
            // lbUpdateDate
            // 
            this.lbUpdateDate.AutoSize = true;
            this.lbUpdateDate.Location = new System.Drawing.Point(80, 6);
            resources.ApplyResources(this.lbUpdateDate, "lbUpdateDate");
            this.lbUpdateDate.Name = "lbUpdateDate";
            this.lbUpdateDate.Size = new System.Drawing.Size(0, 12);
            this.lbUpdateDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 30);
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 6);
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(240, 110);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.linkNext);
            this.Controls.Add(this.linkIgnore);
            this.Controls.Add(this.linkNow);
            this.Controls.Add(this.lbCurrent);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.picLOGO);
            this.Controls.Add(this.lbPercentage);
            this.Controls.Add(this.pnDetail);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 100);
            this.Name = "UpdateForm";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.MouseEnter += new System.EventHandler(this.UpdateForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UpdateForm_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picLOGO)).EndInit();
            this.pnDetail.ResumeLayout(false);
            this.pnDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picLOGO;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbMsg;
        public System.Windows.Forms.Label lbCurrent;
        public System.Windows.Forms.LinkLabel linkNow;
        public System.Windows.Forms.LinkLabel linkIgnore;
        public System.Windows.Forms.LinkLabel linkNext;
        public System.Windows.Forms.Label lbPercentage;
        public System.Windows.Forms.Label lbProgress;
        public System.Windows.Forms.Panel pnDetail;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbUpdateDate;
        public System.Windows.Forms.Label lbLog;
    }
}