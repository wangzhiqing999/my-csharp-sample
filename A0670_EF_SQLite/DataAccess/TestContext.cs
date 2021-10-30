using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using A0670_EF_SQLite.Model;
using System.Data.Common;

namespace A0670_EF_SQLite.DataAccess
{
    public class TestContext : DbContext
    {
        public TestContext()
            : base("name=TestContext")
        {

        }



        public TestContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            // 注意：
            // 调用这个构造函数， 如果传递的是 Data Source=...  这样的连接字符串的话.
            // 最终会导致翻车.
            // 原因是没有传递 providerName 的地方。
            // 不知道使用什么，那么使用默认的 sql server.
            // 最终就翻了.
        }




        public TestContext(DbConnection conn, bool contextOwnsConnection)
            : base(conn, contextOwnsConnection)
        {
            // 这个是 外部初始化好 SQLiteConnection
            // 然后构造 DbContext 的.
            // 但是， 好像不会做初始化数据库表的操作。
        }



        /// <summary>
        /// 账户.
        /// </summary>
        public DbSet<Test> Tests { get; set; }



    }
}
