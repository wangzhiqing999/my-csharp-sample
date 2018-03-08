namespace A0661_EF_MySql_RowVersion.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<A0661_EF_MySql_RowVersion.DataAccess.TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(A0661_EF_MySql_RowVersion.DataAccess.TestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // 注意： 
            //     这里的 DATETIME(6) 与 后面的 CURRENT_TIMESTAMP(6)
            //     是让 MySQL 支持到 秒后面的 6位小数.
            //     如果不加的话， 精度只到 "秒"。
            string rowVersionSQL = @"ALTER TABLE `test2`.`test_table` 
CHANGE COLUMN `RowVersion` `RowVersion` DATETIME(6) NOT NULL 
DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6)";

            context.Database.ExecuteSqlCommand(rowVersionSQL);
        }
    }
}
