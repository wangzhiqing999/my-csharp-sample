using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using A0175_PostgreSQL.Sample;


namespace A0175_PostgreSQL
{
    class Program
    {
        static void Main(string[] args)
        {

            // 读
            ReadPostgreSQLData reader = new ReadPostgreSQLData();
            reader.ReadDataToDataSet();
            reader.ReadDataByReader();



            // 写
            WritePostgreSQLData writer = new WritePostgreSQLData();
            writer.TestInsertUpdateDelete();



            // 函数/存储过程.
            CallPostgreSQLFunc caller = new CallPostgreSQLFunc();
            caller.TestCallFuncProc();



            Console.ReadLine();
        }


    }
}
