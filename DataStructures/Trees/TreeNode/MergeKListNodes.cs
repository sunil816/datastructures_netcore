namespace DataStructures.Trees.TreeNodeNew;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val=0, ListNode next=null)
    {
        this.val = val;
        this.next = next;
    }
}
public class MergeKListNodes
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        ListNode mergedNodesRoot = null;
        ListNode curNodeInMergedNodes = null;
        PriorityQueue<ListNode, int> queue = new PriorityQueue<ListNode, int>();
        foreach (var listNode in lists)
        {
            queue.Enqueue(listNode, listNode.val);
        }

        while (queue.Count > 0)
        {
            var curNode = queue.Dequeue();
            if (mergedNodesRoot == null)
            {
                mergedNodesRoot = curNode;
                curNodeInMergedNodes = curNode;
            }
            else
            {
                curNodeInMergedNodes.next = curNode;
                curNodeInMergedNodes = curNodeInMergedNodes.next;
            }

            if (queue.Count == 0)
            {
                break;
            }

            if (curNode.next != null)
            {
                queue.Enqueue(curNode.next, curNode.next.val);
            }
        }

        return mergedNodesRoot;
    }
}