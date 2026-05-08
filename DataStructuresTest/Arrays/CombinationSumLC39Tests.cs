using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DataStructures.Arrays;

namespace DataStructuresTest.Arrays;

public class CombinationSumLC39Tests
{
    private CombinationSumLC39 _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new CombinationSumLC39();
    }

    [Test]
    public void CombinationSum_Test_NormalCase()
    {
        int[] candidates = { 2, 3, 6, 7 };
        int target = 7;
        
        var result = _sut.CombinationSum(candidates, target);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));

        // Check for presence of { 2, 2, 3 } and { 7 } ignoring order
        Assert.That(ContainsCombination(result, new List<int> { 2, 2, 3 }), Is.True);
        Assert.That(ContainsCombination(result, new List<int> { 7 }), Is.True);
    }
    
    [Test]
    public void CombinationSum_Test_MultipleCombinations()
    {
        int[] candidates = { 2, 3, 5 };
        int target = 8;
        
        var result = _sut.CombinationSum(candidates, target);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(3));

        Assert.That(ContainsCombination(result, new List<int> { 2, 2, 2, 2 }), Is.True);
        Assert.That(ContainsCombination(result, new List<int> { 2, 3, 3 }), Is.True);
        Assert.That(ContainsCombination(result, new List<int> { 3, 5 }), Is.True);
    }

    [Test]
    public void CombinationSum_Test_NoCombination()
    {
        int[] candidates = { 2 };
        int target = 1;
        
        var result = _sut.CombinationSum(candidates, target);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(0));
    }

    private bool ContainsCombination(IList<IList<int>> results, IList<int> combination)
    {
        var sortedCombination = combination.OrderBy(x => x).ToList();
        
        foreach (var res in results)
        {
            if (res.Count == sortedCombination.Count)
            {
                var sortedRes = res.OrderBy(x => x).ToList();
                bool isMatch = true;
                for (int i = 0; i < sortedRes.Count; i++)
                {
                    if (sortedRes[i] != sortedCombination[i])
                    {
                        isMatch = false;
                        break;
                    }
                }
                
                if (isMatch)
                {
                    return true;
                }
            }
        }
        
        return false;
    }
}
