using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0011_OO_Mul_Interface.Sample
{
    
    class Hummer : IArmyCar, IPersonCar
    {

        // 在一个类，实现2个接口
        // 且这2个接口，有着相同的方法名冲突的时候
        // 类可以实现这个一个方法来完成对2个接口的实现。



        // 当不同的接口的相同名称的方法，需要有有特定的实现时
        // 可以通过在 方面前面加上 接口的名称来实现
        // 特定实现的方法无法声明为 public
        // 而且仅仅当 类变量声明为 接口的时候，才会调用这些特定的方法。

        #region 以下代码可以删除，而不影响编译

        void IArmyCar.run()
        {
            Console.WriteLine("悍马正作为军用车辆行驶");
        }

        void IArmyCar.stop()
        {
            Console.WriteLine("悍马正作为军用车辆停止");
        }

        #endregion





        public void run()
        {
            Console.WriteLine("悍马正作为民用车辆行驶");
        }

        public void stop()
        {
            Console.WriteLine("悍马正作为民用车辆停止");
        }
    }

}
