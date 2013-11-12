using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0101_SimpleFactory.Service;
using P0102_FactoryMethod.FactoryMethod;
using P0102_FactoryMethod.FactoryMethodImpl;

namespace P0102_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IFruitGardener[] fruitGardeners = new IFruitGardener[3];
            fruitGardeners[0] = new AppleGardener();
            fruitGardeners[1] = new GrapeGardener();
            fruitGardeners[2] = new StrawberryFruitGardener();

            foreach (IFruitGardener fruitGardener in fruitGardeners)
            {
                IFruit fruit = fruitGardener.Factory();
                Demo(fruit);
            }

            Console.ReadLine();
        }



        /// <summary>
        /// 用于演示一个水果的三个过程.
        /// </summary>
        /// <param name="fruit"></param>
        private static void Demo(IFruit fruit)
        {
            // 种植.
            fruit.Plant();
            // 成长.
            fruit.Grow();
            // 收获.
            fruit.Harvest();
        }
    }
}
