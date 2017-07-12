using ColorWanted.ext;
using ColorWanted.setting;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ColorWanted.update
{
    internal partial class UpdateForm : Form
    {
        /// <summary>
        /// 定时隐藏升级提示窗口
        /// </summary>
        private System.Threading.Timer hideTimer;

        private static UpdateForm Instance;
        private static bool AutoClose;

        private UpdateInfo update;

        private bool Busy;

        /// <summary>
        /// 呈现更新状态的后台线程
        /// </summary>
        private BackgroundWorker updateStatePresent;

        private Image originLogo;

        /// <summary>
        /// 
        /// </summary>
        public static void ShowWindow(bool autoClose = false)
        {
            AutoClose = autoClose;

            if (Instance == null)
            {
                Instance = new UpdateForm();
            }

            if (Instance.Busy)
            {
                return;
            }

            Instance.Show();
            Instance.BringToFront();
            new Thread(Instance.RunCheck) { IsBackground = true }.Start();
        }

        private UpdateForm()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen.WorkingArea;
            Location = new Point(screen.Width - Width, screen.Height - Height);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                var cp = base.CreateParams;
                cp.ExStyle &= ~WS_EX_APPWINDOW;    // 不显示在TaskBar
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
            DelayHide(0);
        }

        private void RunCheck()
        {
            if (updateStatePresent == null)
            {
                updateStatePresent = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true
                };
                updateStatePresent.DoWork += updateStatePresent_DoWork;
                updateStatePresent.RunWorkerCompleted += updateStatePresent_RunWorkerCompleted;
            }
            Busy = true;

            updateStatePresent.RunWorkerAsync();

            InvokeMethod(() =>
            {
                linkNow.Visible = linkIgnore.Visible = linkNext.Visible = false;
                lbCurrent.Text = @"当前版本 " + Application.ProductVersion;
                lbMsg.Text = @"正在检查更新版本...";
            });

            update = OnlineUpdate.Check();

            Settings.Update.LastUpdate = DateTime.Now;
            
                Busy = false;
            updateStatePresent.CancelAsync();

            InvokeMethod(() =>
            {
                if (update == null)
                {
                    lbMsg.Text = @"没有更新版本";
                    DelayHide();
                    return;
                }

                if (!update.Status)
                {
                    lbMsg.Text = @"检查更新失败";
                    DelayHide();
                    return;
                }

                if (update.Version == Settings.Update.IgnoreVersion)
                {
                    if (AutoClose)
                    {
                        DelayHide();
                        return;
                    }

                    lbMsg.Text = string.Format(@"有新版本 {0} (已忽略)", update.Version);
                }
                else
                {
                    lbMsg.Text = @"有新版本 " + update.Version;
                }

                linkNow.Visible = linkIgnore.Visible = linkNext.Visible = true;

                if (!AutoClose)
                {
                    return;
                }
                DelayHide(15000);
            });
        }

        private void updateStatePresent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InvokeMethod(() =>
            {
                picLOGO.Image = originLogo;
                picLOGO.Refresh();
            });
        }

        private void updateStatePresent_DoWork(object sender, DoWorkEventArgs e)
        {
            originLogo = picLOGO.Image;

            // 反转logo颜色
            var reverse = new Bitmap(originLogo);
            for (var i = 0; i < reverse.Width; i++)
            {
                for (var j = 0; j < reverse.Height; j++)
                {
                    var c = reverse.GetPixel(i, j);
                    reverse.SetPixel(i, j,
                        Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }

            var x = 1;

            while (true)
            {
                if (!Busy)
                {
                    break;
                }
                var x1 = x;
                InvokeMethod(() =>
                {
                    picLOGO.Image = x1 == 1 ? reverse : originLogo;
                    picLOGO.Refresh();
                });
                Thread.Sleep(250);
                x *= -1;
            }
        }

        private void linkNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelHide();
            linkNow.Visible = linkIgnore.Visible = linkNext.Visible = false;
            lbMsg.Text = string.Format(@"正在下载更新包({0})...", update.Version);
            OnlineUpdate.Update(update.Link, update.Version, result =>
            {
                var msg = @"更新包下载" + (result ? @"完成" : @"失败");

                InvokeMethod(() =>
                {
                    lbMsg.Text = msg;
                });

                DelayHide();
                return true;
            });
        }

        private void linkIgnore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Update.IgnoreVersion = update.Version;
            CancelHide();
            DelayHide(0);
        }

        private void linkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelHide();
            DelayHide(0);
        }

        private void DelayHide(int timeout = 5000)
        {
            if (timeout == 0)
            {
                Hide();
                return;
            }

            if (hideTimer != null)
            {
                hideTimer.Change(timeout, Timeout.Infinite);
                return;
            }

            hideTimer = new System.Threading.Timer(state =>
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        DelayHide(0);
                    }));
                }
                else
                {
                    DelayHide(0);
                }
            }, null, timeout, Timeout.Infinite);
        }

        private void CancelHide()
        {
            if (hideTimer == null) return;

            hideTimer.Dispose();
            hideTimer = null;
        }

        private delegate void Invoker();

        private void InvokeMethod(Invoker invoker)
        {
            if (IsDisposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(invoker));
            }
            else
            {
                invoker.Invoke();
            }
        }
    }
}
