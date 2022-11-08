using System.Collections;

namespace Lesson04_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson04_练习");
            Monster monster = new Monster();
            monster.AddMonster(1, "a");
            monster.AddMonster(2, "b");
            monster.AddMonster(3, "c");

            monster.RemoveMonster(2);

            monster.GetAllMonster();
        }
    }

    class Monster
    {
        private Hashtable hashtable = new Hashtable();


        public void AddMonster(object _key, object _value)
        { 
            hashtable.Add(_key, _value);
        }

        public void RemoveMonster(object _key) 
        {
            hashtable.Remove(_key);
        }

        public void GetAllMonster()
        {
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine($@"键:{item.Key,-8}----  值：{item.Value}");
            }
        }

    }
}