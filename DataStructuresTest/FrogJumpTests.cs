using DataStructures;

namespace DataStructuresTest;

public class FrogJumpTests
{
    [Test]
    public void FrogJumpTest()
    {
        var frogJump = new FrogJump();
        var minEnergy = frogJump.MinEnergyRequiredForJump(4, new int[] {10, 20, 30, 10});
        Assert.That(20, Is.EqualTo(minEnergy));
    }
}