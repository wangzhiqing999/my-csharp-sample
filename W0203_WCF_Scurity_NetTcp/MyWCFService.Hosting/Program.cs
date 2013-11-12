using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Description;

using MyWCFService.DataContract;
using MyWCFService.ServiceContract;
using MyWCFService.Service;


namespace MyWCFService.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            HostCalculatorSerivceViaConfiguration();
        }




        /// <summary>
        /// 通过配置文件的方式，配置、启动 WCF 服务。
        /// </summary>
        static void HostCalculatorSerivceViaConfiguration()
        {
            using (ServiceHost calculatorSerivceHost = new ServiceHost(typeof(CalculatorService)))
            {
                calculatorSerivceHost.Opened += delegate
                {
                    Console.WriteLine("WCF服务开启完毕......");

                    Console.WriteLine("按回车键停止服务!");
                };

                calculatorSerivceHost.Open();
               
                Console.ReadLine();
            }
        }    
    }
}
