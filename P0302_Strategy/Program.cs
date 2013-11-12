using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using P0302_Strategy.Sample;

using DesignPatterns.Strategy.Ducks;


namespace P0302_Strategy
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("##### 例子1 #####");

            // 无折扣.
            DiscountContext c1 = new DiscountContext(new NoDiscountStrategy());
            // 每本1元.
            DiscountContext c2 = new DiscountContext(new FlatRateStrategy() { OneCopyDiscount = 1 });
            // 总金额 10%
            DiscountContext c3 = new DiscountContext(new PercentageStrategy() { Percent = 0.1M });
            Console.WriteLine(c1.GetBookDiscount(100, 10));
            Console.WriteLine(c2.GetBookDiscount(100, 10));
            Console.WriteLine(c3.GetBookDiscount(100, 10));



            Console.WriteLine("##### 例子2 #####");

            MallardDuck mallardDuck = new MallardDuck();
            RedheadDuck redheadDuck = new RedheadDuck();
            RubberDuck rubberDuck = new RubberDuck();

            Console.WriteLine(mallardDuck.Display() + " # " + mallardDuck.PerformFly().ToString() + " # " + mallardDuck.PerformQuack().ToString());
            Console.WriteLine(redheadDuck.Display() + " # " + redheadDuck.PerformFly().ToString() + " # " + redheadDuck.PerformQuack().ToString());
            Console.WriteLine(rubberDuck.Display() + " # " + rubberDuck.PerformFly().ToString() + " # " + rubberDuck.PerformQuack().ToString());
            


            Console.ReadLine();
        }

    }
}
