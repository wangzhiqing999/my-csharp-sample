using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;


namespace A0136_SocketAsyncEventArgsServer.Sample
{

    //这个类是将UserToken进行了再次封装，MSDN对于异步Socket的介绍中总会提到：  
    //若在异步回调中需要查询更多的信息，则应该建立一个小型类来管理回调时传递的Object对象  
    //UserToken其实就是那个传递的参数，AsyncUserToken就是对UserToken的封装，建立的小型类  
    public class AsyncUserToken
    {
        private Socket socket;
        public Socket Socket
        {
            get { return this.socket; }
            set { this.socket = value; }
        }
        //自定义的一些内容  
        private string id;
        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }  

}
