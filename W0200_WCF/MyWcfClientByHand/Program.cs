using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyWcfService;


namespace MyWcfClientByHand
{


    // 本例子中.
    // 客户端 访问 WCF 服务的代码。
    // 是 手动添加 引用，并编码 访问指定服务的.


    // 这种通过自己编程 调用WCF服务的处理方式：

    // 优点：通过引用 Web 服务的 ServiceContract 接口 与 DataContract 数据类.
    //       通过获取服务端的 DLL 与 XML 文件，能够取得接口的备注信息.

    // 缺点：自己编写客户端的 app.config ，还是有一定的复杂 （这里是直接从 自动的项目中复制过来的）
    //       当接口发生变更，服务端开发完毕后，客户端取最新 服务器的 DLL 后，会编译出错，要手动加入新的方法定义。

    


    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("调用 WCF 服务开始！");

            using (MyWcfServiceClient service = new MyWcfServiceClient("BasicHttpBinding_IMyWcfService"))
            {

                Console.WriteLine("调用 service.GetData(100)， 返回：" + service.GetData(100));


                CompositeType ct = new CompositeType()
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
