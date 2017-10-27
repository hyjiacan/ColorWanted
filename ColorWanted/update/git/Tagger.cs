using System;

namespace ColorWanted.update.git
{
    /// <summary>
    /// tag创建信息
    /// </summary>
    class Tagger
    {
        public string name { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }
    }
}
