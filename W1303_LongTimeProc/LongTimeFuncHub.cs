using Microsoft.AspNet.SignalR;
using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using W1303_LongTimeProc.Service;

namespace W1303_LongTimeProc
{

    [HubName("funcHub")]
    public class LongTimeFuncHub : Hub
    {


        public void Hello()
        {
            Clients.All.hello();
        }




        public void LongTimeFunc()
        {
            int count = 100;

            // 显示总数.
            Clients.Client(Context.ConnectionId).showStart(count);


            Debug.Write("LongTimeFunc Start!");


            for (int i = 0; i < count; i++)
            {
                // 显示进度
                Clients.Client(Context.ConnectionId).showStatus(i + 1);
                Thread.Sleep(1000);

                Debug.Write($"LongTimeFunc Exec: {i+1}/{count}");
            }

            Clients.Client(Context.ConnectionId).showFinish();


            Debug.Write("LongTimeFunc Finish!");
        }





        public void LongTimeFunc2()
        {
            // 显示总数.
            Clients.Client(Context.ConnectionId).showStart(100);

            LongTimeFuncService service = new LongTimeFuncService();

            service.LongTimeFunc(p =>
            {
                Clients.Client(Context.ConnectionId).showStatus(p);
            });

        }




    }
}