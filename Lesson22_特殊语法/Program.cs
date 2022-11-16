namespace Lesson22_特殊语法
{

    class Person
    {
        private int money;
        public bool sex;

        public string name { get; set; }
        public int age { get; set; }

        public Person(int _money)
        {
            money = _money;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson22_特殊语法");

            #region 知识点一 var隐式类型
            //var是一种特殊的变量美型
            //它可以用来表示任意类型的变量
            //注意：
            //1.var不能作为类的成员只能用于临时变量申明时
            //也就是一般写在函数语句块中
            //2.var必须初始化
            #endregion

            #region 知识点二 设置对象初始值
            //申明对象时
            //可以通过直接写大括号的形式初始化公共成员变量和属性

            Person p = new Person(100) { sex = true, age = 10, name = "aaa" };
            #endregion

            #region 知识点三 设置集合初始值
            //申明集合对象时
            //可以通过直接写大括号的形式初始化内部属性

            int[] array2 = new int[] { 1, 2, 3, 4, 5 };
            List<int> listInt = new List<int>() { 1, 2, 34, 5 };

            List<Person> people = new List<Person>() { new Person(10) { age = 10 }, new Person(100) { sex = true, name = "fdsa" } };

            Dictionary<string, int> dic = new Dictionary<string, int>() { { "1", 123 }, { "a", 222 } };
            #endregion

            #region 知识点四 匿名类型
            //var 变量可以申明为自定义的匿名类型
            var v = new { age = 10, money = 100, name = "fdsa" };

            #endregion


            #region 知识点五 可空类型
            //1.值类型是不能赋值为空的
            //int c = null;
            //2.申明时在值类型后面加?可以赋值为空
            int? c = null;

            //3.判断是否为空
            if (c.HasValue)
            {
                Console.WriteLine(c);
            }
            //4.安全获取可空类型值
            //4-1.如果为空默认返回值类型的默认值
            int? value = null;

            //4-2.也可以指定一个默认值
            Console.WriteLine(value.GetValueOrDefault(100));//GetValueOrDefault(可以指定默认值)

            object o = null;

            if (o != null)
            {
                Console.WriteLine(o.ToString());
            }
            //相当于一种语法糖 能够帮我们判断o是不是空
            //如果o是空也不会执行tostring,防止报错
            Console.WriteLine(o?.ToString());

            Action action = null;
            action?.Invoke();

            #endregion

            #region 知识点六 空合并操作符
            //空合并操作符??
            //左边值??右边值
            //如果左边值为null就返回右边值 否则返回左边值
            //只要是可以为null的类型都能用
            int? intV = null;
            int intI = intV == null ? 100 : intV.Value;

            intI = intV ?? 100;

            #endregion

            #region 知识点七 内插字符串
            //关键符号 $
            //用$来禁猎地字符串，让字符串中可以拼接变量
            string sk = $"{123},{456}";
            #endregion

            #region 知识点八 单句逻辑的简略写法
            
            //if,for,while只有一句时可以省略大括号
            //类的属性如果只有一句也可以写 set=>name="张三";
            //类的方法如果只有一句也可以写成 public int Add(int x,int y )=> x+y;
            #endregion

        }
    }


}