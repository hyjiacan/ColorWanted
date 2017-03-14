using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted
{
    public partial class PreviewForm : Form
    {
        public bool MouseOnMe { get; private set; }

        public PreviewForm()
        {
            InitializeComponent();

            MouseWheel += picPreview_MouseWheel;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt-Tab
                return cp;
            }
        }

        //滚轮控制窗口大小
        void picPreview_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!MouseOnMe)
            {
                return;
            }
            var delta = e.Delta / 120;
            if (delta == 0)
            {
                return;
            }
            Width = Width + 11 * delta;
            Height = Height + 11 * delta;
        }

        public void UpdateImage(Bitmap image)
        {
            picPreview.Image = image;
        }

        public Size GetImageSize()
        {
            return picPreview.Size;
        }

        /// <summary>
        /// 切换光标样式
        /// </summary>
        /// <param name="showDefault"></param>
        public void ToggleCursor(bool showDefault)
        {
            picPreview.Cursor = showDefault ?
                       Cursors.Default :
                       Cursors.SizeAll;

        }

        private void picPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_SYSCOMMAND,
                   new IntPtr(NativeMethods.SC_MOVE + NativeMethods.HTCAPTION), IntPtr.Zero);
            }
        }

        private void PreviewForm_MouseEnter(object sender, EventArgs e)
        {
            MouseOnMe = true;
            Cursor = Cursors.SizeAll;
        }

        private void PreviewForm_MouseLeave(object sender, EventArgs e)
        {
            MouseOnMe = false;
        }

        private void PreviewForm_LocationChanged(object sender, EventArgs e)
        {
            Settings.PreviewLocation = Location;
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            Location = Settings.PreviewLocation;
        }
    }
}
