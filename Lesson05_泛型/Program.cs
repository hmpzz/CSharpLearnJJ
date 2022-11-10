using System;

namespace Lesson05_泛型
{



    #region 知识点一 泛型是什么
    //泛型实现了类型参数化 达到了代码重用的目的
    //通过类型参数化来实现同一份代码上操作多种类型

    //泛型相当于类型占位符
    //定义类或方法时使用替代符代表变量类型
    //当真正使用类或者方法时再具体指定类型
    #endregion

    #region 知识点二 泛型分类
    //泛型类和泛型接口
    //基本语法：
    //class 类名<泛型占位字母>
    //interface 接口名<泛型占位字母>

    //泛型函数
    //基本语法：函数名<泛型点字母>(参数列表)

    //注意：泛型占位字母可以有多个，用逗号分开
    #endregion

    #region 知识点三 泛型类和接口
    class TestClass<T>
    {
        public T value { get; set; }
    }

    interface TestInterFace<T>
    { 
        T Value { get; set; }
    }

    class Test : TestInterFace<int>
    {
        public int Value { get; set ; }
    }
    #endregion

    #region 知识点四 泛型方法

    //1.普通类中的泛型方法
    class Test2
    {
        public void TestFun<T>(T value)
        { 
            Console.WriteLine(value);
        }

        public void TestFun<T>()
        { 
            //用泛型类型 在里面做一些逻辑处理
            T t=default(T);
        }

        public T TestFun<T>(string v)
        {
            return default(T);
        }

        public void TestFun<T,K,M>(T t,K k ,M m)
        {

        }
    }

    //2.泛型类中的泛型方法
    class Test2<T>
    { 
        public T value { get; set; }

        //这个不叫泛型方法 因为 T是泛型类申明的时候 就指定 在使用这个函数的时候我们不能再去动态的变化了
        public void TestFun(T value)
        { 
        }

        public void TestFun<K>(K value)
        {
            Console.WriteLine(value);
        }
    }

    #endregion 

    #region 知识点五 泛型的作用
    //1.不同类型对象的相同逻辑处理就可以选择泛型
    //2.使用泛型可以一定程序避免装箱拆箱
    //举例：优化ArrayList
    #endregion

    #region 总结

    #endregion


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson05_泛型");

            TestClass<int> t = new TestClass<int>();
            t.value = 10;
            Console.WriteLine(t.value);

            TestClass<string> t2 = new TestClass<string>();
            t2.value = "abcd";
            Console.WriteLine(t2.value);


            Test2 tt = new Test2();
            tt.TestFun<string>("fdsafdsa");

            Test2 tt0 = new Test2();
            tt.TestFun<int>(123);

            Test2<int> tt2 = new Test2<int>();
            tt2.TestFun(10);
            tt2.TestFun<int>(8);
            tt2.TestFun<string>("aaa");
            tt2.TestFun<float>(1.2f);
        }
    }
}