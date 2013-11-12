using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;

namespace A0165_SQL_Server_Oracle.Sample
{

    /// <summary>
    /// 测试在一个事务中
    /// 调用 Oracle 与 SQL Server 的存储过程.
    /// </summary>
    class TestCallTwoProcedure
    {

        /// <summary>
        /// Oracle 的数据库连接字符串.
        /// 
        /// 注：这里的 enlist=false，那么意味着后续的事务不会在当前事务中登记，所以当前事务不会成为事务的根。
        /// 因此要先执行 SQL Server 的存储过程，  后执行 Oracle 的。
        /// 
        /// 如果删除掉 enlist=false， 或者修改为 enlist=true, 那么运行时可能会报 “无法加载 OraMTS”的错误！
        /// </summary>
        private const String Oracle_connString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.56.102)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=TEST;Password=TEST;enlist=false";


        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// </summary>
        private const String SqlServer_connString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";





        /// <summary>
        /// 调用存储过程.
        /// </summary>
        /// <param name="sqlserverParam"></param>
        /// <param name="oracleParam"></param>        
        public void TestCall(int sqlserverParam, int oracleParam)
        {
            Console.WriteLine("TestCall({0}, {1}) Start!", sqlserverParam, oracleParam);
            try
            {
                // 开始事务.
                using (TransactionScope scope = new TransactionScope())
                {
                    // 处理 SQL Server.
                    using (SqlConnection connSqlServer = new SqlConnection(SqlServer_connString))
                    {

                        connSqlServer.Open();
                        // 创建一个 Command.
                        SqlCommand sqlServerCommand = connSqlServer.CreateCommand();
                        // 定义需要执行的SQL语句.
                        sqlServerCommand.CommandText = "test_SqlServer_Proc";
                        // 定义好，本次执行的类型，是存储过程.
                        sqlServerCommand.CommandType = CommandType.StoredProcedure;
                        // 定义要查询的参数.
                        sqlServerCommand.Parameters.Add(new SqlParameter("@Param", sqlserverParam));

                        // 执行存储过程.
                        Console.WriteLine("尝试调用 SQL Server 的存储过程，参数={0}", sqlserverParam);
                        int sqlServerRowCount = sqlServerCommand.ExecuteNonQuery();
                        Console.WriteLine("调用 SQL Server 的存储过程，参数={0}, 更新行数={1}", sqlserverParam, sqlServerRowCount);




                        // 处理 Oracle.
                        using (OracleConnection connOracle = new OracleConnection(Oracle_connString))
                        {
                            connOracle.Open();
                            // 创建一个 Command.
                            OracleCommand oracleCommand = connOracle.CreateCommand();
                            // 定义需要执行的SQL语句.
                            oracleCommand.CommandText = "test_Oracle_Proc";
                            // 定义好，本次执行的类型，是存储过程.
                            oracleCommand.CommandType = CommandType.StoredProcedure;
                            // 定义要查询的参数.
                            oracleCommand.Parameters.Add(new OracleParameter("p_param", oracleParam));

                            // 执行存储过程.
                            Console.WriteLine("尝试调用 Oracle 的存储过程，参数={0}", oracleParam);
                            int oracleRowCount = oracleCommand.ExecuteNonQuery();
                            Console.WriteLine("调用 Oracle 的存储过程，参数={0}, 更新行数={1}", oracleParam, oracleRowCount);
                        }
                    }

                    // 完成事务.
                    scope.Complete();
                }

            }
            catch (TransactionAbortedException ex)
            {
                Console.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("ApplicationException Message: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("执行发生异常: {0}", ex.Message);
            }

            Console.WriteLine("TestCall({0}, {1}) Finish!", sqlserverParam, oracleParam);


            // 查询 SQL Server
            using (SqlConnection connSqlServer = new SqlConnection(SqlServer_connString))
            {
                connSqlServer.Open();
                Console.WriteLine("SQL Server 数据库 Test_Trans 表行数 = {0}", GetExecResult(connSqlServer));
            }

            // 查询 Oracle.
            using (OracleConnection connOracle = new OracleConnection(Oracle_connString))
            {
                connOracle.Open();
                Console.WriteLine("Oracle 数据库 Test_Trans 表行数 = {0}", GetExecResult(connOracle));
            }

        }


        /// <summary>
        /// 获取数据库的 Test_Trans 表的行数.
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        private int GetExecResult(IDbConnection conn)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(1) FROM Test_Trans";
            // 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
            Object oRowCount = cmd.ExecuteScalar();
            return Convert.ToInt32(oRowCount);
        }

    }
}
