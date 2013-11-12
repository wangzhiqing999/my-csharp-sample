using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWcfClient
{
    class Program
    {

        // 本例子中.
        // 客户端 访问 WCF 服务的代码。
        // 是 通过 VS2010 中， 添加服务引用的方式来添加的


        // 这种通过开发环境生成 调用WCF服务的处理方式：

        // 优点：不需要自己写 WCF 通信的代码，全部由开发环境生成
        //       如果服务器接口发生变化，只需要作一次 “更新服务引用”的处理。

        // 缺点：生成的代码，接口与自定义对象的命名空间，可能与源代码不一致。 
        //       生成的代码，没有方法与参数的注释信息.

        static void Main(string[] args)
        {

            Console.WriteLine("调用 WCF 服务开始！");

            using (MyWcfServiceReference.MyWcfServiceClient service = new MyWcfServiceReference.MyWcfServiceClient())
            {

                Console.WriteLine("调用 service.GetData(100)， 返回：" + service.GetData(100) );


                MyWcfServiceReference.CompositeType ct = new MyWcfServiceReference.CompositeType()
                {
                     StringValue = "Test",
                     BoolValue = true
                };


                Console.WriteLine("调用前 ct: BoolValue={0}; StringValue={1}", ct.BoolValue, ct.StringValue);

                Console.WriteLine("调用 service.GetDataUsingDataContract(ct)");

                ct = service.GetDataUsingDataContract(ct);

                Console.WriteLine("调用后 ct: BoolValue={0}; StringValue={1}", ct.BoolValue, ct.StringValue);


            }

            Console.WriteLine("调用 WCF 服务结束！");
            Console.ReadLine();
        }
    }
}
