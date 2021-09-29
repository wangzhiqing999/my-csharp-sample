namespace A0662_EF_MySql_Work.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<A0662_EF_MySql_Work.DataAccess.MyWorkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(A0662_EF_MySql_Work.DataAccess.MyWorkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }




    internal sealed class Configuration2 : DbMigrationsConfiguration<A0662_EF_MySql_Work.DataAccess.MyWork2Context>
    {
        public Configuration2()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(A0662_EF_MySql_Work.DataAccess.MyWork2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }


}
