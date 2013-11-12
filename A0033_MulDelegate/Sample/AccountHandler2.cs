using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0033_MulDelegate.Sample
{


    /// <summary>
    /// 这个是 业务处理的类
    /// 
    /// 其中的方法，将被用于实现委托.
    /// </summary>
    class AccountHandler
    {

        /// <summary>
        /// 增加金额.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="amt"></param>
        public void AddCash(Account a, double amt)
        {
            Console.WriteLine("增加金额:{0}", amt);
            a.Cash += amt;
        }


        /// <summary>
        /// 减少金额.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="amt"></param>
        public void SubCash(Account a, double amt)
        {
            Console.WriteLine("减少金额:{0}", amt);
            a.Cash -= amt;
        }

    }
}
