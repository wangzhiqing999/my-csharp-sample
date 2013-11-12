using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;


using A0803_Excel.Model;
using A0803_Excel.Service;


namespace A0803_Excel.ServiceImpl
{

    class TestDataExcelExportFormater1 : ExcelDataExportFormater<TestData>
    {

        string ExcelDataExportFormater<TestData>.GetCreateTableSql()
        {
            return @"CREATE TABLE [测试] (
[用户名]  VARCHAR,
[城市]  VARCHAR,
[邮编]  VARCHAR
)";
        }

        string ExcelDataExportFormater<TestData>.GetInsertSql()
        {
            return @"INSERT INTO [测试] (
[用户名],[城市],[邮编]
) VALUES (
?,?,?
)";
        }

        System.Data.OleDb.OleDbParameter[] ExcelDataExportFormater<TestData>.GetInsertParameter(TestData reportData)
        {
            OleDbParameter[] paramArray = new OleDbParameter[3];

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

            paramArray[2] = new OleDbParameter("邮编", OleDbType.VarChar);
            if (String.IsNullOrEmpty(reportData.Zip))
            {
                paramArray[2].Value = "　";
            }
            else
            {
                paramArray[2].Value = reportData.Zip;
            }

            return paramArray;
        }
    }
}
