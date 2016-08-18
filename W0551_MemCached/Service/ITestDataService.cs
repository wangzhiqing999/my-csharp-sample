using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using W0551_MemCached.Model;


namespace W0551_MemCached.Service
{

    /// <summary>
    /// 测试数据服务.
    /// </summary>
    public interface ITestDataService
    {


        /// <summary>
        /// 查询用户信息.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        TestData GetTestDataByUserName(string userName);


        /// <summary>
        /// 新增一个用户.
        /// </summary>
        /// <param name="data"></param>
        void InsertTestData(TestData data);


        /// <summary>
        /// 更新用户.
        /// </summary>
        /// <param name="data"></param>
        void UpdateTestData(TestData data);


        /// <summary>
        /// 删除用户.
        /// </summary>
        /// <param name="data"></param>
        void DeleteTestData(string userName);

    }


}
