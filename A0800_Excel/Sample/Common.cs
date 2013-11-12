using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0800_Excel.Sample
{
    public class Common
    {
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
        /// </summary>
        /// <param name="excelFileName"></param>
        /// <returns></returns>
        public static string GetOleDbConnectionString(string excelFileName)
        {

            // Office 2007 以及 以下版本使用.
            string jetConnString =
              String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", excelFileName);

            // xlsx 扩展名 使用.
            string aceConnXlsxString =
              String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\"", excelFileName);

            // xls 扩展名 使用.
            string aceConnXlsString =
              String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\"", excelFileName);


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
            catch (Exception)
            {
                // 启动 ACE 失败.
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
            catch (Exception)
            {
                // 启动 Jet 失败.
            }


            // 假如 ACE 与 JET 都失败了，默认使用 JET.
            return jetConnString;
        }
        
    }
}
