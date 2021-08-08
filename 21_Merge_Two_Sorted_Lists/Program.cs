using System;
using System.Collections.Generic;

namespace _21_Merge_Two_Sorted_Lists
{
    class Program
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) 
            { 
                val = x;
                next = null;
            }
        }

        static void Main(string[] args)
        {
            ListNode l11 = new ListNode(1);
            ListNode l12 = new ListNode(2);
            ListNode l13 = new ListNode(3);

            l11.next = l12;
            l12.next = l13;

            ListNode l21 = new ListNode(2);
            ListNode l22 = new ListNode(3);
            ListNode l23 = new ListNode(5);

            l21.next = l22;
            l22.next = l23;

            var res = merge_two_lists(l11, l21);

            while (res != null)
            {
                Console.Write(res.val);
                res = res.next;
            }

            Console.ReadKey();
        }

#if false 
        // leetcode 방식
        private static ListNode merge_two_lists(ListNode l1, ListNode l2)
        {
            // maintain an unchanging reference to non ahead of the return node.
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }

            // At least one of l1 and l2 can still have nodes at this point, so connect
            // the non-null list to the end of the merged list

            prev.next = l1 == null ? l2 : l1; 
            return prehead.next;
        }
#else
        // recursive 방식
        private static ListNode merge_two_lists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            if (l1.val < l2.val)
            {
                l1.next = merge_two_lists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = merge_two_lists(l2.next, l1);
                return l2;
            }
        }
#endif
    }
}
