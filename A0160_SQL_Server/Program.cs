using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0160_SQL_Server.Sample;

namespace A0160_SQL_Server
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadSqlServerDataIn testIn = new ReadSqlServerDataIn ();
            testIn.ReadDataByReader();


            // 使用 DataSet 来对数据库进行 更新操作.
            // 比较古老的技术
            // 可用是可用
            // 不推荐.
            UpdateByDataSet dsTest = new UpdateByDataSet();
            dsTest.Test();


            GetScopeIdentity gTest = new GetScopeIdentity();
            gTest.TestInsert();


            // 读
            ReadSqlServerData reader = new ReadSqlServerData();
            reader.ReadDataToDataSet();
            reader.ReadDataByReader();


            // 写
            WriteSqlServerData writer = new WriteSqlServerData();
            writer.TestInsertUpdateDelete();


            // 函数/存储过程.
            CallSqlServerFuncProc caller = new CallSqlServerFuncProc();
            caller.TestCallFuncProc();


            // 长时间处理.
            CallLongTimeProc longTimeCaller = new CallLongTimeProc();
            longTimeCaller.TestCallLongTimeProc();




            Console.WriteLine("===== 二进制文件读写测试 =====");
            ReadWriteBinData binTest = new ReadWriteBinData();
            binTest.TestWriteAndRead();



            Console.ReadLine();

        }
    }
}

