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
    /// 全职员工
    /// </summary>
    public class FulltimeEmployee : Employee
    {
        /// <summary>
        /// 周薪.
        /// </summary>
        public Decimal WeeklyWage { set; get; }



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weeklyWage"></param>
        /// <param name="workTime"></param>
        public FulltimeEmployee(String name, Decimal weeklyWage, int workTime)
        {
            this.Name = name;
            this.WeeklyWage = weeklyWage;
            this.WorkTime = workTime;
        }

        public override void accept(Vistor.Department handler)
        {
            handler.Visit(this);
        }
    }
}
