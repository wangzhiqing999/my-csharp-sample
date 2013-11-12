using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0150_Access.Sample
{
    class WriteAccessDB
    {

        /// <summary>
        /// Access 的数据库连接字符串.
        /// </summary>
        private const String connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\TeamMemberManager.mdb";

        /// <summary>
        /// 用于查询 数据是否存在的 SQL 语句.
        /// </summary>
        private const String EXIST_SQL = "SELECT COUNT(member_type_code) FROM team_member_type WHERE [member_type_code] = ?";


        /// <summary>
        /// 用于查询的 SQL 语句.
        /// </summary>
        private const String SELECT_SQL = "SELECT member_type_code, member_type_name FROM team_member_type WHERE [member_type_code] = ?";


        /// <summary>
        /// 用于 新增记录的 SQL 语句
        /// </summary>
        private const String INSERT_SQL = "INSERT INTO [team_member_type] ([member_type_code], [member_type_name]) VALUES (?, ?)";


        /// <summary>
        /// 用于更新的 SQL 语句.
        /// </summary>
        private const String UPDATE_SQL = "UPDATE [team_member_type] SET [member_type_name] = ? WHERE [member_type_code] = ? ";


        /// <summary>
        /// 用于删除的 SQL 语句.
        /// </summary>
        private const String DELETE_SQL = "DELETE FROM [team_member_type] WHERE [member_type_code] = ?";



        /// <summary>
        /// 用于 测试数据的 代码
        /// </summary>
        private const String TEST_TYPE_CODE = "CODE_7";



        /// <summary>
        /// 测试 新增、编辑、删除
        /// </summary>
        public void TestInsertUpdateDelete()
        {

            Console.WriteLine("使用Command，执行相关的SQL语句，来实现对数据库的 新增、编辑、删除 ");

            // 建立数据库连接.
            OleDbConnection conn = new OleDbConnection(connString);


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

                // 更新数据.
                UpdateData(conn);

                // 再次显示数据.
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
        private bool ExistData(OleDbConnection conn)
        {
            // 创建一个 Command.
            OleDbCommand existCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            existCommand.CommandText = EXIST_SQL;

            // 定义要查询的参数.
            // 注意：Access 与 Oracle/SQL Server 不同，
            //       Access 的SQL中的查询的参数，无法命名。只能用 ? 来表明这是外部传入的参数.
            //       因此，参数只能按照 SQL 中 ? 的顺序，进行添加.
            existCommand.Parameters.Add(new OleDbParameter("?", TEST_TYPE_CODE));

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
        private void InsertData(OleDbConnection conn)
        {
            // 创建一个 Command.
            OleDbCommand insertCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            insertCommand.CommandText = INSERT_SQL;

            // 定义要查询的参数.
            // 注意：Access 与 Oracle/SQL Server 不同，
            //       Access 的SQL中的查询的参数，无法命名。只能用 ? 来表明这是外部传入的参数.
            //       因此，参数只能按照 SQL 中 ? 的顺序，进行添加.
            insertCommand.Parameters.Add(new OleDbParameter("?", TEST_TYPE_CODE));
            insertCommand.Parameters.Add(new OleDbParameter("?", "新插入的名字"));


            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int insertRowCount = insertCommand.ExecuteNonQuery();

            Console.WriteLine("尝试插入数据， 结果造成了{0}条记录的插入。", insertRowCount);

        }


        /// <summary>
        /// 显示数据.
        /// </summary>
        /// <param name="conn"></param>
        private void ShowData(OleDbConnection conn)
        {
            // 创建一个 Command.
            OleDbCommand selectCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            selectCommand.CommandText = SELECT_SQL;

            // 定义要查询的参数.
            selectCommand.Parameters.Add(new OleDbParameter("?", TEST_TYPE_CODE));

            // 执行SQL命令，结果存储到Reader中.
            OleDbDataReader testReader = selectCommand.ExecuteReader();

            // 处理检索出来的每一条数据.
            while (testReader.Read())
            {
                // 将检索出来的数据，输出到屏幕上.
                Console.WriteLine("ID: {0}   Name: {1}",
                    testReader["member_type_code"], testReader["member_type_name"]
                    );
            }

            // 关闭Reader.
            testReader.Close();
        }


        /// <summary>
        /// 更新数据.
        /// </summary>
        /// <param name="conn"></param>
        private void UpdateData(OleDbConnection conn)
        {
            // 创建一个 Command.
            OleDbCommand updateCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            updateCommand.CommandText = UPDATE_SQL;

            // 定义要查询的参数.
            // 注意：Access 与 Oracle/SQL Server 不同，
            //       Access 的SQL中的查询的参数，无法命名。只能用 ? 来表明这是外部传入的参数.
            //       因此，参数只能按照 SQL 中 ? 的顺序，进行添加.
            // 由于 UPDATE 语句中 ? 的顺序， 是名字在前面，因此，参数这里，要把名字先加入。
            // 这个顺序与 INSERT 的 参数顺序不一样。
            updateCommand.Parameters.Add(new OleDbParameter("?", "修改后的名字"));
            updateCommand.Parameters.Add(new OleDbParameter("?", TEST_TYPE_CODE));
            


            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int updateRowCount = updateCommand.ExecuteNonQuery();

            Console.WriteLine("尝试更新数据， 结果造成了{0}条记录的更新。", updateRowCount);
        }



        private void DeleteData(OleDbConnection conn)
        {
            // 创建一个 Command.
            OleDbCommand deleteCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            deleteCommand.CommandText = DELETE_SQL;

            // 定义要查询的参数.
            deleteCommand.Parameters.Add(new OleDbParameter("?", TEST_TYPE_CODE));

            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int updateRowCount = deleteCommand.ExecuteNonQuery();

            Console.WriteLine("尝试删除数据， 结果造成了{0}条记录的删除。", updateRowCount);
        }




        
        
        
        /// <summary>
        /// 演示 事务处理的部分。
        /// </summary>
        /// <param name="conn"></param>
        private void Transaction(OleDbConnection conn)
        {
            
            Console.WriteLine("开始事务处理操作！");

            // 开始创建一个事务.
            OleDbTransaction t = conn.BeginTransaction();

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
                Console.WriteLine("数据库中依然存在着编号为{0}的数据！", TEST_TYPE_CODE);
            }
            else
            {
                Console.WriteLine("数据库中已检索不到编号为{0}的数据！", TEST_TYPE_CODE);
            }
        }


        /// <summary>
        /// 以事务处理的方式插入数据. 
        /// 
        /// 当操作涉及 事务处理的时候， 需要在 OleDbConnection 的 BeginTransaction() 之后。
        /// 
        /// 设置 Command 的 Transaction 属性
        /// 
        /// </summary>
        /// <param name="conn"></param>
        private void InsertData(OleDbConnection conn, OleDbTransaction t)
        {
            // 创建一个 Command.
            OleDbCommand insertCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            insertCommand.CommandText = INSERT_SQL;

            // 注意： 只有加了这一句， 才能事务处理！！！
            insertCommand.Transaction = t;

            // 定义要查询的参数.
            // 注意：Access 与 Oracle/SQL Server 不同，
            //       Access 的SQL中的查询的参数，无法命名。只能用 ? 来表明这是外部传入的参数.
            //       因此，参数只能按照 SQL 中 ? 的顺序，进行添加.
            insertCommand.Parameters.Add(new OleDbParameter("?", TEST_TYPE_CODE));
            insertCommand.Parameters.Add(new OleDbParameter("?", "新插入的名字"));


            // ExecuteNonQuery 方法，表明本次操作，不是一个查询的操作。将没有结果集合返回.
            // 返回的数据，将是 被影响的记录数.
            int insertRowCount = insertCommand.ExecuteNonQuery();

            Console.WriteLine("尝试插入数据， 结果造成了{0}条记录的插入。", insertRowCount);

        }


    }
}
