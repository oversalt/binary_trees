using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresCommon
{
    public abstract class A_Collection<T> : I_Collection<T> where T : IComparable<T>
    {
        #region Abstract Methods
        public abstract void Add(T data);
        public abstract void Clear();
        public abstract bool Remove(T data);
        #endregion

        //Recall that Count is a property, a C# construct similar to a getter/setter.
        //Note that the following implementation of count is probably not efficient.
        //Therefore, we want the ability to override this property in a child implementation
        //The keyword "virtual" allows this to occur. 
        public virtual int Count
        {
            get
            {
                int count = 0;

                //The foreach statment works for collections taht implement IEnumerable
                foreach (T item in this)
                {
                    count++;
                }

                return count;
            }
        }

        public bool Contains(T data)
        {
            bool found = false;

            //Get an instacnec of an enumerator
            IEnumerator<T> myEnum = GetEnumerator();
            //Begin enumeration at the start of the enumerator
            myEnum.Reset();

            //Loop through the data until the requested item is found
            //or we reach the end of the structure
            while(myEnum.MoveNext() && !found)
            {
                //Compare the data to the current value of the enumerator
                found = myEnum.Current.Equals(data);
            }

            return found;
        }

        #region IEnumerable Implementation
        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        //Override the implementation of ToString.  Typically this method would not be
        //part of a data structure, at least not this implementation where all data items
        //are appended to the the string.  Could get really long...
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("[");
            string sep = ", ";
            foreach (T item in this)
            {
                result.Append(item + sep);
            }
            if (Count > 0)
            {
                result.Remove(result.Length - sep.Length, sep.Length);
            }
            result.Append("]");
            return result.ToString();
        }
    }
}
