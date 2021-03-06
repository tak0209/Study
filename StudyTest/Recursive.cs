﻿using StudyTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTest
{
    public class Recursive
    {
        //Sample of simple recursive 
        //Adding number from n to n-1 until n=1
        public int Sum(int n)
        {
            if (n == 1)
                return 1;
            else
            {
                //Debug.Print("{0}", n);
                return n + Sum(n - 1);
            }
        }

        //Another simple recursive for n!
        public int Fact(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Fact(n - 1);
            }
        }

        //One more simple recursive: In order travesal  L-N-R
        public void InOrderTraverseTree(Node node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraverseTree(node.left);
            Debug.Print("{0}", node.value);
            InOrderTraverseTree(node.right);
        }

        //Check for Panalidrom of a string with recursive (shortner string as it found 2 end chars are matched)
        public bool IsPanalidrom(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
            {
                return true;
            }

            if (s[0] == s[s.Length - 1])
            {
                return IsPanalidrom(s.Substring(1, s.Length - 2));
            }

            return false;
        }

        //? Peacwise???
        public int Peacewise(int x)
        {
            if (x < 7)
            {
                return 10;
            }
            else
            {
                return Peacewise(x - 2) + 1;
            }
        }

        #region unused
        public void PermWithSwap(char[] s, int idx)
        {
            if (s.Length == idx)
            {
                Debug.Print("{0}", new string(s));
                return;
            }

            for (int i = idx; i < s.Length; i++)
            {
                if (i != idx)
                    swap(ref s[idx], ref s[i]);
                PermWithSwap(s, idx + 1);
                if (i != idx)
                    swap(ref s[idx], ref s[i]);
                //result += s[i];                 
                //AllPermutation(s, idx+1);
            }
        }

        private void swap(ref char p1, ref char p2)
        {
            char temp = p1;
            p1 = p2;
            p2 = temp;

        }

        public IEnumerable<string> permYield(string word)
        {
            if (word.Length > 1)
            {
                char character = word[0];
                foreach (string subPermute in permYield(word.Substring(1)))
                {
                    for (int index = 0; index <= subPermute.Length; index++)
                    {
                        string pre = subPermute.Substring(0, index);
                        string post = subPermute.Substring(index);

                        //if (post.Contains(character))
                        //    continue;

                        yield return pre + character + post;
                    }
                }
            }
            else
            {
                yield return word;
            }
        }


        //http://learnprogramming.machinesentience.com/java_permutations_recursion/
        /*The algorithm is:

        Remove the first letter
        Find all the permutations of the remaining letters (recursive step)
        Reinsert the letter that was removed in every possible location.
        The base case for the recursion is a single letter. There is only one way to permute a single letter.

        Worked example

        Imagine the start word is bar.

        First remove the b.
        Find the permuatations of ar. This gives ar and ra.
        For each of those words, put the b in every location:
        ar -> bar, abr, arb
        ra -> bra, rba, rab*/

        //public List<String> Permutation(List<string> result, string prefix, string s)
        //{
        //    int n = s.Length;
        //    if (n == 0)
        //    {
        //        result.Add(prefix);
        //    }
        //    else
        //    {
        //        for (int i = 0; i < n; i++)
        //            Permutation(result, prefix + s[i], s.Substring(0, i) + s.Substring(i + 1));
        //    }
        //    return result;
        //}
        #endregion

        // Get all combination of a phone number in chars
        // 1> pick one char from the current digit
        // 2> add char to the final string
        // 3> get the next digit from input and repeat from step 1 until all digits are processed in current run
        // 4> remove the last char from string to open slot for next choice of char
        // 5> iterate through the next char for current digit
        //*
        //  A/B         C/D         E/F
        //   _           _           _
        //
        //  A: R(0,"A")
        //      C: R(1, "AC")
        //          E: R(2, "ACE")  call and print and return  (this will end the recursive for this run, then it will process the line after the recursive)
        //          E: R(2, "ACF")  statement after recursive will remove 1 char to free up the space and new iteration will pick up the next choice of char
        //
        //      Back to C:R(1, "AC")    completed the recursive and remove 1 char to free up the next space
        //              C:R(1, "AD")
        //                  E: R(2, "ADE")
        //                  E: R(2, "ADF")
        //
        public void getAllPhone(string phonenumber, int currentDig, string s, Dictionary<char, string> map)
        {
            if (phonenumber.Length == s.Length)
            {
                Debug.Print(s);
                return;
            }

            char dig = phonenumber[currentDig];
            for (int i = 0; i < map[dig].Count(); i++)
            {
                s += map[dig][i];
                getAllPhone(phonenumber, currentDig + 1, s, map);
                s = s.Substring(0, s.Length - 1);                       //This is not efficient, we can use StringBuilder to improve?               
            }

        }

        // Better! Use char[] to build new string; Get all combination of a phone number in chars
        //this is a better solution since no need to remove substring like the other solution
        //it use re-assign new digit to output char each time to "backtrack??"
        public void getAllPhone2(int[] number, int curr_digit_idx, char[] output, Dictionary<char, string> map)
        {
            // Base case - when all the digit in one combination is done, write it out.
            if (curr_digit_idx == number.Length)
            {
                Debug.Print(new string(output));
                return;
            }

            // Try all 3 possible characters for current digir in number[]
            // and recur for remaining digits
            char dig = Char.Parse(number[curr_digit_idx].ToString());
            for (int i = 0; i < map[dig].Count(); i++)
            {
                output[curr_digit_idx] = map[dig][i];
                getAllPhone2(number, curr_digit_idx + 1, output, map);
            }
        }

        //Find LCA of 2 numbers
        public Node FindLCA(Node node, int v1, int v2)
        {
            if (node == null)
            {
                return null;
            }

            if (node.value > v1 && node.value > v2)
            {
                return FindLCA(node.left, v1, v2);
            }

            if (node.value < v1 && node.value < v2)
            {
                return FindLCA(node.right, v1, v2);
            }

            return node;
        }

        //Test BST
        public bool isBST(Node n, Node prev)
        {
            if (n == null)
                return true;

            if (!isBST(n.left, prev))
                return false;

            if (prev != null && n.value <= prev.value)
                return false;

            prev = n;
            return isBST(n.right, prev);
        }

        //*Alt solution with explaination  
        //http://www.growingwiththeweb.com/2013/06/algorithm-all-permutations-of-set.html 

        //The first parameter, called prefix increases in length as the function 
        //recurses, a character is added to the prefix, and 
        //then that becomes the new prefix for the next recursive call.  

        //The second parameter str gets smaller and smaller each time the method 
        //recurses because str.substring(0,i) nabs the string from position 0 to i, 
        //then cuts off one char, then pastes on substring (i+1) to the end. 

        //1. P("", "abc") : i=0
        //2.   P("a", "bc") : i=0
        //3.     P("ab", "c") : i=0
        //4.       P("abc","")       <-- Point of return:  Go to level 2. since input.length < i after increment to 1
        //        
        //5.   P("ac", "b"): i=1
        //6.     P("acb","") 
        public void permWithPrefix(String prefix, String input)
        {
            int n = input.Length;
            if (n <= 0)
                Debug.Print(prefix);
            else
            {
                for (int i = 0; i < n; i++)
                {
                    permWithPrefix(prefix + input[i], input.Substring(0, i) + input.Substring(i + 1));
                }
            }
        }

        //DFS for string permutation
        //http://exceptional-code.blogspot.com/2012/09/generating-all-permutations.html
        public static void permWithDFS(string input, string newStr, bool[] visited, List<string> results)
        {
            if (newStr.Length == input.Length)
            {
                results.Add(newStr);
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        permWithDFS(input, newStr + input[i].ToString(), visited, results);
                        visited[i] = false;
                    }
                }
            }
        }

        // P(ab) = [a + P(b)] U [P(b)]      => a + {b, ""} U {b, ""} => {ab, a, b, ""}
        // P(b)  = [b + P("")] U [P("")]    => {b, ""}
        // P("") = ""
        public static void FindPowerSet(String str, int currentIdx, List<String> powerSet)
        {
            if (currentIdx == str.Length)
            {
                powerSet.Add("");
                return;
            }

            char first = str[currentIdx];
            FindPowerSet(str, currentIdx + 1, powerSet);

            List<String> newCombos = new List<String>();
            foreach (String set in powerSet)
            {
                newCombos.Add(first + set);
            }

            powerSet.AddRange(newCombos);
        }

        public void GetAllLeaves(Node node)
        {
            if (node.left != null)
            {
                GetAllLeaves(node.left);
            }
            if (node.right != null)
            {
                GetAllLeaves(node.right);
            }
            if (node.left == null && node.right == null)
            {
                //OMG! leaf!
            }
        }

        public static void printLevelOrderZigZag(Node root)
        {
            Stack<Node> currentLevel = new Stack<Node>();
            Stack<Node> nextLevel = new Stack<Node>();

            currentLevel.Push(root);
            while (currentLevel.Any())
            {
                while (currentLevel.Any())
                {
                    Node n = currentLevel.Pop();
                    if (n != null)
                    {
                        Debug.Print(n.value.ToString());

                        nextLevel.Push(n.left);
                        nextLevel.Push(n.right);
                    }
                }

                while (nextLevel.Any())
                {
                    Node n = nextLevel.Pop();
                    if (n != null)
                    {
                        Debug.Print(n.value.ToString());

                        currentLevel.Push(n.right);
                        currentLevel.Push(n.left);
                    }
                }
            }
        }

        //**  Need more work on this!!
        //simplier way to find all combination of brackets
        public static void FindBracketSet(int n, List<String> powerSet)
        {
            if (n == 1)
            {
                powerSet.Add("{}");
                return;
            }

            FindBracketSet(n - 1, powerSet);

            List<String> newCombos = new List<String>();
            for (int i = 0; i < powerSet.Count; i++)
            {
                newCombos.Add("{" + powerSet[i] + "}");
                newCombos.Add("{}" + powerSet[i]);
                if ("{}" + powerSet[i] != powerSet[i] + "{}")
                    newCombos.Add(powerSet[i] + "{}");
            }

            powerSet.AddRange(newCombos);

        }

        public static void Brackets(int n)
        {
            BracketsHelper("", 0, 0, 2);
            //for (int i = 1; i <= n; i++)
            //{
            //    Brackets("", 0, 0, i);
            //    //Debug.Print("-----------------------");
            //}
        }

        //http://www.geeksforgeeks.org/print-all-combinations-of-balanced-parentheses/
        //Catalan number concept behind this https://www.youtube.com/watch?v=m9Khxn2g-6w
        private static void BracketsHelper(string output, int open, int close, int pairs)
        {
            if ((open == pairs) && (close == pairs))
            {
                Debug.Print(output);
            }
            else
            {
                if (open < pairs)
                    BracketsHelper(output + "(", open + 1, close, pairs);

                if (close < open)
                    BracketsHelper(output + ")", open, close + 1, pairs);
            }
        }

        ////http://www.careercup.com/question?id=4356911
        //public static void powerSet2(int[] elements, int n, string end,  List<string> r)
        //{
        //    if (n < 0)
        //    {
        //        Debug.Print(" " + end);
        //        return;
        //    }
        //    string newend = elements[n].ToString() + ", " + end;
        //    r.Add(newend);
        //    powerSet2(elements, n - 1, end, r);
        //    powerSet2(elements, n - 1, newend, r);
        //}

        //public static void PS3(String prefix, string input, List<string> result)
        //{
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        PS3(prefix + input[i], input.Substring(0, i) + input.Substring(i + 1), result);

        //        result.Add(prefix);
        //    }

        //}

        public static Node SortedArrayToBST(int[] a, int start, int end)
        {
            if (start > end) return null;
            int mid = start + (end - start) / 2;

            Node n = new Node(a[mid]);
            n.left = SortedArrayToBST(a, start, mid - 1);
            n.right = SortedArrayToBST(a, mid + 1, end);

            return n;
        }

        public static int compareVersion(string Version1, string Version2)
        {
            var m1 = Version1.Split('.');
            var m2 = Version2.Split('.');
            int max = Math.Min(m1.Length, m2.Length);
            for (int i = 0; i <= max; i++)
            {
                //if m1 has a digit then use it else it's consider a 0; 
                //i,e. 1.2 compare to 1.3.1 will use 1.2.0 instead of 1.2
                int v1 = (i < m1.Length ? Convert.ToInt32(m1[i]) : 0);
                int v2 = (i < m2.Length ? Convert.ToInt32(m2[i]) : 0);
                if (v1 > v2)
                {
                    return 1;
                }
                if (v1 < v2)
                {
                    return -1;
                }
            }
            return 0;
        }

        public static bool isValidP(string str)
        {
            Dictionary<char, char> map = new Dictionary<char, char>(){
                {'(', ')'},
                {'[', ']'},
                {'{', '}'}
            };

            Stack<char> s = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (map.ContainsKey(str[i]))
                {
                    s.Push(str[i]);
                }
                else
                {
                    if (s.Any() && map[s.Peek()] == str[i])
                    {
                        s.Pop();
                    }
                }
            }

            return (!s.Any());
        }

        //N-Queens
        public static bool Queen(List<position> post, int numberOfQueen, int row)
        {
            if (numberOfQueen == row)
            {
                return true;
            }

            for (int col = 0; col < numberOfQueen; col++)
            {
                if (isGoodMove(post, numberOfQueen, row, col))
                {
                    post.Add(new position(row, col));
                    if (Queen(post, numberOfQueen, row + 1))
                        return true;
                    post.RemoveAt(post.Count() - 1);
                }
            }

            return false;
        }

        // Maze!
        public static bool MazeRun2(bool[,] maze, List<position> post, int row, int col)
        {
            var n = post.Count();
            if (n > 0)
            {
                if (post[n - 1].row == maze.GetLength(0) - 1 && post[n - 1].col == maze.GetLength(1) - 1)
                {
                    return true;
                }
            }

            if (isValidMazeMove(maze, row, col))
            {
                post.Add(new position(row, col));
                if (MazeRun2(maze, post, row, col + 1))
                    return true;

                if (MazeRun2(maze, post, row + 1, col))
                    return true;

                post.RemoveAt(post.Count() - 1);

                return false;
            }
            return false;
        }

        //Word in matrix
        //Here's a recursive version 
        //http://algorithms.tutorialhorizon.com/backtracking-search-a-word-in-a-matrix/
        //algo: recursive call to all 8 direction, if false return and back track (remove the last move from the origin of first caller)
        public static bool WordPuzzle(char[,] b, string input, List<position> route)
        {
            //iterate the matrix to find the first char (the starting point (cell) of the target string)
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j] == input[0])            //find the cell of the 1st char of the string
                    {
                        route.Add(new position(i, j));  //add to the route since it's the 1st char
                        return WordPuzzleUtil(b, input, 1, i, j, route);    //find the rest of the string
                    }
                }
            }

            return false;
        }

        public static bool WordPuzzleUtil(char[,] b, string input, int charIdx, int row, int col, List<position> route)
        {
            while (input.Length > charIdx)
            {
                if (!nextMove(b, input, charIdx, ref row, ref col, route))  //Can we find the next char?
                {
                    return false;
                }

                charIdx++;  //continue to the next char
            }

            return true;
        }

        //This is a simple function to check for all directions (8 is it's current not at the edge of the matrix)
        private static bool nextMove(char[,] b, string input, int charIdx, ref int row, ref int col, List<position> route)
        {
            char targetChar = input[charIdx];
            int maxRow = b.GetLength(0);
            int maxCol = maxRow;

            //check next row; same col
            if (row + 1 <= maxRow && b[row + 1, col] == targetChar)
            {
                route.Add(new position(++row, col));
                return true;
            }

            //check upper row; same col
            if (row - 1 >= 0 && b[row - 1, col] == targetChar)
            {
                route.Add(new position(--row, col));
                return true;
            }

            //check next col; same row
            if (col + 1 <= maxCol && b[row, col + 1] == targetChar)
            {
                route.Add(new position(row, ++col));
                return true;
            }

            //check left side col; same row
            if (col - 1 >= 0 && b[row, col - 1] == targetChar)
            {
                route.Add(new position(row, --col));
                return true;
            }

            //check upper left corner
            if (row - 1 >= 0 && col - 1 >= 0 && b[row - 1, col - 1] == targetChar)
            {
                route.Add(new position(--row, --col));
                return true;
            }

            //check lower left corner
            if (row + 1 <= maxRow && col - 1 >= 0 && b[row + 1, col - 1] == targetChar)
            {
                route.Add(new position(++row, --col));
                return true;
            }

            //check upper right corner
            if (row - 1 >= 0 && col + 1 <= maxCol && b[row - 1, col + 1] == targetChar)
            {
                route.Add(new position(--row, ++col));
                return true;
            }

            //check lower right corner
            if (row + 1 <= maxRow && col + 1 <= maxCol && b[row + 1, col + 1] == targetChar)
            {
                route.Add(new position(++row, ++col));
                return true;
            }

            return false;
        }

        private static bool isValidMazeMove(bool[,] maze, int row, int col)
        {
            return maze[row, col];
        }

        private static bool isGoodMove(List<position> post, int numberOfQueen, int row, int col)
        {
            foreach (var p in post)
            {
                if (p.col == col) return false;
                if (p.row == row) return false;
                if (Math.Abs(p.col - col) == Math.Abs(p.row - row)) return false;
            }

            return true;
        }

        public static void QSort(int[] numbers, int start, int end)
        {
            if (start < end)
            {
                int pIdx = partitation(numbers, start, end);
                QSort(numbers, start, pIdx - 1);
                QSort(numbers, pIdx + 1, end);
            }

            return;
        }

        private static int partitation(int[] numbers, int start, int end)
        {
            int pivot = numbers[end];
            int pIdx = start;
            for (int i = start; i < end; i++)
            {
                if (numbers[i] <= pivot)
                {
                    //swap pIdx with element i value to get the left list (smaller of pivot on the left side)
                    swapInt2(ref numbers[pIdx], ref numbers[i]);

                    //move pIdx to next element
                    pIdx++;
                }
            }

            //move pivot to the new pviot position
            swapInt2(ref numbers[pIdx], ref numbers[end]);
            return pIdx;
        }

        public static List<Path> findShortestTrainPath(Station s, Station e)
        {
            int min = -1;
            List<Path> finalPath = null;
            foreach (Train t in s.trains)
            {
                foreach (Path p in t.paths)
                {
                    List<Path> allPaths = new List<Path>();
                    if (findPath(p.end, e, allPaths))
                    {
                        if (min == -1)
                        {
                            min = allPaths.Count;
                        }
                        else
                        {
                            if (allPaths.Count < min)
                            {
                                min = allPaths.Count;
                                finalPath = allPaths;
                            }
                        }
                    }
                }
            }

            return (finalPath);
        }

        private static bool findPath(Station s, Station e, List<Path> allPaths)
        {
            if (s.name == e.name)
                return true;

            foreach (Train t in s.trains)
            {
                foreach (Path p in t.paths)
                {
                    if (p.end == e)
                    {
                        allPaths.Add(p);
                        if (findPath(p.end, e, allPaths))
                        {
                            return true;
                        }

                        allPaths.RemoveAt(allPaths.Count() - 1);
                        return false;
                    }
                }

            }
            return false;
        }

        //Swap 2 integer variable
        private static void swapInt2(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        public class position
        {
            public int row;
            public int col;

            public position(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }
    }
}
