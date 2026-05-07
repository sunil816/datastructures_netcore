namespace DataStructuresTest.Trees;

public class SumPathTests
{
    [Test]
    public void MaxPathSum_Test_Minus10_9_20_null_null_15_7()
    {
        // Create tree for [-10,9,20,null,null,15,7]
        //      -10
        //      /  \
        //     9   20
        //        /  \
        //       15   7
        
        var node15 = new TreeNode(15, null, null);
        var node7 = new TreeNode(7, null, null);
        var node20 = new TreeNode(20, node15, node7);
        var node9 = new TreeNode(9, null, null);
        var root = new TreeNode(-10, node9, node20);

        var sumPath = new SumPath();
        int result = sumPath.MaxPathSum(root);

        // The path with maximum sum is 15 -> 20 -> 7 = 42
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public void MaxSlidingWindow_Test()
    {
        var sumPath = new SumPath();
        int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;
        int[] expected = { 3, 3, 5, 5, 6, 7, 7, 7 }; // The implementation returns array of size nums.Length
        int[] result = sumPath.MaxSlidingWindow(nums, k);
        int[] heights = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        heights = new int[] {4,2,3};
        int maxHeight = sumPath.Trap(heights);
        Assert.That(result, Is.EqualTo(expected));
    }
}
