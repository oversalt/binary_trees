using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace LinkedList
{
    public abstract class A_List<T> : A_Collection<T>, I_List<T> where T : IComparable<T>
    {
        #region Abstract Methods
        public abstract void Insert(int index, T data);
        public abstract T RemoveAt(int index);
        public abstract T ReplaceAt(int index, T data);
        #endregion

        public T ElementAt(int index)
        {
            T myT = default(T);

            int currIndex = 0;
            bool found = false;
            foreach (T item in this)
            {
                if (currIndex == index)
                {
                    myT = item;
                    found = true;
                    break;
                }
                currIndex++;
            }

            if(!found)
            {
                throw new ApplicationException("Not found");
            }

            return myT;
        }

        public int IndexOf(T data)
        {
            //-1 means not found
            int index = -1;
            int currIndex = 0;

            foreach (T item in this)
            {
                if(item.Equals(data))
                {
                    index = currIndex;
                    break;
                }
            }

            return index;
        }


    }
}
