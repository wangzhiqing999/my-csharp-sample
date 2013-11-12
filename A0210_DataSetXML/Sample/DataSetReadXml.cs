using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0210_DataSetXML.Sample
{



    /// <summary>
    /// 这个例子
    ///   用于 演示， 在不调用 ReadXmlSchema 的情况下， 通过自行定义 DataTable 与 DataSet
    ///   实现 DataSet 的 ReadXml 的操作。
    ///   
    /// 
    /// 作为对比，可以参考 A0150_Access 项目下的 ReadAccessDB 类
    /// </summary>
    class DataSetReadXml
    {
        /// <summary>
        /// 读取配置信息.
        /// </summary>
        /// <returns></returns>
        public DataSet ReadConfig(String configFile)
        {
            // 系统检查 DataTable
            DataTable systemCheckDt = new DataTable("SystemCheck");
            // 描述.
            systemCheckDt.Columns.Add("desc");
            // 连接字符串.
            systemCheckDt.Columns.Add("connect_string");
            // 查询语句.
            systemCheckDt.Columns.Add("query");
            // 期望值
            systemCheckDt.Columns.Add("wish_value");


            // 文件复制 DataTable.
            DataTable fileCopyDt = new DataTable("FilesCopy");
            // 文件编号.
            fileCopyDt.Columns.Add("file_id");
            // 文件名称.
            fileCopyDt.Columns.Add("file_name");
            // 源地址.
            fileCopyDt.Columns.Add("copy_from");
            // 目的地址.
            fileCopyDt.Columns.Add("copy_to");

            // 文件复制 DataTable.
            DataTable fileCheckDt = new DataTable("FileCheck");
            fileCheckDt.Columns.Add("check_subject");
            fileCheckDt.Columns.Add("check_file");


            // 邮件 DataTable
            DataTable mailDt = new DataTable("Mail");
            // 邮件编号.
            mailDt.Columns.Add("mail_id");
            // 邮件标题.
            mailDt.Columns.Add("mail_subject");
            // 邮件 收件人.
            mailDt.Columns.Add("mail_to");
            // 邮件 抄送.
            mailDt.Columns.Add("mail_cc");
            // 邮件附件.
            mailDt.Columns.Add("mail_attach");
            // 邮件内容.
            mailDt.Columns.Add("mail_body");
            // 星期.
            mailDt.Columns.Add("week");


            // Excel检查的 DataTable.
            DataTable excelDt = new DataTable("Excel");
            // Excel 文件名.
            excelDt.Columns.Add("excel_file_name");
            // Sheet 名.
            excelDt.Columns.Add("sheet_name");
            // 行
            excelDt.Columns.Add("row");
            // 列
            excelDt.Columns.Add("col");
            // 期望值
            excelDt.Columns.Add("wish_value");


            // Excel 交叉检查的 DataTable
            DataTable mulExcelDt = new DataTable("MulExcel");
            // 描述
            mulExcelDt.Columns.Add("desc");
            // Excel 文件名.
            mulExcelDt.Columns.Add("excel_file_name1");
            // Sheet 名.
            mulExcelDt.Columns.Add("sheet_name1");
            // 行
            mulExcelDt.Columns.Add("row1");
            // 列
            mulExcelDt.Columns.Add("col1");
            // Excel 文件名.
            mulExcelDt.Columns.Add("excel_file_name2");
            // Sheet 名.
            mulExcelDt.Columns.Add("sheet_name2");
            // 行
            mulExcelDt.Columns.Add("row2");
            // 列
            mulExcelDt.Columns.Add("col2");



            // Excel 合并的  DataTable
            DataTable excleCombinationDt = new DataTable("ExcleCombination");
            // 描述
            excleCombinationDt.Columns.Add("desc");
            // 主 Excel 文件.
            excleCombinationDt.Columns.Add("main_excel_file");
            // 主 Excel Sheet.
            excleCombinationDt.Columns.Add("main_excel_sheet");
            // 子 Excel 文件.
            excleCombinationDt.Columns.Add("sub_excel_file");
            // 子 Excel Sheet.
            excleCombinationDt.Columns.Add("sub_excel_sheet");


            // 提醒的 DataTable
            DataTable appointmentDt = new DataTable("Appointment");
            // 描述.
            appointmentDt.Columns.Add("desc");
            // 星期.
            appointmentDt.Columns.Add("week");
            // 日.
            appointmentDt.Columns.Add("day");
            // 消息.
            appointmentDt.Columns.Add("message");


            // 用于返回的 DataSet.
            DataSet ds = new DataSet();

            ds.Tables.Add(systemCheckDt);
            ds.Tables.Add(fileCopyDt);
            ds.Tables.Add(fileCheckDt);
            ds.Tables.Add(mailDt);
            ds.Tables.Add(excelDt);
            ds.Tables.Add(mulExcelDt);
            ds.Tables.Add(excleCombinationDt);
            ds.Tables.Add(appointmentDt);

            // 读取文件.
            ds.ReadXml(configFile);

            // 返回.
            return ds;
        }

    }
}
