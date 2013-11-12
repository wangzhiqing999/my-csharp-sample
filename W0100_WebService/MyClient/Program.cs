using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Web 服务 客户端代码");


            using (MyWebServiceReference.MyWebServiceSoapClient c = new MyWebServiceReference.MyWebServiceSoapClient())
            {

                // --------------------------------------------------
                // 简单调用创建 Web服务，自动产生的方法.
                // --------------------------------------------------
                Console.WriteLine("调用 服务端 HelloWorld 方法！ ");
                Console.WriteLine(c.HelloWorld());
                Console.WriteLine();





                // --------------------------------------------------
                // 调用一个模拟的登录处理方法.
                // --------------------------------------------------
                Console.WriteLine("调用 服务端 DoLogin 方法！ ");

                string userName = String.Empty;
                string password = String.Empty;
                string resultMessage = String.Empty;
                bool loginResult = c.DoLogin(userName, password, ref resultMessage);
                Console.WriteLine("调用 DoLogin ( '{0}' , '{1}' ), 返回值{2}, 返回消息{3}",
                    userName, password, loginResult, resultMessage);

                userName = "TEST";
                password = "123";
                resultMessage = String.Empty;
                loginResult = c.DoLogin(userName, password, ref resultMessage);
                Console.WriteLine("调用 DoLogin ( '{0}' , '{1}' ), 返回值{2}, 返回消息{3}",
                    userName, password, loginResult, resultMessage);

                userName = "TEST";
                password = "TEST";
                resultMessage = String.Empty;
                loginResult = c.DoLogin(userName, password, ref resultMessage);
                Console.WriteLine("调用 DoLogin ( '{0}' , '{1}' ), 返回值{2}, 返回消息{3}",
                    userName, password, loginResult, resultMessage);
                Console.WriteLine();





                // --------------------------------------------------
                // 调用一个 需要 SoapHeader 验证的方法.
                // --------------------------------------------------

                Console.WriteLine("调用 服务端 DoSomething 方法！ ");

                MyWebServiceReference.SecuritySoapHeader header = new MyWebServiceReference.SecuritySoapHeader()
                {
                     UserCode = "TEST",
                     PassWord = "1234"
                };
                Console.WriteLine("传入错误的 SoapHeader， 调用 DoSomething， 返回：" + c.DoSomething(header, "123"));


                header.PassWord = "TEST";
                Console.WriteLine("传入正确的 SoapHeader， 调用 DoSomething， 返回：" + c.DoSomething(header, "123"));


            }




            Console.ReadLine();

        }
    }
}
