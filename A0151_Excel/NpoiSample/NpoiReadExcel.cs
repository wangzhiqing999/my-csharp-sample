using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;


using NPOI.SS.UserModel;

using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;


namespace A0151_Excel.NpoiSample
{
    public class NpoiReadExcel
    {




        public DataSet ReadExcelData(string fileName, string startIndex, bool hasTitle)
        {
            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;



            try
            {

                // 最终结果.
                DataSet excelData = new DataSet();


                using (fs = File.OpenRead(fileName))
                {
                    
                    if (fileName.IndexOf(".xlsx") > 0)
                    {
                        // 2007版本
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if (fileName.IndexOf(".xls") > 0)
                    {
                        // 2003版本
                        workbook = new HSSFWorkbook(fs);
                    }


                    if (workbook != null)
                    {
                        // 遍历每一个 Sheet.
                        for(int sheetIndex = 0; sheetIndex < workbook.NumberOfSheets; sheetIndex++)
                        {
                            // 获取 Sheet.
                            sheet = workbook.GetSheetAt(sheetIndex);

                            if (sheet != null)
                            {
                                dataTable = new DataTable();

                                dataTable.TableName = sheet.SheetName;


                                // 总行数.
                                int rowCount = sheet.LastRowNum;


                                if (rowCount > 0)
                                {
                                    // 第一行.
                                    IRow firstRow = sheet.GetRow(0);
                                    // 列数.
                                    int cellCount = firstRow.LastCellNum;


                                    //构建datatable的列
                                    if (hasTitle)
                                    {
                                        startRow = 1;//如果第一行是列名，则从第二行开始读取
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            cell = firstRow.GetCell(i);
                                            if (cell != null)
                                            {
                                                if (cell.StringCellValue != null)
                                                {
                                                    column = new DataColumn(cell.StringCellValue);
                                                    dataTable.Columns.Add(column);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            column = new DataColumn("column" + (i + 1));
                                            dataTable.Columns.Add(column);
                                        }
                                    }

                                    //填充行
                                    for (int i = startRow; i <= rowCount; ++i)
                                    {
                                        row = sheet.GetRow(i);
                                        if (row == null) continue;

                                        dataRow = dataTable.NewRow();
                                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                                        {
                                            cell = row.GetCell(j);
                                            if (cell == null)
                                            {
                                                dataRow[j] = "";
                                            }
                                            else
                                            {
                                                //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)
                                                switch (cell.CellType)
                                                {
                                                    case CellType.Blank:
                                                        dataRow[j] = "";
                                                        break;
                                                    case CellType.Numeric:
                                                        short format = cell.CellStyle.DataFormat;
                                                        //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                                        if (format == 14 || format == 31 || format == 57 || format == 58)
                                                            dataRow[j] = cell.DateCellValue;
                                                        else
                                                            dataRow[j] = cell.NumericCellValue;
                                                        break;
                                                    case CellType.String:
                                                        dataRow[j] = cell.StringCellValue;
                                                        break;
                                                }
                                            }
                                        }
                                        dataTable.Rows.Add(dataRow);
                                    }




                                    // DataTable 加入  DataSet.
                                    excelData.Tables.Add(dataTable);

                                }

                            }
                        }
                    }
                }



                return excelData;


            }
            catch (Exception err)
            {
                throw err;
            }
            

        }





        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;

            }
        }

    }


}
