using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using A5300_UDP_P2P.Model;


namespace A5300_UDP_P2P.ServiceImpl
{

    public class DefaultClientManager
    {

        /// <summary>
        /// 用户列表.
        /// </summary>
        private List<MyClient> clientList;



        private DefaultClientManager()
        {
            clientList = new List<MyClient>();
        }


        private static DefaultClientManager me = new DefaultClientManager();


        public static DefaultClientManager GetInstance()
        {
            return me;
        }




        /// <summary>
        /// 登录.
        /// </summary>
        /// <returns></returns>
        public MyClient Login(IPEndPoint ipEndPoint, string userName, string password)
        {

            var query =
                from data in clientList
                where
                    data.UserName== userName
                select
                    data;


            MyClient oldClient = query.FirstOrDefault();
            if (oldClient != null)
            {
                oldClient.LastAccessTime = DateTime.Now;
                return oldClient;
            }
            else
            {
                MyClient newClient = new MyClient()
                {
                    UserName = userName,
                    ClientIP = ipEndPoint.Address.ToString(),
                    ClientPort = ipEndPoint.Port,
                    UserToken = Guid.NewGuid(),
                    LastAccessTime = DateTime.Now,
                };

                clientList.Add(newClient);

                return newClient;
            }


            
        }


        /// <summary>
        /// 登出.
        /// </summary>
        /// <returns></returns>
        public bool Logout(IPEndPoint ipEndPoint, Guid userToken)
        {
            var query =
                from data in clientList
                where
                    data.UserToken == userToken
                select
                    data;


            MyClient oldClient = query.FirstOrDefault();

            if (oldClient != null)
            {

                this.clientList.Remove(oldClient);

                return true;
            }

            return false;
        }



        /// <summary>
        /// 保持激活.
        /// </summary>
        /// <returns></returns>
        public bool KeepAlive(IPEndPoint ipEndPoint, Guid userToken)
        {
            var query =
                from data in clientList
                where
                    data.UserToken == userToken
                select
                    data;


            MyClient oldClient = query.FirstOrDefault();
            if (oldClient != null)
            {
                oldClient.LastAccessTime = DateTime.Now;

                return true;
            }

            return false;
        }



        /// <summary>
        /// 当前 usetToken 是否有效.
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public bool IsActiveToken(Guid userToken)
        {
            var query =
               from data in clientList
               where
                   data.UserToken == userToken
               select
                   data;

            MyClient oldClient = query.FirstOrDefault();
            if (oldClient != null)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 取得用户列表.
        /// </summary>
        /// <returns></returns>
        public List<string> GetUserList()
        {
            var query =
               from data in clientList
               select data.UserName;

            return query.ToList();
        }



        /// <summary>
        /// 取得用户.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MyClient GetUser(string name)
        {
            var query =
              from data in clientList
              where data.UserName == name
              select data;

            return query.FirstOrDefault();
        }



    }

}
