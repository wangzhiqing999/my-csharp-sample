using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0160_SQL_Server.Sample
{

    /// <summary>
    /// 用于 读取 SQL Server 数据库 的例子.
    /// 
    /// 注意：这个例子所使用的 表 和 数据， 请参考项目下的 Schema.sql 文件。
    /// 
    /// </summary>
    class ReadSqlServerDataIn
    {

        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";


        /// <summary>
        /// 用于查询的 SQL 语句.
        /// </summary>
        private const String SQL =
            @"
  SELECT
    TOP 10
    sale_item,
    SALE_DATE,
    SALE_MONEY
  FROM
    SALE_REPORT
  WHERE
    sale_item  IN  (@Item)
";




        /// <summary>
        /// 通过 Reader， 依次读取每一条数据.
        /// </summary>
        public void ReadDataByReader()
        {
            Console.WriteLine("测试  Parameters 里面， IN 的处理.");

            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);

            // 打开连接.
            conn.Open();

            // 创建一个 Command.
            SqlCommand testCommand = conn.CreateCommand();

            



            string[] testItem = { "A", "B", "C" };

            StringBuilder buff = new StringBuilder();
            for (int i = 0; i < testItem.Length; i++)
            {
                string paramName = String.Format("@Item{0}", i);
                buff.AppendFormat("{0},", paramName);
                testCommand.Parameters.AddWithValue(paramName, testItem[i]);
            }
            buff.Length--;

            // 定义需要执行的SQL语句.
            testCommand.CommandText = SQL.Replace("@Item", buff.ToString());




            // 执行SQL命令，结果存储到Reader中.
            SqlDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("sale_item:{0} ;  Date:{1} ; Money:{2}   ",
                    testReader["sale_item"], testReader["SALE_DATE"], testReader["SALE_MONEY"]
                    );
            }

            // 关闭Reader.
            testReader.Close();

            // 关闭数据库连接.
            conn.Close();
        }




    }


}
