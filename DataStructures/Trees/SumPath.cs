/*
 * A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them.
 * A node can only appear in the sequence at most once. Note that the path does not need to pass through the root.
 * The path sum of a path is the sum of the node's values in the path.
 * Given the root of a binary tree, return the maximum path sum of any non-empty path.
 */

using System.Numerics;

public class TreeNode
{
    public int val { set; get; }
    public TreeNode? left { get; set; }
    public TreeNode? right { get; set; }

    public TreeNode(int val, TreeNode? left, TreeNode? right)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class SumPath
{
    private TreeNode root;
    private int maximum = Int32.MinValue;
    public int MaxPathSum(TreeNode root)
    {
        CalculateMaxPathSum(root);
        return maximum;
    }
    
    // 1 5 7 3 11 5 9 0
    
    //1  4   4   4  6  6  7  7
    //1, 3, -1, -3, 5, 3, 6, 7
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int[] maxIndexes = new int[nums.Length];
        int[] res = new int[nums.Length];
        Stack<int> maxElementsIndex = new Stack<int>();
        maxIndexes[nums.Length - 1] = nums.Length - 1;
        maxElementsIndex.Push(nums.Length - 1);
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            var curElement = nums[i];
            while (maxElementsIndex.Count > 0 && curElement >= nums[maxElementsIndex.Peek()])
            {
                maxElementsIndex.Pop();
            }

            if (maxElementsIndex.Count > 0)
            {
                maxIndexes[i] = maxElementsIndex.Peek();
            }
            else
            {
                maxIndexes[i] = -1;
            }
            maxElementsIndex.Push(i);
        }

        var currentMaxIndex = 0;
        for (int i = 0; i < (nums.Length);)
        {
            int maxRightIndex = (i + k - 1);
            if (currentMaxIndex < i && maxIndexes[currentMaxIndex] > maxRightIndex)
            {
                currentMaxIndex = i;
            }
            
            while (maxIndexes[currentMaxIndex] <= maxRightIndex && 
                   maxIndexes[currentMaxIndex] != -1 && 
                   currentMaxIndex != (nums.Length - 1))
            {
                currentMaxIndex = maxIndexes[currentMaxIndex];
            }

            res[i] = nums[currentMaxIndex];
            i++;
        }

        return res;
    }
    
    public int Trap(int[] height)
    {
        int[] rightGreaterHeight = new int[height.Length];
        Stack<int> heightsFromRight = new Stack<int>();
        for (int rightIndex = height.Length - 1; rightIndex >= 0; rightIndex--)
        {
            if (heightsFromRight.Count == 0)
            {
                rightGreaterHeight[rightIndex] = -1;
                heightsFromRight.Push(rightIndex);
            }
            else
            {
                int rightNextGreatest = -1;
                while (heightsFromRight.Count > 0 
                       && height[rightIndex] > height[heightsFromRight.Peek()])
                {
                    rightNextGreatest = heightsFromRight.Pop();
                }

                if (heightsFromRight.Count > 0)
                {
                    rightGreaterHeight[rightIndex] = heightsFromRight.Peek();
                }
                else
                {
                    rightGreaterHeight[rightIndex] = rightNextGreatest;
                }
                heightsFromRight.Push(rightIndex);
            }
        }

        int totalCapacity = 0;
        for (int leftIndex = 0; leftIndex < rightGreaterHeight.Length - 1; )
        {
            int rightIndex = rightGreaterHeight[leftIndex];
            if (rightIndex == -1)
            {
                leftIndex++;
                continue;
            }

            int minheight = Math.Min(height[leftIndex], height[rightIndex]);
            int idealCapacity = minheight * (rightIndex - leftIndex - 1);
            int heightsInBetweenIndexes = HeightsInBetweenIndex(leftIndex, rightIndex, height);
            totalCapacity += idealCapacity - heightsInBetweenIndexes;
            leftIndex = rightIndex;
        }

        return totalCapacity;
    }

    int HeightsInBetweenIndex(int left, int right, int[] heights)
    {
        int heightsInBetween = 0;
        int startIndex = left + 1;
        while (startIndex < right)
        {
            heightsInBetween += heights[startIndex];
            startIndex++;
        }

        return heightsInBetween;
    }
    
    public int MaxArea(int[] height)
    {
        int max = Int32.MinValue;
        for (int i = 0, j = height.Length - 1; i < j;)
        {
            var min = Math.Min(height[j], height[i]);
            var data = min * (j - i);
            if (max < data)
            {
                max = data;
            }

            if (height[i] < height[j])
            {
                i++;
            }
            else
            {
                j--;
            }
        }

        return max;
    }

    private int CalculateMaxPathSum(TreeNode root)
    {
        if (root is null)
        {
            return 0;
        }

        int currentSum = root.val;
        int leftMaxSum = CalculateMaxPathSum(root.left);
        int rightMaxSum = CalculateMaxPathSum(root.right);
        if (maximum < (currentSum + leftMaxSum + rightMaxSum))
        {
            maximum = (currentSum + leftMaxSum + rightMaxSum);
        }
        if (leftMaxSum > 0 && leftMaxSum > rightMaxSum)
        {
            currentSum += leftMaxSum;
        }
        else if(rightMaxSum > 0)
        {
            currentSum += rightMaxSum;
        }

        if (currentSum > maximum)
        {
            maximum = currentSum;
        }

        return currentSum;
    }
}