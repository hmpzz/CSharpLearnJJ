using System.Collections;
using System.Collections.Generic;

namespace Lesson09_顺序存储和链式存储
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson09_顺序存储和链式存储");

            #region 知识点一 数据结构
            //数据结构
            //数据结构是计算机存储、组织数据的方式（规则）
            //数据结构是指相互之间存在一种或多种特定关系的数据元素的集合
            //比如自定义的一个 类 也可以称为一种数据结构 自己定义的数据组合规则//不要把数据结构想的太复杂

            //简单点理解，就是人定义的 存储数据 和表示数据之间关系 的规则而已//常用的数据结构（前辈总结和制定的一些经典规则）
            //数组、栈、队列、链表、树、图、堆、散列表
            #endregion

            #region 知识点二 线性表
            //线性表是一种数据结构，是由n个具有相同特性的数据元素的有限序列
            //比如数组、ArrayList、Stack.Queue

            #endregion

            //顺序存储和链式存储 是数据结构中两种 存储结构

            #region 知识点三 顺序存储
            //数组、Stack、Queue、List、ArrayList - 顺序存储 
            //只是 数组、Stack、Queue的 组织规则不同而已

            //顺序存储：
            //用一组地址连续的存储单元依次存储线性表的各个数据元素
            #endregion

            #region 知识点四 链式存储
            //单向链表、双向链表、循环链表   链式存储
            //链式存储（链接存储）：
            //用一组任意的存储单元存储线性表中的各个数据元素

            #endregion


            LinkedNode<int> node01 = new LinkedNode<int>(1);
            LinkedNode<int> node02 = new LinkedNode<int>(2);

            node01.nextNode = node02;
            node02.nextNode = new LinkedNode<int>(3);


            LinkedList<int> link = new LinkedList<int>();
            link.AddValue(1);
            link.AddValue(2);
            link.AddValue(3);
            link.AddValue(4);

            link.Remove(3);

            LinkedNode<int> linknode = link.head;

            while (linknode!=null)
            {
                Console.WriteLine(linknode.Value);
                linknode = linknode.nextNode;
            }



        }
    }

    #region 知识点五 自己实现一个最简单的单向链表
    class LinkedNode<T>
    {
        public T Value { get; set; }
        //存储下一个元素是谁
        public LinkedNode<T> nextNode;

        public LinkedNode(T _value)
        {
            this.Value = _value;
        }
    }

    class LinkedList<T>
    {
        public LinkedNode<T> head;
        public LinkedNode<T> last;
        //public LinkedList()
        //{
        //    if (head==null)
        //    {
        //        head = new LinkedNode<T>();
        //    }
        //}

        public void AddValue(T _value)
        {
            LinkedNode<T> node = new LinkedNode<T>(_value);
            if (head == null)
            {
                head = node;
                last = node;
            }
            else
            {
                last.nextNode = node;
                last = node;
            }
        }

        public void Remove(T _value)
        {
            if (head == null)
            {
                return;
            }
            if (head.Value.Equals(_value))
            {
                head = head.nextNode;

                if (head == null)
                {
                    last = null;
                }
                return;
            }


            LinkedNode<T> node = head;
            while (node.nextNode!=null)
            {
                if (node.nextNode.Value.Equals(_value))
                {
                    node.nextNode = node.nextNode.nextNode;
                    break;
                }
                else
                {
                    node = node.nextNode;
                }
            }
        }
    }
    #endregion

    #region 知识点六 顺序存储和链式存储的优缺点
    //从增删查改的角度去思考

    //增：链式存储 计算上 优于顺序存储 （中间插入时链式不用像顺序一样去移动位置）//删：链式存储 计算上 优于顺序存储 （中间删除时链式不用像顺序一样去移动位置）

    //查：顺序存储 使用上 优于链式存储 （数组可以直接通过下标得到元素，链式需要遍历）//改：顺序存储使用上 优于链式存储 （数组可以直接通过下标得到元素，链式需要遍历）


    #endregion

}