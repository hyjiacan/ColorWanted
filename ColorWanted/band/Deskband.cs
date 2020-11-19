using ColorWanted.util;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ColorWanted.band
{
    [ComVisible(true)]
    [Guid("93bc08bf-d1e3-4c3e-a72d-81651996e10b")]
    [CSDeskBand.CSDeskBandRegistration(Name = "ColorWanted", ShowDeskBand = false)]
    public class Deskband : CSDeskBand.CSDeskBandWin
    {
        private Control control;
        protected override Control Control => control;

        public Deskband()
        {
            var height = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;

            var size = new Size(Util.ScaleX(80), height);
            Options.MinHorizontalSize = size;
            control = new DesktopBandControl
            {
                Left = 0,
                Top = 0,
                Size = size,
                BackColor = Color.Red
            };
            control.Show();
        }

        protected override void DeskbandOnClosed()
        {
            control.Hide();
            base.DeskbandOnClosed();
        }
    }
}
