using ColorWanted.ext;
using ColorWanted.util;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ColorWanted.enums;

namespace ColorWanted.hotkey
{
    internal partial class HotkeyForm : Form
    {
        private StringBuilder buffer;
        public HotkeyForm()
        {
            InitializeComponent();
        }

        private void MouseDownEventHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_SYSCOMMAND,
                    new IntPtr(NativeMethods.SC_MOVE + NativeMethods.HTCAPTION), IntPtr.Zero);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            HotKey.Bind();
            Close();
            Dispose();
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            // 删除键，清空快捷键
            if (e.KeyValue == 8)
            {
                tbInput.Clear();
                return;
            }
            if (e.Modifiers == 0)
            {
                return;
            }

            if (buffer == null)
            {
                buffer = new StringBuilder(32);
            }
            else
            {
                buffer.Clear();
            }

            if (e.Control)
            {
                buffer.Append("Ctrl + ");
            }
            if (e.Alt)
            {
                buffer.Append("Alt + ");
            }
            if (e.Shift)
            {
                buffer.Append("Shift + ");
            }
            if (e.KeyValue >= 33 && e.KeyValue <= 40 ||
                e.KeyValue >= 65 && e.KeyValue <= 90 ||   //a-z/A-Z
                e.KeyValue >= 112 && e.KeyValue <= 123)   //F1-F12
            {
                buffer.Append(e.KeyCode);
            }
            else if (e.KeyValue >= 48 && e.KeyValue <= 57)    //0-9
            {
                buffer.Append(e.KeyCode.ToString().Substring(1));
            }

            tbInput.Text = buffer.ToString();
        }

        private void tbInput_KeyUp(object sender, KeyEventArgs e)
        {
            string str = tbInput.Text.TrimEnd();
            int len = str.Length;
            if (len >= 1 && str.Substring(str.Length - 1) == "+")
            {
                tbInput.Text = "";
            }
        }

        private void HotkeyForm_Load(object sender, EventArgs e)
        {
            // 取消快捷键的注册
            HotKey.Unbind();

            new Thread(() =>
            {
                Invoke(new MethodInvoker(() =>
                {
                    list.Items.AddRange(Util.Enum<HotKeyType>()
                        .Select(hotkey =>
                            {
                                var attr = hotkey.GetAttribute();
                                return new ListViewItem(attr.Name)
                                {
                                    Tag = attr
                                };
                            }
                        ).ToArray());
                }));
            }).Start();
        }
    }
}
