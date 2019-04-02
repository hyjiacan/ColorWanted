using System.Collections.Generic;

namespace ColorWanted.i18n
{
    /// <summary>
    /// 本地语言信息
    /// </summary>
    internal class Language
    {
        /// <summary>
        /// 语言的 i18n 名称
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// 语言版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 语言的作者信息
        /// </summary>
        public Author[] Authors { get; set; }

        /// <summary>
        /// 窗体与其内的控件的文本
        /// </summary>
        public Dictionary<string, Dictionary<string, Dictionary<string, string>>> Resource { get; set; }
    }
}
