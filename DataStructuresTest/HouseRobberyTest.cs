using DataStructures;

namespace DataStructuresTest;

public class HouseRobberyTest
{
    [Test]
    public void HouseRobberyTestCase()
    {
        var houseRobbery = new HouseRobbery();
        var res = houseRobbery.RobWithOutFirstAndLast(new int[] {2, 7, 9, 3, 1});
        Assert.That(res, Is.EqualTo(11));
        res = houseRobbery.RobWithOutFirstAndLast(new int[] {1, 2, 3, 1});
        Assert.That(res, Is.EqualTo(4));
    }
}