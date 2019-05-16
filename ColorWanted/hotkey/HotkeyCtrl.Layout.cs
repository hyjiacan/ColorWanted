namespace ColorWanted.hotkey
{
    partial class HotkeyCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer componentsSet = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (componentsSet != null))
            {
                componentsSet.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void componentsLayout()
        {
            i18n.I18nManager resources = new i18n.I18nManager(typeof(HotkeyCtrl));
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
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            resources.ApplyResources(this.tbInput, "tbInput");
            this.tbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInput.Location = new System.Drawing.Point(36, 30);
            this.tbInput.Name = "tbInput";
            this.tbInput.ReadOnly = true;
            this.tbInput.Size = new System.Drawing.Size(405, 21);
            this.tbInput.TabIndex = 21;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
            this.tbInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyUp);
            // 
            // lbTypeName
            // 
            this.lbTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTypeName.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTypeName.Location = new System.Drawing.Point(1, 1);
            resources.ApplyResources(this.lbTypeName, "lbTypeName");
            this.lbTypeName.Name = "lbTypeName";
            this.lbTypeName.Size = new System.Drawing.Size(600, 28);
            this.lbTypeName.TabIndex = 23;
            this.lbTypeName.AutoEllipsis = true;
            // 
            // lkOK
            // 
            this.lkOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lkOK.AutoSize = true;
            resources.ApplyResources(this.lkOK, "lkOK");
            this.lkOK.LinkColor = System.Drawing.Color.Lime;
            this.lkOK.Location = new System.Drawing.Point(482, 34);
            this.lkOK.Name = "lkOK";
            this.lkOK.Size = new System.Drawing.Size(29, 12);
            this.lkOK.TabIndex = 24;
            this.lkOK.TabStop = true;
            this.lkOK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkOK_LinkClicked);
            // 
            // lkReset
            // 
            this.lkReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lkReset.AutoSize = true;
            resources.ApplyResources(this.lkReset, "lkReset");
            this.lkReset.LinkColor = System.Drawing.Color.Lime;
            this.lkReset.Location = new System.Drawing.Point(540, 34);
            this.lkReset.Name = "lkReset";
            this.lkReset.Size = new System.Drawing.Size(53, 12);
            this.lkReset.TabIndex = 24;
            this.lkReset.TabStop = true;
            this.lkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkReset_LinkClicked);
            // 
            // HotkeyCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lkReset);
            this.Controls.Add(this.lkOK);
            this.Controls.Add(this.lbTypeName);
            this.Controls.Add(this.tbInput);
            this.Name = "HotkeyCtrl";
            this.Size = new System.Drawing.Size(619, 56);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbInput;
        public System.Windows.Forms.Label lbTypeName;
        public System.Windows.Forms.LinkLabel lkOK;
        public System.Windows.Forms.LinkLabel lkReset;
    }
}
