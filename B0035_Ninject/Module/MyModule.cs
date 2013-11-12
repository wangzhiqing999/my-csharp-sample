using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Ninject.Modules;


using B0035_Ninject.Service;
using B0035_Ninject.ServiceImpl;


namespace B0035_Ninject.Module
{


    /// <summary>
    /// 注册的接口和接口实现类.
    /// 
    /// 
    /// NinjectModule
    /// 是通过在 Load() 方法中。
    /// 
    /// 指定 接口的具体实现.
    /// 
    /// </summary>
    public class MyModule : NinjectModule
    {

        public override void Load()
        {


            // 指定 IMySerialNumber  接口的实现 为 MySerialNumberMemory
            // 也就是 仅仅使用 内存的 实现
            // 不使用 数据库的 实现.            
            // ## To 方法：绑定到接口的具体实现。
            Bind<IMySerialNumber>().To<MySerialNumberMemory>();



            // 指定 ICarNumberScan  接口的实现 为 CarNumberScanDummy
            // 也就是 仅仅使用 虚拟 实现
            // ### ToMethod 方法：绑定到方法。
            Bind<ICarNumberScan>().ToMethod(context => CarNumberScanDummy.Instance());



            // 指定 ICarPark  接口的实现 为 CarParkMemory
            // 也就是 仅仅使用 虚拟 实现
            // ### ToConstant 也是一种绑定方式.
            Bind<ICarPark>().ToConstant(new CarParkDummy());



            // 指定 IPosService  接口的实现 为 PosDummy
            // 也就是 仅仅使用 虚拟 实现
            Bind<IPosService>().ToMethod(context => new PosDummy());




        }

    }

}
