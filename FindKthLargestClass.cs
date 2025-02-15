// TC => O(NlogK) where n is total number of elements in the array and k is total number of elements in the heap
// SC => O(k)

public class Solution
{
    public class MinComparer : IComparer<int>
    {
        public int Compare(int x, int y) => x.CompareTo(y);
    }
    public int FindKthLargest(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }

        PriorityQueue<int, int> pQueue = new PriorityQueue<int, int>(new MinComparer());
        foreach (var num in nums)
        {
            pQueue.Enqueue(num, num);
            if (pQueue.Count == k + 1)
            {
                pQueue.Dequeue();
            }
        }

        return pQueue.Dequeue();
    }
}