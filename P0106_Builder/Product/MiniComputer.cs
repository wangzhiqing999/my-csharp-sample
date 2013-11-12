using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0106_Builder.Product
{

    /// <summary>
    /// 这是 建造模式中的  产品。
    /// 本例子用于 描述一台小型计算机
    /// </summary>
    public class MiniComputer : AbstractComputer
    {
        public override void StartComputer()
        {
            Console.WriteLine("小型机启动啦！");
            Console.WriteLine("硬件检测：{0}", base.Hardward);
            Console.WriteLine("{0}软件启动中......", base.Software);
        }

    }
}
