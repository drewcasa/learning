﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Arrays
{
    public class StringUtils
    {

        public bool IsPermutation(string s1, string s2)
        {
            // get counts of chars
            var map = GetCharCounts(s1);
            foreach (char c in s2)
            {
                if (!map.ContainsKey(c) || map[c] == 0)
                    return false;
                map[c]--;
            }

            // if any remaining counts are > 0, false
            foreach (var kvp in map)
                if (kvp.Value > 0) return false;

            // success
            return true;
        }

        public Dictionary<char, int> GetCharCounts(string s)
        {
            var map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map[c] = 1;
                else
                    map[c]++;
            }
            return map;
        }

        public static List<string> GetPermutations(string s1)
        {
            var results = new List<string>();
            GetPermutations("", s1, results);
            return results;
        }

        private static void GetPermutations(string prefix, string remaining, List<string> results)
        {
            // base case
            if (remaining == "")
            {
                results.Add(prefix);
                return;
            }

            // take char from s, append to prefix, recurse
            for (int i = 0; i < remaining.Length; i++)
            {
                var trimmed = remaining.Substring(0, i) + remaining.Substring(i + 1);
                GetPermutations(prefix + remaining[i], trimmed, results);
            }
        }

        public static List<T[]> GetPermutations<T>(T[] values)
        {
            var results = new List<T[]>();
            GetPermutations(values, 0, results);
            return results;
        }

        private static void GetPermutations<T>(T[] values, int index, List<T[]> results)
        {
            // base case
            if (index == values.Length)
            {
                results.Add((T[])values.Clone());
                return;
            }

            // swap curr position with any remaining
            for (int i = index; i < values.Length; i++)
            {
                Swap(values, index, i);
                GetPermutations(values, index + 1, results);
                Swap(values, index, i);
            }
        }

        private static void Swap<T>(T[] values, int i1, int i2)
        {
            if (i1 == i2) return;
            var temp = values[i1];
            values[i1] = values[i2];
            values[i2] = temp;
        }

        /// <summary>
        /// Given a string, find the length of the longest substring without repeating characters.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            // use set to track chars
            // use a head and tail pointer to go through. advance head until dupe found
            // if dupe, remove tail from set and advance until remove dupe
            // track max length as going

            int max = 0;
            int tail = 0, head = 0;
            var seen = new HashSet<char>();

            // maybe can short-circuit earlier if max exceeds remaining possible max
            while (head < s.Length)
            {
                // if char exists, advance tail up until it's gone
                while (seen.Contains(s[head]))
                {
                    seen.Remove(s[tail]);
                    tail++;
                }

                seen.Add(s[head]);
                head++;
                if (head - tail > max) max = head - tail;
            }

            return max;
        }
    }
}
