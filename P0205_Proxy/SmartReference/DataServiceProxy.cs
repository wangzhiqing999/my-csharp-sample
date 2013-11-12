using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0205_Proxy.SmartReference
{
    /// <summary>
    /// 本接口是“代理”模式的  代理主题（Proxy）角色
    /// </summary>
    public class DataServiceProxy : IDataService
    {

        /// <summary>
        /// 代理主题角色内部包含有对真实主题的引用
        /// </summary>
        private IDataService realDataService = new DataServiceImpl();




        public void DoSomething()
        {

            Console.WriteLine("1. ###### 代理角色 可能在这里 检查你的 权限配置......");

            Console.WriteLine("2. ###### 代理角色 可能在这里 记录日志信息......");

            // 执行 真实主题角色 的 业务逻辑.
            realDataService.DoSomething();


            Console.WriteLine("3. ###### 代理角色 可能在这里 统计你的 执行性能信息......");
        }
    }

}
