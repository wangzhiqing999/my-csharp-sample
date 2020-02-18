using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace A0621_EF_CodeFirst.Sample
{    
    
    /// <summary>
    /// 基本测试类.
    /// </summary>
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
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestCodeFirst;Integrated Security=True";


        MyDbContext context = new MyDbContext(connString);


        /// <summary>
        /// 用于 Linq 处理的数据源.
        /// </summary>
        public IQueryable<MrDemoData> MrDemoDataSource
        {
            get { return context.MrDemoDataDbSet; }
        }



        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="data"></param>
        public void SaveMrDemoData(MrDemoData data)
        {
            if (data.DemoID == 0)
            {
                context.MrDemoDataDbSet.Add(data);
            }
            else
            {
                //context.Entry(data).State = EntityState.Modified;
            }
            context.SaveChanges();
        }


        /// <summary>
        /// 删除.
        /// </summary>
        /// <param name="data"></param>
        public void DeleteMrDemoData(MrDemoData data)
        {
            context.MrDemoDataDbSet.Remove(data);
            context.SaveChanges();
        }




        /// <summary>
        /// 测试查询 smslog .
        /// </summary>
        public void TestQuerySmsLog()
        {

            Console.WriteLine("----- 查询当期数据 -----");

            // 查询 sms_log 表.
            var query =
                from data in context.SmsLogs
                where
                    data.PhoneNumber.Contains("666")
                select
                    data;

            List<SmsLog> dataList = query.ToList();

            foreach(var item in dataList)
            {
                Console.WriteLine(item.ToString());
            }




            Console.WriteLine("----- 查询历史数据 -----");


            DbQueryResult dbQuery = DbQueryGetter<SmsLog>.GetDbQueryResult(query);
            string sql;
            object[] param = dbQuery.ParameterList.ToArray();

            // 查询 2019年12月的历史数据.
            sql = dbQuery.Sql.Replace("[sms_log]", "[sms_log_201912]");
            dataList = context.Database.SqlQuery<SmsLog>(sql, param).ToList();
            foreach (var item in dataList)
            {
                Console.WriteLine(item.ToString());
            }


            // 查询 2020年1月的历史数据.
            sql = dbQuery.Sql.Replace("[sms_log]", "[sms_log_202001]");
            dataList = context.Database.SqlQuery<SmsLog>(sql, param).ToList();
            foreach (var item in dataList)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }

}
