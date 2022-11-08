using System.Collections;

namespace Lesson01_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson01_练习");

            Bag bag = new Bag();

            bag.MR("飞机", 1000);
            bag.MR("坦克", 300);

            bag.MC("1", 20);
            bag.MC("2", 30);

            bag.ShowBag();
        }


    }

    class Bag
    {

        public Bag()
        {
            money = 10000;
            arrayList= new ArrayList();
            arrayList.Add("1");
            arrayList.Add("2");
            arrayList.Add("3"); 
        }

        /// <summary>
        /// 存储物品
        /// </summary>
        private ArrayList? arrayList { get; set; }

        /// <summary>
        /// 金钱属性
        /// </summary>
        private decimal money { get; set; }

        /// <summary>
        /// 卖出物品
        /// </summary>
        /// <param name="obj">要卖出的物品</param>
        /// <param name="_money">得到的钱数</param>
        public void MC(object _obj,decimal _money)
        { 
            //查找卖出物品的位置
            int index=arrayList.IndexOf(_obj);

            if (index>=0)
            {
                arrayList.RemoveAt(index);
                money += _money;
            }
            else
            {
                Console.WriteLine("没有找到要卖出的物品");
            }
        }

        /// <summary>
        /// 买入
        /// </summary>
        /// <param name="_obj">要买入的物品</param>
        /// <param name="_money">花费的钱数</param>
        public void MR(object _obj, decimal _money)
        {



            arrayList.Add(_obj);
            money -= _money;
            
        }

        public void ShowBag()
        {
            foreach (object item in arrayList)
            {
                Console.WriteLine($@"物品：{item}");
            }

            Console.WriteLine($@"金钱：{money}");

        }

    }
}