using ColorWanted.colors;
using ColorWanted.screenshot;
using ColorWanted.setting;
using ColorWanted.util;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// https://www.cnblogs.com/1175429393wljblog/p/9887805.html

namespace ColorWanted.websocket
{
    /// <summary>
    /// 提供http支持
    /// </summary>
    public class HttpServer
    {
        private string Host;
        private int Port;
        private bool IsRunning;
        private Dictionary<string, Func<string, string>> Commands;

        public HttpServer(string host, int port)
        {
            Host = host;
            Port = port;

            Commands = new Dictionary<string, Func<string, string>>();

            RegisterCommand("Hi hyjican, tell me the color of pixel under the cursor please. Thank you!", (data) =>
            {
                var pos = Control.MousePosition;
                var color = ColorUtil.GetColor(pos);

                var hsl = new HSL(color.GetHue(), color.GetSaturation(), color.GetBrightness());
                var hsb = HSB.Parse(color);
                var hsi = HSI.Parse(color, Settings.Main.HsiAlgorithm);

                return string.Format("It's my pleasure, the following lines shows the color at pixel ({0},{1}) in different formats.\n", pos.X, pos.Y) +
                    color.ToArgb() + "\n" +
                    string.Format("#{0:X2}{1:X2}{2:X2}\nRGB({0},{1},{2})\n", color.R, color.G, color.B) +
                    string.Format("HSL({0},{1},{2})\n", Math.Round(hsl.H), Util.Round(hsl.S * 100), Util.Round(hsl.L * 100)) +
                    string.Format("HSB({0},{1},{2})\n", Math.Round(hsb.H), Util.Round(hsb.S * 100), Util.Round(hsb.B * 100)) +
                    string.Format("HSI({0},{1},{2})", Math.Round(hsi.H), Util.Round(hsi.S * 100), Util.Round(hsi.I * 100));
            });

            RegisterCommand("Hi hyjican, I want to take a screenshot.", (data) =>
            {
                var rect = Util.GetCurrentScreen();
                var img = ScreenShot.GetScreen(rect.X, rect.Y, rect.Width, rect.Height);
                using (var stream = new MemoryStream())
                {
                    img.Save(stream, ImageFormat.Jpeg);
                    return string.Format("OK, the next line is the image data in encoding base64.\n{0}",Convert.ToBase64String(stream.ToArray()));
                }
            });
        }

        public void RegisterCommand(string command, Func<string, string> handler)
        {
            Commands.Add(command, handler);
        }

        async public void Start()
        {
            await Task.Factory.StartNew(async () =>
            {
                // 指定为 0.0.0.0 时，使用所有可用的IP地址
                bool listenAll = Host == "0.0.0.0";

                var url = string.Format("http://{0}:{1}/", listenAll ? "*" : Host, Port);

                using (var listener = new HttpListener
                {
                    AuthenticationSchemes = AuthenticationSchemes.Anonymous
                })
                {
                    listener.Prefixes.Add(url);
                    listener.Start();

                    Logger.Info(string.Format("ColorWanted serves at http://{0}:{1}/", Host, Port));

                    IsRunning = true;

                    while (IsRunning)
                    {
                        new Thread(HttpRequestDispatcher) { IsBackground = true }.Start(await listener.GetContextAsync());
                    }
                }
            });
        }

        async private void HttpRequestDispatcher(object state)
        {
            var ctx = await ((HttpListenerContext)state).AcceptWebSocketAsync(null);

            var websocket = ctx.WebSocket;

            var buffer = new byte[1024];

            while (websocket.State == WebSocketState.Open)
            {
                try
                {
                    var segs = new ArraySegment<byte>(buffer);
                    var result = await websocket.ReceiveAsync(segs, CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }
                    if (result.Count == 0)
                    {
                        continue;
                    }
                    if (!result.EndOfMessage)
                    {
                        continue;
                    }
                    // 消息内容大于1000个字节，忽略
                    if (result.Count == 0 || result.Count > buffer.Length)
                    {
                        continue;
                    }
                    // 非文本消息，忽略
                    if (result.MessageType != WebSocketMessageType.Text)
                    {
                        continue;
                    }
                    await DispatchWSMessage(websocket, buffer, result.Count);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Logger.Debug(ex.Message);
                }
            }
        }

        private Task DispatchWSMessage(WebSocket websocket, byte[] buffer, int count)
        {
            var command = Encoding.ASCII.GetString(buffer, 0, count);

            string result;

            if (Commands.ContainsKey(command))
            {
                result = Commands[command].Invoke(command);
            }
            else
            {
                result = "I am sorry for that that I cannot understand what you are talking.";
            }

            return websocket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(result)),
                WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private void Flush(HttpListenerRequest req, HttpListenerResponse res, byte[] buffer)
        {
            res.ContentType = "text/plain";

            if (buffer == null || buffer.Length == 0)
            {
                res.Close();
                Logger.Info($"Response {res.StatusCode}: Length=0");
                return;
            }

            var statusCode = res.StatusCode;

            // 接收 gzip 编码
            if (req.Headers != null && req.Headers.Get("Accept-Encoding") != null
                && req.Headers.Get("Accept-Encoding").Contains("gzip"))
            {
                Logger.Info($"Client accepts GZip encoding");

                res.AddHeader("Content-Encoding", "gzip");
                MemoryStream memory = null;
                try
                {
                    memory = new MemoryStream();
                    using (var stream = new GZipStream(memory, CompressionMode.Compress, false))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    buffer = memory.ToArray();
                }
                finally
                {
                    if (memory != null)
                        memory.Dispose();
                }

                Logger.Info("GZip complete");
            }

            var length = res.ContentLength64 = buffer.LongLength;
            res.OutputStream.Write(buffer, 0, (int)length);
            res.OutputStream.Flush();
            res.Close();

            Logger.Info($"Response {statusCode}: Length={length}");
        }
    }
}