using System.Windows.Forms;
using ColorWanted.hotkey;

namespace ColorWanted.enums
{
    /// <summary>
    /// 全局快捷键类型定义
    /// </summary>
    internal enum HotKeyType
    {
        /// <summary>
        /// 切换显示模式
        /// </summary>
        [Hotkey("切换显示模式", Key = Keys.F1)]
        SwitchMode = 0xF00001,
        /// <summary>
        /// 显示更多的颜色格式
        /// </summary>       
        [Hotkey("切换显示格式", Key = Keys.E)]
        ShowMoreFormat,
        /// <summary>
        /// 复制颜色值
        /// </summary>  
        [Hotkey("复制颜色", Key = Keys.C)]
        CopyColor,
        /// <summary>
        /// 复制策略，控制是否仅复制值（同时对hex和rgb生效）
        /// </summary>  
        [Hotkey("切换复制策略", Key = Keys.V)]
        CopyPolicy,
        /// <summary>
        /// 显示预览窗口
        /// </summary>   
        [Hotkey("显示预览窗口", Key = Keys.F2)]
        ShowPreview,
        /// <summary>
        /// 显示调色板
        /// </summary>   
        [Hotkey("显示调色板", Key = Keys.F3)]
        ShowColorPicker,
        /// <summary>
        /// 控制是否绘制
        /// </summary>   
        [Hotkey("控制是否绘制", Key = Keys.Oemtilde)]
        ControlDraw,
        /// <summary>
        /// 将取色和预览窗口显示到最顶层(如果是显示的)
        /// </summary>   
        [Hotkey("将取色和预览窗口显示到最顶层", Key = Keys.T)]
        BringToTop
    }
}
