using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;


using A0800_Excel.Test;
using A0801_Excel.Sample;


namespace A0801_Excel.Test
{



    /// <summary>
    /// 当 TestData 对象
    /// 需要创建多种不同格式的 Excel 文件的时候.
    /// 原有的体系结构不支持了.
    /// 
    /// 因为原有的一个数据类 实现一个 ExcelExportAble 接口的
    /// 无法实现数据的处理.
    /// 
    /// </summary>
    public class TestDataPlus : ExcelExportAblePlus<TestData>
    {


        /// <summary>
        /// 本 Excel 表格， 相对于 以前的 TestData 中的表格， 少一列.
        /// </summary>
        /// <returns></returns>
        string ExcelExportAblePlus<TestData>.GetCreateTableSql()
        {
            return @"CREATE TABLE [测试] (
[用户名]  VARCHAR,
[城市]  VARCHAR
)";
        }



        string ExcelExportAblePlus<TestData>.GetInsertSql()
        {
            return @"INSERT INTO [测试] (
[用户名],[城市]
) VALUES (
?,?
)";
        }



        System.Data.OleDb.OleDbParameter[] ExcelExportAblePlus<TestData>.GetInsertParameter(TestData reportData)
        {
            OleDbParameter[] paramArray = new OleDbParameter[2];

            paramArray[0] = new OleDbParameter("用户名", OleDbType.VarChar);
            if (String.IsNullOrEmpty(reportData.UserName))
            {
                paramArray[0].Value = "　";
            }
            else
            {
                paramArray[0].Value = reportData.UserName;
            }

            paramArray[1] = new OleDbParameter("城市", OleDbType.VarChar);
            if (String.IsNullOrEmpty(reportData.City))
            {
                paramArray[1].Value = "　";
            }
            else
            {
                paramArray[1].Value = reportData.City;
            }


            return paramArray;
        }
    }

}
