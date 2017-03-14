using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ColorWanted
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            lbVersion.Text = @"v " + Application.ProductVersion;
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

        private void llCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(llScm.Text);
        }
    }
}
