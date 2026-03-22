using DataStructures;
using NUnit.Framework;

namespace DataStructuresTest;

public class ClimbStairsTests
{
    [Test]
    public void CheckClimbStairsTest()
    {
        var climbStairs = new ClimbStairs();
        var noOfSteps = climbStairs.NoOfDifferentWaysToClimbStairs(4);
        Assert.That(noOfSteps, Is.EqualTo(5));
        var noOfStepsIterative = climbStairs.NoOfDifferentWaysToClimbStairsIterative(4);
        Assert.That(noOfStepsIterative, Is.EqualTo(5));

    }
}