using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using A0622_EF_OneToManyPlus.DataAccess;
using A0622_EF_OneToManyPlus.Model;
using A0622_EF_OneToManyPlus.Service;


namespace A0622_EF_OneToManyPlus.ServiceImpl
{
    public class DefaultTestServiceImpl : ITestService
    {

        public long InitTestData()
        {
            using (TestContext context = new TestContext())
            {
                User testUser = context.Users.FirstOrDefault(p => p.UserName == "TEST_USER");
                if (testUser == null)
                {
                    testUser = new User()
                    {
                        UserName = "TEST_USER",
                        Masters = new List<Master>()
                    };



                    for (int i = 0; i < 3; i++)
                    {
                        Master testMaster = new Master()
                        {
                            UserData = testUser,
                            MasterName = String.Format("TEST_MASTER_{0}" , i),
                            Details = new List<Detail>()
                        };

                        for (int j = 0; j < 3; j++)
                        {
                            Detail testDetail = new Detail()
                            {
                                MasterData = testMaster,
                                DetailName = String.Format("TEST_DETAIL_{0}_{1}", i, j)
                            };
                            testMaster.Details.Add(testDetail);
                        }
                        testUser.Masters.Add(testMaster);
                    }

                    context.Users.Add(testUser);
                    context.SaveChanges();
                }

                return testUser.UserID;
            }
        }



        public User GetUserOnly(long id)
        {
            using (TestContext context = new TestContext())
            {
                // Find 仅仅根据主键查询数据，不额外查询关联表.
                User result = context.Users.Find(id);
                return result;
            }
        }


        public User GetUserWithMaster(long id)
        {
            using (TestContext context = new TestContext())
            {
                // Users.Include("Masters")
                // 意味着， 查询 User 表的同时， 关联查询 Master 表.
                User result = context.Users.Include("Masters").FirstOrDefault(p => p.UserID == id);
                return result;
            }
        }

        public User GetUserWithMasterAndDetail(long id)
        {
            using (TestContext context = new TestContext())
            {
                // Users.Include("Masters.Details")
                // 意味着， 查询 User 表的同时， 关联查询 Master 表与 Detail 表.
                User result = context.Users.Include("Masters.Details").FirstOrDefault(p => p.UserID == id);
                return result;
            }
        }


    }
}
