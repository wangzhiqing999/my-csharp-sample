using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0310_Visitor.ObjectStructure;

using P0310_Visitor.ConcreteElement;
using P0310_Visitor.Element;

using P0310_Visitor.ConcreteVisitor;
using P0310_Visitor.Vistor;


namespace P0310_Visitor
{
    class Program
    {
        static void Main(string[] args)
        {

            EmployeeList list = new EmployeeList();
            Employee fte1, fte2, fte3, pte1, pte2;

            fte1 = new FulltimeEmployee("张无忌", 3200, 45);
            fte2 = new FulltimeEmployee("杨过", 2000, 40);
            fte3 = new FulltimeEmployee("段誉", 2400, 38);
            pte1 = new ParttimeEmployee("洪七公", 80, 20);
            pte2 = new ParttimeEmployee("郭靖", 60, 18);

            list.addEmployee(fte1);
            list.addEmployee(fte2);
            list.addEmployee(fte3);
            list.addEmployee(pte1);
            list.addEmployee(pte2);


            Console.WriteLine("财务部 访问数据！");

            Department fadep = new FADepartment();
            list.accept(fadep);


            Console.WriteLine();
            Console.WriteLine("人力资源部 访问数据！");

            Department hrdep = new HRDepartment();
            list.accept(hrdep);


            Console.ReadLine();
        }






    }
}
