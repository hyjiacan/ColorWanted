using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ColorWanted.theme;

namespace ColorWanted
{
    internal partial class BugReportForm : Form
    {
        /// <summary>
        /// 数据模板
        /// </summary>
        private const string template =
@"操作系统: {0}
.NET版本: {1}
程序版本: {2}
错误消息: {3}
错误源: {4}
";

        public BugReportForm()
        {
            InitializeComponent();
            ThemeUtil.Apply(this);
        }

        internal void SetException(Exception exception)
        {
            tbMsg.Clear();
            tbMsg.AppendText(string.Format(template,
            Environment.OSVersion,
            Environment.Version,
            Application.ProductVersion,
            exception.Message,
            exception.StackTrace));
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbMsg.Text);
            btnCopy.Text = "已复制";
        }

        private void btnOKl_Click(object sender, EventArgs e)
        {
            if (cbRestart.Checked)
            {
                Application.Restart();
                return;
            }
            Application.Exit();
        }

        private void lkIssue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lkIssue.Text);
        }
    }
}
