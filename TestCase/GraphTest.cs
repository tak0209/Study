using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase
{
    [TestClass]
    public class GraphTest
    {
        private static GraphNode SetupGraph()
        {
            GraphNode g = new GraphNode();
            g.Value = 1;
            g.Childern = new GraphNode[] { new GraphNode { Value = 2 }, new GraphNode { Value = 3 } };
            g.Childern[0].Childern = new GraphNode[] { new GraphNode { Value = 5 }, new GraphNode { Value = 4 } };
            g.Childern[0].Childern[1].Childern = new GraphNode[] { g.Childern[0].Childern[0] };
            return g;
        }

        [TestMethod]
        public void TestBFS()
        {
            //              1
            //            /   \
            //           2     3
            //          /  \
            //         5 -  4 

            GraphNode g = SetupGraph();
            //Graph.BFS(g);
        }

        [TestMethod]
        public void TestDFS()
        {
            GraphNode g = SetupGraph();
            //Graph.DFS(g);
        }
    }
}
