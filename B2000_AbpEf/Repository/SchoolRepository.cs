using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;


using B2000_AbpEf.DataAccess;
using B2000_AbpEf.Model;


namespace B2000_AbpEf.Repository
{


    public class SchoolRepository : EfRepositoryBase<B2000_AbpEfDbContext, School, Int32>, ISchoolRepository
    {

        public SchoolRepository(IDbContextProvider<B2000_AbpEfDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }



        // 测试基本的查询 / 筛选 / 翻页.
        public IEnumerable<School> QuerySchoolList(string name, string address, SchoolState? state, int pgSize = 5, int pgNo = 1)
        {
            var query =
                from data in Context.Schools
                select data;


            // 如果输入了名称.
            if(!String.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.SchoolName.Contains(name));
            }

            // 如果输入了地址.
            if (!String.IsNullOrEmpty(address))
            {
                query = query.Where(p => p.SchoolAddress.Contains(address));
            }

            if(state != null)
            {
                query = query.Where(p => p.State == state);
            }


            // 排序
            query = query.OrderBy(p => p.Id);

            // 翻页.
            int skipNum = pgSize * (pgNo - 1);
            query = query.Skip(skipNum).Take(pgSize);

            // 执行查询.
            var result = query.ToList();

            return result;
        }




        // 测试直接执行 SQL 语句.
        public IEnumerable<School> QueryByStatus(SchoolState state)
        {

            string sql = @"
SELECT
    Id,
    school_name         AS  SchoolName,
    school_address      AS  SchoolAddress,
    school_state        AS  State
FROM
    test_abp_school
WHERE
    school_state & @state > 0
ORDER BY
    Id
";

            var result = Context.Database.SqlQuery<School>(
                sql, 
                new SqlParameter("@state", state)
                ).ToList();




            return result;
        }


    }
}
