namespace Lesson15_lambda表达式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("lambda表达式");

            #region 知识点一 什么是lambda表达式 
            //可以将lamb ad表达式理解为匿名函数的简写 
            //它除了写法不同外 
            //使用上和匿名函数一模一样 
            //都是和委托或者事件配合侧用的
            #endregion

            #region 知识点二  lambda表达式语法
            //匿名函数
            //delegate(参数列表)
            //{
            //}；

            //lambda表达式
            //(参数列表)=>
            //{
            ////函数体
            //}；
            #endregion

            #region 知识点三 使用
            //1.无参无返回
            Action a = () => { Console.WriteLine("无参无返回的lambda表达式"); };
            a();

            //2.有参
            Action<int> b = (int value) => { Console.WriteLine($@"有参数无返回值的lambda表达式，参数为:{value}"); };
            b(100);

            //3.甚至参数类型都可以省略参数类型和委托或事件容器一致
            Action<int> c = (value) => { Console.WriteLine($@"省略参数无返回值的lambda表达式，参数为:{value}"); };
            c(200);

            //4.有返回值
            Func<string, int> d = (value) => { Console.WriteLine($@"有参数有返回值的lambda表达式，参数为:{value}"); return 1; };
            Console.WriteLine(d("aa"));

            Console.WriteLine( () => { Console.WriteLine("abcde"); return 123; });


            //其它传参使用等和匿名函数一样
            //缺点也是和匿名函数一样的
            #endregion


            Test test = new Test();
            test.Dosomething();



            
        


        }
    }

    #region 知识点四 闭包
    //内层的函数可以引用包含在它外层的函数的变量
    //即使外层函数的执行已经终止
    //注意：
    //该变量提供的值井非变量创建时的值，而是在父函数范围内的最终值。

    class Test
    {
        public  Action   action;
        public Test()
        {
            int value = 100;
            //这里就形成了闭包
            //因为当构造函数执行完毕时，其中声明的临时变量value的生命周期被改变了
            action = () => 
            { 
                Console.WriteLine(value); 
            };

            for (int i = 0; i < 10; i++)
            {

                int index = i;  //因为这个index 在每次循环中都会被重定义，所以index在匿名函数中就会次次改变
                action += () =>
                {
                    Console.WriteLine($@"这个i全是10：{i}");
                    Console.WriteLine($@"这个index不会全是10：{index}");
                };
            }
        }

        public void Dosomething()
        {
            action();
        }
    }
    #endregion

 


    //总结
    //匿名函数的特殊写法 就是lambda表达式
    //因为写法就是 (参数列表)=>{}
    //参数列表可以直接省略参数类型
    //主要在 委托传递和存储时 为了方便可以直接使用匿名函数或者lambda表达式
    //缺点：无法指定移除
}