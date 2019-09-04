using ColorWanted.screenshot;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
namespace ColorWanted.ext
{
    public static class CanvasExtension
    {
        /// <summary>
        /// int: 控件的index
        /// </summary>
        private static Dictionary<Canvas, Stack<int>> History;

        public static void Undo(this Canvas canvas)
        {
            if (History == null || !History.ContainsKey(canvas))
            {
                return;
            }
            var history = History[canvas];
            if (history == null || history.Count == 0)
            {
                return;
            }

            var index = history.Pop();
            canvas.Children.RemoveAt(index);
        }

        public static void Draw(this Canvas canvas, DrawRecord record)
        {
            if (History == null)
            {
                History = new Dictionary<Canvas, Stack<int>>();
            }
            Stack<int> history = null;
            if (History.ContainsKey(canvas))
            {

                history = History[canvas];
            }
            else
            {
                history = new Stack<int>();
                History.Add(canvas, history);
            }

            var element = record.GetDrawElement();
            if (element == null)
            {
                return;
            }

            history.Push(canvas.Children.Add(element));
            GC.Collect();
        }
    }
}
