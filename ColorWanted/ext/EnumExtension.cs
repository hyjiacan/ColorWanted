using ColorWanted.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorWanted.ext
{
    /// <summary>
    /// 枚举类型的扩展
    /// </summary>
    static class EnumExtension
    {
        /// <summary>
        /// 获取快捷键枚举的int类型值
        /// </summary>
        /// <param name="hotKeyValue"></param>
        /// <returns></returns>

        internal static int AsInt(this HotKeyValue hotKeyValue)
        {
            return (int)hotKeyValue;
        }

        /// <summary>
        /// 获取显示模式枚举的int类型值
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        internal static int AsInt(this DisplayMode mode)
        {
            return (int)mode;
        }
    }
}
