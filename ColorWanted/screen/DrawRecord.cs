using System.Drawing;

namespace ColorWanted.screen
{
    internal class DrawRecord
    {
        public DrawType Type { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

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
            return new DrawRecord { Type = type, Color = System.Drawing.Color.Red };
        }
    }
}
