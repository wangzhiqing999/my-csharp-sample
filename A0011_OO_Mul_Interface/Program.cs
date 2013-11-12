using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0011_OO_Mul_Interface.Sample;

namespace A0011_OO_Mul_Interface
{
    class Program
    {

        static void Main(string[] args)
        {
            // 使用接口
            IArmyCar ha = new Hummer();
            ha.run();
            ha.stop();

            // 使用接口
            IPersonCar hp = new Hummer();
            hp.run();
            hp.stop();

            // 使用具体类
            Hummer h = new Hummer();
            h.run();
            h.stop();

            Console.ReadLine();
        }

    }
}
