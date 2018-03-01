using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0624_EF_OneToOne.Sample;

namespace A0624_EF_OneToOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();

            Car c1 = new Car()
            {
                CarName = "BMW",
                Engine = new Engine()
                {
                    EngineName = "BMW发动机"
                }
            };

            Car c2 = new Car()
            {
                CarName = "奥迪",
                Engine = new Engine()
                {
                    EngineName = "奥迪发动机"
                }
            };


            t.SaveCarData(c1);
            t.SaveCarData(c2);



            Car c3 = new Car()
            {
                CarName = "报废车辆，发动机已拆除"
            };
            t.SaveCarData(c3);



            Console.WriteLine("===== 通过[从]  查询[主] =====");
            foreach (Engine e in t.EngineDataSource)
            {
                Console.WriteLine("{0} 安装在 {1} 上.",
                    e.EngineName, e.OnCar.CarName);
            }
            Console.WriteLine();


            Console.WriteLine("===== 通过[主]  查询[从] =====");
            foreach (Car c in t.CarDataSource)
            {
                Console.Write(c.CarName);
                if (c.Engine != null)
                {
                    Console.WriteLine(" ----- {0}", c.Engine.EngineName);
                }
                else
                {
                    Console.WriteLine(" ----- 未安装");
                }
            }


            Console.ReadLine();
        }
    }
}
