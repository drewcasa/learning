using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.LinkedLists
{
    public class MyLinkedList
    {
        private MyNode<int> _head;
        private int _len;

        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            _len = 0;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            var curr = _head;
            for (int i = 0; i < index; i++)
            {
                if (curr == null) return -1;
                curr = curr.next;
            }
            if (curr == null) return -1;
            return curr.val;
        }

        /** Add a node of value val before the first element of the linked list. 
         * After the insertion, the new node will be the first node of the 
         * linked list. */
        public void AddAtHead(int val)
        {
            AddAtIndex(0, val);
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            AddAtIndex(_len, val);
        }

        /** Add a node of value val before the index-th node in the linked list. 
         * If index equals to the length of linked list, the node will be 
         * appended to the end of linked list. If index is greater than 
         * the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index > _len)
                return;

            var newNode = new MyNode<int>(val);

            if (index == 0)
            {
                // insert at head
                newNode.next = _head;
                _head = newNode;
            }
            else
            {
                // advance to node before insertion
                var nodeBefore = _head;
                for (int i = 0; i < index - 1; i++)
                    nodeBefore = nodeBefore.next;

                // insert
                newNode.next = nodeBefore.next;
                nodeBefore.next = newNode;
            }
            _len++;
        }

        /** Delete the index-th node in the linked list, 
         * if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= _len)
                return;

            // delete head
            if (index == 0)
            {
                _head = _head.next;
            }
            else
            {
                // advance to node before deletion
                var nodeBefore = _head;
                for (int i = 0; i < index - 1; i++)
                    nodeBefore = nodeBefore.next;

                nodeBefore.next = nodeBefore.next.next;
            }
            _len--;
        }

        class MyNode<T>
        {
            internal T val;
            internal MyNode<T> next;

            public MyNode(T val)
            {
                this.val = val;
            }
        }
    }


}
