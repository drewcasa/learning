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
            var fb = new VersionControl();
            var result = fb.FirstBadVersion(100);
            Assert.AreEqual(7, result);
            Assert.AreEqual(6, fb.Count);

            var bad2 = new VersionControl();
            bad2.FirstBad = 1702766719;
            Assert.AreEqual(bad2.FirstBad, bad2.FirstBadVersion(2126753390));
        }

        [TestMethod]
        public void TestBinarySearch()
        {
            var sln = new Solution();
            var input = new int[] { 1, 2, 4, 5, 7, 8, 100, 200, 201 };

            var result = sln.Search(input, 1);
            Assert.AreEqual(0, result);

            result = sln.Search(input, 0);
            Assert.AreEqual(-1, result);

            result = sln.Search(input, 100);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void TestSqrt()
        {
            var sln = new Solution();

            Assert.AreEqual(3, sln.MySqrt(10));
            Assert.AreEqual(3, sln.MySqrt(9));
            Assert.AreEqual(2, sln.MySqrt(8));
            Assert.AreEqual(1, sln.MySqrt(1));
            Assert.AreEqual(0, sln.MySqrt(0));
            Assert.AreEqual(4, sln.MySqrt(17));
            Assert.AreEqual(1000, sln.MySqrt(1000000));
            Assert.AreEqual((int)System.Math.Sqrt(2147395600), sln.MySqrt(2147395600));

        }

        [TestMethod]
        public void TestPeak()
        {
            var sln = new Solution();

            Assert.AreEqual(0, sln.FindPeakElement(new int[] { 5 }));
            Assert.AreEqual(2, sln.FindPeakElement(new int[] { 5, 6, 7, 2 }));
            Assert.AreEqual(1, sln.FindPeakElement(new int[] { 4, 5 }));
            Assert.AreEqual(0, sln.FindPeakElement(new int[] { 5, 5 }));
            Assert.AreEqual(0, sln.FindPeakElement(new int[] { int.MinValue }));
            Assert.AreEqual(0, sln.FindPeakElement(new int[] { int.MaxValue }));
        }

        [TestMethod]
        public void TestFindMin()
        {
            var sln = new Solution();

            Assert.AreEqual(5, sln.FindMin(new int[] { 5 }));
            Assert.AreEqual(1, sln.FindMin(new int[] { 5, 1, 2, 3 }));
            Assert.AreEqual(4, sln.FindMin(new int[] { 5, 4 }));
            Assert.AreEqual(1, sln.FindMin(new int[] { 1, 2 }));
        }

        [TestMethod]
        public void TestSearchRotate()
        {
            var sln = new Solution();

            Assert.AreEqual(4, sln.SearchRotated(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
            Assert.AreEqual(2, sln.SearchRotated(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6));
            Assert.AreEqual(3, sln.SearchRotated(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 7));
            Assert.AreEqual(0, sln.SearchRotated(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4));
            Assert.AreEqual(2, sln.SearchRotated(new int[] { 5, 1, 3 }, 3));

            Assert.AreEqual(-1, sln.SearchRotated(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3));
            Assert.AreEqual(-1, sln.SearchRotated(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3123));
        }

    }
}
