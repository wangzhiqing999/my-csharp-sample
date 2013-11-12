using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MongoDB.Bson;
using MongoDB.Driver;


using MongoDB.Driver.Builders;

using MongoDB.Driver.Linq;

 

namespace A0190_MongoDB.Sample
{

    /// <summary>
    /// Mongo  LINQ 查询的测试.
    /// </summary>
    public class TestMongoLinq
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
            // "TestMain" is the name of the collection
            MongoCollection<TestLinq> collection = database.GetCollection<TestLinq>("TestLinq");







            // ------------------------------
            // 步骤五.   完成  插入、查询、更新、删除 之类的相关操作.
            // ------------------------------

            InsertTestData(collection);
            Console.WriteLine("数据已插入到 MongoDB");
            Console.WriteLine("请到命令行方式下执行 db.TestLinq.find()  核对数据！");
            Console.WriteLine("按回车键继续测试处理...");
            Console.ReadLine();


            // 基础条件查询.
            BasicLinq(collection);


            // 多条件查询.
            MultiCondLinq(collection, null, null, null, null);
            MultiCondLinq(collection, "a", null, null, null);
            MultiCondLinq(collection, "a", null, 9, 10);
            MultiCondLinq(collection, null, "i", 10, 12);


            // 删除数据.
            DeleteTestData(collection);

            Console.WriteLine("完成测试数据删除的处理...");
            Console.WriteLine("请到命令行方式下执行 db.TestLinq.find()  核对数据！");
            Console.WriteLine("按回车键结束测试...");
            Console.ReadLine();

        }



        /// <summary>
        /// 插入测试数据.
        /// </summary>
        private void InsertTestData(MongoCollection<TestLinq> collection)
        {
            TestLinq data1 = new TestLinq()
            {
                FirstName = "Jac",
                LastName = "Lee",
                SeqNumber = 9,
            };

            TestLinq data2 = new TestLinq()
            {
                FirstName = "Kimi",
                LastName = "Qiu",
                SeqNumber = 12,
            };

            TestLinq data3 = new TestLinq()
            {
                FirstName = "Edward",
                LastName = "Wang",
                SeqNumber = 14,
            };

            // 完成插入处理.
            collection.Insert(data1);
            collection.Insert(data2);
            collection.Insert(data3);

        }


        /// <summary>
        /// 删除测试数据.
        /// </summary>
        /// <param name="collection"></param>
        private void DeleteTestData(MongoCollection<TestLinq> collection)
        {

            var query = Query<TestLinq>.GT(p => p.SeqNumber , 0);            
            collection.Remove(query);
        }



        /// <summary>
        /// 基本的 单一条件的  LINQ 查询.
        /// </summary>
        /// <param name="collection"></param>
        private void BasicLinq(MongoCollection<TestLinq> collection)
        {
            // 查询 FirstName 完全匹配.
            var queryFirstName =
                from data in collection.AsQueryable<TestLinq>()
                where data.FirstName == "Jac"
                select data;

            foreach (TestLinq result in queryFirstName)
            {
                Console.WriteLine("查询 FirstName = Jac  ，查询结果 = {0}", result);
            }



            // 模糊查询 LastName
            var queryLastName =
                from data in collection.AsQueryable<TestLinq>()
                where data.LastName.StartsWith("Q")
                select data;

            foreach (TestLinq result in queryLastName)
            {
                Console.WriteLine("查询 LastName LIKE Q%  ，查询结果 = {0}", result);
            }


            // 测试数字 大小.
            var querySeqNo =
                 from data in collection.AsQueryable<TestLinq>()
                 where data.SeqNumber > 13
                 select data;

            foreach (TestLinq result in querySeqNo)
            {
                Console.WriteLine("查询 SeqNumber > 13  ，查询结果 = {0}", result);
            }
        }



        /// <summary>
        /// 多条件查询.
        /// </summary>
        /// <param name="collection"></param>
        private void MultiCondLinq(MongoCollection<TestLinq> collection, 
            string firstName, string lastName, int? minSeqNo, int? maxSeqNo)
        {
            // 初始化查询， 没有任何条件.
            var query =
                from data in collection.AsQueryable<TestLinq>()
                select data;

            if (!String.IsNullOrEmpty(firstName))
            {
                // 如果输入了 firstName
                // 追加条件.
                query =  query.Where(p=>p.FirstName.Contains(firstName));
            }


            if (!String.IsNullOrEmpty(lastName))
            {
                // 如果输入了 firstName
                // 追加条件.
                query = query.Where(p => p.LastName.Contains(lastName));
            }



            if (minSeqNo != null)
            {
                // 如果输入了 最小编号.
                // 追加条件.
                // 注意：如果条件直接写  >=  NullAble 的， 执行将会抱错！
                query = query.Where(p => p.SeqNumber >= minSeqNo.Value);
            }

            if (maxSeqNo != null)
            {
                // 如果输入了 最大编号.
                // 追加条件.
                query = query.Where(p => p.SeqNumber <= maxSeqNo.Value);
            }


            // 输出查询结果
            Console.WriteLine("######动态查询 FirstName:{0}; LastName:{1}; SeqNumber:({2}--{3})",
                firstName, lastName, minSeqNo, maxSeqNo);

            foreach (TestLinq result in query)
            {
                Console.WriteLine("查询结果 = {0}", result);
            }
            Console.WriteLine();

        }
        



    }
}
