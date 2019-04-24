using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using System.Data.OleDb;


namespace A0151_Excel.Sample
{


	/// <summary>
	/// 读取 Excel 信息.
	/// </summary>
	public class ReadExcel
	{



		/// <summary>
		/// 读取 Excel 文件.
		/// (默认 标题在 第1行)
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public DataSet ReadExcelData(string fileName)
		{
			return ReadExcelData(fileName, String.Empty, true, true);
		}


		/// <summary>
		/// 读取 Excel 文件.
		/// (通过参数，指定标题在 第几行)
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="startIndex"> 标题与内容的区域 例如 A3:X100 </param>
        /// <param name="hasTitle">是否有标题</param>
		/// <returns></returns>
		public DataSet ReadExcelData(string fileName, string startIndex, bool hasTitle, bool isReadOnly)
		{
			String sConnectionString =
                Common.GetOleDbConnectionString(fileName, hasTitle, isReadOnly);

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

					adapter.SelectCommand.CommandText = string.Format("SELECT * FROM [{0}{1}]", tableName, startIndex);


#if DEBUG
					Console.WriteLine("Excel SQL = " + adapter.SelectCommand.CommandText);
#endif

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




        public void TestRead(string fileName, string startIndex, bool hasTitle, bool isReadOnly = true)
		{
            DataSet ds = this.ReadExcelData(fileName, startIndex, hasTitle, isReadOnly);

			foreach (DataTable dt in ds.Tables)
			{
				Console.WriteLine("Sheet名：{0}", dt.TableName);

				foreach (DataColumn col in dt.Columns)
				{
					Console.Write(col.ColumnName);
					Console.Write("\t");
				}
				Console.WriteLine();


				foreach (DataRow row in dt.Rows)
				{
					foreach (DataColumn col in dt.Columns)
					{
						Console.Write( row[col.ColumnName] );
						Console.Write("\t");
					}
					Console.WriteLine();
				}
			}
		}




	}


}
