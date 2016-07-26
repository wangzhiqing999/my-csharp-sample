using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using MySql.Data.MySqlClient;

namespace A4005_Settings.Util
{
    class MySqlConnTest : AbstractConnTest
    {
        protected override System.Data.Common.DbConnection GetConnection(string connString)
        {
            return new MySqlConnection(connString);
        }
    }
}
