
using System;

namespace ColorWanted.setting
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.pnContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.rbLangEn = new System.Windows.Forms.RadioButton();
            this.rbLangZh = new System.Windows.Forms.RadioButton();
            this.btnTheme = new System.Windows.Forms.Button();
            this.btnHotkey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContainer
            // 
            this.pnContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnContainer.AutoScroll = true;
            this.pnContainer.Location = new System.Drawing.Point(12, 92);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(560, 426);
            this.pnContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rbLangEn);
            this.panel1.Controls.Add(this.rbLangZh);
            this.panel1.Controls.Add(this.btnTheme);
            this.panel1.Controls.Add(this.btnHotkey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnOpenFile);
            this.panel1.Controls.Add(this.tbFilePath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 81);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(0, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(560, 1);
            this.label3.TabIndex = 7;
            // 
            // rbLangEn
            // 
            this.rbLangEn.AutoSize = true;
            this.rbLangEn.Location = new System.Drawing.Point(115, 49);
            this.rbLangEn.Name = "rbLangEn";
            this.rbLangEn.Size = new System.Drawing.Size(65, 16);
            this.rbLangEn.TabIndex = 6;
            this.rbLangEn.TabStop = true;
            this.rbLangEn.Text = "English";
            this.rbLangEn.UseVisualStyleBackColor = true;
            this.rbLangEn.CheckedChanged += new System.EventHandler(this.rbLangEn_CheckedChanged);
            // 
            // rbLangZh
            // 
            this.rbLangZh.AutoSize = true;
            this.rbLangZh.Location = new System.Drawing.Point(62, 49);
            this.rbLangZh.Name = "rbLangZh";
            this.rbLangZh.Size = new System.Drawing.Size(47, 16);
            this.rbLangZh.TabIndex = 5;
            this.rbLangZh.TabStop = true;
            this.rbLangZh.Text = "中文";
            this.rbLangZh.UseVisualStyleBackColor = true;
            this.rbLangZh.CheckedChanged += new System.EventHandler(this.rbLangZh_CheckedChanged);
            // 
            // btnTheme
            // 
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheme.Location = new System.Drawing.Point(311, 46);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(75, 23);
            this.btnTheme.TabIndex = 2;
            this.btnTheme.Text = "主题配色";
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // btnHotkey
            // 
            this.btnHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHotkey.Location = new System.Drawing.Point(392, 46);
            this.btnHotkey.Name = "btnHotkey";
            this.btnHotkey.Size = new System.Drawing.Size(75, 23);
            this.btnHotkey.TabIndex = 2;
            this.btnHotkey.Text = "快捷键";
            this.btnHotkey.UseVisualStyleBackColor = true;
            this.btnHotkey.Click += new System.EventHandler(this.btnHotkey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "语言";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Location = new System.Drawing.Point(473, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "打开";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.BackColor = System.Drawing.Color.White;
            this.tbFilePath.Location = new System.Drawing.Point(62, 13);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(405, 21);
            this.tbFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "配置文件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 534);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(365, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "设置项在变更后会自动保存。但红色标记项需要重启软件才能生效。";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选项";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnHotkey;
        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbLangZh;
        private System.Windows.Forms.RadioButton rbLangEn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}