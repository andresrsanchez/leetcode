using System;
using System.Threading;

namespace leetcode
{
    public class FooBarAutoResetEvent
    {
        private int _n;
        private AutoResetEvent _autoResetEvent = new AutoResetEvent(true);
        private AutoResetEvent _autoResetEvent1 = new AutoResetEvent(false);

        public FooBarAutoResetEvent(int n)
        {
            this._n = n;
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < _n; i++)
            {
                _autoResetEvent.WaitOne();
                printFoo();
                _autoResetEvent1.Set();
            }
        }

        public void Bar(Action printBar)
        {
            for (int i = 0; i < _n; i++)
            {
                _autoResetEvent1.WaitOne();
                printBar();
                _autoResetEvent.Set();
            }
        }
    }
}
