using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;



// 本项目 需要安装  SyncSDK-v2.1-x64-CHS.msi  


namespace ProvisionServer
{


    /// <summary>
    /// 本程序是 服务器端运行的 初始化程序.
    /// 
    /// 需要首先执行.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 服务器连接.
            // connect to server database
            SqlConnection serverConn = new SqlConnection("Data Source=localhost; Initial Catalog=SyncDB; Integrated Security=True");


            // 定义一个 同步范围
            // define a new scope named ProductsScope
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription("ProductsScope");


            // 同步范围 增加一个表.
            // get the description of the Products table from SyncDB dtabase
            DbSyncTableDescription tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable("Products", serverConn);

            // add the table description to the sync scope definition
            scopeDesc.Tables.Add(tableDesc);




            // 将同步范围定义的信息，更新到数据库上面去.

            // create a server scope provisioning object based on the ProductScope
            SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);

            // skipping the creation of table since table already exists on server
            serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);

            // start the provisioning process
            serverProvision.Apply();
          

            // 该应用程序，运行完毕后， 会在 服务器上面， 创建这些表：
            // Products_Tracking, schema_info, scope_config, scope_info

        }




    }


}
