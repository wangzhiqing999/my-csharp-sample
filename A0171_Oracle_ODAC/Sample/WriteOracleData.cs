using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;


namespace A0171_Oracle_ODAC.Sample
{

    /// <summary>
    /// 测试写入 Oracle 数据.
    /// </summary>
    class WriteOracleData
    {

        /// <summary>
        /// Oracle 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.56.101)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=TEST;Password=TEST";


        /// <summary>
        /// 用于查询 数据是否存在的 SQL 语句.
        /// </summary>
        private const String EXIST_SQL =
            @"
SELECT 
  COUNT(1) 
FROM 
  sale_report 
WHERE 
  sale_date = :sale_date
  AND sale_item = :sale_item";


        /// <summary>
        /// 用于查询的 SQL 语句.
        /// </summary>
        private const String SELECT_SQL =
            @"
SELECT 
  sale_date, sale_item, sale_money 
FROM
  sale_report 
WHERE
  sale_date = :sale_date
  AND sale_item = :sale_item";


        /// <summary>
        /// 用于 新增记录的 SQL 语句
        /// </summary>
        private const String INSERT_SQL =
            @"
INSERT INTO sale_report (
  sale_date, sale_item, sale_money
) VALUES (
  :sale_date, :sale_item, :sale_money
)";


        /// <summary>
        /// 用于更新的 SQL 语句.
        /// </summary>
        private const String UPDATE_SQL =
            @"
UPDATE 
  sale_report
SET 
  sale_money = :sale_money
WHERE 
  sale_date = :sale_date
  AND sale_item = :sale_item";



        /// <summary>
        /// 用于删除的 SQL 语句.
        /// </summary>
        private const String DELETE_SQL =
            @"
DELETE FROM 
  sale_report
WHERE 
  sale_date = :sale_date
  AND sale_item = :sale_item";



        /// <summary>
        /// 用于 测试数据的 日期
        /// </summary>
        private static DateTime TEST_SALE_DATE = new DateTime(2012, 12, 21);

        /// <summary>
        /// 用于测试用的 项目.
        /// </summary>
        private const String TEST_SALE_ITEM = "TA";



        /// <summary>
        /// 测试 新增、编辑、删除
        /// </summary>
        public void TestInsertUpdateDelete()
        {

            Console.WriteLine("使用Command，执行相关的SQL语句，来实现对数据库的 新增、编辑、删除 ");

            // 建立数据库连接.
            OracleConnection conn = new OracleConnection(connString);


            try
            {
                // 打开连接.
                conn.Open();

                if (ExistData(conn))
                {
                    Console.WriteLine("主键为 {0} 与 {1} 的数据，已经存在，无法进行新数据的插入！", TEST_SALE_DATE, TEST_SALE_ITEM);
                }
                else
                {
                    Console.WriteLine("开始进行主键为{0} 与 {1} 的数据的插入！", TEST_SALE_DATE, TEST_SALE_ITEM);
                    InsertData(conn);
                }

                // 显示数据.
                ShowData(conn);

                // 更新数据.
                UpdateData(conn);

                // 再次显示数据.
                ShowData(conn);

                // 删除数据.
                DeleteData(conn);

                if (ExistData(conn))
                {
                    Console.WriteLine("主键为{0} 与 {1} 的的数据，没有成功的被删除！", TEST_SALE_DATE, TEST_SALE_ITEM);
                }
                else
                {
                    Console.WriteLine("数据库中已检索不到主键为{0} 与 {1} 的的数据！", TEST_SALE_DATE, TEST_SALE_ITEM);
                }

                // 事务处理.
                Transaction(conn);

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
        private bool ExistData(OracleConnection conn)
        {
            // 创建一个 Command.
            OracleCommand existCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            existCommand.CommandText = EXIST_SQL;

            // 定义要查询的参数.
            existCommand.Parameters.Add(new OracleParameter(":sale_date", TEST_SALE_DATE));
            existCommand.Parameters.Add(new OracleParameter(":sale_item", TEST_SALE_ITEM));

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
        private void InsertData(OracleConnection conn)
        {
            // 创建一个 Command.
            OracleCommand insertCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            insertCommand.CommandText = INSERT_SQL;

            // 定义要查询的参数.
            insertCommand.Parameters.Add(new OracleParameter(":sale_date", TEST_SALE_DATE));
            insertCommand.Parameters.Add(new OracleParameter(":sale_item", TEST_SALE_ITEM));
            insertCommand.Parameters.Add(new OracleParameter(":sale_money", 100000));


            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int insertRowCount = insertCommand.ExecuteNonQuery();

            Console.WriteLine("尝试插入数据， 结果造成了{0}条记录的插入。", insertRowCount);

        }



        /// <summary>
        /// 显示数据.
        /// </summary>
        /// <param name="conn"></param>
        private void ShowData(OracleConnection conn)
        {
            // 创建一个 Command.
            OracleCommand selectCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            selectCommand.CommandText = SELECT_SQL;

            // 定义要查询的参数.
            selectCommand.Parameters.Add(new OracleParameter(":sale_date", TEST_SALE_DATE));
            selectCommand.Parameters.Add(new OracleParameter(":sale_item", TEST_SALE_ITEM));

            // 执行SQL命令，结果存储到Reader中.
            OracleDataReader testReader = selectCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("sale_date:{0}; sale_item:{1}; sale_money:{2}",
                    testReader["sale_date"], testReader["sale_item"], testReader["sale_money"]
                    );
            }

            // 关闭Reader.
            testReader.Close();
        }



        /// <summary>
        /// 更新数据.
        /// </summary>
        /// <param name="conn"></param>
        private void UpdateData(OracleConnection conn)
        {
            // 创建一个 Command.
            OracleCommand updateCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            updateCommand.CommandText = UPDATE_SQL;

            // 定义要查询的参数.
            updateCommand.Parameters.Add(new OracleParameter(":sale_date", TEST_SALE_DATE));
            updateCommand.Parameters.Add(new OracleParameter(":sale_item", TEST_SALE_ITEM));
            updateCommand.Parameters.Add(new OracleParameter(":sale_money", 0.1));



            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int updateRowCount = updateCommand.ExecuteNonQuery();

            Console.WriteLine("尝试更新数据， 结果造成了{0}条记录的更新。", updateRowCount);
        }


        private void DeleteData(OracleConnection conn)
        {
            // 创建一个 Command.
            OracleCommand deleteCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            deleteCommand.CommandText = DELETE_SQL;

            // 定义要查询的参数.
            deleteCommand.Parameters.Add(new OracleParameter(":sale_date", TEST_SALE_DATE));
            deleteCommand.Parameters.Add(new OracleParameter(":sale_item", TEST_SALE_ITEM));

            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int updateRowCount = deleteCommand.ExecuteNonQuery();

            Console.WriteLine("尝试删除数据， 结果造成了{0}条记录的删除。", updateRowCount);
        }



        /// <summary>
        /// 演示 事务处理的部分。
        /// </summary>
        /// <param name="conn"></param>
        private void Transaction(OracleConnection conn)
        {

            Console.WriteLine("开始事务处理操作！");

            // 开始创建一个事务.
            OracleTransaction t = conn.BeginTransaction();

            try
            {
                Console.WriteLine("模拟插入2条相同数据，造成主键冲突的异常！");

                InsertData(conn, t);
                InsertData(conn, t);

                // 提交事务.
                t.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                // 回滚事务.
                t.Rollback();
            }


            if (ExistData(conn))
            {
                Console.WriteLine("数据库中依然存在着主键为{0} 与 {1} 的的数据！", TEST_SALE_DATE, TEST_SALE_ITEM);
            }
            else
            {
                Console.WriteLine("数据库中已检索不到主键为{0} 与 {1} 的的数据！", TEST_SALE_DATE, TEST_SALE_ITEM);
            }
        }


        /// <summary>
        /// 插入数据.
        /// </summary>
        /// <param name="conn"></param>
        private void InsertData(OracleConnection conn, OracleTransaction t)
        {
            // 创建一个 Command.
            OracleCommand insertCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            insertCommand.CommandText = INSERT_SQL;

            // 注意： 只有加了这一句， 才能事务处理！！！
            insertCommand.Transaction = t;

            // 定义要查询的参数.
            insertCommand.Parameters.Add(new OracleParameter(":sale_date", TEST_SALE_DATE));
            insertCommand.Parameters.Add(new OracleParameter(":sale_item", TEST_SALE_ITEM));
            insertCommand.Parameters.Add(new OracleParameter(":sale_money", 100000));


            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int insertRowCount = insertCommand.ExecuteNonQuery();

            Console.WriteLine("尝试插入数据， 结果造成了{0}条记录的插入。", insertRowCount);

        }

    }

}
