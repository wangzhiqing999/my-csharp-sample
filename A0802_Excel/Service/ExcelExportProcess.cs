using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;



namespace A0802_Excel.Service
{


    /// <summary>
    /// Excel 报表导出处理类.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExcelExportProcess<T1, T2>
        where T1 : ExcelDataExportFormater<T2>
              
    {
        /// <summary>
        /// 基准的定义得对象.
        /// </summary>
        public T1 ExcelDataExportFormater { set; get; }


        /// <summary>
        /// 创建 Excel 报表.
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="outputFileName"></param>
        public void CreateExcelReport(List<T2> dataList, string outputFileName)
        {
            if (dataList == null
                || dataList.Count == 0
                || dataList[0] == null)
            {
                // 参数为空
                // 或者没有数据
                // 直接返回.
                return;
            }


            // 取得连接字符串.
            String sConnectionString =
                Common.GetOleDbConnectionString(outputFileName);

            // 定义 Oledb 的数据库联接.
            OleDbConnection cn = new OleDbConnection(sConnectionString);

            try
            {
                // 打开连接.
                cn.Open();
                // 首先建表.
                string sqlCreate = ExcelDataExportFormater.GetCreateTableSql();


                // 仅仅当 GetCreateTableSql() 函数返回的字符串
                // 非空的情况下， 才执行
                // 如果返回为空，那么可以认为是目标 Excel 已经有这个表
                // 不需要重复创建了.
                if (!String.IsNullOrEmpty(sqlCreate))
                {
                    OleDbCommand cmd = new OleDbCommand(sqlCreate, cn);
                    // 创建Sheet.
                    cmd.ExecuteNonQuery();
                }


                // 然后插入行.
                OleDbCommand icmd = new OleDbCommand();
                icmd.Connection = cn;
                icmd.CommandText = ExcelDataExportFormater.GetInsertSql();

                foreach (T2 oneData in dataList)
                {
                    // 清空参数.
                    icmd.Parameters.Clear();

                    // 从对象获取参数数组.
                    OleDbParameter[] parameters =
                        ExcelDataExportFormater.GetInsertParameter(oneData);

                    // 遍历填写参数.
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        icmd.Parameters.Add(parameters[i]);
                    }
                    // 执行数据库插入操作.
                    icmd.ExecuteNonQuery();
                }
            }
            finally
            {
                // 执行完毕后，关闭连接.
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

    }



}
