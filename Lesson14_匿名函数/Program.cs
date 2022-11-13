namespace Lesson14_匿名函数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson14_匿名函数");


            #region 知识点一什么 是匿名函数
            //顾名思义，就是没有名字的函数
            //匿名函数的使用主要是配合委托和事件进行使用
            //脱离委托和事件是不会使用匿名函数的
            #endregion

            #region 知识点二  基本语法
            //delegate (参数列表)
            //{
            //    //函数逻辑
            //};

            //何时使用?
            //1.函数中传递委托参数时
            //2.委托或事件赋值时
            #endregion

            #region 知识点三 使用
            //1.无参无返回
            //这样申明匿名函数 只是在申明函数而已还没有调用
            //真正调用它的时候 是这个委托窗口啥时调用 就什么时候调用这个匿名函数
            Action a = delegate ()
            {
                Console.WriteLine("匿名函数逻辑");
            };

            a();

            //2.有参
            Action<int, string> b = delegate (int a, string b)
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
            };

            b(100, "123");

            //3.有返回值
            Func<int, string, string> c = delegate (int a, string b)
            {
                return $@"{a}+{b}";
            };

            Console.WriteLine( c(123,"aaa"));

            //4.一般情况会作为函数参数传递或者作为函数返回值
            //参数传递
            Test t = new Test();

            t.Dosomething(100, delegate () { Console.WriteLine("做为参数传入的函数逻辑"); });

            //返回值
            Action action = t.GetFun();
            action();
            //一步到位，直接调用返回的函数
            t.GetFun()();

            t.GetFun("aaa")("bbb");
            #endregion

            #region 知识点四 匿名函数的缺点
            //添加到委托或事件容器中后 不记录 无法单独移除

            Action ac3 = delegate () { Console.WriteLine("匿名函数一"); };
            ac3 += delegate () { Console.WriteLine("匿名函数二"); };

            ac3();
            #endregion




        }
    }
    class Test
    {
        public Action action;

        //public delegate void AAA();   //与上面的Action一样


        //fun做为参数传递时
        public void Dosomething(int a, Action fun)
        {
            Console.WriteLine(a);
            fun();
        }

        //作为返回值
        public Action GetFun()
        {
            return delegate () { Console.WriteLine("函数内部返回的一个匿名函数逻辑"); };
        }

        public Action<string> GetFun(string _value)
        {
            return delegate (string _ss) { Console.WriteLine($@"{_value},{_ss}"); };
        }
    }

    //总结
    //匿名函数就是没有名字的函数
    //固定写法
    //delegate (参数列表){}
    //主要是在委托传递和存储时 为了方便可以直接使用匿名函数
    //缺点是 没有办法指定移除


}