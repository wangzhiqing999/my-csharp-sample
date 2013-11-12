using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace A0160_SQL_Server.Sample
{


    /// <summary>
    /// 用于测试，  通过 DataSet 来更新数据库表.
    /// </summary>
    public class UpdateByDataSet
    {


        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";



        public void Test()
        {

            Console.WriteLine("使用 DataSet，来实现对数据库的 新增、编辑、删除 ");


            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();


            // 创建一个 DataAdapter 对象，它表示数据库和 DataSet 对象之间的链接。
            SqlDataAdapter daTest
                = new SqlDataAdapter("Select * From sale_report", conn);

            // DataSet 名字可以自己取一个.
            DataSet dsTest = new DataSet("Test");


            // SqlDataAdapter 类提供 Fill 和 FillSchema 两种方法，这对于加载这些数据很关键。
            // 这两种方法均可将信息加载到 DataSet 中。
            // Fill 加载数据本身，而 FillSchema 加载有关特定表的所有可用的元数据（如列名、主键和约束）。
            // 处理数据加载的正确方式是先运行 FillSchema，后运行 Fill。
            daTest.FillSchema(dsTest, SchemaType.Source, "sale_report");
            daTest.Fill(dsTest, "sale_report");


            // 这些数据此时作为 DataSet 的 Tables 集合内独立的 DataTable 对象来提供。
            // 如果在对 FillSchema 和 Fill 的调用中指定了一个表名，
            // 则可以使用该名称访问您需要的特定表。 
            DataTable dtTest;
            dtTest = dsTest.Tables["sale_report"];


            // 从 DataTable 获取新的 DataRow 对象。
            DataRow drCurrent = dtTest.NewRow();

            // 根据需要设置 DataRow 字段值。
            drCurrent["sale_date"] = DateTime.Today;
            drCurrent["sale_item"] = "T";
            drCurrent["sale_money"] = 100;

            // 将新的对象传递给 DataTable.Rows 集合的 Add 方法。
            dtTest.Rows.Add(drCurrent);


            // 通过 SqlCommandBuilder 设置 DataAdapter 对象的 InsertCommand、UpdateCommand 和 DeleteCommand 属性。
            // 注意：表必须有主键信息
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(daTest);


            // 更新原始数据库，可将 DataSet 传递到 DataAdapter 对象的 Update 方法。
            daTest.Update(dsTest, "sale_report");

            Console.WriteLine("新增测试数据完毕， 去查询一下，数据库是否已经成功新增数据！");
            Console.WriteLine("按回车键继续...");
            Console.ReadLine();



            object[] keyArray = new object[2];
            keyArray[0] = DateTime.Today;
            keyArray[1] = "T";
            drCurrent = dtTest.Rows.Find(keyArray);

            // 要完全删除一行，可使用 DataRow 对象的 Delete 方法。
            drCurrent.Delete();


            daTest.Update(dsTest, "sale_report");
            Console.WriteLine("删除测试数据完毕， 去查询一下，数据库是否已经成功删除数据！");
            Console.WriteLine("按回车键继续...");
            Console.ReadLine();
        }


    }
}
