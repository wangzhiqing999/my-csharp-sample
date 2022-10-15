using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;




namespace A0151_Excel.Sample
{

    /// <summary>
    /// 
    /// 这个类的处理机制，与 ReadExcel 的不同点在于。
    /// ReadExcel 是 Excel 读取完了，返回一个 DataSet 的机制。
    /// ExcelDataReader 是 Excel 逐行处理，逐行返回的机制。
    /// <br/>
    /// 实际业务中，会有客户要求 网站上传一个 Excel 文件， 然后将数据导入到 数据库当中。
    /// 
    /// 数据量不大的情况下，比如 几百行的数据，返回 DataSet 没有问题。
    /// 
    /// 但是遇到那种，一个 Excel 里面，列又多，行是几十万行的情况下，读取完了，搞不好就是 1G 以上的内存没有了。
    /// 如果网站是 32位下运行的， 就直接没法玩了。
    /// 
    /// 
    /// 这种情况下，通过 OleDbDataReader， 来 内部逐行 yield return  返回数据，  外部 foreach 逐行处理， 可以减少内存的消耗.
    /// 
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExcelDataReader<T>
    {




        public IEnumerable<T> ReadExcelData(string fileName, string startIndex, bool hasTitle, bool isReadOnly, Func<OleDbDataReader, T> func)
        {
            string sConnectionString = Common.GetOleDbConnectionString(fileName, hasTitle, isReadOnly);

            using (OleDbConnection connection = new OleDbConnection(sConnectionString))
            {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

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

                    OleDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = string.Format("SELECT * FROM [{0}{1}]", tableName, startIndex);

                    using (OleDbDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            T oneResult = func(dataReader);
                            yield return oneResult;
                        }
                    }
                }

            }
        }



    }


}
