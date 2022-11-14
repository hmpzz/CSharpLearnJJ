namespace Lesson18_多线程
{
    internal class Program
    {
        static bool isRuning = true;
        static object obj = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson18_多线程");

            #region 知识点一 了解线程前先了解进程
            //进程(Process) 是计算机中的程序关于某数据集合上的一次运行活动
            //是系统进行资源分配和调度的基本单位，是操作系统结构的基础
            //说人话：打开一个应用程序就是在操作系统上开启了一个进程
            //进程之间可以相互独立运行，互不干扰
            //进程之间也可以相互访问、操作
            #endregion

            #region 知识点二 什么是线程
            //操作系统能够进行运算调度的最小单位。
            //它被包含在进程之中，是进程中的实际运作单位
            //一条线程指的是进程中一个单一顺序的控制流，一个进程中可以并发多个线程
            //我们目前写的程序都在主线程中
            //简单理解线程：
            //就是代码从上到下运行的一条“管道”
            #endregion

            #region 知识点三 什么是多线程
            //我们可以通过代码开启新的线程
            //可以同时运行代码的多条“管道”就叫多线程
            #endregion

            #region 知识点四 语法相关
            //线程类Thread

            //需要引用命名空间using System.Threading；
            //1.申明一个新的线程
            //注意线程执行的代码需要封装到一个函数中
            //新线程要执行的代码逻辑 被封装 到了一个函数语句块
            Thread t = new Thread(NewThreadLogic);

            //2.启动线程
            t.Start();

            //3.设置为后台线程
            //当前台线程都结束了的时候，整个程序也就结束了，即使还有后台线程正在运行
            //后台线程不会防止应用程序的进程被终止掉
            //如果不设置为后台线程可能导致进程无法正常关闭
            t.IsBackground = true;

            //4.关闭释放一个线程
            //如果开启的线程中不是死循环是能够结束的逻辑那么不用刻意的去关闭它
            //如果是死循环想要中止这个线程有两种方式
            //4.1-死循环中bool标识
            //Console.ReadKey();
            //isRuning = false;
            //Console.ReadKey();

            //4.2-通过线程提供的方法(注意在.Netcore版本中无法中止会报错)
            //t.Abort();
            //t = null;


            //5.线程休眠
            //Thread.Sleep(1000);
            #endregion

            #region 知识点五 线程之间共享数据
            //多个线程使用的内存是共享的，都属于该应用程序(进程)
            //所以要注意 当多线程 同时操作同一片内存区域时可能会出问题
            //可以通过加锁的形式避免问题

            //lock
            //当我们在多个线程当中想要访问同样的东西 进行逻辑处理时
            //为了避免不必要的逻辑顺序执行的差错
            //lock(引用类型对象)
            while (true)
            {
                lock (obj)  //这个对象可以是随便一个引用对象，使用lock就是判断那个引用对象（obj）是不是被别人锁了，如果没有那么我锁，我用，如果锁了我就等别人用完了再用
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("国");
                }
            }

            #endregion

            #region 知识点六 多线程对于我们的意义
            //可以用多线程专门处理一些复杂耗时的逻辑
            //比如 寻路、网络通信等
            #endregion

            Console.WriteLine("主线程完成！");
        }

        static void NewThreadLogic()
        {
            //新开线程执行的代码逻辑 在该函数语句块中

            while (isRuning)
            {
                lock (obj)
                {
                    //Thread.Sleep(1000);
                    //Console.WriteLine("这是一个新开线程代码逻辑！");
                    Console.SetCursorPosition(10, 5);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("一");
                }
            }

        }
    }
}