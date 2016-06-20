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
    public class GraphTest
    {
        //Tree graph
        static List<GraphNode> TG = new List<GraphNode>();
        //Graph that doesn't look a tress since there are some circular paths
        static List<GraphNode> G = new List<GraphNode>();
        static GraphNode g1 = new GraphNode { Value = 1 };
        static GraphNode g2 = new GraphNode { Value = 2 };
        static GraphNode g3 = new GraphNode { Value = 3 };
        static GraphNode g4 = new GraphNode { Value = 4 };
        static GraphNode g5 = new GraphNode { Value = 5 };
        static GraphNode g6 = new GraphNode { Value = 6 };

        private static void SetupGraph()
        {
            g1.Childern = new List<GraphNode> { g2, g3 };
            g3.Childern = new List<GraphNode> { g1 };
            g2.Childern = new List<GraphNode> { g1, g4, g5, g6, };
            g4.Childern = new List<GraphNode> { g2 };
            g5.Childern = new List<GraphNode> { g2, g6 };
            g6.Childern = new List<GraphNode> { g2, g5 };

            G.Add(g6);
            G.Add(g2);
            G.Add(g3);
            G.Add(g4);
            G.Add(g5);
            G.Add(g1);
        }

        // Graph with circular reference
        //         6   1
        //        | \ / \
        //        |  2   3
        //        | / \
        //         5   4 

        private static void SetupTree()
        {
            g1.Childern = new List<GraphNode> { g2, g3 };
            g2.Childern = new List<GraphNode> { g5, g4, g6 };

            TG.Add(g1);
            TG.Add(g2);
        }

        //Tree graph
        //            1
        //           / \
        //          2   3
        //        / | \
        //       5  4  6

        [TestMethod]
        public void TestClone()
        {
            SetupGraph();
            Debug.WriteLine("BFS\n-------------");
            Graph.BFS(g1);

            ClearAllVisitedNode();
            Debug.WriteLine("DFS\n-------------");
            Graph.DFSwithStack(g1);

            ClearAllVisitedNode();
            var clone = Graph.CloneGraph(g1);
            Debug.WriteLine("DFS clone\n-------------");
            Graph.BFS(clone);
        }

        [TestMethod]
        public void TestDFSandBFS()
        {
            SetupTree();
            Debug.WriteLine("BFS\n-------------");
            Graph.BFS(g1);

            ClearAllVisitedNode();
            Debug.WriteLine("Pre order DFS\n-------------");
            Graph.PreOrderDFS(g1);

            ClearAllVisitedNode();
            Debug.WriteLine("Post order DFS\n-------------");
            Graph.PostOrderDFS(g1);

            ClearAllVisitedNode();
            Debug.WriteLine("DFS with stack\n-------------");
            Graph.DFSwithStack(g1);
        }

        //Simply clear all node to not visited
        private void ClearAllVisitedNode()
        {
            g1.Visited = false;
            g2.Visited = false;
            g3.Visited = false;
            g4.Visited = false;
            g5.Visited = false;
            g6.Visited = false;
        }

        [TestMethod]
        public void TestWordLadder()
        {
            var steps = Graph.WordLadder("hit", "cog", new HashSet<string>() { "hot", "dot", "dog", "lot", "log", "cog" });
        }

    }
}
