using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0185_MySQL_MySqlClient.Sample;
using A0185_MySQL_MySqlClient.XaSample;

namespace A0185_MySQL_MySqlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            // 读
            ReadMySQLData reader = new ReadMySQLData();
            reader.ReadDataToDataSet();
            reader.ReadDataByReader();


            // 写
            WriteMySQLData writer = new WriteMySQLData();
            writer.TestInsertUpdateDelete();


            // UTF-8 编码的读写.
            ReadWriteUtf8 utf8WritrReader = new ReadWriteUtf8();
            utf8WritrReader.TestInsertSelect();


            // 存储过程.
            CallMySqlProc proc = new CallMySqlProc();
            proc.TestCallProcFunc();

            */


            /*
            UseMySqlConnectionStringBuilder.TestUse1();
            UseMySqlConnectionStringBuilder.TestUse2();
            */




            /*
            XaTest1 xaTest1 = new XaTest1();
            xaTest1.TestXaCommit();
            xaTest1.TestXaRollback();
            xaTest1.TestError();
            xaTest1.TestForgetCommit();
            */



            XaTest2 xaTest2 = new XaTest2();

            xaTest2.TestAllSucc();
            xaTest2.TestAFail();
            xaTest2.TestBFail();


            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
