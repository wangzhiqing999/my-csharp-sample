using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0309_State.SampleBank
{


    /// <summary>
    /// 抽象状态类，每个子类实现与Context的一个状态相关的行为
    /// </summary>
    abstract class State
    {
        /// <summary>
        /// 账户
        /// </summary>
        protected Account account;


        /// <summary>
        /// 账户余额.
        /// </summary>
        protected double balance;


        /// <summary>
        /// 利息
        /// </summary>
        protected double interest;

        /// <summary>
        /// 金额下限
        /// </summary>
        protected double lowerLimit;

        /// <summary>
        /// 金额上限.
        /// </summary>
        protected double upperLimit;





        /// <summary>
        /// 账户.
        /// </summary>
        public Account Account
        {
            get { return account; }
            set { account = value; }
        }


        /// <summary>
        /// 账户余额.
        /// </summary>
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }


        /// <summary>
        /// 存款
        /// </summary>
        /// <param name="amount"></param>
        public abstract void Deposit(double amount);


        /// <summary>
        /// 取款
        /// </summary>
        /// <param name="amount"></param>
        public abstract void Withdraw(double amount);


        /// <summary>
        /// 支付利息
        /// </summary>
        public abstract void PayInterest();

    }







    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Red indicates 账户已透支.
    /// </remarks>
    /// </summary>
    class RedState : State
    {

        private double _serviceFee;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="state"></param>
        public RedState(State state)
        {
            // 设置 账户余额 与 账户.
            this.balance = state.Balance;
            this.account = state.Account;

            // 初始化 本状态的基本参数.
            Initialize();
        }


        /// <summary>
        /// 基本状态参数 初始化.
        /// </summary>
        private void Initialize()
        {
            // Should come from a datasource

            // 利率 （本状态未使用）
            interest = 0.0;

            // 下限 -100.00  （本状态未使用）
            lowerLimit = -100.0;

            // 上限 0.00
            upperLimit = 0.0;

            // 服务费
            _serviceFee = 15.00;

        }



        /// <summary>
        /// 存款.
        /// </summary>
        /// <param name="amount"></param>
        public override void Deposit(double amount)
        {
            // 增加 账户余额.
            balance += amount;
            // 检查 状态.
            StateChangeCheck();
        }


        /// <summary>
        /// 取款.
        /// </summary>
        /// <param name="amount"></param>
        public override void Withdraw(double amount)
        {
            amount = amount - _serviceFee;
            Console.WriteLine("账户上没有现金用于取款了!");
        }


        /// <summary>
        /// 支付利息.
        /// </summary>
        public override void PayInterest()
        {
            // No interest is paid
            Console.WriteLine("账户上没有现金，因此没有利息需要支付!");
        }


        /// <summary>
        /// 状态变化的检查.
        /// </summary>
        private void StateChangeCheck()
        {
            if (balance > upperLimit)
            {
                // 如果 账户余额 大于  本状态所规定的上限
                // 那么将迁移到  标准状态下面去.
                account.State = new SilverState(this);
            }
        }

    }



    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Silver indicates 标准卡账户.
    /// </remarks>
    /// </summary>
    class SilverState : State
    {

        // Overloaded constructors
        public SilverState(State state)
            :
          this(state.Balance, state.Account)
        {
        }


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="account"></param>
        public SilverState(double balance, Account account)
        {
            // 设置 账户余额 与 账户.
            this.balance = balance;
            this.account = account;

            // 初始化 本状态的基本参数.
            Initialize();
        }


        /// <summary>
        ///  基本状态参数 初始化.
        /// </summary>
        private void Initialize()
        {
            // Should come from a datasource
            // 利率
            interest = 0.0;
            // 下限 0.00
            lowerLimit = 0.0;
            // 上限 0.00
            upperLimit = 1000.0;
        }


        /// <summary>
        /// 存款.
        /// </summary>
        /// <param name="amount"></param>
        public override void Deposit(double amount)
        {
            // 增加 账户余额.
            balance += amount;
            // 检查 状态.
            StateChangeCheck();
        }


        /// <summary>
        /// 取款.
        /// </summary>
        /// <param name="amount"></param>
        public override void Withdraw(double amount)
        {
            // 减少 账户余额.
            balance -= amount;
            // 检查 状态.
            StateChangeCheck();
        }


        /// <summary>
        /// 支付利息.
        /// </summary>
        public override void PayInterest()
        {
            // 账户余额 = 账户余额 + 账户余额 * 利率
            balance += interest * balance;
            // 检查 状态.
            StateChangeCheck();
        }


        /// <summary>
        /// 状态变化的检查.
        /// </summary>
        private void StateChangeCheck()
        {
            if (balance < lowerLimit)
            {
                // 如果 账户余额 小于  本状态所规定的下限
                // 那么将迁移到  透支卡状态下面去.
                account.State = new RedState(this);
            }
            else if (balance > upperLimit)
            {
                // 如果 账户余额 大于  本状态所规定的上限
                // 那么将迁移到  金卡状态下面去.
                account.State = new GoldState(this);
            }
        }
    }


    
    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Gold indicates 金卡账户.
    /// </remarks>
    /// </summary>
    class GoldState : State
    {
        // Overloaded constructors
        public GoldState(State state)
            : this(state.Balance, state.Account)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="account"></param>
        public GoldState(double balance, Account account)
        {
            // 设置 账户余额 与 账户.
            this.balance = balance;
            this.account = account;

            // 初始化 本状态的基本参数.
            Initialize();
        }

        /// <summary>
        /// 基本状态参数 初始化.
        /// </summary>
        private void Initialize()
        {
            // Should come from a database
            // 利率
            interest = 0.05;
            // 下限
            lowerLimit = 1000.0;
            // 上限  （本状态未使用）
            upperLimit = 10000000.0;
        }


        /// <summary>
        /// 存款.
        /// </summary>
        /// <param name="amount"></param>
        public override void Deposit(double amount)
        {
            // 增加 账户余额.
            balance += amount;
            // 检查 状态.
            StateChangeCheck();
        }


        /// <summary>
        /// 取款.
        /// </summary>
        /// <param name="amount"></param>
        public override void Withdraw(double amount)
        {
            // 减少 账户余额.
            balance -= amount;
            // 检查 状态
            StateChangeCheck();
        }


        /// <summary>
        /// 支付利息.
        /// </summary>
        public override void PayInterest()
        {
            // 账户余额 = 账户余额 + 账户余额 * 利率
            balance += interest * balance;
            // 检查 状态.
            StateChangeCheck();
        }


        /// <summary>
        /// 状态变化的检查.
        /// </summary>
        private void StateChangeCheck()
        {
            if (balance < 0.0)
            {
                // 余额小于 0， 直接进入 账户已透支 状态.
                account.State = new RedState(this);
            }
            else if (balance < lowerLimit)
            {
                // 余额仅仅小于 本状态的下限 (还大于0)， 进入 标准卡账户 状态.
                account.State = new SilverState(this);
            }
        }
    }
}
