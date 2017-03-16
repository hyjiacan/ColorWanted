﻿using ColorWanted.enums;
using ColorWanted.ext;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private bool iniloaded;
        private readonly Screen screen;
        private HelpForm helpForm;
        private PreviewForm previewForm;
        private ColorDialog colorPicker;


        /// <summary>
        /// 控制是否停止绘制预览窗口，为true时就停止绘制预览窗口
        /// 为true时可以在预览窗口上取色
        /// </summary>
        private bool stopDrawPreview;

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

        // 上次复制的时间
        private DateTime lastCopyTime;


        private readonly StringBuilder hexBuffer;

        private readonly StringBuilder rgbBuffer;

        public MainForm()
        {
            InitializeComponent();

            screen = Screen.PrimaryScreen;

            currentMode = DisplayMode.Fixed;

            hexBuffer = new StringBuilder(8, 8);
            rgbBuffer = new StringBuilder(10, 16);

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

        private void carettimer_Tick(object sender, EventArgs e)
        {
            if (currentMode != DisplayMode.Follow)
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

        private void colortimer_Tick(object sender, EventArgs e)
        {
            if (!stopDrawPreview && previewForm.MouseOnMe)
            {
                // 如果没有停止预览，并且鼠标在预览窗口上
                // 就不取色，这是为了防止因循环取色导致过高的资源占用
                return;
            }
            if (!iniloaded)
            {
                // 不晓得为啥，在启动时加载Visible会被覆盖，所在放到这里来了
                SwitchMode(Settings.Mode);

                iniloaded = true;
            }

            Color cl = ColorUtil.GetColor(MousePosition);

            // 如果光标位置不变，颜色也不变，就不绘制了
            if (MousePosition.Equals(lastPosition) && cl.Equals(lastColor))
            {
                return;
            }

            lastPosition = MousePosition;
            lastColor = cl;

            hexBuffer.Clear();
            lbHex.Text =
            hexBuffer.AppendFormat("#{0:X2}{1:X2}{2:X2}", cl.R, cl.G, cl.B).ToString();

            rgbBuffer.Clear();
            lbRgb.Text =
            rgbBuffer.AppendFormat("RGB({0},{1},{2})", cl.R, cl.G, cl.B).ToString();

            if (trayMenuShowPreview.Checked && !stopDrawPreview)
            {
                DrawPreview(MousePosition);
            }

            if (trayMenuShowRgb.Checked)
            {
                lbRgb.BackColor = cl;
                lbRgb.ForeColor = ColorUtil.GetContrastColor(cl);
            }
            else
            {
                BackColor = cl;
            }
        }

        private static readonly Bitmap pic = new Bitmap(11, 11);
        private const int extend = 5;
        private static Graphics graphics;
        /// <summary>
        /// 画放大图，每个方向各取5个像素
        /// </summary>
        private void DrawPreview(Point pt)
        {
            if (graphics == null)
            {
                graphics = Graphics.FromImage(pic);
            }
            graphics.Clear(Color.White);
            graphics.CopyFromScreen(pt.X - extend, pt.Y - extend, 0, 0, pic.Size);
            graphics.Save();

            previewForm.UpdateImage(pic);
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
            if (Util.ShowBugReportForm(new Exception("xxxxxxx")) == DialogResult.OK)
            {
                Application.Exit();
            }
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

            // 复制颜色值  如果连续两次（间隔小于1秒），则复制RGB颜色值，否则复制HEX颜色值
            if (keyValue == HotKeyValue.CopyHexColor.AsInt())
            {
                var result = Util.SetClipboard(Handle,
                    (DateTime.Now - lastCopyTime).TotalSeconds >= 1
                    ? lbHex.Text
                    : lbRgb.Text);

                // 复制失败
                if (result != null)
                {
                    tray.ShowBalloonTip(5000,
                        "复制失败",
                        result,
                        ToolTipIcon.Error);
                }
                else
                {
                    lastCopyTime = DateTime.Now;
                }

                base.WndProc(ref m);
                return;
            }

            // 显示/隐藏RGB颜色值
            if (keyValue == HotKeyValue.CopyRgbColor.AsInt())
            {
                ToggleRgb();
                base.WndProc(ref m);
                return;
            }

            // 切换显示模式
            if (keyValue == HotKeyValue.SwitchMode.AsInt())
            {
                SwitchMode();
                base.WndProc(ref m);
                return;
            }

            // 打开预览窗口
            if (keyValue == HotKeyValue.ShowPreview.AsInt())
            {
                TogglePreview();
                base.WndProc(ref m);
                return;
            }

            // 显示/隐藏调色板
            if (keyValue == HotKeyValue.ShowColorPicker.AsInt())
            {
                ShowColorPicker();
                base.WndProc(ref m);
                return;
            }

            // 绘制预览窗口
            if (keyValue == HotKeyValue.DrawPreview.AsInt())
            {
                stopDrawPreview = !stopDrawPreview;
                previewForm.ToggleCursor(stopDrawPreview);
                base.WndProc(ref m);
                return;
            }

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
            if (Settings.ShowRgb)
            {
                ToggleRgb();
            }

            if (!trayMenuFollowCaret.Checked)
            {
                FixedPosition();
            }

            // 加载配置
            trayMenuAutoPin.Checked = Settings.AutoPin;

            trayMenuShowRgb.Checked = Settings.ShowRgb;

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

            if (iniloaded)
            {
                Settings.Location = Location;
            }
        }


        #region 托盘菜单


        private void trayMenuHideWindow_Click(object sender, EventArgs e)
        {
            SwitchMode(DisplayMode.Hidden);
        }

        private void trayMenuFixed_Click(object sender, EventArgs e)
        {
            SwitchMode(DisplayMode.Fixed);
        }

        private void trayMenuFollowCaret_Click(object sender, EventArgs e)
        {
            SwitchMode(DisplayMode.Follow);
        }

        private void trayMenuShowHelp_Click(object sender, EventArgs e)
        {
            if (helpForm == null)
            {
                helpForm = new HelpForm();
            }
            helpForm.Show();
        }

        private void trayMenuShowRgb_Click(object sender, EventArgs e)
        {
            ToggleRgb();
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
            if (iniloaded)
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

        private void ToggleRgb()
        {
            if (!Visible)
            {
                return;
            }
            BringToFront();
            bool showrgb = trayMenuShowRgb.Checked = !trayMenuShowRgb.Checked;
            lbRgb.Visible = showrgb;
            Width = showrgb ? 208 : 88;

            if (iniloaded)
            {
                Settings.ShowRgb = showrgb;
            }
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
        /// 当前的显示模式
        /// </summary>
        private DisplayMode currentMode;
        /// <summary>
        /// 激活显示模式
        /// </summary>
        private void SwitchMode()
        {
            // 下一个要激活的模式
            DisplayMode mode = (DisplayMode)Enum.ToObject(typeof(DisplayMode), currentMode + 1);
            // 看加了后这个模式有没有定义，如果没有定义，则跳转到隐藏模式
            if (!Enum.IsDefined(typeof(DisplayMode), mode))
            {
                mode = DisplayMode.Hidden;
            }
            SwitchMode(mode);
        }

        private void SwitchMode(DisplayMode mode)
        {
            // 切换模式时，先停止取色窗口位置定时器
            caretTimer.Stop();

            if (mode == DisplayMode.Hidden)
            {
                trayMenuHideWindow.Checked = true;
                trayMenuFollowCaret.Checked = false;
                trayMenuFixed.Checked = false;

                trayMenuShowPreview.Enabled = false;
                trayMenuShowRgb.Enabled = false;
                trayMenuRestoreLocation.Enabled = false;
                trayMenuAutoPin.Enabled = false;

                Hide();
            }
            else
            {

                trayMenuHideWindow.Checked = false;
                trayMenuFollowCaret.Checked = false;
                trayMenuFixed.Checked = false;

                trayMenuShowRgb.Enabled = true;
                trayMenuShowPreview.Enabled = true;

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
            if (iniloaded)
            {
                Settings.Mode = mode;
            }
            currentMode = mode;
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
    }
}
