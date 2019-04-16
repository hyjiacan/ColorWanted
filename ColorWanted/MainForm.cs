using ColorWanted.colors;
using ColorWanted.ext;
using ColorWanted.history;
using ColorWanted.hotkey;
using ColorWanted.misc;
using ColorWanted.mode;
using ColorWanted.setting;
using ColorWanted.theme;
using ColorWanted.update;
using ColorWanted.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ColorWanted
{
    internal partial class MainForm : Form
    {
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
        private const int colorInterval = 200;

        /// <summary>
        /// 取色窗口移动周期
        /// </summary>
        private const int caretInterval = 50;

        private bool settingLoaded;
        private PreviewForm previewForm;
        private ThemeForm themeForm;
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
        /// 当前的HSI算法
        /// </summary>
        private HsiAlgorithm currentHsiAlgorithm;

        public MainForm()
        {
            componentsLayout();
            ThemeUtil.Apply(this);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                var cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW); // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW; // 不显示在Alt-Tab
                return cp;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Height = 20;
            Width = 88;
            Init();
        }

        /// <summary>
        /// 执行初始化操作
        /// </summary>
        private void Init()
        {
            trayMenuHsiAlgorithmGeometry.Tag = HsiAlgorithm.Geometry;
            trayMenuHsiAlgorithmAxis.Tag = HsiAlgorithm.Axis;
            trayMenuHsiAlgorithmSegment.Tag = HsiAlgorithm.Segment;
            trayMenuHsiAlgorithmBajon.Tag = HsiAlgorithm.Bajon;
            trayMenuHsiAlgorithmStandard.Tag = HsiAlgorithm.Standard;

            previewForm = new PreviewForm();
            previewForm.LocationChanged += previewForm_LocationChanged;

            currentDisplayMode = DisplayMode.Fixed;
            SwitchHsiAlgorithm(Settings.Main.HsiAlgorithm);

            colorBuffer = new StringBuilder(8, 64);


            if (Settings.Preview.Visible)
            {
                TogglePreview();
            }

            if (trayMenuFixed.Checked)
            {
                FixedPosition();
            }

            SwitchFormatMode(Settings.Main.Format);

            var now = DateTime.Now;

            lastPressTime = Util.Enum<HotKeyType>()
                .ToDictionary(item => item, item => now);

            HotKey.Bind(Handle);

            trayMenuCopyPolicyHexValueOnly.Checked = Settings.Base.HexValueOnly;
            trayMenuCopyPolicyRgbValueOnly.Checked = Settings.Base.RgbValueOnly;

            new Thread(() =>
            {
                UpdateTooltip();

                // 读取开机启动的注册表
                trayMenuAutoStart.Checked = Settings.Base.Autostart;
                trayMenuAutoPin.Checked = Settings.Base.AutoPin;

                trayMenuPixelScale.Checked = Settings.Preview.PixelScale;
            })
            {
                IsBackground = true
            }.Start();

            caretTimer = new Timer { Interval = caretInterval };
            caretTimer.Tick += carettimer_Tick;
            caretTimer.Start();

            colorTimer = new Timer { Interval = colorInterval };
            colorTimer.Tick += colortimer_Tick;
            colorTimer.Start();

            // 检查是否是首次运行
            if (Settings.Base.IsFirstRun)
            {

                Settings.Base.IsFirstRun = false;

                // 首次运行时，打开帮助窗口
                trayMenuShowAbout_Click(null, null);
                if (!IsDisposed)
                {
                    // 然后打开快捷键设置窗口
                    trayMenuHotkey_Click(null, null);
                }
            }

            // 加载语言并选中使用的项
            new Thread(() =>
            {
                // 当前显示的语言
                var locale = (Settings.I18n.Lang ?? System.Globalization.CultureInfo.InstalledUICulture.Name).ToLower();
                // 加载自定义语言
                var langs = i18n.I18nManager.GetLocalLangs();
                if (langs.Any())
                {
                    // 都放到其它语言菜单项下
                    var others = new ToolStripMenuItem();
                    resources.ApplyResources(others, "trayMenuLanguageOther");
                    others.Name = "trayMenuLanguageOther";

                    // 存放语言 tooltip 的临时量
                    var temp = new StringBuilder();

                    var subs = langs.Select(language =>
                    {
                        var item = new ToolStripMenuItem();
                        item.Name = $"customize-lang--{language.Locale}";
                        item.Text = language.Name;

                        // 选中项
                        var l = language.Locale.ToLower();
                        item.Checked = locale == l || locale.StartsWith(l) || l.StartsWith(locale);

                        // 提示信息中显示语言的版本以及作者
                        temp.Append($"{language.Version}\n");
                        if (language.Authors != null && language.Authors.Any())
                        {
                            temp.Append("------------\n");
                            foreach (var author in language.Authors)
                            {
                                temp.AppendFormat("{0}/{1}\n", author.Name, author.Mail);
                                if (string.IsNullOrEmpty(author.HomePage))
                                {
                                    temp.Append(author.HomePage);
                                }
                            }
                        }
                        item.ToolTipText = temp.ToString();
                        temp.Clear();
                        return item;
                    });

                    // 添加菜单项
                    others.DropDownItems.AddRange(subs.ToArray());
                    this.InvokeMethod(() =>
                    {
                        trayMenuLanguage.DropDownItems.Add(others);
                    });
                }
                if (locale.StartsWith("zh"))
                {
                    trayMenuLanguageZH.Checked = true;
                }
                else if (!langs.Any() || locale.StartsWith("en"))
                {
                    // 没有其它语言或设置为英语时
                    trayMenuLanguageEN.Checked = true;
                }
            })
            {
                IsBackground = true
            }.Start();

            // 启动时检查更新
            trayMenuCheckUpdateOnStartup.Checked = Settings.Update.CheckOnStartup;

            // 自动检查更新
            if (trayMenuCheckUpdateOnStartup.Checked &&
                (DateTime.Now.Date - Settings.Update.LastUpdate).TotalDays >= Settings.Update.Span)
            {
                UpdateForm.ShowWindow(true);
            }
        }

        public void UpdateTooltip()
        {
            this.InvokeMethod(() =>
            {
                tooltip.SetToolTip(lbHex, resources.GetString("lbHex.ToolTip") +
                                          HotKey.Get(HotKeyType.CopyColor));
                tooltip.SetToolTip(lbRgb, resources.GetString("lbRgb.ToolTip") +
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

            var color = ColorUtil.GetColor(MousePosition);

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

            var contrastColor = ColorUtil.GetContrastColor(color);
            if (FormatMode.Standard == currentFormatMode)
            {
                lbRgb.BackColor = color;
                lbRgb.ForeColor = contrastColor;
                return;
            }

            if (lbRgb.BackColor != BackColor)
            {
                lbRgb.BackColor = BackColor;
                lbRgb.ForeColor = ForeColor;
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

            var hsi = HSI.Parse(color, currentHsiAlgorithm);
            lbHsi.Text = colorBuffer.AppendFormat("HSI({0},{1},{2})",
                Math.Round(hsi.H),
                Util.Round(hsi.S * 100),
                Util.Round(hsi.I * 100)).ToString();
            colorBuffer.Clear();

            pnExt.BackColor = color;
            pnExt.ForeColor = contrastColor;
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
            catch (Exception)
            {
                try
                {
                    if (previewForm != null && !previewForm.IsDisposed)
                    {
                        previewForm.Dispose();
                    }
                }
                catch (Exception)
                {
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


        private void trayMenuExit_Click(object sender, EventArgs e)
        {
            colorTimer.Stop();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.InvokeMethod(() => HotKey.Unbind(Handle));
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
                    trayMenuPixelScale_Click(null, null);
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
            if (!trayMenuAutoPin.Checked || previewForm.FollowMainForm)
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
            if (trayMenuFollowCaret.Checked)
            {
                return;
            }
            if (trayMenuAutoPin.Checked)
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
        private void tray_Click(object sender, EventArgs e)
        {
            if (Visible)
            {
                TopMost = true;
            }
            if (previewForm != null && previewForm.Visible)
            {
                previewForm.TopMost = true;
            }
        }


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

        private void trayMenuFormatStandard_Click(object sender, EventArgs e)
        {
            SwitchFormatMode(FormatMode.Standard);
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

            Settings.Base.HexValueOnly = item.Checked;
        }

        private void trayMenuCopyPolicyRgbValueOnly_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // ReSharper disable once PossibleNullReferenceException
            item.Checked = !item.Checked;

            Settings.Base.RgbValueOnly = item.Checked;
        }

        private void trayMenuHsiAlgorithmChange(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // ReSharper disable once PossibleNullReferenceException
            SwitchHsiAlgorithm((HsiAlgorithm)item.Tag);
        }

        private void trayMenuTheme_Click(object sender, EventArgs e)
        {
            if (themeForm == null)
            {
                themeForm = new ThemeForm();
            }
            if (themeForm.Visible)
            {
                themeForm.BringToFront();
                return;
            }
            themeForm.Show(this);
            themeForm.BringToFront();
        }

        private void trayMenuLanguageEN_Click(object sender, EventArgs e)
        {
            trayMenuLanguageEN.Checked = true;
            trayMenuLanguageZH.Checked = false;
            Settings.I18n.Lang = "en";
        }

        private void trayMenuLanguageZH_Click(object sender, EventArgs e)
        {
            trayMenuLanguageZH.Checked = true;
            trayMenuLanguageEN.Checked = false;
            Settings.I18n.Lang = "zh";
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


        private void trayMenuShowPreview_Click(object sender, EventArgs e)
        {
            TogglePreview();
        }

        private void trayMenuPixelScale_Click(object sender, EventArgs e)
        {
            Settings.Preview.PixelScale =
                trayMenuPixelScale.Checked =
                !trayMenuPixelScale.Checked;
        }

        private void trayMenuAutoPin_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // ReSharper disable once PossibleNullReferenceException
            item.Checked = !item.Checked;
            if (settingLoaded)
            {
                Settings.Base.AutoPin = item.Checked;
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
        private void trayMenuHotkey_Click(object sender, EventArgs e)
        {
            try
            {
                var form = Application.OpenForms["HotkeyForm"] ?? new HotkeyForm();

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
        private void trayMenuAutoStart_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // ReSharper disable once PossibleNullReferenceException
            item.Checked = !item.Checked;

            // 写注册表
            Settings.Base.Autostart = item.Checked;
        }

        private void trayMenuCheckUpdate_Click(object sender, EventArgs e)
        {
            UpdateForm.ShowWindow();
        }

        private void trayMenuCheckUpdateOnStartup_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // ReSharper disable once PossibleNullReferenceException
            item.Checked = !item.Checked;

            Settings.Update.CheckOnStartup = item.Checked;
        }

        private void trayMenuOpenConfigFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Settings.FullName))
                {
                    File.Create(Settings.FullName).Close();
                }

                Process.Start(Settings.FullName);
            }
            catch (Exception ex)
            {
                tray.ShowBalloonTip(5000, "无法打开配置文件", ex.Message, ToolTipIcon.Warning);
            }
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

        private void ToggleCopyPolicy()
        {
            trayMenuCopyPolicyHexValueOnly.Checked =
                trayMenuCopyPolicyRgbValueOnly.Checked =
                    Settings.Base.HexValueOnly =
                        Settings.Base.RgbValueOnly =
                            !Settings.Base.HexValueOnly;
        }

        private void TogglePreview()
        {
            Settings.Preview.Visible = trayMenuShowPreview.Checked = previewForm.Visible = !previewForm.Visible;
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
            colorPicker.CustomColors = Settings.Base.CustomColors;

            trayMenuShowColorPicker.Checked = true;

            if (DialogResult.OK == colorPicker.ShowDialog(this))
            {
                var cl = colorPicker.Color;
                ColorHistory.Record(cl);
                Util.SetClipboard(Handle, string.Format("#{0:X2}{1:X2}{2:X2}", cl.R, cl.G, cl.B));

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
                    trayMenuFormatMini.Checked = true;
                    trayMenuFormatStandard.Checked = false;
                    trayMenuFormatExtention.Checked = false;

                    lbHex.Width = 68;
                    lbRgb.Visible = false;
                    pnExt.Visible = false;
                    Height = 20;
                    Width = 88;
                    break;
                case FormatMode.Standard:
                    trayMenuFormatMini.Checked = false;
                    trayMenuFormatStandard.Checked = true;
                    trayMenuFormatExtention.Checked = false;

                    lbHex.Width = 68;
                    lbRgb.Width = 140;
                    lbRgb.Left = 68;
                    lbRgb.Top = 0;
                    lbRgb.Visible = true;
                    pnExt.Visible = false;
                    Height = 20;
                    Width = 208;
                    break;
                case FormatMode.Extention:
                    trayMenuFormatMini.Checked = false;
                    trayMenuFormatStandard.Checked = false;
                    trayMenuFormatExtention.Checked = true;

                    lbHex.Width = 180;
                    lbRgb.Width = 180;
                    lbRgb.Left = 0;
                    lbRgb.Top = 20;
                    lbRgb.Visible = true;
                    pnExt.Visible = true;
                    Height = 100;
                    Width = 180;
                    break;
            }
            currentFormatMode = mode;

            if (settingLoaded)
            {
                Settings.Main.Format = mode;
            }
        }

        private void SwitchHsiAlgorithm(HsiAlgorithm algorithm)
        {
            trayMenuHsiAlgorithmGeometry.Checked = false;
            trayMenuHsiAlgorithmAxis.Checked = false;
            trayMenuHsiAlgorithmSegment.Checked = false;
            trayMenuHsiAlgorithmBajon.Checked = false;
            trayMenuHsiAlgorithmStandard.Checked = false;
            switch (algorithm)
            {
                case HsiAlgorithm.Geometry:
                    trayMenuHsiAlgorithmGeometry.Checked = true;
                    break;
                case HsiAlgorithm.Axis:
                    trayMenuHsiAlgorithmAxis.Checked = true;
                    break;
                case HsiAlgorithm.Segment:
                    trayMenuHsiAlgorithmSegment.Checked = true;
                    break;
                case HsiAlgorithm.Bajon:
                    trayMenuHsiAlgorithmBajon.Checked = true;
                    break;
                case HsiAlgorithm.Standard:
                    trayMenuHsiAlgorithmStandard.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("algorithm", algorithm, null);
            }
            Settings.Main.HsiAlgorithm = currentHsiAlgorithm = algorithm;
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
                var result = Util.SetClipboard(Handle, doubleClick ?
                    (trayMenuCopyPolicyRgbValueOnly.Checked ? lbRgb.Tag.ToString() : lbRgb.Text) :
                    (trayMenuCopyPolicyHexValueOnly.Checked ? lbHex.Tag.ToString() : lbHex.Text));

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
    }
}
