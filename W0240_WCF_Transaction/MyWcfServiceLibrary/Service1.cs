using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace MyWcfServiceLibrary
{




    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Single, 
        InstanceContextMode = InstanceContextMode.PerCall,          
        TransactionTimeout = "00:30:00" )]
    public class Service1 : IService1
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }



        /// <summary>
        /// SQL Server 的数据库连接字符串.
        /// </summary>
        private const String connString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";



        /// <summary>
        /// 用于 新增记录的 SQL 语句
        /// </summary>
        private const String INSERT_MAIN_SQL = @"
INSERT INTO test_main (
    id, value
) VALUES (
    @id, @value
)
";



        /// <summary>
        /// 用于 新增记录的 SQL 语句
        /// </summary>
        private const String INSERT_SUB_SQL = @"
INSERT INTO test_sub (
    id, main_id, value
) VALUES (
    @id, @main_id, @value
)
";


        /// <summary>
        /// 用于 删除记录的 SQL 语句
        /// </summary>
        private const String DELETE_MAIN_SQL = @"
DELETE 
    test_main
WHERE
    id = @id
";

        /// <summary>
        /// 用于 删除记录的 SQL 语句
        /// </summary>
        private const String DELETE_SUB_SQL = @"
DELETE 
    test_sub
WHERE
    main_id = @main_id
";




        /// <summary>
        /// 用于测试 事务处理的方法.
        /// 
        /// 下面的 
        /// TransactionScopeRequired = true 意味着， 这个方法需要一个事务。
        /// TransactionAutoComplete = true 意味着， 这个方法执行结束后，将提交事务 （如果执行没有抛出异常）。
        /// </summary>
        /// <param name="main_id"></param>
        /// <param name="main_val"></param>
        /// <param name="sub_id"></param>
        /// <param name="sub_value"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true, 
            TransactionAutoComplete = true)]
        public bool TestInsertData(int main_id, string main_val, int sub_id, string sub_value)
        {

            // 请注意： 
            // 由于是使用 WCF 来进行事务的管理.
            // 因此下面的代码中， 没有使用  SqlTransaction 来进行 手动管理事务。


            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                // 打开连接.
                conn.Open();
                // 创建一个 Command.
                SqlCommand insertCommand = conn.CreateCommand();

                // 定义需要执行的SQL语句.
                insertCommand.CommandText = INSERT_MAIN_SQL;
                // 定义要查询的参数.
                insertCommand.Parameters.Add(new SqlParameter("@id", main_id));
                insertCommand.Parameters.Add(new SqlParameter("@value", main_val));
                insertCommand.ExecuteNonQuery();

                // 定义需要执行的SQL语句.
                insertCommand.CommandText = INSERT_SUB_SQL;
                insertCommand.Parameters.Clear();

                // 定义要查询的参数.
                insertCommand.Parameters.Add(new SqlParameter("@id", sub_id));
                insertCommand.Parameters.Add(new SqlParameter("@main_id", main_id));
                insertCommand.Parameters.Add(new SqlParameter("@value", sub_value));
                insertCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                // 由于是使用 WCF 来管理事务.
                // 因此，发生异常了， 就必须抛出异常
                // 不能自己 Catch 住了， 然后简单返回 false.

                // 如果自己 Catch 住了，简单返回 false 的话， WCF 认为你的程序执行正常，就你做的修改提交了，而不是回滚掉。
                throw new FaultException(ex.ToString(), new FaultCode(ex.Message));
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch
                {
                }
            }

        }



        /// <summary>
        /// 用于删除记录的方法.
        /// </summary>
        /// <param name="main_id"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true,
            TransactionAutoComplete = true)]
        public bool TestDeleteData(int main_id)
        {
            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                // 打开连接.
                conn.Open();
                // 创建一个 Command.
                SqlCommand deleteCommand = conn.CreateCommand();

                // 定义需要执行的SQL语句.
                deleteCommand.CommandText = DELETE_SUB_SQL;
                // 定义要查询的参数.
                deleteCommand.Parameters.Add(new SqlParameter("@main_id", main_id));
                deleteCommand.ExecuteNonQuery();

                // 定义需要执行的SQL语句.
                deleteCommand.CommandText = DELETE_MAIN_SQL;
                deleteCommand.Parameters.Clear();

                // 定义要查询的参数.
                deleteCommand.Parameters.Add(new SqlParameter("@id", main_id));
                deleteCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                // 由于是使用 WCF 来管理事务.
                // 因此，发生异常了， 就必须抛出异常
                // 不能自己 Catch 住了， 然后简单返回 false.

                // 如果自己 Catch 住了，简单返回 false 的话， WCF 认为你的程序执行正常，就你做的修改提交了，而不是回滚掉。
                throw new FaultException(ex.ToString(), new FaultCode(ex.Message));
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch
                {
                }
            }
        }









        #region 测试 WCF 调用 多个内部方法.


        /// <summary>
        /// 仅仅插入 主表.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true,
            TransactionAutoComplete = true)]
        public bool TestInsertMain(int id, string val)
        {
            // 请注意： 
            // 由于是使用 WCF 来进行事务的管理.
            // 因此下面的代码中， 没有使用  SqlTransaction 来进行 手动管理事务。


            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                // 打开连接.
                conn.Open();
                // 创建一个 Command.
                SqlCommand insertCommand = conn.CreateCommand();

                // 定义需要执行的SQL语句.
                insertCommand.CommandText = INSERT_MAIN_SQL;
                // 定义要查询的参数.
                insertCommand.Parameters.Add(new SqlParameter("@id", id));
                insertCommand.Parameters.Add(new SqlParameter("@value", val));
                insertCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                // 由于是使用 WCF 来管理事务.
                // 因此，发生异常了， 就必须抛出异常
                // 不能自己 Catch 住了， 然后简单返回 false.

                // 如果自己 Catch 住了，简单返回 false 的话， WCF 认为你的程序执行正常，就你做的修改提交了，而不是回滚掉。
                throw new FaultException(ex.ToString(), new FaultCode(ex.Message));
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 仅仅插入 子表.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="main_id"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true,
            TransactionAutoComplete = true)]
        public bool TestInsertSub(int id, int main_id, string val)
        {

            // 请注意： 
            // 由于是使用 WCF 来进行事务的管理.
            // 因此下面的代码中， 没有使用  SqlTransaction 来进行 手动管理事务。


            // 建立数据库连接.
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                // 打开连接.
                conn.Open();
                // 创建一个 Command.
                SqlCommand insertCommand = conn.CreateCommand();

                // 定义需要执行的SQL语句.
                insertCommand.CommandText = INSERT_SUB_SQL;

                // 定义要查询的参数.
                insertCommand.Parameters.Add(new SqlParameter("@id", id));
                insertCommand.Parameters.Add(new SqlParameter("@main_id", main_id));
                insertCommand.Parameters.Add(new SqlParameter("@value", val));
                insertCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                // 由于是使用 WCF 来管理事务.
                // 因此，发生异常了， 就必须抛出异常
                // 不能自己 Catch 住了， 然后简单返回 false.

                // 如果自己 Catch 住了，简单返回 false 的话， WCF 认为你的程序执行正常，就你做的修改提交了，而不是回滚掉。
                throw new FaultException(ex.ToString(), new FaultCode(ex.Message));
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch
                {
                }
            }
        }



        /// <summary>
        /// 调用 TestInsertMain 与 TestInsertSub
        /// 
        /// 分别插入 主表与子表.
        /// </summary>
        /// <param name="main_id"></param>
        /// <param name="main_val"></param>
        /// <param name="sub_id"></param>
        /// <param name="sub_value"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationBehavior(
            TransactionScopeRequired = true,
            TransactionAutoComplete = true)]
        public bool TestInsertAll(int main_id, string main_val, int sub_id, string sub_value)
        {

            // 调用2个内部方法.

            // 测试的目的：
            // 这2个方法，在执行完毕后，都有 conn.Close();的处理。
            // 这里 预期是 
            //  第一个 方法执行成功后，conn.Close()
            //  第二个方法执行失败。
            //  需要确认 失败时，整个事物是否能够成功地回滚。

            TestInsertMain(main_id, main_val);
            TestInsertSub(sub_id, main_id, sub_value);

            return true;
        }


        #endregion  


    }
}
