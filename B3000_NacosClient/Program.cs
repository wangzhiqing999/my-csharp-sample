using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Alibaba.Nacos.Core;

namespace NacosClient
{
    class Program
    {
        static void Main(string[] args)
        {

            ConfigSample configSample = new ConfigSample();

            // configSample.TestPublishConfig();

            //configSample.TestGetConfig();

            configSample.TestGetConfig2();

            //configSample.TestListenerConfig2();

            // configSample.TestDeleteConfig();




            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
