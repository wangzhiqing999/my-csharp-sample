using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace B1200_Redis.Sample
{

    /// <summary>
    /// 测试 Hash 的存储与获取.
    /// </summary>
    public class HashTest : BasicTest
    {


        /// <summary>
        /// 将哈希存储到 Redis.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="hashInfo"></param>
        /// <returns></returns>
        public string SaveHashToRedis(string keyName, Dictionary<string, string> hashInfo)
        {
            using (RedisClient client = GetRedisClient())
            {
                if (client == null)
                {
                    return "fail";
                }

                client.SetRangeInHash(keyName, hashInfo);

                return "success";
            }
        }



        /// <summary>
        /// 从 Redis 中获取 哈希数据.
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public Dictionary<string, string> LoadHashFromRedis(string keyName)
        {
            using (RedisClient client = GetRedisClient())
            {
                if (client == null)
                {
                    return null;
                }

                Dictionary<string, string> hashResult = client.GetAllEntriesFromHash(keyName);

                return hashResult;
            }
        }




    }
}
