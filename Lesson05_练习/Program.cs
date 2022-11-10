namespace Lesson05_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson05_练习");

            TestType<int>(10);
            TestType<float>(20f);
            TestType<string>("123");
            TestType<char>('5');
        }


        public static void TestType<T>(T value)
        {
            if (typeof(T)==typeof   (int))
            {
                Console.WriteLine("int");
         
            }
            else if (typeof(T) == typeof(char))
            {
                Console.WriteLine("char");
            }
            else if (typeof(T) == typeof(float))
            {
                Console.WriteLine("float");
            }
            else if (typeof(T) == typeof(string))
            {
                Console.WriteLine("string");
            }


        }
    }
}