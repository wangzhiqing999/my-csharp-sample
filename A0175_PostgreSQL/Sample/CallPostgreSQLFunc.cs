using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Npgsql;

namespace A0175_PostgreSQL.Sample
{

    /// <summary>
    /// 用于写入  PostgreSQL 数据库的例子.
    /// </summary>
    class CallPostgreSQLFunc
    {



        /// <summary>
        /// PostgreSQL 的数据库连接字符串.
        /// 
        /// 访问的是位于 192.168.56.101 这台机器上面的 Test 数据库。
        /// 服务端口是默认的 5432 端口.
        /// 用户名 与密码，都是 test        
        /// </summary>
        private const String connString =
            @"Server=192.168.56.101;Port=5432;User ID=test;Password=test;Database=Test;";






        public void TestCallFuncProc()
        {
            // 建立数据库连接.
            NpgsqlConnection conn = new NpgsqlConnection(connString);

            // 打开连接.
            conn.Open();

            // 调用  函数.
            CallFunc(conn);

            // 调用  返回结果集的函数
            CallFuncWithTable(conn);

            // 调用存储过程
            CallProcedure(conn);

            // 关闭数据库连接.
            conn.Close();
        }



        /// <summary>
        /// 测试 调用  函数.
        /// </summary>
        private void CallFunc(NpgsqlConnection conn)
        {
            // 创建一个 Command.
            NpgsqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "SELECT HelloWorld() ";

            // 执行SQL命令，结果存储到Reader中.
            NpgsqlDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("调用函数:{0}; 返回:{1}",
                    testCommand.CommandText, testReader[0]
                    );
            }

            // 关闭Reader.
            testReader.Close();
        }


        /// <summary>
        /// 测试 调用 返回结果集的函数.
        /// </summary>
        private void CallFuncWithTable(NpgsqlConnection conn)
        {
            // 创建一个 Command.
            NpgsqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "SELECT TestReturnList()";

            // 执行SQL命令，结果存储到Reader中.
            NpgsqlDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("调用函数:{0}; 返回:{1}",
                    testCommand.CommandText, testReader[0]
                    );


                // 注意：
                //   这里的 返回结果集的函数，结果好像只有一列， 与预期的期望值有一些出入.

            }

            // 关闭Reader.
            testReader.Close();
        }



        /// <summary>
        /// 测试执行存储过程.
        /// </summary>
        /// <param name="conn"></param>
        private void CallProcedure(NpgsqlConnection conn)
        {
            // 创建一个 Command.
            NpgsqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "HelloWorld2";

            // 定义好，本次执行的类型，是存储过程.
            testCommand.CommandType = CommandType.StoredProcedure;

            // 定义要查询的参数.
            // 第一个参数，是输入的.
            testCommand.Parameters.Add(new NpgsqlParameter("vUserName", "HeiHei"));

            // 第2个参数，是输出的.
            NpgsqlParameter para2 = new NpgsqlParameter("vOutValue", DbType.String, 10);
            para2.Direction = ParameterDirection.Output;
            testCommand.Parameters.Add(para2);


            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int insertRowCount = testCommand.ExecuteNonQuery();


            // 存储过程执行完毕后，取得 output 出来的数据.
            String pa2 = testCommand.Parameters["vOutValue"].Value.ToString();

            Console.WriteLine("调用 {0} 存储过程之后， vOutValue={1};", testCommand.CommandText, pa2);

        }

    }


}
