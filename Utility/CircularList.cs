using System;
using System.Collections.Generic;
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

        public string LastOrDefault()
        {
            if (tail != null)
                return tail.data.ToString();
            return String.Empty;
        }

        public Dictionary<string,int>CountFrequency()
        {
            Dictionary<string, int> frequencyCounter = new Dictionary<string, int>();

            Node<T> currentNode = head;
            while(currentNode!=tail)
            {
                if (frequencyCounter.ContainsKey(currentNode.data.ToString()))
                    frequencyCounter[currentNode.data.ToString()] += 1;
                else
                    frequencyCounter[currentNode.data.ToString()] = 1;

            }
           
            return frequencyCounter;
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
