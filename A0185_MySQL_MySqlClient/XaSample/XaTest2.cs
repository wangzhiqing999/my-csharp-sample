using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using MySql.Data.MySqlClient;
using A0185_MySQL_MySqlClient.Xa;




namespace A0185_MySQL_MySqlClient.XaSample
{

    /// <summary>
    /// 测试  XA, 两台 MySQL 的处理机制.
    /// </summary>
    public class XaTest2
    {


        /// <summary>
        /// 测试服务器 A 的 MySQL 的数据库连接字符串.
        /// </summary>
        private const string connStringA =
            @"Server=192.168.1.86;Database=test;Uid=root;Pwd=123456";



        /// <summary>
        /// 测试服务器 B 的 MySQL 的数据库连接字符串.
        /// </summary>
        private const string connStringB =
            @"Server=192.168.1.106;Database=test;Uid=root;Pwd=Aa123456.";




        /// <summary>
        /// 用于更新的 SQL 语句.
        /// </summary>
        private const String UPDATE_SQL =
            @"
UPDATE 
  test_xa
SET 
  value = value + 10
WHERE 
  id = 1";


        /// <summary>
        /// 用于 触发异常的 SQL 语句.
        /// </summary>
        private const String ERROR_SQL = @"INSERT INTO test_xa (id, value) VALUES (1, 100)";


        /// <summary>
        /// 更新指定 库的数据.
        /// </summary>
        /// <param name="conn"></param>
        private void Update(MySqlConnection conn, string sql = UPDATE_SQL)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }



        /// <summary>
        /// 测试全部成功的情况.
        /// </summary>
        public void TestAllSucc()
        {
            Console.WriteLine("----- Test XA All Success -----");

            MySqlConnection connA = new MySqlConnection(connStringA);
            MySqlConnection connB = new MySqlConnection(connStringB);

            connA.Open();
            connB.Open();


            MySqlXaTransaction xaTransactionA = new MySqlXaTransaction(connA, "TestAllSucc");
            xaTransactionA.XaStart();

            MySqlXaTransaction xaTransactionB = new MySqlXaTransaction(connB, "TestAllSucc");
            xaTransactionB.XaStart();


            try
            {
                Update(connA);

                xaTransactionA.XaEnd();
                xaTransactionA.XaPrepare();



                Update(connB);

                xaTransactionB.XaEnd();
                xaTransactionB.XaPrepare();




                xaTransactionA.XaCommit();
                xaTransactionB.XaCommit();

            } 
            catch (Exception ex)
            {
                Console.WriteLine("数据库读写操作发生了错误！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);


                xaTransactionA.XaRollback();
                xaTransactionB.XaRollback();
            }


            



            

            


        }







        /// <summary>
        /// 测试前一个处理失败了.
        /// </summary>
        public void TestAFail()
        {

            Console.WriteLine("----- Test XA A Fail -----");


            MySqlConnection connA = new MySqlConnection(connStringA);
            MySqlConnection connB = new MySqlConnection(connStringB);

            connA.Open();
            connB.Open();


            MySqlXaTransaction xaTransactionA = new MySqlXaTransaction(connA, "TestAFail");
            xaTransactionA.XaStart();

            MySqlXaTransaction xaTransactionB = new MySqlXaTransaction(connB, "TestAFail");
            xaTransactionB.XaStart();


            try
            {
                Update(connA, ERROR_SQL);

                xaTransactionA.XaEnd();
                xaTransactionA.XaPrepare();



                Update(connB);

                xaTransactionB.XaEnd();
                xaTransactionB.XaPrepare();




                xaTransactionA.XaCommit();
                xaTransactionB.XaCommit();

            }
            catch (Exception ex)
            {
                Console.WriteLine("数据库读写操作发生了错误！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);


                xaTransactionA.XaRollback();
                xaTransactionB.XaRollback();
            }











        }






        /// <summary>
        /// 测试后一个处理失败了.
        /// </summary>
        public void TestBFail()
        {

            Console.WriteLine("----- Test XA B Fail -----");


            MySqlConnection connA = new MySqlConnection(connStringA);
            MySqlConnection connB = new MySqlConnection(connStringB);

            connA.Open();
            connB.Open();


            MySqlXaTransaction xaTransactionA = new MySqlXaTransaction(connA, "TestBFail");
            xaTransactionA.XaStart();

            MySqlXaTransaction xaTransactionB = new MySqlXaTransaction(connB, "TestBFail");
            xaTransactionB.XaStart();


            try
            {
                Update(connA);
                xaTransactionA.XaEnd();
                xaTransactionA.XaPrepare();



                Update(connB, ERROR_SQL);


                xaTransactionB.XaEnd();
                xaTransactionB.XaPrepare();




                xaTransactionA.XaCommit();
                xaTransactionB.XaCommit();

            }
            catch (Exception ex)
            {
                Console.WriteLine("数据库读写操作发生了错误！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);


                xaTransactionA.XaRollback();
                xaTransactionB.XaRollback();
            }


        }





    }
}
