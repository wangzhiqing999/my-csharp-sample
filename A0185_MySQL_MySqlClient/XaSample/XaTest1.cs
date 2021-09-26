using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using A0185_MySQL_MySqlClient.Xa;


namespace A0185_MySQL_MySqlClient.XaSample
{


    /// <summary>
    /// 测试  XA
    /// </summary>
    public class XaTest1
    {


        /// <summary>
        /// MySQL 的数据库连接字符串.
        /// </summary>
        private const string connString =
            @"Server=192.168.1.86;Database=test;Uid=root;Pwd=123456";



        /// <summary>
        /// 用于更新的 SQL 语句.
        /// </summary>
        private const String UPDATE_SQL_1 =
            @"
UPDATE 
  test_xa
SET 
  value = value + 10
WHERE 
  id = 1";



        /// <summary>
        /// 用于更新的 SQL 语句.
        /// </summary>
        private const String UPDATE_SQL_2 =
            @"
UPDATE 
  test_xa
SET 
  value = value - 10
WHERE 
  id = 1";





        /// <summary>
        /// 用于 触发异常的 SQL 语句.
        /// </summary>
        private const String ERROR_SQL = @"INSERT INTO test_xa (id, value) VALUES (1, 100)";






        /// <summary>
        /// 测试提交的过程.
        /// </summary>
        public void TestXaCommit()
        {

            Console.WriteLine("----- Test XA COMMIT -----");


            using (MySqlConnection conn = new MySqlConnection(connString))
            {                
                try
                {
                    conn.Open();

                    MySqlXaTransaction xaTransaction = new MySqlXaTransaction(conn, "test1");



                    xaTransaction.XaStart();



                    MySqlCommand cmd = new MySqlCommand(UPDATE_SQL_1, conn);
                    cmd.ExecuteNonQuery();




                    xaTransaction.XaEnd();



                    xaTransaction.XaPrepare();
                    xaTransaction.XaCommit();


                }
                catch (Exception ex)
                {
                    Console.WriteLine("数据库读写操作发生了错误！");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }

        }



        public void TestXaRollback()
        {

            Console.WriteLine("----- Test XA ROLLBACK -----");


            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    MySqlXaTransaction xaTransaction = new MySqlXaTransaction(conn, "test2");



                    xaTransaction.XaStart();



                    MySqlCommand cmd = new MySqlCommand(UPDATE_SQL_2, conn);
                    cmd.ExecuteNonQuery();




                    xaTransaction.XaEnd();



                    xaTransaction.XaPrepare();
                    xaTransaction.XaRollback();


                }
                catch (Exception ex)
                {
                    Console.WriteLine("数据库读写操作发生了错误！");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }






        public void TestError()
        {

            Console.WriteLine("----- Test ERROR --- XA ROLLBACK -----");

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (MySqlXaTransaction xaTransaction = new MySqlXaTransaction(conn, "test3"))
                    {
                        xaTransaction.XaStart();

                        MySqlCommand cmd = new MySqlCommand(UPDATE_SQL_2, conn);
                        cmd.ExecuteNonQuery();


                        cmd.CommandText = ERROR_SQL;
                        cmd.ExecuteNonQuery();


                        xaTransaction.XaEnd();
                        xaTransaction.XaPrepare();
                        xaTransaction.XaCommit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("数据库读写操作发生了错误！");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }


        }





        /// <summary>
        /// 测试 忘记 Commit.
        /// 自动回滚.
        /// </summary>
        public void TestForgetCommit()
        {

            Console.WriteLine("----- Test Forget Commit --- Auto XA ROLLBACK -----");

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (MySqlXaTransaction xaTransaction = new MySqlXaTransaction(conn, "test4"))
                    {
                        xaTransaction.XaStart();

                        MySqlCommand cmd = new MySqlCommand(UPDATE_SQL_2, conn);
                        cmd.ExecuteNonQuery();


                        xaTransaction.XaEnd();
                        xaTransaction.XaPrepare();

                        // xaTransaction.XaCommit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("数据库读写操作发生了错误！");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }




    }
}
