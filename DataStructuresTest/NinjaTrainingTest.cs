using DataStructures;

namespace DataStructuresTest;

[TestFixture]
public class NinjaTrainingTest
{
    [Test]
    public void VerifyMaxMeritPoints()
    {
        var ninjaTraining = new NinjaTraining();
        var maxPoints = ninjaTraining.MaxMeritPoints(3,
        new int [][] {
            new int[] { 1,2,5},
            new int[] { 3,1,1},
            new int[] { 3,3,3},
        });
        Assert.That(maxPoints, Is.EqualTo(11));

        var maxPointsIterative = ninjaTraining.CalculateMaxMeritPointsIterative(3,
            new int[][]
            {
                new int[] { 1, 2, 5 },
                new int[] { 3, 1, 1 },
                new int[] { 3, 3, 3 },
            });
        Assert.That(maxPointsIterative, Is.EqualTo(11));

    }
}