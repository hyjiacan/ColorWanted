using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ColorWanted.util
{
    internal static class Http
    {
        /// <summary>
        /// 向github请求的api版本
        /// </summary>
        private const string accept = "application/vnd.github.v3+json";

        /// <summary>
        /// 没有userAgent时，github不会接收请求
        /// </summary>
        private const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.75 Safari/537.36 ColorWanted/{0}";

        /// <summary>
        /// 发送get请求
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string Get(string uri)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;

            var req = WebRequest.Create(uri) as HttpWebRequest;
            if (req == null)
            {
                Logger.Warn($"Cannot create request to {uri}");
                return null;
            }
            req.Accept = accept;
            req.Method = "GET";
            req.UserAgent = string.Format(userAgent, Application.ProductVersion);
            req.KeepAlive = false;

            Logger.Info($"Request {uri}");
            using (var res = req.GetResponse())
            {
                var responseStream = res.GetResponseStream();
                if (responseStream == null)
                {
                    Logger.Warn("Empty response");
                    return null;
                }
                using (var stream = new StreamReader(responseStream))
                {
                    return stream.ReadToEnd();
                }
            }
        }
    }
}
