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
        public static void BFS(GraphNode root)
        {
            Queue<GraphNode> q = new Queue<GraphNode>();
            root.Visited = true;
            q.Enqueue(root);

            while (q.Any())
            {
                GraphNode n = q.Dequeue();
                Debug.Print(n.Value.ToString());

                if (n.Childern!=null)
                {
                    foreach(GraphNode cn in n.Childern)
                    {
                        if (!cn.Visited)
                        {
                            cn.Visited = true;
                            q.Enqueue(cn);
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

            while(s.Any())
            {
                GraphNode n = s.Peek();

                if (n.Childern!=null)
                {
                    foreach (GraphNode cn in n.Childern)
                    {
                        if (!cn.Visited)
                        {
                            s.Push(cn);
                            cn.Visited = true;
                        }
                    }
                }

                GraphNode current = s.Pop();
                Debug.Print(current.Value.ToString());
            }
        }
    }
}
