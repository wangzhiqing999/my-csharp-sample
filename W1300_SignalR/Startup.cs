using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

using Microsoft.AspNet.SignalR;


[assembly: OwinStartup(typeof(W1300_SignalR.Startup))]

namespace W1300_SignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888



            // 下面3行， 将把服务器的错误详细信息， 发送给客户端。
            //var hubConfiguration = new HubConfiguration();
            //hubConfiguration.EnableDetailedErrors = true;
            //app.MapSignalR(hubConfiguration);



            app.MapSignalR();

        }
    }
}
