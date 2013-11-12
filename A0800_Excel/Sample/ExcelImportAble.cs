using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace A0800_Excel.Sample
{

    /// <summary>
    /// 可作 Excel 导入的接口.
    /// </summary>
    public interface ExcelImportAble
    {

        #region 导入的逻辑.

        /// <summary>
        /// 数据转换操作.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<ExcelExportAble> GetDataFromDataTable(DataTable dt);

        #endregion 导入的逻辑.

    }

}
