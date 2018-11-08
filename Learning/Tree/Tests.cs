using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Tree
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void TestBoggle()
        {
            var sln = new Solution();

            var board = new char[,]
            {
                { 'a', 'b', 'b', 'l' },
                { 'd', 'a', 'b', 'e' },
                { 'a', 'b', 'b', 'c' },
                { 'a', 't', 'a', 'c' },
                { 'a', 't', 'a', 'k' },
            };
            var words = new string[]
            {
                "dab", "ab", "dabble", "able", "cat", "box", "ox", "attack", "at"
            };

            var result = sln.FindWords(board, words);

            Assert.IsTrue(result.Contains("dab"));
            Assert.IsFalse(result.Contains("able"));
            Assert.AreEqual(6, result.Count);
        }

        [TestMethod]
        public void TestBoggle1by1()
        {
            var sln = new Solution();

            var board = new char[,]
            {{ 'a'} };
            var words = new string[] { "a" };

            var result = sln.FindWords(board, words);

            Assert.IsTrue(result.Contains("a"));
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void TestPalindromePairs()
        {
            var sln = new Palindrome();
            var input = new string[] { "bba", "abb", "a", "cat", "elba" };
            var result = sln.PalindromePairs(input);

            Assert.AreEqual(4, result.Count);

            input = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            result = sln.PalindromePairs(input);

            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void TestTreeBalance()
        {
            var sln = new TreeSolution();
            
            var tree = TreeNode.BuildTree(new List<int?> { 1, 2, 2, 3, 3, null, null, 4, 4 });
            var result = sln.IsBalanced(tree);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestPalindromePairsEmpty()
        {
            var sln = new Palindrome();
            var input = new string[] { "a", "" };
            var result = sln.PalindromePairs(input);

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void TestPalindromes()
        {
            var sln = new Palindrome();

            Assert.IsTrue(sln.IsPalindrome(""));
            Assert.IsTrue(sln.IsPalindrome("a"));
            Assert.IsTrue(sln.IsPalindrome("aa"));
            Assert.IsTrue(sln.IsPalindrome("aba"));
            Assert.IsTrue(sln.IsPalindrome("abba"));
            Assert.IsTrue(sln.IsPalindrome("aabbabbaa"));

            Assert.IsFalse(sln.IsPalindrome("ab"));
            Assert.IsFalse(sln.IsPalindrome("abc"));
            Assert.IsFalse(sln.IsPalindrome("abaa"));
            Assert.IsFalse(sln.IsPalindrome("aaba"));
            Assert.IsFalse(sln.IsPalindrome("aab"));
            Assert.IsFalse(sln.IsPalindrome("baa"));
        }

    }
}
