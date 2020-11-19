using ColorWanted.ext;
using ColorWanted.util;
using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted.band
{
    class DesktopBandControl : UserControl
    {
        //private Form main;
        private Timer timer;
        private Label label;
        public DesktopBandControl()
        {
            //main = Application.OpenForms["MainForm"] ?? new MainForm();
            timer = new Timer
            {
                Interval = 100
            };
            timer.Tick += Timer_Tick;
            label = new Label
            {
                Left = 0,
                Top = 0,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(label);
            this.VisibleChanged += DesktopBandControl_VisibleChanged;
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            var color = ColorUtil.GetColor(MousePosition);
            var colorStr = string.Format("{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
            label.InvokeMethod(() =>
            {
                label.Text = colorStr;
            });
        }

        private void DesktopBandControl_VisibleChanged(object sender, System.EventArgs e)
        {
            timer.Enabled = Visible;
            //if (Visible)
            //{
            //    Width = main.Width;
            //    Controls.Add(main);
            //}
            //else
            //{
            //    Controls.Remove(main);
            //}
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if ((Keys)m.WParam == Keys.Tab)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
                return true;
            }

            return base.ProcessKeyPreview(ref m);
        }
    }
}
