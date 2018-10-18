using System;
using System.Collections.Generic;
using System.Text;

namespace Learning
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class TreeNodeSolution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var inOrder = new List<int>();
            TraverseInOrder(root, inOrder);
            return inOrder;
        }

        private void TraverseInOrder(TreeNode node, IList<int> ordered)
        {
            if (node == null) return;

            TraverseInOrder(node.left, ordered);
            ordered.Add(node.val);
            TraverseInOrder(node.right, ordered);
        }
    }
}
