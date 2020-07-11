using System;
using System.Collections.Generic;
using System.Text;
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
}
