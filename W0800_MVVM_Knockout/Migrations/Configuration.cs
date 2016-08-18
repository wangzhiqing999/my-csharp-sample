namespace W0800_MVVM_Knockout.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using W0800_MVVM_Knockout.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<W0800_MVVM_Knockout.DataAccess.TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "W0800_MVVM_Knockout.DataAccess.TestContext";
        }

        protected override void Seed(W0800_MVVM_Knockout.DataAccess.TestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Contacts.AddOrUpdate(p=>p.PhoneNo,
                new Contact { FirstName = "Edward", LastName = "Wang", EmailAddress = "EdwardWang@test.cn", PhoneNo = "12345678"},
                new Contact { FirstName = "Kimi", LastName = "Qiu", EmailAddress = "KimiQiu@test.cn", PhoneNo = "12348888" },
                new Contact { FirstName = "Jac", LastName = "Li", EmailAddress = "JacLi@test.cn", PhoneNo = "88881234" }
                );

        }
    }
}
