using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ColorWanted.update
{
    class OnlineUpdate
    {
        private const string url = "https://api.github.com/repos/hyjiacan/ColorWanted/tags";
        private const string link = "https://github.com/hyjiacan/ColorWanted/raw/{0}/ColorWanted/bin/Release/ColorWanted.exe";
        private const string accept = "application/vnd.github.v3+json";
        private const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Maxthon/5.1.0.1400 Chrome/55.0.2883.75 Safari/537.36 ColorWanted/{0}";

        private static readonly JavaScriptSerializer json = new JavaScriptSerializer();

        public static UpdateInfo Check()
        {
            var info = new UpdateInfo();

            try
            {
                var req = WebRequest.Create(url) as HttpWebRequest;

                if (req == null)
                {
                    return info;
                }

                req.Accept = accept;
                req.Method = "GET";
                req.UserAgent = string.Format(userAgent, Application.ProductVersion);
                req.KeepAlive = false;
                using (var res = req.GetResponse())
                {
                    var responseStream = res.GetResponseStream();
                    if (responseStream == null)
                    {
                        return info;
                    }
                    using (var stream = new StreamReader(responseStream))
                    {
                        var data = stream.ReadToEnd();
                        var list = json.Deserialize<List<TagItem>>(data);

                        TagItem tag = null;
                        var currentVersion = Version.Parse(Application.ProductVersion);

                        foreach (var item in list)
                        {
                            if (currentVersion < Version.Parse(item.name))
                            {
                                tag = item;
                            }
                        }

                        if (tag == null)
                        {
                            return null;
                        }

                        info.Status = true;
                        info.Version = tag.name;
                        info.Link = string.Format(link, tag.commit.sha);

                        return info;
                    }
                }
            }
            catch
            {
                return info;
            }
        }

        public static void Update(string url, string version, Func<bool, bool> callback)
        {
            var filename = Path.Combine(Application.StartupPath,
                string.Format("ColorWanted-{0}.tmp.exe", version));

            try
            {
                using (var web = new WebClient())
                {
                    web.DownloadFileCompleted += (sender, e) =>
                    {
                        callback.Invoke(true);

                        Process.Start(filename, string.Format(@"-update 1 ""{0}""", Application.ExecutablePath));

                        Application.Exit();
                    };
                    web.DownloadFileAsync(new Uri(url), filename);
                }
            }
            catch
            {
                callback.Invoke(false);
            }
        }
    }
}
