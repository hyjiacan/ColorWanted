using ColorWanted.ext;
using ColorWanted.setting;
using ColorWanted.theme;
using ColorWanted.util;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ColorWanted.update
{
    /// <summary>
    /// 更新窗口，作为单例使用
    /// </summary>
    internal partial class UpdateForm : Form
    {
        i18n.I18nManager resources = new i18n.I18nManager(typeof(UpdateForm));
        /// <summary>
        /// 定时隐藏升级提示窗口
        /// </summary>
        private System.Threading.Timer hideTimer;
        /// <summary>
        /// 实例
        /// </summary>
        private static UpdateForm Instance;
        /// <summary>
        /// 更新请求是否是来自于自动更新
        /// </summary>
        private static bool FromAutoUpdate;

        private UpdateInfo update;

        /// <summary>
        /// 是否正在检查更新
        /// </summary>
        private bool Busy;

        /// <summary>
        /// 呈现更新状态的后台线程
        /// </summary>
        private BackgroundWorker updateStatePresent;

        private Image originLogo;
        private Bitmap reverseLogo;

        /// <summary>
        /// 显示检查更新的窗口
        /// <paramref name="fromAutoUpdate">更新请求是否是来自于自动更新</paramref>
        /// </summary>
        public static void ShowWindow(bool fromAutoUpdate = false)
        {
            FromAutoUpdate = fromAutoUpdate;

            if (Instance == null)
            {
                Instance = new UpdateForm();
            }

            if (Instance.Busy)
            {
                var mainForm = Application.OpenForms["MainForm"] as MainForm;
                if (mainForm != null)
                    mainForm
                        .ShowTip(2000, Instance.resources.GetString("updateIsBusy"));
                return;
            }

            Instance.Height = 110;
            Instance.Top = Screen.PrimaryScreen.WorkingArea.Height - 110;
            Instance.pnDetail.Hide();

            Instance.Left = Util.GetScreenSize().Width;

            // 如果不是来自自动更新，就先显示窗口
            if (!FromAutoUpdate)
            {
                Instance.SlideIn(() =>
                {
                    Instance.InvokeMethod(() =>
                    {
                        Instance.Left = Util.GetScreenSize().Width - Instance.Width;
                        Instance.btnExit.Show();
                    });
                });
            }
            // 启动检查更新
            new Thread(Instance.RunCheck) { IsBackground = true }.Start();
        }

        private UpdateForm()
        {
            componentsLayout();
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
                lbCurrent.Text = $"{resources.GetString("currentVersion")} " + Application.ProductVersion;
                lbMsg.Text = resources.GetString("checking");
            });

            update = OnlineUpdate.Check();

            Settings.Update.LastUpdate = DateTime.Now;

            Busy = false;
            updateStatePresent.CancelAsync();

            this.InvokeMethod(() =>
            {
                // 没有更新
                if (update == null)
                {
                    lbMsg.Text = resources.GetString("noupdate");
                    DelayHide();
                    return;
                }

                // 检查更新失败
                if (!update.Status)
                {
                    lbMsg.Text = resources.GetString("checkFailed");
                    DelayHide();
                    return;
                }

                // 检查到更新，但是已经被忽略
                if (update.Version == Settings.Update.IgnoreVersion)
                {
                    lbMsg.Text = string.Format(resources.GetString("newVersionIgnored"), update.Version);
                    DelayHide();
                    return;
                }

                // 检查到可用的更新
                lbMsg.Text = $"{resources.GetString("newVersion")} " + update.Version;


                lbUpdateDate.Text = update.Date.ToLongDateString();

                lbLog.Text = update.Message;

                Top = Screen.PrimaryScreen.WorkingArea.Height - 240;
                Height = 240;
                pnDetail.Show();

                linkNow.Visible = linkIgnore.Visible = linkNext.Visible = true;

                // 当不是来自于自动更新时，窗口已经处于可见状态
                if (!FromAutoUpdate)
                    return;

                // 只有来自于自动更新时，窗口才是在检查到更新到才显示
                this.SlideIn(() =>
                {
                    this.InvokeMethod(() =>
                    {
                        Left = Util.GetScreenSize().Width - Width;
                        btnExit.Show();
                    });
                    DelayHide(15000);
                });
            });
        }


        private void updateStatePresent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.InvokeMethod(() =>
            {
                picLOGO.Image = originLogo;
                picLOGO.Refresh();
            });
        }

        /// <summary>
        /// 闪烁窗口图标，表示正在检查更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateStatePresent_DoWork(object sender, DoWorkEventArgs e)
        {
            originLogo = picLOGO.Image;

            // 反转logo颜色
            if (reverseLogo == null)
            {
                reverseLogo = new Bitmap(originLogo);
                for (var i = 0; i < reverseLogo.Width; i++)
                {
                    for (var j = 0; j < reverseLogo.Height; j++)
                    {
                        var c = reverseLogo.GetPixel(i, j);
                        reverseLogo.SetPixel(i, j,
                        Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                    }
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
                    picLOGO.Image = x1 == 1 ? reverseLogo : originLogo;
                    picLOGO.Refresh();
                });
                Thread.Sleep(250);
                x *= -1;
            }
        }

        /// <summary>
        /// 立即更新 被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelHide();
            linkNow.Visible = linkIgnore.Visible = linkNext.Visible = false;
            lbMsg.Text = string.Format(resources.GetString("downloading") + "({0})...", update.Version);

            lbPercentage.Text = "0K / 0K    0%";
            if (!lbPercentage.Visible)
            {
                lbPercentage.Show();
                lbProgress.Show();
            }
            Application.DoEvents();
            new Thread(() =>
            {
                OnlineUpdate.Update(update.Link, update.Version, result =>
                {
                    if (!result.Success)
                    {
                        this.InvokeMethod(() =>
                        {
                            lbMsg.Text = resources.GetString("downloadFailed");
                        });
                        return;
                    }

                    this.InvokeMethod(() =>
                    {
                        lbPercentage.Text = string.Format(@"{0}K / {1}K    {2}%",
                            Math.Ceiling(result.BytesReceived / 1024.0),
                            Math.Ceiling(result.TotalBytesToReceive / 1024.0),
                            result.Percentage);

                        lbProgress.Width = lbPercentage.Width * result.Percentage / 100;

                        if (result.TotalBytesToReceive == result.BytesReceived)
                        {
                            lbMsg.Text = resources.GetString("downloadComplete");
                        }
                    });
                });
            })
            { IsBackground = true }.Start();
        }

        /// <summary>
        /// 忽略此版本 被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkIgnore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Update.IgnoreVersion = update.Version;
            CancelHide();
            DelayHide(0);
        }

        /// <summary>
        /// 下次再说 被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelHide();
            DelayHide(0);
        }

        /// <summary>
        /// 延迟关闭窗口
        /// </summary>
        /// <param name="timeout"></param>
        private void DelayHide(int timeout = 5000)
        {
            if (timeout == 0)
            {
                this.InvokeMethod(() =>
                {
                    btnExit.Hide();
                });
                this.SlideOut();
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

        /// <summary>
        /// 取消关闭窗口
        /// </summary>
        private void CancelHide()
        {
            if (hideTimer == null) return;

            hideTimer.Dispose();
            hideTimer = null;
        }

        /// <summary>
        /// 鼠标放到窗口上时，取消关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateForm_MouseEnter(object sender, EventArgs e)
        {
            CancelHide();
        }

        /// <summary>
        /// 鼠标离开窗口时，延迟关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateForm_MouseLeave(object sender, EventArgs e)
        {
            if (hideTimer == null)
            {
                return;
            }
            // 鼠标还在窗体区域内时，不触发事件
            if (Bounds.Contains(MousePosition))
            {
                return;
            }
            DelayHide();
        }
    }
}
