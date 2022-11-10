namespace Lesson06_泛型约束
{
    internal class Program
    {


        #region 知识点一 什么是泛型约束
        //让泛型的类型有一定的限制
        //关键字：where
        //泛型约束一共有6种                     
        //1.值类型                                 where 泛型字母:struct
        //2.引用类型                               where 泛型字母:class 
        //3.存在无参公共构造函数                   where 泛型字母:new()
        //4.某个类本身或者其派生类                 where 泛型字母:类名
        //5.某个接口的派生类                       where 泛型字母:接口名
        //6.另一个泛型类型本身或者派生类型         where 泛型字母:另一个泛型字母

        //where 泛型字母:(泛型的约束)
        #endregion

        #region 知识点二 各泛型约束讲解

        #region 值类型约束
        class Test1<T> where T:struct
        { 
            public T value { get; set; }

            public void TestFun<K>(K _value) where K:struct
            {

            }
        }
        #endregion

        #region 引用类型约束
        class Test2<T> where T : class
        { 
            public T value { get; set; }

            public void TestFun<K>(K k) where K : class 
            {

            }
        }
        #endregion

        #region 公共无参构造约束（值类型也能传）
        class Test3<T> where T:new ()
        {

            public T value { get; set; }

            public void TestFun<K>(K k) where K : class
            {

            }
        }

        class Test1
        { 
        }
        class Test2
        {
            public Test2(int k)
            { 

            }
        }
        #endregion

        #region 类约束
        class Test4<T> where T : Test1
        {

            public T value { get; set; }

            public void TestFun<K>(K k) where K : Test1
            {

            }
        }

        
        class Test3:Test1
        {
            
        }
        #endregion

        #region 接口约束
        interface IFly
        { 
        }

        class Test4 : IFly
        { }


        class Test5<T> where T : IFly
        {

            public T value { get; set; }

            public void TestFun<K>(K k) where K : IFly
            {

            }
        }

        #endregion

        #region 另一个泛型约束

        //要么T类型就是U，要么T就是继承U
        class Test6<T,U> where T : U
        {

            public T value { get; set; }

            public void TestFun<K,V>(K k) where K : V
            {

            }
        }
        #endregion

        #endregion

        #region 知识点三 泛型约束的组合使用
        class Test7<T> where T:class ,new()//如果用这种组合就不能传值类型了
        {

        }
        #endregion

        #region 知识点四 多个泛型有约束

        class Test8<T,K> where T:class,new() where K:struct
        {

        }

        #endregion

        #region 总结
        //泛型约束：让类型有一定限制
        //class
        //struct
        //new()
        //类名
        //接口名
        //另一个泛型字母

        //注意：
        //1.可以组合使用
        //2.多个泛型约束 用where连接即可
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Lesson06_泛型约束");

            //Test1<object> t0 = new Test1<object>();  //会报错，因为object不是值类型
            Test1<int> t1 = new Test1<int>();
            t1.TestFun<float>(1.2f);

            //Test1<int> t0 = new Test1<int>();   //会报错，因为int不是引用类型
            Test2<object> t2=new Test2<object>();
            t2.TestFun<Random>(new Random());


            //Test3<Test2> t0 = new Test3<Test2>();  //会报错，因为Test2没有公共无参构造函数
            Test3<Test1> t3 = new Test3<Test1>();


            //Test4<Test2> t0 = new Test4<Test2>();  //会报错
            Test4<Test1> t4 = new Test4<Test1>();
            Test4<Test3> t41 = new Test4<Test3>();


            Test5<Test4> t5 = new Test5<Test4>();
            Test5<IFly> t51 = new Test5<IFly>();
            t51.value = new Test4();



            Test6<Test4, IFly> t6 = new Test6<Test4, IFly>();


        }
    }
}