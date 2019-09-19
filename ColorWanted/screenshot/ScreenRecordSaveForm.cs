using ColorWanted.ext;
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace ColorWanted.screenshot
{
    public partial class ScreenRecordSaveForm : Form
    {
        public ScreenRecordSaveForm()
        {
            InitializeComponent();
        }

        private static void MakeGIF(string saveTo)
        {
            var files = Directory.GetFiles(ScreenRecordOption.CachePath);

            var encoder = new GifBitmapEncoder();
            for (int i = 0; i < files.Length; i++)
            {
                var frame = BitmapFrame.Create(new MemoryStream(File.ReadAllBytes(files[i])));
                encoder.Frames.Add(frame);
            }

            byte[] GifData;
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                GifData = ms.ToArray();
                ms.Close();
            }

            byte[] ApplicationExtention = { 33, 255, 11, 78, 69, 84, 83, 67, 65, 80, 69, 50, 46, 48, 3, 1, 0, 0, 0 };

            using (FileStream fs = new FileStream(saveTo, FileMode.Create))
            {
                fs.Write(GifData, 0, 13);
                fs.Write(ApplicationExtention, 0, ApplicationExtention.Length);
                fs.Write(GifData, 13, GifData.Length - 13);
                fs.Close();
            }
            GC.Collect();
        }

        private void ScreenRecordSaveForm_Load(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "gif",
                FileName = string.Format("record-{0:yyyyMMddHHmmss}.gif", DateTime.Now)
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                dialog.Dispose();
                Close();
                return;
            }
            var filename = dialog.FileName;
            dialog.Dispose();

            new System.Threading.Thread(() =>
            {
                MakeGIF(filename);
                this.InvokeMethod(() =>
                {
                    Close();
                });
            })
            { IsBackground = true }.Start();
        }
    }
}
