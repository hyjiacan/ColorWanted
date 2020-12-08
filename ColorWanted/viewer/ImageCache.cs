using System;
using System.Drawing;

namespace ColorWanted.viewer
{
    /// <summary>
    /// 图片在指定像素点的颜色缓存
    /// </summary>
    static class ImageCache
    {
        private static Bitmap image;
        private static int[,] _cache;

        public static int Width { get; private set; }
        public static int Height { get; private set; }

        public static void SetImage(Bitmap img)
        {
            image = img;

            Width = img.Width;
            Height = img.Height;

            if (_cache != null)
            {
                _cache = null;
            }
            _cache = new int[Width, Height];
            // 初始化所有值为 -1
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _cache[i, j] = -1;
                }
            }
        }

        public static Color Get(Point point)
        {
            return Get(point.X, point.Y);
        }

        public static Color Get(int x, int y)
        {
            try
            {
                var value = _cache[x, y];
                if (value != -1)
                {
                    return Color.FromArgb(value);
                }

                var color = image.GetPixel(x, y);
                _cache[x, y] = color.ToArgb();
                return color;
            }
            catch (Exception)
            {
                //util.Logger.Warn(ex);
                util.Logger.Warn($"Cannot find point({x},{y}) in image cache({Width},{Height})");
                return Color.Black;
            }
        }

        internal static void Clear()
        {
            _cache = null;
            Width = 0;
            Height = 0;
            image?.Dispose();
            image = null;
        }
    }
}
