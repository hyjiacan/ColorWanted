using System;
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
    }
}
