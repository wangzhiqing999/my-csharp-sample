using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace A0802_Excel.Service
{


    /// <summary>
    /// 可作 Excel 导入的接口.
    /// 
    /// 当 一个数据 对象
    /// 需要从多种不同格式的 Excel 文件 导入的时候.
    /// 
    /// 
    /// 该接口定义了，系统如何导入 Excel 格式的数据.
    /// 
    /// </summary>
    public interface ExcelDataImportFormater<T>
    {

        #region 导入的逻辑.

        /// <summary>
        /// 数据转换操作.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<T> GetDataFromDataTable(DataTable dt);


        #endregion 导入的逻辑.

    }



}

