namespace Lesson07_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson07_List");

            #region 知识点一 List的本质
            //Lis是一个C#为我们封闭好的类，
            //它的本质是一个可变类型的泛型数组
            //List类帮助我们实现了很多方法
            //比如泛型数组的增删查改
            #endregion

            #region 知识点二 申明
            //需要引用命名空间
            //using System.Collections.Generic
            List<int> list=new List<int>();

            #endregion

            #region 知识点三 增删查改

            #region 增
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);


            list.Insert(0, 999);
            #endregion

            #region 删
            //1.移除指定元素
            list.Remove(1);
            //2.移除指定位置的元素
            list.RemoveAt(0);
            //3.清空
            list.Clear();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            #endregion

            #region 查
            //1.得到指定位置的元素
            Console.WriteLine(list[0]);

            //2.查看元素是否存在
            if (list.Contains(1))
            {
                Console.WriteLine("找到");
            }
            else
            {
                Console.WriteLine("没找到");
            }


            //3.正向查找元素位置
            //找到返回位置，找不到返回-1
            Console.WriteLine(list.IndexOf(3));

            //4.反向查找元素位置
            //找到返回位置，找不到返回-1
            Console.WriteLine(list.LastIndexOf(3));
            #endregion

            #region 改
            Console.WriteLine(list[0]);
            list[0] = 10;
            Console.WriteLine(list[0]);
            #endregion


            #endregion

            #region 知识点四 遍历
            //长度
            Console.WriteLine(list.Count);

            //容量
            //避免产生垃圾
            Console.WriteLine(list.Capacity);
            Console.WriteLine("****************************");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("****************************");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            #endregion
        }
    }
}