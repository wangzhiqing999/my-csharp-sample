using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace A0630_EF_Inherit_TPH.Sample
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
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestInherit;Integrated Security=True";


        MyDbContext context = new MyDbContext(connString);



        public IQueryable<WorkMember> WorkMembers
        {
            get { return context.WorkMemberDbSet; }
        }


        public IQueryable<Operator> Operators
        {
            get { return context.OperatorDbSet; }
        }

        public IQueryable<Manager> Managers
        {
            get { return context.ManagerDbSet; }
        }



        public void SaveWorkMember(WorkMember op)
        {
            if (op.MemberID == 0)
            {
                context.WorkMemberDbSet.Add(op);
            }
            else
            {
                context.Entry(op).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
