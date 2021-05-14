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

OS Version: Microsoft Windows NT 6.2.9200.0
.NET Version: 4.0.30319.42000
App Version: 4.2.1
Error Type: System.ArgumentException
Error message: Width must be non-negative.
Error Stack:    at System.Windows.Size.set_Width(Double value)
   at ColorWanted.screenshot.ImageEditor.ResizeBorder_Resize(Object sender, ResizeEventArgs e)
   at ColorWanted.screenshot.ResizeBorder.UpdateState(Point newPosition)
   at ColorWanted.screenshot.ImageEditor.container_MouseMove(Object sender, MouseEventArgs e)
   at System.Windows.RoutedEventArgs.InvokeHandler(Delegate handler, Object target)
   at System.Windows.RoutedEventHandlerInfo.InvokeHandler(Object target, RoutedEventArgs routedEventArgs)
   at System.Windows.EventRoute.InvokeHandlersImpl(Object source, RoutedEventArgs args, Boolean reRaised)
   at System.Windows.UIElement.RaiseEventImpl(DependencyObject sender, RoutedEventArgs args)
   at System.Windows.UIElement.RaiseTrustedEvent(RoutedEventArgs args)
   at System.Windows.Input.InputManager.ProcessStagingArea()
   at System.Windows.Input.InputManager.ProcessInput(InputEventArgs input)
   at System.Windows.Input.InputProviderSite.ReportInput(InputReport inputReport)
   at System.Windows.Interop.HwndMouseInputProvider.ReportInput(IntPtr hwnd, InputMode mode, Int32 timestamp, RawMouseActions actions, Int32 x, Int32 y, Int32 wheel)
   at System.Windows.Interop.HwndMouseInputProvider.FilterMessage(IntPtr hwnd, WindowMessage msg, IntPtr wParam, IntPtr lParam, Boolean& handled)
   at System.Windows.Interop.HwndSource.InputFilterMessage(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, Boolean& handled)
   at MS.Win32.HwndWrapper.WndProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, Boolean& handled)
   at MS.Win32.HwndSubclass.DispatcherCallbackOperation(Object o)
   at System.Windows.Threading.ExceptionWrapper.InternalRealCall(Delegate callback, Object args, Int32 numArgs)
   at System.Windows.Threading.ExceptionWrapper.TryCatchWhen(Object source, Delegate callback, Object args, Int32 numArgs, Delegate catchHandler)
   at System.Windows.Threading.Dispatcher.LegacyInvokeImpl(DispatcherPriority priority, TimeSpan timeout, Delegate method, Object args, Int32 numArgs)
   at MS.Win32.HwndSubclass.SubclassWndProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam)
   at System.Windows.Forms.UnsafeNativeMethods.DispatchMessageW(MSG& msg)
   at System.Windows.Forms.Application.ComponentManager.System.Windows.Forms.UnsafeNativeMethods.IMsoComponentManager.FPushMessageLoop(IntPtr dwComponentID, Int32 reason, Int32 pvLoopData)
   at System.Windows.Forms.Application.ThreadContext.RunMessageLoopInner(Int32 reason, ApplicationContext context)
   at System.Windows.Forms.Application.ThreadContext.RunMessageLoop(Int32 reason, ApplicationContext context)
   at ColorWanted.Program.Run(String[] args)
   at ColorWanted.Program.Main(String[] args)

