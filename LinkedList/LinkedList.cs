using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace LinkedList
{
    public class LinkedList<T> : A_List<T> where T : IComparable<T>
    {
        #region Attributes
        private Node head;
        #endregion

        public override void Add(T data)
        {
            head = RecAdd(data, head);
        }

        private Node RecAdd(T data, Node current)
        {
            //Base case - current node is null
            if (current == null)
            {
                current = new Node(data);
            }
            else
            {
                //Could check if current.next is null then assign.
                //However, the if statement would be less efficient than just assigning.
                current.next = RecAdd(data, current.next);
            }

            return current;

        }

        public override void Clear()
        {
            head = null;
        }

        public override void Insert(int index, T data)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            head = RecInsert(index, data, head);
        }

        private Node RecInsert(int index, T data, Node current)
        {
            if (index > 0)
            {
                current.next = RecInsert(--index, data, current.next);
            }
            else if (index == 0)
            {
                current = new Node(data, current);
            }
            return current;
        }

        public override bool Remove(T data)
        {
            return RecRemove(ref head, data);
        }

        private bool RecRemove(ref Node current, T data)
        {
            bool found = false;

            if (current != null)
            {
                if (current.data.Equals(data))
                {
                    found = true;
                    if (current.next != null)
                    {
                        current = current.next;
                    }
                    else
                    {
                        current = null;
                    }

                }
                else
                {
                    found = RecRemove(ref current.next, data);
                }
            }

            return found;
        }

        public override T RemoveAt(int index)
        {
            return RecRemoveAt(ref head, index, 0);
        }

        private T RecRemoveAt(ref Node current, int index, int currIndex)
        {
            T myT = default(T);

            if (currIndex == index && index >= 0)
            {
                if (current.next != null || current != null)
                {
                    myT = current.data;
                    current = current.next;
                }
                else
                {
                    throw new ApplicationException("Index out of bounds");
                }
            }
            else
            {
                myT = RecRemoveAt(ref current.next, index, ++currIndex);
            }

            return myT;
        }

        public override T ReplaceAt(int index, T data)
        {
            return RecReplaceAt(index, data, ref head, 0);
        }

        private T RecReplaceAt(int index, T data, ref Node current, int currIndex)
        {
            T myT = default(T);

            if (current != null && index >= 0)
            {
                if (currIndex == index)
                {
                    current = new Node(data, current.next);
                    myT = current.data;
                }
                else
                {
                    myT = RecReplaceAt(index, data, ref current.next, ++currIndex);
                }
            }
            else
            {
                throw new ApplicationException("Index out of bounds");
            }
            return myT;
        }
            

        public override IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        #region Enumerator Implemenation
        private class Enumerator : IEnumerator<T>
        {
            private LinkedList<T> parent;
            private Node lastVisited;   //The current node that we visited
            private Node scout; //The next node to visit
                        
            public Enumerator(LinkedList<T> parent)
            {
                this.parent = parent;
                Reset();
            }

            public T Current
            {
                get
                {
                    return lastVisited.data;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return lastVisited.data;
                }
            }

            public void Dispose()
            {
                parent = null;
                scout = null;
                lastVisited = null;
            }

            public bool MoveNext()
            {
                if (scout != null)
                {
                    lastVisited = scout;
                    scout = scout.next;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                //Set the node currently looked at to null
                lastVisited = null;
                //Point the scout to head of the list
                scout = parent.head;
            }
        }

        #endregion
        #region Node Class
        //A class that represents the data and a reference to the nodes next neighbour
        private class Node
        {
            #region Attributes
            public T data;
            public Node next;
            #endregion

            //Constructor chaining in C#
            public Node (T data) : this(data, null) { }

            public Node (T data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }
        #endregion
    }
}
