using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0171_Oracle_ODAC.Sample;

namespace A0171_Oracle_ODAC
{
    class Program
    {
        static void Main(string[] args)
        {

            // 读
            ReadOracleData reader = new ReadOracleData();
            reader.ReadDataToDataSet();
            reader.ReadDataByReader();


            // 写
            WriteOracleData writer = new WriteOracleData();
            writer.TestInsertUpdateDelete();


            // 函数/存储过程.
            CallOracleFuncProc caller = new CallOracleFuncProc();
            caller.TestCallFuncProc();

            Console.ReadLine();

        }
    }
}
