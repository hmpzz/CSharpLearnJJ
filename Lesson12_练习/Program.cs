namespace Lesson12_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson12_练习");

            #region 第一题

            Action action = null;
            action += Cook;
            action += Finished;

            Action<string> action1 = null;

            action1 += Eat;

            action();
            action1("妈妈");
            action1("爸爸");
            action1("儿子");
            #endregion

            #region 第一题第二个思路
            Console.WriteLine("********************************");

            Mom mom = new Mom();
            Person person01 = new Person("爸爸");
            Person person02 = new Person("儿子");


            mom.Cook();
            mom.CallName += person01.Answer;
            mom.CallName += person02.Answer;
            

            mom.CallName();
            #endregion

            #region 第二题
            Console.WriteLine("********************************");
            Player player01 = new Player();

            Monster monster01 = new Monster();
            monster01.Dead(player01.AddMoney);

            Monster monster02 = new Monster();
            monster02.Dead(player01.AddMoney);
            #endregion
        }

        #region 第一题


        public static void Cook()
        {
            Console.WriteLine("妈妈做饭");
        }

        public static void Finished()
        {
            Console.WriteLine("做完饭了！");

        }

        public static void Eat(string _Person)
        {
            Console.WriteLine($@"{_Person}吃饭！");
        }
        #endregion

        #region 第一题第二个思路
        class Mom
        {

            public Mom()
            {
                CallName = Reply;
            }
            public void Cook()
            {
                Console.WriteLine($@"妈妈做饭");
                Console.WriteLine($@"妈妈炒菜");
            }
            public void Reply()
            {
                Console.WriteLine($@"妈妈说：我做完就来吃饭！");
            }

            public Action CallName;
            
        }

        class Person
        {
            public string Name { get; set; }

            public Person(string _name)
            {
                Name = _name;
            }

            public void Answer()
            {
                Console.WriteLine($@"{Name}说：我马上来吃饭！");
            }
        }
            
        #endregion

        #region 第二题
        class Player
        {
            static int Money { get; set; }

            public Player()
            {
                Money = 0;
            }

            public void AddMoney()
            {
                Money += 10;
                Console.WriteLine($@"现有金钱{Money}!");
            }

        }

        class Monster
        {
            public void Dead(Action action)
            { 
                action();
            }
        }
        #endregion
    }
}