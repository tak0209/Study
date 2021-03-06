﻿using System;
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

            // 3 4 5 1 2  (is the element after mid is the rotation(minimum)  i > i + 1)
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

        //DP for MSS
        public static int MSS2(int[] a)
        {
            int max = a[0];
            int currentMax = a[0];

            for (int i = 0; i < a.Length; i++)
            {
                currentMax = Math.Max(a[i], currentMax + a[i]);
                max = Math.Max(currentMax, max);
            }
            return max;
        }

        public static int MSS(int[] a)
        {
            int max = 0;
            int sum = 0;

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (sum + a[i] > 0)
                {
                    sum += a[i];
                }
                else
                {
                    sum = 0;
                }

                max = Math.Max(max, sum);
            }
            return max;
        }

        //DP?
        public static int maxOneProfit2(int[] a)
        {
            int minPrice = a[0];
            int profit = 0;

            for (int i = 1; i < a.Length; i++)
            {
                profit = Math.Max(profit, a[i] - minPrice);
                minPrice = Math.Min(minPrice, a[i]);
            }

            return profit;
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

        public static string LongestPalidrome(string s)
        {
            int n = s.Length;
            if (n == 0) return "";
            string longest = s.Substring(0, 1);  // a single char itself is a palindrome
            for (int i = 0; i < n - 1; i++)
            {
                string p1 = expandAroundCenter(s, i, i);
                if (p1.Length > longest.Length)
                    longest = p1;

                string p2 = expandAroundCenter(s, i, i + 1);
                if (p2.Length > longest.Length)
                    longest = p2;
            }
            return longest;
        }

        public static string expandAroundCenter(string s, int c1, int c2)
        {
            int l = c1, r = c2;
            int n = s.Length;
            while (l >= 0 && r <= n - 1 && s[l] == s[r])
            {
                l--;
                r++;
            }
            return s.Substring(l + 1, r - l - 1);
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
