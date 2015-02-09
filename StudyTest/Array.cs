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
            if (a[high]>a[low])
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
                Debug.Print("min {0} @ {1}", a[mid + 1].ToString(), mid+1);
                return;
            }

            // is mid a min?
            if (a[mid] < a[mid-1])
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
    }
}
