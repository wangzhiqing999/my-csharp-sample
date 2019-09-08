using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace A0160_SQL_Server.Sample
{


    /// <summary>
    /// 测试使用 SqlConnectionStringBuilder
    /// </summary>
    class UseSqlConnectionStringBuilder
    {



        /// <summary>
        /// 这里主要的测试目标， 是 传入一个 连接字符串， 能解析出 各个属性的值.
        /// </summary>
        public static void TestUse1()
        {
            Console.WriteLine("----- Test SqlConnectionStringBuilder -----");

            // 测试的链接字符串.
            string connString = @"Data Source=192.168.1.2\MSSQLSERVER,1433;Initial Catalog=TestDb;Uid=sa;Pwd=123456;Connect Timeout=30;Encrypt=False;";


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connString);
           
            Console.WriteLine("ConnectionString = " + builder.ConnectionString);

            Console.WriteLine("DataSource = " + builder.DataSource);
            Console.WriteLine("InitialCatalog = " + builder.InitialCatalog);
            Console.WriteLine("UserID = " + builder.UserID);
            Console.WriteLine("Password = " + builder.Password);
            Console.WriteLine("ConnectTimeout = " + builder.ConnectTimeout);
            Console.WriteLine("Encrypt = " + builder.Encrypt);
        }



        /// <summary>
        /// 这里主要的测试目标， 是 传入各个属性， 能获取一个 连接字符串.
        /// </summary>
        public static void TestUse2()
        {
            Console.WriteLine("----- Test SqlConnectionStringBuilder -----");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = @"localhost\SQLEXPRESS";
            builder.InitialCatalog = "Test";
            builder.UserID = "sa";
            builder.Password = "12345678";
            builder.ConnectTimeout = 30;
            builder.Encrypt = false;
            
            Console.WriteLine("ConnectionString = " + builder.ConnectionString);
        }




    }
}
