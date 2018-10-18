using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.QueuesAndStacks
{
    public class MyQueue
    {

        Stack<int> enq, deq;

        /** Initialize your data structure here. */
        public MyQueue()
        {
            enq = new Stack<int>();
            deq = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            enq.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            MoveToDeq();
            return deq.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            MoveToDeq();
            return deq.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            if (deq.Count > 0) return false;
            return enq.Count == 0;
        }

        private void MoveToDeq()
        {
            // if deq is empty, we'll refill from enq
            if (deq.Count == 0)
                while (enq.Count > 0)
                    deq.Push(enq.Pop());
        }
    }

}
