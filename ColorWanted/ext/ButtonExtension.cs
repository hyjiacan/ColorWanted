using System.Reflection;
using System.Windows.Forms;

namespace ColorWanted.ext
{
    internal static class ButtonExtension
    {
        /// <summary>
        /// 禁用按钮点击时的边框
        /// </summary>
        /// <param name="button"></param>
        public static void NoBorder(this Button button)
        {
            button.GetType()
                .GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod)
                .Invoke(button, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null,
                new object[] { ControlStyles.Selectable, false },
                Application.CurrentCulture
            );
        }
    }
}
