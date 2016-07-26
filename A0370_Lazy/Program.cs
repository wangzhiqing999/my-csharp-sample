using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0370_Lazy.Sample;


namespace A0370_Lazy
{
    class Program
    {
        static void Main(string[] args)
        {

            // ---------- 不使用延迟初始化
            Console.WriteLine("#{0}#-----------", DateTime.Now);
            Console.WriteLine("#不使用延迟初始化");

            Console.WriteLine("#初始化5个用户.");

            List<Customer> dataList = new List<Customer>();
            for (int i = 0; i < 5; i++)
            {
                dataList.Add(new Customer("C_" + i));
            }

            Console.WriteLine("#{0}#初始化完毕.", DateTime.Now);

            Console.WriteLine("#查询第3个用户的订单.");
            for (int i = 0; i < dataList[2].MyOrders.Count; i++)
            {
                Console.WriteLine(dataList[2].MyOrders[i]);
            }

            Console.WriteLine("#{0}#测试结束", DateTime.Now);



            Console.WriteLine();


            // ---------- 使用延迟初始化
            Console.WriteLine("#{0}#-----------", DateTime.Now);
            Console.WriteLine("#使用延迟初始化");

            Console.WriteLine("#初始化5个用户.");

            List<CustomerWithLazy> lazyDataList = new List<CustomerWithLazy>();
            for (int i = 0; i < 5; i++)
            {
                lazyDataList.Add(new CustomerWithLazy("C_" + i));
            }

            Console.WriteLine("#{0}#初始化完毕.", DateTime.Now);

            Console.WriteLine("#查询第3个用户的订单.");
            for (int i = 0; i < lazyDataList[2].MyOrders.Count; i++)
            {
                Console.WriteLine(lazyDataList[2].MyOrders[i]);
            }

            Console.WriteLine("#{0}#测试结束", DateTime.Now);


            Console.ReadLine();
        }
    }
}
