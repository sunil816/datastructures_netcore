namespace DataStructures.Trees;
/*
 * Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
   
   According to the definition of LCA on Wikipedia: 
   “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that 
   has both p and q as descendants (where we allow a node to be a descendant of itself).”
   
 */
public class TreeNode
{
  public int val { get; private set; }
  public TreeNode? left { get; private set; }
  public TreeNode? right { get; private set; }
  
  public TreeNode(int value, TreeNode? left, TreeNode? right)
  {
    this.val = value;
    this.left = left;
    this.right = right;
  }
  
  public void SetChildren(TreeNode parent, TreeNode? left, TreeNode? right)
  {
    parent.left = left;
    parent.right = right;
  }
}
public class LongestCommonAncestor
{
  public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
  {
    Stack<TreeNode> nodesInPathForNodeP = new Stack<TreeNode>();
    PopulateNodesInPath(root, nodesInPathForNodeP, p);
    Stack<TreeNode> nodesInPathForNodeQ = new Stack<TreeNode>();
    PopulateNodesInPath(root, nodesInPathForNodeQ, q);
    NodesTillCommonHeight(nodesInPathForNodeP, nodesInPathForNodeQ);
    while (nodesInPathForNodeQ.Peek() != nodesInPathForNodeP.Peek())
    {
      nodesInPathForNodeQ.Pop();
      nodesInPathForNodeP.Pop();
    }
    return nodesInPathForNodeP.Peek();
  }

  private static void NodesTillCommonHeight(Stack<TreeNode> nodesInPathForNodeP, Stack<TreeNode> nodesInPathForNodeQ)
  {
    if (nodesInPathForNodeP.Count > nodesInPathForNodeQ.Count)
    {
      while (nodesInPathForNodeP.Count != nodesInPathForNodeQ.Count)
      {
        nodesInPathForNodeP.Pop();
      }
    }
    else
    {
      while (nodesInPathForNodeP.Count != nodesInPathForNodeQ.Count)
      {
        nodesInPathForNodeQ.Pop();
      }
    }
  }

  private bool PopulateNodesInPath(TreeNode? root, Stack<TreeNode> nodesInPath, TreeNode nodeToFind)
  {
    if (root is null)
    {
      return false;
    }
    nodesInPath.Push(root);
    if (root == nodeToFind )
    {
      return true;
    }
    var nodeFound = PopulateNodesInPath(root.left, nodesInPath, nodeToFind);
    nodeFound = nodeFound || PopulateNodesInPath(root.right, nodesInPath, nodeToFind);
    if (!nodeFound)
    {
      nodesInPath.Pop();
    }
    return nodeFound;
  }
}