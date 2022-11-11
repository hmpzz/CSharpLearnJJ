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

            #region 第二题

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