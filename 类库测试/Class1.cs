using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 类库测试
{
    public class Player
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 血量
        /// </summary>
        public int Blood { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public int Atk { get; set; }

        /// <summary>
        /// 防御力
        /// </summary>
        public int Defense { get; set; }

        public Player()
        {
            Console.WriteLine("Player的无参构造函数");
        }
    }

    class Location
    { 
        public int X { get; set; }
        public int Y { get; set; }
    }

}
