using DataStructures;

namespace DataStructuresTest;

public class MergeKSortedListTests
{
    [Test]
    public void MergeKSortedListTest()
    {
        var list1 = ListNode.CreateLinkedNode([1,2,4]);
        var list2 = ListNode.CreateLinkedNode([1,3,5]);
        var list3 = ListNode.CreateLinkedNode([3,6]);
        var mergedList = MergeKSortedList.GetMergedList([list1, list2, list3]);
        var res = ListNode.GetListData(mergedList);
        Assert.That(res, Is.EqualTo(new[] { 1, 1, 2, 3, 3, 4, 5, 6 }));
    }
}
