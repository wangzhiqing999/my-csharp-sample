using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace A0640_EF_Enum.Sample
{

    public class Test
    {
        /// <summary>
        /// 数据库连接地址.
        /// 
        /// 在 Entity Framework 4 当中.
        /// 如果 Initial Catalog 指定的 “数据库”不存在
        /// 那么会在 Data Source 指定的服务器下，自动创建一个。
        /// 
        /// </summary>
        private static readonly string connString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestEnum;Integrated Security=True";


        MyDbContext context = new MyDbContext(connString);


        public IQueryable<TestData> TestDatas
        {
            get { return context.TestDataDbSet; }
        }

        public void SaveTestData(TestData data)
        {
            if (data.TestDataID == 0)
            {
                context.TestDataDbSet.Add(data);
            }
            else
            {
                context.Entry(data).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }

}
