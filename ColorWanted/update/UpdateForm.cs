using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted.update
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen.WorkingArea;
            Location = new Point(screen.Width - Width, screen.Height - Height);
        }

        private UpdateInfo update;

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt-Tab
                return cp;
            }
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

        public bool ShowDetail { get; set; }

        public void Action()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    linkNow.Visible = linkIgnore.Visible = linkNext.Visible = false;
                    lbCurrent.Text = @"当前版本 " + Application.ProductVersion;

                    if (ShowDetail)
                    {
                        ShowWindow();
                    }
                    lbMsg.Text = @"正在检查更新版本...";
                }));
            }
            else
            {
                linkNow.Visible = linkIgnore.Visible = linkNext.Visible = false;
                lbCurrent.Text = @"当前版本 " + Application.ProductVersion;

                if (ShowDetail)
                {
                    ShowWindow();
                }
                lbMsg.Text = @"正在检查更新版本...";
            }
            var worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                update = OnlineUpdate.Check();
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        if (update == null)
                        {
                            lbMsg.Text = @"没有更新版本";
                            return;
                        }

                        if (!update.Status)
                        {
                            lbMsg.Text = @"查检更新失败";
                            return;
                        }

                        linkNow.Visible = linkIgnore.Visible = linkNext.Visible = true;

                        lbMsg.Text = @"有新版本 " + update.Version;

                        ShowWindow();
                    }));
                }
                else
                {
                    if (update == null)
                    {
                        lbMsg.Text = @"没有更新版本";
                        return;
                    }

                    if (!update.Status)
                    {
                        lbMsg.Text = @"查检更新失败";
                        return;
                    }

                    linkNow.Visible = linkIgnore.Visible = linkNext.Visible = true;

                    lbMsg.Text = @"有新版本 " + update.Version;

                    ShowWindow();
                }
            };
            worker.RunWorkerAsync();
        }

        private void linkNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbMsg.Text = @"正在下载更新包...";
            OnlineUpdate.Update(update.Link, update.Version, result =>
            {
                var msg = @"更新包下载" + (result ? @"完成" : @"失败");
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        lbMsg.Text = msg;
                    }));
                }
                else
                {
                    lbMsg.Text = msg;
                }

                Hide();
                return true;
            });
        }

        private void linkIgnore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.IgnoreVersion = update.Version;
            Hide();
        }

        private void linkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
        }

        private void ShowWindow()
        {
            Show();
            BringToFront();
        }
    }
}
