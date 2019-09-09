using ColorWanted.ext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorWanted.screenshot
{
    /// <summary>
    /// Screenshot.xaml 的交互逻辑
    /// </summary>
    public partial class ScreenshotWindow : Window
    {
        /// <summary>
        /// 截图得到的图片对象
        /// </summary>
        private Bitmap image;

        /// <summary>
        /// 记录上次的选区
        /// </summary>
        private Rect lastSelectedRect;

        /// <summary>
        /// 渲染计数，用于降低选区大小或位置变化时的渲染频次
        /// </summary>
        private int counter = 0;

        /// <summary>
        /// 渲染频次，每5次请求渲染一次
        /// </summary>
        private const int RENDER_TICK = 3;

        /// <summary>
        /// 是否正在编辑，根据编辑层是否可见
        /// </summary>
        public bool Editing => canvasEdit.Visibility == Visibility.Visible;

        private ButtonGroup drawShape;

        private ButtonGroup drawLineStyle;

        private ButtonGroup drawColor;

        private Button drawFont;

        private Slider drawWidth;

        public ScreenshotWindow()
        {
            InitializeComponent();
        }

        public void Show(Bitmap img, int screenWidth, int screenHeight)
        {
            Left = 0;
            Top = 0;

            canvasEdit.Width = canvasMask.Width = Width = screenWidth;
            canvasEdit.Height = canvasMask.Height = Height = screenHeight;

            //Topmost = true;

            image = img;

            maskBackground.ImageSource = img.AsOpacity(0.7f).AsResource();

            //Refresh();
            Show();
        }

        private void CanvasMask_OnDraw(object sender, DrawEventArgs e)
        {
            if (e.IsEmpty)
            {
                selectArea.Visibility = Visibility.Hidden;
                return;
            }

            if (e.State == DrawState.Start)
            {
                return;
            }
            var area = e.Area;
            if (area.IsEmpty || area.Width == 0 || area.Height == 0)
            {
                selectArea.Visibility = Visibility.Hidden;
                return;
            }

            if (e.State == DrawState.Move)
            {
                counter++;
                if (counter % RENDER_TICK == 0)
                {
                    UpdateSelectArea(area);
                }
                return;
            }

            // 肯定是 DrawState.End
            counter = 0;
            // 立即执行
            UpdateSelectArea(area);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BuildToolbar();
        }

        #region 工具条

        /// <summary>
        /// 生成工具条
        /// </summary>
        private void BuildToolbar()
        {
            drawShape = new ButtonGroup
            {
                Visibility = Visibility.Hidden
            };
            drawShape.Changed += DrawShape_Changed; ;
            drawShape.AddRange(
                BuildImageButton(Properties.Resources.text, DrawShapes.Text),
                BuildImageButton(Properties.Resources.line, DrawShapes.Line),
                BuildImageButton(Properties.Resources.curve, DrawShapes.Curve),
                BuildImageButton(Properties.Resources.ellipse, DrawShapes.Ellipse),
                BuildImageButton(Properties.Resources.rect, DrawShapes.Rectangle)
            );
            mainToolbar.Items.Add(drawShape);

            mainToolbar.Items.Add(BuildImageButton(Properties.Resources.edit, OnEditClick));
            mainToolbar.Items.Add(new Separator());
            mainToolbar.Items.Add(BuildImageButton(Properties.Resources.save, OnSaveClick));
            mainToolbar.Items.Add(BuildImageButton(Properties.Resources.ok, OnOkClick));
            mainToolbar.Items.Add(BuildImageButton(Properties.Resources.cancel, OnCancelClick));

            drawLineStyle = new ButtonGroup();
            drawLineStyle.AddRange(
                BuildImageButton(Properties.Resources.dot_line, LineStyles.Dotted),
                BuildImageButton(Properties.Resources.dash_line, LineStyles.Dashed),
                BuildImageButton(Properties.Resources.solid_line, LineStyles.Solid)
            );
            extToolbar.Items.Add(drawLineStyle);
            mainToolbar.Items.Add(new Separator());

            // 线宽
            drawWidth = new Slider
            {
                Minimum = 1,
                Maximum = 40,
                Width = 80
            };
            extToolbar.Items.Add(drawWidth);
            mainToolbar.Items.Add(new Separator());

            drawColor = new ButtonGroup();
            drawColor.AddRange(
                BuildColorButton(Colors.Red),
                BuildColorButton(Colors.Orange),
                BuildColorButton(Colors.Green),
                BuildColorButton(Colors.Olive),
                BuildColorButton(Colors.Blue),
                BuildColorButton(Colors.Cyan),
                BuildColorButton(Colors.Yellow),
                BuildColorButton(Colors.Black),
                BuildColorButton(Colors.White)
            );
            extToolbar.Items.Add(drawColor);
            mainToolbar.Items.Add(new Separator());

            drawFont = new Button
            {
                Content = "T",
                Width = 24,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            drawFont.Click += OnFontClick;

            extToolbar.Items.Add(drawFont);
        }

        private void DrawShape_Changed(object sender, RoutedEventArgs e)
        {
            if (!Enum.TryParse<DrawShapes>(((Button)e.Source).Tag.ToString(), out DrawShapes type))
            {
                return;
            }

            if (type == DrawShapes.Text)
            {
                drawLineStyle.Visibility = Visibility.Hidden;
                drawWidth.Visibility = Visibility.Hidden;
                drawFont.Visibility = Visibility.Visible;
                return;
            }

            drawFont.Visibility = Visibility.Hidden;
            drawWidth.Visibility = Visibility.Visible;
            drawLineStyle.Visibility = Visibility.Visible;
        }

        private void OnFontClick(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FontDialog()
            {
                ShowEffects = false
            };
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            var btn = (Button)sender;
            var font = dialog.Font;
            btn.FontFamily = new System.Windows.Media.FontFamily(font.FontFamily.Name);
            btn.Tag = font.SizeInPoints;
            btn.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Normal;
            btn.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;
        }

        private void OnEditClick(object sender, RoutedEventArgs e)
        {

        }
        private void OnSaveClick(object sender, RoutedEventArgs e)
        {

        }
        private void OnOkClick(object sender, RoutedEventArgs e)
        {

        }
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {

        }

        private Button BuildImageButton(Bitmap image, object tag)
        {
            return new Button
            {
                Content = new System.Windows.Controls.Image
                {
                    Source = image.AsResource(),
                    Tag = tag
                }
            };
        }

        private Button BuildImageButton(Bitmap image, RoutedEventHandler handler)
        {
            var btn = new Button
            {
                Content = new System.Windows.Controls.Image
                {
                    Source = image.AsResource()
                }
            };
            btn.Click += handler;
            return btn;
        }

        private Button BuildColorButton(System.Windows.Media.Color color)
        {
            return new Button
            {
                Width = 20,
                Height = 20,
                Background = new SolidColorBrush(color),
                Tag = color.ToString()
            };
        }
        #endregion

        private void UpdateSelectArea(Rect selectedRect)
        {
            if (lastSelectedRect == selectedRect)
            {
                return;
            }
            lastSelectedRect = selectedRect;

            var img = image.Cut(selectedRect).AsResource();

            selectArea.Source = img;
            selectArea.SetLocation(selectedRect.X, selectedRect.Y);
            selectArea.Visibility = Visibility.Visible;
        }
    }
}
