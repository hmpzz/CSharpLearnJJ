namespace Lesson16_List排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson16_List排序");

            #region 知识点一 List自带排序方法
            List<int> list = new List<int>();
            list.Add(3);
            list.Add(2);
            list.Add(6);
            list.Add(1);
            list.Add(4);
            list.Add(5);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("******************************");
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            #endregion

            #region 知识点二 自定义类的排序
            List<Item> itemList = new List<Item>();

            itemList.Add(new Item(45));
            itemList.Add(new Item(10));
            itemList.Add(new Item(99));
            itemList.Add(new Item(24));
            itemList.Add(new Item(100));
            itemList.Add(new Item(12));


            itemList.Sort();

            List<Item> itemList01 = itemList.OrderBy(a => a.Money).Select(a => new Item(a.Money)).ToList();

            for (int i = 0; i < itemList.Count; i++)
            {
                Console.WriteLine(itemList[i].Money);
            }
            #endregion

            #region 知识点三 通过委托函数进行排序
            Console.WriteLine("*********************************");
            List<ShopItem> shopItems = new List<ShopItem>();
            shopItems.Add(new ShopItem(2));
            shopItems.Add(new ShopItem(1));
            shopItems.Add(new ShopItem(4));
            shopItems.Add(new ShopItem(3));
            shopItems.Add(new ShopItem(6));
            shopItems.Add(new ShopItem(5));

            //shopItems.Sort(SortShopItem);

            shopItems.Sort((a, b) => { return a.id >= b.id ? 1 : -1; });

            for (int i = 0; i < shopItems.Count; i++)
            {
                Console.WriteLine(shopItems[i].id);
            }

            #endregion

            static int SortShopItem(ShopItem a,ShopItem b)
            {
                //传入的两个对象为列表中的两个对象
                //进行两两的比较用左边的和右边的条件比较
                //返回值规则与之前一样 0做标准 负数在左 正数在右
                return a.id >= b.id ? 1 : -1;
                
            }
        }

        class Item : IComparable<Item>
        {
            public int Money { get; set; }
            public Item(int _money)
            {
                Money = _money;
            }


            /// <summary>
            /// 实现排序接口
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public int CompareTo(Item? other)
            {
                //返回值的含义
                //小于0：放在传入对象的前面
                //等于0：保持当前的位置不变
                //大于0：放在传入对象的后面

                //可以简单理解 传入对象的位置就是0
                //如果你的返回为负数 就放在它的左边 也就是前面
                //如果你的返回为正数 就放在它的右边 也就是后面

                int result = 0;
                if (this.Money > other.Money)
                {
                    result = 1;
                }
                else if (this.Money == other.Money)
                {
                    result = 0;
                }
                else if (this.Money < other.Money)
                {
                    result = -1;
                }
                return result;
            }
        }

        class ShopItem
        { 
            public int id { get; set; }

            public ShopItem(int _id)
            {
                this.id = _id;
            }
        }
    }

    //总结
    //系统自带的变量，一般都可以直接Sort
    //自定义类Sort有两种方式，
    //1.继承接口实现
    //2.在Sort中写lambda表达式
}