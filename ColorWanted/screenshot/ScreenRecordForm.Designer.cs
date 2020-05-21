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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFps = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFullscreen = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnTarget.SuspendLayout();
            this.pnToolOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFps)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTarget
            // 
            this.pnTarget.BackColor = System.Drawing.Color.Green;
            this.pnTarget.Controls.Add(this.pnToolOption);
            this.pnTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTarget.Location = new System.Drawing.Point(0, 0);
            this.pnTarget.Name = "pnTarget";
            this.pnTarget.Size = new System.Drawing.Size(584, 441);
            this.pnTarget.TabIndex = 0;
            // 
            // pnToolOption
            // 
            this.pnToolOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnToolOption.BackColor = System.Drawing.SystemColors.Control;
            this.pnToolOption.Controls.Add(this.label6);
            this.pnToolOption.Controls.Add(this.label5);
            this.pnToolOption.Controls.Add(this.label4);
            this.pnToolOption.Controls.Add(this.tbFps);
            this.pnToolOption.Controls.Add(this.label1);
            this.pnToolOption.Controls.Add(this.cbFullscreen);
            this.pnToolOption.Controls.Add(this.btnStart);
            this.pnToolOption.Location = new System.Drawing.Point(114, 111);
            this.pnToolOption.Name = "pnToolOption";
            this.pnToolOption.Size = new System.Drawing.Size(360, 200);
            this.pnToolOption.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "40";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "帧速率";
            // 
            // tbFps
            // 
            this.tbFps.Location = new System.Drawing.Point(110, 55);
            this.tbFps.Maximum = 40;
            this.tbFps.Minimum = 8;
            this.tbFps.Name = "tbFps";
            this.tbFps.Size = new System.Drawing.Size(173, 45);
            this.tbFps.TabIndex = 4;
            this.tbFps.Value = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(27, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "提示:窗口边界即为录制边界，按下 Alt + R 结束录屏";
            // 
            // cbFullscreen
            // 
            this.cbFullscreen.AutoSize = true;
            this.cbFullscreen.Location = new System.Drawing.Point(110, 127);
            this.cbFullscreen.Name = "cbFullscreen";
            this.cbFullscreen.Size = new System.Drawing.Size(72, 16);
            this.cbFullscreen.TabIndex = 5;
            this.cbFullscreen.Text = "全屏工作";
            this.cbFullscreen.UseVisualStyleBackColor = true;
            this.cbFullscreen.CheckedChanged += new System.EventHandler(this.CbFullscreen_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(208, 115);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 38);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // ScreenRecordForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.pnTarget);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenRecordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "屏幕录制";
            this.TransparencyKey = System.Drawing.Color.Green;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenRecordForm_FormClosing);
            this.Load += new System.EventHandler(this.ScreenRecordForm_Load);
            this.pnTarget.ResumeLayout(false);
            this.pnToolOption.ResumeLayout(false);
            this.pnToolOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTarget;
        private System.Windows.Forms.Panel pnToolOption;
        private System.Windows.Forms.CheckBox cbFullscreen;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbFps;
    }
}