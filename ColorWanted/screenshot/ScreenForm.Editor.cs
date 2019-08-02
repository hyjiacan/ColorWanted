using ColorWanted.ext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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
        /// <summary>
        /// 编辑区域
        /// </summary>
        private PictureBox pictureEditor;
        /// <summary>
        /// 文字输入
        /// </summary>
        private TextBox textInput;
        private ToolStripButton activeToolShapeType;
        private ToolStripButton activeToolColor;
        private ToolStripButton activeToolLineStyle;
        private int screenWidth;
        private int screenHeight;

        public void Show(Bitmap img, int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            history = new Stack<DrawRecord>();
            current = new DrawRecord
            {
                Type = DrawTypes.Rectangle,
                Color = Color.Blue,
                //// 默认的全屏选区
                //Start = new Point(0, 0),
                //End = new Point(screenWidth - 1, screenHeight - 1)
            };
            image = img;
            picturePreview.BackgroundImage = img.AsOpacity(0.7f);
            previewGraphics = picturePreview.CreateGraphics();

            new Thread(InitEditorToolbar) { IsBackground = true }.Start();

            Refresh();
            Show();
            BringToFront();
            TopMost = false;
        }

        /// <summary>
        /// 初始化编辑器的工具条
        /// </summary>
        private void InitEditorToolbar()
        {
            activeToolShapeType = toolRectangle;
            activeToolColor = toolColorRed;
            activeToolLineStyle = toolStyleSolid;

            // 字体
            toolTextStyle.ForeColor = activeToolColor.BackColor;
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
            Close();
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

        private Point GetToolbarLocation(Control toolbar)
        {
            var location = new Point(current.End.X - toolbarMask.Width, current.End.Y + 2);
            if (location.X < 0)
            {
                location.X = 0;
            }
            if (location.X + toolbar.Width > screenWidth)
            {
                location.X = screenWidth - toolbar.Width;
            }
            if (location.Y < 0)
            {
                location.Y = 0;
            }
            if (location.Y + toolbar.Height > screenHeight)
            {
                location.Y = screenHeight - toolbar.Height;
            }
            return location;
        }

        #region 选区
        private void ToolMaskEdit_Click(object sender, System.EventArgs e)
        {
            ShowEdit();
        }
        private void PicturePreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 重新选择
                toolbarMask.Hide();
                current.Reset();
                picturePreview.Refresh();
                return;
            }

            if (e.Button != MouseButtons.Left)
            {
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

            if (current.HasOffset)
            {
                // 开始编辑
                ShowMask();
            }
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

        private void ShowMask()
        {
            var rect = current.Copy();
            rect.Width = 2;
            opacityImage = image.AsOpacity(border: rect);
            pictureMask.BackgroundImage = opacityImage;
            pictureMask.Show();
            pictureMask.BringToFront();

            pictureEditor = new PictureBox
            {
                Bounds = current.Rect,
                BackgroundImage = selectedImage = image.Cut(current.Rect)
            };

            // 处理闪烁问题
            pictureEditor.EnableDoubleBuffered();

            pictureEditor.MouseDown += PictureEditor_MouseDown;
            pictureEditor.MouseUp += PictureEditor_MouseUp;
            pictureEditor.MouseMove += PictureEditor_MouseMove;
            pictureEditor.MouseLeave += PictureEditor_MouseLeave;
            pictureEditor.MouseEnter += PictureEditor_MouseEnter;
            Controls.Add(pictureEditor);
            pictureEditor.Show();
            pictureEditor.BringToFront();
            editorGraphics = pictureEditor.CreateGraphics();

            toolbarMask.Location = GetToolbarLocation(toolbarMask);
            toolbarMask.Show();
            toolbarMask.BringToFront();
        }

        private void ShowEdit()
        {
            toolbarMask.Hide();

            toolPanel.Location = GetToolbarLocation(toolPanel);
            toolPanel.Show();
            toolPanel.BringToFront();
        }

        private void HideEdit()
        {
            current.Reset();
            current.Type = DrawTypes.Rectangle;

            toolPanel.Hide();

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

            toolbarMask.Show();
            toolbarMask.BringToFront();
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
                if (textInput != null && textInput.Visible)
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
                    current.Reset();
                    HideEdit();
                }
                return;
            }

            if (!toolPanel.Visible)
            {
                // 此时双击就直接复制
                if (e.Clicks > 1)
                {
                    ToolOK_Click(null, null);
                    return;
                }
                return;
            }

            // 输入文字
            if (current != null && current.Type == DrawTypes.Text)
            {
                CommitTextInput();
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
            if (!toolPanel.Visible)
            {
                return;
            }
            if (!mousedown)
            {
                return;
            }
            current.End = e.Location;
            Redraw();
        }

        private void PictureEditor_MouseUp(object sender, MouseEventArgs e)
        {
            if (!toolPanel.Visible)
            {
                return;
            }
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
            HideTextInput();
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
            if (activeToolShapeType != null)
            {
                activeToolShapeType.Checked = false;
            }
            activeToolShapeType = item;
            item.Checked = true;
            current.Type = (DrawTypes)Enum.Parse(typeof(DrawTypes), type.ToString());
            if (current.Type == DrawTypes.Text)
            {
                toolbarLineType.Hide();
                toolLineWidth.Hide();
                toolbarTextStyle.Show();
            }
            else
            {
                toolbarTextStyle.Hide();
                toolbarLineType.Show();
                toolLineWidth.Show();
            }
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
            using (var result = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = ".png"
            })
            {
                if (result.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                var img = GetResult();
                img.Save(result.FileName);
            }
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
                    BorderStyle = BorderStyle.None,
                    ForeColor = current.Color,
                    Font = toolTextStyle.Font,
                    //AcceptsReturn = true
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
                        CommitTextInput();
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
                Redraw();
            }
        }

        private void ToolbarColor_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = (ToolStripButton)e.ClickedItem;

            if (activeToolColor != null)
            {
                activeToolColor.Checked = false;
            }
            activeToolColor = item;
            item.Checked = true;
            if (item.Tag == null)
            {
                current.Color = item.BackColor;
            }
            else
            {
                // 选择颜色
                var dialog = new ColorDialog
                {
                    Color = item.BackColor,
                    AllowFullOpen = true
                };

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    current.Color = dialog.Color;
                }
                dialog.Dispose();
            }
            toolTextStyle.ForeColor = item.BackColor = current.Color;
            item.ForeColor = util.ColorUtil.GetContrastColor(current.Color);
        }

        private void ToolLineWidth_Scroll(object sender, System.EventArgs e)
        {
            current.Width = toolLineWidth.Value;
        }

        private void ToolbarLineType_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = (ToolStripButton)e.ClickedItem;

            if (activeToolLineStyle != null)
            {
                activeToolLineStyle.Checked = false;
            }
            activeToolLineStyle = item;
            item.Checked = true;
            current.LineStyle = (LineStyles)Enum.Parse(typeof(LineStyles), item.Tag.ToString());
        }

        /// <summary>
        /// 设置文字样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolTextStyle_Click(object sender, System.EventArgs e)
        {
            var dialog = new FontDialog
            {
                MinSize = 8,
                MaxSize = 16,
                ShowApply = false,
                ShowColor = false,
                ShowEffects = true,
                FontMustExist = true
            };
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            current.TextFont = toolTextStyle.Font = dialog.Font;
        }

        private void CommitTextInput()
        {
            if (textInput == null || string.IsNullOrWhiteSpace(textInput.Text))
            {
                return;
            }
            var text = textInput.Text.Trim();
            current.Text = text;
            history.Push(current);
            current = current.Copy();
            current.Reset();
            HideTextInput();
            Redraw();
        }
        #endregion
    }
}
