namespace ColorWanted.screenshot
{
    partial class ScreenRecordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenRecordForm));
            this.pnTarget = new System.Windows.Forms.Panel();
            this.pnToolOption = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQuality = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFullscreen = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnTarget.SuspendLayout();
            this.pnToolOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTarget
            // 
            this.pnTarget.Controls.Add(this.pnToolOption);
            this.pnTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTarget.Location = new System.Drawing.Point(0, 0);
            this.pnTarget.Name = "pnTarget";
            this.pnTarget.Size = new System.Drawing.Size(584, 281);
            this.pnTarget.TabIndex = 0;
            // 
            // pnToolOption
            // 
            this.pnToolOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnToolOption.Controls.Add(this.label3);
            this.pnToolOption.Controls.Add(this.label2);
            this.pnToolOption.Controls.Add(this.tbQuality);
            this.pnToolOption.Controls.Add(this.label1);
            this.pnToolOption.Controls.Add(this.cbFullscreen);
            this.pnToolOption.Controls.Add(this.btnStart);
            this.pnToolOption.Location = new System.Drawing.Point(142, 72);
            this.pnToolOption.Name = "pnToolOption";
            this.pnToolOption.Size = new System.Drawing.Size(293, 129);
            this.pnToolOption.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "高质量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "低质量";
            // 
            // tbQuality
            // 
            this.tbQuality.Location = new System.Drawing.Point(108, 21);
            this.tbQuality.Maximum = 100;
            this.tbQuality.Minimum = 1;
            this.tbQuality.Name = "tbQuality";
            this.tbQuality.Size = new System.Drawing.Size(173, 45);
            this.tbQuality.TabIndex = 19;
            this.tbQuality.Value = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "提示:窗口边界即为录制边界";
            // 
            // cbFullscreen
            // 
            this.cbFullscreen.AutoSize = true;
            this.cbFullscreen.Location = new System.Drawing.Point(14, 21);
            this.cbFullscreen.Name = "cbFullscreen";
            this.cbFullscreen.Size = new System.Drawing.Size(72, 16);
            this.cbFullscreen.TabIndex = 17;
            this.cbFullscreen.Text = "全屏工作";
            this.cbFullscreen.UseVisualStyleBackColor = true;
            this.cbFullscreen.CheckedChanged += new System.EventHandler(this.CbFullscreen_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(206, 77);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 38);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // ScreenRecordForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 281);
            this.Controls.Add(this.pnTarget);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenRecordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕录制";
            this.TransparencyKey = System.Drawing.Color.Green;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenRecordForm_FormClosing);
            this.Load += new System.EventHandler(this.ScreenRecordForm_Load);
            this.pnTarget.ResumeLayout(false);
            this.pnToolOption.ResumeLayout(false);
            this.pnToolOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTarget;
        private System.Windows.Forms.Panel pnToolOption;
        private System.Windows.Forms.CheckBox cbFullscreen;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbQuality;
    }
}