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

            MouseWheel += new MouseEventHandler(picPreview_MouseWheel);
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

        private void picPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SYSCOMMAND, NativeMethods.SC_MOVE + NativeMethods.HTCAPTION, 0);
            }
        }

        private void PreviewForm_MouseEnter(object sender, EventArgs e)
        {
            MouseOnMe = true;
            this.Cursor = Cursors.SizeAll;
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
