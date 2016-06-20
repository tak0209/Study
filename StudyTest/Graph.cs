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
        public static int WordLadder(string beginWord, string endWord, HashSet<string> dict)
        {
            List<string> path = new List<string>();
            int step = 0;
            bool done = false;

            string currentWord = beginWord;
            path.Add(currentWord);
            while (!done)
            {
        
                if (currentWord == endWord)
                {
                    return step++;
                }

                char[] arr = currentWord.ToCharArray();
                for (int i = 0; i < arr.Length; i++)    //swap out one char a time and check with dictionary
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        char temp = arr[i];
                        if (arr[i] != c)
                        {
                            arr[i] = c;
                        }

                        String newWord = new String(arr);
                        if (dict.Contains(newWord))
                        {
                            currentWord = newWord;
                            path.Add(currentWord);
                            step++;
                            dict.Remove(newWord);
                            i = 0;
                            break;
                        }

                        arr[i] = temp;
                    }
                }
            }

            return 0;
        }
        public static int WordLadderOld(string beginWord, string endWord, HashSet<string> dict)
        {
            Queue<WordNode> queue = new Queue<WordNode>();
            queue.Enqueue(new WordNode(beginWord, 1));

            while (queue.Any())
            {
                WordNode top = queue.Dequeue();
                String word = top.word;

                if (word ==endWord)
                {
                    return top.numSteps;
                }

                char[] arr = word.ToCharArray();
                for (int i = 0; i < arr.Length; i++)    //swap out one char a time and check with dictionary
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        char temp = arr[i];
                        if (arr[i] != c)
                        {
                            arr[i] = c;
                        }

                        String newWord = new String(arr);
                        if (dict.Contains(newWord))
                        {
                            queue.Enqueue(new WordNode(newWord, top.numSteps + 1));
                            dict.Remove(newWord);
                        }

                        arr[i] = temp;
                    }
                }
            }

            return 0;
        }

        private static bool isValid(GraphNode p, string target)
        {
            foreach (var c in p.SValue)
            {
                foreach(var tc in target)
                {
                    if (c == tc)
                        return true;
                }
            }
            return false;
        }

        public static GraphNode CloneGraph(GraphNode root)
        {
            Queue<GraphNode> q = new Queue<GraphNode>();

            q.Enqueue(root);
            root.Visited = true;

            GraphNode currentNode, newGraph = null;
            while (q.Any())
            {
                GraphNode n = q.Dequeue();
                currentNode = new GraphNode() { Value = n.Value, Childern = new List<GraphNode>() };

                if (newGraph == null)
                {
                    newGraph = currentNode;
                }
                else
                {
                    newGraph.Childern.Add(currentNode);
                }

                foreach (GraphNode c in n.Childern)
                {
                    if (!c.Visited)
                    {
                        currentNode.Childern.Add(c);
                        q.Enqueue(c);
                        c.Visited = true;
                        //Debug.Print(c.Value.ToString());
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

                //Adding the reverse order to show it's actually doing depth first else it looks like BFS
                //http://stackoverflow.com/questions/9201166/iterative-dfs-vs-recursive-dfs-and-different-elements-order
                foreach (GraphNode child in node.Childern.ToArray().Reverse())
                {
                    if (!child.Visited)
                    {
                        //mark visited as in going to stack
                        //this prevent circular elements printed more than once
                        child.Visited = true;
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

        //This DFS will use the instructional stack and it's only use with tree (grapth can contain circular path)
        public static void PreOrderDFS(GraphNode n)
        {
            Debug.Print(n.Value.ToString());

            foreach (var child in n.Childern)
            {
                PreOrderDFS(child);
            }
        }

        //This DFS will use the instructional stack and it's only use with tree (grapth can contain circular path)
        public static void PostOrderDFS(GraphNode n)
        {
            foreach (var child in n.Childern)
            {
                PostOrderDFS(child);
            }

            Debug.Print(n.Value.ToString());
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