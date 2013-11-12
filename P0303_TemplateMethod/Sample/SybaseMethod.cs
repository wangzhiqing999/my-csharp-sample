using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0303_TemplateMethod.Sample
{

    public class SybaseMethod : AbstractMethod
    {
        public override bool ConnectDataBase()
        {
            Console.WriteLine("[Sybase] 连接到 Sybase 数据库...");
            return true;
        }

        public override void DisconnectDataBase()
        {
            Console.WriteLine("[Sybase] 断开 Sybase 数据库的连接...");
        }
    }
}
