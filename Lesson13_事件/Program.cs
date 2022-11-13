namespace Lesson13_事件
{
    #region 知识点一 事件是什么
    //事什是基于委托的存在
    //事件是委托的安全包裹
    //让委托的使用更具有安全性
    //事件是一种特殊的变量类型
    #endregion

    #region 知识点二 事件的使用
    //申明语法：
    //访问修饰符 event  委托类型 事件名；
    //事件的使用;

    //1.事件是作为成员变量存在于类中
    //2.委托怎么用事件就怎么用
    //事件相对于委托的区别：
    //1.不能在类外部赋值
    //2.不能再类外部调用
    //注意：
    //它只能作为成员存在于类和接口以及结构体中
    #endregion

    #region 知识点三 为什么有事件
    //1.防止外部随意置空委托
    //2.防止外部随意调用委托
    //3.事件相当于对委托进行了一次封装让其更加安全
    #endregion



    class Test
    {
        //委托成员变量 用于存储 函数的
        public Action myFun = null;

        //事件成员变量
        public event Action myEvent = null;

        public Test()
        {
            //事件的使用与委托 几乎一模一样 只是有些细微的区别
            myFun += TestFun;

            myEvent += TestFun;

            myFun();
            myEvent();
        }

        public void DoEvent()
        {
            myEvent();
        }
        public void TestFun()
        {
            Console.WriteLine(123);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson13_事件");

            Test t = new Test();
            //委托可以在外部赋值
            t.myFun = null;
            t.myFun += TestFun1;

            t.myFun = t.myFun + TestFun1;

            //事件是不能在外部赋值
            //虽然不能直接赋值 但可以 加减 去添加移除记录的函数
            //t.myEvent = TestFun1;    //这句报错，不能这么用
            t.myEvent += TestFun1;
            

            //委托是可以在外部调用
            t.myFun();

            //事件不能在外部调用
            //t.myEvent();
            //只能在类的内部去封装 调用
            t.DoEvent();


            Action a = TestFun1;
            //event Action ae=TestFun1;   //事件只能作为成员 存在于 类和接口以及结构体中
        }



        static void TestFun1()
        {
            Console.WriteLine("TestFun1");
        }

        //总结
        //事件和委托的区别
        //事件和委托基本是一模一样的
        //事件就是特殊的委托
        //主要区别：
        //1.事件不能在外部使用赋值 =符号 只能用+= -= 委托哪里都能用
        //2.事件 不能在外部执行 委托哪里都能执行
        //3.事件 不能作为 函数中的临时变量 委托可以
    }
}