namespace DataStructures.Arrays;

public class LargestRectangleArea
{
    public void KthLargest(int k, int[] nums)
    {
        PriorityQueue<int, int> kthLargest = new PriorityQueue<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (kthLargest.Count < k)
            {
                kthLargest.Enqueue(nums[i], nums[i]);
            }
            else if(kthLargest.Peek() < nums[i])
            {
                kthLargest.Dequeue();
                kthLargest.Enqueue(nums[i], nums[i]);
            }
        }
    }
    
    public int Add(PriorityQueue<int, int> kthLargest, int k, int val) {
        if (kthLargest.Peek() < val)
        {
            kthLargest.Dequeue();
            kthLargest.Enqueue(val,val);
        }

        return kthLargest.Peek();
    }
    public int LargestRectangleArea2(int[] heights) {
        int[] smallestIndexToTheRight = new int[heights.Length];
        int[] smallestIndexToTheLeft = new int[heights.Length];
        Stack<int> data = new Stack<int>();
        
        for (int i = heights.Length - 1; i >= 0; i--)
        {
            smallestIndexToTheRight[i] = -1;
            smallestIndexToTheLeft[i] = -1;
        }
        for(int i=heights.Length-1; i>=0; i--)
        {
            if (data.Count == 0)
            {
                data.Push(i);
            }
            else
            {
                while (data.Count > 0)
                {
                    if (heights[data.Peek()] < heights[i])
                    {
                        smallestIndexToTheRight[i] = data.Peek();
                        break;
                    }
                    else
                    {
                        var ind = data.Pop();
                        smallestIndexToTheLeft[ind] = i;
                    }
                }

                data.Push(i);
            }
        }

        int maxRectangle = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            int leftIndex = smallestIndexToTheLeft[i] == -1 ? 0 : smallestIndexToTheLeft[i]+1;
            int rightIndex = smallestIndexToTheRight[i] == -1 ? heights.Length - 1 : smallestIndexToTheRight[i]-1;
            int curRectangle = heights[i] * (rightIndex - leftIndex + 1);
            maxRectangle = Math.Max(maxRectangle, curRectangle);
        }

        return maxRectangle;
    }
}