using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblem
{
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
    public class MinDepthOfTree
    {
        static TreeNode BuildTree(string[] elements, int index)
        {
            if (index >= elements.Length || elements[index] == "null")
                return null;
            TreeNode node = new TreeNode(int.Parse(elements[index]));
            node.left = BuildTree(elements, 2 * index + 1);
            node.right = BuildTree(elements, 2 * index + 2);
            return node;
        }
        static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;
            if (root.left == null) return MinDepth(root.right) + 1;
            if (root.right == null) return MinDepth(root.left) + 1;
            return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }
        public static void CalculateMinDepth()
        {
            Console.WriteLine("Enter the elements separated by spaces and use null for empty nodes:");
            string[] elements = Console.ReadLine().Split(' ');
            TreeNode root = BuildTree(elements, 0);
            int minDepth = MinDepth(root);
            Console.WriteLine($"Minimum depth of the binary tree is: {minDepth}");
        }
    }
}
