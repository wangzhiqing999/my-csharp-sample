using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0520_LINQ_DataSet.Sample
{
    class LinqDataSetSample
    {

        /// <summary>
        /// DataSet 导出的文件
        /// </summary>
        private const String DATATABLE_XML_FILE = "datatable.xml";
        private const String DATATABLE_SCHEMA_XML_FILE = "datatable_schema.xml";


        /// <summary>
        /// 从 XML 文件中读取数据，形成 DataTable.
        /// 
        /// 参考 A0150_Access 项目的 ReadAccessDB.cs
        /// </summary>
        /// <returns></returns>
        private static DataTable LoadDataTable()
        {
            DataTable newDt = new DataTable();
            newDt.ReadXmlSchema(DATATABLE_SCHEMA_XML_FILE);
            newDt.ReadXml(DATATABLE_XML_FILE);
            return newDt;
        }

        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable myDataTable = LoadDataTable();


        /// <summary>
        /// 测试查询.
        /// </summary>
        public void TestQuery1()
        {

            // 定义查询.
            // 这里需要注意： 
            //     DataTable 后面，需要增加一个 .AsEnumerable()
            IEnumerable<DataRow> query =
                from teamMemberType in myDataTable.AsEnumerable()
                orderby teamMemberType.Field<String>("member_type_code") descending
                select teamMemberType;

            // 执行查询.
            IEnumerable<DataRow> dataArray = query.ToArray();

            Console.WriteLine("将 DataTable 中的数据， 按照 member_type_code 降序排列后的结果如下：");
            foreach (DataRow data in dataArray)
            {
                Console.WriteLine("====member_type_code:{0}", data.Field<String>("member_type_code"));
            }



            // 定义查询.
            // 这里需要注意： 
            //     DataTable 后面，需要增加一个 .AsEnumerable()
            IEnumerable<DataRow> query1 =
                from teamMemberType in myDataTable.AsEnumerable()
                where !teamMemberType.Field<String>("member_type_code").StartsWith("TEST")
                orderby teamMemberType.Field<String>("member_type_code") ascending
                select teamMemberType;

            // 执行查询.
            dataArray = query1.ToArray();

            Console.WriteLine("将 DataTable 中的数据， 不是 TEST 开头的，按照 member_type_code 升序排列后的结果如下：");
            foreach (DataRow data in dataArray)
            {
                Console.WriteLine("====member_type_code:{0}", data.Field<String>("member_type_code"));
            }


        }



        


    }
}
