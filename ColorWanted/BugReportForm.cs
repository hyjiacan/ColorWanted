using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ColorWanted
{
    public partial class BugReportForm : Form
    {
        /// <summary>
        /// 数据模板
        /// </summary>
        private const string template = 
@"操作系统: {0}
.NET版本: {1}
程序: {2}
程序版本: {3}
错误消息: {4}
错误源: {5}
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
            Application.ProductName,
            Application.ProductVersion,
            exception.Message,
            exception.StackTrace));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var data = Convert.ToBase64String(
                Encoding.UTF8.GetBytes(
                    tbMsg.Text + "\r" + tbExtra.Text));

            try
            {
                new WebClient().UploadString(
                        "http://www.hyjiacan.com/git/bug.php?token=bugreport",
                        "post",
                        data);
            }
            catch
            {
                // ignore
            }

            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lkIssue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lkIssue.Text);
        }
    }
}
