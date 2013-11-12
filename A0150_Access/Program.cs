using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0150_Access.Sample;

namespace A0150_Access
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****读取测试*****");

            // 构造例子类.
            ReadAccessDB access = new ReadAccessDB();

            // 将数据填充到 DataSet 中.
            access.ReadDataToDataSet();

            // 使用 Reader 逐行处理.
            access.ReadDataByReader();


            Console.WriteLine("*****写入测试*****");

            WriteAccessDB access2 = new WriteAccessDB();

            access2.TestInsertUpdateDelete();





            Console.WriteLine("===== 二进制文件读写测试 =====");
            ReadWriteBinData binTest = new ReadWriteBinData();
            binTest.TestWriteAndRead();


            Console.ReadLine();

        }
    }
}
