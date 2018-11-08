using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.QueuesAndStacks
{
    class Solution
    {

        /// <summary>
        /// Determine if an input is a valid expression using 
        /// open and close parens and brackets in correct open/close
        /// sequence.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsValidExpression(string input)
        {
            if (input is null) throw new ArgumentNullException();

            // map valid open -> close chars
            var charMap = new Dictionary<char, char>() { { '[', ']' }, { '(', ')' } };

            // hold open tokens
            var s = new Stack<char>();

            foreach (char c in input)
            {
                if (charMap.ContainsKey(c)) // open
                {
                    s.Push(c);
                }
                else // close
                {
                    if (s.Count == 0) return false; // no opening to match
                    char open = s.Pop();
                    if (charMap[open] != c) return false; // invalid closing character
                }
            }

            return s.Count == 0; // non-empty means invalid
        }

        /// <summary>
        /// Determine if input represents binary tree.
        /// Ex: ()
        /// (()())
        /// ((()())(()()))
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsBinaryTreeExpression(string input)
        {
            if (input is null) throw new ArgumentNullException();

            // map valid open -> close chars
            var charMap = new Dictionary<char, char>() { { '[', ']' }, { '(', ')' } };

            // hold open tokens - add special root to track its "children"
            var s = new Stack<TreeToken>();
            s.Push(new TreeToken('*', 0));
            int nodeCount = input.Length / 2;

            foreach (char c in input)
            {
                if (charMap.ContainsKey(c)) // open
                {
                    // before pushing, let's validate index
                    var parent = s.Peek();
                    if (parent.ChildCount == 2) return false; // don't allow 3 children

                    var child = parent.CreateChild(c);
                    if (child.Index > nodeCount) return false; // violates completeness
                    s.Push(child);
                }
                else // close
                {
                    if (s.Count == 1) return false; // no opening to match
                    var node = s.Pop();

                    // invalid closing character
                    if (charMap[node.Token] != c) return false;
                }
            }

            // only root should remain, and it should only have 0 or 1 children
            return (s.Count == 1) && (s.Peek().ChildCount <= 1);
        }

        class TreeToken
        {
            public char Token;
            public int Index;
            public int ChildCount = 0;

            public TreeToken(char c, int index)
            {
                Token = c;
                Index = index;
            }

            public TreeToken CreateChild(char c)
            {
                int index = Index == 0 ? 1 : (Index * 2) + ChildCount;
                ChildCount++;
                return new TreeToken(c, index);
            }
        }

        public string DecodeString(string s)
        {
            int start = 0;
            return DecodeSegment(s, ref start);
        }

        private string DecodeRepeatedSegment(string s, ref int i)
        {
            // read freq first
            var sb = new StringBuilder();
            while (Char.IsDigit(s[i]))
                sb.Append(s[i++]);
            int freq = int.Parse(sb.ToString());

            // read past '['
            i++;

            // read segment
            string segment = DecodeSegment(s, ref i);

            // read past ']'
            i++;

            // repeat segment
            sb.Clear();
            for (int j = 0; j < freq; j++)
                sb.Append(segment);

            return sb.ToString();
        }

        private string DecodeSegment(string s, ref int i)
        {
            // segment can have any combination of text and repeated, nested segments
            var sb = new StringBuilder();
            while (i < s.Length && s[i] != ']')
            {
                // if digit, decode nested segment
                if (char.IsDigit(s[i]))
                    sb.Append(DecodeRepeatedSegment(s, ref i));
                else // if char, append chars
                    sb.Append(s[i++]);
            }

            return sb.ToString();
        }

    }
}
