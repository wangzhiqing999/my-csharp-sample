using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace A0170_Oracle.Sample
{


    /// <summary>
    /// 用于 访问 Oracle 数据库 存储过程与函数 的例子。
    /// 
    /// 注意：这个例子所使用的 表 和 数据， 请参考项目下的 Schema.sql 文件。
    /// 
    /// </summary>
    class CallOracleFuncProc
    {
        /// <summary>
        /// Oracle 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.210)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=TEST;Password=TEST123";


        public void TestCallFuncProc()
        {
            // 建立数据库连接.
            OracleConnection conn = new OracleConnection(connString);

            // 打开连接.
            conn.Open();

            // 调用 Oracle 函数.
            CallFunc(conn);

            // 调用 Oracle 返回结果集的函数
            CallFuncWithTable(conn);

            // 调用存储过程
            CallProcedure(conn);

            // 关闭数据库连接.
            conn.Close();
        }



        /// <summary>
        /// 测试 调用 Oracle 函数.
        /// </summary>
        private void CallFunc(OracleConnection conn)
        {
            // 创建一个 Command.
            OracleCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "SELECT HelloWorldFunc() FROM dual";

            // 执行SQL命令，结果存储到Reader中.
            OracleDataReader testReader = testCommand.ExecuteReader();

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
        /// 测试 调用 Oracle 返回结果集的函数.
        /// </summary>
        private void CallFuncWithTable(OracleConnection conn)
        {
            // 创建一个 Command.
            OracleCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "pkg_HelloWorld.getHelloWorld";

            // 定义好，本次执行的类型，是存储过程.
            testCommand.CommandType = CommandType.StoredProcedure;

            // 定义好，我这个参数，是 游标 + 返回值.
            OracleParameter para = new OracleParameter("c", OracleType.Cursor);
            para.Direction = ParameterDirection.ReturnValue;
            testCommand.Parameters.Add(para);


            // 执行SQL命令，结果存储到Reader中.
            OracleDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("调用函数:{0}; 返回:{1} - {2}",
                    testCommand.CommandText, testReader[0], testReader[1]
                    );
            }

            // 关闭Reader.
            testReader.Close();
        }



        /// <summary>
        /// 测试执行存储过程.
        /// </summary>
        /// <param name="conn"></param>
        private void CallProcedure(OracleConnection conn)
        {
            // 创建一个 Command.
            OracleCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "HelloWorld2";

            // 定义好，本次执行的类型，是存储过程.
            testCommand.CommandType = CommandType.StoredProcedure;

            // 定义要查询的参数.
            // 第一个参数，是输入的.
            testCommand.Parameters.Add(new OracleParameter("p_user_name", "HeiHei"));

            // 第2个参数，是输出的.
            OracleParameter para2 = new OracleParameter("p_out_val", OracleType.VarChar, 10);
            para2.Direction = ParameterDirection.Output;
            testCommand.Parameters.Add(para2);

            // 第3个参数，是既输入又输出的.
            OracleParameter para3 = new OracleParameter("p_inout_val", OracleType.VarChar, 20);
            para3.Direction = ParameterDirection.InputOutput;
            para3.Value = "HAHA";
            testCommand.Parameters.Add(para3);

            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int insertRowCount = testCommand.ExecuteNonQuery();


            // 存储过程执行完毕后，取得 output 出来的数据.
            String pa2 = testCommand.Parameters["p_out_val"].Value.ToString();
            String pa3 = testCommand.Parameters["p_inout_val"].Value.ToString();

            Console.WriteLine("调用 {0} 存储过程之后， p_out_val={1}; p_inout_val={2}", testCommand.CommandText, pa2, pa3);

        }

    }
}
