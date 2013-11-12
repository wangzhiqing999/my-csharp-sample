using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

using A0800_Excel.Sample;


namespace A0800_Excel.Test
{
    public class TestData : ExcelExportAble, ExcelImportAble
    {

        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { set; get; }


        /// <summary>
        /// 城市
        /// </summary>
        public string City { set; get; }


        /// <summary>
        /// 邮编.
        /// </summary>
        public string Zip { set; get; }





        string ExcelExportAble.GetCreateTableSql()
        {
            return @"CREATE TABLE [测试] (
[用户名]  VARCHAR,
[城市]  VARCHAR,
[邮编]  VARCHAR
)";
        }

        string ExcelExportAble.GetInsertSql()
        {
            return @"INSERT INTO [测试] (
[用户名],[城市],[邮编]
) VALUES (
?,?,?
)";
        }

        System.Data.OleDb.OleDbParameter[] ExcelExportAble.GetInsertParameter()
        {
            OleDbParameter[] paramArray = new OleDbParameter[3];

            paramArray[0] = new OleDbParameter("用户名", OleDbType.VarChar);
            if (String.IsNullOrEmpty(this.UserName))
            {
                paramArray[0].Value = "　";
            }
            else
            {
                paramArray[0].Value = this.UserName;
            }

            paramArray[1] = new OleDbParameter("城市", OleDbType.VarChar);
            if (String.IsNullOrEmpty(this.City))
            {
                paramArray[1].Value = "　";
            }
            else
            {
                paramArray[1].Value = this.City;
            }

            paramArray[2] = new OleDbParameter("邮编", OleDbType.VarChar);
            if (String.IsNullOrEmpty(this.Zip))
            {
                paramArray[2].Value = "　";
            }
            else
            {
                paramArray[2].Value = this.Zip;
            }

            return paramArray;
        }




        List<ExcelExportAble> ExcelImportAble.GetDataFromDataTable(System.Data.DataTable dt)
        {
            // 结果列表.
            List<ExcelExportAble> resultList = new List<ExcelExportAble>();

            foreach (DataRow row in dt.Rows)
            {
                TestData myData = new TestData();
                myData.UserName = (String) row["用户名"];
                myData.City = (String)row["城市"];
                myData.Zip = (String)row["邮编"];

                resultList.Add(myData);
            }

            return resultList;
        }
    }
}
