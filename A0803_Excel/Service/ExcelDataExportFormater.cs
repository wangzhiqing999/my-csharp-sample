using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;



namespace A0803_Excel.Service
{


    /// <summary>
    /// 可作 Excel 导出的接口.
    /// 
    /// 当 一个数据 对象
    /// 需要创建多种不同格式的 Excel 文件的时候.
    /// 
    /// 
    /// 该接口定义了，系统如何导出 Excel 格式的数据.
    /// 
    /// </summary>
    public interface ExcelDataExportFormater<in T>
    {

        #region 导出的逻辑.

        /// <summary>
        /// 取得建表语句的 SQL.
        /// </summary>
        /// <returns></returns>
        string GetCreateTableSql();

        /// <summary>
        /// 取得插入数据的 SQL.
        /// </summary>
        /// <returns></returns>
        string GetInsertSql();

        /// <summary>
        /// 取得插入数据的参数.
        /// </summary>
        /// <returns></returns>
        OleDbParameter[] GetInsertParameter(T reportData);


        #endregion 导出的逻辑.

    }

}
