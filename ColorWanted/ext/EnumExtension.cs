using ColorWanted.enums;
using ColorWanted.hotkey;

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

        public static HotkeyAttribute GetAttribute(this HotKeyType hotKeyType)
        {
            var type = hotKeyType.GetType();
            var attrs = type.GetCustomAttributes(typeof(HotkeyAttribute), false);
            if (attrs.Length == 0)
            {
                return null;
            }
            var attr = attrs[0] as HotkeyAttribute;
            attr.HotKeyType = hotKeyType;
            return attr;
        }
    }
}
