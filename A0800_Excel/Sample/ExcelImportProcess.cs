using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;


namespace A0800_Excel.Sample
{


    /// <summary>
    /// Excel 报表导入处理类.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExcelImportProcess<T> where T : ExcelImportAble
    {
        /// <summary>
        /// 基准的定义得对象.
        /// </summary>
        public T BaseDefineObject { set; get; }

        /// <summary>
        /// 从 Excel 读取数据列表.
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <returns></returns>
        public List<T> ReadDataFromExcelReport(string inputFileName)
        {
            // 预期结果列表.
            List<T> resultList = new List<T>();

            // 将 Excel 数据读取到 DataSet。
            DataSet ds = ReadExcel(inputFileName);

            // 遍历.
            foreach (DataTable dt in ds.Tables)
            {
                // 数据转换.
                List<ExcelExportAble> dataList = BaseDefineObject.GetDataFromDataTable(dt);
                foreach (ExcelExportAble data in dataList)
                {
                    // 加入最后的结果列表.
                    resultList.Add((T)data);
                }
            }

            // 返回.
            return resultList;
        }


        /// <summary>
        /// 读取 Excel 文件.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private DataSet ReadExcel(string fileName)
        {
            String sConnectionString = Common.GetOleDbConnectionString(fileName);
            OleDbConnection connection = new OleDbConnection(sConnectionString);
            try
            {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand();
                adapter.SelectCommand.Connection = connection;
                DataSet excelData = new DataSet();

                // 结果表索引.
                int resultTableIndex = 0;

                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    DataRow dr = schemaTable.Rows[i];
                    string tableName = dr["TABLE_NAME"].ToString().Trim('\'');
                    if (tableName.IndexOf("$") <= 0
                        || !tableName.EndsWith("$"))
                    {
                        // Sheet 名中不包含 $ 的，或者不是$ 结尾的。忽略.
                        continue;
                    }
                    adapter.SelectCommand.CommandText = string.Format("SELECT * FROM [{0}]", tableName);
                    adapter.Fill(excelData);
                    excelData.Tables[resultTableIndex].TableName = tableName.Replace("$", "");
                    resultTableIndex++;
                }
                return excelData;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }


    }



}
