using System.Reflection;

namespace Lesson20_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson20_练习");

            Assembly assembly = Assembly.LoadFrom($@"C:\Users\Administrator\source\repos\CSharp进阶教学\类库测试\bin\Debug\类库测试.dll");
            Type[] types = assembly.GetTypes();

            foreach (Type item in types)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("************************************");


            Type Player = assembly.GetType("类库测试.Player");
            MemberInfo[] members = Player.GetMembers();
            foreach (MemberInfo item in members)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("************************************");


            object playerObj=Activator.CreateInstance(Player );



        }
    }
}