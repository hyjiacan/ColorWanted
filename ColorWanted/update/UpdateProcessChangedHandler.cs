
namespace ColorWanted.update
{
    public delegate void UpdateProcessChangedHandler(UpdateProcessChangedData data);

    public class UpdateProcessChangedData
    {
        public bool Success { get; set; }

        public int Percentage { get; set; }

        // 摘要: 
        //     获取收到的字节数。
        //
        // 返回结果: 
        //     一个指示收到的字节数的 System.Int64 值。
        public long BytesReceived { get; set; }
        //
        // 摘要: 
        //     获取 System.Net.WebClient 数据下载操作中的字节总数。
        //
        // 返回结果: 
        //     一个指示将要接收的字节数的 System.Int64 值。
        public long TotalBytesToReceive { get; set; }
    }
}
