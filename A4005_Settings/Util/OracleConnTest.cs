using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OracleClient;

namespace A4005_Settings.Util
{
    class OracleConnTest : AbstractConnTest
    {
        protected override System.Data.Common.DbConnection GetConnection(string connString)
        {
            return new OracleConnection(connString);
        }
    }
}
