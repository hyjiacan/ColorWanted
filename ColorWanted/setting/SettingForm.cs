using ColorWanted.ext;
using ColorWanted.hotkey;
using ColorWanted.theme;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorWanted.setting
{
    public partial class SettingForm : Form
    {
        private List<SettingModule> modules;
        private ThemeForm themeForm;

        private static SettingForm instance;
        public static SettingForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new SettingForm();
                }
                return instance;
            }
        }

        private SettingForm()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            base.Show();
            BringToFront();
        }

        private void LoadSettings()
        {
            modules = new List<SettingModule>();

            var settingsType = typeof(Settings);
            var baseNamespace = settingsType.FullName;
            var members = settingsType.GetMembers(BindingFlags.Public | BindingFlags.Static);

            // 找到所有的配置模块和配置项
            foreach (var member in members)
            {
                var attr = member.GetCustomAttribute<SettingModuleAttribute>();
                if (attr == null)
                {
                    continue;
                }

                var moduleType = Type.GetType($"{baseNamespace}+{member.Name}");

                var items = moduleType.GetProperties(BindingFlags.Public | BindingFlags.Static)
                    .Where(prop => prop != null && prop.GetCustomAttribute<SettingItemAttribute>() != null);

                if (!items.Any())
                {
                    continue;
                }

                modules.Add(new SettingModule
                {
                    Name = attr.Name,
                    TypeName = member.Name,
                    Items = items.ToList()
                });
            }

            modules.Sort((a, b) => a.TypeName.CompareTo(b.TypeName));
        }

        private void UpdateSettings()
        {
            this.SuspendLayout();

            this.tbFilePath.Text = Settings.FullName;

            foreach (var module in modules)
            {
                var group = new GroupBox
                {
                    AutoSize = true,
                    Text = module.Name,
                    MinimumSize = new Size(500, 0),
                    Padding = new Padding(20)
                };

                var panel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    MinimumSize = new Size(400, 0)
                };

                panel.Controls.AddRange(module.Items.Select(item => CreateControl(module, item)).ToArray());

                group.Controls.Add(panel);

                pnContainer.Controls.Add(group);
            }


            this.ResumeLayout(false);
        }

        private Control RenderBool(SettingModule module, PropertyInfo item)
        {
            var attr = item.GetCustomAttribute<SettingItemAttribute>();
            var name = attr.Name;
            var checkbox = new CheckBox
            {
                Text = name,
                Checked = (bool)item.GetValue(module),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(0, 5, 0, 5)
            };
            if (attr.RestartRequired)
            {
                checkbox.ForeColor = Color.Red;
            }
            checkbox.CheckedChanged += (sender, e) =>
            {
                item.SetValue(module, checkbox.Checked);
            };
            return checkbox;
        }
        private Control RenderEnum(SettingModule module, PropertyInfo item)
        {
            var attr = item.GetCustomAttribute<SettingItemAttribute>();
            var name = attr.Name;

            var itemContainer = new Panel
            {
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 10)
            };

            var label = new Label
            {
                Text = name,
                Left = 0,
                Top = 0,
                AutoSize = true
            };

            if (attr.RestartRequired)
            {
                label.ForeColor = Color.Red;
            }
            itemContainer.Controls.Add(label);

            var enumItems = item.PropertyType.GetFields()
                .Where(field => field.Name != "value__")
                .Select(field =>
                {
                    var desc = field.GetCustomAttribute<EnumDescriptionAttribute>();
                    desc.Value = field.GetValue(item).ToString();
                    return desc;
                }).ToArray();

            var dropdown = new ComboBox
            {
                Left = 0,
                Top = 16,
                MinimumSize = new Size(400, 0),
                DropDownStyle = ComboBoxStyle.DropDownList,
                ValueMember = "Value",
                DisplayMember = "Description"
            };

            dropdown.Items.AddRange(enumItems);

            var val = item.GetValue(module).ToString();
            dropdown.SelectedItem = enumItems.First(i => i.Value == val);

            // 鼠标离开时，使其推动焦点，以避免选项被意外选择
            dropdown.MouseLeave += (sender, e) =>
            {
                dropdown.Parent.Focus();
            };

            itemContainer.Controls.Add(dropdown);

            dropdown.SelectedIndexChanged += (sender, e) =>
            {
                item.SetValue(module, Enum.Parse(item.PropertyType, ((EnumDescriptionAttribute)dropdown.SelectedItem).Value));
            };
            return itemContainer;
        }

        private Control RenderNumber(SettingModule module, PropertyInfo item, char type)
        {
            var attr = item.GetCustomAttribute<SettingItemAttribute>();
            var name = attr.Name;

            var itemContainer = new Panel
            {
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 10)
            };
            var label = new Label
            {
                Text = name,
                Left = 0,
                Top = 0,
                AutoSize = true
            };
            if (attr.RestartRequired)
            {
                label.ForeColor = Color.Red;
            }
            itemContainer.Controls.Add(label);

            var textbox = new NumericUpDown
            {
                Left = 0,
                Top = 16,
                Width = 400,
                Minimum = 0,
                Maximum = type == 'i' ? int.MaxValue : long.MaxValue
            };
            textbox.Value = long.Parse(item.GetValue(module).ToString());
            itemContainer.Controls.Add(textbox);

            textbox.ValueChanged += (sender, e) =>
            {
                if(type == 'i')
                {
                    item.SetValue(module, Convert.ToInt32(textbox.Value));
                }
                else
                {
                    item.SetValue(module, Convert.ToInt64(textbox.Value));
                }                
            };

            return itemContainer;
        }

        private Control RenderInput(SettingModule module, PropertyInfo item)
        {
            var attr = item.GetCustomAttribute<SettingItemAttribute>();
            var name = attr.Name;

            var itemContainer = new Panel
            {
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 10)
            };

            var label = new Label
            {
                Text = name,
                Left = 0,
                Top = 0,
                AutoSize = true
            };
            if (attr.RestartRequired)
            {
                label.ForeColor = Color.Red;
            }
            itemContainer.Controls.Add(label);

            var textbox = new TextBox
            {
                Text = item.GetValue(module).ToString(),
                Left = 0,
                Top = 16,
                Width = 400
            };
            itemContainer.Controls.Add(textbox);

            // 确定按钮
            var btn = new Button
            {
                Text = "确定",
                Left = 405,
                Top = 16,
                Width = 40,
                FlatStyle = FlatStyle.Flat
            };

            btn.Click += (sender, e) =>
            {
                item.SetValue(module, textbox.Text);
            };

            itemContainer.Controls.Add(btn);

            return itemContainer;
        }

        private Control CreateControl(SettingModule module, PropertyInfo item)
        {
            var type = item.PropertyType;

            if (type == typeof(bool))
            {
                return RenderBool(module, item);
            }

            if (type.IsEnum)
            {
                return RenderEnum(module, item);
            }

            if (type == typeof (int))
            {
                return RenderNumber(module, item, 'i');
            }

            if (type == typeof(long))
            {
                return RenderNumber(module, item, 'l');
            }

            return RenderInput(module, item);
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            if (themeForm == null || themeForm.IsDisposed)
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

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Settings.FullName))
                {
                    File.Create(Settings.FullName).Close();
                    Process.Start(Settings.FullName);
                }
            }
            catch (Exception ex)
            {
                util.Logger.Warn(ex);
                MainForm.Instance.ShowBalloon(5000, "无法打开配置文件", ex.Message, ToolTipIcon.Warning);
            }
        }

        private void btnHotkey_Click(object sender, EventArgs e)
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

        private void SettingForm_Load(object sender, EventArgs e)
        {
            if (Settings.I18n.Lang == "zh")
            {
                rbLangZh.Checked = true;
                rbLangEn.Checked = false;
            }
            else
            {
                rbLangZh.Checked = false;
                rbLangEn.Checked = true;
            }

            Task.Factory.StartNew(() =>
            {
                LoadSettings();

                this.InvokeMethod(UpdateSettings);
            });
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbLangZh_CheckedChanged(object sender, EventArgs e)
        {
            Settings.I18n.Lang = "zh";
            rbLangEn.Checked = false;
        }

        private void rbLangEn_CheckedChanged(object sender, EventArgs e)
        {
            Settings.I18n.Lang = "en";
            rbLangZh.Checked = false;
        }
    }

    class SettingModule
    {
        public string Name { get; set; }

        public string TypeName { get; set; }

        public List<PropertyInfo> Items { get; set; }
    }
}
