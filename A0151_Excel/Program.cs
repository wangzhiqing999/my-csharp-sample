using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using A0151_Excel.Model;
using A0151_Excel.NpoiSample;
using A0151_Excel.Sample;

namespace A0151_Excel
{
    class Program
    {
        static void Main(string[] args)
        {

            string excelFileName = System.AppDomain.CurrentDomain.BaseDirectory + "Test.xls";
            CreateWriteExcel cwExcel = new CreateWriteExcel();
            cwExcel.TestWriteExcel(excelFileName);



            Console.WriteLine("准备测试 ReadExcel.ReadExcelData 注意观察内存使用！");
            Console.WriteLine("按回车继续...");
            Console.ReadLine();

            ReadExcel rExcel = new ReadExcel();
            // 测试读取 前面创建 的 Excel 文件.
            rExcel.TestRead(excelFileName, String.Empty, true);


            Console.WriteLine("准备测试 NpoiReadExcel.ReadExcelData 注意观察内存使用！");
            Console.WriteLine("注意观察内存使用！");
            Console.WriteLine("按回车继续...");
            Console.ReadLine();

            TestNpoiReadExcel(excelFileName);

            Console.WriteLine("准备测试 ExcelDataReader.ReadExcelData 注意观察内存使用！");
            Console.WriteLine("按回车继续...");
            Console.ReadLine();

            // 逐行读取.
            TestReadExcelData();

            Console.WriteLine("内存占用的测试完成！");
            Console.WriteLine("按回车继续...");
            Console.ReadLine();

            // 测试读取 标题不在 第一行的情况。
            rExcel.TestRead("Report.xls", "A4:C100", true);


            // 测试读取 没有标题 的情况。
            rExcel.TestRead("Test2.xls", String.Empty, false);



            // 注意1：下面这种情况， 第一行需要是空白的
            // 测试读取 没有标题  且数据不在第一行的情况。
            // 注意2：当 Excel 中， 某一列，内容一直是数字的， 然后突然变字符了，会发生无法读取到该行的字符数据的问题。
            rExcel.TestRead("Report2.xls", "A4:C100", true);






            TestNpoiWriteExcel();


            Console.WriteLine("----- Finish -----");

            Console.ReadLine();
        }



        private static void TestNpoiReadExcel(string excelFileName)
        {
            Console.WriteLine("------ NPOI TEST ------");

            NpoiReadExcel readExcel = new NpoiReadExcel();

            DataSet ds = readExcel.ReadExcelData(excelFileName, String.Empty, true);


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
                        Console.Write(row[col.ColumnName]);
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }
            }
        }




        private static void TestNpoiWriteExcel()
        {
            NpoiWriteExcel tester = new NpoiWriteExcel();
            tester.CreateExcel();


            DataSet ds = tester.ReadExcel();

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
                        Console.Write(row[col.ColumnName]);
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }
            }
        }





        private static void TestReadExcelData()
        {

            Console.WriteLine("----- ExcelDataReader -----");


            ExcelDataReader<TestData> excelReader = new ExcelDataReader<TestData>();

            var results = excelReader.ReadExcelData("Test.xls", string.Empty, true, true, dataReader =>
            {
                TestData testData = new TestData();

                testData.ID = Convert.ToInt32(dataReader["编号"]);
                testData.Name = Convert.ToString(dataReader["名称"]);
                testData.Value = Convert.ToInt32(dataReader["成绩"]);

                return testData;
            });


            foreach(var item in results)
            {
                Console.Write(item);
            }
        }



    }
}
