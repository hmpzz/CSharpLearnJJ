namespace Lesson17_协变逆变
{

    #region 知识点一什么是协变逆变
    //协变
    //和谐的变化，自然的变化
    //因为里氏替换原则父类可以装子类
    //所以子类变父类
    //比如string变成object
    //感受是和谐的

    //逆变：
    //逆常规的变化，不正常的变化
    //因为里氏替换原则父类可以装子类但是子类不能装父类
    //所以父类变子类
    //比如object变成string
    //感受是不和谐的

    //协变和逆变是用来修饰泛型的
    //协变：out
    //逆变：in
    //用于在泛型中修饰泛型字母的
    //只有泛型接口和泛型委托能使用
    #endregion

    #region 知识点二作用
    //1.返回值和参数(只有委托和接口可用)
    //用out修饰的泛型只能作为返回值
    delegate T TestOut<out T>();
    //用in修饰的泛型只能作为参数
    delegate void TestIn<in T>(T value);

    //2.结合里氏替换原则理解
    class Father
    {

    }

    class Son : Father
    {

    }
    #endregion




    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson17_协变逆变");

            #region 知识点二 作用(结合里氏替换原则理解)
            //协变父类总是能被子类替换
            TestOut<Son> os = () =>
            {
                return new Son();
            };

            TestOut<Father> of = os;//TestOut里的T没有OUT就没办法这么写，就是不能协变
            Father f = of();//实际上返回的 是os里面装的函数 返回的是Son

            //逆变父类总是能被子类替换
            //看起来像是father-->son 明明是传父类 但是你传子类 不和谐的
            TestIn<Father> iF = (value) => 
            {
            };

            TestIn<Son> iS = iF;



            iS(new Son());//实际上 调用的是iF
            #endregion


        }
    }
    //总结
    //协变 out
    //逆变 in
    //用来修饰 泛型替代符的 只能修饰接口或者委托中的泛型
    //1.out 修饰的泛型类型 只能作为返回值类型 in修饰的泛型类型 只能作为 参数类型
    //2.遵循里氏替换原则的 用out和in修饰的 泛型委托 可以相互装载（有父子关系的泛型）

    // 协变  父类泛型委托装子类泛型委托          逆变  子类泛型委托装父类泛型委托
}