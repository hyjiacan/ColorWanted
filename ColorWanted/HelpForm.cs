using System;
using System.Diagnostics;
using System.Windows.Forms;
using ColorWanted.ext;
using ColorWanted.util;

namespace ColorWanted
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();

            lbVersion.Text = @"v" + Application.ProductVersion;
        }

        private void MouseDownEventHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_SYSCOMMAND,
                    new IntPtr(NativeMethods.SC_MOVE + NativeMethods.HTCAPTION), IntPtr.Zero);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void llScm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(llScm.Text);
        }

        private void lkCopySourceUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.SetClipboard(Handle, llScm.Text);
        }

        private void lkVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lkRelease.Text);
        }

        private void lkCopyReleaseUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.SetClipboard(Handle, lkRelease.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://www.gnu.org/licenses/gpl-3.0.html");
        }
    }
}
