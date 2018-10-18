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

        private void AssertArray(int[] expected, int[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

    }
}
