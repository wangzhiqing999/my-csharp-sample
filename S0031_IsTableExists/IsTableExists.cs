using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{

    /// <summary>
    /// 查询指定表的 指定条件的数据是否存在.
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="queryInfo">查询条件</param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.Read)]
    public static SqlInt32 IsTableExists(SqlString tableName, SqlString queryInfo)
    {
        SqlConnection cnn = new SqlConnection("context connection=true");
        cnn.Open();

        // 查询结果.
        Object result = null;

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            // 拼SQL.
            string sql = "SELECT Top 1 1 FROM " + tableName.ToString();
            if( !String.IsNullOrEmpty(queryInfo.ToString())) {
                sql = sql + " WHERE " + queryInfo.ToString();
            }

            // 准备用于检索数据的 动态SQL.
            cmd.CommandText = sql;
            // 执行查询.
            result = cmd.ExecuteScalar();
        } catch  {
            // 发生异常的情况下，认为不存在.
            result = null;
        }
        finally {
            // 必须关闭连接.
            cnn.Close();
        }


        if (result == null)
        {
            return new SqlInt32(0);
        }

        // 在此处放置代码
        return new SqlInt32(1);
    }



};

