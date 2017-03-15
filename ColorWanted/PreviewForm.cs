using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ColorWanted
{
    public partial class PreviewForm : Form
    {
        public bool MouseOnMe { get; private set; }

        private Bitmap image;

        public Bitmap Image
        {
            set
            {
                if (image == null || !image.Size.Equals(picPreview.Size))
                {
                    image = new Bitmap(picPreview.Size.Width, picPreview.Height);
                }

                picPreview.Image = ScaleBitmap(value, image);
                GC.Collect();
            }
        }

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
        private void picPreview_MouseWheel(object sender, MouseEventArgs e)
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


        private static readonly Pen linePen = new Pen(new SolidBrush(Color.FromArgb(100, 30, 30, 30)));


        private static Rectangle srcRect = new Rectangle(0, 0, 0, 0);

        private static Rectangle destRect = new Rectangle(0, 0, 0, 0);

        public static Bitmap ScaleBitmap(Bitmap srcImage, Bitmap destImage)
        {
            // 大小不变，所以取一次就够了
            if (srcRect.IsEmpty)
            {
                srcRect.Size = srcImage.Size;
            }

            // 大小可能会变，当改变时取新值
            if (!destImage.Size.Equals(destRect.Size))
            {
                destRect.Size = destImage.Size;
            }

            var scale = destRect.Width / srcImage.Width;

            unsafe
            {
                // 锁定数据
                var srcData = srcImage.LockBits(srcRect,
                    ImageLockMode.ReadOnly,
                    srcImage.PixelFormat);
                var destData = destImage.LockBits(destRect,
                    ImageLockMode.WriteOnly,
                    destImage.PixelFormat);

                // 获取数据指针
                var srcPointer = (byte*)srcData.Scan0.ToPointer();
                var destPointer = (byte*)destData.Scan0.ToPointer();

                // 放大后行数据的缓存
                var rowbuffer = new byte[destData.Stride];

                for (int i = 0; i < srcRect.Height; i++)
                {
                    // 写第i行数据

                    for (int j = 0; j < srcData.Stride; j += 4)
                    {
                        // 写第j列数据 这个循环完成后  就写完一行了
                        // 当前位置的色值
                        var c1 = *srcPointer;
                        srcPointer++;
                        var c2 = *srcPointer;
                        srcPointer++;
                        var c3 = *srcPointer;
                        srcPointer++;
                        var c4 = *srcPointer;
                        srcPointer++;

                        // 这里是放大行的像素
                        for (var k = j * scale; k < destData.Stride; k += 4)
                        {
                            rowbuffer[k] = c1;
                            rowbuffer[k + 1] = c2;
                            rowbuffer[k + 2] = c3;
                            rowbuffer[k + 3] = c4;
                        }
                    }

                    // 这里是放大列的像素
                    // 即 将放大的行复制scale次
                    for (var j = 0; j < scale; j++)
                    {
                        foreach (var t in rowbuffer)
                        {
                            *destPointer = t;
                            destPointer++;
                        }
                    }
                }

                // 解锁数据
                srcImage.UnlockBits(srcData);
                destImage.UnlockBits(destData);
            }

            var graphics = Graphics.FromImage(destImage);

            linePen.Color = ColorUtil.GetContrastColor(srcImage.GetPixel(srcImage.Width / 2 + 1, srcImage.Height / 2 + 1), true);
            graphics.DrawLine(linePen, 0, destRect.Height / 2, destRect.Width, destRect.Height / 2);
            graphics.DrawLine(linePen, destRect.Width / 2, destRect.Height, destRect.Width / 2, 0);

            graphics.Save();
            graphics.Dispose();

            return destImage;
        }
    }
}
