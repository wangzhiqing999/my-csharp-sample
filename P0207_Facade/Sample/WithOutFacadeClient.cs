using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0207_Facade.Sample
{

    /// <summary>
    /// 没有使用 Facade 模式的 客户端.
    /// </summary>
    public class WithOutFacadeClient
    {
        private const int _amount = 12000;


        public void Test()
        {
            Bank bank = new Bank();
            Loan loan = new Loan();
            Credit credit = new Credit();

            Customer customer = new Customer("Ann McKinsey");

            bool eligible = true;

            if (!bank.HasSufficientSavings(customer, _amount))
            {
                eligible = false;
            }
            else if (!loan.HasNoBadLoans(customer))
            {
                eligible = false;
            }
            else if (!credit.HasGoodCredit(customer))
            {
                eligible = false;
            }

            Console.WriteLine("{0} 用户的贷款申请被 {1} 了...", customer.Name , (eligible ? "通过" : "拒绝"));

        }

    }

}
