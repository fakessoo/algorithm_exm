using System;

namespace _83_Remove_Duplicates_from_Sorted_List
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //ListNode head_4 = new ListNode(3);
            //ListNode head_3 = new ListNode(3, head_4);
            ListNode head_2 = new ListNode(2);
            ListNode head_1 = new ListNode(1, head_2);
            ListNode head = new ListNode(1, head_1);
            DeleteDuplicates(head);
            while (head.next != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            ListNode base_node = head;
            while (base_node != null && base_node.next != null)
            {
                if (base_node.val == base_node.next.val)
                {
                    base_node.next = base_node.next.next;
                }
                else
                {
                    base_node = base_node.next;
                }
            }
            return head;
        }
    }


}
