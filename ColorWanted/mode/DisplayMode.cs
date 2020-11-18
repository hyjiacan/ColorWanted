using ColorWanted.ext;

namespace ColorWanted.mode
{
    /// <summary>
    /// 显示模式
    /// </summary>
    internal enum DisplayMode
    {
        /// <summary>
        /// 隐藏窗口，此时在后台工作，仍然可以通过快捷键复制取到的颜色值
        /// </summary>
        [EnumDescription("隐藏", "窗口不可见，但取色功能仍然可用")]
        Hidden,
        /// <summary>
        /// 窗口在固定位置显示，此时可以使用鼠标拖动改变窗口位置
        /// </summary>
        [EnumDescription("固定", "窗口显示在屏幕的固定位置")]
        Fixed,
        /// <summary>
        /// 窗口跟随光标显示
        /// </summary>
        [EnumDescription("跟随", "窗口跟随鼠标位置在屏幕内移动")]
        Follow
    }
}
