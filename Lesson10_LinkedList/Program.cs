using System.Collections.Generic;

namespace Lesson10_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson10_LinkedList");

            #region 知识点一 LinkedList
            //LinkedList是一个C#为我们封装好的类
            //它的本质是一个可变类型的泛型双向链表
            #endregion

            #region 知识点二 申明
            //需要引用命名空间
            //using System.Collections.Generic 

            LinkedList<int> linkedList = new LinkedList<int>();



            //链表对象 需要掌握两个类
            //一个是链表本身 一个是链表节点类LinkedListNode
            #endregion

            #region 知识点三 增删查改

            #region 增
            //1．在链表尾部添加元素
            linkedList.AddLast(10);

            //2．在链表头部添加元素
            linkedList.AddFirst(20);

            //3．在某一个节点之后添加一个节点
            // 要指定节点 先得得到一个节点
            
            linkedList.AddBefore(linkedList.Find(10), 5);

            //4．在某一个节点之前添加一个节点
            // 要指定节点 先得得到一个节点
            linkedList.AddAfter(linkedList.Find(10), 15);
            
            #endregion


            #region 删

            //1．移除头节点
            linkedList.RemoveFirst();

            //2．移除尾节点
            linkedList.RemoveLast();

            //3．移除指定节点
            linkedList.Remove(10);
            // 无法通过位置直接移除

            //5．清空
            linkedList.Clear();


            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            #endregion

            #region 查

            //1．头节点
            LinkedListNode<int>? first =linkedList.First;

            //2．尾节点
            LinkedListNode<int>? last = linkedList.Last;

            //3．找到指定值的节点
            //无法直接通过下标获取中间元素
            //只有遍历查找指定位置元素
            LinkedListNode<int>? node01 = linkedList.Find(3);
            node01 = linkedList.Find(5);   //找不到就为空

            //4．判断是否存在
            int p = 1;
            if (linkedList.Contains(p))
            {
                Console.WriteLine($@"链表中存在{p}");
            }

            #endregion

            # region 改 
            //要先得再改得到节点再故其中的值，
            Console.WriteLine(linkedList.First.Value);
            linkedList.First.Value = 10;
            Console.WriteLine(linkedList.First.Value);

            #endregion

            #endregion

            #region 遍历
            //1.foreach遍历
            foreach (int item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("***************************");
            //2.通过节点遍历
            //从头到尾

            LinkedListNode<int> nodeBL =linkedList.First;

            while (nodeBL!=null)
            {
                Console.WriteLine(nodeBL.Value);
                nodeBL=nodeBL.Next;
            }

            Console.WriteLine("***************************");
            //从尾到头
            nodeBL = linkedList.Last;
            while (nodeBL != null)
            {
                Console.WriteLine(nodeBL.Value);
                nodeBL = nodeBL.Previous;
            }
            #endregion

        }
    }
}