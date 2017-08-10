using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.Domain.Repositories;
using B2000_AbpEf.Model;


namespace B2000_AbpEf.Repository
{

    public interface ISchoolRepository : IRepository<School, Int32>
    {

        /// <summary>
        /// 查询学校列表.
        /// 
        /// 测试目的：  基本的 查询 / 翻页处理.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="state"></param>
        /// <param name="pgSize"></param>
        /// <param name="pgNo"></param>
        /// <returns></returns>
        IEnumerable<School> QuerySchoolList(string name, string address, SchoolState ? state, int pgSize = 5, int pgNo = 1);





        /// <summary>
        /// 根据状态， 查询学校.
        /// 
        /// 测试目的，  直接执行特定的 SQL 语句.
        /// 也就是万一的情况， 如果业务逻辑非常复杂， 很难在 EF 里面写查询的情况下， 直接调用 SQL 去查询， 然后返回结果.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        IEnumerable<School> QueryByStatus(SchoolState state);



    }
}
