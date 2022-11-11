namespace Lesson12_委托
{
    internal class Program
    {

        #region 知识点一 委托是什么
        //委托是函数(方法)的容器
        ///可以理解为表示函数(方法)的变量类型 
        //用来 存储、传递函数(方法) 
        //委托的本质是一个类，用来定义函数(方法)的类型(返回值和参数的类型) 
        //不同的函数(方法)必须对应和各自"格式"一致的委托 
        #endregion

        #region 知识点二 基本语法
        //关键字： delegate
        //语法：访问修饰符 delegate 返回值 委托名(参数列表) ；

        //写在哪里?
        //可以申明在namespace和class语句块中
        //更多的写在namespace中
        //简单记忆委托语法就是函数申明语法前面加一个delegate关键字


        #endregion

        #region 知识点三 定义自定义委托
        //访问修饰默认不写为public在别的命名空间中也能使用
        //private其它命名空间就不能用了
        //一般使用public

        //申请了一个可以用来存储无参无返回值函数的容器 
        //这里只是定义了规则 并没有使用
        delegate void MyFun();

        //委托规则的申明 是不能第一名（在同一语句块中）
        //表示用来装载或传递 返回值为int 有一个int参数的函数的 委托 容器规则
        delegate int MyFun2(int a);

        //委托是支持泛型的 可以让返回值和参数可变，更方便我们的使用
        delegate T MyFun3<out T,in K>(K k);
        #endregion

        #region 知识点四 使用定义好的委托
        //委托变量是函数的容器！！！

        //委托常用在：
        //1.作为类的成员
        //2.作为函数的参数

        class Test
        {
            public MyFun fun { get; set; }
            public MyFun2 fun2 { get; set; }

            public Action action { get; set; }

            public void TestFun(MyFun fun, MyFun2 fun2)
            {
                //先处理一些别的逻辑 当这些逻辑处理完了再执行传入的函数
                int i = 1;
                i *= 2;
                i += 2;

                //fun();
                //fun2(i);

                this.fun = fun;
                this.fun2 = fun2;
            }

            public void AddFun(MyFun fun, MyFun2 fun2)
            {
                this.fun += fun;
                this.fun2 = fun2;
            }

            public void RemoveFun(MyFun fun, MyFun2 fun2)
            {
                this.fun -= fun;
                this.fun2 -= fun2;
            }
        }
        #endregion

        #region 知识点五 委托变量可以存储多个函数(多播委托)

        #region 增

        #endregion

        #region 删

        #endregion

        #endregion

    

        static void Main(string[] args)
        {
            Console.WriteLine("Lesson12_委托");
            //专门用来装载 函数的 容器
            MyFun f = new MyFun(Fun);
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("4");
            Console.WriteLine("5");

            f.Invoke();//调用方式1 invoke()


            //Fun只写函数名，而不要写括号
            MyFun f2 = Fun;
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("4");
            Console.WriteLine("5");
            f2();   //调用方式2 直接写 委托名(); 像函数一样调用

            Console.WriteLine("******************************");

            MyFun2 f3 = Fun2;
            Console.WriteLine(f3.Invoke(123));
            Console.WriteLine(f3(456));

            Console.WriteLine("******************************");

            Test t = new Test();

            t.TestFun(Fun, Fun2);

            Console.WriteLine("******************************");

            //如何用委托存储多个函数
            MyFun ff = null;
            ff += Fun;
            ff += Fun3;

            ff();
            //从容器中移除指定的函数
            ff -= Fun;
            ff();

            //清空容器
            ff = null;

            if (ff!=null)
            {
                ff();
            }

            Console.WriteLine("******************************");

            t.AddFun(Fun, Fun2);
            t.fun();
            t.fun2(2);


            #region 知识点六 系统定义好的委托
            //系统定义好的委托
            //系统提供的 无参 无返回值 委托
            Action action = Fun;
            action += Fun3;
            action();

            //系统提供的 无参 有返回值 委托
            Func<string> funString = Fun4;
            Func<int> funInt = Fun5;

            //系统提供的 有参（n个参数） 无返回值  1到16个参数
            Action<int,string> funAction = Fun6;

            //系统提供的 有参（n个参数） 无返回值  1到16个参数
            Func<int,string,string> funAction2 = Fun7;


            funAction2(10, "");
            #endregion
        }

        static void Fun()
        {
            Console.WriteLine("张三做什么");
        }

        static int Fun2(int value)
        {
            return value;
        }

        static void Fun3()
        {
            Console.WriteLine("李四做什么");
        }

        static string Fun4()
        {
            return "";
        }

        static int Fun5()
        {
            return 5;
        }

        static void Fun6(int value,string s)
        {
            
        }

        static string Fun7(int value, string s)
        {
            return "";
        }

    }

    //总结 
    //简单理解委托就是装载、传递函数的容器而已 
    //可以用委托变量来存储函数或者传递函数的 
    //系统其实已经提供了很多委托给我们用 
    
    //Action：没有返回值， 参数提供了0~16个委托给我们用 
    //Func：有返回值， 参数提供了0~16个委托给我们用

}