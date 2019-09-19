using System;
using System.Drawing;
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
            if (p.X >= 0 && img.Width > p.X && p.Y >= 0 && img.Height > p.Y)
            {
                // 光标位置使用反色绘制
                var color = img.GetPixel(p.X, p.Y);
                var cursorColor = util.ColorUtil.GetContrastColor(color);
                using (var graphics = Graphics.FromImage(img))
                {
                    var brush = new SolidBrush(cursorColor);
                    if (mouseDown)
                    {
                        graphics.DrawEllipse(new Pen(cursorColor, 3), p.X - 3, p.Y - 3, 7, 7);
                        graphics.DrawEllipse(new Pen(cursorColor, 2), p.X - 7, p.Y - 7, 15, 15);
                        graphics.DrawEllipse(new Pen(cursorColor, 1), p.X - 9, p.Y - 9, 19, 19);
                    }
                    else
                    {
                        graphics.FillEllipse(brush, p.X - 1, p.Y - 1, 3, 3);
                    }
                    graphics.Flush();
                    brush.Dispose();
                }
            }
            img.Save(Path.Combine(ScreenRecordOption.CachePath, DateTime.Now.ToFileTime().ToString() + ".bmp"));
            img.Dispose();
            GC.Collect();
        }

        private void ScreenRecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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

            // 隐藏工具条
            pnToolOption.Hide();

            // 设置panel 背景为 Green，以实现透明
            pnTarget.BackColor = Color.Green;

            timer.Start();
        }
    }
}
