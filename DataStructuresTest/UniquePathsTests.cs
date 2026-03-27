using DataStructures;

namespace DataStructuresTest;

public class UniquePathsTests
{
    [Test]
    public void UniquePathsTest()
    {
        var uniquePath = new UniquePath();
        var noOfUniqueWays = uniquePath.UniquePaths(1, 1);
        Assert.That(noOfUniqueWays, Is.EqualTo(1));
        noOfUniqueWays = uniquePath.UniquePaths(3, 2);
        Assert.That(noOfUniqueWays, Is.EqualTo(3));
        noOfUniqueWays = uniquePath.UniquePaths(3, 7);
        Assert.That(noOfUniqueWays, Is.EqualTo(28));
    }
}