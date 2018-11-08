using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Arrays
{

    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void TestRemoveDupes()
        {
            var sln = new Solution();

            int[] nums = new int[] { 1, 1, 2, 2, 2 };

            Assert.AreEqual(2, sln.RemoveDuplicates(nums));
            Assert.AreEqual(1, nums[0]);
            Assert.AreEqual(2, nums[1]);
        }

        [TestMethod]
        public void TestMerge()
        {
            var merge = new Solution();
            int[] nums1 = new int[] { 1, 3, 5, 7, 9, 0, 0, 0, 0 };
            int[] nums2 = new int[] { 2, 4, 6, 12 };

            merge.Merge(nums1, 5, nums2, 4);
            Assert.AreEqual(12, nums1[8]);

            nums1 = new int[] { };
            nums2 = new int[] { };

            merge.Merge(nums1, 0, nums2, 0);

            nums1 = new int[] { 0, 0, 0 };
            nums2 = new int[] { 2, 123, 123516161 };

            merge.Merge(nums1, 0, nums2, 3);
            Assert.AreEqual(2, nums1[0]);
        }

        [TestMethod]
        public void TestRotate()
        {
            var rotater = new Solution();

            int[] nums = new int[] { 1, 2, 3, 4, 5 };
            rotater.Rotate(nums, 1);
            AssertArray(new int[] { 5, 1, 2, 3, 4 }, nums);

            nums = new int[] { 1, 2, 3, 4, 5 };
            rotater.Rotate(nums, 21);
            AssertArray(new int[] { 5, 1, 2, 3, 4 }, nums);

            nums = new int[] { 1, 2, 3, 4, 5 };
            rotater.Rotate(nums, 4);
            AssertArray(new int[] { 2, 3, 4, 5, 1 }, nums);

        }

        [TestMethod]
        public void TestTwoSum()
        {
            var sln = new Solution();

            int[] nums = new int[] { 1, 2, 1, 4, 5 };
            var result = sln.TwoSum(nums, 7);
            AssertArray(new int[] { 1, 4 }, result);
        }

        [TestMethod]
        public void TestJump()
        {
            var sln = new Solution();

            int[] nums = new int[] { 1, 2, 1, 4, 5 };
            Assert.AreEqual(3, sln.Jump(nums));
            Assert.AreEqual(2, sln.Jump(new int[] { 2, 3, 1, 1, 4 }));
            Assert.AreEqual(0, sln.Jump(new int[] { 0 }));
        }

        [TestMethod]
        public void TestSingleNums()
        {
            var singleNum = new Solution();

            int[] nums = new int[] { 1, 2, 1, 3, 2 };
            var result = singleNum.SingleNumber(nums);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestSudoku()
        {
            var board = new char[,]
            {
                {'8','3','.','.','7','.','.','.','.'},
                {'6','.','.','1','9','5','.','.','.'},
                {'.','9','8','.','.','.','.','6','.'},
                {'8','.','.','.','6','.','.','.','3'},
                {'4','.','.','8','.','3','.','.','1'},
                {'7','.','.','.','2','.','.','.','6'},
                {'.','6','.','.','.','.','2','8','.'},
                {'.','.','.','4','1','9','.','.','5'},
                {'.','.','.','.','8','.','.','7','9'}
            };

            var puzzle = new Solution();
            Assert.IsFalse(puzzle.IsValidSudoku(board));

            board[0, 0] = '5';
            Assert.IsTrue(puzzle.IsValidSudoku(board));
        }

        [TestMethod]
        public void TestQueens()
        {
            var sln = new Solution();
            var result = sln.NumQueenPlacement(4);
            Assert.AreEqual(2, result);

            result = sln.NumQueenPlacement(5);
            Assert.AreEqual(10, result);

            result = sln.NumQueenPlacement(6);
            Assert.AreEqual(4, result);

            result = sln.NumQueenPlacement(8);
            Assert.AreEqual(92, result);

            result = sln.NumQueenPlacement(10);
            Assert.AreEqual(724, result);

            result = sln.NumQueenPlacement(11);
            Assert.AreEqual(2680, result);

            result = sln.NumQueenPlacement(12);
            Assert.AreEqual(14200, result);
        }

        [TestMethod]
        public void TestQueens2()
        {
            var sln = new Solution();
            var result = sln.SolveNQueens(4);
            Assert.AreEqual(2, result.Count);

            result = sln.SolveNQueens(5);
            Assert.AreEqual(10, result.Count);

            result = sln.SolveNQueens(6);
            Assert.AreEqual(4, result.Count);

            result = sln.SolveNQueens(8);
            Assert.AreEqual(92, result.Count);
        }

        private void AssertArray(int[] expected, int[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void TestPermutations()
        {
            var results = StringUtils.GetPermutations("abc");
            Assert.AreEqual(6, results.Count);
            Assert.AreEqual("abc", results[0]);
            Assert.AreEqual("cba", results[5]);
        }

        [TestMethod]
        public void TestPermutationsArray()
        {
            var results = StringUtils.GetPermutations(new int[] { 1, 2, 3, 4 });
            Assert.AreEqual(24, results.Count);
            AssertArray(new int[] { 1, 2, 3, 4 }, results[0]);
            AssertArray(new int[] { 1, 2, 4, 3 }, results[1]);
            AssertArray(new int[] { 1, 3, 2, 4 }, results[2]);
            AssertArray(new int[] { 1, 3, 4, 2 }, results[3]);
        }

        [TestMethod]
        public void TestLengthSubstring()
        {
            Assert.AreEqual(3, StringUtils.LengthOfLongestSubstring("abcaaa"));
            Assert.AreEqual(3, StringUtils.LengthOfLongestSubstring("aaaabadaaa"));
            Assert.AreEqual(8, StringUtils.LengthOfLongestSubstring("another one"));
            Assert.AreEqual(0, StringUtils.LengthOfLongestSubstring(""));
        }
    }
}
