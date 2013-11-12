using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0033_MulDelegate.Sample
{


    /// <summary>
    /// 用于 定义 委派 的例子
    /// </summary>
    class AccountService
    {
        /// <summary>
        /// 基础数据类.
        /// </summary>
        private Account a = new Account();


        /// <summary>
        /// 定义一个委派
        /// 
        /// 这个委派是 没有返回值、有2个参数的一个方法.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="amt"></param>
        public delegate void AddAccountCashDelegate(Account a, double amt);

        // 同上
        public delegate void SubAccountCashDelegate(Account a, double amt);




        public AddAccountCashDelegate add = null;

        public SubAccountCashDelegate sub = null;



        /// <summary>
        /// 用于演示， 怎样使用委派
        /// 
        /// 注意：这里与 前面的 不同是
        /// 
        /// 前面的委派，被定义在 参数上
        /// 这里的委派，被定义在 内部变量上
        /// </summary>
        /// <param name="add"></param>
        public void DemoAdd(double amt)
        {
            if (add != null)
            {
                add(a, amt);
            }
            else
            {
                Console.WriteLine("委派没有定义！");
            }
        }

        // 同上
        public void DemoSub(double amt)
        {
            if (sub != null)
            {
                sub(a, amt);
            }
            else
            {
                Console.WriteLine("委派没有定义！");
            }
        }






    }


}
