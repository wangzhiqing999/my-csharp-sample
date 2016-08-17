using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using MEF_0001_Client.Sample;


namespace MEF_0001_Client
{

    // http://www.cnblogs.com/comsokey/p/MEF1.html
    class Program
    {
        static void Main(string[] args)
        {

            Client client = new Client();




            var catalog = new AggregateCatalog();
            
            // 遍历运行目录下的Addin文件夹，查找所需的插件。
            catalog.Catalogs.Add(new DirectoryCatalog("Addin"));   

            var _container = new CompositionContainer(catalog);

            _container.SatisfyImportsOnce(client);




            

            client.TestRun();


            Console.ReadLine();
        }
    }
}
