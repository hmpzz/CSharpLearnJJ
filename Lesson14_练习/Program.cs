namespace Lesson14_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson14_练习");
            Test(10)("100");

            Console.WriteLine( Test2(10)
                (12));
        }

        public static Action<string> Test(int a)
        {

            return delegate (string b) { Console.WriteLine($@"{a}+{b}"); };
        }


        public static Func<int, int> Test2(int a)
        {
            Console.WriteLine("进入第一层");
            return delegate (int b) { Console.WriteLine("返回函数后，再次计算"); return a * b; };
        }

    }


}