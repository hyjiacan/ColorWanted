using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted
{
    public partial class MainForm : Form
    {
        private bool flag;
        Timer timer;
        const int keyId = 111;

        AboutForm aboutForm;

        public MainForm()
        {
            InitializeComponent();

            var screen = Screen.PrimaryScreen.Bounds;

            Left = (screen.Width - Width) / 2;
            Top = 0;

            NativeMethods.RegisterHotKey(Handle, keyId, KeyModifiers.Alt, Keys.C);
            NativeMethods.RegisterHotKey(Handle, keyId + 1, KeyModifiers.Alt, Keys.G);
            NativeMethods.RegisterHotKey(Handle, keyId + 2, KeyModifiers.Alt, Keys.H);

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Start();
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
            Point pt = new Point(Control.MousePosition.X, Control.MousePosition.Y);
            Color cl = GetColor(pt);
            pnProxy.BackColor = cl;
            lbHex.Text = string.Format("#{0}{1}{2}", cl.R.ToString("X2"), cl.G.ToString("X2"), cl.B.ToString("X2"));
            lbRgb.Text = string.Format("RGB({0},{1},{2})", cl.R, cl.G, cl.B);
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
                        Visible = !Visible;
                        break;
                }
            }

            base.WndProc(ref m);
        }

        private void MouseDownEventHandler(object sender, MouseEventArgs e)
        {
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SYSCOMMAND, NativeMethods.SC_MOVE + NativeMethods.HTCAPTION, 0);
        }

        private void visibleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.Visible = visibleToolStripMenuItem.CheckState == CheckState.Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutForm == null)
            {
                aboutForm = new AboutForm();
            }
            aboutForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tray.ShowBalloonTip(2000);
        }
    }
}
