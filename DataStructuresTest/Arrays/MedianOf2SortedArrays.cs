namespace DataStructuresTest.Arrays;

public class MedianOf2SortedArrays
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        double total = 0;
        int totalLength = (nums1.Length + nums2.Length);
        int rightMedianIndex = totalLength/2;
        int leftMedianIndex = -1;
        if (totalLength % 2 == 0)
        {
            leftMedianIndex = rightMedianIndex - 1;
        }

        int[] temp = nums1;
        if (nums1.Length < nums2.Length)
        {
            nums1 = nums2;
            nums2 = temp;
        }

        if (nums1.Length == 0)
        {
            return total;
        }

        if (nums2.Length == 0)
        {
            total = nums2[rightMedianIndex];

            if (leftMedianIndex != -1)
            {
                total = (total + nums2[leftMedianIndex]) / 2;
            }

            return total;
        }

        int leftIndex = 0;
        int rightIndex = nums1.Length - 1;
        int leftIndexN2 = 0;
        int rightIndexN2 = nums2.Length - 1;
        while (leftIndex < rightIndex)
        {
            int mid = leftIndex + (rightIndex - leftIndex) / 2;
            int insertIndex = GetInsertIndex(nums2, leftIndexN2, rightIndexN2, nums1[mid]);
            int midIndexInMergedArray = mid + insertIndex;
            if (midIndexInMergedArray == rightMedianIndex)
            {
                return nums1[mid];
            }
            if (midIndexInMergedArray < rightMedianIndex)
            {
                leftIndex = mid + 1;
                
            }
            else
            {
                
            }
        }

        return total;
    }

    private int GetInsertIndex(int [] nums, int leftIndex, int rightIndex, int val)
    {
        while (leftIndex < rightIndex)
        {
            int mid = leftIndex + (rightIndex - leftIndex) / 2;
            if (mid != (nums.Length-1) && nums[mid] <= val && nums[mid+1] > val)
            {
                return mid+1;
            }
            else if (nums[mid] < val)
            {
                leftIndex = mid + 1;
            }
            else
            {
                rightIndex = mid - 1;
            }
        }

        return leftIndex;
    }
}