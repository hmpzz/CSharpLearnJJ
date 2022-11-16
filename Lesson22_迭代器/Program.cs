using System.Collections;

namespace Lesson22_迭代器
{
    internal class Program
    {
        #region 知识点一 迭代器是什么
        //迭代器(iterator) 时又称光标(cursor)
        //是程序设计的软件设计模式
        //迭代器模式提供一个方法顺序访问一个聚合对象中的各个元素
        //而又不暴露其内部的标识
        //在表现效果上看
        //是可以在容器对象(例如链表或数组)上遍历访问的接口
        //设计人员无需关心容器对象的内存分配的实现细节
        //可以用foreach遍历的类， 都是实现了迭代器的
        #endregion

        #region 知识点二 标准迭代器的实现方法
        //关键接口：IEnumerator， IEnumerable
        //命名空间：using System.Collections；
        //可以通过同时继承IEnumerable和IEnumerator实现其中的方法

        class CustomList : IEnumerable, IEnumerator
        {
            private int[] list;

            private int position = -1;//这个是给movenext方法用的,用于表示数据到了哪个位置
            public CustomList()
            {
                list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            }


            #region IEnumerable
            public IEnumerator GetEnumerator()
            {

                Reset();
                //return list.GetEnumerator();
                return this;
                //throw new NotImplementedException();
            }

            #endregion

            #region IEnumerator
            public object Current
            {
                get { return list[position]; }
            }


            public bool MoveNext()
            {
                position++;

                //判断是否溢出
                return position < list.Length;

            }

            public void Reset()
            {
                position = -1;
            }

            #endregion
        }

        #endregion

        #region 知识点三 用yield return 语法糖实现迭代器
        //yield return是c#提供给我们的语法糖
        //所谓语法糖，也称糖衣语法
        //主要作用就是将复杂逻辑简单化，可以增加程序的可读性
        //从而减少程序代码出错的机会

        //关键接口：IEnumerable
        //命名空间：using System.Collections；
        //让想要通过for each遍历的自定义类实现接口中的方法GetEnumerator即可

        class CustomList2 : IEnumerable
        {
            private string[] list;

            public CustomList2()
            {
                list = new string[] { "a", "b", "c","d","e","f"};
            }
            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < list.Length; i++)
                {
                    //yield关键字 配合迭代器使用
                    //可以理解为 暂时返回保留当前的状态
                    //一会还会再回来

                    //C#语法糖
                    yield return list[i];
                }


            }
        }
        #endregion

        #region 知识点四 用yield return 语法糖为泛型类实现迭代器
        class customList<T> : IEnumerable
        {
            private T[] array;

            public customList(params T[] _array)
            {
                array = _array;
            }

            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    yield return array[i];
                }
            }
        }

        #endregion


        static void Main(string[] args)
        {
            Console.WriteLine("Lesson22_迭代器");

            CustomList customList = new CustomList();
            
            //foreach 本质
            //1.先获取in后面的那个对象的 IEnumerator
            //  会调用对象其中的GetEnumerator方法 来获取
            //2.执行得到这个IEnumerator对象中的 MoveNext方法
            //3.只要这个MoveNext方法的返回值是true 就会去得到Current
            //  然后赋值给item
            foreach (int item in customList)
            {
                Console.WriteLine(item);
            }

            foreach (int item in customList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("**************************");
            CustomList2 customList2 = new CustomList2();
            foreach (string item in customList2)
            {
                Console.WriteLine(item);
            }

            foreach (string item in customList2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("**************************");

            customList<string> list2 = new customList<string>("123","a","fdsfds","pppp");

            foreach (string item in list2)
            {
                Console.WriteLine(item);
            }

            foreach (string item in list2)
            {
                Console.WriteLine(item);
            }



        }
    }
}