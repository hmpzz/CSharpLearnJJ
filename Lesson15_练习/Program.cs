using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lesson15_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson15_练习");

            #region 练习题

            
            Func<Action> func = () => { return () => { Console.WriteLine("123"); }; };

            func()();


            Func<int, Func<int, int, string>> func01 = (value) =>
            {
                value *= 2;
                return (value01, value02) =>
                {
                    return $@"变量值：{value * value01 * value02}";
                };
            };

            Console.WriteLine(func01(6)(12, 10));

            #endregion

            #region 自己的测试

            

            List<Test> testList  = new List<Test>();

            testList.Add(new Test { Name = "a", Age = 10 });
            testList.Add(new Test { Name = "b", Age = 10 });
            testList.Add(new Test { Name = "c", Age = 20 });
            testList.Add(new Test { Name = "d", Age = 15 });
            testList.Add(new Test { Name = "e", Age = 30 });

            List<Test> test2= testList.Ppp<Test>(a => a.Age <= 10).ToList();

            //Test.QQQ(testList, a => a.Age >= 10);

            Func<Test, bool> aa = (_value) =>
            {
                return _value.Age <= 10;                
            };

            Func<Test, bool> bb = a => { return a.Age <= 10; };
            Func<Test, bool> cc = a =>  a.Age <= 10 ;

            III(testList, (Test) => { return Test.Age <= 10; });


            Func<Test, int, bool> aa01 = (a, b) => { return a.Age <= b; };
            Func<Test, int, bool> bb01 = (a, b) =>  a.Age <= b;

            bb01(new Test { Name = "b", Age = 10 }, 20);

            III01(testList, 10,(Test,_value) => { return Test.Age <= _value; });

            #endregion

        }

        public static List<Test> III(List<Test> sources, Func<Test, bool> predicate)
        {
            List<Test> testTemp = new List<Test>();

            foreach (Test testItem in sources)
            {
                if( predicate(testItem))
                {
                    testTemp.Add(testItem);
                }
            }

            return testTemp;
        }


        public static List<Test> III01(List<Test> sources,int _value, Func<Test,int, bool> predicate)
        {
            List<Test> testTemp = new List<Test>();

            foreach (Test testItem in sources)
            {
                if (predicate(testItem,_value))
                {
                    testTemp.Add(testItem);
                }
            }

            return testTemp;
        }

    }


    class Test
    {
        public string Name { get; set; }
        public int Age { get; set; }


        //public static IEnumerable<TSource> QQQ<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        //{ 


        //    //return source.Where(predicate);
        //}
    }




}