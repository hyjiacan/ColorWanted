# TODO LIST

- [x] 截图占用内存高
- [x] 截图启动慢
- [x] 截图工具条位置优化
- [ ] 截图工具条拖动支持
- [x] 屏幕录制时，支持设置帧速率
- [x] 屏幕录制时，支持设置质量(会影响生成文件大小)
- [ ] 功能插件化（截图，录屏，剪贴板监视）
- [ ] [高DPI 支持](https://docs.microsoft.com/zh-cn/dotnet/framework/winforms/automatic-scaling-in-windows-forms)
  考虑通过读取当前的系统缩放因子来计算
  同时将界面上的控件大小，使用变量存放起来，以在加载时自动应用缩放因子