using System;
using System.Drawing;

namespace ColorWanted.screenshot.events
{
    /// <summary>
    /// 双击mask层时截图的事件参数
    /// </summary>
    public class DoubleClickEventArgs : EventArgs
    {
        public Bitmap Image { get; private set; }
        public DoubleClickEventArgs(Bitmap image)
        {
            Image = image;
        }
    }
}
