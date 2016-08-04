using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted
{
    public partial class MainForm : Form
    {
        Timer timer;
        const int keyId = 111;
        private bool backgroundTipShown;
        private bool iniloaded;
        private Screen screen;
        AboutForm aboutForm;

        public MainForm()
        {
            InitializeComponent();

            screen = Screen.PrimaryScreen;

            var size = screen.Bounds;

            Left = (size.Width - Width) / 2;
            Top = 0;

            NativeMethods.RegisterHotKey(Handle, keyId, KeyModifiers.Alt, Keys.C);
            NativeMethods.RegisterHotKey(Handle, keyId + 1, KeyModifiers.Alt, Keys.G);
            NativeMethods.RegisterHotKey(Handle, keyId + 2, KeyModifiers.Alt, Keys.H);
        }


        static public byte GetRValue(uint color)
        {
            return (byte)color;
        }
        static public byte GetGValue(uint color)
        {
            return ((byte)(((short)(color)) >> 8));
        }
        static public byte GetBValue(uint color)
        {
            return ((byte)((color) >> 16));
        }
        static public byte GetAValue(uint color)
        {
            return ((byte)((color) >> 24));
        }
        public Color GetColor(Point screenPoint)
        {
            IntPtr displayDC = NativeMethods.CreateDC("DISPLAY", null, null, IntPtr.Zero);
            uint colorref = NativeMethods.GetPixel(displayDC, screenPoint.X, screenPoint.Y);
            NativeMethods.DeleteDC(displayDC);
            byte Red = GetRValue(colorref);
            byte Green = GetGValue(colorref);
            byte Blue = GetBValue(colorref);
            return Color.FromArgb(Red, Green, Blue);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!iniloaded)
            {
                LoadSettings();
            }

            Point pt = new Point(Control.MousePosition.X, Control.MousePosition.Y);
            Color cl = GetColor(pt);
            pnProxy.BackColor = cl;
            lbHex.Text = string.Format("#{0}{1}{2}", cl.R.ToString("X2"), cl.G.ToString("X2"), cl.B.ToString("X2"));
            lbRgb.Text = string.Format("RGB({0},{1},{2})", cl.R, cl.G, cl.B);
        }

        private void LoadSettings()
        {
            // 加载配置
            var v = Settings.Get("visible");
            visibleToolStripMenuItem.Checked = Visible = string.IsNullOrWhiteSpace(v) || v == "1";
            var loc = Settings.Get("location");
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
                }
            }

            var p = Settings.Get("autopin");
            autoPinToolStripMenuItem.Checked = string.IsNullOrWhiteSpace(p) || p == "1";

            iniloaded = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            timer.Stop();

            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NativeMethods.UnregisterHotKey(Handle, keyId);
            NativeMethods.UnregisterHotKey(Handle, keyId + 1);
            NativeMethods.UnregisterHotKey(Handle, keyId + 2);
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

        private void toggleVisible(object sender, EventArgs e)
        {
            visibleToolStripMenuItem.Checked = Visible = !Visible;
            if (iniloaded)
            {
                Settings.Set("visible", Visible ? "1" : "0");
            }
            if (!backgroundTipShown && !Visible)
            {
                backgroundTipShown = true;
                tray.ShowBalloonTip(1000, "赏色", "取色器切换到后台运行", ToolTipIcon.Info);
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

        private void autoPinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoPinToolStripMenuItem.Checked = !autoPinToolStripMenuItem.Checked;
            if (iniloaded)
            {
                Settings.Set("autopin", autoPinToolStripMenuItem.Checked ? "1" : "0");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Height = 20;

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Start();

            tray.ShowBalloonTip(1000);
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
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
                else if (size.Height - Top - Height <= 16)
                {
                    Top = size.Height - Height;
                }
            }
            if (iniloaded)
            {
                Settings.Set("location", Left + "," + Top);
            }
        }
    }
}
