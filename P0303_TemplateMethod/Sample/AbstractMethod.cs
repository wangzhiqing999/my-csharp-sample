using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace P0303_TemplateMethod.Sample
{

    /// <summary>
    /// 模板方法 中的 抽象模板角色 
    /// 
    /// 
    /// </summary>
    public abstract class AbstractMethod
    {

        /// <summary>
        /// 基本方法  （抽象方法：子类必须实现）
        /// 
        /// 连接到数据库.
        /// </summary>
        /// <returns></returns>
        public abstract bool ConnectDataBase();


        /// <summary>
        /// 基本方法  （virtual 方法： 子类可选择性的实现/或不实现）
        /// 
        /// 获取记录条数.
        /// </summary>
        /// <returns></returns>
        public virtual int ExecQueryNon()
        {
            Console.WriteLine("[Common] 我执行了 SELECT COUNT(1) FROM 表...");
            return 1;
        }


        /// <summary>
        /// 基本方法  （virtual 方法： 子类可选择性的实现/或不实现）
        /// 
        /// 获取数据明细.
        /// </summary>
        /// <returns></returns>
        public virtual DataSet GetData()
        {
            Console.WriteLine("[Common] 我执行了 SELECT * FROM 表...");
            return new DataSet();
        }

        


        /// <summary>
        /// 基本方法  （抽象方法：子类必须实现）
        /// 
        /// 断开数据库连接.
        /// </summary>
        public abstract void DisconnectDataBase();



        /// <summary>
        /// 模板方法 
        /// 
        /// </summary>
        public void Process()
        {

            Console.WriteLine("[Common] 处理开始...");

            if (ConnectDataBase() == true)
            {
                int ss = ExecQueryNon();

                Console.WriteLine("[Common] 查询到了 {0} 行记录", ss);

                if (ss > 0)
                {
                    DataSet ds = GetData();
                }

                DisconnectDataBase();
            }

            Console.WriteLine("[Common] 处理结束...");


            Console.WriteLine();
        }




    }
}
