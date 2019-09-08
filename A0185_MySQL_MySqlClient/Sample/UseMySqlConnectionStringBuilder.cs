using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;


namespace A0185_MySQL_MySqlClient.Sample
{
    class UseMySqlConnectionStringBuilder
    {

        /// <summary>
        /// 这里主要的测试目标， 是 传入一个 连接字符串， 能解析出 各个属性的值.
        /// </summary>
        public static void TestUse1()
        {
            Console.WriteLine("----- Test MySqlConnectionStringBuilder -----");

            // 测试的链接字符串.
            string connString = @"Server=192.168.1.3;Database=Test;Uid=root;Pwd=123456;Charset=utf8";


            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(connString);

            Console.WriteLine("ConnectionString = " + builder.ConnectionString);

            Console.WriteLine("Server = " + builder.Server);
            Console.WriteLine("Database = " + builder.Database);
            Console.WriteLine("UserID = " + builder.UserID);
            Console.WriteLine("Password = " + builder.Password);
            Console.WriteLine("ConnectTimeout = " + builder.ConnectionTimeout);
            Console.WriteLine("CharacterSet = " + builder.CharacterSet);
        }



        /// <summary>
        /// 这里主要的测试目标， 是 传入各个属性， 能获取一个 连接字符串.
        /// </summary>
        public static void TestUse2()
        {
            Console.WriteLine("----- Test MySqlConnectionStringBuilder -----");

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

            builder.Server = @"localhost";
            builder.Database = "Test";
            builder.UserID = "root";
            builder.Password = "12345678";
            builder.ConnectionTimeout = 30;
            builder.CharacterSet = "utf8";

            Console.WriteLine("ConnectionString = " + builder.ConnectionString);
        }



    }
}
