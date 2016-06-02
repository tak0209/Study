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

                    if (map.Count() == 1)
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

        //Visited flag is needed when traverse a graph since it may have circular reference
        //vs in a tree, we can use instruction stack implicitly pushing node into stack
        //DFS should be depth first if the other of the child is in the right order
        public static void DFSwithStack(GraphNode n)
        {
            Stack<GraphNode> s = new Stack<GraphNode>();
            n.Visited = true;
            s.Push(n);

            while (s.Any())
            {
                var node = s.Pop();
                Debug.Print(node.Value.ToString());

                foreach (GraphNode child in node.Childern.ToArray().Reverse())
                {
                    if (!child.Visited)
                    {
                        //mark visited as in going to stack
                        child.Visited = true;                    //this prevent circular elements printed more than once
                        s.Push(child);
                    }
                }
            }
        }

        //Recursive with visited flag
        public static void DFSwithStack2(GraphNode n)
        {
            Debug.Print(n.Value.ToString());
            n.Visited = true;

            foreach (GraphNode child in n.Childern)
            {
                if (!child.Visited)
                {
                    DFSwithStack2(child);
                }
            }
        }

        public static void PreOrderDFS(GraphNode n)
        {
            Debug.Print(n.Value.ToString());

            foreach (var child in n.Childern)
            {
                PreOrderDFS(child);
            }
        }

        public static void PostOrderDFS(GraphNode n)
        {
            foreach (var child in n.Childern)
            {
                PostOrderDFS(child);
            }

            Debug.Print(n.Value.ToString());
        }

        //http://blogs.msdn.com/b/daveremy/archive/2010/03/16/non-recursive-post-order-depth-first-traversal.aspx
        //??? this should be same as DFS since it use the function stack to push all childer nodes
        //then pop it with recursion
        public static void recursivePostOrder(GraphNode node)
        {
            if (node.Childern != null)
            {
                foreach (var n in node.Childern)
                {
                    recursivePostOrder(n);
                }
            }
            // Do action
            if (!node.Visited)
            {
                node.Visited = true;
                Debug.Print(node.Value.ToString());
            }
        }
    }
}

public class Tree<K, V>
    where K : class, IComparable<K>
    where V : class
{
    private Node<K, V> root;

    public V DFS(K key)
    {
        Stack<Node<K, V>> stack = new Stack<Node<K, V>>();

        while (stack.Any())
        {
            var node = stack.Pop();

            if (node.key == key)
            {
                return node.value;
            }
            foreach (var child in node.children)
            {
                stack.Push(child);
            }
        }
        return default(V);
    }

    private class Node<K, V>
        where K : class, IComparable<K>
        where V : class
    {
        public K key;
        public V value;
        public Node<K, V>[] children;
    }
}