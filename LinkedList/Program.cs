using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> myList = new LinkedList<int>();
            #region Test Add
            myList.Add(10);
            myList.Add(2);
            myList.Add(7);
            myList.Add(3);
            myList.Add(5);
            Console.WriteLine(myList.ToString());
            #endregion

            #region Test Remove
            /*
            Console.WriteLine(myList.Remove(7));
            Console.WriteLine(myList.ToString());
            Console.WriteLine(myList.Remove(10));
            Console.WriteLine(myList.ToString());
            Console.WriteLine(myList.Remove(5));
            Console.WriteLine(myList.ToString());
            Console.WriteLine(myList.Remove(55));
            */
            #endregion

            #region Test RemoveAt
            Console.WriteLine(myList.RemoveAt(4));
            Console.WriteLine(myList.ToString());
            //Below works, commenting out to make rest of code work
            //Console.WriteLine(myList.RemoveAt(5555));
            //Console.WriteLine(myList.ToString());
            #endregion

            #region Test ReplaceAt
            /*
            Console.WriteLine(myList.ReplaceAt(1, 12));
            Console.WriteLine(myList.ToString());
            Console.WriteLine(myList.ReplaceAt(0, 12));
            Console.WriteLine(myList.ToString());
            //Below works
            //Console.WriteLine(myList.ReplaceAt(70, 12));
            //Console.WriteLine(myList.ToString());
            */
            #endregion

            #region Test ElementAt
            Console.WriteLine("\nElementAt test");
            Console.WriteLine(myList.ElementAt(0));
            Console.WriteLine(myList.ElementAt(1));
            Console.WriteLine(myList.ElementAt(2));
            Console.WriteLine(myList.ElementAt(3));
            try
            {
                Console.WriteLine(myList.ElementAt(4));
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region Test IndexOf
            Console.WriteLine("\nIndexOf test");
            Console.WriteLine(myList.IndexOf(10));
            Console.WriteLine(myList.IndexOf(2));
            Console.WriteLine(myList.IndexOf(7));
            Console.WriteLine(myList.IndexOf(3));
            Console.WriteLine(myList.IndexOf(5555));
            #endregion

        }
    }
}
