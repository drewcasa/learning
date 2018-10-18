using System;
using System.Collections.Generic;
using System.Text;

namespace Learning
{
    public class MyCircularQueue
    {
        private int[] _queue;
        private int _head, _tail, _count;

        /** Initialize your data structure here. Set the size of the queue to be k. */
        public MyCircularQueue(int k)
        {
            _count = 0;
            _queue = new int[k];
            _head = -1;
            _tail = -1;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (IsFull()) return false;
            if (IsEmpty()) _head = 0;
            _count++;
            _tail = (++_tail % _queue.Length);
            _queue[_tail] = value;
            return true;
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if (IsEmpty()) return false;
            _head = (++_head % _queue.Length);
            _count--;
            if (IsEmpty())
            {
                _head = -1;
                _tail = -1;
            }
            return true;
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (IsEmpty()) return -1;
            return _queue[_head];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (IsEmpty()) return -1;
            return _queue[_tail];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            return _count == _queue.Length;
        }
    }

    /**
     * Your MyCircularQueue object will be instantiated and called as such:
     * MyCircularQueue obj = new MyCircularQueue(k);
     * bool param_1 = obj.EnQueue(value);
     * bool param_2 = obj.DeQueue();
     * int param_3 = obj.Front();
     * int param_4 = obj.Rear();
     * bool param_5 = obj.IsEmpty();
     * bool param_6 = obj.IsFull();
     */
}
