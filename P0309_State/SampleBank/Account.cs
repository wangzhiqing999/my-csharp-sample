using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0309_State.SampleBank
{


    /// <summary>
    /// 类Account，相当于Context类
    /// </summary>
    class Account
    {

        /// <summary>
        /// 账户状态.
        /// </summary>
        private State _state;


        /// <summary>
        /// 账户 的所有人.
        /// </summary>
        private string _owner;


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="owner"></param>
        public Account(string owner)
        {
            this._owner = owner;

            // 新账户默认的状态为： 'Silver' 
            this._state = new SilverState(0.0, this);
        }



        /// <summary>
        /// 账户余额
        /// </summary>
        public double Balance
        {
            get { return _state.Balance; }
        }


        /// <summary>
        /// 账户的状态.
        /// </summary>
        public State State
        {
            get { return _state; }
            set { _state = value; }
        }


        /// <summary>
        /// 存款
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(double amount)
        {
            _state.Deposit(amount);

            Console.WriteLine("存款 {0:C} --- ", amount);
            Console.WriteLine(" 账户余额 = {0:C}", this.Balance);
            Console.WriteLine(" 账户状态 = {0}",
              this.State.GetType().Name);
            Console.WriteLine("");

        }


        /// <summary>
        /// 取款.
        /// </summary>
        /// <param name="amount"></param>
        public void Withdraw(double amount)
        {
            _state.Withdraw(amount);

            Console.WriteLine("取款 {0:C} --- ", amount);
            Console.WriteLine(" 账户余额 = {0:C}", this.Balance);
            Console.WriteLine(" 账户状态 = {0}\n",
              this.State.GetType().Name);

        }


        /// <summary>
        /// 支付利息.
        /// </summary>
        public void PayInterest()
        {
            _state.PayInterest();

            Console.WriteLine("支付利息 --- ");
            Console.WriteLine(" 账户余额 = {0:C}", this.Balance);
            Console.WriteLine(" 账户状态 = {0}\n",
              this.State.GetType().Name);

        }

    }

}
