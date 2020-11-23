using ColorWanted.Properties;
using ColorWanted.setting;
using ColorWanted.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
            LangDir = Path.Combine(Glob.AppDataPath, "i18n");
            if (!Directory.Exists(LangDir))
            {
                Directory.CreateDirectory(LangDir);
            }
            language = LoadLanguages(Settings.I18n.Lang);

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
        /// 获取可用的自定义语言
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Language> GetLocalLangs()
        {
            return Directory.GetFiles(LangDir, "*.json", SearchOption.TopDirectoryOnly)
                   .Select(file =>
                   {
                       var content = File.ReadAllText(Path.Combine(LangDir, file));
                       try
                       {
                           return Json.Deserialize<Language>(content);
                       }
                       catch (Exception ex)
                       {
                           Logger.Warn(ex);
                           // ignore the exception
                           return null;
                       }
                   })
                   // 筛选可用的语言包
                   .Where(lang => lang != null
                   && !string.IsNullOrWhiteSpace(lang.Locale)
                   && !string.IsNullOrWhiteSpace(lang.Name)
                   && lang.Resource != null);
        }

        /// <summary>
        /// 根据指定的语言加载内置语言包
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        private static Language GetInnerLang(string locale)
        {
            var content = (locale != null && locale.StartsWith("zh")) ? Resources.zh : Resources.en;
            return Json.Deserialize<Language>(content);
        }

        /// <summary>
        /// 加载语言
        /// </summary>
        /// <param name="locale">要加载的语言名称，不指定时加载默认语言(中文)</param>
        /// <returns></returns>
        private static Language LoadLanguages(string locale = null)
        {
            // 本地的自定义语言文件
            var langs = GetLocalLangs();

            // 没有指定时，使用本地语言
            if (string.IsNullOrWhiteSpace(locale))
            {
                locale = System.Globalization.CultureInfo.InstalledUICulture.Name;
            }

            locale = locale.ToLower();

            // 看看本地的自定义语言中有没有本地语言(localization)或指定的语言
            // 如果没有可用的语言包，加载内置的
            var language = langs.FirstOrDefault(lang =>
            {
                var l = lang.Locale.ToLower();
                return locale == l || locale.StartsWith(l) || l.StartsWith(locale);
            }) ?? GetInnerLang(locale);

            return language;
        }
    }
}
