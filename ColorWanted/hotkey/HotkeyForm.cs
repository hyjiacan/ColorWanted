using ColorWanted.ext;
using ColorWanted.util;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
            if (list.SelectedItems.Count == 0)
            {
                return;
            }
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

            KeyModifier? modifiers = null;

            if (e.Control)
            {
                buffer.Append("Ctrl + ");
                modifiers = KeyModifier.Ctrl;
            }
            if (e.Alt)
            {
                buffer.Append("Alt + ");

                if (modifiers == null)
                {
                    modifiers = KeyModifier.Alt;
                }
                else
                {
                    modifiers |= KeyModifier.Alt;
                }
            }
            if (e.Shift)
            {
                buffer.Append("Shift + ");
                if (modifiers == null)
                {
                    modifiers = KeyModifier.Shift;
                }
                else
                {
                    modifiers |= KeyModifier.Shift;
                }
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
            else if (e.KeyCode == Keys.Oemtilde)
            {
                buffer.Append("`");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                buffer.Append("Enter");
            }

            tbInput.Text = buffer.ToString();
            if (modifiers == null)
            {
                return;
            }

            var attr = tbInput.Tag as HotKey;
            // ReSharper disable once PossibleNullReferenceException
            attr.Modifiers = modifiers.Value;
            attr.Key = e.KeyCode;
        }

        private void tbInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (list.SelectedItems.Count == 0)
            {
                return;
            }
            var str = tbInput.Text.TrimEnd();
            var len = str.Length;
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
                                var attr = HotKey.Get(hotkey);
                                return new ListViewItem(attr.ToFullString())
                                {
                                    Tag = attr
                                };
                            }
                        ).ToArray());
                    lbMsg.Text = "加载完成";
                }));
            }).Start();
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMsg.Text = "";
            var select = list.SelectedItems;
            if (select.Count == 0)
            {
                tbInput.Tag = null;
                tbInput.Text = "";
                return;
            }
            var attr = select[0].Tag as HotKey;
            tbInput.Tag = attr;
            // ReSharper disable once PossibleNullReferenceException
            tbInput.Text = attr.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbInput.Tag == null || tbInput.Text == "")
            {
                return;
            }
            var hotkey = tbInput.Tag as HotKey;
            HotKey.Set(hotkey);
            // 更新显示
            var select = list.SelectedItems;
            if (select.Count == 0)
            {
                tbInput.Tag = null;
                tbInput.Text = "";
                return;
            }
            // ReSharper disable once PossibleNullReferenceException
            select[0].Text = hotkey.ToFullString();

            lbMsg.Text = "设置完成";
        }
    }
}
