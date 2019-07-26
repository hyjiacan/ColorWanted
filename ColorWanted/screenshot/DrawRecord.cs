using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ColorWanted.screenshot
{
    internal class DrawRecord
    {
        public DrawTypes Type { get; set; }
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
        public string Text { get; set; }
        public Color Color { get; set; }
        public int Width { get; set; }
        public List<Point> PointSet { get; set; }

        public bool HasOffset => Start != End || PointSet.Any();
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

        public int Distance => (int)Math.Sqrt(Math.Abs(Start.X - End.X) * Math.Abs(Start.X - End.X) + Math.Abs(Start.Y - End.Y) * Math.Abs(Start.Y - End.Y));

        public DrawRecord()
        {
            PointSet = new List<Point>();
        }

        public static DrawRecord Make(DrawTypes type)
        {
            return new DrawRecord { Type = type, Color = System.Drawing.Color.Red, Width = 1 };
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
                End = End,
                Text = Text,
                Color = Color,
                Width = Width
            };

            temp.PointSet.AddRange(PointSet);

            if (temp.PointSet.Count > 0)
            {
                temp.PointSet[0].Offset(offsetStartX, offsetStartY);
            }
            if (temp.PointSet.Count > 1)
            {
                temp.PointSet.Last().Offset(offsetEndX, offsetEndY);
            }
            return temp;
        }
    }
}
