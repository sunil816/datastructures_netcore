using DataStructures.Strings;

namespace DataStructuresTest.Trees;

public class StringPermutationTests
{
    [Test]
    public void VerifyStringPermutation()
    {
        StringPermutation stringPermutation = new();
        //var isInclusive = stringPermutation.CheckInclusion("ab", "adbada");

        StringGeneral stringGeneral = new();
        stringGeneral.MinWindow("ADOBECODEBANC", "ABC");
    }
}