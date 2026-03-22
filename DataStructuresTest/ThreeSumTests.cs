using DataStructures;
using NUnit.Framework;

namespace DataStructuresTest;

[TestFixture]
public sealed class ThreeSumTests
{
    [Test]
    public void ThreeSums_ExampleInput_ReturnsExpectedTriplets()
    {
        var sut = new ThreeSum();
        var nums = new[] { -1, 0, 1, 2, -1, -4 };
        var max = sut.CharacterReplacement("AAABABCAAAAA", 1);
        
        var actual = NormalizeTriplets(sut.ThreeSums(nums));

        var expected = new HashSet<string>
        {
            "-1,-1,2",
            "-1,0,1",
        };

        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Test]
    public void ThreeSums_AllZeros_ReturnsSingleTriplet()
    {
        var sut = new ThreeSum();
        var nums = new[] { 0, 0, 0, 0 };

        var actual = NormalizeTriplets(sut.ThreeSums(nums));

        var expected = new HashSet<string> { "0,0,0" };
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    private static HashSet<string> NormalizeTriplets(List<List<int>> triplets)
    {
        var normalized = new HashSet<string>(StringComparer.Ordinal);
        foreach (var t in triplets)
        {
            // Avoid relying on output order; compare as sets of sorted triplets.
            var a = t[0];
            var b = t[1];
            var c = t[2];

            if (a > b) (a, b) = (b, a);
            if (b > c) (b, c) = (c, b);
            if (a > b) (a, b) = (b, a);

            normalized.Add($"{a},{b},{c}");
        }

        return normalized;
    }
}
