using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using A0670_EF_SQLite.Model;

namespace A0670_EF_SQLite.DataAccess
{
    public class TestContext : DbContext
    {
        public TestContext()
            : base("name=TestContext")
        {

        }



        /// <summary>
        /// 账户.
        /// </summary>
        public DbSet<Test> Tests { get; set; }



    }
}
