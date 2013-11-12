using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0207_Facade.Sample
{

    /// <summary>
    /// 门面类
    /// </summary>
    public class Mortgage
    {
        private Bank bank = new Bank();
        private Loan loan = new Loan();
        private Credit credit = new Credit();

        public bool IsEligible(Customer cust, int amount)
        {
            
            Console.WriteLine("门面类 ==> {0} 申请 {1:C} 贷款！",
              cust.Name, amount);

            bool eligible = true;

            if (!bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }
            else if (!loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!credit.HasGoodCredit(cust))
            {
                eligible = false;
            }

            return eligible;
        }

    }
}
