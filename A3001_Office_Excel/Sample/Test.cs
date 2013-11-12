using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A3001_Office_Excel.Common;


namespace A3001_Office_Excel.Sample
{
    class Test
    {


        /// <summary>
        /// 测试 Excel 保护.
        /// </summary>
        public void TestProtect()
        {

            Console.WriteLine("测试 Excel 保护开始！");


            string fileName =
                System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
                + @"ExcelFiles\测试工作表保护.xls";


            ExcelReport service = new ExcelReport();

            // 打开 Excel.
            service.OpenExcel();

            // 打开 Excel 文件.
            service.OpenExcelFile(fileName);





            // 允许用户编辑区域.
            service.AddProtectionAllowEditRanges(
                "测试工作表保护",
                "可编辑区域",
                "D5",
                "D8");


            // 保护.
            service.Protect("测试工作表保护");





            // 保存 Excel 文件.
            service.SaveExcelFile();

            // 关闭 Excel.
            service.CloseExcel();


            Console.WriteLine("测试 Excel 保护结束！");
        }






        /// <summary>
        /// 测试 冻结窗口.
        /// </summary>
        public void TestActiveWindow()
        {

            Console.WriteLine("测试 Excel 冻结窗口 开始！");


            string fileName =
                System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
                + @"ExcelFiles\测试冻结窗口.xls";


            ExcelReport service = new ExcelReport();

            // 打开 Excel.
            service.OpenExcel();

            // 打开 Excel 文件.
            service.OpenExcelFile(fileName);






            // 冻结窗口
            service.ActiveWindow("测试冻结窗口");






            // 保存 Excel 文件.
            service.SaveExcelFile();

            // 关闭 Excel.
            service.CloseExcel();



            Console.WriteLine("测试 Excel 冻结窗口 结束！");
        }







        /// <summary>
        /// 测试 条件公式.
        /// </summary>
        public void TestFormatConditions()
        {

            Console.WriteLine("测试 Excel 条件公式 开始！");


            string fileName =
                System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
                + @"ExcelFiles\测试条件公式.xls";


            ExcelReport service = new ExcelReport();

            // 打开 Excel.
            service.OpenExcel();

            // 打开 Excel 文件.
            service.OpenExcelFile(fileName);






            // 条件公式
            service.SetFormatConditionsExpression(
                "测试条件公式1",
                "=INDIRECT(CONCATENATE(\"R\",ROW(),\"C2\"),FALSE) < INDIRECT(CONCATENATE(\"R\",ROW(),\"C3\"),FALSE)",
                true,
                true,
                -16776961);


            /*

关于公式 =INDIRECT(CONCATENATE("R",ROW(),"C2"),FALSE) < INDIRECT(CONCATENATE("R",ROW(),"C3"),FALSE)

             
其中 ROW() 是 获得 Excel 表格当前行号

CONCATENATE 是连接字符串
CONCATENATE("R",ROW(),"C2")
CONCATENATE("R",ROW(),"C3")  就是通过 行号，来计算一个 当前行的地址。
例如当前行是第3行
那么就返回  R3C2， 意思是 第3行第2列。
以及返回  R3C3， 意思是 第3行第3列。


INDIRECT 是通过 地址，获取指定地址的具体数据。
例如当前行是第3行。
最后相当于执行的是
=INDIRECT("R3C2"),FALSE) < INDIRECT("R3C3"),FALSE)
也就是判断，当前行的第3列的数据，是否大于当前行的第2列的数据。
如果条件满足了，那么就需要设定格式。

             */









            service.SetFormatConditionsCellValueLessEqual(
                "测试条件公式2",
                "A3",
                "C4",
                0,
                0,
                ExcelFormatConditionOperator.xlLessEqual,
                "=INDIRECT(CONCATENATE(\"R\",ROW(),\"C2\"),FALSE)",
                true,
                false,
                -16776961);

            /*
            
            关于公式的   =INDIRECT(CONCATENATE("R",ROW(),"C2"),FALSE) 解释

            CONCATENATE 是连接字符串
            CONCATENATE("R",ROW(),"C2")
            CONCATENATE("R",ROW(),"C2")  就是通过 行号，来计算一个 当前行的地址。
            例如当前行是第4行

            那么就返回  R4C2， 意思是 第4行第2列。

            INDIRECT 是通过 地址，获取指定地址的具体数据。

            */





            // 保存 Excel 文件.
            service.SaveExcelFile();

            // 关闭 Excel.
            service.CloseExcel();



            Console.WriteLine("测试 Excel 条件公式 结束！");
        }





        /// <summary>
        /// 测试 复制与隐藏.
        /// </summary>
        public void TestCopyAndHide()
        {
            Console.WriteLine("测试 Excel 复制与隐藏 开始！");


            string fileName =
                System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
                + @"ExcelFiles\测试复制与隐藏.xls";


            ExcelReport service = new ExcelReport();

            // 打开 Excel.
            service.OpenExcel();

            // 打开 Excel 文件.
            service.OpenExcelFile(fileName);






            // 复制
            service.SimpleCopy(
                "测试复制与隐藏",
                "复制后",
                "A3");


            // 隐藏
            service.HideSheet("测试复制与隐藏");



            // 保存 Excel 文件.
            service.SaveExcelFile();

            // 关闭 Excel.
            service.CloseExcel();



            Console.WriteLine("测试 Excel 复制与隐藏 结束！");

        }







        /// <summary>
        /// 测试 读写.
        /// </summary>
        public void TestReadWrite()
        {
            Console.WriteLine("测试 Excel 读写 开始！");


            string fileName =
                System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
                + @"ExcelFiles\测试读写.xls";


            ExcelReport service = new ExcelReport();

            // 打开 Excel.
            service.OpenExcel();

            // 打开 Excel 文件.
            service.OpenExcelFile(fileName);





            // 选择工作表.
            service.SelectSheet("测试读写");


            for (int i = 2; i <= 5; i++)
            {
                // 获取数据.
                Console.WriteLine("{0}.{1}.{2}.{3}",
                    service.GetValue(i, 1),
                    service.GetValue(i, 2),
                    service.GetValue(i, 3),
                    service.GetValue(i, 4));

                // 设置公式.
                service.SetFormulaR1C1(i, 5, "=IF(测试读写!R" + i + "C4>=18,\"18+\",\"未成年\")");

                // 设置数值.
                service.SetValue(i, 6, "Test" + i);
            }
            



            // 保存 Excel 文件.
            service.SaveExcelFile();

            // 关闭 Excel.
            service.CloseExcel();



            Console.WriteLine("测试 Excel 读写 结束！");
        }



    }
}
