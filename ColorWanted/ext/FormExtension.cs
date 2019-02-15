using ColorWanted.util;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ColorWanted.ext
{
    /// <summary>
    /// 窗体功能扩展
    /// </summary>
    public static class FormExtension
    {
        public delegate void FormInvoker();

        public static void InvokeMethod(this Form form, FormInvoker invoker)
        {
            if (form.IsDisposed)
            {
                return;
            }
            try
            {
                if (form.InvokeRequired)
                {
                    form.Invoke(new MethodInvoker(invoker));
                }
                else
                {
                    invoker.Invoke();
                }
            }
            catch (ObjectDisposedException)
            {
                // ignore
            }
        }

        /// <summary>
        /// 窗口渐入效果
        /// </summary>
        public static void SlideIn(this Form form, Action callback)
        {
            form.Show();
            form.BringToFront();
            new Thread(() =>
            {
                var step = 8;
                var offset = 0;
                while (offset < form.Width)
                {
                    var step1 = step;
                    form.InvokeMethod(() =>
                    {
                        form.Left -= step1;
                        Application.DoEvents();
                    });
                    offset += step1;
                    step = (int)(step * 1.2);
                    Thread.Sleep(50);
                }
                if (callback != null)
                {
                    callback.Invoke();
                }
            })
            { IsBackground = true }.Start();
        }

        public static void SlideOut(this Form form)
        {
            new Thread(() =>
            {
                var step = 8;
                while (form.Width > 0)
                {
                    var step1 = step;
                    form.InvokeMethod(() =>
                    {
                        form.Width -= step1;
                        form.Left += step1;
                    });
                    step = (int)(step * 1.2);
                    Thread.Sleep(50);
                }
                form.InvokeMethod(() =>
                {
                    form.Width = 0;
                    form.Left = Util.GetScreenSize().Width;
                });
            })
            { IsBackground = true }.Start();
        }

    }
}
