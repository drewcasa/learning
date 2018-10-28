using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.SortSearch
{

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestBadVersion()
        {
            var fb = new Solution();
            var result = fb.FirstBadVersion(100);
            Assert.AreEqual(7, result);
            Assert.AreEqual(6, fb.Count);

            var bad2 = new Solution();
            bad2.FirstBad = 1702766719;
            Assert.AreEqual(bad2.FirstBad, bad2.FirstBadVersion(2126753390));
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

    }
}
