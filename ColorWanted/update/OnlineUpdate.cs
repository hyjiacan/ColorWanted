using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ColorWanted.update
{
    /// <summary>
    /// 提供在线更新功能，这是一个静态类
    /// </summary>
    internal static class OnlineUpdate
    {
        /// <summary>
        /// 查询已经发布的tags
        /// </summary>
        private const string url = "https://api.github.com/repos/hyjiacan/ColorWanted/tags";
        /// <summary>
        /// 根据tag的sha1来决定下载地址
        /// </summary>
        private const string link = "https://github.com/hyjiacan/ColorWanted/raw/{0}/ColorWanted/bin/Release/ColorWanted.exe";
        /// <summary>
        /// 向github请求的api版本
        /// </summary>
        private const string accept = "application/vnd.github.v3+json";
        /// <summary>
        /// 没有userAgent时，github不会接收请求
        /// </summary>
        private const string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Maxthon/5.1.0.1400 Chrome/55.0.2883.75 Safari/537.36 ColorWanted/{0}";

        private static readonly JavaScriptSerializer json = new JavaScriptSerializer();

        /// <summary>
        /// 检查更新
        /// </summary>
        /// <returns>没有更新时返回null，检查失败时返回的updateinfo.status=false</returns>
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

                        // 需要找到大于当前版本的tag其中最大的一个
                        TagItem tag = null;
                        var currentVersion = Version.Parse(Application.ProductVersion);

                        foreach (var item in list)
                        {
                            if (tag == null)
                            {
                                if (currentVersion < Version.Parse(item.name))
                                {
                                    tag = item;
                                }
                            }
                            else
                            {
                                if (Version.Parse(tag.name) < Version.Parse(item.name))
                                {
                                    tag = item;
                                }
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

        /// <summary>
        /// 下载更新包并且更新文件
        /// </summary>
        /// <param name="fileurl"></param>
        /// <param name="version"></param>
        /// <param name="callback"></param>
        public static void Update(string fileurl, string version, Func<bool, bool> callback)
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
                    web.DownloadFileAsync(new Uri(fileurl), filename);
                }
            }
            catch
            {
                callback.Invoke(false);
            }
        }

        /*
         * 更新流程说明：
         * 1 下载更新文件，并命名成 ColorWanted-(版本号).tmp.exe)
         * 2 启动新下载的文件，并传入参数 [-update 1 新下载文件的文件完整路径]，程序退出
         * 3 新文件启动后，检查参数列表长度是否>3，并且有 -update 参数
         * 4 若满足，则等待2秒，以确保打开此文件的文件（因为是通过老版本的colorwanted打开新版本）已经关闭
         * 5 若参数为1，则此时运行的是新文件。此时给旧文件添加扩展名 .old ，
         *   备份存放，将新文件名复制为旧文件名
         * 6 此时，旧的文件名所存放的文件就是更新后的新文件，此时再启动旧文件名，
         *   并传入参数 [-update 2 旧文件名]，程序退出
         * 7 此时，会重复步骤3，4，然后删除下载的临时文件，并删除旧文件的备份 (.old 文件)
         * 8 更新完成
         */

        /// <summary>
        /// 处理更新参数
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool HandleUpdateArgs(string[] args)
        {
            // 参数长度至少应该是三个

            if (args.Length < 3)
            {
                return false;
            }

            // 第一个参数  -update 才有效
            if (args[0] != "-update")
            {
                return false;
            }

            // phase 控制更新不同阶段
            var phase = args[1];

            var oldname = args[2];

            if (phase == "1")
            {
                Thread.Sleep(2000);
                // 此时此程序是刚刚下载的新文件
                // 需要将旧文件重命名
                File.Move(oldname, oldname + ".old");

                // 复制新文件。文件名与旧文件相同
                File.Copy(Application.ExecutablePath, oldname);

                // 启动新文件
                Process.Start(oldname, string.Format(@"-update 2 ""{0}""",
                    Application.ExecutablePath));
                return false;
            }

            if (phase == "2")
            {
                Thread.Sleep(2000);
                // 删除临时文件
                File.Delete(oldname);

                // 删除旧文件
                File.Delete(Application.ExecutablePath + ".old");
                return true;
            }

            return false;
        }
    }
}
