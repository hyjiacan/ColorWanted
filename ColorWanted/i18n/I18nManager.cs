using ColorWanted.Properties;
using ColorWanted.setting;
using ColorWanted.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorWanted.i18n
{
    internal class I18nManager
    {
        private static readonly Language language;
        private static readonly string LangDir;

        private readonly Dictionary<string, Dictionary<string, string>> resources;

        static I18nManager()
        {
            LangDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Application.ProductName, "i18n");
            if (!Directory.Exists(LangDir))
            {
                Directory.CreateDirectory(LangDir);
            }
            language = LoadLanguages(string.IsNullOrWhiteSpace(Settings.I18n.Lang) ?
                System.Globalization.CultureInfo.InstalledUICulture.Name : Settings.I18n.Lang);

        }
        public I18nManager(Type formType)
        {
            resources = language.Resource[formType.Name];
        }

        public void ApplyResources(Component control, string objectName)
        {
            if (!resources.ContainsKey(objectName))
            {
                return;
            }
            if (control is Form)
            {
                ApplyForm(control as Form, objectName);
                return;
            }
            if (control is NotifyIcon)
            {
                ApplyTray(control as NotifyIcon, objectName);
                return;
            }
            if (control is ContextMenuStrip)
            {
                ApplyContextMenu(control as ContextMenuStrip, objectName);
                return;
            }
            if (control is ToolStripMenuItem)
            {
                ApplyMenuItem(control as ToolStripMenuItem, objectName);
                return;
            }

            ApplyControl(control as Control, objectName);
        }

        private void ApplyForm(Form form, string objectName)
        {
            var define = resources[objectName];
            foreach (var prop in define.Keys)
            {
                var val = define[prop];
                switch (prop)
                {
                    case "Text":
                        form.Text = val;
                        break;
                }
            }
        }

        private void ApplyTray(NotifyIcon tray, string objectName)
        {
            var define = resources[objectName];
            foreach (var prop in define.Keys)
            {
                var val = define[prop];
                switch (prop)
                {
                    case "Text":
                        tray.Text = val;
                        break;
                    case "BalloonTipTitle":
                        tray.BalloonTipTitle = val;
                        break;
                    case "BalloonTipText":
                        tray.BalloonTipText = val;
                        break;
                }
            }
        }

        private void ApplyContextMenu(ContextMenuStrip menu, string objectName)
        {
            var define = resources[objectName];
            foreach (var prop in define.Keys)
            {
                var val = define[prop];
                switch (prop)
                {
                    case "Text":
                        menu.Text = val;
                        break;
                }
            }
        }

        private void ApplyMenuItem(ToolStripMenuItem menu, string objectName)
        {
            var define = resources[objectName];
            foreach (var prop in define.Keys)
            {
                var val = define[prop];
                switch (prop)
                {
                    case "Text":
                        menu.Text = val;
                        break;
                    case "ToolTipText":
                        menu.ToolTipText = val;
                        break;
                }
            }
        }

        private void ApplyControl(Control control, string objectName)
        {
            var define = resources[objectName];
            foreach (var prop in define.Keys)
            {
                var val = define[prop];
                switch (prop)
                {
                    case "Text":
                        control.Text = val;
                        break;
                }
            }
        }

        public string GetString(string key)
        {
            var temp = key.Split('.');
            var controlName = temp[0];
            var propertyName = "";
            if (temp.Length > 1)
            {
                propertyName = temp[1];
            }
            if (!resources.ContainsKey(controlName))
            {
                return "";
            }
            return resources[controlName].ContainsKey(propertyName) ? resources[controlName][propertyName] : "";
        }

        /// <summary>
        /// 获取可用的语言
        /// </summary>
        /// <returns></returns>
        private static string[] GetLangs()
        {
            return Directory.GetFiles(LangDir, "*.json", SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// 加载语言
        /// </summary>
        /// <param name="locale">要加载的语言名称，不指定时加载默认语言(中文)</param>
        /// <returns></returns>
        private static Language LoadLanguages(string locale = null)
        {
            //var langs = GetLangs();
            //if (!langs.Any())
            //{
            //    // 没有语言包，使用内置的英文
            //    return null;
            //}
            //// 默认的语言
            //var file = "zh.json";
            //if (!string.IsNullOrWhiteSpace(locale))
            //{
            //    var lang = langs.FirstOrDefault(l =>
            //    {
            //        var name = Path.GetFileNameWithoutExtension(l);
            //        return name == locale
            //        || name.StartsWith($"{locale}_")
            //        || name.StartsWith($"{locale}-")
            //        || locale.StartsWith($"{name}-");
            //    });
            //    if (!string.IsNullOrWhiteSpace(lang))
            //    {
            //        file = lang;

            //        // 使用第一个语言

            //    }
            //}

            //// 文件不存在
            //if (!File.Exists(file))
            //{
            //    // TODO 如果文件不存在，需要通过 http 去下载
            //    return null;
            //}



            //var content = File.ReadAllText(Path.Combine(LangDir, file));

            var content = (locale != null && locale.StartsWith("zh")) ? Resources.zh : Resources.en;

            return Json.Deserialize<Language>(Encoding.UTF8.GetString(content));
        }
    }
}
