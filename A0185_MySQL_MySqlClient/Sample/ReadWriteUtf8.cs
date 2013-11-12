using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;




namespace A0185_MySQL_MySqlClient.Sample
{
    class ReadWriteUtf8
    {

        /// <summary>
        /// MySQL 的数据库连接字符串.
        /// 
        /// 注意： UTF8 的情况下， 需要设置 charset=utf8
        /// </summary>
        private const String connString =
            @"Server=192.168.56.101;Database=test_utf8;Uid=root;Pwd=mysql123;charset=utf8";


        /// <summary>
        /// 用于 新增记录的 SQL 语句
        /// </summary>
        private const String INSERT_SQL =
            @"
INSERT INTO test_tab (
  value1,  value2
) VALUES (
  ?value1,  ?value2
)";



        /// <summary>
        /// 用于 更新记录的 SQL 语句
        /// </summary>
        private const String UPDATE_SQL =
            @"
UPDATE test_tab 
  SET value1 =  ?value1,  value2 = ?value2
";



        /// <summary>
        /// 用于 删除记录的 SQL 语句.
        /// </summary>
        private const String DELETE_SQL = @"DELETE FROM test_tab";



        /// <summary>
        /// 用于查询的 SQL 语句.
        /// </summary>
        private const String SELECT_SQL =
            @"
SELECT
  value1,  value2
FROM
  test_tab";




        /// <summary>
        /// 用于查询的 SQL 语句.  (带 汉字的查询条件)
        /// </summary>
        private const String SELECT_SQL_WHERE =
            @"
SELECT
  value1,  value2
FROM
  test_tab
WHERE
  value1 = ?value1";




        /// <summary>
        /// 测试 新增 读取.
        /// </summary>
        public void TestInsertSelect()
        {

            // 建立数据库连接.
            MySqlConnection conn = new MySqlConnection(connString);


            try
            {
                // 打开连接.
                conn.Open();


                // 插入.
                InsertData(conn);

                // 查询.
                SelectData(conn);

                // 按指定名称查询. (目的为了测试 UTF8 的情况下， 汉字的查询是否正常)
                SelectDataByValue1(conn, "测试UTF8_1");


                // 更新
                UpdateData(conn);

                // 查询.
                SelectData(conn);


                // 按指定名称查询. (目的为了测试 UTF8 的情况下， 汉字的查询是否正常)
                SelectDataByValue1(conn, "再次测试UTF8_1");


                // 删除数据.
                DeleteData(conn);

            }
            catch (Exception ex)
            {
                Console.WriteLine("数据库读写操作发生了错误！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                // 关闭数据库.
                conn.Close();
            }

        }







        /// <summary>
        /// 插入数据.
        /// </summary>
        /// <param name="conn"></param>
        private void InsertData(MySqlConnection conn)
        {
            // 创建一个 Command.
            MySqlCommand insertCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            insertCommand.CommandText = INSERT_SQL;

            // 定义要查询的参数.

            insertCommand.Parameters.Add(new MySqlParameter("?value1", MySqlDbType.VarChar)).Value = "测试UTF8_1";
            insertCommand.Parameters.Add(new MySqlParameter("?value2", MySqlDbType.VarChar)).Value = "测试UTF8_2";

            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int insertRowCount = insertCommand.ExecuteNonQuery();

            Console.WriteLine("尝试插入数据， 结果造成了{0}条记录的插入。", insertRowCount);

        }



        /// <summary>
        /// 更新数据.
        /// </summary>
        /// <param name="conn"></param>
        private void UpdateData(MySqlConnection conn)
        {
            // 创建一个 Command.
            MySqlCommand updateCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            updateCommand.CommandText = UPDATE_SQL;

            // 定义要查询的参数.

            updateCommand.Parameters.Add(new MySqlParameter("?value1", MySqlDbType.VarChar)).Value = "再次测试UTF8_1";
            updateCommand.Parameters.Add(new MySqlParameter("?value2", MySqlDbType.VarChar)).Value = "再次测试UTF8_2";

            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int updateRowCount = updateCommand.ExecuteNonQuery();

            Console.WriteLine("尝试更新数据， 结果造成了{0}条记录的插入。", updateRowCount);

        }



        /// <summary>
        /// 删除数据.
        /// </summary>
        /// <param name="conn"></param>
        private void DeleteData (MySqlConnection conn)
        {
            // 创建一个 Command.
            MySqlCommand deleteCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            deleteCommand.CommandText = DELETE_SQL;

            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int deleteRowCount = deleteCommand.ExecuteNonQuery();

            Console.WriteLine("尝试删除数据， 结果造成了{0}条记录的插入。", deleteRowCount);

        }



        /// <summary>
        /// 查询数据.
        /// </summary>
        /// <param name="conn"></param>
        private void SelectData(MySqlConnection conn)
        {

            // 创建一个 Command.
            MySqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = SELECT_SQL;

            // 执行SQL命令，结果存储到Reader中.
            MySqlDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("value1:{0} ; value2:{1}   ",
                    testReader["value1"], testReader["value2"]
                    );
            }

            // 关闭Reader.
            testReader.Close();
        }




        /// <summary>
        /// 查询数据.  根据汉字作为查询条件.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="value1"></param>
        private void SelectDataByValue1(MySqlConnection conn, string value1)
        {

            // 创建一个 Command.
            MySqlCommand testCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            testCommand.CommandText = SELECT_SQL_WHERE;

            // 定义要查询的参数.
            testCommand.Parameters.Add(new MySqlParameter("?value1", MySqlDbType.VarChar)).Value = value1;


            // 执行SQL命令，结果存储到Reader中.
            MySqlDataReader testReader = testCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("根据 value1 = {0} 作为条件， 查询出; value2 = {1} 。  ",
                    testReader["value1"], testReader["value2"]
                    );
            }

            // 关闭Reader.
            testReader.Close();
        }



    }
}
