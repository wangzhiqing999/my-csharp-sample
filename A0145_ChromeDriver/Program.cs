using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace A0145_ChromeDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test1();

            Test2();

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }




        static void Test1()
        {
            Console.WriteLine("=== Test1 ===");
            ChromeDriver driver = new ChromeDriver(@"C:\Users\wangz\AppData\Local\Google\Chrome\Application\");
            driver.Navigate().GoToUrl("https://www.baidu.com/");
        }



        static void Test2()
        {
            Console.WriteLine("=== Test2 ===");
            ChromeDriver driver = new ChromeDriver(@"C:\Users\wangz\AppData\Local\Google\Chrome\Application\");
            driver.Navigate().GoToUrl("https://www.baidu.com/");


            
            var search = driver.FindElementById("kw");
            search.Click();
            search.SendKeys("browser");

            var btn = driver.FindElementById("su");
            btn.Click();

          
        }

    }
}
