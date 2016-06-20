using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase
{
    [TestClass]
    public class ArrayTest
    {
        [TestMethod]
        public void TestLongestPalindrome()
        {
            ArrayObj.LongestPalidrome("abbaccaxzzyzzccaxyz");
        }
        
        [TestMethod]
        public void TestFindMinInRotatedSortArray()
        {
            int[] a = new int[] { 4, 5, 1, 2, 3 };
            ArrayObj.FindMin(a, 0, a.Length - 1);
        }

        [TestMethod]
        public void TestReverseString()
        {
            char[] test = "this is    a test".ToCharArray();
            ArrayObj.ReverseSentence(test);
        }

        [TestMethod]
        public void MSSTest()
        {
            int[] a = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };
            int max = ArrayObj.MSS2(a);
        }

        [TestMethod]
        public void MaxProfitTest()
        {
            //int[] a = new int[] { 5, 10, 25, 1, 10, 30 };
            int[] a = new int[] { 5, 10, 25, 35, 45, 55 };
            //int[] a = new int[] { 2,3,10,6,4,8,1};
            //int[] a = new int[] { 7, 9, 5, 6,3, 2 };
            int max = ArrayObj.maxOneProfit(a);
            max = ArrayObj.maxOneProfit2(a);

            max = ArrayObj.maxProfit(a);
        }
    }
}
