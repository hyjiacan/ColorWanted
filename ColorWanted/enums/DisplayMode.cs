namespace ColorWanted.enums
{
    /// <summary>
    /// 显示模式
    /// </summary>
    internal enum DisplayMode
    {
        /// <summary>
        /// 隐藏窗口，此时在后台工作，仍然可以通过快捷键复制取到的颜色值
        /// </summary>
        Hidden = 1,
        /// <summary>
        /// 窗口在固定位置显示，此时可以使用鼠标拖动改变窗口位置
        /// </summary>
        Fixed,
        /// <summary>
        /// 窗口跟随光标显示
        /// </summary>
        Follow
    }
}
