using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Odbc;


namespace A0180_MySQL_ODBC.Sample
{


    public class ReadMySQLData
    {


        /// <summary>
        /// MySQL ODBC 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"dsn=MySQLTest";



        /// <summary>
        /// 用于查询的 SQL 语句.
        /// </summary>
        private const String SQL =
            @"
  SELECT
    YEAR(SALE_DATE) AS SALE_DATE,
    SUM(SALE_MONEY) AS SUM_MONEY
  FROM
    SALE_REPORT
  GROUP BY
     YEAR(SALE_DATE)
  ORDER BY
    SUM(SALE_MONEY) DESC";




        /// <summary>
        /// 将数据读取到 DataSet 中.
        /// </summary>
        public void ReadDataToDataSet()
        {

            Console.WriteLine("使用DataAdapter，将数据填充到DataSet中，然后脱离数据库，直接对DataSet进行处理。");

            // 建立数据库连接.
            OdbcConnection conn = new OdbcConnection(connString);

            // 创建一个适配器
            OdbcDataAdapter adapter = new OdbcDataAdapter(SQL, conn);

            // 创建DataSet，用于存储数据.
            DataSet testDataSet = new DataSet();

            // 执行查询，并将数据导入DataSet.
            adapter.Fill(testDataSet, "result_data");

            // 关闭数据库连接.
            conn.Close();

            // 处理DataSet中的每一行数据.
            foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("Date:{0} ; Money:{1}   ",
                    testRow["SALE_DATE"], testRow["SUM_MONEY"]
                    );
            }
        }



        /// <summary>
        /// 通过 Reader， 依次读取每一条数据.
        /// </summary>
        public void ReadDataByReader()
        {
            Console.WriteLine("使用DataReader，逐行对查询结果进行处理。[处理过程必须保持数据库连接正常]");

            // 建立数据库连接.
            OdbcConnection conn = new OdbcConnection(connString);

            // 打开连接.
            conn.Open();

            // 创建一个 Command.
            OdbcCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = SQL;

            // 执行SQL命令，结果存储到Reader中.
            OdbcDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("Date:{0} ; Money:{1}   ",
                    testReader["SALE_DATE"], testReader["SUM_MONEY"]
                    );
            }

            // 关闭Reader.
            testReader.Close();

            // 关闭数据库连接.
            conn.Close();
        }


    }
}
