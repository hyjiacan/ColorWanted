using System.Windows.Forms;

namespace ColorWanted.hotkey
{
    /// <summary>
    /// 全局快捷键类型定义
    /// </summary>
    internal enum HotKeyType
    {
        /// <summary>
        /// 切换显示模式
        /// </summary>
        [HotKey("切换显示模式 (隐藏/固定/跟随)", Key = Keys.F1)]
        SwitchMode = 0xF00001,
        /// <summary>
        /// 显示更多的颜色格式
        /// </summary>       
        [HotKey("切换显示/隐藏RGB格式面板", Key = Keys.E)]
        ShowMoreFormat,
        /// <summary>
        /// 复制颜色值
        /// </summary>  
        [HotKey("复制颜色值，单击复制十六进制格式,双击复制RGB格式", Key = Keys.C)]
        CopyColor,
        /// <summary>
        /// 复制策略，控制是否仅复制值（同时对hex和rgb生效）
        /// </summary>  
        [HotKey("切换复制策略", Key = Keys.V)]
        CopyPolicy,
        /// <summary>
        /// 显示预览窗口
        /// </summary>   
        [HotKey("显示/隐藏预览面板", Key = Keys.F2)]
        ShowPreview,
        /// <summary>
        /// 显示调色板
        /// </summary>   
        [HotKey("打开调色板", Key = Keys.F3)]
        ShowColorPicker,
        /// <summary>
        /// 控制是否绘制
        /// </summary>   
        [HotKey("单击暂停/开始绘制预览窗,双击暂停/开始取色", Key = Keys.Oemtilde)]
        ControlDraw,
        /// <summary>
        /// 将取色和预览窗口显示到最顶层(如果是显示的)
        /// </summary>   
        [HotKey("将取色和预览窗口显示到最顶层", Key = Keys.T)]
        BringToTop
    }
}
