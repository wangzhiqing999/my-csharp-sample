using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0031_delegate.Sample
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




        /// <summary>
        /// 用于演示， 怎样使用委派
        /// 
        /// 这个方法，要求有2个参数
        /// 第一个参数是“委派”，也就是把 函数作为参数.
        /// 第二个参数是 普通数据
        /// </summary>
        /// <param name="add"></param>
        public void DemoAdd(AddAccountCashDelegate add, double amt)
        {
            add(a, amt);
        }

        // 同上
        public void DemoSub(SubAccountCashDelegate sub, double amt)
        {
            sub(a, amt);
        }






    }


}
