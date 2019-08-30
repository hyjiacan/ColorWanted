using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColorWanted.screenshot
{
    public class DrawRecord
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
                return Points.FirstOrDefault();
            }
            set
            {
                Points.Clear();
                Points.Add(value);
            }
        }
        /// <summary>
        /// 终点坐标
        /// </summary>
        public Point End
        {
            get
            {
                return Points.Count > 1 ? Points.Last() : new Point();
            }
            set
            {
                Points.Add(value);
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
        public System.Drawing.Font TextFont { get; set; }
        /// <summary>
        /// 鼠标移动的点集合
        /// </summary>
        public PointCollection Points { get; set; }
        /// <summary>
        /// 是否偏移(起点终点是否相同)
        /// </summary>
        public bool HasOffset => Start != End || (Type == DrawTypes.Pen && Points.Any());

        /// <summary>
        /// 区域大小
        /// </summary>
        public Size Size
        {
            get
            {
                var size = new Size();
                if (Points.Count > 1)
                {
                    size.Width = Math.Abs(End.X - Start.X);
                    size.Height = Math.Abs(End.Y - Start.Y);
                }

                return size;
            }
        }

        /// <summary>
        /// 起点与终点的距离
        /// </summary>
        public int Distance => (int)Math.Sqrt(Math.Abs(Start.X - End.X) * Math.Abs(Start.X - End.X) + Math.Abs(Start.Y - End.Y) * Math.Abs(Start.Y - End.Y));

        public DrawRecord()
        {
            Points = new PointCollection();
            Width = 1;
            Color = Colors.Red;
            LineStyle = LineStyles.Solid;
            TextFont = System.Drawing.SystemFonts.DefaultFont;
        }

        public static DrawRecord Make(DrawTypes type)
        {
            return new DrawRecord { Type = type };
        }

        public void Reset()
        {
            Points.Clear();
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

            temp.Points = Points.Clone();

            if (temp.Points.Count > 0)
            {
                temp.Points.First().Offset(offsetStartX, offsetStartY);
            }
            if (temp.Points.Count > 1)
            {
                temp.Points.Last().Offset(offsetEndX, offsetEndY);
            }
            return temp;
        }
    }
}
