using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace P0303_TemplateMethod.Sample
{

    /// <summary>
    /// 模板方法 中的 具体模板角色
    /// </summary>
    public class OracleMethod : AbstractMethod
    {

        public override bool ConnectDataBase()
        {
            Console.WriteLine("[Oracle] 连接到 Oracle 数据库...");
            return true;
        }


        public override int ExecQueryNon()
        {
            Console.WriteLine("[Oracle] 我执行了 SELECT COUNT(1) FROM Oralce的表...");
            return 1;
        }


        public override System.Data.DataSet GetData()
        {
            Console.WriteLine("[Oracle] 我执行了 SELECT * FROM Oralce的表...");
            return new DataSet();
        }


        public override void DisconnectDataBase()
        {
            Console.WriteLine("[Oracle] 断开 Oracle 数据库的连接...");
        }
    }
}
