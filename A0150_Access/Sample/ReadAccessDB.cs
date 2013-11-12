using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0150_Access.Sample
{


    /// <summary>
    /// 用于 访问 Access 数据库的例子.
    /// 
    /// 
    /// </summary>
    class ReadAccessDB
    {

        /// <summary>
        /// Access 的数据库连接字符串.
        /// </summary>
        private const String connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\TeamMemberManager.mdb";

        /// <summary>
        /// 用于查询的 SQL 语句.
        /// </summary>
        private const String SQL = "SELECT member_type_code, member_type_name FROM team_member_type";


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
            OleDbConnection conn = new OleDbConnection(connString);

            // 创建一个适配器
            OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, conn);

            // 创建DataSet，用于存储数据.
            DataSet testDataSet = new DataSet();

            // 执行查询，并将数据导入DataSet.
            adapter.Fill(testDataSet, "team_member_type");

            // 关闭数据库连接.
            conn.Close();
            


            // 处理DataSet中的每一行数据.
            foreach (DataRow testRow in testDataSet.Tables["team_member_type"].Rows)
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("ID: {0}   Name: {1}",
                    testRow["member_type_code"], testRow["member_type_name"]
                    );
            }



            // 注意：
            //    在通过 DataTable 的 WriteXml 方法来导出数据，给其他系统使用的时候
            //    还需要使用 WriteXmlSchema 来导出 Schema
            //    否则在使用 ReadXml 读取的时候， 会发生错误，因为新的 DataTable 不知道表的结构，不知道该如何去读取.
            //    除非你手动设置好每个列的字段/数据类型等信息，那么 DataSet 或者 DataTable 将能够理解如何倒入，而不在需要 ReadXmlSchema
            Console.WriteLine("将 DataTable 的数据，写入到 XML 文件中。");
            testDataSet.Tables["team_member_type"].WriteXmlSchema(DATATABLE_SCHEMA_XML_FILE);
            testDataSet.Tables["team_member_type"].WriteXml(DATATABLE_XML_FILE);


            Console.WriteLine("从 XML 文件中，读取数据到 DataTable 里面。");
            DataTable newDt = new DataTable();
            newDt.ReadXmlSchema(DATATABLE_SCHEMA_XML_FILE);
            newDt.ReadXml(DATATABLE_XML_FILE);


            // 输出 DataTable 信息。
            foreach (DataRow testRow in newDt.Rows)
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("ID: {0}   Name: {1}",
                    testRow["member_type_code"], testRow["member_type_name"]
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
            OleDbConnection conn = new OleDbConnection(connString);

            // 打开连接.
            conn.Open();

            // 创建一个 Command.
            OleDbCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = SQL;

            // 执行SQL命令，结果存储到Reader中.
            OleDbDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("ID: {0}   Name: {1}",
                    testReader["member_type_code"], testReader["member_type_name"]
                    );
            }

            // 关闭Reader.
            testReader.Close();

            // 关闭数据库连接.
            conn.Close();

        }

    }


}
