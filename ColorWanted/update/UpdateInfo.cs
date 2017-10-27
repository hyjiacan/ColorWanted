using System;

namespace ColorWanted.update
{
    internal class UpdateInfo
    {
        /// <summary>
        /// 更新的版本号字符串
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 更新的下载地址
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 更新的状态(true: 成功，false: 失败)
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 更新消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime Date { get; set; }
    }
}
