using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Learning.Graphs
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void TestTreeDepth()
        {
            var sln = new Solution();

            var root = new TreeNode(1);
            root.left = new TreeNode(2);

            Assert.AreEqual(2, sln.MaxDepth(root));
            Assert.AreEqual(0, sln.MaxDepth(null));
            Assert.AreEqual(1, sln.MaxDepth(root.left));

        }

        [TestMethod]
        public void TestTreeValid()
        {
            var sln = new Solution();

            var root = new TreeNode(1);
            root.left = new TreeNode(2);

            var maxNode = new TreeNode(int.MaxValue);

            Assert.AreEqual(false, sln.IsValidBST(root));
            Assert.AreEqual(true, sln.IsValidBST(maxNode));
            Assert.AreEqual(true, sln.IsValidBST(null));

            root.left = new TreeNode(1);
            Assert.AreEqual(false, sln.IsValidBST(root));
        }

    }
}
