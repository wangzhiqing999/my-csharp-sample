using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0310_Visitor.Vistor;
using P0310_Visitor.ConcreteElement;

namespace P0310_Visitor.ConcreteVisitor
{
    /// <summary>
    /// 本类是“访问者”模式的 ConcreteVisitor（具体访问者）
    /// 
    /// 财务部
    /// </summary>
    public class FADepartment : Department 
    {
        /// <summary>
        /// 实现财务部对全职员工的访问
        /// </summary>
        /// <param name="employee"></param>
        public override void Visit(FulltimeEmployee employee)
        {
            int workTime = employee.WorkTime;
		    Decimal weekWage = employee.WeeklyWage;
		    if(workTime > 40)
		    {
			    weekWage = weekWage + (workTime - 40) * 100;
		    }
		    else if(workTime < 40)
		    {
			    weekWage = weekWage - (40 - workTime) * 80;
			    if(weekWage < 0)
			    {
				    weekWage = 0;
			    }
		    }
            Console.WriteLine("正式员工{0}实际工资为：{1}元。",
                employee.Name,
                weekWage);
        }

        /// <summary>
        /// 实现财务部对兼职员工的访问
        /// </summary>
        /// <param name="employee"></param>
        public override void Visit(ParttimeEmployee employee)
        {
            int workTime = employee.WorkTime;
		    Decimal hourWage = employee.HourWage;
            Console.WriteLine("临时工{0}实际工资为：{1}元。",
                employee.Name,
                workTime * hourWage);	
        }
    }

}
