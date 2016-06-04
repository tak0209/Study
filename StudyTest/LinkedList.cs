using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTest
{
    public class LinkedList
    {
        public LinkNode AddLinkNode(LinkNode p1, LinkNode p2)
        {
            LinkNode head = null, p3 = null;
            int carry = 0;

            while (p1 !=null|| p2!=null)
            {
                int total = 0;
                if (p1!=null)
                {
                    total += p1.value;
                    p1 = p1.next;
                }

                if (p2!=null)
                {
                    total += p2.value;
                    p2 = p2.next;
                }

                total += carry;
                carry = total / 10;

                if (head==null)
                {
                    head = new LinkNode(total % 10);
                    p3 = head;
                }
                else
                {
                    p3.next =  new LinkNode(total % 10);
                    p3 = p3.next;
                }
            }

            return head;
        }

        //based on a 3 element list     1 -> 2 ->3   the fast pointer will be moved to 2^n where n=n+1:: 2, 4, 6, 8.... therefore when fast is at the end then slow is in the middle (slow @2 fast @ end)
        public static void SplitLinkInMiddle(LinkNode head, ref LinkNode first, ref LinkNode last)
        {
            if (head == null)
                return; // Handle empty list

            LinkNode slow = head;
            LinkNode fast = head;
            while (fast!= null)
            {
                slow = slow.next;
                fast = (fast.next != null) ? fast.next.next : null;
            }
            last = slow;
            first = head;
        }
    }
}
