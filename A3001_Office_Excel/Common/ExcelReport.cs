using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Excel = Microsoft.Office.Interop.Excel;


namespace A3001_Office_Excel.Common
{

    /// <summary>
    /// Excel 公式.
    /// 等价于 Excel.XlFormatConditionOperator
    /// </summary>
    public enum ExcelFormatConditionOperator
    {
        xlBetween = 1,
        xlNotBetween = 2,
        xlEqual = 3,
        xlNotEqual = 4,
        xlGreater = 5,
        xlLess = 6,
        xlGreaterEqual = 7,
        xlLessEqual = 8,
    }



    /// <summary>
    /// Excel 报表处理类.
    /// </summary>
    public class ExcelReport
    {

        /// <summary>
        /// Excel App.
        /// </summary>
        private Excel.Application xlApp;

        /// <summary>
        /// Excel 工作簿.
        /// </summary>
        private Excel.Workbook xlBook = null;

        /// <summary>
        /// Excel 工作表.
        /// </summary>
        private Excel.Worksheet xlSheet = null;

        /// <summary>
        /// 打开 Excel.
        /// </summary>
        public void OpenExcel()
        {
            // 启动 Excel.
            xlApp = new Excel.Application();

#if DEBUG

            // 可见/不可见.
            xlApp.Visible = true;
#else

            // 可见/不可见.
            xlApp.Visible = false;
#endif


            xlApp.UserControl = true;
            xlApp.DisplayAlerts = true;
        }


        /// <summary>
        /// 退出 Excel.
        /// </summary>
        public void CloseExcel()
        {
            xlApp.DisplayAlerts = false;
            xlApp.Workbooks.Close();
            xlApp.Quit();
        }


        /// <summary>
        /// 打开 Excel 文件.
        /// </summary>
        /// <param name="excelFile"></param>
        public void OpenExcelFile(String excelFile)
        {
            // 打开文件.
            xlBook = xlApp.Workbooks.Open(excelFile);

            // 取得第一个 Sheet.
            foreach (Excel.Worksheet displayWorksheet in xlBook.Sheets)
            {
                xlSheet = displayWorksheet;
                break;
            }
        }





        #region 打印用的方法.


        /// <summary>
        /// 设置需要把文件打印到哪一个打印机上去.
        /// </summary>
        /// <param name="printName"></param>
        public void SetPrintName(string printName)
        {
            xlApp.ActivePrinter = printName;
        }



        /// <summary>
        /// 设置打印区域.
        /// </summary>
        public void SetPrintArea(string printArea)
        {
            xlSheet.PageSetup.PrintArea = printArea;
        }


        /// <summary>
        /// 打印.
        /// </summary>
        public void Print()
        {
            xlSheet.PrintOut();
        }


        /// <summary>
        /// 打印预览.
        /// </summary>
        private void PrintPreview()
        {
            xlSheet.PrintPreview();
        }


        #endregion




        /// <summary>
        /// 保存 Excel 文件.
        /// </summary>
        public void SaveExcelFile()
        {
            xlBook.Save();

        }

        /// <summary>
        /// 另存为 Excel 文件.
        /// </summary>
        public void SaveAsExcelFile(String asFileName)
        {
            xlBook.SaveCopyAs(asFileName);
        }


        /// <summary>
        /// 关闭 Excel 文件.
        /// </summary>
        public void CloseExcelFile()
        {
            xlBook.Close(false, false, false);
        }


        /// <summary>
        /// 选择工作表.
        /// </summary>
        /// <param name="sheetName"></param>
        public void SelectSheet(String sheetName)
        {
            // 选择工作表.
            xlSheet = (Excel.Worksheet)xlBook.Sheets.get_Item(sheetName);

            xlSheet.Activate();
        }


        /// <summary>
        /// 更新数据透视表数据.
        /// </summary>
        /// <param name="dataSheerName">数据Sheet名</param>
        /// <param name="pivotSheetName">报表Sheet名</param>
        /// <param name="PivotName">数据透视表名</param>
        public void AddPivotTable(string dataSheerName, string pivotSheetName, string PivotName = "数据透视表1")
        {
            // 首先定位到 数据的 Sheet. 设定 数据透视表的 的数据源.
            xlSheet = null;
            foreach (Excel.Worksheet displayWorksheet in xlBook.Sheets)
            {
                if (dataSheerName == displayWorksheet.Name)
                {
                    xlSheet = displayWorksheet;
                    break;
                }
            }

            if (xlSheet != null)
            {
                // 取得数据的Sheet的行数与列数
                int rowCount = xlSheet.UsedRange.Rows.Count;
                int colCount = xlSheet.UsedRange.Columns.Count;

                // 拼写好 数据源的名字，准备后面用于更新 数据透视表的数据源.
                string sourceData = dataSheerName + "!R1C1:R" + rowCount + "C" + colCount;

                // 然后定位到 数据透视表的 Sheet. 刷新数据.
                xlSheet = null;
                foreach (Excel.Worksheet displayWorksheet in xlBook.Sheets)
                {
                    if (pivotSheetName == displayWorksheet.Name)
                    {
                        xlSheet = displayWorksheet;
                        break;
                    }
                }

                if (xlSheet != null)
                {
                    // 修改 Excel 文件中 数据透视表的 数据源
                    ((Excel.PivotTable)xlSheet.PivotTables(PivotName)).SourceData = sourceData;
                    // 刷新数据 : 重新计算 数据透视表数据
                    ((Excel.PivotTable)xlSheet.PivotTables(PivotName)).Update();
                }

            }
        }





        #region 设置/获取 单元格数据.


        /// <summary>
        /// 设置公式.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="val"></param>
        public void SetFormulaR1C1(int row, int col, string val)
        {
            xlSheet.Cells[row, col].FormulaR1C1 = val;
        }


        /// <summary>
        /// 设置公式. (为零的时候，不显示)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="val"></param>
        public void SetFormulaR1C1ZeroNotDisplay(int row, int col, string val)
        {
            String tmpVal = val.Substring(1);
            String formula = String.Format("=IF({0}= 0, \"\", {1})", tmpVal, tmpVal);

            xlSheet.Cells[row, col].FormulaR1C1 = formula;
        }




        /// <summary>
        /// 设置数值.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="val"></param>
        public void SetValue(int row, int col, string val)
        {
            xlSheet.Cells[row, col].Value = val;
        }



        /// <summary>
        /// 获取数据.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public string GetValue(int row, int col)
        {
            // 取得单元格.
            var cell = xlSheet.Cells[row, col];
            if (cell.MergeCells == true)
            {
                // 本单元格是 “合并单元格”
                if (cell.MergeArea.Row == row
                    && cell.MergeArea.Column == col)
                {
                    // 当前单元格 就是 合并单元格的 左上角 内容.
                    
                    // 注意: 当 单元格数据类型为 日期, 且列宽比较短的时候
                    // 会显示为  ###
                    // 最后导致  cell.Text  的数据为  ###
                    // 现在修改为  cell.Value.ToString() 。 
                    // 以能够获取到正确的 日期数据 （而不是 ###）

                    // return cell.Text;
                    return cell.Value.ToString();
                }
                else
                {
                    // 返回 合并单元格的 左上角 内容.
                    return xlSheet.Cells[cell.MergeArea.Row, cell.MergeArea.Column].Text;
                }
            }
            else
            {
                // 本单元格是 “普通单元格”
                // 获取文本信息.
                // return cell.Text;
                return cell.Value.ToString();
            }
        }


        #endregion





        /// <summary>
        /// 隐藏工作表.
        /// </summary>
        /// <param name="sheetName"></param>
        public void HideSheet(string sheetName)
        {
            // 选择工作表.
            Excel.Worksheet tmpSheet = (Excel.Worksheet)xlBook.Sheets.get_Item(sheetName);
            // 隐藏.
            tmpSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
        }



        /// <summary>
        /// 简单的 复制 粘贴
        /// 从 源 Sheet 复制到 目标 Sheet.
        /// </summary>
        /// <param name="fromSheetName"></param>
        /// <param name="toSheetName"></param>
        public void SimpleCopy(string fromSheetName, string toSheetName, string startPlace = "A1")
        {
            // 选择源工作表.
            Excel.Worksheet fromSheet = (Excel.Worksheet)xlBook.Sheets.get_Item(fromSheetName);

            // 选择
            fromSheet.Select();
            // 复制.
            fromSheet.UsedRange.Copy();


            // 选择目的工作表.
            Excel.Worksheet toSheet = (Excel.Worksheet)xlBook.Sheets.get_Item(toSheetName);

            // 选择.
            toSheet.Activate();
            toSheet.Select();

            // 注意:
            // 这里是  先粘贴数据， 后粘贴格式
            // 假如  先粘贴格式 后粘贴数据的话
            // 如果 源Sheet 有 合并单元格的情况下
            // 粘贴格式完毕以后， 再粘贴数据将发生错误。

            // 粘贴数据.
            toSheet.Range[startPlace].PasteSpecial(Excel.XlPasteType.xlPasteValues);
            
            // 粘贴格式.
            toSheet.Range[startPlace].PasteSpecial(Excel.XlPasteType.xlPasteFormats);
        }




        /// <summary>
        /// 简单的 复制 粘贴
        /// 从 源 Sheet 复制到 目标 Sheet.
        /// </summary>
        /// <param name="fromSheetName">源 Sheet 名称.</param>
        /// <param name="toSheetName"> 目标 Sheet 名称. </param>
        /// <param name="fromPlace"> 源 Sheet 的起始地址 </param>
        /// <param name="toPlace"> 目标 Sheet 的起始地址</param>
        public void SimpleCopy(string fromSheetName, string toSheetName, 
            string fromPlace,
            string toPlace)
        {
            // 选择源工作表.
            Excel.Worksheet fromSheet = (Excel.Worksheet)xlBook.Sheets.get_Item(fromSheetName);

            // 选择
            fromSheet.Select();
            // 复制. （从指定坐标开始， 到全部）
            fromSheet.Range[fromPlace, GetEndAddress(fromSheet)].Copy();

            // 选择目的工作表.
            Excel.Worksheet toSheet = (Excel.Worksheet)xlBook.Sheets.get_Item(toSheetName);

            // 选择.
            toSheet.Activate();
            toSheet.Select();

            // 粘贴数据.
            toSheet.Range[toPlace].PasteSpecial(Excel.XlPasteType.xlPasteValues);
            
            // 粘贴格式.
            toSheet.Range[toPlace].PasteSpecial(Excel.XlPasteType.xlPasteFormats);

        }




        #region  条件格式代码.



        /// <summary>
        /// 获取指定工作表的 已使用数据单元 最大 行列地址.
        /// </summary>
        /// <param name="mySheet"></param>
        /// <returns></returns>
        private string GetEndAddress(
            Excel.Worksheet mySheet,
            string startPlace = "A1",
            int subRow = 0,
            int subCol = 0)
        {
            // 取得数据的Sheet的行数与列数
            int rowCount = mySheet.UsedRange.Rows.Count - subRow;
            int colCount = mySheet.UsedRange.Columns.Count - subCol;


            // 相对位移坐标.
            int movColIdx = startPlace[0] - 'A';
            int movRowIdx = startPlace[1] - '1';

            // 相对位移坐标处理.
            rowCount += movRowIdx;
            colCount += movColIdx;

            if (colCount <= 26)
            {
                // 列数小于等于 26。 字母是 A-Z
                char topChar = (char)('A' + (colCount - 1));
                return topChar.ToString() + rowCount;
            }
            else
            {
                // 大于 26， 意味着要有 AA-- ZZ了
                char topChar = (char)('A' + (colCount / 26) - 1);
                char secondChar = (char)('A' + (colCount % 26) - 1);
                return topChar.ToString() + secondChar.ToString() + rowCount;
            }
        }




        /// <summary>
        /// 设置条件格式.
        /// </summary>
        /// <param name="fromSheetName"> 需要设置条件格式的 Sheet 名字.</param>
        /// <param name="formula1"> 条件公式. </param>
        /// <param name="bold"> 满足条件后的行 是否粗体. </param>
        /// <param name="italic"> 满足条件后的行 是否斜体. </param>
        /// <param name="color"> 满足条件后的行 字体的颜色. </param>
        public void SetFormatConditionsExpression(
            string fromSheetName,
            string formula1,
            bool bold,
            bool italic,
            int color)
        {
            // 选择源工作表.
            Excel.Worksheet mySheet = (Excel.Worksheet)xlBook.Sheets.get_Item(fromSheetName);

            // 选择
            mySheet.Select();

            // 范围选择.
            Excel.Range myRange = mySheet.Range["A2", GetEndAddress(mySheet)];

            // 设置公式.
            Excel.FormatCondition myCond = myRange.FormatConditions.Add(
                Excel.XlFormatConditionType.xlExpression,
                Type.Missing,
                formula1);

            // 设置条件字体.
            myCond.Font.Bold = bold;
            myCond.Font.Italic = italic;
            myCond.Font.Color = color;

        }





        /// <summary>
        /// 设置条件格式.
        /// </summary>
        /// <param name="fromSheetName"> 需要设置条件格式的 Sheet 名字.</param>
        /// <param name="baseAddress"> 基准地址. </param>
        /// <param name="startAddress"> 起始地址. </param>
        /// <param name="subRow"> 结束行递减数量. </param>
        /// <param name="subCol"> 结束列递减数量. </param>
        /// <param name="oper"> 公式的判断方式. </param>
        /// <param name="formula1"> 条件公式. </param>
        /// <param name="bold"> 满足条件后的行 是否粗体. </param>
        /// <param name="italic"> 满足条件后的行 是否斜体. </param>
        /// <param name="color"> 满足条件后的行 字体的颜色. </param>
        public void SetFormatConditionsCellValueLessEqual(
            string fromSheetName,
            string baseAddress,
            string startAddress,
            int subRow,
            int subCol,
            ExcelFormatConditionOperator oper,
            string formula1,
            bool bold,
            bool italic,
            int color)
        {
            // 选择源工作表.
            Excel.Worksheet mySheet = (Excel.Worksheet)xlBook.Sheets.get_Item(fromSheetName);

            // 选择
            mySheet.Select();

            // 范围选择.
            string finishAddress = GetEndAddress(mySheet, baseAddress, subRow, subCol);
            Excel.Range myRange = mySheet.Range[startAddress, finishAddress];

            // 设置公式.
            Excel.FormatCondition myCond = myRange.FormatConditions.Add(
                Excel.XlFormatConditionType.xlCellValue,
                oper,
                formula1);

            // 设置条件字体.
            myCond.Font.Bold = bold;
            myCond.Font.Italic = italic;
            myCond.Font.Color = color;

        }



        #endregion  条件格式代码.





        /// <summary>
        /// 设置 冻结窗口 （首行）
        /// </summary>
        /// <param name="fromSheetName"> 需要设置条件格式的 Sheet 名字. </param>
        public void ActiveWindow(string fromSheetName)
        {
            // 选择源工作表.
            Excel.Worksheet mySheet = (Excel.Worksheet)xlBook.Sheets.get_Item(fromSheetName);
            mySheet.Select();

            xlApp.ActiveWindow.SplitColumn = 0;
            xlApp.ActiveWindow.SplitRow = 1;
            xlApp.ActiveWindow.FreezePanes = true;
        }







        #region  用于 锁定工作表，仅仅允许部分区域 可输入的代码.



        /// <summary>
        /// 增加 “允许用户编辑区域”
        /// </summary>
        /// <param name="sheetName"></param>
        /// <param name="rangeTitle"></param>
        /// <param name="rangeFrom"></param>
        /// <param name="rangeTo"></param>
        /// <param name="?"></param>
        public void AddProtectionAllowEditRanges(
            string sheetName,
            string rangeTitle,
            string rangeFrom,
            string rangeTo,
            string password = "")
        {
            // 选择源工作表.
            Excel.Worksheet mySheet = (Excel.Worksheet)xlBook.Sheets.get_Item(sheetName);

            Excel.Range myRange = mySheet.Range[rangeFrom, rangeTo];

            mySheet.Protection.AllowEditRanges.Add(
                rangeTitle,
                myRange,
                password);
        }



        /// <summary>
        /// 保护工作表.
        /// </summary>
        /// <param name="sheetName"> 工作表名 </param>
        /// <param name="password"> 密码 </param>
        public void Protect(
            string sheetName,
            string password = "")
        {

            // 选择源工作表.
            Excel.Worksheet mySheet = (Excel.Worksheet)xlBook.Sheets.get_Item(sheetName);


            mySheet.Protect(
                Password: password,
                DrawingObjects: true,
                Contents: true,
                Scenarios: true);

        }



        #endregion





        #region 格式设定代码.




        /// <summary>
        /// 合并单元格.
        /// </summary>
        /// <param name="fromAddr"></param>
        /// <param name="toAddr"></param>
        public void Merge(string fromAddr, string toAddr)
        {
            xlSheet.Range[fromAddr, toAddr].Merge();
        }


        /// <summary>
        /// 插入一列.
        /// </summary>
        public void InsertCol(int colIndex)
        {
            xlSheet.Columns[colIndex].Insert(
                Shift: -4161,
                CopyOrigin: 0
                );
        }



        /// <summary>
        /// 删除列.
        /// </summary>
        /// <param name="colIndex"></param>
        public void RemoveCol(int colIndex)
        {
            xlSheet.Columns[colIndex].Delete(
                Shift: -4159
                );
        }

        /// <summary>
        /// 删除行.
        /// </summary>
        /// <param name="rowIndex"></param>
        public void RemoveRow(int rowIndex)
        {
            xlSheet.Rows[rowIndex].Delete(
                Shift: -4162
                );
        }




        /// <summary>
        /// 复制一列.
        /// </summary>
        /// <param name="fromColumn"></param>
        /// <param name="toColumn"></param>
        public void SimpleCopyColumn(int fromColumn, string startPlace)
        {
            xlSheet.Columns[fromColumn].Copy();

            // 粘贴格式.
            xlSheet.Range[startPlace].PasteSpecial(Excel.XlPasteType.xlPasteFormats);

            // 粘贴数据.
            xlSheet.Range[startPlace].PasteSpecial(Excel.XlPasteType.xlPasteValues);
        }


        /// <summary>
        /// 在同一个 Sheet 范围内， 简单的复制粘贴处理.
        /// </summary>
        /// <param name="fromPlaceBegin"></param>
        /// <param name="fromPlaceEnd"></param>
        /// <param name="startPlace"></param>
        public void SimpleCopyInOneSheet(
            string fromPlaceBegin, string fromPlaceEnd,
            string startPlace)
        {
            // 复制.
            xlSheet.Range[fromPlaceBegin, fromPlaceEnd].Copy();

            // 粘贴
            xlSheet.Range[startPlace].Select();
            xlSheet.Paste();
        }



        /// <summary>
        /// 获取最大列索引.
        /// </summary>
        /// <returns></returns>
        public int GetMaxColIndex()
        {
            return xlSheet.UsedRange.Columns.Count;
        }


        /// <summary>
        /// 获取最大行索引.
        /// </summary>
        /// <returns></returns>
        public int GetMaxRowIndex()
        {
            return xlSheet.UsedRange.Rows.Count;
        }



        #endregion

    }



}

