﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyTest;
using System.Diagnostics;
using System.Collections.Generic;

namespace TestCase
{
    [TestClass]
    public class RecursiveTest
    {
        [TestMethod]
        public void SumTest()
        {
            Recursive myRecursive = new Recursive();
            var result = myRecursive.Sum(5);
            Debug.Print("{0}", result);
            Assert.AreEqual(5 + 4 + 3 + 2 + 1, result);
        }
        
        [TestMethod]
        public void FactTest()
        {
            Recursive myRecursive = new Recursive();
            var result = myRecursive.Fact(5);
            Assert.AreEqual(5 * 4 * 3 * 2 * 1, result);
        }

        [TestMethod]
        public void InOrderTreeTest()
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);

            Recursive myRecursive = new Recursive();
            myRecursive.InOrderTraverseTree(root);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ParalindromeTest()
        {
            Recursive myRecursive = new Recursive();
            Assert.IsTrue(myRecursive.IsPanalidrom("amanaplanacanalpanama"));
        }

        [TestMethod]
        public void PeacewiseTest()
        {
            Recursive myRecursive = new Recursive();
            var result = myRecursive.Peacewise(12);
            Debug.Print(result.ToString());
            Assert.AreEqual(13, result);
        }

        [TestMethod]
        public void AllPremTest()
        {
            Recursive myRecursive = new Recursive();
            myRecursive.AllPermutation("ab".ToCharArray(), 0);
        }

        [TestMethod]
        public void PremTest()
        {
            Recursive myRecursive = new Recursive();
            var test = myRecursive.permute("abc");     
            foreach (string s in test)
            {
                Debug.Print(s);
            }
        }


        [TestMethod]
        public void PremTest2()
        {
            Recursive myRecursive = new Recursive();
            List<string> result = new List<string>();
            var test = myRecursive.Permutation(result, "", "abc");
            foreach (string s in test)
            {
                Debug.Print(s);
            }
        }

        [TestMethod]
        public void Prem2Test()
        {
            Recursive myRecursive = new Recursive();
            myRecursive.permuteString("", "abc");
        }

        [TestMethod]
        public void PhoneTest()
        {
            Dictionary<char, string> map = new Dictionary<char, string>()
            {
                {'1', ""}, 
                {'2',"ABC"}, {'3', "DEF"}, {'4', "GHI"}, {'5', "JKL"},
                {'6',"MNO"}, {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"}
            };

            Recursive myRecursive = new Recursive();
            myRecursive.getAllPhone("234", 0, "", map);
        }
    }
}
