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
    class ReadSqlServerData
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
    TOP 3
    ROW_NUMBER() OVER (ORDER BY SUM(SALE_MONEY) DESC) AS NO,
    SALE_DATE,
    SUM(SALE_MONEY) AS SUM_MONEY
  FROM
    SALE_REPORT
  GROUP BY
    SALE_DATE
  ORDER BY
    SUM(SALE_MONEY) DESC";



        /// <summary>
        /// DataSet 导出的文件
        /// </summary>
        private const String DATATABLE_XML_FILE = "datatable.xml";
        private const String DATATABLE_SCHEMA_XML_FILE = "datatable_schema.xml";



        /// <summary>
        /// 将数据读取到 DataSet 中.
        /// 
        /// 这里演示了2种方式，一种是从数据库中读取，一种是从XML文件中读取.
        /// 
        /// 作为对比，还可以参考 A0210_DataSetXML 项目下的 DataSetReadXml 类，那里的读取方式，与这里有些差异。
        /// </summary>
        public void ReadDataToDataSet()
        {

            Console.WriteLine("使用DataAdapter，将数据填充到DataSet中，然后脱离数据库，直接对DataSet进行处理。");

            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);

            // 创建DataSet，用于存储数据.
            DataSet testDataSet = new DataSet();

            Console.WriteLine("执行第一个 SQL.");
            // 创建一个适配器
            SqlDataAdapter adapter = new SqlDataAdapter(SQL, conn);            
            // 执行查询，并将数据导入DataSet.
            adapter.Fill(testDataSet, "result_data");


            Console.WriteLine("执行第二个 SQL.");
            //  创建另一个适配器（这里主要用于测试 向一个 DateSet 中，写入多个 DataTable ）
            SqlDataAdapter adapter2 = new SqlDataAdapter(@"SELECT TOP 3 * FROM SALE_REPORT", conn);
            // 执行查询，并将数据导入DataSet.
            adapter2.Fill(testDataSet, "result_data2");


            // 关闭数据库连接.
            conn.Close();



            // 处理DataSet中的每一行数据.
            Console.WriteLine("第一个 DataTable.");
            foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("NO:{0} ;  Date:{1} ; Money:{2}   ",
                    testRow["NO"], testRow["SALE_DATE"], testRow["SUM_MONEY"]
                    );
            }

            Console.WriteLine("第二个 DataTable.");
            foreach (DataRow testRow in testDataSet.Tables["result_data2"].Rows)
            {
                Console.WriteLine("Date:{0} ; Money:{1}   ",
                    testRow["SALE_DATE"], testRow["SALE_MONEY"]
                    );
            }



            // 注意：
            //    在通过 DataTable 的 WriteXml 方法来导出数据，给其他系统使用的时候
            //    还需要使用 WriteXmlSchema 来导出 Schema
            //    否则在使用 ReadXml 读取的时候， 会发生错误，因为新的 DataTable 不知道表的结构，不知道该如何去读取.
            //    除非你手动设置好每个列的字段/数据类型等信息，那么 DataSet 或者 DataTable 将能够理解如何倒入，而不在需要 ReadXmlSchema
            Console.WriteLine("将 DataTable 的数据，写入到 XML 文件中。");
            testDataSet.Tables["result_data"].WriteXmlSchema(DATATABLE_SCHEMA_XML_FILE);
            testDataSet.Tables["result_data"].WriteXml(DATATABLE_XML_FILE);


            Console.WriteLine("从 XML 文件中，读取数据到 DataTable 里面。");
            DataTable newDt = new DataTable();
            newDt.ReadXmlSchema(DATATABLE_SCHEMA_XML_FILE);
            newDt.ReadXml(DATATABLE_XML_FILE);

            // 处理DataSet中的每一行数据.
            foreach (DataRow testRow in newDt.Rows)
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("NO:{0} ;  Date:{1} ; Money:{2}   ",
                    testRow["NO"], testRow["SALE_DATE"], testRow["SUM_MONEY"]
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
            SqlConnection conn = new SqlConnection(connString);

            // 打开连接.
            conn.Open();

            // 创建一个 Command.
            SqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = SQL;

            // 执行SQL命令，结果存储到Reader中.
            SqlDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("NO:{0} ;  Date:{1} ; Money:{2}   ",
                    testReader["NO"], testReader["SALE_DATE"], testReader["SUM_MONEY"]
                    );
            }

            // 关闭Reader.
            testReader.Close();

            // 关闭数据库连接.
            conn.Close();
        }




    }


}
