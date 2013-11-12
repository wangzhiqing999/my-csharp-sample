using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using MongoDB.Bson;
using MongoDB.Driver;

using MongoDB.Driver.Builders;


namespace A0190_MongoDB.Sample
{

    /// <summary>
    /// 测试  Mongo 数据库的  分片.
    /// </summary>
    class TestMongoShard
    {

        public void DoTest()
        {
            // ------------------------------
            // 步骤一.  取得一个  MongoClient  对象.
            // ------------------------------

            // mongoDB 的 mongos 运行在 192.168.253.78:30000 端口上.
            // mongoDB 的3个片 安装在 mongo01 / mongo02 / mongo03  这3台虚拟机上.

            // 因为分片对 最终客户端， 是不可见的。
            // 因此这里的 连接字符串， 仅仅包含 mongos 的地址信息.

            //string connectionString = "mongodb://192.168.253.78:30000";
            //MongoClient client = new MongoClient(connectionString);




            // 下面这种情况, 是用于多个 mongos 进程的情况.
            MongoClientSettings setting = new MongoClientSettings();
            setting.ConnectionMode = ConnectionMode.ShardRouter;

            setting.Servers = new List<MongoServerAddress>() { 
                new MongoServerAddress("192.168.253.78", 30000), 
                new MongoServerAddress("192.168.253.78", 30001) };

            MongoClient client = new MongoClient(setting);






            // ------------------------------
            // 步骤二.  取得一个  MongoServer  对象.
            // ------------------------------
            // Get a Reference to a Server Object
            MongoServer server = client.GetServer();





            // ------------------------------
            // 步骤三.  取得一个  MongoDatabase  对象.
            // ------------------------------
            // Get a Reference to a Database Object
            MongoDatabase database = server.GetDatabase("test"); // "test" is the name of the database





            // ------------------------------
            // 步骤四.   取得一个  MongoCollection  对象.
            // ------------------------------
            // Get a Reference to a Collection Object
            // "TestMain" is the name of the collection
            MongoCollection<TestBasic> collection = database.GetCollection<TestBasic>("TestBasic");







            // ------------------------------
            // 步骤五.   完成  插入的相关操作.
            // ------------------------------


            for (int i = 0; i < 100000; i++)
            {
                TestBasic mainData = new TestBasic()
                {
                    Name = String.Format("C# 访问 MongoDB 的例子代码 {0} : {1:yyyy-MM-dd HH:mm:ss} ", i, DateTime.Now)
                };

                

                // 完成插入处理.
                collection.Insert(mainData);


            }
            
            Console.WriteLine("数据 已插入到 MongoDB");
            Console.WriteLine("请到命令行方式下执行 db.TestBasic.find()  核对数据！");

            Console.WriteLine("请到命令行方式下执行 db.printShardingStatus()  核对数据！");



            Console.WriteLine("按回车键结束测试...");
            Console.ReadLine();

        }
    }
}
