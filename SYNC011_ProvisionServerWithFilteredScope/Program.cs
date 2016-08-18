using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;


namespace ProvisionServerWithFilteredScope
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
            SqlConnection serverConn = new SqlConnection("Data Source=localhost; Initial Catalog=SyncDB; Integrated Security=True");

            // 定义一个 同步范围
            // define the OrdersScope-NC filtered scope 
            // this scope filters records in the Orders table with OriginState set to NC
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription("OrdersScope-NC");


            // 同步范围 增加一个表.
            // get the description of the Orders table and add it to the scope
            DbSyncTableDescription tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable("Orders", serverConn);
            scopeDesc.Tables.Add(tableDesc);



            // 将同步范围定义的信息，更新到数据库上面去.

            // create server provisioning object
            SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);

            // no need to create the Orders table since it already exists, 
            // so use the Skip parameter
            serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);


            // 这里是 为同步范围中的表， 追加一个额外的 限定条件.
            // 也就是要求 OriginState 这一列的数值， 等于  NC.
            // 不满足条件的数据，将不参与 同步.

            // set the filter column on the Orders table to OriginState
            serverProvision.Tables["Orders"].AddFilterColumn("OriginState");
            // set the filter value to NC
            serverProvision.Tables["Orders"].FilterClause = "[side].[OriginState] = 'NC'";


            // start the provisioning process
            serverProvision.Apply();

        }
    }
}
