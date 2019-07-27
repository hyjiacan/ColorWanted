using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ColorWanted.screenshot
{
    internal class DrawRecord
    {
        /// <summary>
        /// 绘制类型
        /// </summary>
        public DrawTypes Type { get; set; }
        /// <summary>
        /// 起点坐标
        /// </summary>
        public Point Start
        {
            get
            {
                return PointSet.FirstOrDefault();
            }
            set
            {
                PointSet.Clear();
                PointSet.Add(value);
            }
        }
        /// <summary>
        /// 终点坐标
        /// </summary>
        public Point End
        {
            get
            {
                return PointSet.Count > 1 ? PointSet.Last() : Point.Empty;
            }
            set
            {
                PointSet.Add(value);
            }
        }
        /// <summary>
        /// 当 Type 为 Text ，输入的文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 绘制颜色
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// 线样式
        /// </summary>
        public LineStyles LineStyle { get; set; }
        /// <summary>
        /// 绘制线宽
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 文字样式
        /// </summary>
        public Font TextFont { get; set; }
        /// <summary>
        /// 鼠标移动的点集合
        /// </summary>
        public List<Point> PointSet { get; set; }
        /// <summary>
        /// 是否偏移(起点终点是否相同)
        /// </summary>
        public bool HasOffset => Start != End || PointSet.Any();
        /// <summary>
        /// 由起点终点形成的矩形
        /// </summary>
        public Rectangle Rect
        {
            get
            {
                var minX = Start.X;
                var minY = Start.Y;
                var maxX = End.X;
                var maxY = End.Y;

                if (minX > maxX)
                {
                    minX = maxX;
                    maxX = Start.X;
                }

                if (minY > maxY)
                {
                    minY = maxY;
                    maxY = Start.Y;
                }

                return new Rectangle(minX, minY, maxX - minX, maxY - minY);
            }
        }

        /// <summary>
        /// 起点与终点的距离
        /// </summary>
        public int Distance => (int)Math.Sqrt(Math.Abs(Start.X - End.X) * Math.Abs(Start.X - End.X) + Math.Abs(Start.Y - End.Y) * Math.Abs(Start.Y - End.Y));

        public DrawRecord()
        {
            PointSet = new List<Point>();
            Width = 1;
            Color = Color.Red;
            LineStyle = LineStyles.Solid;
            TextFont = SystemFonts.DefaultFont;
        }

        public static DrawRecord Make(DrawTypes type)
        {
            return new DrawRecord { Type = type };
        }

        public void Reset()
        {
            PointSet.Clear();
            Text = string.Empty;
        }

        public DrawRecord Copy(int offsetStartX = 0, int offsetStartY = 0, int offsetEndX = 0, int offsetEndY = 0)
        {
            var temp = new DrawRecord
            {
                Type = Type,
                Color = Color,
                Width = Width
            };

            temp.PointSet.AddRange(PointSet);

            if (temp.PointSet.Count > 0)
            {
                temp.PointSet.First().Offset(offsetStartX, offsetStartY);
            }
            if (temp.PointSet.Count > 1)
            {
                temp.PointSet.Last().Offset(offsetEndX, offsetEndY);
            }
            return temp;
        }
    }
}
