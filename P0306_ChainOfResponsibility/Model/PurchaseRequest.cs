using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0306_ChainOfResponsibility.Model
{
    /// <summary>
    /// 采购单：请求类
    /// </summary>
    public class PurchaseRequest
    {
        /// <summary>
        /// 采购金额
        /// </summary>
        public decimal Amount { set; get; } 


        /// <summary>
        /// 采购单编号
        /// </summary>
        public int Number { set; get; }


        /// <summary>
        /// 采购目的
        /// </summary>
        public String Purpose { set; get; }


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="amount">采购金额</param>
        /// <param name="number">采购单编号</param>
        /// <param name="purpose">采购目的</param>
        public PurchaseRequest(decimal amount, int number, String purpose)
        {
            this.Amount = amount;
            this.Number = number;
            this.Purpose = purpose;
        }

    }
}
