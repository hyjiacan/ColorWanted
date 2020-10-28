using System;

namespace ColorWanted.setting
{
    /// <summary>
    /// 标识一个类是配置模块
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class SettingModuleAttribute : Attribute
    {
        public string Name { get; set; }

        public SettingModuleAttribute(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// 标识一个属性是配置项
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    class SettingItemAttribute : Attribute
    {
        public string Name { get; set; }

        public SettingItemAttribute(string name)
        {
            Name = name;
        }
    }
}
