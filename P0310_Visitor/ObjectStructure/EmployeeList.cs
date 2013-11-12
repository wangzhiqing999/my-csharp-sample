using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0310_Visitor.Element;
using P0310_Visitor.Vistor;

namespace P0310_Visitor.ObjectStructure
{
    /// <summary>
    /// 本类是“访问者”模式的  ObjectStructure（对象结构）
    /// </summary>
    public class EmployeeList
    {
        //定义一个集合用于存储员工对象
        private List<Employee> list = new List<Employee>();

        public void addEmployee(Employee employee)
        {
            list.Add(employee);
        }

        //遍历访问员工集合中的每一个员工对象
        public void accept(Department handler)
        {
            foreach (Employee obj in list)
            {
                obj.accept(handler);
            }
        }
    }
}
