using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A3001_Office_Excel.Sample;

namespace A3001_Office_Excel
{

    class Program
    {


        static void Main(string[] args)
        {

            Test test = new Test();



            // 测试 工作表保护.
            test.TestProtect();


            // 测试 冻结窗口.
            test.TestActiveWindow();


            // 测试 条件公式.
            test.TestFormatConditions();


            // 测试 复制与隐藏.
            test.TestCopyAndHide();


            // 测试 读写。
            test.TestReadWrite();



            Console.ReadLine();
        }

    }


}
