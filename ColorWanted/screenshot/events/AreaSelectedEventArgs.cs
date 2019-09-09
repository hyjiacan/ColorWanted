using System;
using System.Drawing;
using System.Windows;

namespace ColorWanted.screenshot.events
{
    public class AreaSelectedEventArgs : EventArgs
    {
        public Rectangle Rect { get; private set; }
        public AreaSelectedEventArgs(Rect rect)
        {
            Rect = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }
    }
}
