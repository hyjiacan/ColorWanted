
namespace ColorWanted.screenshot
{
    partial class DelayedScreenshotForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.numSeconds = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "延时";
            this.label1.MouseLeave += new System.EventHandler(this.DelayedScreenshotForm_MouseLeave);
            // 
            // numSeconds
            // 
            this.numSeconds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numSeconds.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numSeconds.Location = new System.Drawing.Point(40, 6);
            this.numSeconds.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numSeconds.Name = "numSeconds";
            this.numSeconds.Size = new System.Drawing.Size(41, 22);
            this.numSeconds.TabIndex = 1;
            this.numSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "秒";
            this.label2.MouseLeave += new System.EventHandler(this.DelayedScreenshotForm_MouseLeave);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(12, 31);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(86, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "准备截图";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseLeave += new System.EventHandler(this.DelayedScreenshotForm_MouseLeave);
            // 
            // DelayedScreenshotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(110, 60);
            this.ControlBox = false;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numSeconds);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(110, 60);
            this.MinimizeBox = false;
            this.Name = "DelayedScreenshotForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ScreenshotCountdown";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DelayedScreenshotForm_Load);
            this.MouseEnter += new System.EventHandler(this.DelayedScreenshotForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.DelayedScreenshotForm_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSeconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
    }
}