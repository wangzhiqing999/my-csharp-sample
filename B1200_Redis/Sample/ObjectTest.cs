using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace B1200_Redis.Sample
{

    /// <summary>
    /// 测试指定对象的存储与获取.
    /// </summary>
    public class ObjectTest : BasicTest
    {

        /// <summary>
        /// 保存自定义类数据到Redis缓存中
        /// </summary>
        /// <param name="keyName">需要保存的键名称</param>
        /// <param name="dataInfo">需要保存的自定义类信息</param>
        /// <returns>返回保存的结果</returns>
        public string SaveTestObjToRedis(string keyName, TestObj dataInfo)
        {
            using (RedisClient client = GetRedisClient())
            {
                if (client == null)
                {
                    return "fail";
                }

                if (client.ContainsKey(keyName))
                {
                    client.Replace<TestObj>(keyName, dataInfo);
                }
                else
                {
                    client.Set<TestObj>(keyName, dataInfo);
                }

                return "success";
            }
        }



        /// <summary>
        /// 从redis缓存中获取自定义类数据.
        /// </summary>
        /// <param name="keyName">缓存中的键名称</param>
        /// <returns>输入键对应的值信息</returns>
        public TestObj LoadTestObjFromRedis(string keyName)
        {
            using (RedisClient client = GetRedisClient())
            {
                if (client == null)
                {
                    return null;
                }
                TestObj configData = client.Get<TestObj>(keyName);
                return configData;
            }
        }


    }



    /// <summary>
    /// 用于测试存储的对象.
    /// </summary>
    [Serializable]
    public class TestObj
    {
        public long Code { set; get; }

        public string Name { set; get; }


        public DateTime LastUpdateTime { set; get; }


        public override string ToString()
        {
            return $"TestObj: Code={Code}; Name={Name}; LastUpdateTime={LastUpdateTime}";
        }
    }
}
