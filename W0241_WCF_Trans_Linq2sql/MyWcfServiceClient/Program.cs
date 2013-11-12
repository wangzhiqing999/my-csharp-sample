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

                Console.WriteLine("尝试调用 service.GetData(1)");
                service.GetData(1);


                // 尝试成功执行一次.
                Console.WriteLine("尝试调用 service.TestInsertData(5, FIVE, 5, FIVEFIVE)");
                service.TestInsertData(5, "FIVE", 5, "FIVEFIVE");

                Console.WriteLine("尝试调用 service.TestDeleteData(5)");
                // 清理数据.
                service.TestDeleteData(5);



                try
                {
                    // 尝试使处理失败！
                    // 因为 主表有数据为 id 为 1 与 2 的。  子表数据也是有  id 为 1 与 2 的。
                    // 在 WCF 服务中， 先插入 id=10 的主表，将成功， 然后插入 id = 1 的子表， 将失败。
                    // 操作完毕后， 需要去数据库核对。
                    // 确保没有 id=10 的主表数据.
                    Console.WriteLine("尝试调用 service.TestInsertData(10, testM, 1, TESTS)");
                    service.TestInsertData(10, "TestM", 1, "TESTS");
                }
                catch (FaultException ex)
                {
                    Console.WriteLine("调用 WCF 服务发生异常！ {0}: {1}", ex.Code.Name, ex.Reason);
                }






                try
                {
                    // 尝试使处理失败！
                    // 因为 主表有数据为 id 为 1 与 2 的。  子表数据也是有  id 为 1 与 2 的。
                    // 在 WCF 服务中， 先插入 id=20 的主表，将成功， 然后插入 id = 1 的子表， 将失败。
                    // 操作完毕后， 需要去数据库核对。
                    // 确保没有 id=10 的主表数据.
                    Console.WriteLine("尝试调用 service.TestInsertAll(10, TestM20, 1, TESTS)");
                    service.TestInsertAll(20, "TestM20", 1, "TESTS");
                }
                catch (FaultException ex)
                {
                    Console.WriteLine("调用 WCF 服务发生异常！ {0}: {1}", ex.Code.Name, ex.Reason);
                }





                Console.WriteLine("按回车键结束！");
                Console.ReadLine();
            }


        }
    }
}
