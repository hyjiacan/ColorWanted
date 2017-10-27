
namespace ColorWanted.update.git
{
    /// <summary>
    /// tag对象信息
    /// 数据来自 
    /// https://api.github.com/repos/hyjiacan/ColorWanted/git/tags/:sha
    /// </summary>
    class TagObject
    {
        public Tagger tagger { get; set; }
        public string message { get; set; }
    }
}
