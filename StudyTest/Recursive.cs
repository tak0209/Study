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

        public void AllPermutation(char[] s, int idx)
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
                AllPermutation(s, idx + 1);
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

        public IEnumerable<string> permute(string word)
        {
            if (word.Length > 1)
            {
                char character = word[0];
                foreach (string subPermute in permute(word.Substring(1)))
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

        public List<String> Permutation(List<string> result, string prefix, string s)
        {
            int n = s.Length;
            if (n == 0)
            {
                result.Add(prefix);
            }
            else
            {
                for (int i = 0; i < n; i++)
                    Permutation(result, prefix + s[i], s.Substring(0, i) + s.Substring(i + 1));
            }
            return result;
        }

        //The first parameter, called prefix increases in length as the function 
        //recurses, a character is added to the prefix, and 
        //then that becomes the new prefix for the next recursive call.  


        //The second parameter str gets smaller and smaller each time the method 
        //recurses because str.substring(0,i) nabs the string from position 0 to i, 
        //then cuts off one char, then pastes on substring (i+1) to the end. 

        public void permuteString(String prefix, String input)
        {
            if (input.Length <= 1)
                Debug.Print(prefix + input);
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    input = input.Substring(0, i) + input.Substring(i + 1);
                    permuteString(prefix + input[i], input);
                }
            }
        }


        //*Alt solution with explaination  
        //http://www.growingwiththeweb.com/2013/06/algorithm-all-permutations-of-set.html 


        //*
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
        //*
        public void getAllPhone(string phonenumber, int currentDig, string s, Dictionary<char, string> map)
        {
            if (phonenumber.Length == s.Length)
            {
                Debug.Print(s);
                return;
            }

            char dig = phonenumber[currentDig];
            for (int i=0; i< map[dig].Count(); i ++)
            {
                s += map[dig][i];
                getAllPhone(phonenumber, currentDig + 1, s, map);
                s = s.Substring(0, s.Length - 1);                       //This is not efficient, we can use StringBuilder to improve?               
            }

        }

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

        private static Node prev = null;

        public  bool isBST(Node root)
        {        
            if (root == null)
                return true;

            if (!isBST(root.left))
                return false;

            if (prev != null && root.value <= prev.value)
                return false;

            prev = root;
            return isBST(root.right);
        }
    }
}
