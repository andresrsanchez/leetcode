using System;
using System.Threading;

namespace leetcode
{
    public class PrintInOrderLooped
    {
        // volatile idea from https://hezhigang.github.io/2019/08/08/LeetCode-Concurrency-Print-in-Order/
        // i was using static (😒)

        private volatile int _i = 0;

        public void First(Action printFirst)
        {
            printFirst();
            _i = 1;
        }

        public void Second(Action printSecond)
        {
            while (_i == 0) { }
            printSecond();
            _i = 2;
        }

        public void Third(Action printThird)
        {
            while (_i == 0 || _i == 1) { }
            printThird();
        }
    }

    public class PrintInOrderEvent
    {
        private AutoResetEvent _autoResetEvent1 = new AutoResetEvent(false);
        private AutoResetEvent _autoResetEvent2 = new AutoResetEvent(false);

        public void First(Action printFirst)
        {
            printFirst();
            _autoResetEvent1.Set();
        }

        public void Second(Action printSecond)
        {
            _autoResetEvent1.WaitOne();
            printSecond();
            _autoResetEvent2.Set();
        }

        public void Third(Action printThird)
        {
            _autoResetEvent2.WaitOne();
            printThird();
        }
    }
}
