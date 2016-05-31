using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase
{
    [TestClass]
    public class LinkTest
    {
        [TestMethod]
        public void AddLinkTest()
        {
            //3->2->1
            LinkNode L1 = new LinkNode(3);
            L1.next = new LinkNode(2);
            L1.next.next = new LinkNode(1);
            L1.next.next.next = new LinkNode(5);

            //8->2
            LinkNode L2 = new LinkNode(8);
            L2.next = new LinkNode(2);

            LinkedList myList = new LinkedList();
            var testList = myList.AddLinkNode(L1, L2);

            while (testList!=null)
            {
                Debug.Print("{0}->",testList.value);
                testList = testList.next;
            }
            
        }

        [TestMethod]
        public void SplitLinkTest()
        {
            //3->2->1
            LinkNode L1 = new LinkNode(3);
            L1.next = new LinkNode(2);
            L1.next.next = new LinkNode(1);
            L1.next.next.next = new LinkNode(5);
            L1.next.next.next.next = new LinkNode(6);
            L1.next.next.next.next.next = new LinkNode(7);

            LinkNode first = new LinkNode();
            LinkNode second = new LinkNode();
            LinkedList.SplitLinkInMiddle(L1, ref first, ref second);
        }

    }
}
