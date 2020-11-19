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
        public delegate void MethodInvoker();

        public static void InvokeMethod(this Control control, MethodInvoker invoker)
        {
            if (control.IsDisposed)
            {
                return;
            }
            // fix #3 #4
            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new MethodInvoker(invoker));
                }
                else
                {
                    invoker.Invoke();
                }
            }
            catch (ThreadAbortException)
            {
                // ignore
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
            if (!form.Visible)
            {
                form.Show();
            }
            form.BringToFront();
            new Thread(() =>
            {
                var step = 8;
                var offset = 0;
                var left = Util.GetScreenSize(true).Width;
                // fix #3 #4
                try
                {
                    while (offset < form.Width)
                    {
                        var step1 = step;
                        form.InvokeMethod(() =>
                        {
                            form.Left = left - step1;
                            Application.DoEvents();
                        });
                        offset += step1;
                        step = (int)(step * 1.5);
                        Thread.Sleep(50);
                    }
                    form.InvokeMethod(() =>
                    {
                        form.Left = left - form.Width;
                    });
                }
                catch (ThreadAbortException)
                {
                    // ignore
                }
                catch (ObjectDisposedException)
                {
                    // ignore
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
                var left = Util.GetScreenSize().Width;
                var width = form.Width;
                // fix #3 #4
                try
                {
                    var offset = 0;
                    while (left - offset < width)
                    {
                        var step1 = step;
                        form.InvokeMethod(() =>
                        {
                            form.Left = left + step1;
                        });
                        offset += step1;
                        step = (int)(step * 1.5);
                        Thread.Sleep(50);
                    }
                    form.InvokeMethod(() =>
                    {
                        form.Left = left;
                        form.Hide();
                    });
                }
                catch (ThreadAbortException)
                {
                    // ignore
                }
                catch (ObjectDisposedException)
                {
                    // ignore
                }
            })
            { IsBackground = true }.Start();
        }

    }
}
