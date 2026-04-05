namespace DataStructures;

public class ListNode
{
    public int val { get; set; }
    public ListNode? next { get; set; }
    public ListNode(int val, ListNode? next)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode CreateLinkedNode(int[] data)
    {
        ListNode res = null;
        ListNode prev = null;
        ListNode cur;
        for (int i = 0; i < data.Length; i++)
        {
            cur = new ListNode(data[i], null);
            if (res == null)
            {
                res = cur;
            }
            if (prev != null)
            {
                prev.next = cur;
            }
            prev = cur;
        }
        return res;
    }
    
    public static int[] GetListData(ListNode listNode)
    {
        List<int> data = new List<int>();
        while (listNode != null)
        {
            data.Add(listNode.val);
            listNode = listNode.next;
        }
        return data.ToArray();
    }
}


public class MergeKSortedList
{
    public static ListNode GetMergedList(ListNode[]  linkedNodes)
    {
        ListNode mergedList = null;
        PriorityQueue<ListNode, int> priorityQueue = new PriorityQueue<ListNode, int>();
        for (var startIndex = 0; startIndex < linkedNodes.Length; startIndex++)
        {
            priorityQueue.Enqueue(linkedNodes[startIndex], linkedNodes[startIndex].val);
        }
        ListNode previousNode = null;
        while (priorityQueue.Count > 0)
        {
            var currentNode = priorityQueue.Dequeue();
            if (mergedList == null)
            {
                mergedList = currentNode;
                previousNode =  currentNode;
            }
            else
            {
                // Avoid null-conditional assignment (preview feature) by using a normal assignment.
                previousNode.next = currentNode;
                previousNode = currentNode;
            }

            if (currentNode.next != null)
            {
                priorityQueue.Enqueue(currentNode.next, currentNode.next.val);
            }
        }
        return mergedList;
    }
}
