using ColorWanted.ext;
using ColorWanted.hotkey;
using ColorWanted.update;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using ColorWanted.theme;

namespace ColorWanted
{
    internal partial class AboutForm : Form
    {
        public AboutForm()
        {
            componentsLayout();
            ThemeUtil.Apply(this);
            lkVersion.Text = @"v" + Application.ProductVersion;
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
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://www.gnu.org/licenses/gpl-3.0.html");
        }

        private void lkFeedback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/hyjiacan/ColorWanted/issues/new");
        }

        private void lkQQGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(
                @"http://shang.qq.com/wpa/qunwpa?idkey=c04a8be7a9e17c76e1f3bb0dadd59115b0c611d13a908235c7da3c612f85e4e9");
        }

        private void lkMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto://" + lkMail.Text);
        }

        private void lkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lkGithub.Text);
        }

        private void lkSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lkSite.Text + "?from=app&v=" + lkVersion.Text);
        }

        private void lkHotkey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = Application.OpenForms["HotkeyForm"] ?? new HotkeyForm();
            form.Show();
            form.BringToFront();
        }

        private void lkVersion_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateForm.ShowWindow();
        }
    }
}
