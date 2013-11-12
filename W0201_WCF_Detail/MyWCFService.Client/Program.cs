using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyWCFService.DataContract;
using MyWCFService.ServiceContract;


namespace MyWCFService.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            CallWcfService("NetTcpBinding_ICalculator");

            CallWcfService("BasicHttpBinding_ICalculator");



            Console.WriteLine("按回车键结束！");


            Console.ReadLine();
        }



        /// <summary>
        /// 测试调用 WCF 服务.
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        private static void CallWcfService(string endpointConfigurationName)
        {
            using (CalculatorClient service = new CalculatorClient(endpointConfigurationName))
            {

                Console.WriteLine("调用 WCF 服务 ( {0} )  开始！", endpointConfigurationName);

                Console.WriteLine("service.Add(1, 2) = {0}", service.Add(1, 2));
                Console.WriteLine("service.Sub(2, 3) = {0}", service.Sub(2, 3));
                Console.WriteLine("service.Mul(3, 4) = {0}", service.Mul(3, 4));

                DivResult divResult = service.Div(5, 2);
                Console.WriteLine("service.Div(5, 2) = {0} 余 {1} ", divResult.DivData, divResult.ModData);

                Console.WriteLine("调用 WCF 服务 ( {0} )  结束！", endpointConfigurationName);

                Console.WriteLine();
            }
        }
    }
}
