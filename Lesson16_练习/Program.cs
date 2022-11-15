namespace Lesson16_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson16_练习");

            #region 第一题


            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Monster(1, 6, 5));
            monsters.Add(new Monster(5, 1, 3));
            monsters.Add(new Monster(6, 3, 1));
            monsters.Add(new Monster(2, 4, 2));
            monsters.Add(new Monster(4, 2, 6));
            monsters.Add(new Monster(3, 5, 4));

            int sortby = 3;

            switch (sortby)
            {
                //攻击力排序
                case 1:
                    monsters.Sort((a, b) => { return a.Attack >= b.Attack ? 1 : -1; });
                    break;
                //防御力
                case 2:
                    monsters.Sort((a, b) => { return a.Defense >= b.Defense ? 1 : -1; });
                    break;
                //血量
                case 3:
                    monsters.Sort((a, b) => { return a.Blood >= b.Blood ? 1 : -1; });
                    break;
                default:
                    break;
            }

            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine($@"{monsters[i].Attack},{monsters[i].Defense},{monsters[i].Blood}");
            }
            #endregion

            #region 第二题

            List<Thing> things = new List<Thing>();
            things.Add(new Thing("1白件", "1破碎", "3板甲"));
            things.Add(new Thing("2蓝件", "3卓越", "2皮甲"));
            things.Add(new Thing("2蓝件", "1破碎", "3板甲"));
            things.Add(new Thing("3金件", "2完好", "1布甲"));
            things.Add(new Thing("3金件", "3卓越", "1布甲"));
            things.Add(new Thing("1白件", "2完好", "2皮甲"));

            things.Sort();

            foreach (Thing item in things)
            {
                Console.WriteLine($@"{item.Type},{item.Quality},{item.name}");
            }
            #endregion

        }

        #region 第一题      
        class Monster
        {
            /// <summary>
            /// 攻击
            /// </summary>
            public int Attack { get; set; }

            /// <summary>
            /// 防御
            /// </summary>
            public int Defense { get; set; }

            /// <summary>
            /// 血量
            /// </summary>
            public int Blood { get; set; }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="Attack">攻击</param>
            /// <param name="Defense">防御</param>
            /// <param name="Blood">血量</param>
            public Monster(int _Attack, int _Defense, int _Blood)
            {
                Attack = _Attack;
                Defense = _Defense;
                Blood = _Blood;
            }


        }
        #endregion

        #region 第二题        
        class Thing:IComparable<Thing>
        { 
            /// <summary>
            /// 类型
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// 品质
            /// </summary>
            public string Quality { get; set; }

            /// <summary>
            /// 名字
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="_type">类型</param>
            /// <param name="_quality">质量</param>
            /// <param name="_name">名字</param>
            public Thing(string _type, string _quality, string _name)
            {
                Type = _type;
                Quality = _quality;
                this.name = _name;
            }

            public int CompareTo(Thing? other)
            {

                int SortValue = 0;
                if (this.Type.CompareTo(  other.Type)>0)
                {
                    SortValue = 1;
                }
                else if (this.Type.CompareTo(other.Type)<0)
                {
                    SortValue = -1;
                }
                else 
                {
                    if (this.Quality.CompareTo(other.Quality) > 0)
                    {
                        SortValue = 1;
                    }
                    else if (this.Quality.CompareTo(other.Quality) < 0)
                    {
                        SortValue = -1;
                    }
                    else
                    {
                        if (this.name.CompareTo(other.name)>0)
                        {
                            SortValue = 1;
                        }
                        else
                        {
                            SortValue = -1;
                        }
                    }
                }

                return SortValue;
            }
        }
        #endregion

        enum TestEnum
        {
            a=1,
            b=2,
            c=3,
        }

        class TestClass
        {

            public int a;
            public int b { get; set; }

            public void c(int _a, int _b)
            {
                Console.WriteLine($@"{_a},{_b}");
            }
            public TestClass()
            { 
            }
            public TestClass(int _a, TestEnum _b)
            {
                Console.WriteLine($@"构造函数：参数{_a},{_b.ToString()}");
            }
            
        }
    }
}
