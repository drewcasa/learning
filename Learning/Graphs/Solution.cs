using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Graphs
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            return System.Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }

        private bool IsValidBST(TreeNode node, long min, long max)
        {
            if (node is null) return true;
            if (node.val <= min || node.val >= max) return false;

            return IsValidBST(node.left, min, node.val)
                && IsValidBST(node.right, node.val, max);
        }

    }

}
