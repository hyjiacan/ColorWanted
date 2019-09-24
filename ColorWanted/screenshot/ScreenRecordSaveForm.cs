using ColorWanted.ext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace ColorWanted.screenshot
{
    public partial class ScreenRecordSaveForm : Form
    {
        private static readonly byte[] ApplicationExtention = { 33, 255, 11, 78, 69, 84, 83, 67, 65, 80, 69, 50, 46, 48, 3, 1, 0, 0, 0 };
        public ScreenRecordSaveForm()
        {
            InitializeComponent();
        }

        private static FileStream LoadImage(string file)
        {
            var temp = Path.GetFileNameWithoutExtension(file).Split('#');
            var x = int.Parse(temp[1]);
            var y = int.Parse(temp[2]);

            var stream = new MemoryStream(File.ReadAllBytes(file));

            using (var img = (Bitmap)Image.FromStream(stream))
            {
                if (x >= 0 && img.Width > x && y >= 0 && img.Height > y)
                {
                    DrawCursor(img, x, y, temp[3] == "1");
                }
                // 重新写入磁盘，以减少内存占用
                img.Save(file, ScreenRecordOption.CodecInfo, ScreenRecordOption.EncoderParameters);
                img.Dispose();
            }

            stream.Close();
            stream.Dispose();

            GC.Collect();

            return File.OpenRead(file);
        }

        private static void DrawCursor(Bitmap img, int x, int y, bool mousedown)
        {
            // 光标位置使用反色绘制
            var color = img.GetPixel(x, y);
            var cursorColor = util.ColorUtil.GetContrastColor(color);
            using (var graphics = Graphics.FromImage(img))
            {
                var brush = new SolidBrush(cursorColor);
                if (mousedown)
                {
                    graphics.DrawEllipse(new Pen(cursorColor, 3), x - 3, y - 3, 7, 7);
                    graphics.DrawEllipse(new Pen(cursorColor, 2), x - 7, y - 7, 15, 15);
                    graphics.DrawEllipse(new Pen(cursorColor, 1), x - 9, y - 9, 19, 19);
                }
                else
                {
                    graphics.FillEllipse(brush, x - 2, y - 2, 5, 5);
                }
                graphics.Flush();
                brush.Dispose();
            }
        }

        private static void MakeGIF(string saveTo)
        {
            var files = Directory.GetFiles(ScreenRecordOption.CachePath);

            // 保存每个文件流，以方便在后面关闭文件
            var temp = new List<FileStream>(files.Length);

            var encoder = new GifBitmapEncoder();
            for (int i = 0; i < files.Length; i++)
            {
                var stream = LoadImage(files[i]);
                temp.Add(stream);
                var frame = BitmapFrame.Create(stream);
                encoder.Frames.Add(frame);
            }

            byte[] gifData;
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                encoder.Frames.Clear();
                encoder = null;
                gifData = stream.ToArray();
                stream.Close();
            }

            foreach (var item in temp)
            {
                item.Close();
                item.Dispose();
            }
            temp.Clear();
            temp = null;

            using (FileStream fs = new FileStream(saveTo, FileMode.Create))
            {
                fs.Write(gifData, 0, 13);
                fs.Write(ApplicationExtention, 0, ApplicationExtention.Length);
                fs.Write(gifData, 13, gifData.Length - 13);
                fs.Close();
            }
            gifData = null;
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
