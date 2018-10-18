using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

using MEF_0002.Service;


namespace MEF_0002.Client
{

    /// <summary>
    /// 测试客户端.
    /// </summary>
    public class TestClient
    {

        /// <summary>
        /// 演示服务
        /// 
        /// 注意：这里传递了参数 WebDemoService,  也就是 指定了 契约名.
        /// 如果存在有多个 契约名称为 WebDemoService 的， 运行过程中， 将发生异常.
        /// </summary>
        [Import("WebDemoService")]
        public IDemoService Service { get; set; }


        public void TestRun()
        {
            this.Service.SaveData("[测试调用单个服务]");

            Console.WriteLine();
        }

    }

}
