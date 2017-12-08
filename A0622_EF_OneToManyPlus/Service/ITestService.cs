using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using A0622_EF_OneToManyPlus.Model;


namespace A0622_EF_OneToManyPlus.Service
{
    /// <summary>
    /// 测试服务.
    /// </summary>
    public interface ITestService
    {

        /// <summary>
        /// 初始化测试数据.
        /// </summary>
        long InitTestData();


        /// <summary>
        /// 仅仅查询用户.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserOnly(long id);


        /// <summary>
        /// 查询用户， 同时获取主数据信息.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserWithMaster(long id);


        /// <summary>
        /// 查询用户， 同时获取主数据与子数据信息.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserWithMasterAndDetail(long id);
    }
}
