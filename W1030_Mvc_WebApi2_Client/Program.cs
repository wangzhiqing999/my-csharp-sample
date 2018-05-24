using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W1030_Mvc_WebApi2_Client
{
    class Program
    {
        static void Main(string[] args)
        {

            var f = testFail();
            Console.ReadKey();


            var s = testSuccess();
            Console.ReadKey();




            var l = testI18n();
            Console.ReadKey();

            Console.WriteLine("Finish!");
            

        }



        static async Task testFail()
        {
            Console.WriteLine("### 直接访问.");

            OAuthClientTest test = new OAuthClientTest();
            await test.Call_WebAPI_Without_Access_Token();

            Console.WriteLine("### 直接访问完成! 按任意键继续.");
        }

        static async Task testSuccess()
        {
            Console.WriteLine("### 使用 Access Token 访问.");

            OAuthClientTest test = new OAuthClientTest();
            await test.Call_WebAPI_By_Access_Token();

            Console.WriteLine("### 使用 Access Token 访问完成! 按任意键继续.");
        }





        /// <summary>
        /// 测试默认语言.
        /// </summary>
        /// <returns></returns>
        static async Task testI18n()
        {            
            I18nTest test = new I18nTest();

            Console.WriteLine("测试默认语言");
            await test.TestDefault();


            Console.WriteLine("测试 zh-CN");
            await test.TestLang("zh-CN");

            Console.WriteLine("测试 en-US");
            await test.TestLang("en-US");

        }




    }
}
