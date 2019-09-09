using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorWanted.ext
{
    public class ButtonGroup : StackPanel
    {
        public object Value
        {
            get
            {
                return GetActiveButton();
            }
            set
            {
                SetActiveButton(value);
            }
        }

        public Color ActiveColor { get; set; }

        public event RoutedEventHandler Changed;

        private SolidColorBrush borderBrush;

        private static readonly Thickness activeThickness = new Thickness(2);
        private static readonly Thickness deactiveThickness = new Thickness(0);

        private SolidColorBrush ActiveBrush
        {
            get
            {
                if (borderBrush == null)
                {
                    borderBrush = new SolidColorBrush(Color.FromArgb(180, 80, 80, 240));
                }
                return borderBrush;
            }
        }

        public ButtonGroup()
        {
            Orientation = Orientation.Horizontal;
            Loaded += ButtonGroup_Loaded;
        }

        public void AddRange(params Button[] buttons)
        {
            foreach (var item in buttons)
            {
                Children.Add(item);
            }
        }

        private void ButtonGroup_Loaded(object sender, RoutedEventArgs e)
        {
            var margin = new Thickness(1, 0, 1, 0);
            for (int i = 0; i < Children.Count; i++)
            {
                var btn = (Button)Children[i];
                btn.Click += Btn_Click;
                btn.BorderThickness = deactiveThickness;
                btn.BorderBrush = ActiveBrush;
                btn.Margin = margin;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton(((Button)sender).Tag);
        }

        private void SetActiveButton(object value)
        {
            if (value.ToString() == Value.ToString())
            {
                return;
            }
            foreach (var item in Children)
            {
                var btn = (Button)item;
                if (btn.Tag.ToString() == value.ToString())
                {
                    btn.BorderThickness = activeThickness;
                    Changed.Invoke(this, new RoutedEventArgs { Source = btn });
                }
                else
                {
                    btn.BorderThickness = deactiveThickness;
                }
            }
        }

        private object GetActiveButton()
        {
            foreach (var item in Children)
            {
                var btn = (Button)item;
                var border = btn.BorderThickness;
                if (border.Bottom == 3)
                {
                    return btn.Tag;
                }
            }
            return null;
        }
    }
}
