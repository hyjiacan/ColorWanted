using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ColorWanted
{
    public partial class MainForm : Form
    {
        Timer timer;
        const int keyId = 111;
        private bool iniloaded;
        private Screen screen;
        private AboutForm aboutForm;

        private IntPtr hTaskbar;
        private IntPtr hBar;
        private IntPtr hMin;

        private NativeMethods.Rect rcMin, rcBar;

        public MainForm()
        {
            InitializeComponent();

            hTaskbar = NativeMethods.FindWindow("Shell_TrayWnd", null);
            hBar = NativeMethods.FindWindowEx(hTaskbar, IntPtr.Zero, "ReBarWindow32", null);
            hMin = NativeMethods.FindWindowEx(hBar, IntPtr.Zero, "MSTaskSwWClass", null);

            screen = Screen.PrimaryScreen;

            NativeMethods.RegisterHotKey(Handle, keyId, KeyModifiers.Alt, Keys.C);
            NativeMethods.RegisterHotKey(Handle, keyId + 1, KeyModifiers.Alt, Keys.G);
            NativeMethods.RegisterHotKey(Handle, keyId + 2, KeyModifiers.Alt, Keys.H);
            NativeMethods.RegisterHotKey(Handle, keyId + 3, KeyModifiers.Alt, Keys.F1);
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (!iniloaded)
            {
                // 不晓得为啥，在启动时加载Visible会被覆盖，所在放到这里来了
                restoreLocationToolStripMenuItem.Enabled =
                showRgbToolStripMenuItem.Enabled =
                autoPinToolStripMenuItem.Enabled =
                followCaretToolStripMenuItem.Enabled =
                visibleToolStripMenuItem.Checked =
                Visible = Settings.FormVisible;
                if (Visible)
                {
                    BringToFront();
                }
                followCaretToolStripMenuItem.Checked = Settings.FollowCaret;
                if (followCaretToolStripMenuItem.Checked)
                {
                    restoreLocationToolStripMenuItem.Enabled =
                    autoPinToolStripMenuItem.Enabled = false;
                }

                iniloaded = true;

                Embed2Taskbar();
            }
            Point pt = new Point(Control.MousePosition.X, Control.MousePosition.Y);

            if (Visible && followCaretToolStripMenuItem.Checked)
            {
                FollowCaret(Control.MousePosition.X, Control.MousePosition.Y);
            }

            Color cl = ColorUtil.GetColor(pt);
            lbHex.Text = string.Format("#{0}{1}{2}", cl.R.ToString("X2"), cl.G.ToString("X2"), cl.B.ToString("X2"));

            lbRgb.Text = string.Format("RGB({0},{1},{2})", cl.R, cl.G, cl.B);

            if (showRgbToolStripMenuItem.Checked)
            {

                lbRgb.BackColor = cl;

                if (ColorUtil.isDark(cl) || ColorUtil.isSingle(cl))
                {
                    lbRgb.ForeColor = Color.White;
                    return;
                }

                if (ColorUtil.isLight(cl) || ColorUtil.isGray(cl))
                {
                    lbRgb.ForeColor = Color.Black;
                    return;
                }

                var diffr = 255 - cl.R;
                var diffg = 255 - cl.G;
                var diffb = 255 - cl.B;

                lbRgb.ForeColor = Color.FromArgb(diffr, diffg, diffb);
            }
            else
            {
                pnColor.BackColor = cl;
            }
        }

        private void FollowCaret(int x, int y)
        {
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

        private void SetDefaultLocation()
        {
            var size = screen.Bounds;

            Left = (size.Width - Width) / 2;
            Top = 0;
        }

        private void LoadLocation()
        {
            var loc = Settings.Location;
            if (!string.IsNullOrWhiteSpace(loc))
            {
                var arr = loc.Split(',');
                if (arr.Length == 2)
                {
                    int x, y;
                    if (int.TryParse(arr[0], out x))
                    {
                        Left = x;
                    }
                    if (int.TryParse(arr[1], out y))
                    {
                        Top = y;
                    }

                    return;
                }
            }

            SetDefaultLocation();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            timer.Stop();

            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            NativeMethods.UnregisterHotKey(Handle, keyId);
            NativeMethods.UnregisterHotKey(Handle, keyId + 1);
            NativeMethods.UnregisterHotKey(Handle, keyId + 2);
            NativeMethods.UnregisterHotKey(Handle, keyId + 3);

            ReleaseFromTaskbar();
        }

        protected override void WndProc(ref Message m)
        {
            // hotkey
            if (m.Msg == 0x0312)
            {
                switch (m.WParam.ToInt32())
                {
                    case keyId:
                        Clipboard.SetText(lbHex.Text);
                        break;
                    case keyId + 1:
                        Clipboard.SetText(lbRgb.Text);
                        break;
                    case keyId + 2:
                        toggleVisible(null, null);
                        break;
                    case keyId + 3:
                        followCaretToolStripMenuItem_Click(null, null);
                        break;
                }
            }

            base.WndProc(ref m);
        }

        private void MouseDownEventHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SYSCOMMAND, NativeMethods.SC_MOVE + NativeMethods.HTCAPTION, 0);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Height = 20;


            if (!followCaretToolStripMenuItem.Checked)
            {
                LoadLocation();
            }

            // 加载配置
            autoPinToolStripMenuItem.Checked = Settings.AutoPin;

            showRgbToolStripMenuItem.Checked = Settings.ShowRgb;
            toggleRgb();

            // 读取开机启动的注册表
            try
            {
                using (var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
                {
                    if (reg != null)
                    {
                        var path = reg.GetValue(Application.ProductName);
                        if (path != null)
                        {
                            if (string.Equals(path.ToString(), "\"" + Application.ExecutablePath + "\"", StringComparison.OrdinalIgnoreCase))
                            {
                                autoStartToolStripMenuItem.Checked = true;
                            }
                        }
                    }
                }
            }
            catch { }

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (followCaretToolStripMenuItem.Checked)
            {
                return;
            }
            if (autoPinToolStripMenuItem.Checked)
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
                Settings.Location = Left + "," + Top;
            }
        }

        private void Embed2Taskbar()
        {
            NativeMethods.GetWindowRect(hBar, out rcBar); //获得二级容器的Handle  
            NativeMethods.GetWindowRect(hMin, out rcMin);  //获得最小化窗口的Handle  

            var minWidth = rcMin.Right - rcMin.Left;
            var minHeight = rcMin.Bottom - rcMin.Top;

            var barWidth = rcBar.Right - rcBar.Left;
            var barHeight = rcBar.Bottom - rcBar.Top;

            NativeMethods.MoveWindow(hMin, IntPtr.Zero, IntPtr.Zero, rcMin.Right - rcMin.Left - Width, rcMin.Bottom - rcMin.Top, 1);

            NativeMethods.SetParent(pnContainer.Handle, hBar);  //把程序窗口设置成任务栏的子窗口

            NativeMethods.MoveWindow(pnContainer.Handle, new IntPtr(rcMin.Right - rcMin.Left - Width + 2),
                new IntPtr((rcBar.Bottom - rcBar.Top - Height) / 2), Width, Height, 1);
        }

        private void UpdateTaskbarPosition()
        {

        }

        private void ReleaseFromTaskbar()
        {
            NativeMethods.MoveWindow(pnContainer.Handle, new IntPtr(Left),
                new IntPtr(Top), Width, Height, 1);

            NativeMethods.SetParent(pnContainer.Handle, Handle);

            NativeMethods.MoveWindow(hMin, IntPtr.Zero, IntPtr.Zero, rcMin.Right - rcMin.Left, rcMin.Bottom - rcMin.Top, 1);
        }

        #region 托盘菜单


        private void toggleVisible(object sender, EventArgs e)
        {

            visibleToolStripMenuItem.Checked =
            Visible = !Visible;
            if (Visible)
            {
                BringToFront();
            }
            restoreLocationToolStripMenuItem.Enabled =
           showRgbToolStripMenuItem.Enabled =
           autoPinToolStripMenuItem.Enabled = followCaretToolStripMenuItem.Checked ? false : Visible;
            if (iniloaded)
            {
                Settings.FormVisible = Visible;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutForm == null)
            {
                aboutForm = new AboutForm();
            }
            aboutForm.Show();
        }

        private void showRgbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            item.Checked = !item.Checked;
            toggleRgb();
            if (iniloaded)
            {
                Settings.ShowRgb = item.Checked;
            }
        }

        private void autoPinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            item.Checked = !item.Checked;
            toggleRgb();
            if (iniloaded)
            {
                Settings.AutoPin = item.Checked;
            }
        }

        private void restoreLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDefaultLocation();
        }

        private void autoStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            item.Checked = !item.Checked;

            // 写注册表
            try
            {
                using (var reg = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
                {
                    if (item.Checked)
                    {
                        reg.SetValue(Application.ProductName, "\"" + Application.ExecutablePath + "\"");
                    }
                    else
                    {
                        reg.DeleteValue(Application.ProductName);
                    }
                }
            }
            catch (Exception ex)
            {
                tray.ShowBalloonTip(5000, "赏色", "设置开机启动失败:" + ex.Message, ToolTipIcon.Warning);
            }
        }

        private void followCaretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = followCaretToolStripMenuItem;
            restoreLocationToolStripMenuItem.Enabled =
                autoPinToolStripMenuItem.Enabled =
            visibleToolStripMenuItem.Enabled = item.Checked;
            item.Checked = !item.Checked;
            if (Visible)
            {
                BringToFront();
            }
            if (!item.Checked)
            {
                LoadLocation();
            }
            else
            {
                ReleaseFromTaskbar();
            }
            if (iniloaded)
            {
                Settings.FollowCaret = item.Checked;
            }
        }
        private void toggleRgb()
        {
            if (Visible)
            {
                BringToFront();
            }
            bool showrgb = showRgbToolStripMenuItem.Checked;
            lbRgb.Visible = showrgb;
            Width = showrgb ? 208 : 88;
        }
        #endregion
    }
}
