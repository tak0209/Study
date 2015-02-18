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
            //10, 6, 7, 8, 9
            if (a[high] > a[mid])
            {
                FindMin(a, low, mid - 1);
            }
            else    //8, 9, 10, 6, 7
            {
                FindMin(a, mid + 1, high);
            }
        }


        public static void FindStringHelper(string[][] m, string search)
        {
            //ArrayObj.FindString(m, "", "CAT", 0, 0);
            bool[][] visited = { new bool[] { false, false, false, false },
                               new bool[] { false, false, false, false } ,
                               new bool[] { false, false, false, false } 
                               };

            for (int r = 0; r < m.Length; r++)
            {
                for (int c = 0; c < m[0].Length; c++)
                {
                    if (m[r][c] == search[0].ToString())
                    {
                        visited[r][c] = true;
                        var path =  "[" + r + "," + c + "]";
                        bool ret = FindString(m, ref path, search, r, c, visited);
                        visited[r][c] = false;
                    }
                }
            }
        }
        //FindString(m, "", "XBOX", 0, 0);
        public static bool FindString(string[][] m, ref string path, string search, int r, int c, bool[][] visited)
        {
            if (search.Length == 1)
                return true;

            List<matrixPt> a = findNextPath(m, r, c, search[1].ToString());
            foreach (matrixPt n in a)
            {
                if (!visited[n.r][n.c])
                {
                    path += "[" + n.r + "," + n.c + "],";
                    visited[n.r][n.c] = true;                    
                    return FindString(m, ref path, search.Substring(1), n.r, n.c, visited);
                }
            }
            
            visited[r][c]=false;
            return false;
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
            int end = s.Length - 1;
            Reverse(s, 0, end);

            //reverse each word
            int start = 0;
            int i = 0;
            while (i < end)
            {
                while (i <= end && s[i] != ' ')
                {
                    i++;
                }               //find next word
                Reverse(s, start, i - 1);
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

        public static int maxOneProfit(int[] prices)
        {
            int min = 0;
            int maxP = 0;

            min = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                maxP = Math.Max(maxP, prices[i] - min);
                min = Math.Min(min, prices[i]);
            }

            return maxP;
        }

        // greedy algorithm, if make profits, then buy
        public static int maxProfit(int[] prices)
        {
            if (prices.Length < 1) return 0;
            int max = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    max += prices[i] - prices[i - 1];
                }
            }
            return max;
        }
    }

    public class matrixPt
    {
        public int r { get; set; }
        public int c { get; set; }
    }

}


/*
boolean pattern_match(char **martix, int m, int n, char *pattern)
{
    boolean **visited = new boolean*[n];
    boolean found=false;
    int i, j;
    for(i=0; i<m; i++) {
       visited = new boolean[n];
       for(j=0; j<n; j++) visited[i][j]=false;
    }       

    for(i=0; i<m; i++) 
       for(j=0; j<n; j++) {
           if(find_pattern(matrix, i, j, m, n, pattern, visited)==true) {
              found = true; break;
           }
       }
       if(found) break;
    }
    for(i=0; i<m; i++) delete visited[i];
    delete visited;

    return found;
}

boolean find_pattern(char **matrix, int i, int j, int m, int n, char *pattern, boolean visited)
{
static int delta_i[8]={-1, -1, -1, 0, 1, 1, 1, 0};
static int delta_j[8]={1, 0, -1, -1, -1, 0, 1, 1};
    int k;
    char *p=pattern;
    if(*p == '\0') return true;
    if(i<;0 || i>=m-1 || j<;0 || j>=n-1) return false;
    if(matrix[i][j] != *p || visited[i][j]==true) return false;

    visited[i][j]=true;
    for(k=0; k<;8; k++) {
       if(find_pattern(matrix, i+delta_i[k], j+delta_j[k], m, n, p+1, visited)==true) 
         return true;    
    }
    return (visited[i][j]=false);
}

*/