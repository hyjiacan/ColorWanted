using ColorWanted.theme;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ColorWanted
{
    internal partial class BugReportForm : Form
    {
        /// <summary>
        /// 数据模板
        /// </summary>
        private const string template =
@"OS Version: {0}
.NET Version: {1}
App Version: {2}
Error Type: {3}
Error message: {4}
Error Stack: {5}
";

        public BugReportForm()
        {
            componentsLayout();
            ThemeUtil.Apply(this);

        }

        internal void SetException(Exception exception)
        {
            tbMsg.Clear();
            tbMsg.AppendText(string.Format(template,
            Environment.OSVersion,
            Environment.Version,
            Application.ProductVersion,
            exception.GetType().FullName,
            exception.Message,
            exception.StackTrace));
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbMsg.Text);
            btnCopy.Text = "已复制";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbRestart.Checked)
            {
                try
                {
                    Application.Restart();
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sorry that I cannot restart myself.");
                    Environment.Exit(1);
                }
                return;
            }
            Environment.Exit(0);
        }

        private void lkIssue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lkIssue.Text);
        }
    }
}
