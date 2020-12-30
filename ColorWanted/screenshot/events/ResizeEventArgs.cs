using System;
using System.Windows;

namespace ColorWanted.screenshot.events
{
    class ResizeEventArgs : EventArgs
    {
        public ResizePositions ResizePosition { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
    }

    delegate void ResizeEventHandler(object sender, ResizeEventArgs e);
}
