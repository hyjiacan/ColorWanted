namespace ColorWanted.screenshot
{
    public static class ScreenRecordOption
    {
        /// <summary>
        /// 帧速率
        /// </summary>
        public static int Fps { get; set; }
        /// <summary>
        /// 重复次数
        /// </summary>
        public static int RepeatCount { get; set; }
        /// <summary>
        /// 图片的缓存路径
        /// </summary>
        public static string CachePath { get; set; }
    }
}
