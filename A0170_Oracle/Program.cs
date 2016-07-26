using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;



using A0170_Oracle.Sample;


namespace A0170_Oracle
{
    class Program
    {
        static void Main(string[] args)
        {
/*
            for (int i = 0; i < 3; i++)
            {
                GetSequence gTest = new GetSequence()
                {
                    TestValue = "Test" + i
                };

                ThreadStart ts = new ThreadStart(gTest.DoTest);
                Thread t = new Thread(ts);

                t.Start();
            }
            

            



            Console.ReadLine();


            // 读
            ReadOracleData reader = new ReadOracleData();
            reader.ReadDataToDataSet();
            reader.ReadDataByReader();


            // 写
            WriteOracleData writer = new WriteOracleData();
            writer.TestInsertUpdateDelete();
*/

            // 函数/存储过程.
            CallOracleFuncProc caller = new CallOracleFuncProc();
            caller.TestCallFuncProc();

            Console.ReadLine();
        }
    }
}
