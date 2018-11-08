using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static Learning.LinkedLists.Solution;

namespace Learning.LinkedLists
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void TestList()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            var list = new MyLinkedList();
            Assert.AreEqual(-1, list.Get(0));

            list.AddAtHead(1); // 1
            list.AddAtTail(5); // 1,5
            Assert.AreEqual(1, list.Get(0));
            Assert.AreEqual(5, list.Get(1));

            list.AddAtIndex(0, 3); // 3,1,5
            Assert.AreEqual(3, list.Get(0));

            list.AddAtIndex(1, 7); // 3,7,1,5

            list.DeleteAtIndex(5); // 3,7,1,5
            list.DeleteAtIndex(0); // 7,1,5
            list.DeleteAtIndex(1); // 7,5
            Assert.AreEqual(5, list.Get(1));
            Assert.AreEqual(7, list.Get(0));
        }

        [TestMethod]
        public void TestNodeIntersection()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            var head = new ListNode(5);
            head.next = new ListNode(126);
            var head2 = new ListNode(4);
            head2.next = new ListNode(6);
            head2.next.next = head.next;

            var sln = new Solution();

            var result = sln.GetIntersectionNodeBruteForce(head, head2);
            Assert.AreSame(head.next, result);
            Assert.AreEqual(126, result.val);

            result = sln.GetIntersectionNodeBetter(head, head2);
            Assert.AreSame(head.next, result);
            Assert.AreEqual(126, result.val);

            result = sln.GetIntersectionNodeBest(head, head2);
            Assert.AreSame(head.next, result);
            Assert.AreEqual(126, result.val);

            result = sln.GetIntersectionNodeBruteForce(head, new ListNode(132));
            Assert.IsNull(result);
            result = sln.GetIntersectionNodeBetter(head, new ListNode(132));
            Assert.IsNull(result);
            result = sln.GetIntersectionNodeBest(head, new ListNode(132));
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestRemoveNth()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            var head = BuildList(new int[] { 1, 2, 3, 4 });
            var sln = new Solution();

            var result = sln.RemoveNthFromEnd(head, 2);
            Assert.AreSame(head, result);
            AssertList(result, new int[] { 1, 2, 4 });

            result = sln.RemoveNthFromEnd(head, 1);
            Assert.AreSame(head, result);
            AssertList(result, new int[] { 1, 2 });

            result = sln.RemoveNthFromEnd(head, 2);
            Assert.AreNotSame(head, result);
        }

        [TestMethod]
        public void TestReverse()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            var head = BuildList(1, 2, 3);

            var sln = new Solution();
            var result = sln.ReverseList(head);
            AssertList(result, 3, 2, 1);

            var head2 = new ListNode(345);

            result = sln.ReverseList(head2);
            Assert.AreSame(head2, result);
            Assert.IsNull(result.next);
        }

        [TestMethod]
        public void TestRemove()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            var head = BuildList(1, 2, 3, 4);

            var sln = new Solution();
            var result = sln.RemoveElements(head, 2);
            Assert.AreSame(head, result);
            AssertList(result, 1, 3, 4);
        }

        [TestMethod]
        public void TestRemove2()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            var head = BuildList(1, 6, 4, 6);

            var sln = new Solution();
            var result = sln.RemoveElements(head, 6);
            Assert.AreSame(head, result);
            AssertList(result, 1, 4);
        }

        [TestMethod]
        public void TestOddEven()
        {
            var head = BuildList(1, 2, 3, 4, 5, 6);

            var sln = new Solution();
            var result = sln.OddEvenList(head);
            AssertList(head, 1, 3, 5, 2, 4, 6);
        }

        [TestMethod]
        public void TestOddEvenOdd()
        {
            var head = BuildList(1, 2, 3, 4, 5);

            var sln = new Solution();
            var result = sln.OddEvenList(head);
            AssertList(head, 1, 3, 5, 2, 4);
        }

        [TestMethod]
        public void TestOddEvenEdge()
        {
            var sln = new Solution();

            var result = sln.OddEvenList(BuildList(1, 2, 3));
            AssertList(result, 1, 3, 2);

            result = sln.OddEvenList(BuildList(1, 2));
            AssertList(result, 1, 2);

            result = sln.OddEvenList(new ListNode(1));
            AssertList(result, 1);

            result = sln.OddEvenList(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestPalindrome()
        {
            var sln = new Solution();

            Assert.IsTrue(sln.IsPalindrome(BuildList(1)));
            Assert.IsTrue(sln.IsPalindrome(BuildList(1, 1)));
            Assert.IsTrue(sln.IsPalindrome(BuildList(1, 2, 1)));
            Assert.IsTrue(sln.IsPalindrome(BuildList(1, 2, 2, 1)));
            Assert.IsTrue(sln.IsPalindrome(BuildList(1, 1, 1, 3, 3, 1, 1, 1)));

            Assert.IsFalse(sln.IsPalindrome(BuildList(1, 2, 3)));
            Assert.IsFalse(sln.IsPalindrome(BuildList(1, 2, 2, 3, 3, 1)));
            Assert.IsFalse(sln.IsPalindrome(BuildList(1, 2)));
        }

        [TestMethod]
        public void TestMerge()
        {
            var sln = new Solution();

            var result = sln.MergeTwoLists(BuildList(1, 3, 5), BuildList(2, 4, 5));
            AssertList(result, 1, 2, 3, 4, 5, 5);
            result = sln.MergeTwoLists(BuildList(), BuildList());
            AssertList(result);
            result = sln.MergeTwoLists(BuildList(1), BuildList());
            AssertList(result, 1);
            result = sln.MergeTwoLists(BuildList(1, 1, 1), BuildList(1));
            AssertList(result, 1, 1, 1, 1);

            result = sln.MergeTwoLists(BuildList(7, 8, 9), BuildList(1, 2, 3));
            AssertList(result, 1, 2, 3, 7, 8, 9);
            result = sln.MergeTwoLists(BuildList(1, 2, 3), BuildList(7, 8, 9, 10));
            AssertList(result, 1, 2, 3, 7, 8, 9, 10);
        }

        [TestMethod]
        public void TestAdd()
        {
            var sln = new Solution();

            var result = sln.AddTwoNumbers(BuildList(1, 3, 1), BuildList(2, 4, 5));
            AssertList(result, 3, 7, 6);

            result = sln.AddTwoNumbers(BuildList(1, 3, 1), BuildList(2));
            AssertList(result, 3, 3, 1);

            result = sln.AddTwoNumbers(BuildList(1, 3, 1), BuildList(0));
            AssertList(result, 1, 3, 1);

            result = sln.AddTwoNumbers(BuildList(), BuildList());
            AssertList(result);

            result = sln.AddTwoNumbers(BuildList(5), BuildList(5));
            AssertList(result, 0, 1);
        }

        [TestMethod]
        public void TestRandomClone()
        {
            var sln = new Solution();

            var input = BuildRandomList(1, 2, 3, 4);
            input.random = input.next.next;
            input.next.random = input;
            input.next.next.random = input;

            var result = sln.CopyRandomListRecursion(input);
            AssertList(result, 1,2,3,4);
            Assert.AreNotSame(input, result);
            Assert.AreNotSame(input.random, result.random);
            Assert.AreEqual(input.random.label, result.random.label);
        }

        [TestMethod]
        public void RotateTests()
        {
            var sln = new Solution();

            var input = BuildList(1, 2, 3, 4);
            var result = sln.RotateRight(input, 2);
            AssertList(result, 3, 4, 1, 2);

            result = sln.RotateRight(BuildList(2, 3), 2);
            AssertList(result, 2, 3);

            result = sln.RotateRight(BuildList(2, 3), 12);
            AssertList(result, 2, 3);

            result = sln.RotateRight(BuildList(), 1);
            AssertList(result);

            result = sln.RotateRight(BuildList(1,2,3,4,5), 17);
            AssertList(result, 4,5,1,2,3);
        }

        private ListNode BuildList(params int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;

            var head = new ListNode(nums[0]);
            var curr = head;
            for (int i = 1; i < nums.Length; i++)
            {
                curr.next = new ListNode(nums[i]);
                curr = curr.next;
            }
            return head;
        }

        private RandomListNode BuildRandomList(params int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;

            var head = new RandomListNode(nums[0]);
            var curr = head;
            for (int i = 1; i < nums.Length; i++)
            {
                curr.next = new RandomListNode(nums[i]);
                curr = curr.next;
            }
            return head;
        }

        private void AssertList(ListNode head, params int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Assert.AreEqual(nums[i], head.val);
                head = head.next;
            }
            Assert.IsNull(head);
        }

        private void AssertList(RandomListNode head, params int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Assert.AreEqual(nums[i], head.label);
                head = head.next;
            }
            Assert.IsNull(head);
        }

    }
}
