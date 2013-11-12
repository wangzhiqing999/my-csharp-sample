using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0207_Facade.Sample
{

    /// <summary>
    /// 银行子系统
    /// </summary>
    public class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("银行子系统查询{0}用户是否有足够多的存款......", c.Name);
            return true;
        }
    }



    /// <summary>
    /// 信用子系统
    /// </summary>
    public class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("信用子系统查询{0}用户是否有不良信用记录......", c.Name);
            return true;
        }
    }



    /// <summary>
    /// 贷款子系统
    /// </summary>
    public class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("贷款子系统查询{0}有无贷款未还情况......", c.Name);
            return true;
        }
    }

}
