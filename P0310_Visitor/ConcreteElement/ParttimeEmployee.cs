using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0310_Visitor.Element;

namespace P0310_Visitor.ConcreteElement
{
    /// <summary>
    /// 本类是“访问者”模式的 ConcreteElement（具体元素）
    /// 
    /// 兼职员工
    /// </summary>
    public class ParttimeEmployee : Employee
    {
        /// <summary>
        /// 时薪.
        /// </summary>
        public Decimal HourWage { set; get; }


        public ParttimeEmployee(String name, Decimal hourWage, int workTime)
        {
            this.Name = name;
            this.HourWage = hourWage;
            this.WorkTime = workTime;
        }


        public override void accept(Vistor.Department handler)
        {
            handler.Visit(this);
        }
    }
}
