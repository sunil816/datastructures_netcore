namespace DataStructures.Arrays;

public class CombinationSumLC39
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>>? [][]sumCombinations = new IList<IList<int>>[candidates.Length][];
        for (int i=0; i < candidates.Length; i++)
        {
            sumCombinations[i] = new IList<IList<int>>[target + 1];
        }

        for (int row = candidates.Length - 1; row >= 0; row--)
        {
            int candidateValue = candidates[row];
            for (int curTarget = 1; curTarget <= target; curTarget++)
            {
                if (curTarget == candidateValue)
                {
                    List<int> res = new List<int>() { curTarget };
                    sumCombinations[row][curTarget] = new List<IList<int>>() { res };
                }

                var sumWithCurTargetConsidered = curTarget - candidateValue;
                if (curTarget > candidateValue && sumCombinations[row][sumWithCurTargetConsidered] != null)
                {
                    sumCombinations[row][curTarget] = new List<IList<int>>();
                    foreach (var lastRes in sumCombinations[row][sumWithCurTargetConsidered])
                    {
                        var curRes = new List<int>();
                        curRes.Add(candidateValue);
                        curRes.AddRange(lastRes);
                        sumCombinations[row][curTarget].Add(curRes);
                    }
                }

                if (row < candidates.Length - 1 && sumCombinations[row+1][curTarget] != null)
                {
                    if (sumCombinations[row][curTarget] is null)
                    {
                        sumCombinations[row][curTarget] = new List<IList<int>>();
                    }

                    foreach (var nextRowResult in sumCombinations[row+1][curTarget])
                    {
                        var copyRes = new List<int>() { };
                        copyRes.AddRange(nextRowResult);
                        sumCombinations[row][curTarget].Add(copyRes);
                    }
                }
            }
        }
        return sumCombinations[0][target] ?? new List<IList<int>>();
    }
}