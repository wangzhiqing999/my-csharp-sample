using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Refit;


namespace W1030_Mvc_WebApi2_Client.Api
{

    /// <summary>
    /// 测试使用  Refit  来调用 Web Api 的例子代码.
    /// </summary>
    class RefitTest
    {
        public static void DoTest()
        {
            Console.WriteLine("Refit Test Start.");

            var service = RestService.For<IMyDemoService>("http://localhost:42266/");

            var demoDatas = service.GetMyDemosAsync().GetAwaiter().GetResult();

            Console.WriteLine("GetMyDemosAsync result:");
            foreach (var item in demoDatas)
            {
                Console.WriteLine("{0} : {1}", item.UserName, item.Password);
            }

            Console.WriteLine("Refit Test Finish.");
            Console.ReadLine();
        }
    }
}
