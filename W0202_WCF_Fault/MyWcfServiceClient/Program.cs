using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace MyWcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {


            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client("WSHttpBinding_IService1"))
            {

                
                try
                {
                    Console.WriteLine("尝试调用 service.GetData(1)");
                    service.GetData(1);
                }
                catch (FaultException ex)
                {
                    Console.WriteLine("调用 WCF 服务发生异常！ {0}: {1}", ex.Code.Name, ex.Reason);
                }



                try
                {
                    Console.WriteLine("尝试调用 service.GetDataUsingDataContract(null)");
                    service.GetDataUsingDataContract(null);
                }
                catch (FaultException ex)
                {
                    Console.WriteLine("调用 WCF 服务发生异常！ {0}: {1}", ex.Code.Name, ex.Reason);
                }



                try
                {
                    Console.WriteLine("尝试调用 service.TestFaults(null)");
                    service.TestFaults(null);
                }
                catch (FaultException<ServiceReference1.SystemFault> sf)
                {
                    Console.WriteLine("调用 WCF 服务发生异常！ {0}: {1}\n{2}",
                        sf.Detail.SystemOperation, 
                        sf.Detail.SystemMessage, 
                        sf.Detail.SystemReason);
                }



                Console.WriteLine("按回车键结束！");
                Console.ReadLine();
            }


        }
    }
}
