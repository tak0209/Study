using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTest
{
    public class ArrayObj
    {
        //this will find the minimum which is the point of where rotation begin
        public static void FindMin(int[] a, int low, int high)
        {
            //no rotation
            if (a[high] > a[low])
            {
                Debug.Print("min {0} @ {1}", a[0].ToString(), 0);
                return;
            }

            //1 element
            if (low == high)
            {
                Debug.Print("min {0} @ {1}", a[low].ToString(), low);
                return;
            }

            int mid = low + (high - low) / 2;

            // 3 4 5 1 2  (is the element after min is the rotation(minimum)  i > i + 1)
            if (a[mid] > a[mid + 1])
            {
                Debug.Print("min {0} @ {1}", a[mid + 1].ToString(), mid + 1);
                return;
            }

            // is mid a min?
            if (a[mid] < a[mid - 1])
            {
                Debug.Print("* min {0} @ {1}", a[mid].ToString(), mid);
                return;
            }

            //Go to left side of the array if the last element is greater than mid element
            if (a[high] > a[mid])
            {
                FindMin(a, low, mid - 1);
            }
            else
            {
                FindMin(a, mid + 1, high);
            }
        }

        //FindString(m, "", "XBOX", 0, 0);
        public static void FindString(string[][] m, string path, string search, int r, int c)
        {
            if (m[r][c] == search[0].ToString())
            {
                path += "[" + r + "," + c + "],";
                if (search.Length == 1)
                {
                    Debug.Print("Find it!: {0}", path);
                    return;
                }

                List<matrixPt> a = findNextPath(m, r, c, search[1].ToString());
                foreach (matrixPt n in a)
                {
                    path += "[" + n.r + "," + n.c + "],";
                    FindString(m, path, search.Substring(1), n.r, n.c);
                }
            }

            if (r < m.Count() - 1)        //more row?
            {
                if (c + 1 <= m[0].Count() - 1)
                {
                    c++;
                }
                else
                {
                    r++;
                    c = 0;
                }

                path = "";
            }
            else
            {
                Debug.Print("No find");
                return;
            }
            FindString(m, path, search, r, c);
        }

        private static List<matrixPt> findNextPath(string[][] m, int r, int c, string nextChar)
        {
            List<matrixPt> ret = new List<matrixPt>();
            int row = m.Count() - 1;
            int col = m[0].Count() - 1;

            if (c + 1 <= col)
            {
                if (m[r][c + 1] == nextChar)
                {
                    ret.Add(new matrixPt { c = c + 1, r = r });
                }
            }

            if (c - 1 >= 0)
            {
                if (m[r][c - 1] == nextChar)
                {
                    ret.Add(new matrixPt { c = c - 1, r = r });
                }
            }

            if (r + 1 <= row)
            {
                if (m[r + 1][c] == nextChar)
                {
                    ret.Add(new matrixPt { c = c, r = r + 1 });
                }
            }

            if (r - 1 >= 0)
            {
                if (m[r - 1][c] == nextChar)
                {
                    ret.Add(new matrixPt { c = c, r = r - 1 });
                }
            }

            if (r + 1 <= row && c + 1 <= col)
            {
                if (m[r + 1][c + 1] == nextChar)
                {
                    ret.Add(new matrixPt { c = c + 1, r = r + 1 });
                }
            }

            if (r - 1 >= 0 && c + 1 <= col)
            {
                if (m[r - 1][c + 1] == nextChar)
                {
                    ret.Add(new matrixPt { c = c + 1, r = r - 1 });
                }
            }

            if (r - 1 >= 0 && c - 1 >= col)
            {
                if (m[r - 1][c - 1] == nextChar)
                {
                    ret.Add(new matrixPt { c = c - 1, r = r - 1 });
                }
            }

            if (r + 1 <= row && c - 1 >= 0)
            {
                if (m[r + 1][c - 1] == nextChar)
                {
                    ret.Add(new matrixPt { c = c - 1, r = r + 1 });
                }
            }

            return ret;
        }

        public static void ReverseSentence(char[] s)
        {
            int end = s.Length-1;
            Reverse(s, 0, end);

            //reverse each word
            int start = 0;
            int i = 0;
            while (i<end)
            {
                while (i<=end && s[i]!= ' ') 
                { 
                    i++;                     
                }               //find next word
                Reverse(s, start, i-1);
                start = ++i;
            }

        }

        private static void Reverse(char[] str, int s, int e)
        {
            for (int i = s; i < e; i++)
            {
                var temp = str[i];
                str[i] = str[e];
                str[e] = temp;
                e--;
            }
        }
    }

    public class matrixPt
    {
        public int r { get; set; }
        public int c { get; set; }
    }
}
