using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0622_EF_OneToMany.Sample;

namespace A0622_EF_OneToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();

            // 新增学校.
            School school1 = new School()
            { 
                SchoolName = "学校1"
            };
            School school2 = new School()
            {
                SchoolName = "学校2"
            };

            t.SaveSchoolData(school1);
            t.SaveSchoolData(school2);


            // 新增老师.
            Teacher t1 = new Teacher()
            {
                TeacherName = "张老师",
                InSchool = school1
            };

            Teacher t2 = new Teacher()
            {
                TeacherName = "李老师",
                InSchool = school1
            };

            Teacher t3 = new Teacher()
            {
                TeacherName = "王老师",
                InSchool = school2
            };

            Teacher t4 = new Teacher()
            {
                TeacherName = "赵老师",
                InSchool = school2
            };

            t.SaveTeacherData(t1);
            t.SaveTeacherData(t2);
            t.SaveTeacherData(t3);
            t.SaveTeacherData(t4);

            
            // 查询 学校中的老师.
            foreach (School sc in t.SchoolDataSource)
            {
                foreach (Teacher te in sc.SchoolTeachers)
                {
                    Console.WriteLine("{0}:{1}", sc.SchoolName, te.TeacherName);
                }
            }

            Console.ReadLine();
        }
    }
}
