using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;


namespace ProvisionFilteredScopeClient
{


    /// <summary>
    /// 本程序是 客户端运行的 初始化程序.
    /// 
    /// 需要在服务器执行完初始化以后， 再运行本程序， 完成客户端初始化的操作.
    /// 
    /// 服务器端需要初始化，创建表。
    /// 客户端不需要先手动创建表的。 运行本程序以后， 会参照服务器的设置， 在客户端创建表.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            // 客户端的连接.
            SqlConnection clientConn = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SyncExpressDB; Trusted_Connection=Yes");

            // 服务端的连接.
            SqlConnection serverConn = new SqlConnection("Data Source=localhost; Initial Catalog=SyncDB; Integrated Security=True");


            // 从 服务器上， 获取 同步范围的数据.
            // get description for the OrdersScope-NC scope from the SyncDB server database
            DbSyncScopeDescription scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope("OrdersScope-NC", serverConn);


            // 将同步范围的数据， 写入到客户端.
            // create a provisioning object 
            SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc);

            // start the provisioning process
            clientProvision.Apply();


        }
    }
}
