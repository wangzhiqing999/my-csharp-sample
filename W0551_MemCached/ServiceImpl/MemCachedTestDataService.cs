using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;


using Enyim.Caching;
using Enyim.Caching.Memcached;


using W0551_MemCached.Model;
using W0551_MemCached.Service;


namespace W0551_MemCached.ServiceImpl
{


    public class MemCachedTestDataService : ITestDataService
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// Memcached
        /// </summary>
        private static MemcachedClient client = new MemcachedClient("enyim.com/memcached");


        /// <summary>
        /// 实际的服务.
        /// </summary>
        private ITestDataService realService = new DefaultTestDataService();


        public MemCachedTestDataService()
        {
            // 仅仅当发生连接故障的情况下， 才加下面这句话.
            // LogManager.AssignFactory(new DiagnosticsLogFactory(@".\MemCached.Log"));
        }


        



        /// <summary>
        /// 查询用户信息.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public TestData GetTestDataByUserName(string userName)
        {
            // 尝试从 MemCached 中获取数据.
            TestData result = client.Get<TestData>(userName);

            if (result != null)
            {
                logger.InfoFormat("从 MemCahced 中，通过关键字 {0}, 查询到数据 {1}", userName, result);
            }


            if (result == null)
            {
                // MemCached 中没有数据， 尝试 加载.
                result = realService.GetTestDataByUserName(userName);

                if (result != null)
                {
                    // MemCached 中没有，数据库中有， 尝试加入MemCached.
                    // 过期时间.
                    DateTime absoluteExpiration = DateTime.Now.AddMinutes(30);

                    // 指定过期方式。 加入 Memcache.
                    client.Store(StoreMode.Add, userName, result, absoluteExpiration);
                }
            }

            // 返回.
            return result;
        }


        /// <summary>
        /// 新增一个用户.
        /// </summary>
        /// <param name="data"></param>
        public void InsertTestData(TestData data)
        {
            realService.InsertTestData(data);
        }



        /// <summary>
        /// 更新用户.
        /// </summary>
        /// <param name="data"></param>
        public void UpdateTestData(TestData data)
        {
            realService.UpdateTestData(data);

            // 判断缓存里面有没有， 如果有， 那么需要更新缓存内容.
            // 尝试从 MemCached 中获取数据.
            TestData cachedData = client.Get<TestData>(data.UserName);

            if (cachedData != null)
            {
                // 过期时间.
                DateTime absoluteExpiration = DateTime.Now.AddMinutes(30);
                // 指定过期方式。 加入 Memcache.
                client.Store(StoreMode.Replace, data.UserName, data, absoluteExpiration);
            }
        }



        /// <summary>
        /// 删除用户.
        /// </summary>
        /// <param name="data"></param>
        public void DeleteTestData(string userName)
        {
            realService.DeleteTestData(userName);


            // 判断缓存里面有没有， 如果有， 那么需要更新缓存内容.
            // 尝试从 MemCached 中获取数据.
            TestData cachedData = client.Get<TestData>(userName);

            if (cachedData != null)
            {
                client.Remove(userName);
            }
        }
    }
}