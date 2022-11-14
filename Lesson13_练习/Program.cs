namespace Lesson13_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson13_练习");

            #region 热水器问题


            Heater h = new Heater();

            Alarm alarm = new Alarm();
            Display display = new Display();

            h.BoilEvert += alarm.MaxAlert;
            h.BoilEvert += display.ShowMsg;

            h.BoilWater();
            #endregion


            #region 妈妈做饭叫人吃问题
            Console.WriteLine("******************************");

            Mom mom = new Mom();
            Dad dad = new Dad();
            Son son = new Son();


            mom.Eat += dad.Answer;
            mom.Eat += son.Reply;


            mom.Cook();
            mom.Call();

            

            #endregion
        }

     
    }

    #region 热水器问题的类


    /// <summary>
    /// 热水器类
    /// </summary>
    public class Heater
    {
        /// <summary>
        /// 温度
        /// </summary>
        private int temperature;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Heater()
        {
            temperature = 0;
            BoilEvert = null;
        }
        /// <summary>
        /// 定义一个有一个int参数的委托
        /// </summary>
        /// <param name="param"></param>
        //public delegate void BoilHandler(int param);


        /// <summary>
        /// 声明事件
        /// </summary>
        //public event BoilHandler BoilEvert;

        //上面的委托和事件可以用这句来做，意思一样
        public event Action<int> BoilEvert;



        /// <summary>
        /// 如果水温超过95度就触发事件（具体事件干嘛得看事件绑定了啥），这个事件可以绑定一个有一个int参数的方法
        /// </summary>
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    if (BoilEvert != null)
                    {
                        BoilEvert(temperature);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 报警器类
    /// </summary>
    public class Alarm
    {
        public void MaxAlert(int _value)
        {
            Console.WriteLine($@"alert:水温已经{_value}度了！");
        }
    }
    /// <summary>
    /// 显示器类
    /// </summary>
    public class Display
    {
        public void ShowMsg(int _value)
        {
            Console.WriteLine($@"display:水快开了，当前温度{_value}度");
        }
    }
    #endregion


    #region 妈妈叫人吃饭问题

    public class Mom
    {

        public delegate void EatHandler();

        public event EatHandler Eat;

        //public Action Eat;  //以上两句可以用这句替代

        public Mom()
        {
            Eat = null;
        }

        public void Cook()
        {
            Console.WriteLine("妈妈做饭");
            Console.WriteLine("妈妈做菜");
        }

        public void Call()
        {
            Console.WriteLine("饭都做好了，大家来吃吧!");
            Eat();
        }


    }

    public class Dad
    {
        public void Answer()
        {
            Console.WriteLine("爸爸说：我马上来吃！");
        }
    }
    public class Son
    {
        public void Reply()
        {
            Console.WriteLine("儿子说：我一会儿吃！");
        }
    }

    #endregion
}
