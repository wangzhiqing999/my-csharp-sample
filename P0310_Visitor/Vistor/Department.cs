using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0310_Visitor.ConcreteElement;

namespace P0310_Visitor.Vistor
{

    /// <summary>
    /// 本类是“访问者”模式的 Vistor（抽象访问者）
    /// 
    /// 部门
    /// </summary>
    public abstract class Department
    {
        //声明一组重载的访问方法，用于访问不同类型的具体元素

        /// <summary>
        /// 实现对全职员工的访问
        /// </summary>
        /// <param name="employee"></param>
        public abstract void Visit(FulltimeEmployee employee);


        /// <summary>
        /// 实现对兼职员工的访问
        /// </summary>
        /// <param name="employee"></param>
        public abstract void Visit(ParttimeEmployee employee);	
    }
}
