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
    /// 人力资源部
    /// </summary>
    public class HRDepartment : Department 
    {
        /// <summary>
        /// 实现人力资源部对全职员工的访问
        /// </summary>
        /// <param name="employee"></param>
        public override void Visit(FulltimeEmployee employee)
        {
		    int workTime = employee.WorkTime;
		    Console.WriteLine("正式员工{0}实际工作时间为：{1}小时。",
                employee.Name,
                employee.WorkTime);

		    if(workTime > 40)
		    {
			    Console.WriteLine("正式员工{0}加班时间为{1}小时。",
                    employee.Name,
                    workTime - 40);
		    }
		    else if(workTime < 40)
		    {
                Console.WriteLine("正式员工{0}请假时间为：{1}小时。",
                    employee.Name,
                    40 - workTime);
		    }
        }

        /// <summary>
        /// 实现人力资源部对兼职员工的访问
        /// </summary>
        /// <param name="employee"></param>
        public override void Visit(ParttimeEmployee employee)
        {
		    Console.WriteLine("临时工{0}实际工作时间为：{1}小时。",
                employee.Name,
                employee.WorkTime);
        }
    }
}
