using DataStructures.Trees.TreeNodeNew;
namespace DataStructures.Trees.TreeNodeNew;
 // Definition for a binary tree node.
 
public class InvertBinaryTree
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
        {
            return root;
        }

        InvertTree(root.left);
        InvertTree(root.right);
        (root.left, root.right) = (root.right, root.left);
        return root;
    }
    
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        if (root is null)
        {
            return root;
        }

        ReverseOddLevelsData(root.left, root.right, 1);
        return root;
    }

    private void ReverseOddLevelsData(TreeNode node1, TreeNode node2, int level)
    {
        if (node1 is null)
        {
            return;
        }
        
        ReverseOddLevelsData(node1.left, node2.right, level + 1);
        ReverseOddLevelsData(node1.right, node2.left, level + 1);
        if (level % 2 == 1)
        {
            (node1.val, node2.val) = (node2.val, node1.val);
        }
    }
}