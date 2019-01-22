using ColorWanted.ext;
using ColorWanted.setting;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ColorWanted.theme;
using ColorWanted.util;

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
                var mainForm = Application.OpenForms["MainForm"] as MainForm;
                if (mainForm != null)
                    mainForm
                        .ShowTip(2000, "正在查询更新信息，求你不要再点了...");
                return;
            }

            Instance.Height = 110;
            Instance.Top = Screen.PrimaryScreen.WorkingArea.Height - 110;
            Instance.pnDetail.Hide();

            Instance.Left = Util.GetScreenSize().Width;

            Instance.Show();
            Instance.BringToFront();
            Instance.SlideIn();
            new Thread(Instance.RunCheck) { IsBackground = true }.Start();
        }

        private UpdateForm()
        {
            InitializeComponent();
            ThemeUtil.Apply(this);
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
            if (updateStatePresent.IsBusy)
            {
                return;
            }
            Busy = true;

            updateStatePresent.RunWorkerAsync();

            this.InvokeMethod(() =>
            {
                linkNow.Visible = linkIgnore.Visible = linkNext.Visible = false;
                lbCurrent.Text = @"当前版本 " + Application.ProductVersion;
                lbMsg.Text = @"正在检查更新版本...";
            });

            update = OnlineUpdate.Check();

            Settings.Update.LastUpdate = DateTime.Now;

            Busy = false;
            updateStatePresent.CancelAsync();

            this.InvokeMethod(() =>
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

                lbUpdateDate.Text = update.Date.ToString("yyyy年MM月dd日");

                lbLog.Text = update.Message;

                Top = Screen.PrimaryScreen.WorkingArea.Height - 240;
                Height = 240;
                pnDetail.Show();

                linkNow.Visible = linkIgnore.Visible = linkNext.Visible = true;

                if (!AutoClose)
                    return;

                SlideIn();
            });
        }

        private void SlideIn()
        {
            new Thread(() =>
            {
                var step = 8;
                var offset = 0;
                while (offset < Width)
                {
                    var step1 = step;
                    this.InvokeMethod(() =>
                    {
                        Left -= step1;
                        Application.DoEvents();
                    });
                    offset += step1;
                    step = (int)(step * 1.2);
                    Thread.Sleep(50);
                }
                this.InvokeMethod(() =>
                {
                    Left = Util.GetScreenSize().Width - Width;
                    btnExit.Show();
                });
                DelayHide(15000);
            }) { IsBackground = true }.Start();
        }

        private void SlideOut()
        {
            this.InvokeMethod(() =>
            {
                btnExit.Hide();
            });
            new Thread(() =>
            {
                var step = 8;
                while (Width > 0)
                {
                    var step1 = step;
                    this.InvokeMethod(() =>
                    {
                        Width -= step1;
                        Left += step1;
                    });
                    step = (int)(step * 1.2);
                    Thread.Sleep(50);
                }
                this.InvokeMethod(() =>
                {
                    Width = 0;
                    Left = Util.GetScreenSize().Width;
                });
            }) { IsBackground = true }.Start();
        }

        private void updateStatePresent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.InvokeMethod(() =>
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
                this.InvokeMethod(() =>
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
            new Thread(() =>
            {
                OnlineUpdate.Update(update.Link, update.Version, result =>
                {
                    if (!result.Success)
                    {
                        this.InvokeMethod(() =>
                        {
                            lbMsg.Text = @"更新包下载失败";
                        });
                        return;
                    }

                    this.InvokeMethod(() =>
                    {
                        if (!lbPercentage.Visible)
                        {
                            lbPercentage.Show();
                            lbProgress.Show();
                        }
                        lbPercentage.Text = string.Format(@"{0}K / {1}K    {2}%",
                            Math.Ceiling(result.BytesReceived / 1024.0),
                            Math.Ceiling(result.TotalBytesToReceive / 1024.0),
                            result.Percentage);

                        lbProgress.Width = lbPercentage.Width * result.Percentage / 100;

                        if (result.TotalBytesToReceive == result.BytesReceived)
                        {
                            lbMsg.Text = @"更新包下载完成，即将更新...";
                        }
                    });

                    DelayHide();
                });
            }) { IsBackground = true }.Start();
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
                SlideOut();
                lbMsg.Text = "";
                linkNow.Visible = linkIgnore.Visible = linkNext.Visible = false;
                lbPercentage.Hide();
                lbProgress.Hide();
                lbProgress.Width = 0;
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

        private void UpdateForm_MouseEnter(object sender, EventArgs e)
        {
            CancelHide();
        }

        private void UpdateForm_MouseLeave(object sender, EventArgs e)
        {
            // 鼠标还在窗体区域内时，不触发事件
            if (Bounds.Contains(MousePosition))
            {
                return;
            }
            DelayHide();
        }
    }
}
