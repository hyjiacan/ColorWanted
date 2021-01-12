using System;

namespace ColorWanted.screenshot.events
{
    class ResizeEventArgs : EventArgs
    {
        public ResizePositions ResizePosition { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
    }
}
