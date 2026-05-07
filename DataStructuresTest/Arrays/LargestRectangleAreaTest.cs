using DataStructures.Arrays;

namespace DataStructuresTest.Arrays;

public class LargestRectangleAreaTest
{
    [Test]
    public void TestBaseCase()
    {
        LargestRectangleArea largestRectangleArea = new();
        int maxRectangle = largestRectangleArea.LargestRectangleArea2(new int[]{2,1,5,6,2,3});
        Assert.That(10, Is.EqualTo(maxRectangle));
    }
}