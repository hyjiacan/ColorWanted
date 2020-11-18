using System;

namespace ColorWanted.ext
{
    /// <summary>
    /// 枚举描述工具，主要用于设置窗口获取描述信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    internal class EnumDescriptionAttribute : Attribute
    {
        public EnumDescriptionAttribute(string name)
        {
            Name = name;
        }
        public EnumDescriptionAttribute(string name, string tip)
        {
            Name = name;
            Tip = tip;
        }
        public string Name { get; set; }
        public string Tip { get; set; }
        public string Value { get; set; }

        public string Description
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Tip))
                {
                    return Name;
                }
                return $"{Name} *{Tip}";
            }
        }
    }
}
