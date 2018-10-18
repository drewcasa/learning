using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.QueuesAndStacks
{
    public class MyStack
    {
        Queue<int> inQ;
        int top;

        /** Initialize your data structure here. */
        public MyStack()
        {
            inQ = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            inQ.Enqueue(x);
            top = x;
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            int limit = inQ.Count - 1;
            for (int i = 0; i < limit; i++)
            {
                top = inQ.Dequeue();
                inQ.Enqueue(top);
            }
            return inQ.Dequeue();
        }
        
        /** Get the top element. */
        public int Top()
        {
            return top;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return inQ.Count == 0;
        }
    }

}
