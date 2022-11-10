using System.Runtime.InteropServices;

namespace Lesson08_练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson08_练习");

            #region 第一题           
            Dictionary<int,string > keyValuePairs = new Dictionary<int,string>();
            keyValuePairs.Add(1, "壹");
            keyValuePairs.Add(2, "贰");
            keyValuePairs.Add(3, "参");
            keyValuePairs.Add(4, "肆");
            keyValuePairs.Add(5, "伍");
            keyValuePairs.Add(6, "陆");
            keyValuePairs.Add(7, "柒");
            keyValuePairs.Add(8, "捌");
            keyValuePairs.Add(9, "玖");
            keyValuePairs.Add(0, "零");

            

            int k1 = 306;

            int k2 = k1;

            string value = "";

            while (k2!=0)
            {
                int k3 = k2 % 10;
                k2 =k2 / 10;

                value += keyValuePairs[k3];
                
            }
            Console.WriteLine(value);

            #endregion


            Console.WriteLine("*****************************************");
            #region 第二题
            string p1 = "Welcome to Unity World!";
            Dictionary<string ,int> keyValuePairs1 = new Dictionary<string ,int>();

            foreach (char item in p1)
            {
                if (keyValuePairs1.ContainsKey(item.ToString().ToUpper()))
                { 
                    keyValuePairs1[item.ToString().ToUpper()]++;
                }
                else
                {
                    keyValuePairs1.Add(item.ToString().ToUpper(), 1);
                }
                        
            }

            foreach (KeyValuePair<string,int> item in keyValuePairs1)
            {
                Console.WriteLine($@"字符：{item.Key}    值：{item.Value}");
            }

            #endregion
        }


    }
}