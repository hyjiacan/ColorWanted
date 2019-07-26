using ColorWanted.ext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace ColorWanted.screenshot
{
    partial class ScreenForm
    {
        /// <summary>
        /// 遮罩图片对象(半透明的图)
        /// </summary>
        private Bitmap opacityImage;
        /// <summary>
        /// 屏幕截图的画布
        /// </summary>
        private Graphics previewGraphics;
        /// <summary>
        /// 选择区域的画布
        /// </summary>
        private Graphics editorGraphics;
        /// <summary>
        /// 标记鼠标是否按下
        /// </summary>
        private bool mousedown;
        /// <summary>
        /// 当前的绘制
        /// </summary>
        private DrawRecord current;
        /// <summary>
        /// 编辑历史
        /// </summary>
        private Stack<DrawRecord> history;
        /// <summary>
        /// 选中的图片区域
        /// </summary>
        private Bitmap selectedImage;

        private PictureBox pictureEditor;

        private TextBox textInput;

        public void Show(Bitmap img)
        {
            history = new Stack<DrawRecord>();
            current = new DrawRecord
            {
                Type = DrawTypes.Rectangle,
                Color = Color.Blue
            };
            image = img;
            picturePreview.BackgroundImage = img;

            previewGraphics = picturePreview.CreateGraphics();

            Refresh();
            Show();
            BringToFront();
        }

        private void ScreenForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CloseForm();
            }
        }

        private void CloseForm()
        {
            image = null;
            mousedown = false;
            current = null;
            Hide();
        }

        private void ScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (editorGraphics != null)
            {
                editorGraphics.Dispose();
            }

            if (previewGraphics != null)
            {
                previewGraphics.Dispose();
            }

            if (opacityImage != null)
            {
                opacityImage.Dispose();
            }
        }

        #region 选区
        private void PicturePreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedImage != null)
            {
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                // 重新选择
                current.Reset();
                picturePreview.Refresh();
                return;
            }

            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (current.HasOffset)
            {
                if (e.Clicks > 1)
                {
                    // 开始编辑
                    ShowEdit();
                }
                return;
            }
            mousedown = true;
            // 刷新后再重绘
            DrawSelectBox();
            current.Start = e.Location;
        }

        private void PicturePreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedImage != null)
            {
                return;
            }
            if (!mousedown || previewGraphics == null || current == null)
            {
                return;
            }
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            current.End = e.Location;
            DrawSelectBox();
            mousedown = false;
        }

        private void PicturePreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedImage != null)
            {
                return;
            }
            if (!mousedown || previewGraphics == null)
            {
                return;
            }
            current.End = e.Location;
            DrawSelectBox();
        }

        private void PicturePreview_MouseLeave(object sender, EventArgs e)
        {
            if (selectedImage != null)
            {
                return;
            }
            mousedown = false;
        }

        private void DrawSelectBox()
        {
            picturePreview.Refresh();
            previewGraphics.Draw(current);
        }

        private void ShowEdit()
        {
            opacityImage = image.AsOpacity(border: current.Copy(-4, -4, 2, 2));
            pictureMask.BackgroundImage = opacityImage;
            pictureMask.Show();
            pictureMask.BringToFront();

            pictureEditor = new PictureBox
            {
                Bounds = current.Rect,
                BackgroundImage = selectedImage = image.Cut(current.Rect)
            };
            pictureEditor.MouseDown += PictureEditor_MouseDown;
            pictureEditor.MouseUp += PictureEditor_MouseUp;
            pictureEditor.MouseMove += PictureEditor_MouseMove;
            pictureEditor.MouseLeave += PictureEditor_MouseLeave;
            pictureEditor.MouseEnter += PictureEditor_MouseEnter;
            Controls.Add(pictureEditor);
            pictureEditor.Show();
            pictureEditor.BringToFront();
            editorGraphics = pictureEditor.CreateGraphics();

            toolbar.Show();
            toolbar.BringToFront();
        }

        private void HideEdit()
        {
            selectedImage.Dispose();
            selectedImage = null;
            toolbar.Hide();
            pictureEditor.Hide();
            editorGraphics = null;
            Controls.Remove(pictureEditor);
            pictureEditor = null;
            opacityImage.Dispose();
            opacityImage = null;
            picturePreview.BringToFront();
        }
        #endregion

        #region 绘制

        private void Redraw()
        {
            pictureEditor.Refresh();
            if (current != null && current.HasOffset)
            {
                editorGraphics.Draw(current);
            }
            foreach (var record in history)
            {
                editorGraphics.Draw(record);
            }
        }

        private void PictureEditor_MouseDown(object sender, MouseEventArgs e)
        {
            // 点击右键时就撤销编辑
            // 一直撤销到没有历史
            // 然后可以重新选择截图区域
            if (e.Button == MouseButtons.Right)
            {
                if (current != null && current.Type == DrawTypes.Text)
                {
                    HideTextInput();
                    return;
                }
                if (history.Count > 0)
                {
                    history.Pop();
                    Redraw();
                }
                else
                {
                    HideEdit();
                }
                return;
            }

            // 输入文字
            if (current != null && current.Type == DrawTypes.Text)
            {
                current.Start = e.Location;
                ShowTextInput(e.Location);
                return;
            }

            current.Start = e.Location;
            mousedown = true;
            return;
        }

        private void PictureEditor_MouseEnter(object sender, System.EventArgs e)
        {

        }

        private void PictureEditor_MouseLeave(object sender, System.EventArgs e)
        {

        }

        private void PictureEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mousedown)
            {
                return;
            }
            current.End = e.Location;
            Redraw();
        }

        private void PictureEditor_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mousedown || e.Button != MouseButtons.Left)
            {
                return;
            }
            current.End = e.Location;
            Redraw();
            history.Push(current);
            current = current.Copy();
            current.Reset();
            mousedown = false;
        }

        private void Toolbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!(e.ClickedItem is ToolStripButton item))
            {
                return;
            }
            var type = item.Tag;
            if (type == null)
            {
                // 为空表示绘制类型按钮
                return;
            }
            ((ToolStripButton)toolbar.Items.Find($"tool{current.Type.ToString()}", false)[0]).Checked = false;
            item.Checked = true;
            current.Type = (DrawTypes)Enum.Parse(typeof(DrawTypes), type.ToString());
        }

        private Bitmap GetResult()
        {
            var result = selectedImage ?? image;
            var g = Graphics.FromImage(result);
            foreach (var item in history)
            {
                g.Draw(item);
            }
            g.Flush();
            return result;
        }

        private void ToolOK_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetImage(GetResult());
            CloseForm();
        }

        private void ToolSave_Click(object sender, System.EventArgs e)
        {
            var result = new SaveFileDialog();
            if (result.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var img = GetResult();
            img.Save(result.FileName);
            CloseForm();
        }

        private void ToolCancel_Click(object sender, System.EventArgs e)
        {
            CloseForm();
        }

        private void ShowTextInput(Point location)
        {
            if (textInput == null)
            {
                textInput = new TextBox
                {
                    Width = 200,
                    Height = 60,
                    Multiline = true,
                    BorderStyle = BorderStyle.None
                };
                textInput.KeyDown += (sender, e) =>
                {
                    // 按ESC取消输入
                    if (e.KeyCode == Keys.Escape)
                    {
                        e.Handled = true;
                        HideTextInput();
                        return;
                    }
                    // 按回车完成输入
                    if (e.KeyCode == Keys.Enter)
                    {
                        current.Text = textInput.Text;
                        history.Push(current);
                        current = current.Copy();
                        current.Reset();
                        HideTextInput();
                        Redraw();
                    }
                };
                Controls.Add(textInput);
            }
            textInput.Text = string.Empty;
            textInput.Location = new Point(pictureEditor.Location.X + location.X,
                pictureEditor.Location.Y + location.Y);
            textInput.Show();
            textInput.BringToFront();
            textInput.Focus();
        }
        private void HideTextInput()
        {
            if (textInput != null)
            {
                textInput.Hide();
            }
        }
        #endregion
    }
}
