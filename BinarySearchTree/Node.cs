using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node<T> where T:IComparable<T>
    {
        #region Attributes
        private T tData;
        private Node<T> nLeft;
        private Node<T> nRight;
        #endregion

        #region Properties
        public T Data
        {
            get
            {
                return tData;
            }

            set
            {
                tData = value;
            }
        }

        public Node<T> Left
        {
            get
            {
                return nLeft;
            }

            set
            {
                nLeft = value;
            }
        }

        public Node<T> Right
        {
            get
            {
                return nRight;
            }

            set
            {
                nRight = value;
            }
        }
        #endregion

        #region Constructors
        //Note that we are using constructor chaining
        public Node() : this(default(T), null, null) { }
        public Node(T tData) : this(tData, null, null) { }
        public Node(T tData, Node<T> nLeft, Node<T> nRight)
        {
            this.tData = tData;
            this.nLeft = nLeft;
            this.nRight = nRight;
        }
        #endregion

        #region Other Functionality
        public bool IsLeaf()
        {
            return this.Left == null && this.Right == null;
        }
        #endregion
    }
}
