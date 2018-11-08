using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Tree
{
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public static TreeNode BuildTree(List<int?> nums)
        {
            if (nums.Count == 0) return null;

            return BuildTreeNode(nums, 0);
        }

        private static TreeNode BuildTreeNode(List<int?> nums, int index)
        {
            if (index >= nums.Count || !nums[index].HasValue)
                return null;

            var node = new TreeNode(nums[index].Value);
            node.left = BuildTreeNode(nums, index * 2 + 1);
            node.right = BuildTreeNode(nums, (index * 2) + 2);
            return node;
        }
    }

    /// <summary>
    /// For this problem, a height-balanced binary tree is defined as:
    /// a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
    /// </summary>
    public class TreeSolution
    {

        public bool IsBalanced(TreeNode root)
        {
            return Balance(root).IsBalanced;
        }

        public int GetDepth(TreeNode node)
        {
            if (node is null) return 0;
            return 1 + System.Math.Max(GetDepth(node.left), GetDepth(node.right));
        }

        private BalanceResult Balance(TreeNode node)
        {
            if (node is null) return new BalanceResult { IsBalanced = true, MaxDepth = 0 };

            var leftBal = Balance(node.left);
            var rightBal = Balance(node.right);
            bool isBalanced = leftBal.IsBalanced && rightBal.IsBalanced
                && System.Math.Abs(leftBal.MaxDepth - rightBal.MaxDepth) <= 1;
            int maxDepth = System.Math.Max(leftBal.MaxDepth, rightBal.MaxDepth) + 1;

            return new BalanceResult { IsBalanced = isBalanced, MaxDepth = maxDepth };
        }

        private class BalanceResult
        {
            public bool IsBalanced;
            public int MaxDepth;
        }


    }

}
