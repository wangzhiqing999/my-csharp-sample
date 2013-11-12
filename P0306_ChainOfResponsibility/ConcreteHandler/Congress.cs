using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using P0306_ChainOfResponsibility.Model;
using P0306_ChainOfResponsibility.Handler;


namespace P0306_ChainOfResponsibility.ConcreteHandler
{
    /// <summary>
    ///  本类是 责任链中的 ConcreteHandler（具体处理者）
    /// </summary>
    public class Congress : Approver
    {
        public Congress(String name)
            : base(name)
        {
        }


        /// <summary>
        /// 具体请求处理方法
        /// </summary>
        /// <param name="request"></param>
        public override void processRequest(PurchaseRequest request)
        {

            // 处理请求.
            Console.WriteLine(
                "召开董事会审批采购单  审批采购单：{0}，金额：{1}元，采购目的：{2}。",
                request.Number,
                request.Amount,
                request.Purpose);

        }
    }
}
