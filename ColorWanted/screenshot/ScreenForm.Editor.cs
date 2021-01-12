using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ColorWanted.ext;
using ColorWanted.hotkey;
using ColorWanted.screenshot.events;
using ColorWanted.util;

namespace ColorWanted.screenshot
{
    partial class ScreenForm
    {
        private ToolStripButton activeToolShapeType;
        private ToolStripButton activeToolColor;
        private ToolStripButton activeToolLineStyle;
        private ToolStripButton activeToolDrawMode;
        private const int HOTKEY_ID_BASE = 0xF10000;

        public void BindEditorEvents()
        {
            editor.AreaSelected += Editor_AreaSelected;
            editor.AreaCleared += Editor_AreaCleared;
            editor.Compeleted += Editor_Compeleted;
            editor.HistoryChange += Editor_HistoryChange;
        }

        private void Editor_HistoryChange(object sender, HistoryEventArgs e)
        {
            toolUndo.Enabled = e.HistoryCount > 0;
            toolRedo.Enabled = e.RedoHistoryCount > 0;
        }

        public void ShowWindow()
        {
            this.ShowInTaskbar = false;
            Show();
            BringToFront();
            TopMost = true;

            BindHotKeys();

            new Thread(InitEditorToolbar) { IsBackground = true }.Start();
        }

        public void SetImage(Bitmap img)
        {
            this.InvokeMethod(() =>
            {
                editor.SetImage(img);

                Refresh();
            });
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

        private void Editor_AreaSelected(object sender, AreaEventArgs e)
        {
            //TopMost = false;
            //this.ShowInTaskbar = true;
            // 这个事件会在创建选区时触发
            if (toolPanel.Visible)
            {
                toolPanel.Hide();
            }
            FixToolbarPosition(e.Rect, toolbarMask);

            if (!toolbarMask.Visible)
            {
                toolbarMask.Show();
            }
        }

        private void FixToolbarPosition(Rectangle rect, Control tb)
        {
            var w = rect.Width;
            var h = rect.Height;
            var x = rect.X;
            var y = rect.Y;

            // 默认放在右下角
            var left = x + w - tb.Width;
            var top = y + h + 2;

            var size = this.Size;

            // 如果下方高度不合适，放到右侧
            if (top + tb.Height > size.Height)
            {
                top -= tb.Height + 2;
                left += 2;
            }

            // 如果右侧宽度不合适，放到上方
            if (left + tb.Width > size.Width)
            {
                top = y - tb.Height - 2;
                left = x + w - tb.Width;
            }

            // 如果上方宽度不合适，放到左侧
            if (top < 0)
            {
                top = y + h - tb.Height;
                left = x - tb.Width - 2;
            }

            if (left < 0)
            {
                // 放到内部（右下角）
                top = y + h - tb.Height - 2;
                left = x + w - tb.Width - 2;
            }

            tb.Left = Util.ScaleX(left);
            // 2: 边框大小
            tb.Top = Util.ScaleY(top);
        }

        /// <summary>
        /// 重置按钮状态
        /// </summary>
        private void ResetEditorToolbar()
        {
            var buttons = toolPanel.Controls.OfType<ToolStrip>()
                .Where(control => control != null)
                .SelectMany(toolstrip => toolstrip.Items.OfType<ToolStripButton>())
                .Where(button => button != null);
            this.InvokeMethod(() =>
            {
                foreach (ToolStripButton button in buttons)
                {
                    button.Checked = false;
                }
            });
        }

        /// <summary>
        /// 初始化编辑器的工具条
        /// </summary>
        private void InitEditorToolbar()
        {
            ResetEditorToolbar();

            activeToolShapeType = toolRectangle;
            activeToolColor = toolColorRed;
            activeToolLineStyle = toolStyleSolid;
            activeToolDrawMode = toolDrawModeStroke;

            this.InvokeMethod(() =>
            {
                toolbarMask.Hide();
                toolbarLineType.Show();
                toolLineWidth.Show();
                toolbarColor.Show();
                toolbarDrawMode.Show();
                toolbarTextStyle.Hide();

                toolUndo.Enabled = false;
                toolRedo.Enabled = false;

                activeToolShapeType.Checked = true;
                activeToolColor.Checked = true;
                activeToolLineStyle.Checked = true;
                activeToolDrawMode.Checked = true;

                // 字体
                toolTextStyle.ForeColor = activeToolColor.BackColor;
            });
        }

        private void CloseForm()
        {
            Close();
        }

        private void ScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnbindHotKeys();

            editor.CancelEdit();
            // 内存回收
            editor.Reset();

            e.Cancel = true;
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
            editor.TextFont = toolTextStyle.Font;
            editor.DrawMode = DrawModes.Stroke;

            FixToolbarPosition(editor.Bounds, toolPanel);
            editor.BeginEdit();
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

            switch (editor.DrawShape)
            {
                case DrawShapes.Curve:
                    toolbarTextStyle.Hide();
                    toolbarDrawMode.Hide();
                    toolbarLineType.Show();
                    toolLineWidth.Show();
                    toolbarColor.Show();
                    break;
                case DrawShapes.Line:
                    toolbarTextStyle.Hide();
                    toolbarDrawMode.Hide();
                    toolbarLineType.Show();
                    toolLineWidth.Show();
                    toolbarColor.Show();
                    break;
                case DrawShapes.Polyline:
                    toolbarTextStyle.Hide();
                    toolbarDrawMode.Hide();
                    toolbarLineType.Show();
                    toolLineWidth.Show();
                    toolbarColor.Show();
                    break;
                case DrawShapes.Text:
                    toolbarTextStyle.Show();
                    toolbarLineType.Hide();
                    toolLineWidth.Hide();
                    toolbarDrawMode.Hide();
                    toolbarColor.Show();
                    break;
                case DrawShapes.Rectangle:
                case DrawShapes.Ellipse:
                //case DrawShapes.Polygon:
                //    toolbarTextStyle.Hide();
                //    toolbarLineType.Show();
                //    toolLineWidth.Show();
                //    toolbarDrawMode.Show();
                //    toolbarColor.Show();
                //    break;
                case DrawShapes.Arrow:
                    toolbarTextStyle.Hide();
                    toolbarDrawMode.Hide();
                    toolbarLineType.Show();
                    toolLineWidth.Show();
                    toolbarColor.Show();
                    break;
                case DrawShapes.Mosaic:
                    toolbarTextStyle.Hide();
                    toolbarDrawMode.Hide();
                    toolbarLineType.Hide();
                    toolLineWidth.Show();
                    toolbarColor.Hide();
                    break;
            }
        }

        private void ToolOK_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(editor.EndEdit());
            CloseForm();
        }

        private void ToolSave_Click(object sender, EventArgs e)
        {
            var img = editor.EndEdit();
            IsActive = false;
            if (ScreenShot.SaveImage(img))
            {
                CloseForm();
            }
            IsActive = true;
        }

        private void ToolCancel_Click(object sender, EventArgs e)
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

        private void ToolLineWidth_Scroll(object sender, EventArgs e)
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

        /// <summary>
        /// 绘制模式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarDrawMode_ItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = (ToolStripButton)e.ClickedItem;

            if (activeToolDrawMode != null)
            {
                activeToolDrawMode.Checked = false;
            }
            activeToolDrawMode = item;
            item.Checked = true;
            editor.DrawMode = (DrawModes)Enum.Parse(typeof(DrawModes), item.Tag.ToString());

            // 仅在描边时才显示宽度和线型
            toolbarLineType.Visible = toolLineWidth.Visible = editor.DrawMode == DrawModes.Stroke;
        }

        private void toolUndo_Click(object sender, EventArgs e)
        {
            editor.Undo();
        }

        private void toolRedo_Click(object sender, EventArgs e)
        {
            editor.Redo();
        }

        /// <summary>
        /// 接收消息，响应快捷键
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            // 收到的不是快捷键消息，不作任何处理
            if (m.Msg != 0x312)
            {
                base.WndProc(ref m);
                return;
            }

            // 窗口没有激活，不处理
            if (!IsActive)
            {
                base.WndProc(ref m);
                return;
            }

            // 收到的快捷键的值
            var keyValue = m.WParam.ToInt32();

            switch (keyValue)
            {
                // 关闭窗口
                case 0xF10001:
                    CloseForm();
                    break;
                // 撤消编辑
                case 0xF10002:
                    if (editor.IsEditing)
                    {
                        editor.Undo();
                    }
                    break;
                // 重做编辑
                case 0xF10003:
                    if (editor.IsEditing)
                    {
                        editor.Redo();
                    }
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }

        private void BindHotKeys()
        {
            // ESC 关闭窗口
            NativeMethods.RegisterHotKey(Handle,
                    HOTKEY_ID_BASE + 1,
                    KeyModifier.None,
                    Keys.Escape);

            // Ctrl Z 撤消编辑
            NativeMethods.RegisterHotKey(Handle,
                    HOTKEY_ID_BASE + 2,
                    KeyModifier.Ctrl,
                    Keys.Z);

            // Ctrl Shift Z 重做编辑
            NativeMethods.RegisterHotKey(Handle,
                    HOTKEY_ID_BASE + 3,
                    KeyModifier.Ctrl | KeyModifier.Shift,
                    Keys.Z);
        }

        private void UnbindHotKeys()
        {
            // ESC 关闭窗口
            NativeMethods.UnregisterHotKey(Handle,
                    HOTKEY_ID_BASE + 1);

            // Ctrl Z 撤消编辑
            NativeMethods.UnregisterHotKey(Handle,
                    HOTKEY_ID_BASE + 2);

            // Ctrl Shift Z 重做编辑
            NativeMethods.UnregisterHotKey(Handle,
                    HOTKEY_ID_BASE + 3);
        }
    }
}
