using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0306_ChainOfResponsibility.Model;


namespace P0306_ChainOfResponsibility.Handler
{

    /// <summary>
    /// 审批者类：抽象处理者
    /// </summary>
    public abstract class Approver
    {
        /// <summary>
        /// 定义后继对象
        /// </summary>
        public Approver Successor { set; protected get; }

        /// <summary>
        /// 审批者姓名
        /// </summary>
        protected String name;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="name"></param>
        public Approver(String name)
        {
            this.name = name;
        }



        /// <summary>
        /// 抽象请求处理方法
        /// </summary>
        /// <param name="request"></param>
        public abstract void processRequest(PurchaseRequest request);

    }

}
