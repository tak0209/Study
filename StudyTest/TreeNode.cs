using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTest
{
    public class Node
    {
        public Node(int x)
        {
            value = x;
        }

        public int value { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
    }
}
