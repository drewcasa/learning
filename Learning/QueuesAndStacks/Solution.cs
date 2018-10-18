using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.QueuesAndStacks
{
    class Solution
    {

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
                else                // if char, append chars
                    sb.Append(s[i++]);
            }

            return sb.ToString();
        }
        
    }
}
