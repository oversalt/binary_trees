using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace BinarySearchTree
{
    class Program
    {
        static void TestBSTAdd(BST<int> myBST)
        {
            myBST.Add(9);
            myBST.Add(4);
            myBST.Add(3);
            myBST.Add(6);
            myBST.Add(5);
            myBST.Add(7);
            myBST.Add(17);
            myBST.Add(22);
            myBST.Add(20);
        }

        static void DisplayInt(int x)
        {
            Console.Write(x + ", ");
        }

        static void TestIterate(BST<int> myBST)
        {
            myBST.Iterate(DisplayInt, TRAVERALORDER.POST_ORDER);
        }

        static void TestHeight(BST<int> myBST)
        {
            myBST.Add(10);
            myBST.Add(20);
            myBST.Add(5);
            myBST.Add(7);
            myBST.Add(1);
            myBST.Add(0);
            myBST.Add(25);
            myBST.Add(11);
            Console.WriteLine(myBST.Height());
        }

        static void TestSmallest(BST<int> myBST)
        {
            Console.WriteLine("Smallest: " + myBST.FindSmallest());

            BST<int> x = new BST<int>();
            x.Add(2);
            x.Add(8);
            x.Add(4);
            x.Add(1);
            x.Add(9);
            x.Add(10);
            x.Add(3);
            Console.WriteLine("Smallest: " + x.FindSmallest());
        }

        static void TestLargest(BST<int> myBST)
        {
            Console.WriteLine("Largest: " + myBST.FindLargest());
        }

        static void TestRemove(BST<int> myBST)
        {
            myBST.Iterate(DisplayInt, TRAVERALORDER.IN_ORDER);
            Console.WriteLine();
            myBST.Remove(20);

            myBST.Iterate(DisplayInt, TRAVERALORDER.IN_ORDER);
        }

        static void TestEnumeratorDepthFirst(BST<int> myBST)
        {
            Console.WriteLine(myBST.ToString());
        }

        static void TestIterateBreadth(BST<int> myBST)
        {
            myBST.IterateBreadth(DisplayInt);
        }

        static void TestPathString(BST<int> myBST)
        {
            Console.WriteLine(myBST.PathString(20));
        }

        static void TestClone()
        {
            BST<int> tree = new BST<int>();

            tree.Add(10);
            tree.Add(11);
            tree.Add(12);
            tree.Add(7);
            tree.Add(5);
            tree.Add(1);
            tree.Add(60);
            tree.Add(97);
            tree.Add(6);

            Console.WriteLine(tree.ToString());

            BST<int> cloneTree = (BST<int>) tree.Clone();
            Console.WriteLine(cloneTree.ToString());
        }

        static void TestClear()
        {
            BST<int> tree = new BST<int>();

            tree.Add(10);
            tree.Add(11);
            tree.Add(12);
            tree.Add(7);
            tree.Add(5);
            tree.Add(1);
            tree.Add(60);
            tree.Add(97);
            tree.Add(6);

            Console.WriteLine(tree.ToString());

            tree.Clear();
            Console.WriteLine(tree.ToString());
        }

        static void TestRandomAdd()
        {
            long start = 0;
            long end = 0;
            //How many random numbers do you want
            int iMax = 100000;
            //Largest number generated
            int iLargest = iMax * 10;
            //Create a tree
            //BST<int> tree = new BST<int>();
            AVLT<int> tree = new AVLT<int>();
            //Get the current time
            start = Environment.TickCount;
            //Create a random number generator using the start time as a seed.
            Random randomNumber = new Random((int)start);

            //Generate numbers and add to the tree
            for (int i = 0; i < iMax; i++)
            {
                tree.Add(randomNumber.Next(1, iLargest));
            }

            //Get the current time
            end = Environment.TickCount;

            Console.WriteLine("Time to add: " + (end - start).ToString() + "ms");
            Console.WriteLine("Theoretical Maximum Height: " + Math.Truncate(Math.Log(iMax, 2)));
            Console.WriteLine("Actual Height: " + tree.Height());
            //tree.Iterate(DisplayInt, TRAVERALORDER.IN_ORDER); 
        }

        static void TestBalance(AVLT<int> tree)
        {
            tree.Add(30);
            tree.Add(20);
            tree.Add(10);
            Console.WriteLine(tree.ToString());
        }

        static void Main(string[] args)
        {
            //BST<int> myBST = new BST<int>();
            //TestBSTAdd(myBST);
            //Console.WriteLine(myBST.Count);
            //TestIterate(myBST);
            //BST<int> myBST = new BST<int>();
            //TestHeight(myBST);
            //TestSmallest(myBST);
            //TestLargest(myBST);
            //TestRemove(myBST);
            //TestEnumeratorDepthFirst(myBST);
            //TestIterateBreadth(myBST);
            //TestPathString(myBST);
            //TestRandomAdd();
            //AVLT<int> tree = new AVLT<int>();

            //TestBalance(tree);

            //TestClone();
            TestClear();
        }
    }
}
