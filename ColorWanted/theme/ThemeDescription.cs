using System.Drawing;

namespace ColorWanted.theme
{
    public class ThemeDescription
    {
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }

        public bool IsEmpty
        {
            get { return ForeColor.IsEmpty || BackColor.IsEmpty; }
        }

        public ThemeDescription()
        {
            ForeColor = Color.Empty;
            BackColor = Color.Empty;
        }
    }
}
