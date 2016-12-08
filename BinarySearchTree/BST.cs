using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BST<T> : A_BST<T>, ICloneable where T : IComparable<T>
    {
        public BST()
        {
            //Initialize the root node to an empty tree
            nRoot = null;
            //Set the count
            iCount = 0;
        }

        //A virtual balance method that "MAY" be overriden in the child class.
        protected virtual Node<T> Balance (Node<T> nCurrent)
        {
            return nCurrent;
        }

        public override void Add(T data)
        {
            //if the root is null, set it to a node
            if(nRoot == null)
            {
                nRoot = new Node<T>(data);
            }
            else
            {
                RecAdd(data, nRoot);
                nRoot = Balance(nRoot);
            }
            iCount++;
        }

        private void RecAdd(T data, Node<T> nCurrent)
        {
            //Compare the data to add with data in current node
            int iResult = data.CompareTo(nCurrent.Data);

            //if data item is less than current node's data
            if (iResult < 0)
            {
                //if the left node is null
                //  create a new node for the left tree
                //else
                //  recurse to the left node
                if(nCurrent.Left == null)
                {
                    nCurrent.Left = new Node<T>(data);
                }
                else
                {
                    RecAdd(data, nCurrent.Left);
                    nCurrent.Left = Balance(nCurrent.Left);
                }
            }
            //Note that duplicates will be allowed and they go in the right tree.
            else
            {
                //if the right node is null
                //  create a new node for the right tree
                //else
                //  recurse to the right node
                if (nCurrent.Right == null)
                {
                    nCurrent.Right = new Node<T>(data);
                }
                else
                {
                    RecAdd(data, nCurrent.Right);
                    nCurrent.Right = Balance(nCurrent.Right);
                }
            }
        }

        public override void Clear()
        {
            //RecClear(this.nRoot);
            this.nRoot.Right = null;
            this.nRoot.Left = null;
            this.nRoot = null;
        }

        private Node<T> RecClear(Node<T> nCurrent)
        {
            if(nCurrent.IsLeaf())
            {
                return null;
            }
            else
            {
                if(nCurrent.Left != null)
                {
                    nCurrent.Left = RecClear(nCurrent.Left);
                }
                
                if(nCurrent.Right != null)
                {
                    nCurrent.Right = RecClear(nCurrent.Right);
                }

                return nCurrent;
            }
        }

        public object Clone()
        {
            BST<T> clone = (BST<T>)Activator.CreateInstance(this.GetType());
            clone.nRoot = RecClone(this.nRoot);
            clone.iCount = this.iCount;
            return clone;
        }

        private Node<T> RecClone(Node<T> nCurrent)
        {
            Node<T> nNewNode = new Node<T>(nCurrent.Data);

            if(!nCurrent.IsLeaf())
            {
                if (nCurrent.Left != null)
                {
                    nNewNode.Left = RecClone(nCurrent.Left);
                }

                if (nCurrent.Right != null)
                {
                    nNewNode.Right = RecClone(nCurrent.Right);
                }
            }

            return nNewNode;
        }

        public override T Find(T data)
        {
            T retData = default(T);
            if (nRoot.Data.CompareTo(data) == 0)
            {
                retData = nRoot.Data;
            }
            else if (nRoot.Data.CompareTo(data) < 0)
            {
                retData = RecFind(data, nRoot.Right);
            }
            else
            {
                retData = RecFind(data, nRoot.Left);
            }

            return retData;
        }

        private T RecFind(T data, Node<T> nCurrent)
        {
            if (nCurrent.Data.CompareTo(data) == 0)
            {
                return nCurrent.Data;
            }
            else if (nCurrent.Data.CompareTo(data) < 0)
            {
                return RecFind(data, nCurrent.Right);
            }
            else
            {
                return RecFind(data, nCurrent.Left);
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new DepthEnumerator(this);
        }

        public string PathString(T tData)
        {
            string retString = "";

            if(nRoot.Data.CompareTo(tData) == 0)
            {
                retString = nRoot.Data.ToString();
            }
            else if (nRoot.Data.CompareTo(tData) < 0)
            {
                retString += nRoot.Data.ToString() + " " + RecPathString(tData, nRoot.Right);
            }
            else
            {
                retString += nRoot.Data.ToString() + " " + RecPathString(tData, nRoot.Left);
            }

            return retString;
        }

        private string RecPathString(T tData, Node<T> nCurrent)
        {
            if(nCurrent.Data.CompareTo(tData) == 0)
            {
                return nCurrent.Data.ToString();
            }
            else if (nCurrent.Data.CompareTo(tData) < 0)
            {
                return nCurrent.Data.ToString() + " " + RecPathString(tData, nCurrent.Right);
            }
            else
            {
                return nCurrent.Data.ToString() + " " + RecPathString(tData, nCurrent.Left);
            }
        }

        public override int Height()
        {
            int iHeight = -1;

            if(nRoot != null)
            {
                iHeight = RecHeight(nRoot);
            }
            return iHeight;
        }

        protected int RecHeight(Node<T> nCurrent)
        {
            int iHeightLeft = 0;
            int iHeightRight = 0;

            if(nCurrent.IsLeaf())
            {
                return 0;
            }

            if(nCurrent.Left != null)
            {
                iHeightLeft = RecHeight(nCurrent.Left) + 1;
            }

            if(nCurrent.Right != null)
            {
                iHeightRight = RecHeight(nCurrent.Right) + 1;
            }

            return iHeightLeft > iHeightRight ? iHeightLeft : iHeightRight;
        }

        public void IterateBreadth(ProcessData<T> pd)
        {
            Node<T> nCurrent = null;
            Queue<Node<T>> qNodes = new Queue<Node<T>>();
            if(nRoot != null)
            {
                qNodes.Enqueue(nRoot);

                while(qNodes.Count > 0)
                {
                    nCurrent = qNodes.Dequeue();
                    //Process the data
                    pd(nCurrent.Data);
                    //Add the left child
                    if(nCurrent.Left != null)
                    {
                        qNodes.Enqueue(nCurrent.Left);
                    }

                    //Add the right child
                    if(nCurrent.Right != null)
                    {
                        qNodes.Enqueue(nCurrent.Right);
                    }
                    
                }
            }
        }

        public override void Iterate(ProcessData<T> pd, TRAVERALORDER to)
        {
            if(nRoot != null)
            {
                RecIterate(nRoot, pd, to);
            }
        }

        private void RecIterate(Node<T> nCurrent, ProcessData<T> pd, TRAVERALORDER to)
        {
            if(to == TRAVERALORDER.PRE_ORDER)
            {
                //Process the current node
                pd(nCurrent.Data);
            }

            //If the left node exists, recurse to it
            if(nCurrent.Left != null)
            {
                RecIterate(nCurrent.Left, pd, to);
            }

            if(to == TRAVERALORDER.IN_ORDER)
            {
                //Process the current node
                pd(nCurrent.Data);
            }

            //if the right node exists, recurse to it
            if (nCurrent.Right != null)
            {
                RecIterate(nCurrent.Right, pd, to);
            }

            if(to == TRAVERALORDER.POST_ORDER)
            {
                //Process the current node
                pd(nCurrent.Data);
            }
            
        }

        public override bool Remove(T data)
        {
            //if current is not null
            //  if item to remove is less than current
            //      current's left = recurive remove from current's left
            //  else if item to remove is greater than current
            //      current's right = recursive remove from current's right
            //  else
            //      wasRemoved <- true
            //      if current is a leaf
            //          current <- null
            //          count - 1
            //      else
            //          if current's left exists
            //              substitute <- recFindLargest in current's left
            //              current's data <- substitute
            //              current's left <- recRemove the substitute from current's left
            //          else
            //              substitute <- recFindSmallest in current's right
            //              current's data <- substitute
            //              current's right <- recRemove the substitute from current's right
            //return current

            bool wasRemoved = false;
            nRoot = RecRemove(nRoot, data, ref wasRemoved);
            nRoot = Balance(nRoot);
            return wasRemoved;
        }

        private Node<T> RecRemove(Node<T> nCurrent, T data, ref bool wasRemoved)
        {
            T tSubstitute = default(T);
            int iCompare = 0;

            iCompare = data.CompareTo(nCurrent.Data);

            if(nCurrent != null)
            {
                if (iCompare < 0)
                {
                    nCurrent.Left = RecRemove(nCurrent.Left, data, ref wasRemoved);
                    nCurrent.Left = Balance(nCurrent.Left);
                }
                else if (iCompare > 0)
                {
                    nCurrent.Right = RecRemove(nCurrent.Right, data, ref wasRemoved);
                    nCurrent.Right = Balance(nCurrent.Right);
                }
                else
                {
                    wasRemoved = true;
                    if(nCurrent.IsLeaf())
                    {
                        nCurrent = null;
                        iCount--;
                    }
                    else
                    {
                        if(nCurrent.Left != null)
                        {
                            tSubstitute = RecFindLargest(nCurrent.Left);
                            nCurrent.Data = tSubstitute;
                            nCurrent.Left = RecRemove(nCurrent.Left, tSubstitute, ref wasRemoved);
                            nCurrent.Left = Balance(nCurrent.Left);
                        }
                        else
                        {
                            /*
                            tSubstitute = RecFindSmallest(nCurrent.Right);
                            nCurrent.Data = tSubstitute;
                            nCurrent.Right = RecRemove(nCurrent.Right, tSubstitute, ref wasRemoved);
                            */
                            nCurrent = nCurrent.Right;
                        }
                    }
                }
            }

            return nCurrent;
        }

        #region Other Functionality
        public T FindSmallest()
        {
            T tData = default(T);
            //if the root is not null
            if(nRoot != null)
            {
                //Recursively find the smallest value
                tData = RecFindSmallest(nRoot);
            }
            else
            {
                //indicate error
                throw new ApplicationException("Something went wrong.");
            }
            return tData;
        }

        private T RecFindSmallest(Node<T> nCurrent)
        {
            T tData = default(T);

            if(nCurrent.Left != null)
            {
                tData = RecFindSmallest(nCurrent.Left);
            }
            else
            {
                tData = nCurrent.Data;
            }

            return tData;
        }

        public T FindLargest()
        {
            //if the root is not null
            if (nRoot != null)
            {
                //Recursively find the largest value
                return RecFindLargest(nRoot);
            }
            else
            {
                //indicate error
                throw new ApplicationException("Something went wrong.");
            }
        }

        private T RecFindLargest(Node<T> nCurrent)
        {
            T tData = default(T);

            if (nCurrent.Right != null)
            {
                tData = RecFindLargest(nCurrent.Right);
            }
            else
            {
                tData = nCurrent.Data;
            }

            return tData;
        }
        #endregion

        #region Enumerator Implemenation
        private class DepthEnumerator : IEnumerator<T>
        {
            private BST<T> parent = null;
            private Node<T> nCurrent = null;
            private Stack<Node<T>> sNodes = null;

            public DepthEnumerator(BST<T> parent)
            {
                this.parent = parent;
                Reset();
            }

            public T Current
            {
                get
                {
                    return nCurrent.Data;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return nCurrent.Data;
                }
            }

            public void Dispose()
            {
                parent = null;
                nCurrent = null;
                sNodes = null;
            }

            public bool MoveNext()
            {
                bool bMoved = false;

                if(sNodes.Count > 0)
                {
                    nCurrent = sNodes.Pop();
                    bMoved = true;
                    if (nCurrent.Right != null)
                    {
                        sNodes.Push(nCurrent.Right);
                    }

                    if (nCurrent.Left != null)
                    {
                        sNodes.Push(nCurrent.Left);
                    }
                }

                return bMoved;
            }

            public void Reset()
            {
                sNodes = new Stack<Node<T>>();
                //Push the root on the stack
                if(parent.nRoot != null)
                {
                    sNodes.Push(parent.nRoot);
                }
                nCurrent = null;
            }
        }

        private class BreadthEnumerator : IEnumerator<T>
        {
            private BST<T> parent = null;
            private Node<T> nCurrent = null;
            private Queue<Node<T>> qNodes = null;

            public BreadthEnumerator(BST<T> parent)
            {
                this.parent = parent;
                Reset();
            }

            public T Current
            {
                get
                {
                    return nCurrent.Data;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return nCurrent.Data;
                }
            }

            public void Dispose()
            {
                parent = null;
                nCurrent = null;
                qNodes = null;
            }

            public bool MoveNext()
            {
                bool bMoved = false;

                if (qNodes.Count > 0)
                {
                    nCurrent = qNodes.Dequeue();
                    bMoved = true;
                    if (nCurrent.Right != null)
                    {
                        qNodes.Enqueue(nCurrent.Right);
                    }

                    if (nCurrent.Left != null)
                    {
                        qNodes.Enqueue(nCurrent.Left);
                    }
                }

                return bMoved;
            }

            public void Reset()
            {
                qNodes = new Queue<Node<T>>();
                //Push the root on the stack
                if (parent.nRoot != null)
                {
                    qNodes.Enqueue(parent.nRoot);
                }
                nCurrent = null;
            }
        }
        #endregion
    }
}
