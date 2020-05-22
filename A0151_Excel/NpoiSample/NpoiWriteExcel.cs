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
    public class NpoiWriteExcel
    {

        /// <summary>
        /// 测试的文件名.
        /// </summary>
        private const string TEST_FILE_NAME = "test_Npoi.xls";



        public void CreateExcel()
        {

            // 如果文件存在， 先删除.
            if (File.Exists(TEST_FILE_NAME))
            {
                File.Delete(TEST_FILE_NAME);
            }



            // 创建文件
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            // 创建Excel工作表
            var sheet1 = hssfworkbook.CreateSheet("Sheet1");


            // 创建单元格

            // 首行 -- 主标题行.
            var row1 = sheet1.CreateRow(0);
            var cell1 = row1.CreateCell(0);
            cell1.SetCellValue("ID");

            var cell2 = row1.CreateCell(1);
            cell2.SetCellValue("Level");

            var cell3 = row1.CreateCell(2);
            cell3.SetCellValue("Name");


            for(int i =0; i < 10; i++)
            {
                var cell4 = row1.CreateCell(3 + i);
                cell4.SetCellValue("ID_" + i);
            }


            //创建批注
            var patr = sheet1.CreateDrawingPatriarch();
            var comment1 = patr.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 1, 2, 4, 4));
            comment1.String = new HSSFRichTextString("这一列是代码.");
            comment1.Author = "开发人员";
            cell1.CellComment = comment1;

            var comment2 = patr.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 1, 2, 4, 4));
            comment2.String = new HSSFRichTextString("这一列是等级.");
            comment2.Author = "开发人员";
            cell2.CellComment = comment2;

            var comment3 = patr.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 1, 2, 4, 4));
            comment3.String = new HSSFRichTextString("这一列是姓名.");
            comment3.Author = "开发人员";
            cell3.CellComment = comment3;






            // 次行 -- 附标题行.
            var row2 = sheet1.CreateRow(1);
            var cell21 = row2.CreateCell(0);
            cell21.SetCellValue("我是代码");

            var cell22 = row2.CreateCell(1);
            cell22.SetCellValue("我是等级");

            var cell23 = row2.CreateCell(2);
            cell23.SetCellValue("我是姓名");


            for (int i = 0; i < 10; i++)
            {
                var cell4 = row2.CreateCell(3 + i);
                cell4.SetCellValue("名称_" + i);
            }



            // 冻结
            // 第一个参数表示要冻结的列数；
            // 第二个参数表示要冻结的行数；
            // 第三个参数表示右边区域可见的首列序号，从1开始计算；
            // 第四个参数表示下边区域可见的首行序号，也是从1开始计算；
            sheet1.CreateFreezePane(3, 2, 3, 2);





            // 创建数据.
            for (int i = 2; i <= 10; i++)
            {
                var row = sheet1.CreateRow(i);
                for(int j=0; j < 3; j++)
                {
                    var cell = row.CreateCell(j);

                    cell.SetCellValue(string.Format("{0}_{1}", i, j));
                }


                for(int j=0; j<10; j++)
                {
                    var cell = row.CreateCell(3+j);

                    cell.SetCellValue( (i + j)%2 );

                }

            }

            
            // 保存
            FileStream file = new FileStream("test_Npoi.xls", FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();


        }




        public DataSet ReadExcel(string fileName = TEST_FILE_NAME, int startIndex = 1, bool hasTitle = true)
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
                        for (int sheetIndex = 0; sheetIndex < workbook.NumberOfSheets; sheetIndex++)
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


                                    startRow = startRow + startIndex;

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



    }
}
