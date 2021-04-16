using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ServiceStack.Redis;


namespace B1200_Redis.Sample
{
    public class BasicTest
    {

        protected RedisClient GetRedisClient()
        {
            string host = ConfigurationManager.AppSettings["Redis:Host"];
            string portStr = ConfigurationManager.AppSettings["Redis:Port"];
            string pwd = ConfigurationManager.AppSettings["Redis:Pwd"];
            string dbStr = ConfigurationManager.AppSettings["Redis:Db"];

            int port;
            if(Int32.TryParse(portStr, out port) == false)
            {
                port = 6379;
            }

            int db;
            if (Int32.TryParse(dbStr, out db) == false)
            {
                db = 1;
            }

            RedisClient client = new RedisClient(host, port, pwd, db);

            return client;
        }

    }
}
