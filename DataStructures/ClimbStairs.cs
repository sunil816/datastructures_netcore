namespace DataStructures;

//
public class ClimbStairs
{
    int NoOfStairs;

    public int NoOfDifferentWaysToClimbStairsIterative(int noOfStairs)
    {
        if (noOfStairs == 0)
        {
            return 0;
        }

        int noOfWaysToReachFromOneLevelBelow = 1;
        int noOfWaysToReachFromTwoLevelsBelow = 2;
        if (noOfStairs == 1)
        {
            return noOfWaysToReachFromOneLevelBelow;
        }
        if (noOfStairs == 2)
        {
            return noOfWaysToReachFromTwoLevelsBelow;
        }

        int noOfWaysToReachFromThreeLevelsBelow = noOfWaysToReachFromOneLevelBelow + noOfWaysToReachFromTwoLevelsBelow;
        for (int currentStairLevel = noOfStairs - 3; currentStairLevel >= 0; currentStairLevel--)
        {
            noOfWaysToReachFromThreeLevelsBelow = noOfWaysToReachFromOneLevelBelow + noOfWaysToReachFromTwoLevelsBelow;
            noOfWaysToReachFromOneLevelBelow = noOfWaysToReachFromTwoLevelsBelow;
            noOfWaysToReachFromTwoLevelsBelow = noOfWaysToReachFromThreeLevelsBelow;
        }
        return noOfWaysToReachFromThreeLevelsBelow;
    }
    public int NoOfDifferentWaysToClimbStairs(int N)
    {
        NoOfStairs = N;
        int[] noOfWaysToReachStairsAtLevelN = new int[N];
        for (int i = 0; i < N; i++)
        {
            noOfWaysToReachStairsAtLevelN[i] = -1;
        }
        
        return CalculateClimbStairs(noOfWaysToReachStairsAtLevelN, 0);
    }

    int CalculateClimbStairs(int[] noOfWaysToReachStairsAtLevelN, int startLevel)
    {
        if (startLevel >= NoOfStairs)
        {
            return 0;
        }

        if (startLevel == NoOfStairs - 1)
        {
            return 1;
        }
        if (startLevel == NoOfStairs - 2)
        {
            return 2;
        }

        if (noOfWaysToReachStairsAtLevelN[startLevel] != -1)
        {
            return noOfWaysToReachStairsAtLevelN[startLevel];
        }
        int noOfWaysToReachFromOneLevelUp = CalculateClimbStairs(noOfWaysToReachStairsAtLevelN, startLevel + 1);
        int noOfWaysToReachFromTwoLevelsUp = CalculateClimbStairs(noOfWaysToReachStairsAtLevelN, startLevel + 2);
        noOfWaysToReachStairsAtLevelN[startLevel] = noOfWaysToReachFromOneLevelUp + noOfWaysToReachFromTwoLevelsUp;
        return noOfWaysToReachStairsAtLevelN[startLevel];
    }
}