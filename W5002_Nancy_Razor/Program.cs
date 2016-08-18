using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nancy.Hosting.Self;


namespace W5002_Nancy_Razor
{

    /// <summary>
    /// 
    /// Nancy 文档， 参考
    /// 
    /// https://github.com/NancyFx/Nancy/wiki/Introduction
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var url = new Uri("http://localhost:9955");

            var hostConfig = new HostConfiguration();
            hostConfig.UrlReservations = new UrlReservations { CreateAutomatically = true };

            using (var host = new NancyHost(hostConfig, url))
            {
                host.Start();

                Console.WriteLine("Your application is running on " + url);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
