using System;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    public partial class DelayedScreenShotForm : Form
    {
        /// <summary>
        /// 延时截图的计时器
        /// </summary>
        private Timer screenshotTimer;
        private Timer visibleWatchTimer;

        public DelayedScreenShotForm()
        {
            InitializeComponent();
        }

        private void DelayedScreenshotForm_Load(object sender, EventArgs e)
        {
            screenshotTimer = new Timer
            {
                Interval = 1000
            };
            screenshotTimer.Tick += ScreenshotTimer_Tick;

            // 如果窗口显示后1秒鼠标都没有移到到窗口上，那么隐藏窗口
            visibleWatchTimer = new Timer
            {
                Interval = 1000
            };
            visibleWatchTimer.Tick += VisibleWatchTimer_Tick;
        }

        private void ScreenshotTimer_Tick(object sender, EventArgs e)
        {
            var seconds = numSeconds.Value;

            if (seconds > 0)
            {
                numSeconds.Value--;
                return;
            }

            screenshotTimer.Stop();
            Hide();
            btnStart.Text = "准备截图";
            numSeconds.Enabled = true;
            Application.DoEvents();
            // 执行截图操作
            ScreenShot.Capture();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (screenshotTimer.Enabled)
            {
                numSeconds.Enabled = true;
                screenshotTimer.Stop();
                btnStart.Text = "准备截图";
                return;
            }

            numSeconds.Enabled = false;
            screenshotTimer.Start();
            btnStart.Text = "中止";
        }

        private void DelayedScreenshotForm_MouseLeave(object sender, EventArgs e)
        {
            if (Bounds.Contains(MousePosition))
            {
                return;
            }

            if (screenshotTimer.Enabled)
            {
                Opacity = 0.5;
                return;
            }

            // 取消截图操作
            Hide();
            numSeconds.Enabled = true;
        }

        private void DelayedScreenshotForm_MouseEnter(object sender, EventArgs e)
        {
            if (Opacity != 1)
            {
                Opacity = 1;
            }
            if (screenshotTimer.Enabled)
            {
                btnStart.Focus();
            }
            else
            {
                numSeconds.Focus();
            }
        }

        private void DelayedScreenshotForm_VisibleChanged(object sender, EventArgs e)
        {
            visibleWatchTimer.Enabled = Visible;
        }

        private void VisibleWatchTimer_Tick(object sender, EventArgs e)
        {
            if (!Bounds.Contains(MousePosition))
            {
                Hide();
            }
        }
    }
}
