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
        //Not finish solution... should use BFS?
        public void TestPath()
        {                                                                 //                       b
            Station a = new Station('a');                                 //                       ^
            Station b = new Station('b');                                 //                   t1/    \t1
            Station c = new Station('c');                                 //                    /      \
                                                                          //                  a -------- c
                                                                          //                        t2
            Path p1 = new Path('1', b, a);
            Path p2 = new Path('1', a, c);
            Path p3 = new Path('2', b, c);

            Train t1 = new Train() { name = '1', paths = new List<Path>() { p1, p2 } };
            Train t2 = new Train() { name = '2', paths = new List<Path>() { p3 } };

            a.trains.Add(t1);
            a.trains.Add(t2);
            b.trains.Add(t2);

            List<Path> allPath = new List<Path>();

            var paths = Recursive.findShortestTrainPath(a, c);

            foreach(var p in paths)
            {
                Debug.Print(string.Format("%c - from: %c  to: %c", p.trainName, p.start.name, p.end.name));
            }
        }

        [TestMethod]
        public void QSortTest()
        {
            int[] n = { 7, 2, 1, 6, 8, 5, 3, 4 };
            Recursive.QSort(n, 0, n.Length - 1);
        }

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

            Recursive.permWithDFS("ab", "", v, results);
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
        public void PhoneTest2()
        {
            Dictionary<char, string> map = new Dictionary<char, string>()
            {
                {'1', " "},
                {'2',"ABC"}, {'3', "DEF"}, {'4', "GHI"}, {'5', "JKL"},
                {'6',"MNO"}, {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"}
            };

            Recursive myRecursive = new Recursive();
            int[] phonenumber = { 2, 3, 4 };
            char[] output = new char[phonenumber.Length];
            myRecursive.getAllPhone2(phonenumber, 0, output, map);
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

            LCAnode = myRecursive.FindLCA(root, 5, 6);
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
            root.right = new Node(8);                   //        5   8
            //root.left.right = new Node(6);              //         \
            //                                            //          6

            Recursive myRecursive = new Recursive();
            Assert.IsTrue(myRecursive.isBST(root, null));
        }

        [TestMethod]
        public void PS2Test()
        {
            List<string> powerSet = new List<string>();
            Recursive.FindPowerSet("AB", 0, powerSet);
        }

        //Find combination of brackets using power set algo
        [TestMethod]
        public void FindBrackets()
        {
            List<string> powerSet = new List<string>();
            Recursive.FindBracketSet(4, powerSet);

            foreach (var s in powerSet)
            {
                Debug.Print(s);
            }

            //Assert.AreEqual(powerSet.Count, 9);
        }

        //Find combination of brackets using open and close tracking 
        [TestMethod]
        public void BracketsTest()
        {
            Recursive.Brackets(3);
        }

        [TestMethod]
        public void sortedArrayToBSTTest()
        {
            int[] a = new int[] { 1, 2, 3 };
            Recursive.SortedArrayToBST(a, 0, a.Length - 1);
        }

        [TestMethod]
        public void isValidPTest()
        {
            bool ret = Recursive.isValidP("[(ABC)] + {2}");
            Assert.IsTrue(ret);
        }

        [TestMethod]
        public void checkVersion()
        {
            var ret = Recursive.compareVersion("1.2", "1.2.1");
        }

        [TestMethod]
        public void NQueenTest()
        {
            int numberOfQueen = 4;
            List<StudyTest.Recursive.position> post = new List<StudyTest.Recursive.position>();

            if (Recursive.Queen(post, numberOfQueen, 0))
            {
                for (int i = 0; i < numberOfQueen; i++)
                {
                    for (int j = 0; j < numberOfQueen; j++)
                    {
                        bool matched = false;
                        foreach (var p in post)
                        {
                            if (p.row == i && p.col == j)
                            {
                                Console.Write(" Q ");
                                matched = true;
                            }
                        }
                        if (!matched)
                            Console.Write(" * ");
                    }
                    Console.WriteLine("");
                }
            }
        }

        [TestMethod]
        public void MazeTest()
        {
            List<StudyTest.Recursive.position> post = new List<StudyTest.Recursive.position>();
            bool[,] maze = {
                { true, false, false, false },
                { true, true, false, true },
                { true, true, false, false },
                { true, true, true, true } };

            if (Recursive.MazeRun2(maze, post, 0, 0))
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        bool matched = false;
                        foreach (var p in post)
                        {
                            if (p.row == i && p.col == j)
                            {
                                Console.Write(" R ");
                                matched = true;
                            }
                        }
                        if (!matched)
                        {
                            if (maze[i, j])
                                Console.Write(" 1 ");
                            else
                                Console.Write(" 0 ");
                        }
                    }
                    Console.WriteLine("");
                }
            }
        }

        [TestMethod]
        public void FindWordPath()
        {
            List<StudyTest.Recursive.position> post = new List<StudyTest.Recursive.position>();
            char[,] puzzle = {
                { 'A', 'B', 'C', 'X' },
                { 'D', 'E', 'F', 'Y'},
                { 'G', 'H', 'I', 'W' },
                { 'J', 'K', 'L', 'Z' }
                };

            Recursive.WordPuzzle(puzzle, "AEHIL", post);
        }
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
