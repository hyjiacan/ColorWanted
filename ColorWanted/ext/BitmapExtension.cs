using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace ColorWanted.ext
{
    internal static class BitmapExtension
    {
        /// <summary>
        /// 图像模糊化
        /// </summary>
        /// <param name="bitmap">原始图像</param>
        /// <param name="radius"></param>
        /// <param name="sigma">离散程度，sigma 越大曲线越扁</param>
        /// <returns>模糊化后的图像</returns>
        public static Bitmap Blur(this Bitmap bitmap, int radius = 8, float sigma = 2)
        {

            if (bitmap == null)
            {
                return null;
            }

            int width = bitmap.Width;
            int height = bitmap.Height;

            float pa = (float)(1 / (Math.Sqrt(2 * Math.PI) * sigma));
            float pb = -1.0f / (2 * sigma * sigma);

            // generate the Gauss Matrix
            float[] gaussMatrix = new float[radius * 2 + 1];
            float gaussSum = 0f;
            for (int i = 0, x = -radius; x <= radius; ++x, ++i)
            {
                float g = (float)(pa * Math.Exp(pb * x * x));
                gaussMatrix[i] = g;
                gaussSum += g;
            }

            for (int i = 0, length = gaussMatrix.Length; i < length; ++i)
            {
                gaussMatrix[i] /= gaussSum;
            }



            try
            {
                Bitmap bmpReturn = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                BitmapData srcBits = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData targetBits = bmpReturn.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pSrcBits = (byte*)srcBits.Scan0.ToPointer();
                    byte* pTargetBits = (byte*)targetBits.Scan0.ToPointer();
                    int stride = srcBits.Stride;
                    byte* pTemp;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                            {
                                //最边上的像素不处理
                                pTargetBits[0] = pSrcBits[0];
                                pTargetBits[1] = pSrcBits[1];
                                pTargetBits[2] = pSrcBits[2];
                            }
                            else
                            {
                                //取周围9点的值
                                int r1, r2, r3, r4, r5, r6, r7, r8, r9;
                                int g1, g2, g3, g4, g5, g6, g7, g8, g9;
                                int b1, b2, b3, b4, b5, b6, b7, b8, b9;

                                float fR, fG, fB;

                                //左上
                                pTemp = pSrcBits - stride - 3;
                                r1 = pTemp[2];
                                g1 = pTemp[1];
                                b1 = pTemp[0];

                                //正上
                                pTemp = pSrcBits - stride;
                                r2 = pTemp[2];
                                g2 = pTemp[1];
                                b2 = pTemp[0];

                                //右上
                                pTemp = pSrcBits - stride + 3;
                                r3 = pTemp[2];
                                g3 = pTemp[1];
                                b3 = pTemp[0];

                                //左侧
                                pTemp = pSrcBits - 3;
                                r4 = pTemp[2];
                                g4 = pTemp[1];
                                b4 = pTemp[0];

                                //右侧
                                pTemp = pSrcBits + 3;
                                r5 = pTemp[2];
                                g5 = pTemp[1];
                                b5 = pTemp[0];

                                //右下
                                pTemp = pSrcBits + stride - 3;
                                r6 = pTemp[2];
                                g6 = pTemp[1];
                                b6 = pTemp[0];

                                //正下
                                pTemp = pSrcBits + stride;
                                r7 = pTemp[2];
                                g7 = pTemp[1];
                                b7 = pTemp[0];

                                //右下
                                pTemp = pSrcBits + stride + 3;
                                r8 = pTemp[2];
                                g8 = pTemp[1];
                                b8 = pTemp[0];

                                //自己
                                pTemp = pSrcBits;
                                r9 = pTemp[2];
                                g9 = pTemp[1];
                                b9 = pTemp[0];

                                fR = r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8 + r9;
                                fG = g1 + g2 + g3 + g4 + g5 + g6 + g7 + g8 + g9;
                                fB = b1 + b2 + b3 + b4 + b5 + b6 + b7 + b8 + b9;

                                fR /= 9;
                                fG /= 9;
                                fB /= 9;

                                pTargetBits[0] = (byte)fB;
                                pTargetBits[1] = (byte)fG;
                                pTargetBits[2] = (byte)fR;

                            }

                            pSrcBits += 3;
                            pTargetBits += 3;
                        }

                        pSrcBits += srcBits.Stride - width * 3;
                        pTargetBits += srcBits.Stride - width * 3;
                    }
                }

                bitmap.UnlockBits(srcBits);
                bmpReturn.UnlockBits(targetBits);

                return bmpReturn;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 从大图中截取一部分图片
        /// </summary>
        /// <param name="image">来源图片</param>        
        /// <param name="x">从偏移X坐标位置开始截取</param>
        /// <param name="y">从偏移Y坐标位置开始截取</param>
        /// <param name="width">截取图片的宽度</param>
        /// <param name="height">截取图片的高度</param>
        /// <returns></returns>
        public static Bitmap Cut(this Bitmap image, int x, int y, int width, int height)
        {
            if (x < 0)
            {
                x = 0;
            }
            if (y < 0)
            {
                y = 0;
            }
            if (x + width > image.Width)
            {
                width = image.Width - x;
            }
            if (y + height > image.Height)
            {
                height = image.Height - y;
            }
            using (var bitmap = new Bitmap(width, height))
            {
                using (var graphic = Graphics.FromImage(bitmap))
                {
                    //截取原图相应区域写入作图区
                    graphic.DrawImage(image, 0, 0, new Rectangle(x, y, width, height),
                        GraphicsUnit.Pixel);
                    var handle = bitmap.GetHbitmap();
                    var temp = Image.FromHbitmap(handle);
                    NativeMethods.DeleteObject(handle);
                    return temp;
                }
            }
        }

        /// <summary>
        /// 图片截取
        /// </summary>
        /// <param name="image"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public static Bitmap Cut(this Bitmap image, Rect bounds)
        {
            return image.Cut((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height);
        }

        /// <summary>
        /// 修改图片的透明度，返回修改后的新图片
        /// </summary>
        /// <param name="image"></param>
        /// <param name="opacity"></param>
        /// <returns>修改透明度后的新图片</returns>
        public static Bitmap AsOpacity(this Bitmap image, float opacity = 0.3f)
        {
            var matrix = new ColorMatrix(new float[][]{
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, opacity, 0},
                new float[] {0, 0, 0, 0, 1}
            });
            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(resultImage);
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            matrix = null;
            GC.Collect();
            return resultImage;
        }

        public static BitmapSource AsResource(this Bitmap image)
        {
            var handle = image.GetHbitmap();
            var resource = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            // 解决可能导致内存占用高的问题
            NativeMethods.DeleteObject(handle);
            return resource;
        }
    }
}
