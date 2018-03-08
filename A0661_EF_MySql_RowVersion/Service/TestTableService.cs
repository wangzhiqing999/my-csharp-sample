using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using A0661_EF_MySql_RowVersion.Model;
using A0661_EF_MySql_RowVersion.DataAccess;

namespace A0661_EF_MySql_RowVersion.Service
{
    public class TestTableService
    {

        /// <summary>
        /// 获取最后一条测试数据.
        /// </summary>
        /// <returns></returns>
        public TestTable GetLastData()
        {
            TestTable result = null;
            using (TestContext context = new TestContext ())
            {
                var query =
                    from data in context.TestTables
                    orderby data.ID descending
                    select data;
                result = query.FirstOrDefault();

                if(result == null)
                {
                    // 没有数据的情况下， 创建一行.
                    result = new TestTable();
                    context.TestTables.Add(result);
                    context.SaveChanges();
                }
            }
            return result;
        }



        public bool Update(TestTable data)
        {
            try
            {
                using (TestContext context = new TestContext())
                {
                    // 获取数据库的数据.
                    TestTable dbData = context.TestTables.Find(data.ID);

                    if(data == null)
                    {
                        return false;
                    }

                    // 先从上下文中的旧实体获取跟踪
                    DbEntityEntry entry = context.Entry(dbData);
                    // 把新值设置到旧实体上
                    entry.CurrentValues.SetValues(data);

                    // 物理保存.
                    context.SaveChanges();

                    return true;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }





    }
}
