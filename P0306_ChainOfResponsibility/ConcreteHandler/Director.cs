using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0306_ChainOfResponsibility.Model;
using P0306_ChainOfResponsibility.Handler;

namespace P0306_ChainOfResponsibility.ConcreteHandler
{

    /// <summary>
    /// 本类是 责任链中的 ConcreteHandler（具体处理者）
    /// </summary>
    public class Director : Approver
    {
        public Director(String name) :base(name)
        {
        }

        /// <summary>
        /// 具体请求处理方法
        /// </summary>
        /// <param name="request"></param>
        public override void processRequest(PurchaseRequest request)
        {
            if (request.Amount < 50000)
            {
                // 处理请求.
                Console.WriteLine(
                    "主任{0} 审批采购单：{1}，金额：{2}元，采购目的：{3}。",
                    this.name,
                    request.Number,
                    request.Amount,
                    request.Purpose);
            }
            else
            {
                // 转发请求.
                this.Successor.processRequest(request);  
            }
        }

    }

}
