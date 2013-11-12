using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0312_Mediator.Sample
{
    /// <summary>
    /// 抽象同事类
    /// </summary>
    abstract class Colleague
    {
        protected Mediator mediator;

        /// <summary>
        /// 初始化中介者对象
        /// </summary>
        /// <param name="mediator"></param>
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

    }
}
