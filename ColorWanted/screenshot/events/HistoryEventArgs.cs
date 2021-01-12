using System;

namespace ColorWanted.screenshot.events
{
    /// <summary>
    /// 编辑历史事件
    /// </summary>
    public class HistoryEventArgs : EventArgs
    {
        public int HistoryCount { get; private set; }
        public int RedoHistoryCount { get; private set; }

        public HistoryEventArgs(int historyCount, int redoHistoryCount)
        {
            HistoryCount = historyCount;
            RedoHistoryCount = redoHistoryCount;
        }
    }
}
