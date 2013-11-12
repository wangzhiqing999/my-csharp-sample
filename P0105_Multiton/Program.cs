using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0105_Multiton.Sample;


namespace P0105_Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("测试有上限的 多例！");

            // 获取第一个实例.
            Die die1 = Die.GetInstance(1);
            // 获取第二个实例.
            Die die2 = Die.GetInstance(2);

            // 输出.
            Console.WriteLine(die1.Dice());
            Console.WriteLine(die2.Dice());



            Console.WriteLine("测试无上限的 多例！");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    I18n data = I18n.GetInstance("国家" + i);

                    Console.WriteLine(data.DemoCount++);
                }                
            }

            Console.ReadLine();
        }
    }
}
