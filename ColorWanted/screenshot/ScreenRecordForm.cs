using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ColorWanted.ext;

namespace ColorWanted.screenshot
{
    public partial class ScreenRecordForm : Form
    {
        private Timer timer;
        private NativeMethods.HookProc hookProc;
        private int hook;
        private bool mouseDown;
        private Rectangle customizeWindowBounds;
        /// <summary>
        /// 每秒10帧，以和默认的gif帧时长100ms匹配
        /// </summary>
        private const int FRAME_RATE = 10;
        // GIF 默认的帧时长为100ms
        private const int INTERVAL = 100;

        public ScreenRecordForm()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var recordArea = new Rectangle(PointToScreen(pnTarget.Location), pnTarget.Size);

            var img = ScreenShot.GetScreen(recordArea.X, recordArea.Y, recordArea.Width, recordArea.Height);

            var p = PointToClient(MousePosition);
            img.Save(Path.Combine(ScreenRecordOption.CachePath,
                string.Format("{0}#{1}#{2}#{3}",
                    DateTime.Now.ToFileTime(), p.X, p.Y, mouseDown ? "1" : "0")),
                ScreenRecordOption.CodecInfo, ScreenRecordOption.EncoderParameters);
            img.Dispose();
            GC.Collect();
        }

        private void ScreenRecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // 卸载勾子
                NativeMethods.UnhookWindowsHookEx(hook);
            }
            catch
            {
                // ignore
            }
            if (timer == null)
            {
                return;
            }
            timer.Stop();
            timer.Dispose();
            Hide();
        }

        private void ScreenRecordForm_Load(object sender, EventArgs e)
        {
            // 创建缓存目录
            var cachePath = Path.Combine(Environment
                       .GetFolderPath(Environment.SpecialFolder.ApplicationData),
                   Application.ProductName, "record-cache", DateTime.Now.ToString("yyyyMMddHHmmss"));

            Directory.CreateDirectory(cachePath);

            ScreenRecordOption.CachePath = cachePath;

            hookProc = new NativeMethods.HookProc(MouseHookProc);
            hook = NativeMethods.SetWindowsHookEx(NativeMethods.WH_MOUSE_LL, hookProc, IntPtr.Zero, 0);

            TopMost = true;
            BringToFront();
        }
        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return NativeMethods.CallNextHookEx(hook, nCode, wParam, lParam);
            }

            switch ((int)wParam)
            {
                case NativeMethods.WM_LBUTTONDOWN:
                    mouseDown = true;
                    break;
                case NativeMethods.WM_RBUTTONDOWN:
                    break;
                case NativeMethods.WM_MBUTTONDOWN:
                    break;
                case NativeMethods.WM_LBUTTONUP:
                    mouseDown = false;
                    break;
                case NativeMethods.WM_RBUTTONUP:
                    break;
                case NativeMethods.WM_MBUTTONUP:
                    break;
            }

            return NativeMethods.CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private void CbFullscreen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFullscreen.Checked)
            {
                customizeWindowBounds = Bounds;
                FormBorderStyle = FormBorderStyle.None;
                Left = 0;
                Top = 0;
                Width = ScreenShot.SCREEN_WIDTH;
                Height = ScreenShot.SCREEN_HEIGHT;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                Bounds = customizeWindowBounds;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            // 设置图片质量
            ScreenRecordOption.EncoderParameters.Param[0] =
                new EncoderParameter(Encoder.Quality, tbQuality.Value);

            timer = new Timer
            {
                Interval = INTERVAL
            };
            timer.Tick += Timer_Tick;
            if (cbFullscreen.Checked)
            {
                FormBorderStyle = FormBorderStyle.None;
                Left = 0;
                Top = 0;
                Width = ScreenShot.SCREEN_WIDTH;
                Height = ScreenShot.SCREEN_HEIGHT;
            }
            else
            {
                // 禁用改变窗口大小
                FormBorderStyle = FormBorderStyle.Fixed3D;
                // 禁用最大化
                MaximizeBox = false;
                // 禁用最小化
                MinimizeBox = false;
            }

            // 隐藏工具条
            pnToolOption.Hide();

            // 设置panel 背景为 Green，以实现透明
            pnTarget.BackColor = Color.Green;

            timer.Start();
        }
    }
}
