using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace A0800_Excel.Sample
{


    /// <summary>
    /// 可作 Excel 导出的接口.
    /// </summary>
    public interface ExcelExportAble
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
        OleDbParameter[] GetInsertParameter();


        #endregion 导出的逻辑.

    }

}
