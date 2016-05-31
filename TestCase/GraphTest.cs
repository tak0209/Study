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
        static List<GraphNode> G = new List<GraphNode>();
        static GraphNode g = new GraphNode {Value = 1};
        static GraphNode g2 = new GraphNode { Value = 2 };
        static GraphNode g3 = new GraphNode { Value = 3 };
        static GraphNode g4 = new GraphNode { Value = 4 };
        static GraphNode g5 = new GraphNode { Value = 5 };
        static GraphNode g6 = new GraphNode { Value = 6 };
           
        private static void SetupGraph()
        {
            g.Childern = new List<GraphNode> { g2, g3 };
            g2.Childern = new List<GraphNode> { g5, g4 };
            g6.Childern = new List<GraphNode> { g2 };

            G.Add(g6);
            G.Add(g2);
            G.Add(g3);
            G.Add(g4);
            G.Add(g5);
            G.Add(g);
        }


        //              1
        //       6    /   \
        //        \  2     3
        //          /  \
        //         5    4 

        [TestMethod]
        public void TestBFS()
        {          
            SetupGraph();
            var clone = Graph.CloneGraph(g);

            Graph.BFS(clone);
        }

        [TestMethod]
        public void TestDFS()
        {
            SetupGraph();
            foreach (var n in G)
            {
                Graph.recursivePostOrder(n);               
            }
            //Graph.DFS(g);
        }
    }
}
