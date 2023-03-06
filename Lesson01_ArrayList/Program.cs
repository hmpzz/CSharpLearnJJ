using System.Collections;

namespace Lesson01_ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("ArrayList");

            #region 知识点一 ArrayList的本质
            //ArrayList是一个C#为我们封装好的类
            //它的本质是一个object类型的数组
            //ArrayList类帮助我们实现了很多方法
            //比如数组的增删查改
            #endregion

            #region 知识点二 申明
            ArrayList array = new ArrayList();

            #endregion

            #region 增删查改

            #region 增
            //啥对象都能加
            array.Add(1);
            array.Add("123");
            array.Add(true);
            array.Add(new object());


            ArrayList array2 = new ArrayList();
            array2.AddRange(array);

            //在指定位置插入
            array.Insert(1, "123456");

            #endregion

            #region 删
            //移除指定元素，从头找，找到就删除
            array.Remove("123");
            //移除指定位置的元素
            array.RemoveAt(1);
            //清空
            //array.Clear();
            #endregion

            #region 查
            //得到指定位置的元素
            Console.WriteLine(array[0]);

            //查看元素是否存在
            if (array.Contains(1))
            {
                Console.WriteLine("找到了！");
            }
            else
            {
                Console.WriteLine("没找到！");
            }

            //正向查找元素位置
            //找到的返回值是位置 找不到返回值 是-1

            int index = array.IndexOf(1);
            Console.WriteLine(index);

            //反向查找元素位置
            //返回是从头开始的索引数 
            index = array.LastIndexOf(1);
            Console.WriteLine(index);
            #endregion

            #region 改
            Console.WriteLine(array[0]);
            array[0] = "999";
            Console.WriteLine(array[0]);
            #endregion


            #endregion

            #region 遍历
            //长度
            Console.WriteLine(array.Count);
            //容量
            Console.WriteLine(array.Capacity);
            Console.WriteLine("***********************");
            for (int k = 0; k < array.Count-1; k++)
            {
                Console.WriteLine(array[k]);
            }
            Console.WriteLine("***********************");
            //迭代器遍历
            foreach (object item in array)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region 装箱拆箱
            //ArrayList本质上是一个可以自动扩容的object数组
            //由于用万物之父来存储数据，自然存在装箱拆箱
            //当往其中进行值类型存储时就是在装箱，当将值类型对象取出来转换使用时，就存在拆箱
            //所以ArrayList尽量少用，之后我们会学习更好的数据容器
            int i = 1;
            array[0] = i;  //装箱
            i = (int)(array[0]??0); //拆箱
            #endregion
        }
    }
}
