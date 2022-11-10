using System.Collections.Generic;

namespace Lesson08_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson08_Dictionary");

            #region 知识点一 Dictionary的本质
            //可以将Dictionary理解为 拥有泛型的Hashtable
            //它也是基于键的哈希代码组织起来的 键/值对
            //键值对类型从Hashtable的object变为了可以自己制定的泛型
            #endregion

            #region 知识点二 申明
            //需要引用System.Collections.Generic
            Dictionary<int,string> dictionary = new Dictionary<int,string>();

            #endregion

            #region 知识点三 增删查改

            #region 增
            //注意：不能出现相同的键
            dictionary.Add(1, "123");
            dictionary.Add(2, "123");
            dictionary.Add(3, "123");


            #endregion

            #region 删
            //1.只能通过键去删除
            //  删除不存在的键 没反应
            dictionary.Remove(2);

            //2.清空
            dictionary.Clear();
            dictionary.Add(1, "123");
            dictionary.Add(2, "223");
            dictionary.Add(3, "323");
            dictionary.Add(100, "10023");

            #endregion

            #region 查
            //1.通过键查看值
            //  找不到直接报错
            Console.WriteLine(dictionary[2]);

            //Console.WriteLine(dictionary[4]); //这句会报错，因为4找不到

            //2.查看是否存在
            //  根据键检测
            if (dictionary.ContainsKey(2))
            {
                Console.WriteLine("存在键值为2的项");
            }
            //  根据值检测
            if (dictionary.ContainsValue("323"))
            {
                Console.WriteLine("存在键值为323的项");
            }
            #endregion

            #region 改
            Console.WriteLine(dictionary[1]);
            dictionary[1] = "555";
            Console.WriteLine(dictionary[1]);
            #endregion

            #endregion

            #region 知识点四 遍历
            Console.WriteLine("*****************************");
            //1.遍历所有的键
            foreach (int item in dictionary.Keys)
            {
                Console.WriteLine(item);
            }
            
            //2.遍历所有值
            Console.WriteLine("*****************************");
            foreach (string item in dictionary.Values)
            {
                Console.WriteLine(item);
            }

            //3.键值对一起遍历
            Console.WriteLine("*****************************");
            foreach (KeyValuePair<int,string>  item in dictionary)
            {
                Console.WriteLine($@"Key:{item.Key}   Value:{item.Value}");
            }
            #endregion
        }
    }
}