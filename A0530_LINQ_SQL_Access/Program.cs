using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace A0530_LINQ_SQL_Access
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("本例子用于测试 LINQ to SQL 来访问 Access 数据库.");

            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\HR_Roster.accdb";


            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                using (RosterDataClassesDataContext context = new RosterDataClassesDataContext(connection))
                {
                    // 插入.
                    HR_BRANCH branch = new HR_BRANCH()
                    {
                        BRANCH_CODE = "TEST",
                        BRANCH_NAME_CHI = "测试店铺",
                        BRANCH_NAME_ENG = "Test Branch",
                        // 时间类型的，如果像下面这么写，将报格式错误！
                        // BRANCH_CREATEDATE = DateTime.Now,
                        BRANCH_STATUS = "ACTIVE",
                    };
                    context.HR_BRANCH.InsertOnSubmit(branch);
                    // 提交更新.
                    context.SubmitChanges();


                    // 由于插入的时候， 日期格式存在问题。
                    // 这种情况下，需要手动执行 SQL 语句， 对 日期列 的数值进行修改。
                    context.ExecuteCommand("UPDATE HR_BRANCH SET BRANCH_CREATEDATE = #2013-09-09# WHERE BRANCH_CODE = 'TEST' ");

                }

                Console.WriteLine("插入完毕！");



                using (RosterDataClassesDataContext context = new RosterDataClassesDataContext(connection))
                {
                    var query =
                        from data in context.HR_BRANCH
                        where data.BRANCH_CODE == "TEST"
                        select data;

                    HR_BRANCH branch = query.FirstOrDefault();
                    Console.WriteLine("读取结果：{0}, {1}, {2}", 
                        branch.BRANCH_CODE, branch.BRANCH_NAME_CHI, branch.BRANCH_CREATEDATE);

                    
                    branch.BRANCH_NAME_CHI = "测试店铺2";


                    // 下面这句话 要抱错：
                    // 提交更新.
                    // context.SubmitChanges();

                    context.ExecuteCommand("UPDATE HR_BRANCH SET BRANCH_NAME_CHI = '测试店铺2' WHERE BRANCH_CODE = 'TEST' ");

                }
                Console.WriteLine("查询/更新完毕！");




                using (RosterDataClassesDataContext context = new RosterDataClassesDataContext(connection))
                {
                    var query =
                        from data in context.HR_BRANCH
                        where data.BRANCH_NAME_CHI == "测试店铺2"
                        select data;

                    HR_BRANCH branch = query.FirstOrDefault();

                    context.HR_BRANCH.DeleteOnSubmit(branch);
                    
                    // 提交更新.
                    context.SubmitChanges();
                }

                Console.WriteLine("删除处理完毕！");
            }

           






            Console.ReadLine();
        }

    }
}
