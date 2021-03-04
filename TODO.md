# TODO LIST

- [ ] 截图工具，编辑支持马赛克，并支持马赛克级别
- [ ] 截图工具，文字编辑功能优化
- [ ] 剪贴板历史支持按日期删除(在左侧树上添加右键菜单)
- [ ] 更新窗口的动画由位置变化改变为渐入 `opacity`，以及对更新文件的校验
- [ ] 重构多语言支持(通过遍历控件文本的方式查找其它语言，并设置其值)
- [ ] 使用 `DrawingContext` 代替 `Graphics` 作为截图编辑支持
- [ ] 使用 WPF 重写看图工具
- [ ] 窗口作为任务栏工具条
- [ ] 修改关于窗口的反馈链接为 github 和 gitee，移除QQ群和邮箱

- [ ] 移除截图功用，推荐使用 Windows10 系统自带的 Snip&Sckech (快捷键 Windows+Shift+S)

[highdpi]: https://docs.microsoft.com/zh-cn/dotnet/framework/winforms/automatic-scaling-in-windows-forms

马赛克算法：

1. 指定像素范围
2. 找出范围内所有点的颜色
3. 在所有颜色中取随机值(或平均值)，并调整其色阈为原来的一半(可选)，并填充到范围内所有像素点上
4. 重复前面的2/3步骤，直至整个区域都被填充

