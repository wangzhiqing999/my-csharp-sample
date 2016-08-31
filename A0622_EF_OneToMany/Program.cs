using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0622_EF_OneToMany.Sample;

namespace A0622_EF_OneToMany
{
    class Program
    {

        private static Test t = new Test();



        static void Main(string[] args)
        {


            Console.WriteLine(t.GetCreateDatabaseScript());


            ShowAllData();

            
            // 测试 单独 新增学校.
            School school1 = new School()
            { 
                SchoolName = "学校1"
            };

            t.SaveSchoolData(school1);

            Console.WriteLine("school1 = {0} : {1}", school1.SchoolID, school1.SchoolName);




            // 测试 单独 新增 已有学校下的 老师.
            Teacher t1 = new Teacher()
            {
                TeacherName = "张老师",

                // 方式一：  设置 学校 ID.
                SchoolID = school1.SchoolID
            };
            t.SaveTeacherData(t1);
            ShowAllData();





            // ##########
            // 注意：下面的写法，导致创建了新的学校.
            // ##########

            // 测试 单独 新增 已有学校下的 老师.
            Teacher t2 = new Teacher()
            {
                TeacherName = "李老师",

                // 方式二：  设置 学校 对象.
                InSchool = school1
            };
            t.SaveTeacherData(t2);
            ShowAllData();






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
            ShowAllData();




        

            Console.ReadLine();
        }



        private static void ShowAllData()
        {

            Console.WriteLine("===== ShowAllData =====");

            var allSchool = t.GetSchoolList();

            // 查询 学校中的老师.
            foreach (School sc in allSchool)
            {
                foreach (Teacher te in sc.SchoolTeachers)
                {
                    Console.WriteLine("{0}:{1} -- {2}:{3}", sc.SchoolID, sc.SchoolName, te.TeacherID, te.TeacherName);
                }
            }

            Console.WriteLine("==========");
        }

    }
}
