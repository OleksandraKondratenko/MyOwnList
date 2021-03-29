using System;

namespace MyLinkedList
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; set; }

        public Node(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Null data passed");
            }

            Data = data;
        }
    }
}
