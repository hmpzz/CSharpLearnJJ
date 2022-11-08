using System.Collections;

namespace Lesson03_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson03_Queue");


            #region 知识点一 Queue的本质
            //Queue(队列) 是一个C#为我们封闭好的类
            //它的本质也是object[]数组，只是封闭了特殊的存储规则

            //Queue是队列存储容器，栈是一种先进先出的数据结构
            //先存入的数据先获取，后存入的数据后获取
            //队列是先进先出
            #endregion

            #region 知识点二 申明
            //需要引用命名空间 System.Collections
            Queue queue = new Queue();

            #endregion

            #region 知识点三 增取查改

            #region 增
            queue.Enqueue(1);
            queue.Enqueue("123");
            queue.Enqueue(1.4f);
            queue.Enqueue(new Test());

            #endregion

            #region 取
            //队列中不存在删除的概念
            //只有取的概念 取出先加入的对象
            
            object? v =queue.Dequeue();
            Console.WriteLine(v);

            v = queue.Dequeue();
            Console.WriteLine(v);
            #endregion

            #region 查
            //1.队列无法查看指定位置的 元素
            //  只能查看队列头部的元素，但不会移除
            v = queue.Peek();
            Console.WriteLine(v);
            v = queue.Peek();
            Console.WriteLine(v);

            //2.查看元素是否存在于队列中
            if (queue.Contains("123"))
            {
                Console.WriteLine("有");
            }
            else
            {
                Console.WriteLine("没有");
            }
            #endregion

            #region 改
            //队列无法改变其中的元素 只能进和出
            //实在要改只有清空
            queue.Clear();
            queue.Enqueue("1");
            queue.Enqueue(2);
            queue.Enqueue("哈哈哈");

            #endregion

            #endregion

            #region 知识点四 遍历 
            //1.长度
            Console.WriteLine(queue.Count);

            //2.用foreach遍历
            //  而且遍历出来的顺序也是从队列头到队列尾
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }

            //3.还有一种遍历方式
            //  将队列转换为object数组
            //  遍历出来的顺序 也是从队列头到队列尾
            object?[] array = queue.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }


            //4.循环出队
            while (queue.Count > 0)
            {
                object? o = queue.Dequeue();
                Console.WriteLine(o);
            }
            Console.WriteLine(queue.Count);
            #endregion

            #region 知识点五 装箱拆箱
            //由于用万物之父来存储数据，自然存在装箱拆箱
            //当往其中进行值类型存储时就是在装箱，当将值类型对象取出来转换使用时，就存在拆箱
            #endregion
        }
    }

    class Test
    { }
}