using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace A0160_SQL_Server.Sample
{

    /// <summary>
    /// 用于 测试 通过 SCOPE_IDENTITY 函数，
    /// 获取 通过 IDENTITY 自增的 主键的数据值.
    /// </summary>
    public class GetScopeIdentity
    {
        // 建表 SQL.
// CREATE TABLE test_SCOPE_IDENTITY (
//   id   int IDENTITY(1,1) PRIMARY KEY,
//   val VARCHAR(10)
// )

        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";

        /// <summary>
        /// 需要执行的 SQL 语句
        /// 需要注意的是
        /// 这里实际上定义了2条语句
        /// 一条是 INSERT
        /// 一条是 SELECT SCOPE_IDENTITY()
        /// </summary>
        private const String INSERT_SQL =
@"INSERT INTO test_SCOPE_IDENTITY (val) 
VALUES (@val) 
SELECT SCOPE_IDENTITY()";


        /// <summary>
        /// 测试插入数据.
        /// </summary>
        public void TestInsert()
        {
            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);
            // 打开连接.
            conn.Open();
            // 创建一个 Command.
            SqlCommand insertCommand = conn.CreateCommand();
            // 定义需要执行的SQL语句.
            insertCommand.CommandText = INSERT_SQL;
            // 定义要查询的参数.
            insertCommand.Parameters.Add(new SqlParameter("@val", "测试"));
            // 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
            Object oID = insertCommand.ExecuteScalar();
            // 转换为 int 类型.
            int id = Convert.ToInt32(oID);
            // 输出
            Console.WriteLine("新插入的ID为{0}", id);
        }
    }
    
}
