using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.EntityFramework;

using B2000_AbpEf.Model;


namespace B2000_AbpEf.DataAccess
{
    public class B2000_AbpEfDbContext : AbpDbContext
    {

        /// <summary>
        /// 学校.
        /// </summary>
        public virtual IDbSet<School> Schools { get; set; }


        /// <summary>
        /// 老师.
        /// </summary>
        public virtual IDbSet<Teacher> Teachers { get; set; }




        public B2000_AbpEfDbContext()
            : base("B2000_AbpEfDbContext")
        {

        }

        public B2000_AbpEfDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

    }
}
