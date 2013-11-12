using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

using System.Threading;




namespace A0170_Oracle.Sample
{
    public class GetSequence
    {

        /// <summary>
        /// Oracle 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.56.102)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=TEST;Password=TEST";


        /// <summary>
        /// 用于 新增记录的 SQL 语句
        /// </summary>
        private const String INSERT_SQL = @"
INSERT INTO test_seq_tab ( value ) VALUES ( :value  )";


        private const String GET_SEQUENCE_SQL = @"SELECT SEQ_TEST_EF.CURRVAL FROM DUAL";




        /// <summary>
        /// 多线程测试的时候， 使用的属性.
        /// </summary>
        public string TestValue { set; get; }


        public void DoTest()
        {
            // 建立数据库连接.
            OracleConnection conn = new OracleConnection(connString);
            OracleTransaction t = null ;
            
            try
            {
                // 打开连接.
                conn.Open();

                // 开始创建一个事务.
                t = conn.BeginTransaction();


                // 创建一个 Command.
                OracleCommand insertCommand = conn.CreateCommand();
                insertCommand.Transaction = t;
                // 定义需要执行的SQL语句.
                insertCommand.CommandText = INSERT_SQL;

                insertCommand.Parameters.Add(new OracleParameter(":value", TestValue));

                // 执行插入
                insertCommand.ExecuteNonQuery();


                Console.WriteLine("插入数据完毕， 还没有尝试获取序列号！");

                // 模拟一个长时间处理
                // 以判断， 多用户并发的时候， 是否会产生读取 序列号 不正确.                

                Thread.Sleep(3000);


                insertCommand.Parameters.Clear();

                insertCommand.CommandText = GET_SEQUENCE_SQL;
                // 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
                Object oID = insertCommand.ExecuteScalar();
                // 转换为 int 类型.
                int id = Convert.ToInt32(oID);
                // 输出
                Console.WriteLine("新插入的ID为{0}", id);


                t.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine("数据库读写操作发生了错误！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                t.Rollback();
            }
            finally
            {
                // 关闭数据库.
                conn.Close();
            }
        }

    }
}
