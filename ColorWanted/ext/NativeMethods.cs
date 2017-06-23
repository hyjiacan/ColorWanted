using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ColorWanted.hotkey;

/**
* winapi与头文件参考：
* 
* user32.dll   WinUser.h
* gdi32.dll    WinGDI.h
* kernel32.dll WinBase.h
*/

namespace ColorWanted.ext
{
    /// <summary>
    /// Win API 接口
    /// </summary>
    internal class NativeMethods
    {
        #region 屏幕取色

        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateDC(string driverName, string deviceName, string output, IntPtr lpinitData);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr DC);

        #endregion

        #region 全局快捷键

        //如果函数执行成功，返回值不为0。
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄
            int id,                     //定义热键ID（不能与其它ID重复）           
            KeyModifier fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
            Keys vk                     //定义热键的内容
            );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄
            int id                      //要取消热键的ID
            );
        #endregion

        #region 在窗体任意位置拖动窗体

        // 这几个常量定义在 winuser.h 中
        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint SC_MOVE = 0xF010;
        public const uint HTCAPTION = 0x0002;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint wMsg, IntPtr wParam, IntPtr lParam);
        #endregion

        #region INI 文件读写
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString", CharSet = CharSet.Unicode)]
        public static extern bool WriteIni(string section, string key, string val, string filePath);

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString", CharSet = CharSet.Unicode)]
        public static extern bool ReadIni(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        #endregion

        #region 剪贴板操作

        [DllImport("user32.dll")]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll")]
        public static extern bool EmptyClipboard();
        [DllImport("user32.dll")]
        public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        [DllImport("user32.dll")]
        public static extern bool CloseClipboard();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalAlloc(uint uFlags, int dwBytes);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalLock(IntPtr hMem);
        [DllImport("kernel32.dll")]
        public static extern bool GlobalUnlock(IntPtr hMem);

        #endregion
    }
}
