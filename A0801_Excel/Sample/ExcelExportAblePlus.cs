using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;


using A0800_Excel.Sample;


namespace A0801_Excel.Sample
{


    /// <summary>
    /// 可作 Excel 导出的接口.
    /// 
    /// 当 一个数据 对象
    /// 需要创建多种不同格式的 Excel 文件的时候.
    /// 原有的体系结构不支持了.
    /// 
    /// 因为原有的一个数据类 实现一个 ExcelExportAble 接口的
    /// 无法实现数据的处理.
    /// 
    /// 
    /// 现在将 创建 Excel 表格的定义独立出来， 不依赖于原有接口.
    /// 
    /// 下面的  where T : ExcelExportAble 
    /// 用于测试在 ExcelExportProcessPlus 类中，泛型 中 2个 where 的使用。
    /// 实际应用中可以删除掉.
    /// 
    /// 
    /// </summary>
    public interface ExcelExportAblePlus<in T> where T : ExcelExportAble
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
