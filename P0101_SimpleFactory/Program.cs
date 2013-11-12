using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0101_SimpleFactory.Service;
using P0101_SimpleFactory.SimpleFactory;

namespace P0101_SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IFruit fruit1 = FruitGardener.Factory("apple");
            IFruit fruit2 = FruitGardener.Factory("Grape");
            IFruit fruit3 = FruitGardener.Factory("Strawberry");
            Demo(fruit1);
            Demo(fruit2);
            Demo(fruit3);

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
