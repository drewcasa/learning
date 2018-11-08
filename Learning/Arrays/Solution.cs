using System;
using System.Collections.Generic;
using System.Linq;

namespace Learning.Arrays
{
    public class Solution
    {
        /// <summary>
        /// Decode string by 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Find the median of the two ordered lists of numbers.
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int Median(int[] nums1, int[] nums2)
        {

            return 0;
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // fill at the end of nums1 and work backwards, taking the large element from the end of each array
            int curr = nums1.Length - 1;
            m--;
            n--;

            // while there are elements in nums2, we have to merge.
            while (n >= 0)
            {
                // if no elements left to merge in nums1 or 
                if (m < 0 || nums1[m] < nums2[n])
                    nums1[curr--] = nums2[n--];
                else
                    nums1[curr--] = nums1[m--];
            }
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

        /// <summary>
        /// Find and return indices of two numbers that sum to the target #.
        /// 
        /// Ex: [1, 2, 4, 5] target: 7
        /// would return [1, 3]: 2 + 5 = 7
        /// </summary>
        /// <param name="nums">List of numbers, not necessarily ordered</param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            // cycle through and add each num to a map where key is value and value is index
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i])) return new int[] { map[nums[i]], i };
                map[target - nums[i]] = i; // store index in map using key of difference
            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// Given an array of non-negative integers, you are initially positioned at the first index of the array.
        /// Each element in the array represents your maximum jump length at that position.
        /// Your goal is to reach the last index in the minimum number of jumps.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            // we can move forward, choosing the jump that results in the furthest reachable
            // position, because if we chose anything but that, we'd use as many or more moves

            // track our position w i
            int i = 0;
            int numJumps = 0;

            while (i < nums.Length - 1)
            {
                i = GetNextJump(nums, i);
                numJumps++;
            }

            return numJumps;
        }

        private int GetNextJump(int[] nums, int curr)
        {
            int max = 0;
            int maxI = curr;

            // check possible reachable spots from curr
            for (int i = 1; i <= nums[curr]; i++)
            {
                int next = i + curr;
                if ((next) >= (nums.Length - 1)) return next;

                if (next + nums[next] > max)
                {
                    max = next + nums[next];
                    maxI = next;
                }
            }
            return maxI;
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

        public List<int> Intersect(int[] nums1, int[] nums2)
        {
            var set = new HashSet<int>();
            var result = new List<int>();

            foreach (var num in nums1)
                set.Add(num);
            foreach (var num in nums2)
                if (set.Contains(num))
                    result.Add(num);
            return result;
        }

        public List<int> Union(int[] nums1, int[] nums2)
        {
            var union = new HashSet<int>();

            foreach (var num in nums1)
                union.Add(num);
            foreach (var num in nums2)
                union.Add(num);
            return union.ToList();
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

        public int NumQueenPlacement(int k = 8)
        {
            // array to track queen column placement
            var colIndices = new int[k];
            return PlaceFirstQueen(colIndices);
        }

        private int PlaceFirstQueen(int[] colIndices)
        {
            int row = 0;
            int numWays = 0;

            // only check half of board, since other half are mirrored
            for (int col = 0; col < colIndices.Length / 2; col++)
            {
                if (TryPlaceQueen(colIndices, row, col))
                    numWays += PlaceNextQueen(colIndices, row + 1) * 2;
            }
            // if odd length, check middle index (no mirrors)
            if (colIndices.Length % 2 == 1 &&
                TryPlaceQueen(colIndices, row, colIndices.Length / 2))
                numWays += PlaceNextQueen(colIndices, row + 1);

            return numWays;
        }

        private int PlaceNextQueen(int[] colIndices, int row)
        {
            if (row == colIndices.Length)
            {
                //DrawBoard(colIndices);
                return 1;
            }

            int numWays = 0;

            // find a valid spot for the next queen.
            for (int col = 0; col < colIndices.Length; col++)
                if (TryPlaceQueen(colIndices, row, col))
                    numWays += PlaceNextQueen(colIndices, row + 1);

            return numWays;
        }

        private bool TryPlaceQueen(int[] colIndices, int row, int col)
        {
            // validate the previous queens
            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                if (colIndices[rowIndex] == col) return false; // same col
                // diagonal is slope 1
                int rowDelta = row - rowIndex;
                int colDelta = col - colIndices[rowIndex];
                if (rowDelta == System.Math.Abs(colDelta)) return false;
            }
            colIndices[row] = col;
            return true;
        }

        private void DrawBoard(int[] colIndices)
        {
            for (int rowNum = 0; rowNum < colIndices.Length; rowNum++)
            {
                for (int colNum = 0; colNum < colIndices.Length; colNum++)
                {
                    if (colIndices[rowNum] == colNum) Console.Write(" Q ");
                    else Console.Write(" -- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public IList<IList<string>> SolveNQueens(int n)
        {
            EmptyRow = new char[n];
            for (int i = 0; i < n; i++) EmptyRow[i] = '.';

            var colIndices = new int[n];
            var solutions = new List<string[]>();

            PlaceNextQ(colIndices, 0, solutions);
            return solutions.ToArray();
        }

        char[] EmptyRow;

        private IList<IList<string>> PlaceFirstQ(int[] colIndices)
        {
            int row = 0;
            var solutions = new List<string[]>();

            // only check half of board, since other half are mirrored
            for (int col = 0; col < colIndices.Length / 2; col++)
            {
                if (TryPlaceQueen(colIndices, row, col))
                    PlaceNextQ(colIndices, row + 1, solutions);
            }
            // if odd length, check middle index (no mirrors)
            if (colIndices.Length % 2 == 1 &&
                TryPlaceQueen(colIndices, row, colIndices.Length / 2))
                PlaceNextQ(colIndices, row + 1, solutions);

            return solutions.ToArray();
        }

        private void PlaceNextQ(int[] colIndices, int row, List<string[]> solutions)
        {
            if (row == colIndices.Length)
            {
                solutions.Add(ConvertToBoard(colIndices));
                return;
            }

            // find a valid spot for the next queen.
            for (int col = 0; col < colIndices.Length; col++)
                if (TryPlaceQueen(colIndices, row, col))
                    PlaceNextQ(colIndices, row + 1, solutions);
        }

        private string[] ConvertToBoard(int[] colIndices)
        {
            var board = new string[colIndices.Length];

            for (int rowNum = 0; rowNum < colIndices.Length; rowNum++)
            {
                EmptyRow[colIndices[rowNum]] = 'Q';
                board[rowNum] = new string(EmptyRow);
                EmptyRow[colIndices[rowNum]] = '.';
            }
            return board;
        }

    }
}
