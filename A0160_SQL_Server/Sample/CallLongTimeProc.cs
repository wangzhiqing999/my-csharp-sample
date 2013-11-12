using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace A0160_SQL_Server.Sample
{

    /// <summary>
    /// 用于 访问 SQL Server 数据库  长时间运行的存储过程 的例子。
    /// 
    /// 注意：这个例子所使用的 表 和 数据， 请参考项目下的 Schema.sql 文件。
    /// 
    /// </summary>
    public class CallLongTimeProc
    {

        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// 
        /// 注意: 使用 异步处理的时候, 需要增加   Asynchronous Processing=true
        /// </summary>
        private const String connString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;Asynchronous Processing=true";


        public void TestCallLongTimeProc()
        {
            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);

            // 打开连接.
            conn.Open();


            // 调用存储过程
            CallProcedure(conn);


            // 关闭数据库连接.
            conn.Close();

        }



        /// <summary>
        /// 测试执行存储过程.
        /// </summary>
        /// <param name="conn"></param>
        private void CallProcedure(SqlConnection conn)
        {
            // 创建一个 Command.
            SqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = "HelloWorldLongTime";

            // 定义好，本次执行的类型，是存储过程.
            testCommand.CommandType = CommandType.StoredProcedure;

            // 定义要查询的参数.
            // 第一个参数，是输入的.
            testCommand.Parameters.Add(new SqlParameter("@UserName", "HeiHei"));

            // 第2个参数，是输出的.
            SqlParameter para2 = new SqlParameter("@OutVal", SqlDbType.VarChar, 10);
            para2.Direction = ParameterDirection.Output;
            testCommand.Parameters.Add(para2);

            // 第3个参数，是既输入又输出的.
            SqlParameter para3 = new SqlParameter("@InoutVal", SqlDbType.VarChar, 20);
            para3.Direction = ParameterDirection.InputOutput;
            para3.Value = "HAHA";
            testCommand.Parameters.Add(para3);


            Console.WriteLine("Before Call BeginExecuteNonQuery...");

            // BeginExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 异步调用存储过程。
            // 语句执行完毕后，将立即返回.
            IAsyncResult result = testCommand.BeginExecuteNonQuery();

            Console.WriteLine("After Call BeginExecuteNonQuery...");

            int count = 0;
            while (!result.IsCompleted)
            {
                Console.WriteLine("Waiting ({0})", count++);
                // 等待1分钟
                System.Threading.Thread.Sleep(60000);
            }

            // BeginExecuteNonQuery 方法启动异步执行不返回行的 Transact-SQL 语句或存储过程的进程，
            // 因此，在执行语句的同时可以并发运行其他任务。
            // 当语句完成后，开发人员必须调用 EndExecuteNonQuery 方法以完成操作
            testCommand.EndExecuteNonQuery(result);


            // 存储过程执行完毕后，取得 output 出来的数据.
            String pa2 = testCommand.Parameters["@OutVal"].Value.ToString();
            String pa3 = testCommand.Parameters["@InoutVal"].Value.ToString();

            Console.WriteLine("调用 {0} 存储过程之后， @OutVal={1}; @InoutVal={2}", testCommand.CommandText, pa2, pa3);

        }


    }
}
