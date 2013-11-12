using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0310_Visitor.Vistor;


namespace P0310_Visitor.Element
{
    /// <summary>
    /// 本类是“访问者”模式的 Element（抽象元素）
    /// 
    /// 员工类
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// 姓名.
        /// </summary>
        public String Name { set; get; }

        /// <summary>
        /// 工作时间.
        /// </summary>
        public int WorkTime { set; get; }


        /// <summary>
        /// 接受一个抽象访问者访问
        /// </summary>
        /// <param name="handler"></param>
        public abstract void accept(Department handler);

    }
}
