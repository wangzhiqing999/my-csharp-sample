using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0160_SQL_Server.Sample
{

    /// <summary>
    /// 测试读写 二进制数据的例子.
    /// </summary>
    public class ReadWriteBinData
    {

        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";



        /// <summary>
        /// 用于查询 数据是否存在的 SQL 语句.
        /// </summary>
        private const String EXIST_SQL = "SELECT COUNT(Test_Name) FROM Test_BinData WHERE [Test_Name] = @Test_Name";


        /// <summary>
        /// 插入的 sql 语句.
        /// </summary>
        private const string INSERT_SQL = @"INSERT INTO Test_BinData (Test_Name, Test_Data) VALUES(@Test_Name,@Test_Data)";


        /// <summary>
        /// 查询的 sql 语句.
        /// </summary>
        private const string SELECT_SQL = @"SELECT * FROM Test_BinData WHERE Test_Name = @Test_Name";


        /// <summary>
        /// 用于删除的 SQL 语句.
        /// </summary>
        private const String DELETE_SQL = "DELETE FROM [Test_BinData] WHERE [Test_Name] = @Test_Name";




        /// <summary>
        /// 用于 测试数据的 代码
        /// </summary>
        private const String TEST_TYPE_CODE = "CODE_7";



        /// <summary>
        /// 用于测试的 二进制文件名.
        /// </summary>
        private const string TEST_BIN_FILENAME = "TestData.jpg";



        /// <summary>
        /// 测试读写.
        /// </summary>
        public void TestWriteAndRead()
        {
            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);

            try
            {

                // 打开连接.
                conn.Open();

                if (ExistData(conn))
                {
                    Console.WriteLine("编号为{0}的数据，已经存在，无法进行新数据的插入！", TEST_TYPE_CODE);
                }
                else
                {
                    Console.WriteLine("开始进行编号为{0}的数据的插入！", TEST_TYPE_CODE);
                    InsertData(conn);
                }

                // 显示数据.
                ShowData(conn);

                // 删除数据.
                DeleteData(conn);

                if (ExistData(conn))
                {
                    Console.WriteLine("编号为{0}的数据，没有成功的被删除！", TEST_TYPE_CODE);
                }
                else
                {
                    Console.WriteLine("数据库中已检索不到编号为{0}的数据！", TEST_TYPE_CODE);
                }

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
        /// 检测数据库中，是否有指定记录的数据.
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        private bool ExistData(SqlConnection conn)
        {
            // 创建一个 Command.
            SqlCommand existCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            existCommand.CommandText = EXIST_SQL;

            // 定义要查询的参数.
            // 注意：Access 与 Oracle/SQL Server 不同，
            //       Access 的SQL中的查询的参数，无法命名。只能用 ? 来表明这是外部传入的参数.
            //       因此，参数只能按照 SQL 中 ? 的顺序，进行添加.
            existCommand.Parameters.Add(new SqlParameter("@Test_Name", TEST_TYPE_CODE));

            // 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
            Object oRowCount = existCommand.ExecuteScalar();

            // 转换为 int 类型.
            int rowCount = Convert.ToInt32(oRowCount);

            return (rowCount != 0);
        }




        /// <summary>
        /// 插入数据.
        /// </summary>
        /// <param name="conn"></param>
        private void InsertData(SqlConnection conn)
        {
            // 创建一个 Command.
            SqlCommand insertCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            insertCommand.CommandText = INSERT_SQL;

            // 定义要查询的参数.
            insertCommand.Parameters.Add(new SqlParameter("@Test_Name", TEST_TYPE_CODE));

            System.IO.FileStream fs = new System.IO.FileStream(TEST_BIN_FILENAME, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            byte[] buffer = br.ReadBytes((int)fs.Length);            

            // 这里需要插入的第二个参数， 是 二进制数据文件了.
            insertCommand.Parameters.Add(new SqlParameter("@Test_Data", buffer));


            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int insertRowCount = insertCommand.ExecuteNonQuery();

            Console.WriteLine("尝试插入数据， 结果造成了{0}条记录的插入。", insertRowCount);

            // 关闭文件.
            fs.Close();
        }


        /// <summary>
        /// 显示数据.
        /// </summary>
        /// <param name="conn"></param>
        private void ShowData(SqlConnection conn)
        {
            // 创建一个 Command.
            SqlCommand selectCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            selectCommand.CommandText = SELECT_SQL;

            // 定义要查询的参数.
            selectCommand.Parameters.Add(new SqlParameter("@Test_Name", TEST_TYPE_CODE));

            // 执行SQL命令，结果存储到Reader中.
            SqlDataReader testReader = selectCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("Test_Name: {0}", testReader["Test_Name"]);


                byte[] buff = (byte[])testReader["Test_Data"];

                // 输出文件名
                string strSavePath = TEST_TYPE_CODE + ".jpg";

                if (System.IO.File.Exists(strSavePath))
                {
                    // 如果文件已存在，先删除.
                    System.IO.File.Delete(strSavePath);
                }

                // 输出文件.
                System.IO.FileStream stream = new System.IO.FileStream(strSavePath, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
                System.IO.BinaryWriter bw = new System.IO.BinaryWriter(stream);
                bw.Write(buff);
                bw.Close();
                stream.Close();  

            }

            // 关闭Reader.
            testReader.Close();
        }




        /// <summary>
        /// 删除数据.
        /// </summary>
        /// <param name="conn"></param>
        private void DeleteData(SqlConnection conn)
        {
            // 创建一个 Command.
            SqlCommand deleteCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            deleteCommand.CommandText = DELETE_SQL;

            // 定义要查询的参数.
            deleteCommand.Parameters.Add(new SqlParameter("@Test_Name", TEST_TYPE_CODE));

            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int updateRowCount = deleteCommand.ExecuteNonQuery();

            Console.WriteLine("尝试删除数据， 结果造成了{0}条记录的删除。", updateRowCount);
        }





    }


}
