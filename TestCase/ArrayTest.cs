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
        public void TestFindMinInRotatedSortArray()
        {
            int[] a = new int[] { 4, 5, 1, 2, 3 };
            ArrayObj.FindMin(a, 0, a.Length - 1);
        }

        
        [TestMethod]
        public void TestFindString()
        {
            string[][] m = new string[][] {new string[] {"C","B", "E", "C"}, 
                                           new string[] {"O", "X", "T", "A"}, 
                                           new string[] {"V","Y", "D", "E"}};


            ArrayObj.FindStringHelper(m, "XBOX");
        }

        [TestMethod]
        public void TestReverseString()
        {
            char[] test = "this is    a test".ToCharArray();
            ArrayObj.ReverseSentence(test);
        }

        [TestMethod]
        public void MaxProfitTest()
        {
            int[] a = new int[] { 5, 10, 25, 1, 10, 30 };
            //int[] a = new int[] { 5, 10, 25, 35, 45, 55 };
            //int[] a = new int[] { 2,3,10,6,4,8,1};
            //int[] a = new int[] { 7, 9, 5, 6,3, 2 };
            ArrayObj.maxOneProfit(a);

            ArrayObj.maxProfit(a);
        }
    }
}
