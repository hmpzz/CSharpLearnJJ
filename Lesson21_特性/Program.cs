﻿#define Fun

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Lesson21_特性
{

    #region 知识点一 特性是什么
    //特性是一种允许我们向程序的程序集添加元数据的语言结构
    //它是用于保存程序结构信息的某种特殊类型的类

    //特性提供功能强大的方法以将声明信息与C#代码(类型、方法、属性等)相关联。
    //特性与程序实体关联后，即可在运行时使用反射查询特性信息

    //特性的目的是告诉编译器把程序结构的某组元数据嵌入程序集中
    //它可以放置在几乎所有的声明中(类、变量、函数等等申明)

    //说人话：
    //特性本质是个类
    //我们可以利用特性类为元数据添加额外信息
    //比如一个类、成员变量、成员方法等等为他们添加更多的额外信息
    //之后可以通过反射来获取这些额外信息
    #endregion

    #region 知识点二 自定义特性
    //继承特性基类 Attribute
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    class MyCustomAttribute : Attribute
    {
        //特性中的成员，一般根据需求来写
        public string info;

        public MyCustomAttribute(string _info)        {
            info = _info;
        }


        public void TestFun()
        {
            Console.WriteLine("特性的方法");
        }
    }
    #endregion

    #region 知识点三 特性的使用
    //基本语法：
    //[特性名(参数列表)]
    //本质上 就是在调用特性类的构造函数
    //写在哪里？
    //类、函数、变量上一行，表示他们具有该特性信息

    [MyCustom("这个是一个我自己写的用于计算的类")]
    class MyClass
    {
        [MyCustom("这是一个成员变量")]
        public int value;

        //[MyCustom("这是一个用于计算加法的函数")]
        //public void TestFun([MyCustom("函数参数")] int a)
        //{

        //}
        public void TestFun(int a)
        {

        }

    }
    #endregion


    #region 知识点四 限制自定义特性的使用范围
    //通过为特性类加特性限制其使用范围
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    //参数一：Attribute Targets --  特性能够用在哪些地方（用位或连接）
    //参数二：AllowMultiple  -- 是否允许多个特性实例用在同一个目标上
    //参数三：Inherited -- 特性是否能被派生类和重写成员继承

    public class MyCustom2Attribute : Attribute
    {

    }

    #endregion

    #region 知识点五 系统自带特性--过时特性
    //过时特性
    //Obsolete
    //用于提示用户使用的方法等成员已经过时建议使用新方法
    //一般加在函数前的特性

    class TestClass
    {
        //参数一：调用过时方法时提示的内容
        //参数二：true-使用该方法时会报错 false-使用该方法时直接警告
        [Obsolete("OldSpeak已经过时了，请使用Speak方法！", false)]
        public void OldSpeak(string str)
        {
            Console.WriteLine(str);
        }

        public void Speak()
        {

        }

        public void SpeakCaller(string str, [CallerFilePath] string fileName = "", [CallerLineNumber] int line = 0, [CallerMemberName] string target = "")
        {
            Console.WriteLine($@"{str}");
            Console.WriteLine($@"{fileName}");
            Console.WriteLine($@"{line}");
            Console.WriteLine($@"{target}");
        }
    }
    #endregion

    #region 知识点六 系统自带特性--调用者信息特性
    //哪个文件调用？
    //CallerFilePath特性
    //哪一行调用？
    //CallerLineNumber特性
    //哪个函数调用?
    //CallerMemberName特性

    //需要引用命名空间 using System.Runtime.CompilerServices;
    //一般作为函数参数的特性

    #endregion

    #region 知识点七 系统自带特性--条件编译特性
    //条件编译特性
    //Conditional
    //它会和预处理指定 #define配合使用

    //需要引用命名空间 using System.Diagnostics;
    //主要可以用在一些调试代码上
    //有时想执行有时想不执行的代码
    #endregion

    #region 知识点八 系统自带特性--外部Dll包函数特性
    //DllImport

    //用来标记非.Net(C#)的函数，表明该函数在一个外部的DLL中定义，
    //一般用来调用C或者C++的DLL包写好的方法
    //需要引用命名空间 using System.Runtime.InteropServices

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            [DllImport("路径名")]
            static extern int Add(int a, int b); //表示这个函数是由于上面的DLL文件中提供的

            Console.WriteLine("Lesson21_特性");

            #region 特性的使用
            MyClass mc = new MyClass();

            //以下是三种获取type的方式
            Type t = mc.GetType();
            t = typeof(MyClass);
            t = Type.GetType("Lesson21_特性.MyClass");

            //判断是否使用了某个特性
            //参数一：代表特性的类型
            //参数二：代表是否搜索继承链（属性和事件忽略此参数）
            if (t.IsDefined(typeof(MyCustomAttribute), false))
            {
                Console.WriteLine($@"该类型用了MyCustom特性");
            }

            //获取Type元数据中的所有特性
            object[] array = t.GetCustomAttributes(true);

            foreach (object item in array)
            {
                if (item is MyCustomAttribute)
                {
                    Console.WriteLine((item as MyCustomAttribute).info);
                    (item as MyCustomAttribute).TestFun();
                }
            }

            TestClass tc = new TestClass();
            tc.OldSpeak("fdsa");
            Console.WriteLine("**************************");
            tc.SpeakCaller("123123123");
            Console.WriteLine("**************************");
            Fun();


            #endregion
        }

        //表示有#define定义Fun这样的符号才能使用
        [Conditional("Fun")]
        static void Fun()
        {
            Console.WriteLine("执行");
        }
    }
}