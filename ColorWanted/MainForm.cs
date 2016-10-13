using System;
using System.Drawing;
using System.Windows.Forms;
using ColorWanted.enums;
using ColorWanted.ext;

namespace ColorWanted
{
    public partial class MainForm : Form
    {
        Timer timer;
        private bool iniloaded;
        private Screen screen;
        private AboutForm aboutForm;
        private PreviewForm previewForm;
        // 上次复制的时间
        DateTime lastCopyTime;
        public MainForm()
        {
            InitializeComponent();

            screen = Screen.PrimaryScreen;

            currentMode = DisplayMode.Fixed;

            Util.BindHotkeys(Handle);
        }



        private void timer_Tick(object sender, EventArgs e)
        {
            if (previewForm.MouseOnMe)
            {
                return;
            }
            if (!iniloaded)
            {
                // 不晓得为啥，在启动时加载Visible会被覆盖，所在放到这里来了
                SwitchMode(Settings.Mode);

                iniloaded = true;
            }
            Point pt = new Point(MousePosition.X, MousePosition.Y);

            if (currentMode == DisplayMode.Follow)
            {
                FollowCaret();
            }

            //todo 是否绘制预览图
            DrawZoom(pt);

            Color cl = ColorUtil.GetColor(pt);

            lbHex.Text = string.Format("#{0}{1}{2}", cl.R.ToString("X2"), cl.G.ToString("X2"), cl.B.ToString("X2"));

            lbRgb.Text = string.Format("RGB({0},{1},{2})", cl.R, cl.G, cl.B);

            if (trayMenuShowRgb.Checked)
            {

                lbRgb.BackColor = cl;

                lbRgb.ForeColor = ColorUtil.GetContrastColor(cl);
            }
            else
            {
                BackColor = cl;
            }
        }

        static Bitmap pic = new Bitmap(11, 11);
        static int extend = 5;
        static Graphics graphics;
        /// <summary>
        /// 画放大图，每个方向各取5个像素
        /// </summary>
        /// <param name="pt"></param>
        private void DrawZoom(Point pt)
        {
            if (graphics == null)
            {
                graphics = Graphics.FromImage(pic);
            }
            graphics.Clear(Color.White);
            graphics.CopyFromScreen(pt.X - extend, pt.Y - extend, 0, 0, pic.Size);
            graphics.Save();

            previewForm.UpdateImage(Util.ScaleBitmap(pic, previewForm.GetImageSize()));
        }

        private void SetDefaultLocation()
        {
            var size = screen.Bounds;

            Left = (size.Width - Width) / 2;
            Top = 0;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            timer.Stop();

            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.UnbindHotkeys(Handle);
        }

        /// <summary>
        /// 接收消息，响应快捷键
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            // 收到的不是快捷键消息，不作任何处理
            if (m.Msg != 0x312)
            {
                base.WndProc(ref m);
                return;
            }
            // 收到的快捷键的值
            var keyValue = m.WParam.ToInt32();

            // 复制颜色值  如果连续两次（间隔小于1秒），则复制RGB颜色值，否则复制HEX颜色值
            if (keyValue == HotKeyValue.CopyHexColor.AsInt())
            {
                // 复制HEX
                if ((DateTime.Now - lastCopyTime).TotalSeconds >= 1)
                {
                    Clipboard.SetText(lbHex.Text);
                }
                // 复制RGB
                else
                {
                    Clipboard.SetText(lbRgb.Text);
                }
                lastCopyTime = DateTime.Now;
                base.WndProc(ref m);
                return;
            }

            // 显示/隐藏RGB颜色值
            if (keyValue == HotKeyValue.CopyRgbColor.AsInt())
            {
                toggleRgb();
                base.WndProc(ref m);
                return;
            }

            // 切换显示模式
            if (keyValue == HotKeyValue.SwitchMode.AsInt())
            {
                SwitchMode();
                base.WndProc(ref m);
                return;
            }

            // 切换显示模式
            if (keyValue == HotKeyValue.ShowPreview.AsInt())
            {
                TogglePreview();
                base.WndProc(ref m);
                return;
            }
        }

        private void MouseDownEventHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SYSCOMMAND, NativeMethods.SC_MOVE + NativeMethods.HTCAPTION, 0);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Height = 20;

            previewForm = new PreviewForm();
            previewForm.Show();

            if (!trayMenuFollowCaret.Checked)
            {
                FixedPosition();
            }

            // 加载配置
            trayMenuAutoPin.Checked = Settings.AutoPin;

            trayMenuShowRgb.Checked = Settings.ShowRgb;
            toggleRgb();

            // 读取开机启动的注册表
            trayMenuAutoStart.Checked = Settings.Autostart;

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (trayMenuFollowCaret.Checked)
            {
                return;
            }
            if (trayMenuAutoPin.Checked)
            {
                var size = screen.Bounds;
                if (Top <= 16)
                {
                    Top = 0;
                }
                else if (Left <= 16)
                {
                    Left = 0;
                }
                else if (size.Width - Left - Width <= 16)
                {
                    Left = size.Width - Width;
                }
                else if (screen.WorkingArea.Height - Top - Height <= 16)
                {
                    Top = screen.WorkingArea.Height - Height;
                }
            }
            if (iniloaded)
            {
                Settings.Location = Location;
            }
        }

        private void TogglePreview()
        {
            previewForm.Visible = !previewForm.Visible;
            if (previewForm.Visible)
            {
                previewForm.BringToFront();
            }
        }

        #region 托盘菜单


        private void trayMenuHideWindow_Click(object sender, EventArgs e)
        {
            SwitchMode(DisplayMode.Hidden);
        }

        private void trayMenuFixed_Click(object sender, EventArgs e)
        {
            SwitchMode(DisplayMode.Fixed);
        }

        private void trayMenuFollowCaret_Click(object sender, EventArgs e)
        {
            SwitchMode(DisplayMode.Follow);
        }

        private void trayMenuShowAbout_Click(object sender, EventArgs e)
        {
            if (aboutForm == null)
            {
                aboutForm = new AboutForm();
            }
            aboutForm.Show();
        }

        private void trayMenuShowRgb_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            toggleRgb();
            if (iniloaded)
            {
                Settings.ShowRgb = item.Checked;
            }
        }

        private void trayMenuAutoPin_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            item.Checked = !item.Checked;
            if (iniloaded)
            {
                Settings.AutoPin = item.Checked;
            }
        }

        private void trayMenuRestoreLocation_Click(object sender, EventArgs e)
        {
            SetDefaultLocation();
        }

        private void trayMenuAutoStart_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            item.Checked = !item.Checked;

            // 写注册表
            Settings.Autostart = item.Checked;
        }

        private void toggleRgb()
        {
            if (!Visible)
            {
                return;
            }
            BringToFront();
            bool showrgb = trayMenuShowRgb.Checked = !trayMenuShowRgb.Checked;
            lbRgb.Visible = showrgb;
            Width = showrgb ? 208 : 88;
        }
        #endregion

        #region 显示模式控制
        /// <summary>
        /// 当前的显示模式
        /// </summary>
        DisplayMode currentMode;
        /// <summary>
        /// 激活显示模式
        /// </summary>
        private void SwitchMode()
        {
            // 下一个要激活的模式
            DisplayMode mode = (DisplayMode)Enum.ToObject(typeof(DisplayMode), currentMode + 1);
            // 看加了后这个模式有没有定义，如果没有定义，则跳转到隐藏模式
            if (!Enum.IsDefined(typeof(DisplayMode), mode))
            {
                mode = DisplayMode.Hidden;
            }
            SwitchMode(mode);
        }

        private void SwitchMode(DisplayMode mode)
        {
            if (mode == DisplayMode.Hidden)
            {
                trayMenuHideWindow.Checked = true;
                trayMenuFollowCaret.Checked = false;
                trayMenuFixed.Checked = false;

                trayMenuShowRgb.Enabled = false;
                trayMenuRestoreLocation.Enabled = false;
                trayMenuAutoPin.Enabled = false;

                Hide();
            }
            else
            {

                trayMenuHideWindow.Checked = false;
                trayMenuFollowCaret.Checked = false;
                trayMenuFixed.Checked = false;

                trayMenuShowRgb.Enabled = true;

                Show();
                BringToFront();
                FixedPosition();

                switch (mode)
                {
                    case DisplayMode.Fixed:
                        trayMenuFixed.Checked = true;
                        trayMenuRestoreLocation.Enabled = true;
                        trayMenuAutoPin.Enabled = true;
                        break;
                    case DisplayMode.Follow:
                        trayMenuFollowCaret.Checked = true;
                        trayMenuRestoreLocation.Enabled = false;
                        trayMenuAutoPin.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            if (iniloaded)
            {
                Settings.Mode = mode;
            }
            currentMode = mode;
        }

        /// <summary>
        /// 窗口跟随光标显示
        /// </summary>
        private void FollowCaret()
        {
            int x = MousePosition.X,
                y = MousePosition.Y;

            var size = screen.Bounds;

            if (x <= size.Width - Width)
            {

                Left = x + 10;
            }
            else
            {
                Left = x - Width - 10;
            }
            if (y <= Height)
            {

                Top = y + 10;
            }
            else if (y < screen.WorkingArea.Height - Height)
            {
                Top = y + 10;
            }
            else
            {
                Top = screen.WorkingArea.Height - Height;
            }
        }

        /// <summary>
        /// 容器在固定位置显示
        /// </summary>
        private void FixedPosition()
        {
            var loc = Settings.Location;
            if (!loc.IsEmpty)
            {
                Left = loc.X;
                Top = loc.Y;
            }
            // 配置文件里面没有位置数据或数据无效，那么将窗口显示在默认的位置
            SetDefaultLocation();
        }
        #endregion

    }
}
