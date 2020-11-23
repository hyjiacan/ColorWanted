using ColorWanted.ext;
using ColorWanted.setting;
using ColorWanted.util;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ColorWanted
{
    internal partial class PreviewForm : Form
    {
        public bool MouseOnMe { get; private set; }
        /// <summary>
        /// 是否初始化完成
        /// </summary>
        public bool Initialized { get; set; }

        /// <summary>
        /// 是否跟随Main窗口移动
        /// </summary>
        public bool FollowMainForm;

        private Bitmap image;

        /// <summary>
        /// 更新预览图
        /// </summary>
        /// <param name="img"></param>
        public void UpdateImage(Bitmap img)
        {
            // 预览时设置十字的颜色
            lbH.BackColor = lbV.BackColor = ColorUtil.GetContrastColor(img.GetPixel(img.Width / 2 + 1, img.Height / 2 + 1), true);

            // 非像素放大
            if (!Settings.Preview.PixelScale)
            {
                picPreview.Image = img;
                GC.Collect();
                return;
            }

            // 像素放大
            // 根据源图大小来设置预览图的大小，预览图的大小需要为源图大小的倍数
            // 如果不是倍数，那以就设置padding
            var padding = picPreview.Size.Width % img.Width;

            var size = padding == 0 ? picPreview.Size : picPreview.Size - new Size(padding, padding);
            if (image == null || !image.Size.Equals(size))
            {
                image?.Dispose();
                image = new Bitmap(size.Width, size.Height);
            }

            picPreview.Image = ScaleBitmap(img, image);

            GC.Collect();
        }

        public PreviewForm()
        {
            componentsLayout();
            // 加载保存的窗口大小
            var w = Settings.Preview.Size;
            if (w != 0)
            {
                Width = Height = w;
                setCrossSize(Width);
            }

            MouseWheel += picPreview_MouseWheel;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                var cp = base.CreateParams;
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
            Width = Height = Width + 11 * delta;

            // 记住大小
            Settings.Preview.Size = Width;
            setCrossSize(Width);
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
            Settings.Preview.Location = Location;
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            Location = Settings.Preview.Location;
            Initialized = true;
        }


        private static readonly Pen linePen = new Pen(new SolidBrush(Color.FromArgb(100, 30, 30, 30)));


        private static Rectangle srcRect = new Rectangle(0, 0, 0, 0);

        private static Rectangle destRect = new Rectangle(0, 0, 0, 0);

        public static Bitmap ScaleBitmap(Bitmap srcImage, Bitmap destImage)
        {
            // 大小可能会变，当改变时取新值
            if (srcRect.Size != srcImage.Size)
            {
                srcRect.Size = srcImage.Size;
            }

            // 大小可能会变，当改变时取新值
            if (destImage.Size != destRect.Size)
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

                for (var i = 0; i < srcRect.Height; i++)
                {
                    // 写第i行数据

                    for (var j = 0; j < srcData.Stride; j += 4)
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

            return destImage;
        }

        private void picPreview_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            // 切换暂停预览
            var mainForm = Application.OpenForms["MainForm"] as MainForm;
            mainForm.DrawControl(false);
        }

        /// <summary>
        /// 设置 十 的大小和位置
        /// </summary>
        /// <param name="size"></param>
        private void setCrossSize(int size)
        {
            var middle = (size - 1) / 2;
            lbH.Top = lbV.Left = middle;
            lbH.Width = lbV.Height = size;
        }
    }
}
