using ColorWanted.enums;
using ColorWanted.ext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
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
            // Alt + ` 键
            NativeMethods.RegisterHotKey(handle, HotKeyValue.DrawPreview.AsInt(), KeyModifiers.Alt, Keys.Oemtilde);
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
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.DrawPreview.AsInt());
        }

        private static readonly Pen linePen = new Pen(new SolidBrush(Color.FromArgb(100, 30, 30, 30)));


        private static Rectangle srcRect = new Rectangle(0, 0, 0, 0);

        private static Rectangle destRect = new Rectangle(0, 0, 0, 0);

        public static void ScaleBitmap(Bitmap srcImage, Bitmap destImage)
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

            // 边长
            var width = Math.Min(destRect.Width, destRect.Height);
            // 边距
            //var paddingX = (destRect.Width - width) / 2;
            //var paddingY = (destRect.Height - width) / 2;
            var scale = width / srcImage.Width;

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
        }
    }
}
