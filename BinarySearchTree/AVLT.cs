using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class AVLT<T>: BST<T> where T:IComparable<T>
    {
        /// <summary>
        /// Balances the subtree with root nCurrent
        /// </summary>
        /// <param name="nCurrent">Root of the subtree to be balanced</param>
        /// <returns>The new potential root of the balanced subtree</returns>
        protected override Node<T> Balance(Node<T> nCurrent)
        {
            /*
            If current is not null
                heightDiff <-- get the height difference of the current node
                if the current tree is unbalanced to the right (right heavy)
                    rightChildDiff <-- get the height difference of current's right child
                    if right child is left heavy
                        newRoot <-- Double left on the current node
                    else
                        newRoot <-- Single left on current node
                else if current tree is unbalanced to the left
                    leftChildDiff <-- get the height difference of current's left child
                    if left child is right heavy
                        newRoot <-- Double right on the current node
                    else
                        newRoot <-- Single right on the current node
             return newRoot
             */
            Node<T> nNewRoot = nCurrent;
            
            if(nCurrent != null)
            {
                int heightDiff = GetHeightDifference(nCurrent);
                if(heightDiff < -1)
                {
                    int rightChildDiff = GetHeightDifference(nCurrent.Right);
                    
                    if(rightChildDiff >= 1)
                    {
                        nNewRoot = DoubleLeft(nCurrent);
                    }
                    else
                    {
                        nNewRoot = SingleLeft(nCurrent);
                    }
                }
                else if (heightDiff > 1)
                {
                    int leftChildDiff = GetHeightDifference(nCurrent.Left);

                    if(leftChildDiff <= -1)
                    {
                        nNewRoot = DoubleRight(nCurrent);
                    }
                    else
                    {
                        nNewRoot = SingleRight(nCurrent);
                    }
                }
            }
            
            return nNewRoot;
        }

        #region Other Helpers
        /// <summary>
        /// Determines the height difference between the left and right child nodes
        /// of the current node.
        /// </summary>
        /// <param name="nCurrent">Current node to test its height difference</param>
        /// <returns>Positive means left heavy, negative means right heavy. Absolute value would be the height difference</returns>
        public int GetHeightDifference(Node<T> nCurrent)
        {
            int iHeightLeft = -1;
            int iHeightRight = -1;
            int iHeightDiff = 0;

            if(nCurrent != null)
            {
                if(nCurrent.Left != null)
                {
                    iHeightLeft = RecHeight(nCurrent.Left);
                }
                
                if(nCurrent.Right != null)
                {
                    iHeightRight = RecHeight(nCurrent.Right);
                }

                iHeightDiff = iHeightLeft - iHeightRight;
            }

            return iHeightDiff;
        }
        #endregion

        #region Rotations
        private Node<T> SingleLeft(Node<T> nOldRoot)
        {
            //Step 1
            Node<T> nNewRoot = nOldRoot.Right;
            //Step 2
            nOldRoot.Right = nNewRoot.Left;
            //Step 3
            nNewRoot.Left = nOldRoot;
            return nNewRoot;
        }

        private Node<T> SingleRight(Node<T> nOldRoot)
        {
            //Step 1
            Node<T> nNewRoot = nOldRoot.Left;
            //Step 2
            nOldRoot.Left = nNewRoot.Right;
            //Step 3
            nNewRoot.Right = nOldRoot;
            return nNewRoot;
        }

        private Node<T> DoubleLeft(Node<T> nOldRoot)
        {
            nOldRoot.Right = SingleRight(nOldRoot.Right);
            return SingleLeft(nOldRoot);
        }

        private Node<T> DoubleRight(Node<T> nOldRoot)
        {
            nOldRoot.Left = SingleLeft(nOldRoot.Left);
            return SingleRight(nOldRoot);
        }
        #endregion
    }
}
