using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace B1200_Redis.Sample
{

    /// <summary>
    /// 测试字符串的存储与获取.
    /// </summary>
    public class StringTest : BasicTest
    {


        /// <summary>
        /// 保存字符串数据到Redis缓存中
        /// </summary>
        /// <param name="keyName">需要保存的键名称</param>
        /// <param name="stringInfo">需要保存的字符串信息</param>
        /// <returns>返回保存的结果</returns>
        public string SaveStringToRedis(string keyName, string stringInfo)
        {
            using (RedisClient client = GetRedisClient())
            {
                if (client == null)
                {
                    return "fail";
                }
                
                if (client.ContainsKey(keyName))
                {
                    client.Replace<string>(keyName, stringInfo);
                }                    
                else
                {
                    client.Set<string>(keyName, stringInfo);
                }

                return "success";
            }
        }



        /// <summary>
        /// 从redis缓存中获取字符串数据.
        /// </summary>
        /// <param name="keyName">缓存中的键名称</param>
        /// <returns>输入键对应的值信息</returns>
        public string LoadStringFromRedis(string keyName)
        {
            using (RedisClient client = GetRedisClient())
            {
                if (client == null)
                {
                    return string.Empty;
                }
                string configData = client.Get<string>(keyName);                
                return configData;                
            }
        }


    }
}
