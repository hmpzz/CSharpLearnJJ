using System.Collections;
using static Lesson06_练习.Program;

namespace Lesson06_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson06_练习");


            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();


            Test01 aa=Test01.Instance;

            Test01 bb = Test01.Instance;


            ArrayList<int> arrayList = new ArrayList<int>();

            arrayList.Add(10);
            arrayList.Add(15);

            Console.WriteLine( arrayList.IndexOf(15));

            arrayList.Remove(10);
            arrayList.Mod(0, 20);
        }



        /// <summary>
        /// 单例模式的实现
        /// </summary>
        public class Singleton
        {


            public int kk { get; set; }
            // 定义一个静态变量来保存类的实例
            private static Singleton uniqueInstance;

            // 定义一个标识确保线程同步
            private static readonly object locker = new object();

            // 定义私有构造函数，使外界不能创建该类实例
            private Singleton()
            {

                kk += 1;
            }

            /// <summary>
            /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
            /// </summary>
            /// <returns></returns>
            public static Singleton GetInstance()
            {
                // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
                // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
                // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
                // 双重锁定只需要一句判断就可以了
                if (uniqueInstance == null)
                {
                    lock (locker)
                    {
                        // 如果类的实例不存在则创建，否则直接返回
                        if (uniqueInstance == null)
                        {
                            uniqueInstance = new Singleton();
                        }
                    }
                }
                return uniqueInstance;
            }
        }

        public abstract class Singleton<T> where T :class, new()
        {
            private static T instance;
            protected Singleton() { }

            public static T Instance
            { 
                get 
                {
                    if (instance==null)
                    {
                        instance = new T();
                    }
                    return instance; 
                } 
            }

        }

        public class Test01 : Singleton<Test01>
        {
            public string test = "555";

        }

        public class Test02 : Singleton<Test02>
        {
            public int pp = 20;
        }



        public class ArrayList<T>
        {
            private ArrayList arrayList;
            public ArrayList()
            {
                arrayList = new ArrayList();
            }

            public void Add(T _value)
            { 
                arrayList.Add(_value);
            }


            public void Remove(T _value)
            { 
                arrayList.Remove(_value); 
                
            }

            public int IndexOf(T _value)
            {
                return arrayList.IndexOf(_value);
            }

            public void Mod(int _i,T _value)
            {
                arrayList[_i] = _value;
                
            }
        }
    }
}