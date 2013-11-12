using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


using EdmxService.Model;
using EdmxService.Service;


namespace EdmxService.ServiceImpl
{


    /// <summary>
    /// 读取 SQL Server 2005 的数据库表结构信息的类.
    /// </summary>
    public class Sql2005DatabaseInfoReader : IDatabaseInfoReader
    {



        #region 读取表/字段信息的SQL语句


        /// <summary>
        /// 读取表信息的 SQL
        /// </summary>
        private const string READ_TABLE_INFO_SQL = @"select
  a.name AS TableName,
  isnull(g.[value],'') AS Comment
from
  sys.tables a left join sys.extended_properties g
  on (a.object_id = g.major_id AND g.minor_id = 0)
order by 
  a.name
";

        /// <summary>
        /// 读取表的列信息的 SQL
        /// </summary>
        private const string READ_TABLE_COLUMN_INFO_SQL = @"SELECT
   tab.name AS TableName,
   col.name AS ColumnName,
   col.column_id  AS  ColumnId,
   typ.name as DataType,
   col.max_length AS MaxLength,
   col.precision AS Precision,
   col.Scale AS Scale,
   col.is_nullable  AS IsNullAble,
   col.is_identity  AS IsIDEntity,
   case when exists 
      ( SELECT 1 
        FROM 
          sys.indexes idx 
            join sys.index_columns idxCol 
            on (idx.object_id = idxCol.object_id)
         WHERE
            idx.object_id = col.object_id
            AND idxCol.index_column_id = col.column_id
            AND idx.is_primary_key = 1
       ) THEN 1 ELSE 0 END  AS IsPrimaryKey,
  isnull(prop.[value],'-') AS Comment
FROM
  sys.tables tab left join
  (sys.columns col 
    left join sys.types typ 
      on (col.system_type_id = typ.system_type_id)
    left join sys.extended_properties prop
      on (col.object_id = prop.major_id AND prop.minor_id = col.column_id)
  ) on (tab.object_id = col.object_id)
WHERE
  typ.name != 'sysname'
";



        /// <summary>
        /// 读取视图信息的 SQL
        /// </summary>
        private const string READ_VIEW_INFO_SQL = @"select
  a.name AS ViewName,
  isnull(g.[value],'') AS Comment
from
  sys.views a  
    left join sys.extended_properties g
    on (a.object_id = g.major_id AND g.minor_id = 0)
order by 
  a.name";


        /// <summary>
        /// 读取视图的列信息的 SQL
        /// </summary>
        private const string READ_VIEW_COLUMN_INFO_SQL = @"SELECT
   vie.name AS ViewName,
   col.name AS ColumnName,
   col.column_id  AS  ColumnId,
   typ.name as DataType,
   col.max_length AS MaxLength,
   col.precision AS Precision,
   col.Scale AS Scale,
   col.is_nullable  AS IsNullAble,
   col.is_identity  AS IsIDEntity,
   case when exists 
      ( SELECT 1 
        FROM 
          sys.indexes idx 
            join sys.index_columns idxCol 
            on (idx.object_id = idxCol.object_id)
         WHERE
            idx.object_id = col.object_id
            AND idxCol.index_column_id = col.column_id
            AND idx.is_primary_key = 1
       ) THEN 1 ELSE 0 END  AS IsPrimaryKey,
  isnull(prop.[value],'-') AS Comment
FROM
  sys.views vie left join
  (sys.columns col 
    left join sys.types typ 
      on (col.system_type_id = typ.system_type_id)
    left join sys.extended_properties prop
      on (col.object_id = prop.major_id AND prop.minor_id = col.column_id)
  ) on (vie.object_id = col.object_id)";




        #endregion








        public List<TableOrViewInfo> ReadAllTableAndViewInfo(string connString)
        {
            // 预期结果.
            List<TableOrViewInfo> resultList = new List<TableOrViewInfo>();


            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);




            // 创建DataSet，用于存储数据.
            DataSet resultDataSet = new DataSet();

            // 创建一个适配器
            SqlDataAdapter tableAdapter = new SqlDataAdapter(READ_TABLE_INFO_SQL, conn);
            // 执行查询，并将数据导入DataSet.
            tableAdapter.Fill(resultDataSet, "TableInfo");

            // 创建一个适配器
            SqlDataAdapter tableColumnAdapter = new SqlDataAdapter(READ_TABLE_COLUMN_INFO_SQL, conn);
            // 执行查询，并将数据导入DataSet.
            tableColumnAdapter.Fill(resultDataSet, "TableColumnInfo");


            // 创建一个适配器
            SqlDataAdapter viewAdapter = new SqlDataAdapter(READ_VIEW_INFO_SQL, conn);
            // 执行查询，并将数据导入DataSet.
            viewAdapter.Fill(resultDataSet, "ViewInfo");

            // 创建一个适配器
            SqlDataAdapter viewColumnAdapter = new SqlDataAdapter(READ_VIEW_COLUMN_INFO_SQL, conn);
            // 执行查询，并将数据导入DataSet.
            viewColumnAdapter.Fill(resultDataSet, "ViewColumnInfo");




            #region  先加表.

            foreach (DataRow tableRow in resultDataSet.Tables["TableInfo"].Rows)
            {
                // 依次处理每一个表.
                TableOrViewInfo tableInfo = new TableOrViewInfo();

                // 表.
                tableInfo.IsView = false;
                // 表名.
                tableInfo.Name = tableRow["TableName"].ToString();
                // 备注.
                tableInfo.Comment = tableRow["Comment"].ToString();

                // 列.
                tableInfo.ColumnList = new List<ColumnInfo>();


                // 检索当前表的列.
                DataRow[] rows = resultDataSet.Tables["TableColumnInfo"].Select("TableName='" + tableInfo.Name + "'", "ColumnId");

                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow row = rows[i];
                    // 读取每一列.
                    ColumnInfo columnInfo = new ColumnInfo();
                    // 列名
                    columnInfo.Name = row["ColumnName"].ToString();
                    //// 列的顺序
                    //columnInfo.ColumnId = Convert.ToInt32(row["ColumnId"]);
                    //// 数据类型
                    //columnInfo.DataType = row["DataType"].ToString();
                    //// 占用字节数
                    //columnInfo.MaxLength = Convert.ToInt32(row["MaxLength"]);
                    //// 长度
                    //columnInfo.Precision = Convert.ToInt32(row["Precision"]);
                    //// 小数位数
                    //columnInfo.Scale = Convert.ToInt32(row["Scale"]);
                    //// 是否允许非空
                    //columnInfo.IsNullAble = Convert.ToInt32(row["IsNullAble"]) == 1;
                    //// 是否是自增ID
                    //columnInfo.IsIDEntity = Convert.ToInt32(row["IsIDEntity"]) == 1;
                    //// 是否是主键
                    //columnInfo.IsPrimaryKey = Convert.ToInt32(row["IsPrimaryKey"]) == 1;
                    // 备注/说明信息
                    columnInfo.Comment = row["Comment"].ToString();


                    // 列加入表的列List.
                    tableInfo.ColumnList.Add(columnInfo);
                }

                // 处理完毕后，表加入结果列表.
                resultList.Add(tableInfo);
            }

            #endregion



            #region 后处理视图.


            foreach (DataRow viewRow in resultDataSet.Tables["ViewInfo"].Rows)
            {
                // 依次处理每一个视图.
                TableOrViewInfo viewInfo = new TableOrViewInfo();

                // 视图.
                viewInfo.IsView = true;
                // 视图名.
                viewInfo.Name = viewRow["ViewName"].ToString();
                // 备注.
                viewInfo.Comment = viewRow["Comment"].ToString();

                // 列.
                viewInfo.ColumnList = new List<ColumnInfo>();

                // 检索当前表的列.
                DataRow[] rows = resultDataSet.Tables["ViewColumnInfo"].Select("ViewName='" + viewInfo.Name + "'", "ColumnId");


                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow row = rows[i];
                    // 读取每一列.
                    ColumnInfo columnInfo = new ColumnInfo();
                    // 列名
                    columnInfo.Name = row["ColumnName"].ToString();
                    //// 列的顺序
                    //columnInfo.ColumnId = Convert.ToInt32(row["ColumnId"]);
                    //// 数据类型
                    //columnInfo.DataType = row["DataType"].ToString();
                    //// 占用字节数
                    //columnInfo.MaxLength = Convert.ToInt32(row["MaxLength"]);
                    //// 长度
                    //columnInfo.Precision = Convert.ToInt32(row["Precision"]);
                    //// 小数位数
                    //columnInfo.Scale = Convert.ToInt32(row["Scale"]);
                    //// 是否允许非空
                    //columnInfo.IsNullAble = Convert.ToInt32(row["IsNullAble"]) == 1;
                    //// 是否是自增ID
                    //columnInfo.IsIDEntity = Convert.ToInt32(row["IsIDEntity"]) == 1;
                    //// 是否是主键
                    //columnInfo.IsPrimaryKey = Convert.ToInt32(row["IsPrimaryKey"]) == 1;
                    // 备注/说明信息
                    columnInfo.Comment = row["Comment"].ToString();


                    // 列加入 视图的列List.
                    viewInfo.ColumnList.Add(columnInfo);
                }



                // 处理完毕后，加入结果列表.
                resultList.Add(viewInfo);
            }



            #endregion




            return resultList;
        }




    }


}
