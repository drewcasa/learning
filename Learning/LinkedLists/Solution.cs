using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.LinkedLists
{
    public class Solution
    {
        public abstract class Node<TVal, TNode>
        {
            public TNode next;
            public TVal val;

            public Node(TVal value)
            {
                val = value;
            }
        }

        public class ListNode : Node<int, ListNode>
        {
            public ListNode(int value) : base(value)
            { }
        }

        public class RandomListNode
        {
            public RandomListNode random;
            public RandomListNode next;
            public int label; // why aren't questions consistent?

            public RandomListNode(int val)
            {
                label = val;
            }
        }

        public ListNode GetIntersectionNodeBruteForce(ListNode headA, ListNode headB)
        {
            var set = new HashSet<ListNode>();
            var curr = headA;
            while (curr != null)
            {
                set.Add(curr);
                curr = curr.next;
            }
            curr = headB;
            while (curr != null)
            {
                if (set.Contains(curr)) return curr;
                curr = curr.next;
            }
            return null;
        }

        public ListNode GetIntersectionNodeBetter(ListNode headA, ListNode headB)
        {
            if (headA is null || headB is null)
                return null;

            // iterate both to end, if they end on same node, they're intersecting
            int lenA = GetLength(headA);
            int lenB = GetLength(headB);

            // diff in lengths is offset to advance longer list by
            ListNode longer = (lenA > lenB) ? headA : headB;
            ListNode shorter = (lenA > lenB) ? headB : headA;
            int delta = System.Math.Abs(lenA - lenB);
            for (int i = 0; i < delta; i++)
                longer = longer.next;

            // advance two together until reach intersection
            while (longer != shorter)
            {
                longer = longer.next;
                shorter = shorter.next;
            }

            return longer; // null == null
        }

        private int GetLength(ListNode head)
        {
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }
            return len;
        }

        public ListNode GetIntersectionNodeBest(ListNode headA, ListNode headB)
        {
            var runA = headA;
            var runB = headB;

            if (runA is null) return null;

            while (runA != null && runB != null && runA != runB)
            {
                runA = runA.next;
                runB = runB.next;

                if (runA == runB) return runA; // this is key. in second loop, both will be null at same time if no intersection

                // move runners to other head, they'll be aligned
                if (runA is null) runA = headB;
                if (runB is null) runB = headA;
            }

            return runB;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            // we can advance a front-pointer to nth node
            // then, advance both pointers until front gets to end
            // back pointer will be at end-N node.
            var front = head;
            var back = head;

            // advance front (at least one spot ahead of back)
            for (int i = 0; i < n; i++) front = front.next;

            // if front is null, we remove head
            if (front == null) return head.next;

            // advance both until front is at end
            while (front.next != null)
            {
                front = front.next;
                back = back.next;
            }

            // remove back.next
            back.next = back.next.next;
            return head;
        }

        public ListNode ReverseList(ListNode head)
        {
            // iterate through nodes, keeping pointer to prev, curr, next
            ListNode prev = null;

            while (head != null)
            {
                var next = head.next; // next node

                // reverse curr pointer
                head.next = prev;

                // move forward
                prev = head;
                head = next;
            }

            return prev;
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            // advance head if list starts with val
            while (head != null && head.val == val)
                head = head.next;

            if (head is null) return head;

            var curr = head; // head != val

            while (curr.next != null)
            {
                // peek at next value
                if (curr.next.val == val)
                    curr.next = curr.next.next; // remove curr.next
                else
                    curr = curr.next; // only advance if we didn't remove
            }
            return head;
        }

        /// <summary>
        /// Given a singly linked list, group all odd nodes together followed 
        /// by the even nodes. Please note here we are talking about the 
        /// node number and not the value in the nodes.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenList(ListNode head)
        {
            if (head is null || head.next is null || head.next.next is null)
                return head;

            var evenHead = head.next; // need this at end of odd chain
            var odd = head;
            var even = head.next;
            var nextOdd = odd.next.next; // stay 2-ahead

            // move pointers in pairs
            while (nextOdd != null)
            {
                odd.next = nextOdd;
                even.next = nextOdd.next;
                odd = odd.next;
                even = even.next;

                // keep pointers moving ahead by 2
                nextOdd = nextOdd.next?.next;
            }

            odd.next = evenHead;

            return head;
        }

        public bool IsPalindrome(ListNode head)
        {
            // 0 or 1 elements are palindrome
            if (head is null || head.next is null)
                return true;

            // fast runner gets to end while slow is at middle node
            var fast = head;
            var slow = head;
            while (fast?.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            // if we reverse from middle forward, we can then compare reversed with head
            // could track count and optimize out one comparison, but why bother
            var tail = ReverseList(slow);

            // compare from head and tail
            while (tail != null)
            {
                if (head.val != tail.val) return false;
                head = head.next;
                tail = tail.next;
            }

            return true;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            // track pointers to each, adding the smaller value along the way
            if (l1 is null) return l2;
            if (l2 is null) return l1;

            // splice the nodes, rather than clone
            var head = l1.val < l2.val ? l1 : l2;
            var spare = l1.val < l2.val ? l2 : l1;
            var main = head;

            // main points to our current node on combined list
            // spare points to "other" list
            while (main.next != null && spare != null)
            {
                var temp = main.next;
                main.next = (main.next.val < spare.val) ? main.next : spare; // move forward to smaller value
                main = main.next;
                if (spare == main) spare = temp; // if we moved to spare, swap spare back to other list
            }
            main.next = spare; // attach any remaining spares

            return head;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            var head = new ListNode(0);
            ListNode curr = head;

            // least-significant digits to most, don't assume same-length lists
            while (l1 != null || l2 != null || carry > 0)
            {
                var node = AddNodes(l1, l2, ref carry);
                curr.next = node;
                curr = curr.next;

                // move pointers
                l1 = l1?.next;
                l2 = l2?.next;
            }

            return head.next;
        }

        private ListNode AddNodes(ListNode l1, ListNode l2, ref int carry)
        {
            var digit = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = digit / 10;
            return new ListNode(digit % 10);
        }

        /// <summary>
        /// Deep clone of list with random pointers
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public RandomListNode CopyRandomList(RandomListNode head)
        {
            // we'll store all clones here
            var map = new Dictionary<int, RandomListNode>();

            // cycle through list first pass doing shallow copy
            var curr = head;
            var beforeHead = new RandomListNode(-1);
            var currCopy = beforeHead;
            while (curr != null)
            {
                var clone = new RandomListNode(curr.label);
                clone.random = curr.random;

                // insert new node into list + map
                map.Add(clone.label, clone);
                currCopy.next = clone;

                // advance pointers
                currCopy = currCopy.next;
                curr = curr.next;
            }

            // 2nd loop will fix references
            currCopy = beforeHead.next;
            while(currCopy != null)
            {
                if (currCopy.random != null)
                    currCopy.random = map[currCopy.random.label];
                currCopy = currCopy.next;
            }

            // return cloned head
            return beforeHead.next;
        }

        /// <summary>
        /// Deep clone of list with random pointers
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public RandomListNode CopyRandomListRecursion(RandomListNode head)
        {
            var map = new Dictionary<int, RandomListNode>();
            return CloneNode(head, map, true);
        }

        private RandomListNode CloneNode(RandomListNode node, Dictionary<int, RandomListNode> map, bool deepCopy)
        {
            if (node is null) return null;
            if (!map.ContainsKey(node.label))
                map.Add(node.label, new RandomListNode(node.label));

            RandomListNode clone = map[node.label];
            if (deepCopy)
            {
                clone.next = CloneNode(node.next, map, true);
                clone.random = CloneNode(node.random, map, false);
            }

            return clone;
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head is null) return head;

            // fast-forward to tail (get length at same time)
            var curr = head;
            int len = 1;
            while(curr.next != null)
            {
                curr = curr.next;
                len++;
            }

            // attach tail to head
            var tail = curr;
            tail.next = head;

            // advance to K-th node rotates left
            int rSteps = len - (k % len);
            for (int i = 0; i < rSteps; i++)
                curr = curr.next;

            // break cycle and return new head
            head = curr.next;
            curr.next = null;
            return head;
        }
        


    }
}
