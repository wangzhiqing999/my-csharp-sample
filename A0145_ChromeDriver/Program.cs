using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace A0145_ChromeDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test1();

            // Test2();

            Test3();

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





        /// <summary>
        /// 运行 Test2， 可能会弹出， 要你转圈， 把一个图片 摆正的 验证操作.
        /// 
        /// 使用 chrome远程调试 模式.
        /// </summary>
        static void Test3()
        {

            // 先命令行运行
            // chrome.exe --remote-debugging-port=9222


            // 注：初步测试时，好像只能 处理本机的， 不能处理其它计算机的。
            ChromeOptions opt = new ChromeOptions();
            opt.DebuggerAddress = ConfigurationManager.AppSettings["ChromeDriver:DebuggerAddress"];
            ChromeDriver driver = new ChromeDriver(ConfigurationManager.AppSettings["ChromeDriver:Path"], opt);


            driver.Navigate().GoToUrl("https://www.baidu.com/");



            var search = driver.FindElementById("kw");
            search.Click();
            search.SendKeys("browser");

            var btn = driver.FindElementById("su");
            btn.Click();
        }


    }
}
