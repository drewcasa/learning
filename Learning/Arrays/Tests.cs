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
        public void TestDecode()
        {
            var decoder = new Solution();

            int[] nums = new int[] { 1, 1, 2, 2, 2 };

            Assert.AreEqual(2, decoder.RemoveDuplicates(nums));
            Assert.AreEqual(1, nums[0]);
            Assert.AreEqual(2, nums[1]);
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

    }
}
