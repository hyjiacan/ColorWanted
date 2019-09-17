using System.Windows;

namespace ColorWanted.screenshot
{
    /// <summary>
    /// 绘制历史信息项
    /// </summary>
    public class DrawHistoryItem
    {
        public FrameworkElement Element { get; set; }
        public DrawRecord Record { get; set; }
    }
}
