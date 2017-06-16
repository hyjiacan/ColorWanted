using ColorWanted.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ColorWanted.update;

namespace ColorWanted
{
    public partial class MainForm : Form
    {
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
        private const int colorInterval = 200;
        /// <summary>
        /// 取色窗口移动周期
        /// </summary>
        private const int caretInterval = 50;

        private bool settingLoaded;
        private readonly Screen screen;
        private HelpForm helpForm;
        private static UpdateForm updateForm;
        private PreviewForm previewForm;
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
        private readonly Dictionary<HotKeyValue, DateTime> lastPressTime;

        /// <summary>
        /// 颜色值字符串的缓存
        /// </summary>
        private readonly StringBuilder colorBuffer;

        public MainForm()
        {
            InitializeComponent();

            screen = Screen.PrimaryScreen;

            currentDisplayMode = DisplayMode.Fixed;

            colorBuffer = new StringBuilder(8, 64);

            var now = DateTime.Now;

            lastPressTime = new Dictionary<HotKeyValue, DateTime>
            {
                {HotKeyValue.CopyColor, now},
                {HotKeyValue.CopyPolicy, now},
                {HotKeyValue.DrawControl, now},
                {HotKeyValue.ShowColorPicker, now},
                {HotKeyValue.ShowMoreFormat, now},
                {HotKeyValue.ShowPreview, now},
                {HotKeyValue.SwitchMode, now}
            };

            Util.BindHotkeys(Handle);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt-Tab
                return cp;
            }
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
                SwitchDisplayMode(Settings.DisplayMode);

                settingLoaded = true;
            }

            Color color = ColorUtil.GetColor(MousePosition);

            // 如果光标位置不变，颜色也不变，就不绘制了
            if (MousePosition.Equals(lastPosition) && color.Equals(lastColor))
            {
                return;
            }

            lastPosition = MousePosition;
            lastColor = color;

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

            if (trayMenuShowPreview.Checked && !stopDrawPreview)
            {
                DrawPreview(MousePosition);
            }

            if (FormatMode.Mini == currentFormatMode)
            {
                BackColor = color;
                return;
            }
            lbRgb.BackColor = color;
            lbRgb.ForeColor = ColorUtil.GetContrastColor(color);
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
            catch (Exception e)
            {
                Util.ShowBugReportForm(e);
            }
        }

        private void SetDefaultLocation()
        {
            var size = screen.Bounds;

            Left = (size.Width - Width) / 2;
            Top = 0;
        }


        private void trayMenuExit_Click(object sender, EventArgs e)
        {
            colorTimer.Stop();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.UnbindHotkeys(Handle);
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

            var key = (HotKeyValue)keyValue;

            var lasttime = lastPressTime[key];
            var now = DateTime.Now;

            var doubleClick = (now - lasttime).TotalSeconds <= 1;

            switch (key)
            {
                // 切换显示模式
                case HotKeyValue.SwitchMode:
                    SwitchDisplayMode();
                    break;
                // 显示/隐藏更多的颜色格式
                case HotKeyValue.ShowMoreFormat:
                    SwitchFormatMode();
                    break;
                // 复制颜色值
                case HotKeyValue.CopyColor:
                    CopyColor(doubleClick);
                    break;
                // 切换复制策略
                case HotKeyValue.CopyPolicy:
                    ToggleCopyPolicy();
                    break;
                // 打开预览窗口
                case HotKeyValue.ShowPreview:
                    TogglePreview();
                    break;
                // 显示/隐藏调色板
                case HotKeyValue.ShowColorPicker:
                    ShowColorPicker();
                    break;
                // 绘制预览窗口
                case HotKeyValue.DrawControl:
                    DrawControl(doubleClick);
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Height = 20;
            Width = 88;

            previewForm = new PreviewForm();
            previewForm.LocationChanged += previewForm_LocationChanged;
            if (Settings.PreviewVisible)
            {
                TogglePreview();
            }

            if (!trayMenuFollowCaret.Checked)
            {
                FixedPosition();
            }

            // 加载配置
            trayMenuAutoPin.Checked = Settings.AutoPin;

            SwitchFormatMode(Settings.FormatMode);

            trayMenuCopyPolicyHexValueOnly.Checked = Settings.HexValueOnly;
            trayMenuCopyPolicyRgbValueOnly.Checked = Settings.RgbValueOnly;

            // 读取开机启动的注册表
            trayMenuAutoStart.Checked = Settings.Autostart;

            caretTimer = new Timer { Interval = caretInterval };
            caretTimer.Tick += carettimer_Tick;
            caretTimer.Start();

            colorTimer = new Timer { Interval = colorInterval };
            colorTimer.Tick += colortimer_Tick;
            colorTimer.Start();

            // 检查是否是首次运行
            if (Settings.IsFirstRun)
            {
                Settings.IsFirstRun = false;

                // 首次运行时，打开帮助窗口
                trayMenuShowHelp_Click(null, null);
            }

            // 检查更新
            CheckUpdate();
        }

        public static void CheckUpdate(bool showDetail = false)
        {
            if (updateForm == null)
            {
                updateForm = new UpdateForm();
            }

            updateForm.ShowDetail = showDetail;
            updateForm.Action(); 
        }

        private void previewForm_LocationChanged(object sender, EventArgs e)
        {
            if (!trayMenuAutoPin.Checked)
            {
                return;
            }

            #region 针对屏幕边缘
            var size = screen.Bounds;
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
            else if (screen.WorkingArea.Height - previewForm.Top - previewForm.Height <= pinSize)
            {
                previewForm.Top = screen.WorkingArea.Height - previewForm.Height;
            }
            #endregion

            #region 针对主窗口边缘(仅下方和右侧)

            // 右侧
            if (Math.Abs(previewForm.Left - (Left + Width)) <= pinSize
                && previewForm.Top <= Top + Height // 没有在主窗口下方
                && (previewForm.Top + previewForm.Height >= previewForm.Top))// 没有在主窗口上方
            {
                previewForm.Left = Left + Width;
            }

            // 下方
            if (Math.Abs(previewForm.Top - (Top + Height)) <= pinSize
                && previewForm.Left <= Left + Width // 没有在主窗口右侧
                && (previewForm.Left + previewForm.Width >= previewForm.Left))// 没有在主窗口左侧
            {
                previewForm.Top = Top + Height;
            }
            #endregion
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (trayMenuFollowCaret.Checked)
            {
                return;
            }
            if (trayMenuAutoPin.Checked)
            {
                var size = screen.Bounds;
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
                else if (screen.WorkingArea.Height - Top - Height <= pinSize)
                {
                    Top = screen.WorkingArea.Height - Height;
                }
            }

            if (settingLoaded)
            {
                Settings.Location = Location;
            }
        }


        #region 托盘菜单


        private void trayMenuHideWindow_Click(object sender, EventArgs e)
        {
            SwitchDisplayMode(DisplayMode.Hidden);
        }

        private void trayMenuFixed_Click(object sender, EventArgs e)
        {
            SwitchDisplayMode(DisplayMode.Fixed);
        }

        private void trayMenuFollowCaret_Click(object sender, EventArgs e)
        {
            SwitchDisplayMode(DisplayMode.Follow);
        }

        private void trayMenuFormatMini_Click(object sender, EventArgs e)
        {
            SwitchFormatMode(FormatMode.Mini);
        }

        private void trayMenuFormatExtention_Click(object sender, EventArgs e)
        {
            SwitchFormatMode(FormatMode.Extention);
        }

        private void trayMenuCopyPolicyHexValueOnly_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // ReSharper disable once PossibleNullReferenceException
            item.Checked = !item.Checked;

            Settings.HexValueOnly = item.Checked;
        }

        private void trayMenuCopyPolicyRgbValueOnly_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // ReSharper disable once PossibleNullReferenceException
            item.Checked = !item.Checked;

            Settings.RgbValueOnly = item.Checked;
        }

        private void trayMenuShowHelp_Click(object sender, EventArgs e)
        {
            if (helpForm == null)
            {
                helpForm = new HelpForm();
            }
            helpForm.Show();
        }


        private void trayMenuShowPreview_Click(object sender, EventArgs e)
        {
            TogglePreview();
        }

        private void trayMenuAutoPin_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // ReSharper disable once PossibleNullReferenceException
            item.Checked = !item.Checked;
            if (settingLoaded)
            {
                Settings.AutoPin = item.Checked;
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

        private void trayMenuAutoStart_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // ReSharper disable once PossibleNullReferenceException
            item.Checked = !item.Checked;

            // 写注册表
            Settings.Autostart = item.Checked;
        }

        private void trayMenuCheckUpdate_Click(object sender, EventArgs e)
        {
            CheckUpdate(true);
        }

        private void trayMenuOpenConfigFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Settings.FileName))
                {
                    File.Create(Settings.FileName).Close();
                }

                Process.Start(Settings.FileName);
            }
            catch (Exception ex)
            {
                tray.ShowBalloonTip(5000, "无法打开配置文件", ex.Message, ToolTipIcon.Warning);
            }
        }

        private void ToggleCopyPolicy()
        {
            trayMenuCopyPolicyHexValueOnly.Checked =
                trayMenuCopyPolicyRgbValueOnly.Checked =
                    Settings.HexValueOnly =
                        Settings.RgbValueOnly =
                            !Settings.HexValueOnly;
        }

        private void TogglePreview()
        {
            Settings.PreviewVisible = trayMenuShowPreview.Checked = previewForm.Visible = !previewForm.Visible;
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
            catch
            {
                // ignore
            }

            // 加载保存的自定义颜色
            colorPicker.CustomColors = Settings.CustomColors;

            trayMenuShowColorPicker.Checked = true;
            if (DialogResult.OK == colorPicker.ShowDialog(this))
            {
                var cl = colorPicker.Color;
                Util.SetClipboard(Handle, string.Format("#{0:X2}{1:X2}{2:X2}", cl.R, cl.G, cl.B));

                // 保存自定义颜色
                Settings.CustomColors = colorPicker.CustomColors;
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
            DisplayMode mode = (DisplayMode)Enum.ToObject(typeof(DisplayMode), currentDisplayMode + 1);
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
                trayMenuHideWindow.Checked = true;
                trayMenuFollowCaret.Checked = false;
                trayMenuFixed.Checked = false;

                trayMenuShowPreview.Enabled = false;

                trayMenuRestoreLocation.Enabled = false;
                trayMenuAutoPin.Enabled = false;

                trayMenuFormatMini.Enabled = false;
                trayMenuFormatExtention.Enabled = false;

                Hide();
            }
            else
            {

                trayMenuHideWindow.Checked = false;
                trayMenuFollowCaret.Checked = false;
                trayMenuFixed.Checked = false;
                trayMenuShowPreview.Enabled = true;

                trayMenuFormatMini.Enabled = true;
                trayMenuFormatExtention.Enabled = true;

                Show();
                BringToFront();
                FixedPosition();

                switch (mode)
                {
                    case DisplayMode.Fixed:
                        trayMenuFixed.Checked = true;
                        trayMenuRestoreLocation.Enabled = true;
                        trayMenuAutoPin.Enabled = true;
                        break;
                    case DisplayMode.Follow:
                        trayMenuFollowCaret.Checked = true;
                        trayMenuRestoreLocation.Enabled = false;
                        trayMenuAutoPin.Enabled = false;
                        // 跟随模式时启动取色窗口定时器
                        caretTimer.Start();
                        break;
                }
            }
            currentDisplayMode = mode;
            if (settingLoaded)
            {
                Settings.DisplayMode = mode;
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
                    trayMenuFormatMini.Checked = true;
                    trayMenuFormatExtention.Checked = false;

                    lbRgb.Visible = false;

                    Width = 88;
                    break;
                case FormatMode.Extention:
                    trayMenuFormatMini.Checked = false;
                    trayMenuFormatExtention.Checked = true;

                    lbRgb.Visible = true;

                    Width = 208;
                    break;
            }
            currentFormatMode = mode;

            if (settingLoaded)
            {
                Settings.FormatMode = mode;
            }
        }

        /// <summary>
        /// 窗口跟随光标显示
        /// </summary>
        private void FollowCaret()
        {
            int x = MousePosition.X,
                y = MousePosition.Y;

            var size = screen.Bounds;

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
            else if (y < screen.WorkingArea.Height - Height)
            {
                Top = y + 10;
            }
            else
            {
                Top = screen.WorkingArea.Height - Height;
            }
        }

        /// <summary>
        /// 容器在固定位置显示
        /// </summary>
        private void FixedPosition()
        {
            var loc = Settings.Location;
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
                var result = Util.SetClipboard(Handle, doubleClick ?
                    (trayMenuCopyPolicyRgbValueOnly.Checked ? lbRgb.Tag.ToString() : lbRgb.Text) :
                    (trayMenuCopyPolicyHexValueOnly.Checked ? lbHex.Tag.ToString() : lbHex.Text));

                // 复制失败
                if (result != null)
                {
                    tray.ShowBalloonTip(5000,
                        "复制失败",
                        result,
                        ToolTipIcon.Error);
                }
            }
            catch (Exception e)
            {
                Util.ShowBugReportForm(e);
            }
        }

        /// <summary>
        /// 控制绘制预览面板以及更新颜色格式的值
        /// </summary>
        private void DrawControl(bool doubleClick)
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
                    tray.ShowBalloonTip(3000,
                        "已暂停取色",
                        "双击 Ctrl+` 开始取色",
                        ToolTipIcon.Info);
                }

                return;
            }

            stopDrawPreview = !stopDrawPreview;
            previewForm.ToggleCursor(stopDrawPreview);
            if (stopDrawPreview)
            {
                tray.ShowBalloonTip(3000,
                    "已暂停预览",
                    "按下 Ctrl+` 开始预览",
                    ToolTipIcon.Info);
            }
        }
        #endregion
    }
}
