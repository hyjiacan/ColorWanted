using ColorWanted.util;
using System;
using System.Drawing;

namespace ColorWanted.viewer
{
    class ImageUtil
    {
        /// <summary>
        /// 画线的颜色
        /// </summary>
        public Color fillColor = Color.OrangeRed;

        private ImageCache cache;

        public ImageUtil(ImageCache cache)
        {
            this.cache = cache;
        }

        /// <summary>
        /// 获取指定点最近的闭合区域
        /// </summary>
        /// <param name="img"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="drawLine"></param>
        /// <param name="drawBorder"></param>
        /// <returns></returns>
        internal Rectangle GetNearestArea(Bitmap img, int x, int y, bool drawLine, bool drawBorder)
        {
            var width = cache.Width;
            var height = cache.Height;

            // step1: 取到当前点的颜色
            var color = cache.Get(x, y);
            fillColor = ColorUtil.GetContrastColor(color);
            // step1: 找到最近的不同颜色
            // 从4个方向，按顺序 上右下左 依次判断

            // 取色的偏移量
            var offset = 1;
            // 找到不同点后，用来填充的颜色
            //var fill = Color.Red;

            // 找出四个方向的不同点
            Color topColor = Color.Empty,
                rightColor = Color.Empty,
                bottomColor = Color.Empty,
                leftColor = Color.Empty,
                lastTopColor = Color.Empty,
                lastRightColor = Color.Empty,
                lastBottomColor = Color.Empty,
                lastLeftColor = Color.Empty;
            Point topPos = Point.Empty,
                rightPos = Point.Empty,
                bottomPos = Point.Empty,
                leftPos = Point.Empty;

            //var topSpan = new LineSpan();
            //var rightSpan = new LineSpan();
            //var bottomSpan = new LineSpan();
            //var leftSpan = new LineSpan();

            while (true)
            {
                // 上
                var top = y - offset;
                if (topPos.IsEmpty)
                {
                    if (top < 0)
                    {
                        // 边界处理
                        topPos = new Point(x, 0);
                        topColor = cache.Get(x, 0);
                        //drawLine(img, x, 0, Orient.Horison);
                    }
                    else
                    {
                        topColor = cache.Get(x, top);
                        if (ColorUtil.IsSimilarColor(topColor, color) || ColorUtil.IsSimilarColor(topColor, lastTopColor))
                        {
                            lastTopColor = topColor;
                            topColor = Color.Empty;
                        }
                        else
                        {
                            topPos = new Point(x, top);
                            //img.SetPixel(x, top, fill);
                            //drawLine(img, x, top, Orient.Horison);
                        }
                    }
                }
                // 右
                var right = x + offset;
                if (rightPos.IsEmpty)
                {
                    if (right >= width)
                    {
                        // 边界处理
                        rightPos = new Point(width - 1, y);
                        rightColor = cache.Get(width - 1, y);
                        //drawLine(img, width - 1, y, Orient.Vertical);
                    }
                    else
                    {
                        rightColor = cache.Get(right, y);

                        if (ColorUtil.IsSimilarColor(rightColor, color) || ColorUtil.IsSimilarColor(rightColor, lastRightColor))
                        {
                            lastRightColor = rightColor;
                            rightColor = Color.Empty;
                        }
                        else
                        {
                            rightPos = new Point(right, y);
                            //img.SetPixel(right, y, fill);
                            //drawLine(img, right, y, Orient.Vertical);
                        }
                    }
                }
                // 下
                var bottom = y + offset;
                if (bottomPos.IsEmpty)
                {
                    if (bottom >= height)
                    {
                        // 边界处理
                        bottomPos = new Point(x, height - 1);
                        bottomColor = cache.Get(x, height - 1);
                        //drawLine(img, x, height - 1, Orient.Horison);
                    }
                    else
                    {
                        bottomColor = cache.Get(x, bottom);
                        if (ColorUtil.IsSimilarColor(bottomColor, color) || ColorUtil.IsSimilarColor(bottomColor, lastBottomColor))
                        {
                            lastBottomColor = bottomColor;
                            bottomColor = Color.Empty;
                        }
                        else
                        {
                            bottomPos = new Point(x, bottom);
                            //img.SetPixel(x, bottom, fill);
                            //drawLine(img, x, bottom, Orient.Horison);
                        }
                    }
                }
                // 左
                var left = x - offset;
                if (leftPos.IsEmpty && left >= 0)
                {
                    if (left < 0)
                    {
                        // 边界处理
                        leftPos = new Point(0, y);
                        leftColor = cache.Get(0, y);
                        //drawLine(img, 0, y, Orient.Vertical);
                    }
                    else
                    {
                        leftColor = cache.Get(left, y);
                        if (ColorUtil.IsSimilarColor(leftColor, color) || ColorUtil.IsSimilarColor(leftColor, lastLeftColor))
                        {
                            lastLeftColor = leftColor;
                            leftColor = Color.Empty;
                        }
                        else
                        {
                            leftPos = new Point(left, y);
                            //img.SetPixel(left, y, fill);
                            //drawLine(img, left, y, Orient.Vertical);
                        }
                    }
                }

                // 4个方向都找到了
                if (!topPos.IsEmpty && !rightPos.IsEmpty && !bottomPos.IsEmpty && !leftPos.IsEmpty)
                {
                    //if (IsPointsValid(img, color,
                    //    ref topPos, ref rightPos, ref bottomPos, ref leftPos,
                    //    topColor, rightColor, bottomColor, leftColor,
                    //    topSpan, rightSpan, bottomSpan, leftSpan))
                    {
                        break;
                    }
                    //continue;
                }

                // 四个方向都找不到
                if (left < 0 && right >= width && top < 0 && bottom >= height)
                {
                    //Console.WriteLine("4个方向都找不到不同的点");
                    break;
                }

                offset++;
            }

            if (drawLine)
            {
                // 从光标处画十字线

                // 画水平线
                for (int i = leftPos.X; i < rightPos.X; i++)
                {
                    img.SetPixel(i, y, cache.GetContrast(i, y));
                }
                // 画垂直线
                for (int i = topPos.Y; i < bottomPos.Y; i++)
                {
                    img.SetPixel(x, i, cache.GetContrast(x, i));
                }
            }

            //Console.WriteLine("TOP:{0},RIGHT:{1},BOTTOM:{2},LEFT:{3}", topPos, rightPos, bottomPos, leftPos);

            var rect = new Rectangle(leftPos.X, topPos.Y, rightPos.X - leftPos.X, bottomPos.Y - topPos.Y);

            if (drawBorder)
            {
                var rightTop = new Point(rect.X + rect.Width, rect.Y);
                var rightBottom = new Point(rect.X + rect.Width, rect.Y + rect.Height);
                var leftBottom = new Point(rect.X, rect.Y + rect.Height);
                var leftTop = new Point(rect.X, rect.Y);

                // top
                DrawLine(img, rightTop, rightBottom);
                // right
                DrawLine(img, leftTop, rightTop);
                // bottom
                DrawLine(img, rightBottom, leftBottom);
                // left
                DrawLine(img, leftBottom, leftTop);
            }
            return rect;
        }

        /// <summary>
        /// 判断获取到的点是否可用
        /// 可用的依据：相邻的点所在线段是否相交
        /// </summary>
        /// <param name="img"></param>
        /// <param name="targetColor"></param>
        /// <param name="topPos"></param>
        /// <param name="rightPos"></param>
        /// <param name="bottomPos"></param>
        /// <param name="leftPos"></param>
        /// <param name="topColor"></param>
        /// <param name="rightColor"></param>
        /// <param name="bottomColor"></param>
        /// <param name="leftColor"></param>
        /// <param name="topSpan"></param>
        /// <param name="rightSpan"></param>
        /// <param name="bottomSpan"></param>
        /// <param name="leftSpan"></param>
        /// <returns></returns>
        private bool IsPointsValid(Bitmap img, Color targetColor,
            ref Point topPos, ref Point rightPos, ref Point bottomPos, ref Point leftPos,
            Color topColor, Color rightColor, Color bottomColor, Color leftColor,
            LineSpan topSpan, LineSpan rightSpan, LineSpan bottomSpan, LineSpan leftSpan)
        {
            topSpan.Reset(topPos);
            rightSpan.Reset(rightPos);
            bottomSpan.Reset(bottomPos);
            leftSpan.Reset(leftPos);

            // 获取与当前颜色不同的线段
            GetLineSpan(topPos, targetColor, Orientions.Horizontal, topSpan);
            GetLineSpan(rightPos, targetColor, Orientions.Vertical, rightSpan);
            GetLineSpan(bottomPos, targetColor, Orientions.Horizontal, bottomSpan);
            GetLineSpan(leftPos, targetColor, Orientions.Vertical, leftSpan);

            var rightTop = rightSpan.Intersect(topSpan);
            var rightBottom = rightSpan.Intersect(bottomSpan);
            var leftBottom = leftSpan.Intersect(bottomSpan);
            var leftTop = leftSpan.Intersect(topSpan);

            if (leftTop && rightTop && leftBottom && rightBottom)
            {
                return true;
            }

            var isValid = true;

            // 测试每根线段延长线，如果延长线有交点，那么这条线不可用（也就是说这条线是矩形内的线段）
            if (!leftTop)
            {
                if (leftPos.X < topSpan.FromX)
                {
                    if (topPos.Y > 0)
                    {
                        // 左边线在上边线的左端点更左侧，此时需要重新获取上边线
                        topPos = Point.Empty;
                        isValid = false;
                    }
                }
                else
                {
                    if (leftPos.X > 0)
                    {
                        // 左边线在上边线的左端点右侧，此时需要重新获取左边线
                        leftPos = Point.Empty;
                        isValid = false;
                    }
                }
                if (!isValid)
                {
                    return false;
                }
            }
            if (!leftBottom)
            {
                if (leftPos.X < bottomSpan.FromX)
                {
                    if (bottomPos.Y < cache.Height)
                    {
                        // 左边线在下边线的左端点更左侧，此时需要重新获取下边线
                        bottomPos = Point.Empty;
                        isValid = false;
                    }
                }
                else
                {
                    if (leftPos.X > 0)
                    {
                        // 左边线在下边线的左端点右侧，此时需要重新获取左边线
                        leftPos = Point.Empty;
                        isValid = false;
                    }
                }
                if (!isValid)
                {
                    return false;
                }
            }
            if (!rightTop)
            {
                if (rightPos.X > topSpan.ToX)
                {
                    if (topPos.Y > 0)
                    {
                        // 右边线在上边线的右端点更右侧，此时需要重新获取上边线
                        topPos = Point.Empty;
                        isValid = false;
                    }
                }
                else
                {
                    if (rightPos.X < cache.Width)
                    {
                        // 右边线在上边线的右端点左侧，此时需要重新获取右边线
                        rightPos = Point.Empty;
                        isValid = false;
                    }
                }
                if (!isValid)
                {
                    return false;
                }
            }
            if (!rightBottom)
            {
                if (rightPos.X > bottomSpan.ToX)
                {
                    if (bottomPos.Y < cache.Height)
                    {
                        // 右边线在下边线的右端点更右侧，此时需要重新获取下边线
                        bottomPos = Point.Empty;
                        isValid = false;
                    }
                }
                else
                {
                    if (rightPos.X < cache.Width)
                    {
                        // 右边线在下边线的右端点左侧，此时需要重新获取右边线
                        rightPos = Point.Empty;
                        isValid = false;
                    }
                }
                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }

        bool HasSimilarNeiboor(Bitmap img, Color diffColor, Point diffPoint, int r = 5)
        {
            // 顺时针查找
            for (int i = 0; i < r; i++)
            {
                //var x = diffPoint.X + i;
                for (int j = 0; j < r; j++)
                {
                    //var y = diffPoint.Y + j;
                    if (ColorUtil.IsSimilarColor(cache.Get(diffPoint.X, diffPoint.Y), diffColor))
                    {
                        return true;
                    }
                }
                for (int j = 0; j < r; j++)
                {
                    //var y = diffPoint.Y + j;
                    if (ColorUtil.IsSimilarColor(cache.Get(diffPoint.X, diffPoint.Y), diffColor))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 获取指定方向上与指定颜色不同的线段
        /// </summary>
        /// <param name="point"></param>
        /// <param name="color"></param>
        /// <param name="orient"></param>
        /// <param name="span"></param>
        void GetLineSpan(Point point, Color color, Orientions orient, LineSpan span)
        {
            span.Reset(point);

            if (orient == Orientions.Horizontal)
            {
                // 向左
                for (int i = point.X; i >= 0; i--)
                {
                    if (ColorUtil.IsSimilarColor(color, cache.Get(i, point.Y)))
                    {
                        span.FromX = i;
                        break;
                    }
                }
                // 向右
                for (int i = point.X; i < cache.Width; i++)
                {
                    if (ColorUtil.IsSimilarColor(color, cache.Get(i, point.Y)))
                    {
                        span.ToX = i;
                        break;
                    }
                }
                return;
            }

            // 向上
            for (int i = point.Y; i >= 0; i--)
            {
                if (ColorUtil.IsSimilarColor(color, cache.Get(point.X, i)))
                {
                    span.FromY = i;
                    break;
                }
            }
            // 向下
            for (int i = point.Y; i < cache.Height; i++)
            {
                if (ColorUtil.IsSimilarColor(color, cache.Get(point.X, i)))
                {
                    span.ToY = i;
                    break;
                }
            }
        }

        /// <summary>
        /// 根据指定的起点和终点在图片上画线
        /// </summary>
        /// <param name="img"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        void DrawLine(Bitmap img, Point from, Point to)
        {
            int min, max;
            //Console.WriteLine("从{0}到{1}画线", from, to);
            if (from.X == to.X)
            {
                min = Math.Min(from.Y, to.Y);
                max = Math.Max(from.Y, to.Y);
                // 画竖线
                for (int i = min; i < max; i++)
                {
                    img.SetPixel(from.X, i, cache.GetContrast(from.X, i));
                }
                return;
            }

            min = Math.Min(from.X, to.X);
            max = Math.Max(from.X, to.X);
            // 画横线
            for (int i = min; i < max; i++)
            {
                img.SetPixel(i, from.Y, cache.GetContrast(i, from.Y));
            }
        }

        public bool isGray(Color color)
        {
            return bt(color.R) + bt(color.G) + bt(color.B) >= 2;
        }

        public int bt(byte val)
        {
            return val >= 100 && val <= 200 ? 1 : 0;
        }

        public bool isLight(Color color)
        {
            return gt200(color.R) + gt200(color.G) + gt200(color.B) >= 2;
        }

        public bool isDark(Color color)
        {
            return lt150(color.R) + lt150(color.G) + lt150(color.B) >= 2;
        }

        public bool isSingle(Color color)
        {
            return lt100(color.R) + lt100(color.G) + lt100(color.B) == 2 && gt200(color.R) + gt200(color.G) + gt200(color.B) == 1;
        }
        public int lt150(byte val)
        {
            return val <= 150 ? 1 : 0;
        }
        public int lt100(byte val)
        {
            return val <= 100 ? 1 : 0;
        }

        public int gt200(byte val)
        {
            return val >= 200 ? 1 : 0;
        }
    }
}
