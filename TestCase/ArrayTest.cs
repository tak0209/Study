﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                                           new string[] {"V","X", "D", "E"}};

            //ArrayObj.FindString(m, "", "CAT", 0, 0);
            bool[][] visited = { new bool[] { false, false, false, false },
                               new bool[] { false, false, false, false } ,
                               new bool[] { false, false, false, false } 
                               };
            ArrayObj.FindString(m, "", "XBOX", 0, 0, visited);
        }

        [TestMethod]
        public void TestReverseString()
        {
            char[] test = "this is    a test".ToCharArray();
            ArrayObj.ReverseSentence(test);
        }
    }
}