
namespace ColorWanted.update.git
{
    /// <summary>
    /// 请求https://api.github.com/repos/hyjiacan/ColorWanted/git/refs/tags/tagName 得到的数据
    /// </summary>
    class RefItem
    {
        public string @ref { get; set; }
        public CommitItem @object { get; set; }
    }
}

