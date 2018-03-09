
namespace ColorWanted.colors
{
    /// <summary>
    /// HSI转换算法
    /// </summary>
    public enum HsiAlgorithm
    {
        /// <summary>
        /// 几何推导法
        /// </summary>
        Geometry,
        /// <summary>
        /// 坐标变换法
        /// </summary>
        Axis,
        /// <summary>
        /// 分段定义法
        /// </summary>
        Segment,
        /// <summary>
        /// Bajon近似算法
        /// </summary>
        Bajon,
        /// <summary>
        /// 标准模型法
        /// </summary>
        Standard
    }
}
