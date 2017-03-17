using System;

namespace ColorWanted
{
    /**
     * 这个定义在 winuser.h 中
    MOD_ALT         0x0001
    MOD_CONTROL     0x0002
    MOD_SHIFT       0x0004
    MOD_WIN         0x0008
     * */
    //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
    [Flags]
    public enum KeyModifiers
    {
        Alt = 1,
        //Ctrl = 2,
        //Shift = 4,
        //WindowsKey = 8
    }
}
