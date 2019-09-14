using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ColorWanted.ext;
using ColorWanted.screenshot.events;

namespace ColorWanted.screenshot
{
    partial class ScreenForm
    {
        private ToolStripButton activeToolShapeType;
        private ToolStripButton activeToolColor;
        private ToolStripButton activeToolLineStyle;

        public void BindEditorEvents()
        {
            editor.AreaSelected += Editor_AreaSelected;
            editor.AreaCleared += Editor_AreaCleared;
            editor.Compeleted += Editor_Compeleted;

            new Thread(InitEditorToolbar) { IsBackground = true }.Start();
        }

        public void Show(Bitmap img)
        {
            editor.SetImage(img);

            Refresh();
            Show();
            BringToFront();

            // TopMost = true;
        }

        private void Editor_Compeleted(object sender, DoubleClickEventArgs e)
        {
            // 双击完成时触发
            Clipboard.SetImage(e.Image);
            CloseForm();
        }

        private void Editor_AreaCleared(object sender, EventArgs e)
        {
            // 选区被清除或移动选区时，隐藏工具条
            if (toolbarMask.Visible)
            {
                toolbarMask.Hide();
            }
        }

        private void Editor_AreaSelected(object sender, events.AreaEventArgs e)
        {
            // 这个事件会在创建选区时触发
            if (toolPanel.Visible)
            {
                toolPanel.Hide();
            }

            toolbarMask.Left = e.Rect.X;
            // 2: 边框大小
            toolbarMask.Top = e.Rect.Y + e.Rect.Height + 2;

            if (!toolbarMask.Visible)
            {
                toolbarMask.Show();
            }
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
            Close();
        }

        private void ScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 内存回收
            editor.Reset();

            e.Cancel = true;
            toolbar.Hide();
            toolbarMask.Hide();
            toolPanel.Hide();
            Hide();
        }

        private void ToolMaskEdit_Click(object sender, EventArgs e)
        {
            toolbarMask.Hide();

            toolPanel.Location = toolbarMask.Location;
            toolPanel.Show();
            toolPanel.BringToFront();

            editor.DrawColor = Color.Red.ToMediaColor();
            editor.DrawShape = DrawShapes.Rectangle;
            editor.DrawWidth = 2;
            editor.TextFont = toolText.Font;

            editor.BeginEdit();
        }

        private void HideEdit()
        {
            toolPanel.Hide();

            toolbar.Hide();

            toolbarMask.Show();
            toolbarMask.BringToFront();
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
            if (activeToolShapeType != null)
            {
                activeToolShapeType.Checked = false;
            }
            activeToolShapeType = item;
            item.Checked = true;
            editor.DrawShape = (DrawShapes)Enum.Parse(typeof(DrawShapes), type.ToString());
            if (editor.DrawShape == DrawShapes.Text)
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

        private void ToolOK_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetImage(editor.EndEdit());
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
                var img = editor.EndEdit();
                img.Save(result.FileName);
            }
            CloseForm();
        }

        private void ToolCancel_Click(object sender, System.EventArgs e)
        {
            CloseForm();
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

            Color color = item.BackColor;
            if (item.Tag != null)
            {
                // 选择颜色
                var dialog = new ColorDialog
                {
                    Color = item.BackColor,
                    AllowFullOpen = true
                };

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    color = dialog.Color;
                }
                dialog.Dispose();
            }
            editor.DrawColor = color.ToMediaColor();
            item.BackColor = toolTextStyle.ForeColor = color;
        }

        private void ToolLineWidth_Scroll(object sender, System.EventArgs e)
        {
            editor.DrawWidth = toolLineWidth.Value;
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
            editor.LineStyle = (LineStyles)Enum.Parse(typeof(LineStyles), item.Tag.ToString());
        }

        /// <summary>
        /// 设置文字样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolTextStyle_Click(object sender, EventArgs e)
        {
            var dialog = new FontDialog
            {
                MinSize = 8,
                MaxSize = 64,
                ShowApply = false,
                ShowColor = false,
                ShowEffects = false,
                FontMustExist = true
            };
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                dialog.Dispose();
                return;
            }

            editor.TextFont = toolTextStyle.Font = dialog.Font;
            dialog.Dispose();
        }
    }
}
