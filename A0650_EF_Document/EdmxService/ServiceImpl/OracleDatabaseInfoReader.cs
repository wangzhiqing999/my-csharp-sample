using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;


using EdmxService.Model;
using EdmxService.Service;

namespace EdmxService.ServiceImpl
{


    /// <summary>
    /// 读取 Oracle 的数据库表结构信息的类.
    /// </summary>
    public class OracleDatabaseInfoReader: IDatabaseInfoReader
    {


        #region 读取表/字段信息的SQL语句


        /// <summary>
        /// 读取表信息的 SQL
        /// </summary>
        private const string READ_TABLE_INFO_SQL = @"SELECT
  TABLE_NAME,
  TABLE_TYPE,
  COMMENTS
FROM
  USER_TAB_COMMENTS";


        /// <summary>
        /// 读取表的列信息的 SQL
        /// </summary>
        private const string READ_TABLE_COLUMN_INFO_SQL = @"SELECT
  TABLE_NAME,
  COLUMN_NAME,
  COMMENTS
FROM
  USER_COL_COMMENTS";


        #endregion




        public List<TableOrViewInfo> ReadAllTableAndViewInfo(string connString)
        {
            // 预期结果.
            List<TableOrViewInfo> resultList = new List<TableOrViewInfo>();


            using (OracleConnection conn = new OracleConnection(connString))
            {
                // 创建DataSet，用于存储数据.
                DataSet resultDataSet = new DataSet();

                // 创建一个适配器
                OracleDataAdapter tableAdapter = new OracleDataAdapter(READ_TABLE_INFO_SQL, conn);
                // 执行查询，并将数据导入DataSet.
                tableAdapter.Fill(resultDataSet, "TableInfo");

                // 创建一个适配器
                OracleDataAdapter tableColumnAdapter = new OracleDataAdapter(READ_TABLE_COLUMN_INFO_SQL, conn);
                // 执行查询，并将数据导入DataSet.
                tableColumnAdapter.Fill(resultDataSet, "TableColumnInfo");




                #region  先加表.

                foreach (DataRow tableRow in resultDataSet.Tables["TableInfo"].Rows)
                {
                    // 依次处理每一个表.
                    TableOrViewInfo tableInfo = new TableOrViewInfo();

                    // 表.
                    tableInfo.IsView = false;
                    // 表名.
                    tableInfo.Name = tableRow["TABLE_NAME"].ToString();
                    // 备注.
                    tableInfo.Comment = tableRow["COMMENTS"].ToString();

                    // 列.
                    tableInfo.ColumnList = new List<ColumnInfo>();


                    // 检索当前表的列.
                    DataRow[] rows = resultDataSet.Tables["TableColumnInfo"].Select("TABLE_NAME='" + tableInfo.Name + "'");

                    for (int i = 0; i < rows.Length; i++)
                    {
                        DataRow row = rows[i];
                        // 读取每一列.
                        ColumnInfo columnInfo = new ColumnInfo();
                        // 列名
                        columnInfo.Name = row["COLUMN_NAME"].ToString();
                        // 备注/说明信息
                        columnInfo.Comment = row["COMMENTS"].ToString();


                        // 列加入表的列List.
                        tableInfo.ColumnList.Add(columnInfo);
                    }

                    // 处理完毕后，表加入结果列表.
                    resultList.Add(tableInfo);
                }

                #endregion


            }


            return resultList;
        }



    }


}
