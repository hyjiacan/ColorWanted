using ColorWanted.enums;
using System;
using System.Windows.Forms;

namespace ColorWanted.hotkey
{
    [AttributeUsage(AttributeTargets.Field)]
    class HotkeyAttribute : Attribute
    {
        public string Name { get; private set; }
        public KeyModifier Modifiers { get; set; }
        public Keys Key { get; set; }

        public HotKeyType HotKeyType { get; set; }

        public HotkeyAttribute(string name)
        {
            Name = name;
            Modifiers = KeyModifier.Alt;
        }
    }
}
