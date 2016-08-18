using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

using W0800_MVVM_Knockout.Models;


namespace W0800_MVVM_Knockout.DataAccess
{
    // Enable-Migrations -ProjectName W0800_MVVM_Knockout  -EnableAutomaticMigrations
    public class TestContext : DbContext
    {


        public TestContext()
            : base("name=TestContext")
        {
        }


        /// <summary>
        /// 联系信息.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }


    }
}