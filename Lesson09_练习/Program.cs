using System.Collections.Generic;

namespace Lesson09_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson09_练习");


            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.AddNode(1);
            linkedList.AddNode(2);
            linkedList.AddNode(3);
            linkedList.AddNode(4);

            Console.WriteLine($@"节点数量:{LinkedList<int>.NodeCount}");
            

            linkedList.Remove(3);
            Console.WriteLine($@"节点数量:{LinkedList<int>.NodeCount}");
            LinkedNode<int> linkedNode = LinkedList<int>.head;

            while(linkedNode != null)
            {
                Console.WriteLine(linkedNode.Value);
                linkedNode = linkedNode.nextNode;
            }
        }
    }


    class LinkedNode<T>
    {



        public T Value { get; set; }

        public LinkedNode<T> preNode { set; get; }

        public LinkedNode<T> nextNode { set; get; }

        public LinkedNode(T _value)
        {
            Value = _value;
        }

    }

    class LinkedList<T>
    {
        public static int NodeCount { get; set; }
        public static LinkedNode<T> head { get; set; }
        public static LinkedNode<T> last { get; set; }

        public LinkedList()
        {
            NodeCount = 0;
        }



        public void AddNode(T _value)
        {
            if (head == null)
            {
                head = new LinkedNode<T>(_value);
                head.preNode = null;
                head.nextNode = null;

                last = head;
            }
            else
            {
                LinkedNode<T> temp = new LinkedNode<T>(_value);
                last.nextNode = temp;
                temp.preNode = last;

                last = temp;
                temp.nextNode = null;
            }

            NodeCount += 1;
        }


        public void Remove(T _value)
        { 
            LinkedNode<T> temp = head;

            while (temp!=null)
            {
                if (temp.Value.Equals(_value))
                {
                    if (temp.preNode==null)
                    {
                        if (temp.nextNode==null)
                        {
                            head = null;
                            last = null;

                        }
                        else
                        {
                            head = temp.nextNode;
                            temp.nextNode.preNode = null;
                        }
                        
                        

                    }
                    else if (temp.nextNode==null)
                    {
                        last = temp.preNode;
                        temp.preNode.nextNode = null;
                    }
                    else
                    {
                        temp.preNode.nextNode = temp.nextNode;
                        temp.nextNode.preNode = temp.preNode;
                    }
                    
                    
                }

                temp = temp.nextNode;
            }
            NodeCount-=1;
        }
    }
}