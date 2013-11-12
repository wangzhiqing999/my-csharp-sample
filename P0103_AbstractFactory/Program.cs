using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0103_AbstractFactory.AbstractFactory;
using P0103_AbstractFactory.AbstractFactoryImpl;
using P0103_AbstractFactory.Service;

namespace P0103_AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IGardener gardener1 = new NorthernGardener();
            Demo(gardener1);


            IGardener gardener2 = new TropicalGardener();
            Demo(gardener2);

            Console.ReadLine();
        }



        /// <summary>
        /// 这里为 模拟的 客户端的 消费代码.
        /// 
        /// 客户端 对于 不同体系的产品。
        /// 消费代码是一样的。
        /// </summary>
        /// <param name="gardener"></param>
        private static void Demo(IGardener gardener)
        {
            IFruit fruit = gardener.CreateFruit();
            fruit.Plant();
            fruit.Grow();
            fruit.Harvest();


            IVeggie veggie = gardener.CreateVeggie();
            veggie.Plant();
        }
    }
}
