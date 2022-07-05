using System;
using System.Collections.Generic;

namespace Merge_Two_Sorted_Lists
{

    //Definition for singly-linked list.
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
            var l1 = ArrayToList(new int[] { 1, 3, 8, 10 });
            var l2 = ArrayToList(new int[] { 1, 4, 5, 6 });

            //var l1 = ArrayToList(new int[] { 10, 20, 30 });
            //var l2 = ArrayToList(new int[] { 1, 2, 3 });
            Console.Write("List1 = ");
            PrintList(l1);
            Console.Write("List2 = ");
            PrintList(l2);
            Console.Write("Merged List = ");
            PrintList(MergeTwoLists(l1, l2));
        }

        static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            //Dummy Node which will destory prev value when node.next happens.
            var node = new ListNode();
            //to save original values of node.
            var head = node;

            while (list1 != null || list2 != null)
            {
                //Take node for L1 List
                if (list2 == null || (list1 != null && list1.val < list2.val))
                {
                    // copy entire list1 to node
                    node.next = list1;
                    // increment the list1 to remove prev value
                    list1 = list1.next;
                }
                //Take node for L2 List
                else
                {
                    // copy entire list2 to node
                    node.next = list2;
                    // increment the list1 to remove prev value
                    list2 = list2.next;
                }
                node = node.next;
            }

            return head.next;
        }



        static ListNode ArrayToList(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            var node = new ListNode(0);
            var head = node;
            foreach (var num in nums)
            {
                node.next = new ListNode(num);
                node = node.next;
            }
            return head.next;
        }

        static void PrintList(ListNode root)
        {
            Console.Write($"{root.val}");
            if (root.next != null)
            {
                Console.Write("-->");
                PrintList(root.next);
            }
            else
                Console.WriteLine();
        }
    }
}