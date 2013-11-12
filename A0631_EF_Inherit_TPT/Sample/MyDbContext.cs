using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace A0631_EF_Inherit_TPT.Sample
{

    public class MyDbContext : DbContext
    {

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public MyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }


        /// <summary>
        /// 成员
        /// WorkMember DbSet. 
        /// </summary>
        public DbSet<WorkMember> WorkMemberDbSet { get; set; }

        /// <summary>
        /// 操作员
        /// Operator DbSet. 
        /// </summary>
        public DbSet<Operator> OperatorDbSet { get; set; }

        /// <summary>
        /// 管理员
        /// Manager DbSet. 
        /// </summary>
        public DbSet<Manager> ManagerDbSet { get; set; }

    }
}
