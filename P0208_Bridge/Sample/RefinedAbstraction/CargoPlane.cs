using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0208_Bridge.Sample
{


    /// <summary>
    /// 桥梁模式（Bridge） 中的  修正抽象化（Refined Abstraction）角色：
    /// 
    /// 扩展抽象化角色，改变和修正父类对抽象化的定义。
    /// 
    /// 
    /// 货机.
    /// </summary>
    public class CargoPlane : Airplane
    {

        public CargoPlane(AirplaneMaker maker)
        {
            base.airplaneMaker = maker;
        }



        public override void Fly()
        {
            Console.WriteLine("{0}公司的 货机即将起飞......", base.airplaneMaker.GetName());

            Console.WriteLine("首先，关闭 货舱门！");

            Console.WriteLine("启动 {0}", base.airplaneMaker.GetEngine());

            Console.WriteLine("升空");

            Console.WriteLine("收起 {0}", base.airplaneMaker.GetLandingGear());

            Console.WriteLine("货物运输开始了......");


            Console.WriteLine();
        }
    }
}
