using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MongoDB.Bson;
using MongoDB.Driver;

using MongoDB.Driver.Builders;


//using MongoDB.Driver.GridFS;
//using MongoDB.Driver.Linq;



namespace A0190_MongoDB.Sample
{


    /// <summary>
    /// Mongo 基础的测试.
    /// </summary>
    public class TestMongoBasic
    {

        public void DoTest()
        {


            // ------------------------------
            // 步骤一.  取得一个  MongoClient  对象.
            // ------------------------------

            // mongoDB 安装在 TEST-MONGO1 虚拟机上.
            string connectionString = "mongodb://TEST-MONGO1";
            // 构造客户端.
            MongoClient client = new MongoClient(connectionString);
            




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
            // "TestBasic" is the name of the collection
            MongoCollection<TestBasic> collection = database.GetCollection<TestBasic>("TestBasic");







            // ------------------------------
            // 步骤五.   完成  插入、查询、更新、删除 之类的相关操作.
            // ------------------------------

            TestBasic mainData = new TestBasic()
            {
                Name = "C# 访问 MongoDB 的例子代码",
            };

            // 完成插入处理.
            collection.Insert(mainData);

            // 获取插入后的 id.
            var id = mainData.Id;

            Console.WriteLine("数据 {0} 已插入到 MongoDB", mainData);
            Console.WriteLine("请到命令行方式下执行 db.TestBasic.find()  核对数据！");
            Console.WriteLine("按回车键继续测试处理...");
            Console.ReadLine();



            // 尝试查询.
            var query = Query<TestBasic>.EQ(e => e.Id, id);
            var entity = collection.FindOne(query);

            Console.WriteLine("数据查询结果为： {0}", entity);

            entity.Name = "TEST_UPDATE";
            collection.Save(entity);

            Console.WriteLine("尝试对数据进行更新并保存，更新后结果： {0}", entity);
            Console.WriteLine("请到命令行方式下执行 db.TestBasic.find()  核对数据！");
            Console.WriteLine("按回车键继续测试处理...");
            Console.ReadLine();



            var update = Update<TestBasic>.Set(e => e.Name, "TEST_UPDATE");
            collection.Update(query, update);
            collection.Remove(query);

            Console.WriteLine("完成测试数据删除的处理...");
            Console.WriteLine("请到命令行方式下执行 db.TestBasic.find()  核对数据！");
            Console.WriteLine("按回车键结束测试...");
            Console.ReadLine();

        }




    }

}
