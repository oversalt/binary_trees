using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresCommon
{
    //This interface uses generics. The generic type T must be IComparable.
    public interface I_Collection<T>: IEnumerable<T> where T:IComparable<T>
    {
        /// <summary>
        /// Adds the given data to the collection.
        /// </summary>
        /// <param name="data">Item to add</param>
        void Add(T data);

        /// <summary>
        /// Removes all items from the collection
        /// </summary>
        void Clear();

        /// <summary>
        /// Removes the first instance of a value if it exists.
        /// </summary>
        /// <param name="data">Item to remove</param>
        /// <returns>True if removed, else false</returns>
        bool Remove(T data);

        /// <summary>
        /// A C# Property used to access the number of elements in the colletion.
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Determines if this data structure is equal to another one.
        /// </summary>
        /// <param name="other">The passed in data structure to compare to the calling one</param>
        /// <returns>True if equals, else false</returns>
        bool Equals(object other);

        /// <summary>
        /// Determines if the data item is in the structure or not
        /// </summary>
        /// <param name="data">Data item to find</param>
        /// <returns>True if found, else false.</returns>
        bool Contains(T data);
    }
}
