using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5300_UDP_P2P.Model
{
    public class MyClient
    {

        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { set; get; }


        /// <summary>
        /// 用户 ID.
        /// </summary>
        public Guid UserToken { set; get; }


        /// <summary>
        /// 用户  ip 地址.
        /// </summary>
        public string ClientIP { set; get; }


        /// <summary>
        /// 用户端口号.
        /// </summary>
        public int ClientPort { set; get; }



        /// <summary>
        /// 最后访问时间.
        /// </summary>
        public DateTime LastAccessTime { set; get; }




        public override string ToString()
        {
            return String.Format("MyClient[ UserName={0}, UserToken={1}; ClientIP={2}; ClientPort={3}; LastAccessTime={4} ]",
                this.UserName, this.UserToken, this.ClientIP, this.ClientPort, this.LastAccessTime);
        }

    }

}
