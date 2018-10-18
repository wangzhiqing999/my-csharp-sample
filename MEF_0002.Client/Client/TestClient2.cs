using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

using MEF_0002.Service;


namespace MEF_0002.Client
{
    public class TestClient2
    {

        /// <summary>
        /// 演示服务列表.
        /// 
        /// 注意：这里传递了参数 FileDemoService,  也就是 指定了 契约名.
        /// 这里是 ImportMany， 因此， 当存在多个的时候， 将获取多个实现.
        /// 
        /// </summary>
        [ImportMany("FileDemoService")]
        public IEnumerable<IDemoService> Services { get; set; }




        public void TestRun()
        {
            foreach (var service in this.Services)
            {
                service.SaveData("[测试调用所有的服务]");
            }


            Console.WriteLine();
        }

    }
}
