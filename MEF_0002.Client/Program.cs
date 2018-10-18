using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;


using MEF_0002.Service;


namespace MEF_0002.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            TestClient client = new TestClient();
            TestClient2 client2 = new TestClient2();
            TestClient3 client3 = new TestClient3();
            TestClient4 client4 = new TestClient4();
            TestClient4 client42 = new TestClient4();



            var catalog = new AggregateCatalog();

            // 遍历运行目录下的Addin文件夹，查找所需的插件。
            catalog.Catalogs.Add(new DirectoryCatalog("Addin"));
            var _container = new CompositionContainer(catalog);


            //将部件（part）和宿主程序添加到组合容器
            _container.SatisfyImportsOnce(client);
            client.TestRun();



            _container.SatisfyImportsOnce(client2);
            client2.TestRun();




            _container.SatisfyImportsOnce(client3);
            client3.TestRun();



            _container.SatisfyImportsOnce(client4);
            client4.TestRun();

            _container.SatisfyImportsOnce(client42);
            client42.TestRun();


            Console.ReadLine();

        }




    }
}
