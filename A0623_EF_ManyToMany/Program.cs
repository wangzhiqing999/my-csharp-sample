using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0623_EF_ManyToMany.Sample;



namespace A0623_EF_ManyToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();

            Course c1 = new Course()
            {
                CourseName = "摄影"
            };
            Course c2 = new Course()
            {
                CourseName = "绘画"
            };
            Course c3 = new Course()
            {
                CourseName = "音乐"
            };


            Student s1 = new Student()
            {
                StudentName = "张三"
            };
            Student s2 = new Student()
            {
                StudentName = "李四"
            };
            Student s3 = new Student()
            {
                StudentName = "王五"
            };


            t.SaveCourseData(c1);
            t.SaveCourseData(c2);
            t.SaveCourseData(c3);

            t.SaveStudentData(s1);
            t.SaveStudentData(s2);
            t.SaveStudentData(s3);



            List<Course> courseList1 = new List<Course>();
            courseList1.Add(c1);
            courseList1.Add(c2);
            courseList1.Add(c3);

            // 张三 选修了 3门
            s1.Courses = courseList1;
            
            List<Course> courseList2 = new List<Course>();
            courseList2.Add(c1);
            courseList2.Add(c2);

            // 李四 选修了 2门.
            s2.Courses = courseList2;


            List<Course> courseList3 = new List<Course>();
            courseList3.Add(c1);

            // 王五 选修了 1门.
            s3.Courses = courseList3;


            t.SaveStudentData(s1);
            t.SaveStudentData(s2);
            t.SaveStudentData(s3);



            // 从课程入口查询， 那些 学生选修了.
            foreach (Course c in t.CourseDataSource)
            {
                foreach (Student s in c.Students)
                {
                    Console.WriteLine("{0}：{1}", c.CourseName, s.StudentName);
                }
            }


            Console.ReadLine();
        }
    }
}
