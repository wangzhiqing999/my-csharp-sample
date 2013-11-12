using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0106_Builder.Product
{

    /// <summary>
    /// 这是 建造模式中的  产品。
    /// 本例子用于 描述一台个人计算机
    /// </summary>
    public class PersonalComputer : AbstractComputer
    {
        public override void StartComputer()
        {
            Console.WriteLine("PC机启动啦！");
            Console.WriteLine("硬件检测：{0}", base.Hardward);
            Console.WriteLine("{0}软件启动中......", base.Software);
        }
    }
}
