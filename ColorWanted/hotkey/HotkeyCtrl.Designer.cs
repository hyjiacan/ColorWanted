namespace ColorWanted.hotkey
{
    partial class HotkeyCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeyCtrl));
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lbTypeName = new System.Windows.Forms.Label();
            this.lkOK = new System.Windows.Forms.LinkLabel();
            this.lkReset = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.AcceptsReturn = true;
            this.tbInput.AcceptsTab = true;
            resources.ApplyResources(this.tbInput, "tbInput");
            this.tbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInput.Name = "tbInput";
            this.tbInput.ReadOnly = true;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
            this.tbInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyUp);
            // 
            // lbTypeName
            // 
            resources.ApplyResources(this.lbTypeName, "lbTypeName");
            this.lbTypeName.Name = "lbTypeName";
            // 
            // lkOK
            // 
            resources.ApplyResources(this.lkOK, "lkOK");
            this.lkOK.LinkColor = System.Drawing.Color.Lime;
            this.lkOK.Name = "lkOK";
            this.lkOK.TabStop = true;
            this.lkOK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkOK_LinkClicked);
            // 
            // lkReset
            // 
            resources.ApplyResources(this.lkReset, "lkReset");
            this.lkReset.LinkColor = System.Drawing.Color.Lime;
            this.lkReset.Name = "lkReset";
            this.lkReset.TabStop = true;
            this.lkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkReset_LinkClicked);
            // 
            // HotkeyCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lkReset);
            this.Controls.Add(this.lkOK);
            this.Controls.Add(this.lbTypeName);
            this.Controls.Add(this.tbInput);
            this.Name = "HotkeyCtrl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lbTypeName;
        private System.Windows.Forms.LinkLabel lkOK;
        private System.Windows.Forms.LinkLabel lkReset;
    }
}
