using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace A0620_EFv4.Sample
{


    /// <summary>
    /// 基本测试类.
    /// </summary>
    public class Test
    {

        private static readonly string connString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Test2;Integrated Security=True";

        MyDbContext context = new MyDbContext(connString);


        /// <summary>
        /// 用于 Linq 处理的数据源.
        /// </summary>
        public IQueryable<mr_demo_data> MrDemoDataSource
        {
            get { return context.MrDemoDataDbSet; }
        }



        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="data"></param>
        public void SaveMrDemoData(mr_demo_data data)
        {
            if (data.demo_id == 0)
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
        public void DeleteMrDemoData(mr_demo_data data)
        {
            context.MrDemoDataDbSet.Remove(data);
            context.SaveChanges();
        }

    }


}
