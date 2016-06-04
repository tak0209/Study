using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTest
{
    public class LinkNode
    {
        public LinkNode()
        { }

        public LinkNode(int v)
        {
            value = v;
        }

        public LinkNode next { get; set; }
        public int value { get; set; }
    }
}
