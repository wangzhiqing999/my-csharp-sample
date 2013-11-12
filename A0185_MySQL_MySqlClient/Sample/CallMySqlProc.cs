using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using MySql.Data.MySqlClient;


namespace A0185_MySQL_MySqlClient.Sample
{

    /// <summary>
    /// 用于测试  调用 MySql 的存储过程.
    /// </summary>
    class CallMySqlProc
    {


        /// <summary>
        /// MySQL 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"Server=192.168.56.101;Database=Test;Uid=root;Pwd=mysql123";




        public void TestCallProcFunc()
        {
            // 建立数据库连接.
            MySqlConnection conn = new MySqlConnection(connString);


            try
            {
                // 打开连接.
                conn.Open();



                // 测试调用函数.
                CallFunc(conn);


                // 测试执行存储过程.
                // CallProcedure(conn);

                // 调用存储过程  返回结果集
                CallProcedureWithReturnData(conn);

            }
            catch (Exception ex)
            {
                Console.WriteLine("调用存储过程发生了错误！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                // 关闭数据库.
                conn.Close();
            }


        }




        /// <summary>
        /// 测试 调用 MySQL 函数.
        /// </summary>
        private void CallFunc(MySqlConnection conn)
        {
            // 创建一个 Command.
            MySqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "SELECT HelloWorldFunc()";

            // 执行SQL命令，结果存储到Reader中.
            MySqlDataReader testReader = testCommand.ExecuteReader();

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
        /// 测试执行存储过程.
        /// 
        /// 不知道是否是驱动的问题， 直接调用存储过程，总是提示
        /// Procedure or function '`HelloWorld2`' cannot be found in database '`Test`'.
        /// </summary>
        /// <param name="conn"></param>
        private void CallProcedure(MySqlConnection conn)
        {
            // 创建一个 Command.
            MySqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "HelloWorld2";

            // 定义好，本次执行的类型，是存储过程.
            testCommand.CommandType = CommandType.StoredProcedure;

            // 定义要查询的参数.
            // 第一个参数，是输入的.
            MySqlParameter para1 = new MySqlParameter("?vUserName", MySqlDbType.VarChar, 10);
            para1.Value = "HeiHei";
            testCommand.Parameters.Add(para1);

            // 第2个参数，是输出的.
            MySqlParameter para2 = new MySqlParameter("?vOutValue", MySqlDbType.VarChar, 10);
            para2.Direction = ParameterDirection.Output;
            testCommand.Parameters.Add(para2);

            // 第3个参数，是既输入又输出的.
            MySqlParameter para3 = new MySqlParameter("?vInOutValue", MySqlDbType.VarChar, 10);
            para3.Direction = ParameterDirection.InputOutput;
            para3.Value = "HAHA";
            testCommand.Parameters.Add(para3);

            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int insertRowCount = testCommand.ExecuteNonQuery();


            // 存储过程执行完毕后，取得 output 出来的数据.
            String pa2 = testCommand.Parameters["?p_out_val"].Value.ToString();
            String pa3 = testCommand.Parameters["?p_inout_val"].Value.ToString();

            Console.WriteLine("调用 {0} 存储过程之后， p_out_val={1}; p_inout_val={2}", testCommand.CommandText, pa2, pa3);


        }



        /// <summary>
        /// 测试执行存储过程. 返回结果集合.
        /// 
        /// 因为直接使用 CommandType = CommandType.StoredProcedure 的方式调用。 总提示找不到存储过程.
        /// 因此这里 CommandText = "call testProc()"
        /// 
        /// </summary>
        /// <param name="conn"></param>
        private void CallProcedureWithReturnData(MySqlConnection conn)
        {
            // 创建一个 Command.
            MySqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "call testProc()";

            // 定义好，本次执行的类型，是存储过程.
            //testCommand.CommandType = CommandType.StoredProcedure;

            // 执行SQL命令，结果存储到Reader中.
            MySqlDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("调用返回结果集的存储过程:{0}; 返回:{1} - {2}",
                    testCommand.CommandText, testReader[0], testReader[1]
                    );
            }

            // 关闭Reader.
            testReader.Close();
        }



    }


}
