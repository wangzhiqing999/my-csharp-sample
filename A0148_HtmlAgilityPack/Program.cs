using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace A0148_HtmlAgilityPack
{
    class Program
    {
        static void Main(string[] args)
        {

            Test1();
            Test1_1();
            Test1_2();


            Console.WriteLine("Finsih!");
            Console.ReadLine();

        }










        /// <summary>
        /// 测试 简单定位到一个点的操作.
        /// </summary>
        public static void Test1()
        {
            Console.WriteLine("========== Test1 ===========");

            HtmlDocument doc = new HtmlDocument();
            string html = File.ReadAllText("test1.html");
            doc.LoadHtml(html);

            // 根据XPath查找节点，跟XmlNode差不多
            HtmlNode node = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div[1]/h3[1]");
            Console.WriteLine($"InnerText = {node.InnerText.Trim()}" );  //输出节点内容 与InnerHtml的区别在于，它不会输出HTML代码
            Console.WriteLine($"InnerHtml = {node.InnerHtml.Trim()}");  //输出节点Html
            Console.WriteLine($"Name = {node.Name}");
        }





        /// <summary>
        /// 测试读取大标题.
        /// </summary>
        public static void Test1_1()
        {
            Console.WriteLine("========== Test1_1 ===========");

            HtmlDocument doc = new HtmlDocument();
            string html = File.ReadAllText("test1.html");
            doc.LoadHtml(html);

            HtmlNode node = doc.DocumentNode.SelectSingleNode("/html/body/div[1]");
            foreach(var childNode in node.SelectNodes("div"))
            {
                var titleNode = childNode.SelectSingleNode("div[1]/h3[1]");
                Console.WriteLine($"Title = {titleNode.InnerText.Trim()}");
            }
        }




        /// <summary>
        /// 测试读取大标题 + 小按钮.
        /// </summary>
        public static void Test1_2()
        {
            Console.WriteLine("========== Test1_2 ===========");

            HtmlDocument doc = new HtmlDocument();
            string html = File.ReadAllText("test1.html");
            doc.LoadHtml(html);

            HtmlNode node = doc.DocumentNode.SelectSingleNode("/html/body/div[1]");
            foreach (var childNode in node.SelectNodes("div"))
            {               
                int lineIndex = 0;
                foreach(var lineNode in childNode.SelectNodes("div"))
                {
                    lineIndex ++;
                    if(lineIndex == 1)
                    {
                        // 首个 div， 是标题.
                        var titleNode = lineNode.SelectSingleNode("h3[1]");
                        Console.WriteLine($"Title = {titleNode.InnerText.Trim()}");
                    } 
                    else
                    {
                        foreach(var menuNode in lineNode.SelectNodes("div/div[1]/div[1]/h4[1]"))
                        {
                            Console.WriteLine($"  Menu = {menuNode.InnerText.Trim()}");
                        }
                    }
                }


            }
        }




    }
}
