using ColorWanted.clipboard;
using ColorWanted.colors;
using ColorWanted.ext;
using ColorWanted.history;
using ColorWanted.hotkey;
using ColorWanted.misc;
using ColorWanted.mode;
using ColorWanted.screenshot;
using ColorWanted.setting;
using ColorWanted.update;
using ColorWanted.util;
using ColorWanted.viewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ColorWanted
{
    internal partial class MainForm : Form
    {
        #region 变量声明
        i18n.I18nManager resources = new i18n.I18nManager(typeof(MainForm));
        /// <summary>
        /// 取色的定时器
        /// </summary>
        private Timer colorTimer;

        /// <summary>
        /// 取色窗口移动位置定时器
        /// </summary>
        private Timer caretTimer;

        /// <summary>
        /// 取色周期
        /// </summary>
        private const int colorInterval = 100;

        /// <summary>
        /// 取色窗口移动周期
        /// </summary>
        private const int caretInterval = 50;
        /// <summary>
        /// 配置是否加载完成
        /// </summary>
        private bool settingLoaded;
        private PreviewForm previewForm;
        private DelayedScreenShotForm delayedScreenshotForm;
        private ColorDialog colorPicker;

        /// <summary>
        /// 控制是否停止绘制预览窗口，为true时就停止绘制预览窗口
        /// 为true时可以在预览窗口上取色
        /// </summary>
        private bool stopDrawPreview;

        /// <summary>
        /// 是否停止取色
        /// </summary>
        private bool stopPickColor;

        /// <summary>
        /// 上次光标所在位置
        /// </summary>
        private Point lastPosition = Point.Empty;

        /// <summary>
        /// 上次取到的颜色
        /// </summary>
        private Color lastColor = Color.Empty;

        /// <summary>
        /// 自动吸附的距离，当距离小于等于这个值时吸附
        /// </summary>
        private const int pinSize = 15;

        /// <summary>
        /// 上次按下快捷键的时间记录
        /// </summary>
        private Dictionary<HotKeyType, DateTime> lastPressTime;

        /// <summary>
        /// 颜色值字符串的缓存
        /// </summary>
        private StringBuilder colorBuffer;

        /// <summary>
        /// 启动时传入的参数列表
        /// </summary>
        private string[] AppArgs;

        public static MainForm Instance { get; private set; }

        #endregion
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_CLIPBOARDUPDATE:
                    if (ClipboardManager.CopyHistory)
                    {
                        ClipboardManager.CopyHistory = false;
                        break;
                    }
                    try
                    {
                        //显示剪贴板中的文本信息
                        if (Clipboard.ContainsText())
                        {
                            var text = Clipboard.GetText();
                            ClipboardManager.Write(text, text.GetHashCode());
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Warn(ex);
                        // ingore
                    }
                    break;
            }
            base.DefWndProc(ref m);
        }

        private void MainForm_ForeColorChanged(object sender, EventArgs e)
        {
            UpdateShotButton(ForeColor);
        }

        private void UpdateShotButton(Color color)
        {
            var img = new Bitmap(Util.ScaleX(20), Util.ScaleX(20));
            using (var g = Graphics.FromImage(img))
            {
                using (var brush = new SolidBrush(color))
                {
                    using (var pen = new Pen(brush))
                    {
                        g.DrawRectangle(pen, 0, 0, Util.ScaleX(17), Util.ScaleY(17));
                        g.FillPolygon(brush, new[] {
                            new Point(Util.ScaleX(4), Util.ScaleY(8)),
                            new Point(Util.ScaleX(8), Util.ScaleY(3)),
                            new Point(Util.ScaleX(14), Util.ScaleY(8)),
                            new Point(Util.ScaleX(8), Util.ScaleY(13))
                        });
                        g.DrawEllipse(pen, Util.ScaleX(2), Util.ScaleY(2), Util.ScaleX(13), Util.ScaleY(13));
                    }
                }
            }
            btnScreenshot.Image = img;
        }

        public void UpdateTooltip()
        {
            this.InvokeMethod(() =>
            {
                tooltip.SetToolTip(lbHex, resources.GetString("lbHex.ToolTip") + " " +
                                          HotKey.Get(HotKeyType.CopyColor));
                tooltip.SetToolTip(lbRgb, resources.GetString("lbRgb.ToolTip") + " " +
                                          HotKey.Get(HotKeyType.CopyColor));
            });
        }

        /// <summary>
        /// 跟随模式时，更新当前窗口的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void carettimer_Tick(object sender, EventArgs e)
        {
            if (currentDisplayMode != DisplayMode.Follow)
            {
                return;
            }

            // 如果光标位置不变，颜色也不变，就不绘制了
            if (MousePosition.Equals(lastPosition))
            {
                return;
            }

            FollowCaret();
        }

        /// <summary>
        /// 更新当前获取的颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colortimer_Tick(object sender, EventArgs e)
        {
            if (!stopDrawPreview && previewForm.MouseOnMe)
            {
                // 如果没有停止预览，并且鼠标在预览窗口上
                // 就不取色，这是为了防止因循环取色导致过高的资源占用
                return;
            }
            if (!settingLoaded)
            {
                // 不晓得为啥，在启动时加载Visible会被覆盖，所在放到这里来了
                SwitchDisplayMode(Settings.Main.Display);

                settingLoaded = true;
            }

            // 如果光标位置不变，就不绘制了
            if (MousePosition.Equals(lastPosition))
            {
                return;
            }

            var color = ColorUtil.GetColor(MousePosition);

            // 如果颜色不变，就不绘制了
            if (color.Equals(lastColor))
            {
                return;
            }

            lastPosition = MousePosition;
            lastColor = color;

            Msg.Broadcast(lastPosition.X, lastPosition.Y, string.Format("{0},{1},{2}", color.R, color.G, color.B));

            colorBuffer.Clear();
            var val = colorBuffer.AppendFormat("{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B).ToString();
            lbHex.Tag = val;
            colorBuffer.Clear();

            lbHex.Text = colorBuffer.AppendFormat("#{0}", lbHex.Tag).ToString();
            colorBuffer.Clear();

            val = colorBuffer.AppendFormat("{0},{1},{2}", color.R, color.G, color.B).ToString();
            lbRgb.Tag = val;
            colorBuffer.Clear();

            lbRgb.Text = colorBuffer.AppendFormat("RGB({0})", lbRgb.Tag).ToString();
            colorBuffer.Clear();

            // 利用截图按钮来显示选中的颜色
            btnScreenshot.BackColor = ColorUtil.GetContrastColor(color);
            UpdateShotButton(color);

            if (Settings.Preview.Visible && !stopDrawPreview)
            {
                DrawPreview(MousePosition);
            }

            if (FormatMode.Mini == currentFormatMode)
            {
                if (!lbColorPreview.Visible)
                {
                    lbColorPreview.Show();
                }
                lbColorPreview.BackColor = color;
                return;
            }

            if (lbColorPreview.Visible)
            {
                lbColorPreview.Hide();
            }

            if (FormatMode.Shot == currentFormatMode || FormatMode.Standard == currentFormatMode)
            {
                return;
            }

            // var hsl = HSL.Parse(color);
            var hsl = new HSL(color.GetHue(), color.GetSaturation(), color.GetBrightness());
            lbHsl.Text = colorBuffer.AppendFormat("HSL({0},{1},{2})",
                Math.Round(hsl.H),
                Util.Round(hsl.S * 100),
                Util.Round(hsl.L * 100)).ToString();
            colorBuffer.Clear();

            var hsb = HSB.Parse(color);
            lbHsb.Text = colorBuffer.AppendFormat("HSB({0},{1},{2})",
                Math.Round(hsb.H),
                Util.Round(hsb.S * 100),
                Util.Round(hsb.B * 100)).ToString();
            colorBuffer.Clear();

            var hsi = HSI.Parse(color, Settings.Main.HsiAlgorithm);
            lbHsi.Text = colorBuffer.AppendFormat("HSI({0},{1},{2})",
                Math.Round(hsi.H),
                Util.Round(hsi.S * 100),
                Util.Round(hsi.I * 100)).ToString();
            colorBuffer.Clear();
        }

        /// <summary>
        /// 画放大图，每个方向各取5个像素
        /// </summary>
        private void DrawPreview(Point pt)
        {
            var size = previewForm.Height / 11;
            // 目标：预览窗口越大，放大倍数越大
            // preview 预览窗口大小/11得到的数字
            // size 取色宽度
            // 做法：从屏幕上取到的大小不按线性变化，预览窗口放大两次，取色宽度才放大一次
            // 例： 
            // 预览窗口大小    相对放大倍数                        取色宽度                实际放大倍数
            // preview=121 => 11 => size = 11 - (11 - 11) / 2 = 11 => scale = 121/11 = 11
            // preview=132 => 12 => size = 12 - (12 - 11) / 2 = 11 => scale = 132/11 = 12
            // preview=143 => 13 => size = 13 - (13 - 11) / 2 = 12 => scale = 143/12 = 11.92
            // preview=154 => 14 => size = 14 - (14 - 11) / 2 = 13 => scale = 154/13 = 11.85
            // preview=165 => 15 => size = 15 - (15 - 11) / 2 = 13 => scale = 165/13 = 12.69
            // preview=176 => 16 => size = 16 - (16 - 11) / 2 = 14 => scale = 176/14 = 12.57
            // preview=187 => 17 => size = 17 - (17 - 11) / 2 = 14 => scale = 187/14 = 13.36
            // preview=198 => 18 => size = 18 - (18 - 11) / 2 = 15 => scale = 198/15 = 13.2
            // preview=209 => 19 => size = 19 - (19 - 11) / 2 = 15 => scale = 209/15 = 13.93
            // preview=220 => 20 => size = 20 - (20 - 11) / 2 = 16 => scale = 220/16 = 13.75
            // preview=231 => 21 => size = 21 - (21 - 11) / 2 = 16 => scale = 231/16 = 14.44

            size -= (size - 11) / 2;
            if (size % 2 == 0)
            {
                size += 1;
            }
            var pic = new Bitmap(size, size);
            // 从中心点到左侧和顶部的距离
            var extend = size / 2;
            var graphics = Graphics.FromImage(pic);
            try
            {
                graphics.CopyFromScreen(pt.X - extend, pt.Y - extend, 0, 0, pic.Size);
            }
            catch (Win32Exception)
            {
                // ignore the exception
                // System.ComponentModel.Win32Exception (0x80004005): 句柄无效。
            }
            graphics.Save();
            try
            {
                previewForm.UpdateImage(pic);
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                try
                {
                    if (previewForm != null && !previewForm.IsDisposed)
                    {
                        previewForm.Dispose();
                    }
                }
                catch (Exception ex2)
                {
                    Logger.Warn(ex2);
                    // ignore
                }
                // 重试一次
                previewForm = new PreviewForm();
                previewForm.UpdateImage(pic);
            }
        }

        private void SetDefaultLocation()
        {
            var size = Util.GetScreenSize();

            Left = (size.Width - Width) / 2;
            Top = 0;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            colorTimer.Stop();
            caretTimer.Stop();

            try
            {
                NativeMethods.RemoveClipboardFormatListener(Handle);
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                // ignore
            }
            try
            {
                ColorUtil.DeleteDC();
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                // ignore
            }
            try
            {
                this.InvokeMethod(() => HotKey.Unbind(Handle));
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                // ignore
            }
            try
            {
                Msg.Stop();
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                // ignore
            }
            //UnregisterDeskband();
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

            // 收到的快捷键的值
            var keyValue = m.WParam.ToInt32();

            var key = (HotKeyType)keyValue;

            var lasttime = lastPressTime[key];
            var now = DateTime.Now;

            var doubleClick = (now - lasttime).TotalSeconds <= 1;

            switch (key)
            {
                // 切换显示模式
                case HotKeyType.SwitchMode:
                    SwitchDisplayMode();
                    break;
                // 显示/隐藏更多的颜色格式
                case HotKeyType.SwitchDisplayMode:
                    SwitchFormatMode();
                    break;
                // 复制颜色值
                case HotKeyType.CopyColor:
                    CopyColor(doubleClick);
                    break;
                // 切换复制策略
                case HotKeyType.CopyPolicy:
                    ToggleCopyPolicy();
                    break;
                // 打开预览窗口
                case HotKeyType.ShowPreview:
                    TogglePreview();
                    break;
                // 显示/隐藏调色板
                case HotKeyType.ShowColorPicker:
                    ShowColorPicker();
                    break;
                // 绘制预览窗口
                case HotKeyType.ControlDraw:
                    DrawControl(doubleClick);
                    break;
                // 设置窗口在最前显示
                case HotKeyType.BringToTop:
                    if (Visible)
                    {
                        BringToFront();
                    }
                    if (previewForm != null && previewForm.Visible)
                    {
                        previewForm.BringToFront();
                    }
                    break;
                // 使用像素放大算法
                case HotKeyType.PixelScale:
                    Settings.Preview.PixelScale = !Settings.Preview.PixelScale;
                    break;
                // 截图
                case HotKeyType.ScreenShot:
                    if (ScreenShot.Busy)
                    {
                        ScreenShot.CancelCapture();
                    }
                    else
                    {
                        ScreenShot.Capture();
                    }
                    break;
                // 录屏
                case HotKeyType.ScreenCast:
                    ScreenShot.Cast();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            lastPressTime[key] = now;

            base.WndProc(ref m);
        }

        private void MouseDownEventHandler(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(Handle, NativeMethods.WM_SYSCOMMAND,
                new IntPtr(NativeMethods.SC_MOVE + NativeMethods.HTCAPTION), IntPtr.Zero);
        }

        private void previewForm_LocationChanged(object sender, EventArgs e)
        {
            if (!Settings.Base.AutoPin || previewForm.FollowMainForm)
            {
                return;
            }

            #region 针对主窗口边缘(仅下方和右侧)

            // 右侧
            if (Math.Abs(previewForm.Left - (Left + Width)) <= pinSize
                && previewForm.Top <= Top + Height // 没有在主窗口下方
                && (previewForm.Top + previewForm.Height >= previewForm.Top))// 没有在主窗口上方
            {
                previewForm.Left = Left + Width;
                previewForm.Top = Top;
                Settings.Preview.PinPosition = PinPosition.Right;
            }
            else
            // 下方
            if (Math.Abs(previewForm.Top - (Top + Height)) <= pinSize
                && previewForm.Left <= Left + Width // 没有在主窗口右侧
                && (previewForm.Left + previewForm.Width >= previewForm.Left))// 没有在主窗口左侧
            {
                previewForm.Top = Top + Height;
                previewForm.Left = Left;
                Settings.Preview.PinPosition = PinPosition.Bottom;
            }
            else if (previewForm.Initialized)
            {
                // 初始化完成再搞这个事，以解决初始化预览窗口位置时导致 Pin 状态的错误
                Settings.Preview.PinPosition = PinPosition.None;
            }
            #endregion

            #region 针对屏幕边缘 如果已经紧贴了Main窗口，就不管屏幕边缘了
            if (Settings.Preview.PinPosition != PinPosition.None)
            {
                return;
            }
            var size = Util.GetScreenSize();
            if (previewForm.Top <= pinSize)
            {
                previewForm.Top = 0;
            }
            else if (previewForm.Left <= pinSize)
            {
                previewForm.Left = 0;
            }
            else if (size.Width - previewForm.Left - previewForm.Width <= pinSize)
            {
                previewForm.Left = size.Width - previewForm.Width;
            }
            else if (size.Height - previewForm.Top - previewForm.Height <= pinSize)
            {
                previewForm.Top = size.Height - previewForm.Height;
            }
            #endregion
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (Settings.Main.Display == DisplayMode.Follow)
            {
                return;
            }
            if (Settings.Base.AutoPin)
            {
                var size = Util.GetScreenSize();
                if (Top <= pinSize)
                {
                    Top = 0;
                }
                else if (Left <= pinSize)
                {
                    Left = 0;
                }
                else if (size.Width - Left - Width <= pinSize)
                {
                    Left = size.Width - Width;
                }
                else if (size.Height - Top - Height <= pinSize)
                {
                    Top = size.Height - Height;
                }
            }
            // 同步移动预览窗口
            UpdatePreviewPosition();
            // 同步移动截图倒计时窗口
            UpdateDelayedWScreenShotPosition();

            if (settingLoaded)
            {
                Settings.Main.Location = Location;
            }
        }

        /// <summary>
        /// 当预览窗口紧贴此窗口时，若此窗口移动，同步更新预览窗口位置
        /// </summary>
        private void UpdatePreviewPosition()
        {
            previewForm.FollowMainForm = true;
            if (Settings.Preview.PinPosition == PinPosition.Right)
            {
                previewForm.Top = Top;
                previewForm.Left = Left + Width;
            }
            else if (Settings.Preview.PinPosition == PinPosition.Bottom)
            {
                previewForm.Top = Top + Height;
                previewForm.Left = Left;
            }
            previewForm.FollowMainForm = false;
        }


        #region 托盘菜单

        /// <summary>
        /// 处理鼠标左键单击托盘图标的事件
        /// 此时若取色窗口或预览窗口是可见的，刚将其设置为 topmost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (Visible)
            {
                TopMost = true;
            }
            if (previewForm != null && previewForm.Visible)
            {
                previewForm.TopMost = true;
            }
        }

        private void trayMenuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void trayMenuRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void trayMenuShowAbout_Click(object sender, EventArgs e)
        {
            try
            {
                var form = Application.OpenForms["AboutForm"] ?? new AboutForm();

                if (form.Visible)
                {
                    form.BringToFront();
                    return;
                }
                form.Show(this);
                form.BringToFront();
            }
            catch (ObjectDisposedException)
            {
                // ignore
            }
        }

        private void trayMenuShowColorPicker_Click(object sender, EventArgs e)
        {
            ShowColorPicker();
        }

        private void trayMenuRestoreLocation_Click(object sender, EventArgs e)
        {
            SetDefaultLocation();

            previewForm.Location = new Point(0, 0);
        }

        private void trayMenuCheckUpdate_Click(object sender, EventArgs e)
        {
            UpdateForm.ShowWindow();
        }

        private void trayMenuHistory_Click(object sender, EventArgs e)
        {
            try
            {
                var form = Application.OpenForms["HistoryForm"] ?? new HistoryForm();
                form.Show();
            }
            catch (ObjectDisposedException)
            {
                // ignore
            }
        }

        /// <summary>
        /// 开始截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trayMenuScreenShot_Click(object sender, EventArgs e)
        {
            ScreenShot.Capture();
        }

        /// <summary>
        /// 开始录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trayMenuScreenCast_Click(object sender, EventArgs e)
        {
            ScreenShot.Cast();
        }

        /// <summary>
        /// 打开图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trayMenuOpenImage_Click(object sender, EventArgs e)
        {
            var filename = ImageViewer.SelectFile();
            if (filename != null)
            {
                ImageViewer.OpenImage(filename);
            }
        }

        /// <summary>
        /// 打开剪贴板历史窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trayMenuShowClipboard_Click(object sender, EventArgs e)
        {
            ClipboardListForm.Open();
        }

        /// <summary>
        /// 打开设置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trayMenuSettings_Click(object sender, EventArgs e)
        {
            SettingForm.Instance.Show();
        }

        private void ToggleCopyPolicy()
        {
            Settings.Base.RgbValueOnly = Settings.Base.HexValueOnly;
            Settings.Base.HexValueOnly = !Settings.Base.HexValueOnly;
        }

        private void TogglePreview()
        {
            Settings.Preview.Visible = previewForm.Visible = !previewForm.Visible;
            if (previewForm.Visible)
            {
                previewForm.BringToFront();
            }
        }

        private void ShowColorPicker()
        {
            if (trayMenuShowColorPicker.Checked)
            {
                return;
            }

            if (colorPicker == null)
            {
                colorPicker = new ColorDialog
                {
                    FullOpen = true
                };
            }
            try
            {
                // 显示时，尝试从剪贴板中加载已经复制的颜色
                if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    var color = Color.Empty;
                    var c = Clipboard.GetText().Trim();
                    if (c.Length == 7 && c[0] == '#')
                    {
                        // hex
                        var r = Convert.ToInt16(c.Substring(1, 2), 16);
                        var g = Convert.ToInt16(c.Substring(3, 2), 16);
                        var b = Convert.ToInt16(c.Substring(5, 2), 16);

                        color = Color.FromArgb(r, g, b);
                    }
                    else if (c.StartsWith("rgb", StringComparison.OrdinalIgnoreCase))
                    {
                        // rgb
                        var temp = c.Substring(3).Trim('(', ')').Split(',');
                        if (temp.Length == 3)
                        {
                            var colors = temp.Select(int.Parse).ToArray();
                            color = Color.FromArgb(colors[0], colors[1], colors[2]);
                        }
                    }

                    if (!color.IsEmpty)
                    {
                        colorPicker.Color = color;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                // ignore
            }

            // 加载保存的自定义颜色
            colorPicker.CustomColors = Settings.Base.CustomColors;

            trayMenuShowColorPicker.Checked = true;

            if (DialogResult.OK == colorPicker.ShowDialog(this))
            {
                var cl = colorPicker.Color;
                ColorHistory.Record(cl);

                var text = string.Format("#{0:X2}{1:X2}{2:X2}", cl.R, cl.G, cl.B);
                Util.SetClipboard(Handle, Settings.Base.CopyUpperCase ? text : text.ToLower());

                // 保存自定义颜色
                Settings.Base.CustomColors = colorPicker.CustomColors;
            }

            trayMenuShowColorPicker.Checked = false;
        }
        #endregion

        #region 显示模式控制
        /// <summary>
        /// 当前的颜色窗口显示模式
        /// </summary>
        private DisplayMode currentDisplayMode;

        /// <summary>
        /// 当前显示的颜色格式
        /// </summary>
        private FormatMode currentFormatMode;

        /// <summary>
        /// 切换窗口显示模式
        /// </summary>
        private void SwitchDisplayMode()
        {
            // 下一个要激活的模式
            var mode = (DisplayMode)Enum.ToObject(typeof(DisplayMode), currentDisplayMode + 1);
            // 看加了后这个模式有没有定义，如果没有定义，则跳转到隐藏模式
            if (!Enum.IsDefined(typeof(DisplayMode), mode))
            {
                mode = DisplayMode.Hidden;
            }
            SwitchDisplayMode(mode);
        }

        private void SwitchDisplayMode(DisplayMode mode)
        {
            // 切换模式时，先停止取色窗口位置定时器
            caretTimer.Stop();

            if (mode == DisplayMode.Hidden)
            {
                Hide();
            }
            else
            {
                Show();
                BringToFront();
                FixedPosition();

                switch (mode)
                {
                    case DisplayMode.Fixed:
                        trayMenuRestoreLocation.Enabled = true;
                        break;
                    case DisplayMode.Follow:
                        trayMenuRestoreLocation.Enabled = false;
                        // 跟随模式时启动取色窗口定时器
                        caretTimer.Start();
                        break;
                }
            }
            currentDisplayMode = mode;
            if (settingLoaded)
            {
                Settings.Main.Display = mode;
            }
        }

        /// <summary>
        /// 自动切换到下一个颜色格式显示模式
        /// </summary>
        private void SwitchFormatMode()
        {
            var nextmode = (int)currentFormatMode + 1;
            SwitchFormatMode(
                Enum.IsDefined(typeof(FormatMode), nextmode)
                ? (FormatMode)nextmode : FormatMode.Mini);
        }

        private void SwitchFormatMode(FormatMode mode)
        {
            switch (mode)
            {
                case FormatMode.Mini:
                    lbHex.Width = Util.ScaleX(68);
                    lbHex.Visible = true;
                    lbRgb.Visible = false;
                    pnExt.Visible = false;
                    Height = Util.ScaleY(20);
                    Width = Util.ScaleX(88);
                    break;
                case FormatMode.Standard:
                    lbHex.Width = Util.ScaleX(68);
                    lbRgb.Width = Util.ScaleX(140);
                    lbRgb.Left = Util.ScaleX(88);
                    lbRgb.Top = 0;
                    lbHex.Visible = true;
                    lbRgb.Visible = true;
                    pnExt.Visible = false;
                    Height = Util.ScaleY(20);
                    Width = Util.ScaleX(228);
                    break;
                case FormatMode.Extention:
                    // 让两边都留下20宽度，以使显示居中
                    lbHex.Width = Util.ScaleX(140);
                    lbRgb.Width = Util.ScaleX(180);
                    lbRgb.Left = 0;
                    lbRgb.Top = Util.ScaleY(20);
                    lbHex.Visible = true;
                    lbRgb.Visible = true;
                    pnExt.Visible = true;
                    Height = Util.ScaleY(100);
                    Width = Util.ScaleX(180);
                    break;
                case FormatMode.Shot:
                    lbHex.Visible = false;
                    lbRgb.Visible = false;
                    pnExt.Visible = false;
                    Height = Util.ScaleY(20);
                    Width = Util.ScaleX(20);
                    break;
            }
            currentFormatMode = mode;

            if (settingLoaded)
            {
                Settings.Main.Format = mode;
            }
            // 切换了显示格式后，自动重算预览窗口位置
            if (previewForm.Visible && Settings.Preview.PinPosition != PinPosition.None)
            {
                UpdatePreviewPosition();
            }
        }

        /// <summary>
        /// 窗口跟随光标显示
        /// </summary>
        private void FollowCaret()
        {
            int x = MousePosition.X,
                y = MousePosition.Y;

            var size = Util.GetScreenSize();

            if (x <= size.Width - Width)
            {

                Left = x + 10;
            }
            else
            {
                Left = x - Width - 10;
            }
            if (y <= Height)
            {

                Top = y + 10;
            }
            else if (y < size.Height - Height)
            {
                Top = y + 10;
            }
            else
            {
                Top = size.Height - Height;
            }
            // 同步移动预览窗口
            UpdatePreviewPosition();
        }

        /// <summary>
        /// 容器在固定位置显示
        /// </summary>
        private void FixedPosition()
        {
            var loc = Settings.Main.Location;
            if (loc.IsEmpty)
            {
                // 配置文件里面没有位置数据或数据无效，那么将窗口显示在默认的位置
                SetDefaultLocation();
            }
            else
            {
                Left = loc.X;
                Top = loc.Y;
            }
        }
        #endregion

        #region 响应快捷键
        /// <summary> 
        /// 复制HEX颜色值  双击复制RGB颜色值
        /// </summary>
        private void CopyColor(bool doubleClick)
        {
            try
            {
                ColorHistory.Record(ColorUtil.GetColor(MousePosition));
                var text = doubleClick ?
                    (Settings.Base.RgbValueOnly ? lbRgb.Tag.ToString() : lbRgb.Text) :
                    (Settings.Base.HexValueOnly ? lbHex.Tag.ToString() : lbHex.Text);
                var result = Util.SetClipboard(Handle, Settings.Base.CopyUpperCase ? text : text.ToLower());

                // 复制失败
                if (result != null)
                {
                    tray.ShowBalloonTip(5000,
                        resources.GetString("copyFailed"),
                        result,
                        ToolTipIcon.Error);
                }
            }
            catch (Exception e)
            {
                Util.ShowBugReportForm(e);
            }
        }

        public void ShowBalloon(int timeout, string title, string content, ToolTipIcon icon = ToolTipIcon.Info)
        {
            tray.ShowBalloonTip(timeout, title, content, icon);
        }

        /// <summary>
        /// 控制绘制预览面板以及更新颜色格式的值
        /// </summary>
        internal void DrawControl(bool doubleClick)
        {
            if (doubleClick)
            {
                stopPickColor = !stopPickColor;
                // 停止取色
                if (stopPickColor)
                {
                    colorTimer.Start();
                }
                else
                {
                    colorTimer.Stop();
                }

                return;
            }

            stopDrawPreview = !stopDrawPreview;
            previewForm.ToggleCursor(stopDrawPreview);
        }
        #endregion

        public void ShowTip(int timeout, string msg)
        {
            tray.ShowBalloonTip(timeout, null, msg, ToolTipIcon.None);
        }

        #region 延时截图功能
        private void BtnScreenshot_MouseHover(object sender, EventArgs e)
        {
            // 鼠标放在按钮上时，显示倒计时按钮
            DelayedScreenShot();
        }

        private void BtnScreenshot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
            {
                // 双击截图
                ScreenShot.Capture();
                return;
            }
            // 直接按住拖动窗口
            MouseDownEventHandler(sender, e);
        }

        /// <summary>
        /// 延时截图
        /// </summary>
        private void DelayedScreenShot()
        {
            if (delayedScreenshotForm == null)
            {
                delayedScreenshotForm = new DelayedScreenShotForm();
            }
            else if (delayedScreenshotForm.Visible)
            {
                delayedScreenshotForm.Hide();
                return;
            }
            UpdateDelayedWScreenShotPosition();
            delayedScreenshotForm.Show();
            delayedScreenshotForm.Width = 110;
        }

        private void UpdateDelayedWScreenShotPosition()
        {
            if (delayedScreenshotForm == null)
            {
                return;
            }
            // 如果预览窗口
            delayedScreenshotForm.Left = this.Left;
            delayedScreenshotForm.Top = this.Bottom;
        }
        #endregion
    }
}
