using System;
using System.Windows.Forms;
using ColorWanted.ext;
using ColorWanted.setting;

namespace ColorWanted.theme
{
    internal partial class ThemeForm : Form
    {
        public ThemeForm()
        {
            InitializeComponent();
            ThemeUtil.Apply(this);
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
            Close();
        }

        private void btnThemeDark_Click(object sender, EventArgs e)
        {
            UpdateTheme(btnThemeDark, ThemeType.Dark);
        }

        private void btnThemeLight_Click(object sender, EventArgs e)
        {
            UpdateTheme(btnThemeLight, ThemeType.Light);
        }

        private void btnThemeCustom_Click(object sender, EventArgs e)
        {
            UpdateTheme(btnThemeCustom, ThemeType.Custom);
        }

        private static void UpdateTheme(Button src, ThemeType type)
        {
            var theme = new ThemeDescription
            {
                ForeColor = src.ForeColor,
                BackColor = src.BackColor
            };

            ThemeUtil.SetTheme(theme);

            Settings.Theme.Type = type;

        }

        private void linkFg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            var color = dialog.Color;
            lbFg.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                color.R, color.G, color.B);
            btnThemeCustom.ForeColor = color;
        }

        private void linkBg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            var color = dialog.Color;
            lbBg.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                color.R, color.G, color.B);
            btnThemeCustom.BackColor = color;
        }

        private void ThemeForm_Load(object sender, EventArgs e)
        {
            trOpacity.Value = Settings.Theme.Opacity;

            // 加载自定义颜色
            var theme = ThemeUtil.Get(ThemeType.Custom);

            if (theme.IsEmpty)
            {
                return;
            }

            btnThemeCustom.ForeColor = theme.ForeColor;
            btnThemeCustom.BackColor = theme.BackColor;

            lbFg.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                theme.ForeColor.R, theme.ForeColor.G, theme.ForeColor.B);
            lbBg.Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                theme.BackColor.R, theme.BackColor.G, theme.BackColor.B);
        }

        private void trOpacity_Scroll(object sender, EventArgs e)
        {
            var opacity = trOpacity.Value;
            ThemeUtil.SetOpacity(opacity);
            Settings.Theme.Opacity = opacity;
        }
    }
}
