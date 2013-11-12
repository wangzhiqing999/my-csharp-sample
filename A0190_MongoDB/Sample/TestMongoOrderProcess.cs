using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson;
using MongoDB.Driver;

using MongoDB.Driver.Builders;



namespace A0190_MongoDB.Sample
{
    class TestMongoOrderProcess
    {

        public void DoTest()
        {


            // ------------------------------
            // 步骤一.  取得一个  MongoClient  对象.
            // ------------------------------

            // 连接字符串.
            string connectionString = "mongodb://192.168.253.78:30000";
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
            
            // 商品.
            MongoCollection<TestGoods> testGoodsCollection = database.GetCollection<TestGoods>("TestGoods");

            // 订单.
            MongoCollection<TestOrder> testOrderCollection = database.GetCollection<TestOrder>("TestOrder");




            // 插入商品数据.

            List<TestGoods> goodsList = new List<TestGoods>()
            {
                new TestGoods() { GoodsCode = "A001", GoodsName = "苹果", GoodsPrice = 20 },
                new TestGoods() { GoodsCode = "A002", GoodsName = "梨子", GoodsPrice = 10 },
                new TestGoods() { GoodsCode = "A003", GoodsName = "桔子", GoodsPrice = 5 },
                new TestGoods() { GoodsCode = "A004", GoodsName = "葡萄", GoodsPrice = 15 },
                new TestGoods() { GoodsCode = "A005", GoodsName = "芒果", GoodsPrice = 25 },
            };
                        
            // 完成插入商品处理.
            testGoodsCollection.InsertBatch(goodsList);


            Random random = new Random ();

            for (int i = 0; i < 100000; i++)
            {
                List<TestOrder> orderList = new List<TestOrder>()
                {
                    new TestOrder()
                    {
                        CustomerCode = "C00003",
                        CustomerName = "张三",
                        OrderDate = DateTime.Today.AddDays(i % (365 * 3)),
                        OrderDetail = new List<TeseOrderDetail>()
                        {
                            new  TeseOrderDetail() { Id = goodsList[0].Id, GoodsCode = goodsList[0].GoodsCode, GoodsName =goodsList[0].GoodsName, GoodsPrice = goodsList[0].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                            new  TeseOrderDetail() { Id = goodsList[1].Id, GoodsCode = goodsList[1].GoodsCode, GoodsName =goodsList[1].GoodsName, GoodsPrice = goodsList[1].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                            new  TeseOrderDetail() { Id = goodsList[2].Id, GoodsCode = goodsList[2].GoodsCode, GoodsName =goodsList[2].GoodsName, GoodsPrice = goodsList[2].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                            new  TeseOrderDetail() { Id = goodsList[3].Id, GoodsCode = goodsList[3].GoodsCode, GoodsName =goodsList[3].GoodsName, GoodsPrice = goodsList[3].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                            new  TeseOrderDetail() { Id = goodsList[4].Id, GoodsCode = goodsList[4].GoodsCode, GoodsName =goodsList[4].GoodsName, GoodsPrice = goodsList[4].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                        }
                    },

                    new TestOrder()
                    {
                        CustomerCode = "C00004",
                        CustomerName = "李四",
                        OrderDate = DateTime.Today.AddDays(i % (365 * 4)),
                        OrderDetail = new List<TeseOrderDetail>()
                        {
                            new  TeseOrderDetail() { Id = goodsList[0].Id, GoodsCode = goodsList[0].GoodsCode, GoodsName =goodsList[0].GoodsName, GoodsPrice = goodsList[0].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                            new  TeseOrderDetail() { Id = goodsList[2].Id, GoodsCode = goodsList[2].GoodsCode, GoodsName =goodsList[2].GoodsName, GoodsPrice = goodsList[2].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                            new  TeseOrderDetail() { Id = goodsList[4].Id, GoodsCode = goodsList[4].GoodsCode, GoodsName =goodsList[4].GoodsName, GoodsPrice = goodsList[4].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                        }
                    },

                    new TestOrder()
                    {
                        CustomerCode = "C00005",
                        CustomerName = "王五",
                        OrderDate = DateTime.Today.AddDays(i %  (365 * 5)),
                        OrderDetail = new List<TeseOrderDetail>()
                        {
                            new  TeseOrderDetail() { Id = goodsList[1].Id, GoodsCode = goodsList[1].GoodsCode, GoodsName =goodsList[1].GoodsName, GoodsPrice = goodsList[1].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                            new  TeseOrderDetail() { Id = goodsList[3].Id, GoodsCode = goodsList[3].GoodsCode, GoodsName =goodsList[3].GoodsName, GoodsPrice = goodsList[3].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                        }
                    },

                    new TestOrder()
                    {
                        CustomerCode = "C00006",
                        CustomerName = "赵六",
                        OrderDate = DateTime.Today.AddDays(i % (365 * 6)),
                        OrderDetail = new List<TeseOrderDetail>()
                        {
                            new  TeseOrderDetail() { Id = goodsList[0].Id, GoodsCode = goodsList[0].GoodsCode, GoodsName =goodsList[0].GoodsName, GoodsPrice = goodsList[0].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                            new  TeseOrderDetail() { Id = goodsList[4].Id, GoodsCode = goodsList[4].GoodsCode, GoodsName =goodsList[4].GoodsName, GoodsPrice = goodsList[4].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                        }
                    },

                    new TestOrder()
                    {
                        CustomerCode = "C00007",
                        CustomerName = "田七",
                        OrderDate = DateTime.Today.AddDays(i % (365 * 7)),
                        OrderDetail = new List<TeseOrderDetail>()
                        {
                            new  TeseOrderDetail() { Id = goodsList[0].Id, GoodsCode = goodsList[0].GoodsCode, GoodsName =goodsList[0].GoodsName, GoodsPrice = goodsList[0].GoodsPrice, GoodsCount =  random.Next(1, 100)  },
                        }
                    },
                };

                // 插入订单.
                testOrderCollection.InsertBatch(orderList);
            }

            


     
            Console.WriteLine("按回车键结束测试...");
            Console.ReadLine();

        }



        // 处理核对结果：

        /*

        > db.TestGoods.find();
        { "_id" : ObjectId("52577b9370da9a1708ce5345"), "GoodsCode" : "A001", "GoodsName" : "苹果", "GoodsPrice" : 20 }
        { "_id" : ObjectId("52577b9370da9a1708ce5346"), "GoodsCode" : "A002", "GoodsName" : "梨子", "GoodsPrice" : 10 }
        { "_id" : ObjectId("52577b9370da9a1708ce5347"), "GoodsCode" : "A003", "GoodsName" : "桔子", "GoodsPrice" : 5 }
        { "_id" : ObjectId("52577b9370da9a1708ce5348"), "GoodsCode" : "A004", "GoodsName" : "葡萄", "GoodsPrice" : 15 }
        { "_id" : ObjectId("52577b9370da9a1708ce5349"), "GoodsCode" : "A005", "GoodsName" : "芒果", "GoodsPrice" : 25 }



        > db.TestOrder.find().limit(1);
        { "_id" : ObjectId("52577b9370da9a1708ce534a"), 
          "CustomerCode" : "C_00000", 
          "CustomerName" : "张0", 
          "OrderDate" : ISODate("2013-10-10T16:00:00Z"), 
          "OrderDetail" : [    
            {       "_id" : ObjectId("52577b9370da9a1708ce5345"),   "GoodsCode" : "A001",   "GoodsName" : "苹果",   "GoodsPrice" : 20,      "GoodsCount" : 23 },
            {       "_id" : ObjectId("52577b9370da9a1708ce5346"),   "GoodsCode" : "A002",   "GoodsName" : "梨子",   "GoodsPrice" : 10,      "GoodsCount" : 33 },    
            {       "_id" : ObjectId("52577b9370da9a1708ce5347"),   "GoodsCode" : "A003",   "GoodsName" : "桔子",   "GoodsPrice" : 5,       "GoodsCount" : 25 },    
            {       "_id" : ObjectId("52577b9370da9a1708ce5348"),   "GoodsCode" : "A004",   "GoodsName" : "葡萄",   "GoodsPrice" : 15,      "GoodsCount" : 73 },    
            {       "_id" : ObjectId("52577b9370da9a1708ce5349"),   "GoodsCode" : "A005",   "GoodsName" : "芒果",   "GoodsPrice" : 25,      "GoodsCount" : 29 } 
            ] 
        }



        查询 存在有 购买商品数量等于 50 的 顾客代码/姓名.
        > db.TestOrder.find( { "OrderDetail.GoodsCount":50 },  { "CustomerCode" : 1 ,  "CustomerName":1 }  );
        { "_id" : ObjectId("52577b9370da9a1708ce5350"), "CustomerCode" : "C_00006", "CustomerName" : "张6" }

        */



    }
}
