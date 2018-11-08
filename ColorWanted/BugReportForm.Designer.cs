namespace ColorWanted
{
    partial class BugReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugReportForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.lkIssue = new System.Windows.Forms.LinkLabel();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbRestart = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "不好意思，出问题了";
            // 
            // tbMsg
            // 
            this.tbMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tbMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMsg.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.tbMsg.Location = new System.Drawing.Point(33, 64);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ReadOnly = true;
            this.tbMsg.Size = new System.Drawing.Size(478, 154);
            this.tbMsg.TabIndex = 0;
            this.tbMsg.WordWrap = false;
            // 
            // lkIssue
            // 
            this.lkIssue.AutoSize = true;
            this.lkIssue.LinkColor = System.Drawing.Color.Lime;
            this.lkIssue.Location = new System.Drawing.Point(31, 257);
            this.lkIssue.Name = "lkIssue";
            this.lkIssue.Size = new System.Drawing.Size(335, 12);
            this.lkIssue.TabIndex = 4;
            this.lkIssue.TabStop = true;
            this.lkIssue.Text = "https://git.oschina.net/hyjiacan/ColorWanted/issues/new";
            this.lkIssue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkIssue_LinkClicked);
            // 
            // btnOk
            // 
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnOk.FlatAppearance.BorderSize = 2;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(383, 278);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(128, 36);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOKl_Click);
            // 
            // cbRestart
            // 
            this.cbRestart.AutoSize = true;
            this.cbRestart.Checked = true;
            this.cbRestart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRestart.Location = new System.Drawing.Point(37, 290);
            this.cbRestart.Name = "cbRestart";
            this.cbRestart.Size = new System.Drawing.Size(69, 16);
            this.cbRestart.TabIndex = 13;
            this.cbRestart.Text = "重新启动";
            this.cbRestart.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "请复制以上信息到以下地址手动提供这些错误信息";
            // 
            // btnCopy
            // 
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCopy.FlatAppearance.BorderSize = 2;
            this.btnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCopy.Location = new System.Drawing.Point(383, 233);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(128, 36);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // BugReportForm
            // 
            this.AcceptButton = this.btnCopy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(542, 340);
            this.Controls.Add(this.cbRestart);
            this.Controls.Add(this.lkIssue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BugReportForm";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUG报告-赏色";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.LinkLabel lkIssue;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox cbRestart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCopy;
    }
}