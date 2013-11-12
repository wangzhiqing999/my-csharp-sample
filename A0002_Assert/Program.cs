using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0002_Assert.Sample;


namespace A0002_Assert
{

    class Program
    {

        static void Main(string[] args)
        {

            TestAssert test = new TestAssert();


            test.BuyItem(1, 100);


            test.BuyItem(-1, 100);


            test.BuyItem(1, -100);



            Console.ReadLine();

        }

    }

}
