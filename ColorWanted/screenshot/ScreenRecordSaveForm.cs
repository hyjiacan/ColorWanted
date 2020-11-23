using AnimatedGif;
using ColorWanted.ext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    public partial class ScreenRecordSaveForm : Form
    {
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
                img.Save(file);
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

        private void MakeGIF(string saveTo, Action<int, int> callback)
        {
            var files = Directory.GetFiles(ScreenRecordOption.CachePath);

            // 保存每个文件流，以方便在后面关闭文件
            var temp = new List<FileStream>(files.Length);

            int qualityValue = 3;
            this.InvokeMethod(() =>
            {
                qualityValue = tbQuality.Value;
            });
            GifQuality quality;
            switch (qualityValue)
            {
                case 1:
                    quality = GifQuality.Grayscale;
                    break;
                case 2:
                    quality = GifQuality.Bit4;
                    break;
                case 3:
                    quality = GifQuality.Bit8;
                    break;
                default:
                    quality = GifQuality.Default;
                    break;
            }
            var gifStream = new FileStream(saveTo, FileMode.Create);
            var gif = new AnimatedGifCreator(gifStream,
                1000 / ScreenRecordOption.Fps, (int)numRepeatCount.Value);

            for (int i = 0; i < files.Length; i++)
            {
                callback(i, files.Length);
                var stream = LoadImage(files[i]);
                temp.Add(stream);
                gif.AddFrame(Image.FromStream(stream), quality: quality);
            }
            callback(files.Length, files.Length);
            gif.Dispose();

            foreach (var item in temp)
            {
                item.Close();
                item.Dispose();
            }
            temp.Clear();

            GC.Collect();
        }

        private void ScreenRecordSaveForm_Load(object sender, EventArgs e)
        {
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var filename = ScreenShot.SaveRecord();
            if (filename == null)
            {
                return;
            }

            btnOk.Enabled = false;
            tbQuality.Enabled = false;
            this.UseWaitCursor = true;
            lbMsg.Text = "正在生成GIF文件...";
            lbMsg.Visible = true;
            new System.Threading.Thread(() =>
            {
                try
                {
                    MakeGIF(filename, (value, total) =>
                    {
                        this.InvokeMethod(() =>
                        {
                            lbMsg.Text = "正在生成GIF文件... (" + (value * 1f / total).ToString("P") + ")";
                        });
                    });

                    this.InvokeMethod(() =>
                    {
                        lbMsg.Text = "生成GIF文件完成";
                    });
                }
                catch (Exception ex)
                {
                    util.Logger.Warn(ex);
                    this.InvokeMethod(() =>
                    {
                        lbMsg.Text = "生成GIF文件出错";
                    });
                    MessageBox.Show(ex.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.InvokeMethod(() =>
                {
                    this.UseWaitCursor = false;
                    btnOk.Enabled = true;
                    tbQuality.Enabled = true;
                });
            })
            { IsBackground = true }.Start();
        }
    }
}
