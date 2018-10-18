using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

using MEF_0002.Service;


namespace MEF_0002.Client
{
    public class TestClient4
    {

        /// <summary>
        /// 演示服务. (服务是共享的)
        /// </summary>
        [Import("MemoryDemoService", typeof(IDemoService))]
        public IDemoService Service { get; set; }


        /// <summary>
        /// 演示服务. （服务是不共享的）
        /// </summary>
        [Import("TempDemoService", typeof(IDemoService))]
        public IDemoService Service2 { get; set; }




        public void TestRun()
        {

            this.Service.SaveData("[服务是共享的]");
            this.Service2.SaveData("[服务是不共享的]");


            Console.WriteLine();
        }

    }
}
