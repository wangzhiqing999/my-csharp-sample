using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0151_Excel.Sample
{
	public class Common
	{

        #region OLEDB 驱动的选择处理.


        /// <summary>
        /// 取得 OLEDB 的连接字符串.
        /// 优先启动 ACE 驱动，
        /// 假如 ACE 失败，再尝试启动 JET
        ///
        /// 该方法可能用不上。
        /// 因为 在 Office 2010 上面，Jet 与 ACE 都能正常运作
        ///
        /// 唯一需要注意的是， 如果目标机器的操作系统，是64位的话。
        /// 项目需要 编译为 x86， 而不是简单的使用默认的 Any CPU.
		///
		/// 注意：如果目标机器没有 Microsoft.ACE.OLEDB.12.0 驱动，尝试去下面的地址下载.
		/// https://www.microsoft.com/zh-cn/download/confirmation.aspx?id=13255
        /// </summary>
        /// <param name="excelFileName"> Excel 文件.</param>
        /// <param name="hasTitle">Excel 文件是否有标题行. </param>
        /// <param name="isReadonly">是否是只读操作.</param>
        /// <returns></returns>
        public static string GetOleDbConnectionString(string excelFileName, bool hasTitle, bool isReadonly = false)
		{

            
            string optionString = null;
            
            // HDR表示要把第一行作为数据还是作为列名，作为数据用 HDR=no，作为列名用HDR=yes；  
            if (hasTitle)
            {
                optionString = "HDR=yes;";
            }
            else
            {
                optionString = "HDR=no;";
            }


            // 当 IMEX = 0 时为“汇出模式”，这个模式开启的 Excel 档案只能用来做“写入”用途。
            // 当 IMEX = 1 时为“汇入模式”，这个模式开启的 Excel 档案只能用来做“读取”用途。
            // 当 IMEX = 2 时为“连結模式”，这个模式开启的 Excel 档案可同时支援“读取”与“写入”用途。
            if(isReadonly)
            {
                optionString = String.Format("{0};IMEX=1", optionString);
            }
            


            // Office 2007 以及 以下版本使用.
            string jetConnString =
			  String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;" + optionString + "\"", excelFileName);

			// xlsx 扩展名 使用.
			string aceConnXlsxString =
              String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;" + optionString + "\"", excelFileName);

			// xls 扩展名 使用.
			string aceConnXlsString =
              String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;" + optionString + "\"", excelFileName);


			// 默认非 xlsx
			string aceConnString = aceConnXlsString;


			if (excelFileName.EndsWith(".xlsx", StringComparison.CurrentCultureIgnoreCase))
			{
				// 如果扩展名为 xlsx.
				// 那么需要将 驱动切换为 xlsx 扩展名 的.
				aceConnString = aceConnXlsxString;
			}

			// 尝试使用 ACE. 假如不发生错误的话，使用 ACE 驱动.
			try
			{
				System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection(aceConnString);
				cn.Open();
				cn.Close();
				// 使用 ACE
				return aceConnString;
			}
			catch (Exception e)
			{
				// 启动 ACE 失败.
                //Console.WriteLine(e.Message);
			}


			// 尝试使用 Jet. 假如不发生错误的话，使用 Jet 驱动.
			try
			{
				System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection(jetConnString);
				cn.Open();
				cn.Close();
				// 使用 Jet
				return jetConnString;
			}
			catch (Exception e)
			{
				// 启动 Jet 失败.
                //Console.WriteLine(e.Message);
			}


			// 假如 ACE 与 JET 都失败了，默认使用 JET.
			return jetConnString;
		}


        /// <summary>
        /// 默认 认为 Excel 数据文件是包含 列名的.
        /// </summary>
        /// <param name="excelFileName"></param>
        /// <returns></returns>
        public static string GetOleDbConnectionString(string excelFileName)
        {
            
            return GetOleDbConnectionString(excelFileName, true);
        }



		#endregion



	}
}
