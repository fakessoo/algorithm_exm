using System;

namespace _100_Same_Tree
{
    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            TreeNode q = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            Console.Write(IsSameTree(p, q));
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
#if true

            //   1. Recursion

            //  Intuition  

            //  The simplest stragegy here is to use recursion. 
            //  Check if 'p' and 'q' nodes are not 'None', and their values are equal.
            //  If all checks are OK, do the same for the child nodes recursively.

            //   p and q are both null
            if (p == null && q == null) return true;

            //   one of p and q is null
            if (p == null || q == null) return false;

            if (p.val != q.val) return false;

            return IsSameTree(p.right, q.right) && IsSameTree(p.left, q.left);

            //  Time complexity : O(N), where N is a number of nodes in the tree, since one visits each node exactly once.

            //  Space complexity : O(log(N)) in the best case of compeletly balanced tree 
            //      and O(N) in the worst case of completetly unbalanced tree to keep a recursion stack.


#endif
        }
    }


}
