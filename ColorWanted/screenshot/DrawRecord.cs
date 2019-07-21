using System.Drawing;

namespace ColorWanted.screenshot
{
    internal class DrawRecord
    {
        public DrawType Type { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }
        public int Width { get; set; }

        public bool HasOffset => Start != End;
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

        public static DrawRecord Make(DrawType type)
        {
            return new DrawRecord { Type = type, Color = System.Drawing.Color.Red, Width = 1 };
        }

        public void Reset()
        {
            Start = End = Point.Empty;
            Text = string.Empty;
        }

        public DrawRecord Copy(int offsetStartX = 0, int offsetStartY = 0, int offsetEndX = 0, int offsetEndY = 0)
        {
            var temp = new DrawRecord
            {
                Type = Type,
                Start = Start,
                End = End,
                Text = Text,
                Color = Color,
                Width = Width
            };

            temp.Start.Offset(offsetStartX, offsetStartY);
            temp.End.Offset(offsetEndX, offsetEndY);

            return temp;
        }
    }
}
