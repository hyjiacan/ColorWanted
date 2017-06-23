using ColorWanted.hotkey;
using ColorWanted.mode;

namespace ColorWanted.ext
{
    /// <summary>
    /// 枚举类型的扩展
    /// </summary>
    internal static class EnumExtension
    {
        /// <summary>
        /// 获取快捷键枚举的int类型值
        /// </summary>
        /// <param name="hotKeyValue"></param>
        /// <returns></returns>

        public static int AsInt(this HotKeyType hotKeyValue)
        {
            return (int)hotKeyValue;
        }

        /// <summary>
        /// 获取显示模式枚举的int类型值
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static int AsInt(this DisplayMode mode)
        {
            return (int)mode;
        }
    }
}
