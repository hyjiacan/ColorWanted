using ColorWanted.enums;
using ColorWanted.ext;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted
{
    /// <summary>
    /// 静态工具类
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// 将全局快捷键绑定到指定句柄上
        /// </summary>
        /// <param name="handle"></param>
        public static void BindHotkeys(IntPtr handle)
        {
            NativeMethods.RegisterHotKey(handle, HotKeyValue.CopyHexColor.AsInt(), KeyModifiers.Alt, Keys.C);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.CopyRgbColor.AsInt(), KeyModifiers.Alt, Keys.R);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.SwitchMode.AsInt(), KeyModifiers.Alt, Keys.F1);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.ShowPreview.AsInt(), KeyModifiers.Alt, Keys.F2);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.ShowColorPicker.AsInt(), KeyModifiers.Alt, Keys.F3);
        }

        /// <summary>
        /// 将全局快捷键从指定句柄上解除绑定
        /// </summary>
        /// <param name="handle"></param>
        public static void UnbindHotkeys(IntPtr handle)
        {
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.CopyHexColor.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.CopyRgbColor.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.SwitchMode.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.ShowPreview.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.ShowColorPicker.AsInt());
        }

        private static Point startPoint = new Point(0, 0);
        private static Pen linePen = new Pen(new SolidBrush(Color.FromArgb(100, 30, 30, 30)));

        // 新图像的对象
        private static Bitmap newPic = null;
        // 画面对象
        private static Graphics graphics = null;

        private static Rectangle originRect = new Rectangle(0, 0, 0, 0);

        private static Rectangle newRect = new Rectangle(0, 0, 0, 0);

        private static SolidBrush brush = new SolidBrush(Color.Black);

        public static Bitmap ScaleBitmap(Bitmap originPic, Size newSize)
        {
            // 边长
            var width = Math.Min(newSize.Width, newSize.Height);
            // 边距
            var paddingX = (newSize.Width - width) / 2;
            var paddingY = (newSize.Height - width) / 2;
            var m = width / originPic.Width;

            if (!originRect.Size.Equals(originPic.Size))
            {
                originRect.Size = originPic.Size;
            }

            if (newPic == null || !newSize.Equals(newRect.Size))
            {
                newRect.Size = newSize;
                newPic = new Bitmap(newSize.Width, newSize.Height);
                graphics = Graphics.FromImage(newPic);
            }

            for (var row = 0; row < originPic.Width; row++)
            {
                var w = paddingX + row * m;
                for (var col = 0; col < originPic.Height; col++)
                {
                    brush.Color = originPic.GetPixel(row, col);
                    graphics.FillRectangle(brush, w, paddingY + col * m, m, m);
                }
            }
            //graphics.DrawImage(originPic, newRect, originRect, GraphicsUnit.Pixel);

            linePen.Color = ColorUtil.GetContrastColor(originPic.GetPixel(originPic.Width / 2 + 1, originPic.Height / 2 + 1), true);
            graphics.DrawLine(linePen, 0, newSize.Height / 2, newSize.Width, newSize.Height / 2);
            graphics.DrawLine(linePen, newSize.Width / 2, newSize.Height, newSize.Width / 2, 0);

            graphics.Save();

            return newPic;
        }
    }
}
