using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A002_OO.Sample;
using A002_OO.CardSample;

namespace A002_OO
{
    class Program
    {
        static void Main(string[] args)
        {

            ISample sample1 = new Sample1();
            sample1.SayHello("小明");


            ISample sample2 = new Sample2();
            sample2.SayHello("Mike");


            ISample sample3 = new Sample3();
            sample3.SayHello("山本桑");


            Console.WriteLine("==== new 关键字 测试 ===");

            AbstractSample sample3a = new Sample3();
            sample3a.SayHello("山本桑");
            sample3a.SayEnd();

            Sample3 sample3b = new Sample3();
            sample3b.SayHello("山本桑");
            sample3b.SayEnd();






            Console.WriteLine("==== override 与 new 的区别 ===");


            Console.WriteLine("卡=普通卡！");
            Card card1 = new NormalCard();
            card1.LineUp();
            card1.TakeMoney();

            Console.WriteLine("卡=金卡！");
            Card card2 = new GoldCard();
            card2.LineUp();
            card2.TakeMoney();

            Console.WriteLine("金卡=金卡！");
            GoldCard card3 = new GoldCard();
            card3.LineUp();
            card3.TakeMoney();


            Console.ReadLine();
        }
    }
}
