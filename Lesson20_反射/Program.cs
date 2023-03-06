using System.Reflection;

namespace Lesson20_反射
{

    #region 知识点一 什么是程序集
    //程序集是经由编译器编译得到的，供进一步编译执行的那个中间产物
    //在WINDOWS系统中， 它一般表现为后缀为.dll(库文件) 或者是：.exe(可执行文件) 的格式

    //说人话：
    //程序集就是我们写的一个代码集合，我们现在写的所有代码
    //最终都会被编译器翻译为一个程序集供别人使用
    //比如一个代码库文件(dll) 或者一个可执行文件(exe)
    #endregion

    #region 知识点二 元数据
    //元数据就是用来描述数据的数据
    //这个概念不仅仅用于程序上，在别的领域也有元数据

    //说人话：
    //程序中的类，类中的函数、变量等等信息就是程序的元数据
    //有关程序以及类型的数据被称为元数据，它们保存在程序集中
    #endregion

    #region 知识点三 反射的概念
    //程序正在运行时，可以查看其它程序集或者自身的元数据。
    //一个运行的程序查看本身或者其它程序的元数据的行为就叫做反射

    //说人话：
    //在程序运行时，通过反射可以得到其它程序集或者自己程序集代码的各种信息
    //类，函数，变量，对象等等，实例化它们，执行它们，操作它们
    #endregion

    #region 知识点四 反射的作用
    //因为反射可以在程序编译后获得信息，所以它提高了程序的拓展性和灵活性
    //1.程序运行时得到所有元数据，包括元数据的特性
    //2.程序运行时，实例化对象，操作对象
    //3.程序运行时创建新对象，用这些对象执行任务
    #endregion


    class Test
    {
        private int i = 1;

        public int j = 0;

        public string str = "123";

        public Test()
        {

        }

        public Test(int _i)
        {
            i = _i;
        }

        public Test(int _i, string _str) : this(_i)
        {
            str = _str;
        }

        public void Speak()
        {
            Console.WriteLine(i);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson20_反射");

            #region 知识点五 语法相关

            #region Type
            //Type (类的信息类)
            //它是反射功能的基础!
            //它是访问元数据的主要方式。
            //使用 Type 的成员获取有关类型声明的信息
            //有关类型的成员 (如构造函数、方法、字段、属性和类的事件)

            #region 获取Type
            //1.万物之父object中的GetType() 可以获取对象的Type
            int a = 42;
            Type type = a.GetType();
            Console.WriteLine(type);

            //2.通过type of关键字传入类名也可以得到对象的Type
            Type type2 = typeof(int);
            Console.WriteLine(type2);

            //3.通过类的名字也可以获取类型
            //注意类名必须包含命名空间不然找不到
            Type? type3 = Type.GetType("Int32");//这句啥也没有
            type3 = Type.GetType("System.Int32");
            Console.WriteLine(type3);

            #endregion

            #region 得到类的程序集信息
            //可以通过Type可以得到类型所在程序集信息
            Console.WriteLine(type.Assembly);

            #endregion

            #region 获取类中的所有公共成员
            //首先得到Type
            Type t = typeof(Test);

            //然后得到所有公共成员
            //需要引用命名空间 using System.Reflection;
            MemberInfo[] infos = t.GetMembers();
            foreach (MemberInfo item in infos)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("************************************");
            #endregion

            #region 获取类的公共构造函数并调用
            //1.获取所有构造函数
            ConstructorInfo[] ctors = t.GetConstructors();
            foreach (ConstructorInfo item in ctors)
            {
                Console.WriteLine(item);
            }



            //2.获取其中一个构造函数并执行
            //得构造函数传入Type数组数组中内容按顺序是参数类型
            //执行构造函数传入object数组表示按顺序传入的参数
            //2 - 1得到无参构造
            ConstructorInfo? info = t.GetConstructor(new Type[0]);
            Test? obj = info?.Invoke(null) as Test;  //执行无参构造 没有参数传null即可

            Console.WriteLine(obj?.j);

            //2 - 2得到有参构造
            ConstructorInfo? info2 = t.GetConstructor(new Type[] { typeof(int) }); //取到一个int参数的构造函数
            obj = info2?.Invoke(new object[] { 2 }) as Test;
            Console.WriteLine(obj?.str);


            ConstructorInfo? info3 = t.GetConstructor(new Type[] { typeof(int), typeof(string) }); //取到两个参数 （int，string)的构造函数
            obj = info3?.Invoke(new Object[] { 2, "aa" }) as Test;
            Console.WriteLine(obj?.str);


            Console.WriteLine("************************************");
            #endregion

            #region 获取类的公共成员变量
            //1.得到所有成员变量
            FieldInfo[] fieldInfos = t.GetFields();
            foreach (FieldInfo item in fieldInfos)
            {
                Console.WriteLine(item);
            }

            //2.得到指定名称的公共成员变量
            FieldInfo? infoj = t.GetField("j");
            Console.WriteLine(infoj);

            //3.通过反射获取和设置对象的值
            Test test = new Test();
            test.j = 99;
            test.str = "2222";

            //3 - 1通过反射获取对象的某个变量的值
            Console.WriteLine(infoj?.GetValue(test));
            //3 - 2通过反射设置指定对象的某个变量的值
            infoj?.SetValue(test, 100);
            Console.WriteLine(infoj?.GetValue(test));

            Console.WriteLine("************************************");
            #endregion

            #region 获取类的公共成员方法
            //通过Type类中的Get Method方法得到类中的方法
            //Method Info是方法的反射信息

            Type strType = typeof(string);
            //1.如果存在方法重载用Type数组表示参数类型
            MethodInfo[] methods = strType.GetMethods();
            foreach (MethodInfo item in methods)
            {
                Console.WriteLine(item);
            }
            MethodInfo? method = strType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
            Console.WriteLine("************************************");

            //2.调用该方法
            //注意：如果是静态方法Invoke中的第一个参数传null即可
            string str = "Hello,World!";
            object? result = method?.Invoke(str, new object[] { 6, 5 });//第一个参数相当于哪个对象要执行这个成员方法

            Console.WriteLine(result);
            Console.WriteLine("************************************");

            #endregion

            #region 其他
            //Type；
            //得枚举
            //GetEnumName
            //GetEnumNames

            //得事件
            //GetEvent
            //GetEvents

            //得接口
            //GetInterface
            //GetInterfaces

            //得属性
            //GetProperty
            //GetPropertys

            //等等
            #endregion

            #endregion

            #region Assembly
            //用于快速实例化对象的类
            //用于将Type对象快捷实例化为对象
            //先得到Type
            Type testType = typeof(Test);
            //然后快速实例化一个对象
            //1.无参构造
            Test? testObj = Activator.CreateInstance(testType) as Test;
            Console.WriteLine(testObj?.str);

            //2.有参数构造
            testObj = Activator.CreateInstance(testType, 99, "sss") as Test;//这里用CreateInstance那个带变长参数的重载
            Console.WriteLine(testObj?.str);
            Console.WriteLine("************************************");

           

            #endregion

            #region Activator
            //程序集类
            //主要用来加载其它程序集，加载后
            //才能用Type来使用其它程序集中的信息
            //如果想要使用不是自己程序集中的内容 需要先加载程序集
            //比如dll文件(库文件)
            //简单的把库文件看成一种代码仓库，它提供给使用者一些可以直接拿来用的变量、函数或类

            //三种加载程序集的函数
            //一般用来加载在同一文件下的其它程序集
            //Assembly asembly2=Assembly.Load("程序集名称")；

            //一般用来加载不在同一文件下的其它程序集
            //Assembly asembly=Assembly.LoadFrom ("包含程序集清单的文件的名称或路径")；
            //Assembly asembly3=Assembly.LoadFile ("要加载的文件的完全限定路径")；

            //1.先加载一个指定程序集
            Assembly assembly = Assembly.LoadFrom(@"C:\Users\Administrator\source\repos\hmpzz\CSharpLearnJJ\Lesson16_练习\obj\Debug\net6.0\Lesson16_练习.dll");
            Type[] types = assembly.GetTypes();

            foreach (Type item in types)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("************************************");

            //2.再加载程序集中的一个类对象 之后才能使用反射
            Type? aa = assembly.GetType("Lesson16_练习.Program+TestClass");
            MemberInfo[]? members =  aa?.GetMembers();

         

            foreach (MemberInfo item in members ?? new MemberInfo[0])
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("************************************");

            //通过反射 实例化一个 aa对象
            //首先得到枚举Type 来得到可以传入的参数
            Type? bb = assembly.GetType("Lesson16_练习.Program+TestEnum");

            FieldInfo? right = bb?.GetField("a");
            //直接实例化对象
            object? aaObj= Activator.CreateInstance(aa ??  typeof(Assembly), 10, right?.GetValue(null));

            //得到对象中的方法 通过反射
            MethodInfo? methodC = aa?.GetMethod("c");
            methodC?.Invoke(aaObj,new object[] { 15,25});


            //3.类库工程创建
            #endregion

            #endregion
        }
    }

    //总结
    //反射
    //在程序运行时，通过反射可以得到其他程序集或者自己的程序集代码的各种信息
    //类、函数、变量、对象等等，实例化他们，执行他们，操作他们

    //关键类
    //Type
    //Assembly
    //Activator

    //对于我们的意义
    //在初中级阶段基本不会使用反射
    //所以目前对于大家来说，了解反射可以做什么就行
    //很长时间内都不会用到反射相关知识点

    //为什么要学反射
    //为了之后学习Unity引擎的基本工作原理做铺垫
    //Unity引起的基本工作机制就是建立在反射的基础上


}