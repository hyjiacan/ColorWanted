
using ColorWanted.ext;

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
        [EnumDescription("几何推导法")]
        Geometry,
        /// <summary>
        /// 坐标变换法
        /// </summary>
        [EnumDescription("坐标变换法")]
        Axis,
        /// <summary>
        /// 分段定义法
        /// </summary>
        [EnumDescription("分段定义法")]
        Segment,
        /// <summary>
        /// Bajon近似算法
        /// </summary>
        [EnumDescription("Bajon近似算法")]
        Bajon,
        /// <summary>
        /// 标准模型法
        /// </summary>
        [EnumDescription("标准模型法")]
        Standard
    }
}
