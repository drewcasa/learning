using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.QueuesAndStacks
{

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestQueueWithStacks()
        {
            MyQueue queue = new MyQueue();

            queue.Push(1);
            queue.Push(2);
            Assert.AreEqual(1, queue.Peek());  // returns 1
            Assert.AreEqual(1, queue.Pop());   // returns 1
            Assert.IsFalse(queue.Empty()); // returns false
            Assert.AreEqual(2, queue.Pop());
            Assert.IsTrue(queue.Empty());
            queue.Push(12);
        }

        [TestMethod]
        public void TestQueue2()
        {
            MyQueue queue = new MyQueue();

            queue.Push(1);
            queue.Push(2);
            Assert.AreEqual(1, queue.Peek());  // returns 1
            queue.Push(3);
            Assert.AreEqual(1, queue.Peek());  // returns 1
        }

        [TestMethod]
        public void TestStackWQ()
        {
            var stack = new MyStack();

            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Top());
            stack.Push(3);
            Assert.AreEqual(3, stack.Top());
        }

        //s = "3[a]2[bc]", return "aaabcbc".
        ////s = "3[a2[c]]", return "accaccacc".
        //s = "2[abc]3[cd]ef", return "abcabccdcdcdef".
        [TestMethod]
        public void TestDecode()
        {
            var decoder = new Solution();

            Assert.AreEqual("hi", decoder.DecodeString("hi"));
            Assert.AreEqual("hihihi", decoder.DecodeString("3[hi]"));
            Assert.AreEqual("abcabccdcdcdef", decoder.DecodeString("2[abc]3[cd]ef"));
            Assert.AreEqual("accaccacc", decoder.DecodeString("3[a2[c]]"));
            Assert.AreEqual("aaabFFFFcbFFFFc", decoder.DecodeString("3[a]2[b4[F]c]"));
        }
        

    }
}
