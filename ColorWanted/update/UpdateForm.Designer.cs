namespace ColorWanted.update
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
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
            // lbMsg
            // 
            resources.ApplyResources(this.lbMsg, "lbMsg");
            this.lbMsg.Name = "lbMsg";
            // 
            // lbCurrent
            // 
            resources.ApplyResources(this.lbCurrent, "lbCurrent");
            this.lbCurrent.Name = "lbCurrent";
            // 
            // linkNow
            // 
            resources.ApplyResources(this.linkNow, "linkNow");
            this.linkNow.LinkColor = System.Drawing.Color.Lime;
            this.linkNow.Name = "linkNow";
            this.linkNow.TabStop = true;
            this.linkNow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNow_LinkClicked);
            // 
            // linkIgnore
            // 
            resources.ApplyResources(this.linkIgnore, "linkIgnore");
            this.linkIgnore.LinkColor = System.Drawing.Color.Lime;
            this.linkIgnore.Name = "linkIgnore";
            this.linkIgnore.TabStop = true;
            this.linkIgnore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIgnore_LinkClicked);
            // 
            // linkNext
            // 
            resources.ApplyResources(this.linkNext, "linkNext");
            this.linkNext.LinkColor = System.Drawing.Color.Lime;
            this.linkNext.Name = "linkNext";
            this.linkNext.TabStop = true;
            this.linkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNext_LinkClicked);
            // 
            // picLOGO
            // 
            resources.ApplyResources(this.picLOGO, "picLOGO");
            this.picLOGO.BackColor = System.Drawing.Color.White;
            this.picLOGO.Image = global::ColorWanted.Properties.Resources.logo;
            this.picLOGO.Name = "picLOGO";
            this.picLOGO.TabStop = false;
            // 
            // lbPercentage
            // 
            resources.ApplyResources(this.lbPercentage, "lbPercentage");
            this.lbPercentage.Name = "lbPercentage";
            // 
            // lbProgress
            // 
            resources.ApplyResources(this.lbProgress, "lbProgress");
            this.lbProgress.BackColor = System.Drawing.Color.Lime;
            this.lbProgress.Name = "lbProgress";
            // 
            // pnDetail
            // 
            resources.ApplyResources(this.pnDetail, "pnDetail");
            this.pnDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDetail.Controls.Add(this.lbLog);
            this.pnDetail.Controls.Add(this.lbUpdateDate);
            this.pnDetail.Controls.Add(this.label3);
            this.pnDetail.Controls.Add(this.label2);
            this.pnDetail.Name = "pnDetail";
            this.pnDetail.MouseEnter += new System.EventHandler(this.UpdateForm_MouseEnter);
            this.pnDetail.MouseLeave += new System.EventHandler(this.UpdateForm_MouseLeave);
            // 
            // lbLog
            // 
            resources.ApplyResources(this.lbLog, "lbLog");
            this.lbLog.Name = "lbLog";
            // 
            // lbUpdateDate
            // 
            resources.ApplyResources(this.lbUpdateDate, "lbUpdateDate");
            this.lbUpdateDate.Name = "lbUpdateDate";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // UpdateForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
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
            this.Name = "UpdateForm";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
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

        private System.Windows.Forms.PictureBox picLOGO;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label lbCurrent;
        private System.Windows.Forms.LinkLabel linkNow;
        private System.Windows.Forms.LinkLabel linkIgnore;
        private System.Windows.Forms.LinkLabel linkNext;
        private System.Windows.Forms.Label lbPercentage;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.Panel pnDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUpdateDate;
        private System.Windows.Forms.Label lbLog;
    }
}