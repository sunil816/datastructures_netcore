namespace DataStructures;

public class ThreeSum {
    public List<List<int>> ThreeSums(int[] nums)
    {
        List<List<int>> response = new List<List<int>>();
        Array.Sort(nums);
        int innerLeftIndex, innerRightIndex;
        int twoSum = 0;
        for (int outerIndex = 0; outerIndex < (nums.Length - 2); outerIndex++)
        {
            if (outerIndex > 0 && nums[outerIndex - 1] == nums[outerIndex])
            {
                continue;
            }
            innerLeftIndex = outerIndex + 1;
            innerRightIndex = nums.Length - 1;
            twoSum = 0 - nums[outerIndex];
            int prevInnerLeftIndexValue = 0,  prevInnerRightIndexValue = 0;
            bool found = false;
            while (innerLeftIndex < innerRightIndex)
            {
                
                if ((nums[innerLeftIndex] + nums[innerRightIndex] == twoSum) && 
                    (!found || !(prevInnerLeftIndexValue == nums[innerLeftIndex] &&  prevInnerRightIndexValue == nums[innerRightIndex])))
                {
                    response.Add(new List<int>() {nums[outerIndex], nums[innerLeftIndex], nums[innerRightIndex]});
                    prevInnerLeftIndexValue = nums[innerLeftIndex];
                    prevInnerRightIndexValue = nums[innerRightIndex];
                    innerLeftIndex++;
                    innerRightIndex--;
                    found = true;
                }
                else if ((nums[innerLeftIndex] + nums[innerRightIndex]) < twoSum)
                {
                    innerLeftIndex++;
                }
                else
                {
                    innerRightIndex--;
                }
            }
        }

        return response;
    }
}
