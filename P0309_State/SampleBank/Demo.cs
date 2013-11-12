using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0309_State.SampleBank
{
    class Demo
    {

        public static void ShowDemo()
        {

            Console.WriteLine("===== 一个银行账户 状态 的例子演示 =====");

            // 开一个新账户.
            Account account = new Account("张三");


            // 开始各种 存款 、取款等交易.
            account.Deposit(500.0);

            account.Deposit(300.0);

            account.Deposit(550.0);

            account.PayInterest();

            account.Withdraw(2000.00);

            account.Withdraw(1100.00);



        }

    }
}
