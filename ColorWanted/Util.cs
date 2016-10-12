using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ColorWanted.enums;
using ColorWanted.ext;

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
        }

        private static Point startPoint = new Point(0, 0);
        private static Pen linePen = new Pen(new SolidBrush(Color.FromArgb(100, 30, 30, 30)));
        public static Bitmap ScaleBitmap(Bitmap originPic, Size newSize)
        {
            // 边长
            var width = Math.Min(newSize.Width, newSize.Height);
            // 边距
            var paddingX = (newSize.Width - width) / 2;
            var paddingY = (newSize.Height - width) / 2;
            var m = width / originPic.Width;

            var newPic = new Bitmap(newSize.Width, newSize.Height);

            var g = Graphics.FromImage(newPic);

            for (var row = 0; row < originPic.Width; row++)
            {
                for (var col = 0; col < originPic.Height; col++)
                {
                    var color = originPic.GetPixel(row, col);
                    g.FillRectangle(new SolidBrush(color), paddingX + row * m, paddingY + col * m, m, m);
                }
            }

            linePen.Color = ColorUtil.GetContrastColor(originPic.GetPixel(originPic.Width / 2 + 1, originPic.Height / 2 + 1), true);
            g.DrawLine(linePen, 0, newSize.Height / 2, newSize.Width, newSize.Height / 2);
            g.DrawLine(linePen, newSize.Width / 2, newSize.Height, newSize.Width / 2, 0);

            g.Save();


            //// m即光标所在处点的边长
            //// 计算放大后图片边缘到这些图中心的位置
            //// 以确定透明度
            //var center = width / 2 + 1;
            //// 绘图区域半径
            //var maxradius = (int)Math.Ceiling(Math.Sqrt(2 * width * width));
            //// 不透明部分的半径
            //var minradius = (int)Math.Ceiling(Math.Sqrt(2 * m * m));

            //for (var row = 0; row < newPic.Width; row++)
            //{
            //    for (var col = 0; col < newPic.Height; col++)
            //    {
            //        var color = newPic.GetPixel(row, col);
            //        var distance = (int)Math.Ceiling(Math.Sqrt(Math.Pow(Math.Abs(row - center), 2) + Math.Pow(Math.Abs(col - center), 2)));

            //        if (distance <= minradius)
            //        {
            //            continue;
            //        }

            //        var alpha = (int)(Math.Abs(1 - distance * 1.0 / maxradius) * 100);

            //        newPic.SetPixel(row, col, Color.FromArgb(alpha, color));
            //    }
            //}

            return newPic;
        }
    }
}
