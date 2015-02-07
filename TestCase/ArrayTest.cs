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
    }
}
