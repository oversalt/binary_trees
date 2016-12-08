using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace BinarySearchTree
{
    //Define a delagete type that will point to a method that will
    //perform some action on a data membet of type T.
    public delegate void ProcessData<T>(T data);

    //An enumeration to determine the traversal order
    public enum TRAVERALORDER { PRE_ORDER, IN_ORDER, POST_ORDER };

    public interface I_BST<T>: I_Collection<T> where T: IComparable<T>
    {
        /// <summary>
        /// Given a data element, find the corresponding element of equal value
        /// and return it. 
        /// </summary>
        /// <param name="data">The item to find</param>
        /// <returns>A reference to the item found, else the default value for type T</returns>
        T Find(T data);

        /// <summary>
        /// Returns the height of the tree
        /// </summary>
        /// <returns>The height of the tree</returns>
        int Height();

        /// <summary>
        /// Similar to an enumerator, but more effecient. Also, the interate method 
        /// utilizes a delegate to perform some action on each data item
        /// </summary>
        /// <param name="pd">A delegate to a method</param>
        /// <param name="to">The order in which the tree is traversed</param>
        void Iterate(ProcessData<T> pd, TRAVERALORDER to);
    }
}
