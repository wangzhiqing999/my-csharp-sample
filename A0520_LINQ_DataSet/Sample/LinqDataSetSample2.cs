using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0520_LINQ_DataSet.Sample
{

    class LinqDataSetSample2
    {


        /// <summary>
        /// 从 XML 文件中读取数据，形成 DataTable.
        /// 
        /// 参考 A0210_DataSetXML 项目的 DataSetReadXml.cs
        /// </summary>
        /// <returns></returns>
        private static DataSet LoadDataSet()
        {
            // 桔子 DataTable
            DataTable orangeDt = new DataTable("桔子");
            orangeDt.Columns.Add("产地");
            orangeDt.Columns.Add("颜色");
            orangeDt.Columns.Add("味道");
            orangeDt.Columns.Add("品质");

            // 苹果 DataTable
            DataTable appleDt = new DataTable("苹果");
            appleDt.Columns.Add("产地");
            appleDt.Columns.Add("颜色");
            appleDt.Columns.Add("味道");
            appleDt.Columns.Add("品质");

            // 用于返回的 DataSet.
            DataSet ds = new DataSet();

            ds.Tables.Add(orangeDt);
            ds.Tables.Add(appleDt);

            // 读取文件.
            ds.ReadXml("xmlSample.xml");

            // 返回.
            return ds;
        }



        private void ShowRowInfo(IEnumerable<DataRow> dataArray)
        {
            foreach (DataRow data in dataArray)
            {
                Console.WriteLine("==产地:{0};颜色:{1};味道:{2}",
                    data.Field<String>("产地"), data.Field<String>("颜色"), data.Field<String>("味道"));
            }
        }




        private static DataSet dataSource = LoadDataSet();

        private static DataTable apples = dataSource.Tables["苹果"];

        private static DataTable oranges = dataSource.Tables["桔子"];



        /// <summary>
        /// 普通查询.
        /// </summary>
        public void Test1()
        {
            // 定义查询.
            // 这里需要注意： 
            //     DataTable 后面，需要增加一个 .AsEnumerable()
            IEnumerable<DataRow> query =
                from apple in apples.AsEnumerable()
                orderby apple.Field<String>("产地") descending
                select apple;

            // 执行查询.
            IEnumerable<DataRow> dataArray = query.ToArray();

            Console.WriteLine("[01]将 DataTable 中的 苹果， 按照 产地 降序排列后的结果如下：");
            ShowRowInfo(dataArray);

            // 定义查询.
            IEnumerable<DataRow> query2 =
                from orange in oranges.AsEnumerable()
                where orange.Field<String>("产地")  == "中国"
                select orange;

            // 执行查询.
            dataArray = query2.ToArray();

            Console.WriteLine("[01]将 DataTable 中的 桔子， 按照 产地 = 中国 检索后的结果如下：");
            ShowRowInfo(dataArray);
        }


        /**
         * TODO:
         *     Group 与 JOIN  等测试， 暂时还没有测试。  直接用以前章节的 LINQ ， 提示需要强制转换。
         * 
         */ 

    }

}
