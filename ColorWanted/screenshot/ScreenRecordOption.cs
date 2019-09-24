using System.Drawing.Imaging;
using System.Linq;

namespace ColorWanted.screenshot
{
    public static class ScreenRecordOption
    {
        public static int Interval { get; set; }
        public static int FrameRate { get; set; }
        public static string CachePath { get; set; }

        public static readonly ImageCodecInfo CodecInfo;
        public static readonly EncoderParameters EncoderParameters;

        static ScreenRecordOption()
        {
            CodecInfo = ImageCodecInfo.GetImageEncoders().First(item => item.FormatID == ImageFormat.Jpeg.Guid);
            EncoderParameters = new EncoderParameters(1);
        }
    }
}
