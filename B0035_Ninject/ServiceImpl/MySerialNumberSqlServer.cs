using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using B0035_Ninject.Service;


namespace B0035_Ninject.ServiceImpl
{

    /// <summary>
    /// 流水号处理服务 的 SQL Server 实现.
    /// </summary>
    public class MySerialNumberSqlServer : IMySerialNumber
    {



        string IMySerialNumber.MySerialNumberCurrVal()
        {
            throw new NotImplementedException();
        }



        string IMySerialNumber.MySerialNumberNextVal()
        {
            throw new NotImplementedException();
        }


    }

}
