using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using B2000_AbpEf.DataAccess;
using B2000_AbpEf.Model;


namespace B2000_AbpEf.Test
{
    class BasicTest
    {

        /// <summary>
        /// 用于测试的学校名称.
        /// </summary>
        private const string TEST_SCHOOL_NAME = "TEST_SCHOOL";



        /// <summary>
        /// 单表基本操作测试.
        /// </summary>
        public static void TestOneTableFunc()
        {

            Console.WriteLine("----- test one table basic func -----");


            // 测试插入.
            Console.WriteLine("-- INSERT --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                School mySchool = new School()
                {
                    SchoolName = TEST_SCHOOL_NAME,
                    SchoolAddress = "上海市某某路1234号"                    
                };
                // 新增学校.
                context.Schools.Add(mySchool);
                // 物理保存.
                context.SaveChanges();
                Console.WriteLine("After Add. id = {0}, name = {1}, address = {2}", mySchool.Id, mySchool.SchoolName, mySchool.SchoolAddress);
            }


            // 测试查询.
            Console.WriteLine("-- SELECT --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var mySchool = context.Schools.FirstOrDefault(p => p.SchoolName == TEST_SCHOOL_NAME);
                if(mySchool == null)
                {
                    Console.WriteLine("## School Data Not Found!");
                }
                else
                {
                    Console.WriteLine("Query 1. id = {0}, name = {1}, address = {2}", mySchool.Id, mySchool.SchoolName, mySchool.SchoolAddress);
                }                
            }


            // 测试更新.
            Console.WriteLine("-- UPDATE --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var mySchool = context.Schools.FirstOrDefault(p => p.SchoolName == TEST_SCHOOL_NAME);
                mySchool.SchoolAddress = "上海市某某路5678号";
                context.SaveChanges();
            }


            // 测试查询.
            Console.WriteLine("-- SELECT --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var mySchool = context.Schools.FirstOrDefault(p => p.SchoolName == TEST_SCHOOL_NAME);
                if (mySchool == null)
                {
                    Console.WriteLine("## School Data Not Found!");
                } else
                {
                    Console.WriteLine("Query 2. id = {0}, name = {1}, address = {2}", mySchool.Id, mySchool.SchoolName, mySchool.SchoolAddress);
                }                
            }


            // 测试删除.
            Console.WriteLine("-- DELETE --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var mySchool = context.Schools.FirstOrDefault(p => p.SchoolName == TEST_SCHOOL_NAME);
                context.Schools.Remove(mySchool);
                context.SaveChanges();
            }


            // 测试查询.
            Console.WriteLine("-- SELECT --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var mySchool = context.Schools.FirstOrDefault(p => p.SchoolName == TEST_SCHOOL_NAME);
                if (mySchool == null)
                {
                    Console.WriteLine("Success!  After delete.  School Data is Not Found!");
                }                
            }

            Console.WriteLine();

        }





        /// <summary>
        /// 多表的基本操作测试.
        /// </summary>
        public static void TestMulTableFunc()
        {
            Console.WriteLine("----- test mul table basic func -----");


            // 测试插入学校.
            Console.WriteLine("-- INSERT SCHOOL --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                School mySchool = new School()
                {
                    SchoolName = TEST_SCHOOL_NAME,
                    SchoolAddress = "上海市某某路1234号"
                };
                // 新增学校.
                context.Schools.Add(mySchool);
                // 物理保存.
                context.SaveChanges();
                Console.WriteLine("After Add. id = {0}, name = {1}, address = {2}", mySchool.Id, mySchool.SchoolName, mySchool.SchoolAddress);
            }


            // 测试插入老师.
            Console.WriteLine("-- INSERT TEACHER --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var mySchool = context.Schools.FirstOrDefault(p => p.SchoolName == TEST_SCHOOL_NAME);

                Teacher t1 = new Teacher()
                {
                    SchoolID = mySchool.Id,
                    TeacherName = "张三"
                };
                context.Teachers.Add(t1);

                Teacher t2 = new Teacher()
                {
                    SchoolID = mySchool.Id,
                    TeacherName = "李四"
                };
                context.Teachers.Add(t2);

                // 物理保存.
                context.SaveChanges();
            }


            // 测试查询.
            Console.WriteLine("-- SELECT SCHOOL & TEACHER --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                // 注意： 这里好像没法   context.Schools.Includes("SchoolTeachers")
                var mySchool = context.Schools.FirstOrDefault(p => p.SchoolName == TEST_SCHOOL_NAME);

                Console.WriteLine("SCHOOL : id = {0}, name = {1}, address = {2}", mySchool.Id, mySchool.SchoolName, mySchool.SchoolAddress);
                foreach(var myTeacher in mySchool.SchoolTeachers)
                {
                    Console.WriteLine("  TEACHER : id = {0}, name = {1}.", myTeacher.Id, myTeacher.TeacherName);
                }                
            }


            // 测试删除.
            Console.WriteLine("-- DELETE SCHOOL & TEACHER --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var mySchool = context.Schools.FirstOrDefault(p => p.SchoolName == TEST_SCHOOL_NAME);
                var removeList = mySchool.SchoolTeachers.ToList();
                foreach (var myTeacher in removeList)
                { 
                    context.Teachers.Remove(myTeacher);
                }
                context.Schools.Remove(mySchool);
                // 物理保存.
                context.SaveChanges();
            }


            // 测试查询.
            Console.WriteLine("-- SELECT --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var mySchool = context.Schools.FirstOrDefault(p => p.SchoolName == TEST_SCHOOL_NAME);
                if (mySchool == null)
                {
                    Console.WriteLine("Success!  After delete.  School Data is Not Found!");
                }
            }

            Console.WriteLine();
        }





        private static void printSchool(School mySchool)
        {
            Console.WriteLine("SCHOOL : id = {0}, name = {1}, address = {2}", mySchool.Id, mySchool.SchoolName, mySchool.SchoolAddress);
        }



        /// <summary>
        /// 翻页的测试.
        /// </summary>
        public static void TestPage()
        {
            Console.WriteLine("----- test Page basic func -----");

            // 测试插入 20 行.
            Console.WriteLine("-- INSERT  20 LINE --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {

                for(int i = 1; i <= 20; i ++)
                {
                    School mySchool = new School()
                    {
                        SchoolName = String.Format("{0}_{1:000}", TEST_SCHOOL_NAME , i),
                        SchoolAddress = String.Format("上海市某某路{0:000}号", i)
                    };
                    // 新增学校.
                    context.Schools.Add(mySchool);
                }                
                // 物理保存.
                context.SaveChanges();                
            }



            Console.WriteLine("-- PAGE --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var query =
                    from data in context.Schools
                    select data;

                // 排序 = 名称逆序
                query = query.OrderByDescending(p => p.SchoolName);

                // 跳过10行， 取5行.
                query = query.Skip(10).Take(5);
                var resultList = query.ToList();

                Console.WriteLine("Skip 10 Take 5 Result !");
                foreach(var mySchool in resultList)
                {
                    printSchool(mySchool);
                }

            }



            Console.WriteLine("-- DELETE --");
            using (B2000_AbpEfDbContext context = new B2000_AbpEfDbContext())
            {
                var removeList = context.Schools.Where(p => p.SchoolName.StartsWith(TEST_SCHOOL_NAME)).ToList();
                foreach(var item in removeList)
                {
                    context.Schools.Remove(item);
                }
                // 物理保存.
                context.SaveChanges();
            }

            Console.WriteLine();
        }



    }
}
