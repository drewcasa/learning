using System;
using System.Collections.Generic;
using System.Linq;

namespace Learning.Arrays
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            // i points to curr
            int i = 0;

            // j advances ahead to next
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                    nums[++i] = nums[j];
            }

            return i + 1;
        }

        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2) return 0;

            // basically want to find the hills, buy low and sell high
            // doesn't matter that we can only buy or sell on one day, we only need to measure the diffs
            int profit = 0;

            for (int j = 1; j < prices.Length; j++)
            {
                var delta = prices[j] - prices[j - 1];
                if (delta > 0) profit += delta;
            }
            return profit;
        }

        public void RotateInPlace(int[] nums, int k)
        {
            int len = nums.Length;
            if (k % len == 0) return;

            k = k % len; // keep it within limits saves extra checks later
            int gcd = GCD(len, k);
            int kPrime = len - k; // rotate left is easier to read

            // gcd of 4 and 6 is 2.
            for (int i = 0; i < gcd; i++)
            {
                // rotate each number kPrime, same as forward k
                int start = nums[i];
                int j = i;
                int jPrev;
                do
                {
                    jPrev = Increment(j, kPrime, len);
                    nums[j] = nums[jPrev];
                    j = jPrev;
                } while (j != i);
                nums[Increment(i, k, len)] = start;
            }
        }

        public void Rotate(int[] nums, int k)
        {
            int len = nums.Length;
            int[] nums2 = new int[len];
            if (k % len == 0) return;

            for (int i = 0; i < len; i++)
                nums2[Increment(i, k, len)] = nums[i];
            Array.Copy(nums2, nums, len);
        }

        private int Increment(int i, int k, int length)
        {
            int next = (i + k) % length;
            return next;
        }

        public int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }

        public bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length < 2) return false;
            var set = new HashSet<int>(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i])) return true;
                set.Add(nums[i]);
            }
            return false;
        }

        public int SingleNumber(int[] nums)
        {
            // linear, no extra memory
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
                result ^= nums[i];
            return result;
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            // could sort first, then compare in order

            // instead, make map of counts
            var map = new Dictionary<int, int>(nums1.Length);
            foreach (var num in nums1)
            {
                if (map.ContainsKey(num))
                    map[num]++;
                else
                    map[num] = 1;
            }

            var intersect = new List<int>(nums1.Length);

            foreach (var num in nums2)
            {
                if (map.ContainsKey(num) && map[num] > 0)
                {
                    map[num]--;
                    intersect.Add(num);
                }
            }

            return intersect.ToArray();
        }

        public bool IsValidSudoku(char[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (!IsRowValid(board, i)) return false;
                if (!IsColValid(board, i)) return false;
                if (!IsBoxValid(board, i)) return false;
            }

            return true;
        }

        private bool IsRowValid(char[,] board, int rowNum)
        {
            int numMask = 0;
            for (int colNum = 0; colNum < 9; colNum++)
            {
                int val = MapDigitToBit(board[rowNum, colNum]);
                if ((val > 0) && ((val & numMask) == val)) return false;
                numMask |= val;
            }
            return true;
        }

        private bool IsColValid(char[,] board, int colNum)
        {
            int numMask = 0;
            for (int rowNum = 0; rowNum < 9; rowNum++)
            {
                int val = MapDigitToBit(board[rowNum, colNum]);
                if ((val > 0) && ((val & numMask) == val)) return false;
                numMask |= val;
            }
            return true;
        }

        private bool IsBoxValid(char[,] board, int boxNum)
        {
            int numMask = 0;
            int rowOffset = (boxNum / 3) * 3;
            int colOffset = (boxNum % 3) * 3;

            for (int rowNum = rowOffset; rowNum < rowOffset + 3; rowNum++)
                for (int colNum = colOffset; colNum < colOffset + 3; colNum++)
                {
                    int val = MapDigitToBit(board[rowNum, colNum]);
                    if ((val > 0) && ((val & numMask) == val)) return false;
                    numMask |= val;
                }
            return true;
        }

        private int MapDigitToBit(char c)
        {
            switch (c)
            {
                case '1': return 1;
                case '2': return 2;
                case '3': return 4;
                case '4': return 8;
                case '5': return 16;
                case '6': return 32;
                case '7': return 64;
                case '8': return 128;
                case '9': return 256;
                default: return 0;
            }
        }

    }
}
