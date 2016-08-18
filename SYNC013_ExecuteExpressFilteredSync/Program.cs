using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;


namespace ExecuteExpressFilteredSync
{

    /// <summary>
    /// 同步程序.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            // 客户端 数据库连接.
            // connect to the SQL Express database
            SqlConnection clientConn = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=SyncExpressDB; Trusted_Connection=Yes");


            // 服务端 数据库连接.
            // connect to the server database
            SqlConnection serverConn = new SqlConnection("Data Source=localhost; Initial Catalog=SyncDB; Integrated Security=True");


            // 同步范围
            // create a sync orchestration object
            SyncOrchestrator syncOrchestrator = new SyncOrchestrator();

            // set the local provider of sync orchestrator to a sync provider that is
            // associated with the OrdersScope-NC scope in the SyncExpressDB database
            syncOrchestrator.LocalProvider = new SqlSyncProvider("OrdersScope-NC", clientConn);

            // set the remote provider of sync orchestrator to a server sync provider that is
            // associated with the OrdersScope-NC scope in the SyncDB database
            syncOrchestrator.RemoteProvider = new SqlSyncProvider("OrdersScope-NC", serverConn);


            // 数据同步的方向
            // set the direction to Upload and Download
            syncOrchestrator.Direction = SyncDirectionOrder.Download;

            // 同步失败的情况下，所做的操作.
            // subscribe for errors that occur when applying changes to the client
            ((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);


            // 执行同步处理.
            // starts the synchornization session
            SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();


            // 输出同步结果.
            // prints statistics from the sync session
            Console.WriteLine("Start Time: " + syncStats.SyncStartTime);
            Console.WriteLine("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
            Console.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
            Console.WriteLine("Complete Time: " + syncStats.SyncEndTime);
            Console.WriteLine(String.Empty);



            Console.ReadLine();

        }




        static void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
        {
            // display conflict type
            Console.WriteLine(e.Conflict.Type);

            // display error message 
            Console.WriteLine(e.Error);
        }

    }
}
