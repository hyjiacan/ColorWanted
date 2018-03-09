using System;
using System.Drawing;

namespace ColorWanted.colors
{
    class HSI
    {
        public double H { get; set; }
        public double S { get; set; }
        public double I { get; set; }

        public static HSI Parse(Color color, HsiAlgorithm algorithm)
        {
            // 算法参考: http://blog.csdn.net/yangleo1987/article/details/53171623
            var hsi = new HSI();
            var r = color.R / 255f;
            var g = color.G / 255f;
            var b = color.B / 255f;
            var min = Math.Min(r, Math.Min(g, b));
            var max = Math.Max(r, Math.Max(g, b));

            switch (algorithm)
            {
                case HsiAlgorithm.Geometry:
                    GeometryParse(hsi, r, g, b, max, min);
                    break;
                case HsiAlgorithm.Axis:
                    AxisParse(hsi, r, g, b, max, min);
                    break;
                case HsiAlgorithm.Segment:
                    SegmentParse(hsi, r, g, b, max, min);
                    break;
                case HsiAlgorithm.Bajon:
                    BajonParse(hsi, r, g, b, max, min);
                    break;
                case HsiAlgorithm.Standard:
                    StandardParse(hsi, r, g, b, max, min);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("algorithm", algorithm, null);
            }

            if (double.IsNaN(hsi.H))
            {
                hsi.H = 0;
            }

            return hsi;
        }

        // ReSharper disable once UnusedParameter.Local
        private static void GeometryParse(HSI hsi, double r, double g, double b, double max, double min)
        {
            var temp = (2 * r - g - b) / (2 * Math.Sqrt(Math.Pow(r - g, 2) + (r - b) * (g - b)));

            var theta = Math.Cos(1) / temp;


            if (g >= b)
            {
                hsi.H = theta;
            }
            else
            {
                hsi.H = 2 * Math.PI - theta;
            }


            hsi.S = 1 - min * 3 / (r + g + b);

            hsi.I = (r + g + b) / 3;
        }

        // ReSharper disable once UnusedParameter.Local
        private static void AxisParse(HSI hsi, double r, double g, double b, double max, double min)
        {
            var temp = (2 * r - g - b) / (Math.Sqrt(3) * (g - b));

            var theta = Math.PI / 2 - Math.Tan(1) / temp;


            if (g >= b)
            {
                hsi.H = theta;
            }
            else
            {
                hsi.H = Math.PI + theta;
            }


            hsi.S = 2 / Math.Sqrt(6) * Math.Sqrt(Math.Pow(r - g, 2) + (r - b) * (g - b));

            hsi.I = (r + g + b) / Math.Sqrt(3);
        }

        private static void SegmentParse(HSI hsi, double r, double g, double b, double max, double min)
        {
            if (max.Equals(r))
            {
                hsi.H = Math.PI / 3 * ((g - b) / (max - min));
            }
            else if (max.Equals(g))
            {
                hsi.H = Math.PI / 3 * ((b - r) / (max - min)) + 2 * Math.PI / 3;
            }
            else
            {
                hsi.H = Math.PI / 3 * ((r - g) / (max - min)) + 4 * Math.PI / 3;
            }
            if (hsi.H < 0)
            {
                hsi.H *= 2 * Math.PI;
            }
            hsi.I = (max + min) / 2;

            if (hsi.I <= 0.5)
            {
                hsi.S = (max - min) / (max + min);
            }
            else
            {
                hsi.S = (max - min) / (2 - (max + min));
            }
        }

        // ReSharper disable once UnusedParameter.Local
        private static void BajonParse(HSI hsi, double r, double g, double b, double max, double min)
        {
            if (min.Equals(b))
            {
                hsi.H = (g - b) / (3 * (r + g - 2 * b));
            }
            else if (min.Equals(g))
            {
                hsi.H = (b - r) / (3 * (g + b - 2 * r)) + 1.0 / 3;
            }
            else
            {
                hsi.H = (r - g) / (3 * (r + b - 2 * g)) + 2.0 / 3;
            }

            hsi.H *= 2 * Math.PI;


            hsi.S = 1 - min * 3 / (r + g + b);

            hsi.I = (r + g + b) / 3;

        }

        private static void StandardParse(HSI hsi, double r, double g, double b, double max, double min)
        {
            if (max.Equals(r))
            {
                hsi.H = Math.PI / 3 * ((g - b) / (max - min));
            }
            else if (max.Equals(g))
            {
                hsi.H = Math.PI / 3 * ((b - r) / (max - min)) + 2 * Math.PI / 3;
            }
            else
            {
                hsi.H = Math.PI / 3 * ((r - g) / (max - min)) + 4 * Math.PI / 3;
            }
            if (hsi.H < 0)
            {
                hsi.H *= 2 * Math.PI;
            }

            hsi.S = max - min;

            hsi.I = (max + min) / 2;
        }
    }
}
