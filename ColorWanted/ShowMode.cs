using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorWanted
{
    /// <summary>
    /// 窗口显示模式
    /// </summary>
    enum ShowMode
    {
        /// <summary>
        /// 隐藏
        /// </summary>
        Hidden,
        /// <summary>
        /// 固定在屏幕某位置
        /// </summary>
        FixedScreen,
        /// <summary>
        /// 跟随光标
        /// </summary>
        FollowCaret,
        /// <summary>
        /// 嵌入任务栏
        /// </summary>
        EmbedTaskBar
    }
}
