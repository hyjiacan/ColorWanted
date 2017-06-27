using ColorWanted.ext;
using ColorWanted.util;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ColorWanted.hotkey
{
    internal partial class HotkeyForm : Form
    {
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
        }

        private void HotkeyForm_Load(object sender, EventArgs e)
        {
            // 取消快捷键的注册
            HotKey.Unbind();

            new Thread(() =>
            {
                Invoke(new MethodInvoker(() =>
                {
                    panel.Controls.AddRange(Util.Enum<HotKeyType>()
                        .Select(type =>
                            {
                                var hotkey = HotKey.Get(type);

                                var ctrl = new HotkeyCtrl(hotkey)
                                {
                                    Width = 480
                                };

                                ctrl.OnHotkeyChanged += HotkeyChanged;

                                return (Control)ctrl;
                            }
                        ).ToArray());
                    lbMsg.Text = "加载完成";
                }));
            }).Start();
        }


        private void HotkeyChanged(HotKey hotkey)
        {
            lbMsg.Text = "设置成功";
        }

        private void lkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (HotkeyCtrl ctrl in panel.Controls)
            {
                ctrl.Reset();
            }
        }
    }
}
