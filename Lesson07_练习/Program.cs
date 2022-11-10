namespace Lesson07_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson07_练习");


       
        Boss boss01 = new Boss();
        Boss boss02 = new Boss();
        Boss boss03 = new Boss();

        Gablin gablin01 = new Gablin();
        Gablin gablin02 = new Gablin();
        Gablin gablin03 = new Gablin();

            Monster.Show();
        }

    }


    interface IAtk
    {
        public void ATK();
      
    }

    public abstract class Monster : IAtk
    {
        protected static List<Monster> monsters;

        public Monster()
        {
            if (monsters==null)
            {
                monsters = new List<Monster>();
            }
            
        }

        public void Add<T>(T _value) where T:Monster
        { 
            monsters.Add(_value);
        }



        public static void Show()
        {
            foreach (Monster item in monsters)
            {
                item.ATK();
            }
        }

        public virtual void ATK()
        {
            Console.WriteLine("MonsterATK");
        }
    }

    class Boss:Monster
    {
        public Boss()
        {
            //base.Add<Boss>(this);
            Add<Boss>(this);
        }

        public override void ATK()
        {
            Console.WriteLine("BossATK");
        }
    }

    class Gablin : Monster
    {
        public Gablin()
        {
            base.Add<Gablin>(this);
        }

        public override void ATK()
        {
            Console.WriteLine("GablinATK");
        }
    }
}
