using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace A4005_Settings.Util
{


    /// <summary>
    /// SQL Server 连接测试.
    /// </summary>
    class SqlConnTest : AbstractConnTest
    {
        protected override System.Data.Common.DbConnection GetConnection(string connString)
        {
            return new SqlConnection(connString);
        }
    }


}
