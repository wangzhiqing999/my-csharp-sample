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


            // 测试 单独 新增学校.
            School school1 = new School()
            { 
                SchoolName = "学校1"
            };

            t.SaveSchoolData(school1);



            // 测试 单独 新增 已有学校下的 老师.
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

            t.SaveTeacherData(t1);
            t.SaveTeacherData(t2);




            // 测试 批量 新增  学校与老师.

            List<School> schoolList = new List<School>()
            {
                new School() {
                    SchoolName = "学校2",

                    SchoolTeachers = new List<Teacher>() {
                        new Teacher()
                        {
                            TeacherName = "老师001",
                        },
                        new Teacher()
                        {
                            TeacherName = "老师002",
                        }
                    },
                },

                new School() {
                    SchoolName = "学校3",

                    SchoolTeachers = new List<Teacher>() {
                        new Teacher()
                        {
                            TeacherName = "老师003",
                        },
                        new Teacher()
                        {
                            TeacherName = "老师004",
                        }
                    },
                },
            };


            t.BatchInsert(schoolList);





            var allSchool = t.GetSchoolList();

            // 查询 学校中的老师.
            foreach (School sc in allSchool)
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
