using System.Collections;

namespace Lesson02_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson02_练习");


            byte[] aa = new byte[] { 0b10010101 };
            Stack stack = new Stack();

            int bb = 0;
            int c = 1;

            for (int i = 0; i < aa.Length; i++)
            {
                stack.Push(aa[i]);
            }

            while (stack.Count>0)
            {
                bb += Convert.ToInt16(stack.Pop());
                c = c * 2;
            }
            Console.WriteLine(bb);


        }
    }
}