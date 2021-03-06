﻿using ColorWanted.util;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ColorWanted.viewer
{
    /// <summary>
    /// 图片在指定像素点的颜色缓存
    /// </summary>
    class ImageCache
    {
        private Bitmap image;
        private int[,] cachedColor;
        private int[,] cachedContrastColor;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public void SetImage(Bitmap img)
        {
            image = img;

            Width = img.Width;
            Height = img.Height;

            if (cachedColor != null)
            {
                cachedColor = null;
            }
            if (cachedContrastColor != null)
            {
                cachedContrastColor = null;
            }
            cachedColor = new int[Width, Height];
            cachedContrastColor = new int[Width, Height];
            // 初始化所有值为 -1
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    cachedColor[i, j] = -1;
                    cachedContrastColor[i, j] = -1;
                }
            }
        }

        public Color Get(Point point)
        {
            return Get(point.X, point.Y);
        }

        public Color Get(int x, int y)
        {
            try
            {
                var value = cachedColor[x, y];
                if (value != -1)
                {
                    return Color.FromArgb(value);
                }

                var color = image.GetPixel(x, y);
                cachedColor[x, y] = color.ToArgb();
                return color;
            }
            catch (Exception)
            {
                //Logger.Warn(ex);
                Logger.Warn($"Cannot find point({x},{y}) in image cache({Width},{Height})");
                return Color.Black;
            }
        }



        public Color GetContrast(Point point, Color? trickColor = null)
        {
            return GetContrast(point.X, point.Y, trickColor);
        }

        public Color GetContrast(int x, int y, Color? trickColor = null)
        {
            try
            {
                var value = cachedContrastColor[x, y];
                Color color;
                if (value == -1)
                {
                    color = ColorUtil.GetContrastColor(Get(x, y));
                    cachedContrastColor[x, y] = color.ToArgb();
                }
                else
                {
                    color = Color.FromArgb(value);
                }
                // 如果颜色与指定色相近，那么重新取色
                if (trickColor != null && ColorUtil.IsSimilarColor(color, trickColor.Value, 15))
                {
                    color = ColorUtil.GetContrastColor(trickColor.Value);
                    cachedContrastColor[x, y] = color.ToArgb();
                }
                return color;
            }
            catch (Exception)
            {
                //Logger.Warn(ex);
                Logger.Warn($"Cannot find point({x},{y}) in image contrast cache({Width},{Height})");
                return Color.Black;
            }
        }

        internal void Clear()
        {
            cachedColor = null;
            cachedContrastColor = null;
            Width = 0;
            Height = 0;
            image?.Dispose();
            image = null;
        }
    }
}
