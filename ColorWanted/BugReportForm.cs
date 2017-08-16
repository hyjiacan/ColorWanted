using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new WebClient();
                client.UploadValues(
                        "http://git.hyjiacan.com/bug.php?token=bugreport",
                        "post",
                        new NameValueCollection
                        {
                            {"project", Convert.ToBase64String(Encoding.UTF8.GetBytes(Application.ProductName))},
                            {"summary", Convert.ToBase64String(Encoding.UTF8.GetBytes(tbMsg.Text))},
                            {"extra", Convert.ToBase64String(Encoding.UTF8.GetBytes(tbExtra.Text))}
                        });
            }
            catch
            {
                // ignore
            }
            if (cbRestart.Checked)
            {
                Application.Restart();
                return;
            }
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
