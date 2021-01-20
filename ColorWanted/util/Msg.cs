using ColorWanted.setting;
using ColorWanted.viewer;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace ColorWanted.util
{
    /// <summary>
    /// 本机的UDP通信，用于进程间通信
    /// 每次启用时使用一个随机的端口
    /// </summary>
    internal static class Msg
    {
        private static BackgroundWorker worker;
        private static bool running;
        private static UdpClient broadcastClient;
        private static IPEndPoint broadcastEndpoint;

        public static void Send(MsgTypes command, string message = "")
        {
            // 从配置文件读取端口
            int port = Settings.Msg.Port;
            var client = new UdpClient();
            var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            byte[] data = Encoding.UTF8.GetBytes($"{command}#{message}");
            client.Send(data, data.Length, endpoint);
            client.Close();
        }

        public static void Listen()
        {
            running = true;
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        public static void Stop()
        {
            running = false;
        }

        public static void Broadcast(int x, int y, string message)
        {
            if (!Settings.Msg.BroadcastEnabled)
            {
                return;
            }
            if (broadcastClient == null)
            {
                broadcastClient = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
                broadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, Settings.Msg.BroadcastPort);
            }
            if(broadcastEndpoint.Port != Settings.Msg.BroadcastPort)
            {
                broadcastEndpoint.Port = Settings.Msg.BroadcastPort;
            }

            byte[] data = Encoding.UTF8.GetBytes($"Color in RGB#{x}#{y}#{message}");
            broadcastClient.Send(data, data.Length, broadcastEndpoint);
        }

        /// <summary>
        /// 收到消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var buf = (byte[])e.UserState;
            var data = Encoding.UTF8.GetString(buf);
            var temp = data.Split('#');
            if (!Enum.TryParse(temp[0], out MsgTypes type))
            {
                return;
            }
            var message = temp[1];

            if (type == MsgTypes.ShowWindow)
            {
                var form = MainForm.Instance;
                if (!form.Visible)
                {
                    form.Show();
                }
                form.BringToFront();
                return;
            }

            if (type == MsgTypes.ViewImage)
            {
                ShowImage(message);
            }
        }

        private static void ShowImage(string filename)
        {
            ImageViewer.OpenImage(filename);
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var port = GetRandomPort();
            Logger.Info($"Start UDP listener on port {port}");

            Settings.Msg.Port = port;

            UdpClient server = new UdpClient(port);

            IPEndPoint from = new IPEndPoint(IPAddress.Any, 0);

            while (running)
            {
                byte[] buf = server.Receive(ref from);
                worker.ReportProgress(0, buf);
            }

            server.Close();
        }

        public static int GetRandomPort()
        {
            var random = new Random();
            var randomPort = random.Next(10000, 65535);

            var used = IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners();

            while (used.Any(p => p.Port == randomPort))
            {
                randomPort = random.Next(10000, 65535);
            }

            return randomPort;
        }
    }

    internal enum MsgTypes
    {
        ShowWindow = 1,
        ViewImage = 2,
    }
}
