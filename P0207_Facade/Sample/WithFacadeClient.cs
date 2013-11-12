using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0207_Facade.Sample
{
    /// <summary>
    /// 使用 Facade 模式的 客户端.
    /// </summary>
    public class WithFacadeClient
    {

        public void Test()
        {
            // 外观
            Mortgage mortgage = new Mortgage();

            Customer customer = new Customer("Ann McKinsey");

            bool eligable = mortgage.IsEligible(customer, 125000);


            Console.WriteLine("{0} 用户的贷款申请被 {1} 了...", customer.Name, (eligable ? "通过" : "拒绝"));

        }

    }
}
