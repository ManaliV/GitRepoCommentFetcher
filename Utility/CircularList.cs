using System;
using System.Text;

namespace Util
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T value)
        {
            data = value;
            next = null;
        }
    }

    public class CircularLinkList<T>
    {
        protected Node<T> head = null;
        protected Node<T> tail = null;

        public void add(T data)
        {
           
            Node<T> newNode = new Node<T>(data);
           
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                newNode.next = head;
            }
            else
            {
           
                tail.next = newNode;
                tail = newNode;
                tail.next = head;
            }
        }

        public string display()
        {
            string dataInList = string.Empty;
            Node<T> current;
            
            if(head!=null)
            {
                StringBuilder buffer = new StringBuilder();
                buffer.Append(head.data);
                
                for (current = head.next; current != head; current = current.next)                  
                    buffer.Append(current.data);

                dataInList = buffer.ToString();
            }

            return dataInList;
        }
    }

}
