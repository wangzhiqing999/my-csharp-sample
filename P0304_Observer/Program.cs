using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace P0304_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            DesignPatterns.Observer.WeatherData.Demo.ShowDemo();


            P0304_Observer.SampleHappyBar.Demo.ShowDemo();


            P0304_Observer.SampleWithDelegate.Demo.ShowDemo();


            Console.ReadLine();
        }
    }
}
