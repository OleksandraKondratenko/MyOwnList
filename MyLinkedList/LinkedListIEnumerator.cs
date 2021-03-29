using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> current;

        public LinkedListEnumerator(Node<T> current)
        {
            this.current = current;
        }

        public T Current => current.Data;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (current == null)
            {
                return false;
            }

            current = current.Next;
            return (current != null);
        }

        public void Dispose()
        {

        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
