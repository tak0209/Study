using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTest
{
    public class Graph
    {
        public static GraphNode CloneGraph(GraphNode root)
        {
            Dictionary<int, GraphNode> map = new Dictionary<int, GraphNode>();
            Queue<GraphNode> q = new Queue<GraphNode>();

            q.Enqueue(root);
            root.Visited = true;

            GraphNode currentNode, newGraph = null;
            while (q.Any())
            {
                GraphNode n = q.Dequeue();
                if (!map.ContainsKey(n.Value))
                {
                    currentNode = new GraphNode() { Value = n.Value, Childern = new List<GraphNode>() };
                    map.Add(currentNode.Value, currentNode);

                    if (map.Count()==1)
                    {
                        newGraph = currentNode;
                    }
                }
                else
                {
                    currentNode = map[n.Value];    
                }

                if (n.Childern != null)
                {
                    foreach (GraphNode c in n.Childern)
                    {
                        if (!c.Visited)
                        {
                            GraphNode g = new GraphNode() { Value = c.Value, Childern = new List<GraphNode>() }; ;
                            map.Add(g.Value, g);

                            currentNode.Childern.Add(g);
                            q.Enqueue(c);
                            c.Visited = true;
                            //Debug.Print(c.Value.ToString());
                        }
                    }
                }
            }

            return newGraph;
        }

        public static void BFS(GraphNode root)
        {
            Queue<GraphNode> q = new Queue<GraphNode>();

            q.Enqueue(root);
            root.Visited = true;

            while (q.Any())
            {
                GraphNode n = q.Dequeue();
                Debug.Print(n.Value.ToString());                //1 2 3 5 4

                if (n.Childern != null)
                {
                    foreach (GraphNode c in n.Childern)
                    {
                        if (!c.Visited)
                        {
                            q.Enqueue(c);
                            c.Visited = true;
                        }
                    }
                }
            }
        }

        public static void DFS(GraphNode root)
        {
            Stack<GraphNode> s = new Stack<GraphNode>();
            s.Push(root);
            root.Visited = true;

            while (s.Any())
            {
                GraphNode n = s.Peek();
                if (n.Childern!=null)
                {
                    foreach(GraphNode gn in n.Childern)
                    {
                        if (!gn.Visited)
                        {
                            Debug.Print(gn.Value.ToString());  //Top to bottom; missing the root node  2 3 5 4
                            s.Push(gn);
                            gn.Visited = true;
                        }
                    }
                }

                n = s.Pop();
                //Debug.Print(n.Value.ToString());                //print bottom to top   3 4 5 2 1
            }
        }
    }
}
