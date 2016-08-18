using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;


using W0551_MemCached.Model;
using W0551_MemCached.Service;


namespace W0551_MemCached.ServiceImpl
{
    public class DefaultTestDataService : ITestDataService
    {


        private static List<TestData> dataList = new List<TestData>()
        {
            new TestData() {
                UserName = "张三",
                Password = "123456",
                UserType = DataObjectType.AdminUser,
                FirendList = new List<string>() {
                    "李四",
                    "王五",
                    "赵六"
                }
            },
            new TestData() {
                UserName = "李四",
                Password = "123456",
                UserType = DataObjectType.NormalUser,
                FirendList = new List<string>() {
                    "张三",
                    "王五",
                    "赵六"
                }
            },
            new TestData() {
                UserName = "王五",
                Password = "123456",
                UserType = DataObjectType.TestUser,
                FirendList = new List<string>() {
                    "张三",
                    "李四",                    
                    "赵六"
                }
            },
            new TestData() {
                UserName = "赵六",
                Password = "123456",
                UserType = DataObjectType.TestUser,
                FirendList = new List<string>() {
                    "张三",
                    "李四",                    
                    "王五",
                }
            },
        };


        /// <summary>
        /// 查询用户信息.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public TestData GetTestDataByUserName(string userName)
        {
            // 模拟长时间操作.
            Thread.Sleep(3000);

            return dataList.FirstOrDefault(p => p.UserName == userName);
        }


        public void InsertTestData(TestData data)
        {
            dataList.Add(data);
        }


        public void UpdateTestData(TestData data)
        {
            DeleteTestData(data.UserName);
            InsertTestData(data);
        }

        public void DeleteTestData(string userName)
        {
            TestData oldData = dataList.FirstOrDefault(p => p.UserName == userName);
            if (oldData != null)
            {
                dataList.Remove(oldData);
            }
        }
    }
}