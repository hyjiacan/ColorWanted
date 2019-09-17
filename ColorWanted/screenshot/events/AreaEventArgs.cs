using System;
using System.Drawing;
using System.Windows;

namespace ColorWanted.screenshot.events
{
    /// <summary>
    /// 选区相关的事件参数
    /// </summary>
    public class AreaEventArgs : EventArgs
    {
        public Rectangle Rect { get; private set; }
        public AreaEventArgs(Rect rect)
        {
            Rect = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }
    }
}
