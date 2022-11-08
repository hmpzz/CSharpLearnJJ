using System.Collections;

namespace Lesson03_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson03_练习");

            Queue queue = new Queue();
            queue.Enqueue("01");
            queue.Enqueue("02");
            queue.Enqueue("03");
            queue.Enqueue("04");
            queue.Enqueue("05");
            queue.Enqueue("06");


            foreach (object item in queue)
            {
                Console.WriteLine(item);
                Thread.Sleep(2000);
            }
        }
    }
}