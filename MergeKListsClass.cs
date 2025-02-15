// TC ==> O(nklogk) 
// SC ==> O(k)

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
        {
            return null;
        }

        ListNode dummyNode = new ListNode(Int32.MaxValue);
        PriorityQueue<ListNode, int> pQueue = new PriorityQueue<ListNode, int>();
        foreach (var list in lists)
        {
            if (list == null)
            {
                continue;
            }
            pQueue.Enqueue(list, list.val);
        }

        ListNode current = dummyNode;
        while (pQueue.Count > 0)
        {
            var node = pQueue.Dequeue();
            if (node.next != null)
            {
                pQueue.Enqueue(node.next, node.next.val);
            }
            current.next = node;
            current = current.next;
        }

        return dummyNode.next;
    }
}