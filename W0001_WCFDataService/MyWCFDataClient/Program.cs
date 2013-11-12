using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace MyWCFDataClient
{
    class Program
    {
        static void Main(string[] args)
        {

            // Debug 阶段
            // 此地址可能需要动态的变化.
            Uri serviceRootUri = new Uri("http://localhost:4141/DemoWcfDataService.svc/");


            ServiceReference1.TestEntities service = 
                new ServiceReference1.TestEntities(serviceRootUri);


            // 使用 Windows 操作系统验证  ( 当前 Login 用户).
            // service.Credentials = System.Net.CredentialCache.DefaultCredentials; 


            //// 使用 Windows 操作系统验证  ( 手工指定用户名与密码).
            //service.Credentials = new NetworkCredential(
            //    "username",
            //    "password",
            //    "domain");







            Console.WriteLine("========== 首次查询！ ==========");

            ShowDebug(service);





            Console.WriteLine("========== 插入数据！==========");

            // 准备新增一条数据.
            ServiceReference1.mr_demo_data newData = new ServiceReference1.mr_demo_data()
            {
                 city_id = 1,
                 dept_id = 2,
                 demo_info = "New Data"
            };
            // 插入数据.
            service.AddTomr_demo_data(newData);
            // 保存.
            service.SaveChanges();

            // 再次查询.
            ShowDebug(service);
            Console.WriteLine("去数据库查询一下，然后按回车继续！");
            Console.ReadLine();
            





            // 修改数据.
            Console.WriteLine("========== 修改数据！ ==========");

            var query =
                from data in service.mr_demo_data
                where data.city_id == 1 && data.dept_id == 2
                select data;
            foreach (ServiceReference1.mr_demo_data updData in query)
            {
                updData.demo_info = "After UPDATE";

                service.UpdateObject(updData);
            }
            service.SaveChanges();

            ShowDebug(service);
            Console.WriteLine("去数据库查询一下，然后按回车继续！");
            Console.ReadLine();






            // 删除数据.
            Console.WriteLine("========== 删除数据！==========");

            query =
                from data in service.mr_demo_data
                where data.city_id == 1 && data.dept_id == 2
                select data;
            foreach (ServiceReference1.mr_demo_data delData in query)
            {
                service.DeleteObject(delData);
            }

            service.SaveChanges();


            // 再次查询.
            ShowDebug(service);
            Console.WriteLine("去数据库查询一下，然后按回车结束！");
            Console.ReadLine();
        }



        /// <summary>
        /// 显示输出.
        /// </summary>
        /// <param name="service"></param>
        private static void ShowDebug(ServiceReference1.TestEntities service)
        {
            // 这里是 使用 Linq  查询远程服务器上的表的数据。
            var query =
                from data in service.mr_demo_data
                where data.city_id == 1
                select data;


            foreach (ServiceReference1.mr_demo_data data in query)
            {
                Console.WriteLine(
                    "City:{0}; Dept{1}; Value{2}",
                    data.city_id,
                    data.dept_id,
                    data.demo_info);
            }
        }

    
    
    }
}
