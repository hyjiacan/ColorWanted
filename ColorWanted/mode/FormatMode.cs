namespace ColorWanted.mode
{
    /// <summary>
    /// 颜色格式面板显示模式
    /// </summary>
    internal enum FormatMode
    {
        /// <summary>
        /// mini模式，只显示HEX格式
        /// </summary>
        Mini = 1,
        /// <summary>
        /// 标准模式，显示HEX和RGB格式
        /// </summary>
        Standard,
        /// <summary>
        /// 扩展模式，显示HEX和RGB格式以及HSVB信息
        /// </summary>
        Extention,
        /// <summary>
        /// 截图模式，只显示截图按钮
        /// </summary>
        Shot
    }
}
