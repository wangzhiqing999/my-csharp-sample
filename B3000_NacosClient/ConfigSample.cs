using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Alibaba.Nacos.Request.Config;
using Com.Alibaba.Nacos.Util;

using Com.Alibaba.Nacos.Failover;


namespace NacosClient
{
    class ConfigSample
    {


        private const string TEST_DATA_ID = "test.net";

        private const string TEST_GROUP = "DEFAULT_GROUP";



        private const string TEST_ENV_NAME = "DEV";



        /// <summary>
        /// 测试获取 配置信息.
        /// </summary>
        public void TestGetConfig()
        {
            GetConfigRequest configRequest = new GetConfigRequest()
            {
                DataId = TEST_DATA_ID,
                Group = TEST_GROUP,                
            };

            var response = configRequest.DoRequest();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }


        /// <summary>
        /// 测试监听配置（立即返回）.
        /// </summary>
        public void TestListenerConfig()
        {
            ListenerConfigRequest listenerConfigRequest = new ListenerConfigRequest()
            {
                DataId = TEST_DATA_ID,
                Group = TEST_GROUP,
                ContentMD5 = "",
            };

            // 这里没有传入 ContentMD5
            // 下面应该是 立即返回， 意思是，数据发生了变化。

            var response = listenerConfigRequest.DoRequest();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }


        /// <summary>
        /// 测试监听配置（延时返回）.
        /// </summary>
        public void TestListenerConfig2()
        {
            // 先获取数据.
            GetConfigRequest configRequest = new GetConfigRequest()
            {
                DataId = TEST_DATA_ID,
                Group = TEST_GROUP,
            };

            var configResponse = configRequest.DoRequest();
            Console.WriteLine(configResponse.StatusCode);
            Console.WriteLine(configResponse.Content);

            // 监听.
            ListenerConfigRequest listenerConfigRequest = new ListenerConfigRequest()
            {
                DataId = TEST_DATA_ID,
                Group = TEST_GROUP,
                ContentMD5 = Md5Util.Md5(configResponse.Content),
            };

            // 数据没有变化的情况下， 30秒后返回空白。
            // 如果去管理页修改数据，将立即返回非空的内容。

            var response = listenerConfigRequest.DoRequest();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }



        /// <summary>
        /// 测试发布配置
        /// </summary>
        public void TestPublishConfig()
        {
            PublishConfigRequest publishConfigRequest = new PublishConfigRequest()
            {
                DataId = TEST_DATA_ID,
                Group = TEST_GROUP,
                Content = "测试 C# 向 Nacos 发布配置！"
            };

            // 这里执行完了，自己去管理页查询，配置是否被记录了。

            var response = publishConfigRequest.DoRequest();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }



        /// <summary>
        /// 测试删除配置.
        /// </summary>
        public void TestDeleteConfig()
        {
            DeleteConfigRequest deleteConfigRequest = new DeleteConfigRequest()
            {
                DataId = TEST_DATA_ID,
                Group = TEST_GROUP,
            };


            // 这里执行完了，自己去管理页查询，配置是否被删除了。

            var response = deleteConfigRequest.DoRequest();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
        }








        /// <summary>
        /// 测试获取 配置信息. 
        /// 如果快照中有，则从快照中加载。
        /// 如果快照中没有，则从服务器加载，然后 存入快照。
        /// </summary>
        public void TestGetConfig2()
        {

            string configValue = LocalConfigInfoProcessor.GetSnapshot(TEST_ENV_NAME, TEST_DATA_ID, TEST_GROUP, "");
            if (!string.IsNullOrEmpty(configValue))
            {
                Console.WriteLine($"Data in Snapshot, Value = {configValue}");
                // return;
            }


            GetConfigRequest configRequest = new GetConfigRequest()
            {
                DataId = TEST_DATA_ID,
                Group = TEST_GROUP,
            };
            var response = configRequest.DoRequest();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);


            Console.WriteLine($"Save Data to Snapshot, Value = {response.Content}");

            // 存入快照.
            LocalConfigInfoProcessor.SaveSnapshot(TEST_ENV_NAME, TEST_DATA_ID, TEST_GROUP, "", response.Content);
        }


    }
}
