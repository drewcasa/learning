using System;
using System.Collections.Generic;
using System.Text;

namespace Learning
{
    public class MinStack
    {
        private List<int> _stack;
        private int _currMin = int.MaxValue;
        private int _index = -1;

        /** initialize your data structure here. */
        public MinStack()
        {
            _stack = new List<int>();
        }

        public void Push(int x)
        {
            _stack.Add(x);
            if (x < _currMin) _currMin = x;
            _index++;
        }

        public void Pop()
        {
            if (_currMin == _stack[_index])
            {
                _currMin = int.MaxValue;
                for (int i = 0; i <= _stack.Count - 2; i++)
                    if (_stack[i] < _currMin) _currMin = _stack[i];
            }

            _stack.RemoveAt(_index);
            _index--;
        }

        public int Top()
        {
            return _stack[_index];
        }

        public int GetMin()
        {
            return _currMin;
        }
    }

}
