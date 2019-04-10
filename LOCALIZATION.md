# 多语言支持 Multiple language supported

ColorWanted use JSON to make multiple language.
此程序通过JSON格式文件实现多语言支持。

Inner language:
内置支持语言如下：

- 中文
- English

## 结构 Structure

Language file contains 3 parts: language name, author info, and translations.
语言描述文件使用`JSON`格式存储，其中包含语言名称，作者信息，以及语言翻译内容三部分。

```json
{
  "locale": "zh-CN",
  "name": "简体中文",
  "authors": [{
      "name": "hyjiacan",
      "mail": "hyjiacan@163.com",
      "homepage": ""
    }
  ],
  "resource": {
    "窗体1名称/Form1 name": {
      "控件1名称/Control1 name": {
        "控件1的属性名称1/Property1 name": "控件1的属性值1/Property1 value",
        "控件1的属性名称2/Property2 name": "控件1的属性值2/Property2 value",
        "控件1的属性名称n/Propertyn name": "控件1的属性值n/Propertyn value"
      },
      "控件2名称/Control2 name": {
        "控件2的属性名称1/Property name": "控件2的属性值1/Property1 value",
        "控件2的属性名称2/Property name": "控件2的属性值2/Property2 value",
        "控件2的属性名称n/Property name": "控件2的属性值n/Propertyn value"
      }
    },    
    "窗体2名称/Form2 name": {
      "控件1名称/Control1 name": {
        "控件1的属性名称1/Property1 name": "控件1的属性值1/Property1 value",
        "控件1的属性名称2/Property2 name": "控件1的属性值2/Property2 value",
        "控件1的属性名称n/Propertyn name": "控件1的属性值n/Propertyn value"
      },
      "控件2名称/Control2 name": {
        "控件2的属性名称1/Property1 name": "控件2的属性值1/Property1 value",
        "控件2的属性名称2/Property2 name": "控件2的属性值2/Property2 value",
        "控件2的属性名称n/Propertyn name": "控件2的属性值n/Propertyn value"
      }
    }
  }
}
```

### 语言名称 Language name

`locale` is the name of language, `name` is human readable name, write in local language.
其中，`locale`表示语言的`i18n`名称，`name`表示语言的描述名称，一般使用本地语言书写。

### 作者信息 Author info

Author info `authors` is a array, what means can store more than one author's info.
作者信息`authors`是一个数组节点，也就是说一个语言文件内可以填写多个作者的信息。

### 本地语言翻译 Translation

Translation put in node `resource`, structure like this: Form name -> Control name -> Control property name -> Control property value.
翻译内容都存放在`resource`节点下，其结构为：窗体名称 -> 控件名称 -> 控件属性名称 -> 控件属性值 。

- `$this` means form self
  当设置窗体本身的属性时，控件名称使用 `$this`
- While translate non-control string, control name means `resource name`, and property should be empty string `""`
  当设置非控件资源时，控件名称使用`资源名称`，属性名称写为空串 `""`

Here is the full sample [en.json](ColorWanted/Resources/langs/en.json)
使用完整示例参见 [zh.json](ColorWanted/Resources/langs/zh.json)


## 自定义 Customize

You can customize language, just put the language file in folder *C:\Users\YOUR USERNAME\AppData\Roaming\ColorWanted\i18n*, sub folder is ignored.
自定义的多语言文件存放在 *C:\Users\你的用户名\AppData\Roaming\ColorWanted\i18n* 目录下，放在子目录无效。
