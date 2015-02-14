using System;
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

        //[TestMethod]
        //public void PremWithSwapTest()
        //{
        //    Recursive myRecursive = new Recursive();
        //    myRecursive.PermWithSwap("ab".ToCharArray(), 0);
        //}

        //[TestMethod]
        //public void PremYieldTest()
        //{
        //    Recursive myRecursive = new Recursive();
        //    var test = myRecursive.permYield("abc");     
        //    foreach (string s in test)
        //    {
        //        Debug.Print(s);
        //    }
        //}

        [TestMethod]
        public void PremWithPrefixTest()
        {
            Recursive myRecursive = new Recursive();
            myRecursive.permWithPrefix("", "abc");
        }

        [TestMethod]
        public void permWithDFSTest()
        {
            bool[] v = new bool[100];
            List<string> results = new List<string>();

            Recursive.permWithDFS("abc", "", v, results);
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


        [TestMethod]
        public void LCATreeTest()
        {
            Node root = new Node(9);                    //          9
            root.left = new Node(5);                    //         / \
            root.right = new Node(10);                  //        5   10
            root.left.right = new Node(6);              //       / \
            root.left.left = new Node(4);               //      4   6
            root.left.right.right = new Node(7);        //           \
                                                        //            7

            Recursive myRecursive = new Recursive();
            var LCAnode = myRecursive.FindLCA(root, 6, 7);
            Assert.AreEqual(6, LCAnode.value);

            LCAnode = myRecursive.FindLCA(root, 5, 10);
            Assert.AreEqual(9, LCAnode.value);

            LCAnode = myRecursive.FindLCA(root, 15, 6);
            Assert.AreEqual(5, LCAnode.value);
        }

        [TestMethod]
        public void PrintLevelZapzipTest()
        {
            Node root = new Node(9);                    //          9
            root.left = new Node(5);                    //         / \
            root.right = new Node(10);                  //        5   10
            root.left.right = new Node(6);              //       / \
            root.left.left = new Node(4);               //      4   6
            Recursive.printLevelOrderZigZag(root);
        }

        [TestMethod]
        public void IsBSTTreeTest()
        {
            Node root = new Node(7);                    //          7
            root.left = new Node(5);                    //         / \
            root.right = new Node(1);                   //        5   8
            //root.left.right = new Node(6);              //         \
            //                                            //          6

            Recursive myRecursive = new Recursive();
            Assert.IsTrue(myRecursive.isBST(root, null));
        }

        [TestMethod]
        public void PS2Test()
        {
            List<string> powerSet = new List<string>();
            Recursive.FindPowerSet("123", 0, powerSet);
        }

        [TestMethod]
        public void sortedArrayToBSTTest()
        {
            int[] a = new int[] { 1, 2, 3 };
            Recursive.SortedArrayToBST(a, 0, a.Length - 1);
        }


        [TestMethod]
        public void BracketsTest()
        {
            Recursive.Brackets(2);
        }

        [TestMethod]
        public void isValidPTest()
        {
            bool ret = Recursive.isValidP("[(ABC)] + {2}");
            Assert.IsTrue(ret);
        }
        //[TestMethod]
        //public void PS3Test()
        //{
        //    List<string> powerSet = new List<string>();
        //    Recursive.PS3("", "123", powerSet);
        //}

        //[TestMethod]
        //public void PS()
        //{
        //    List<string> testResult = new List<string>();
        //    Recursive.powerSet2(new int[] { 1, 2, 3 }, 2, "", testResult);
        //}
    }
}
