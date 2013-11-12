using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using B0045_MOQ_Ninject.Service;
using Moq;
using Ninject.Modules;

namespace B0045_MOQ_Ninject.Module
{
    /// <summary>
    /// 注册的接口和接口实现类.
    /// NinjectModule
    /// 是通过在 Load() 方法中。
    /// 指定 接口的具体实现.
    /// </summary>
    public class MyModule : NinjectModule
    {
        /// <summary>
        /// 加载 指定 接口的具体实现 信息.
        /// </summary>
        public override void Load()
        {
            // Mock 一个 车牌扫描的 接口.
            var mockCarNumberScan = new Mock<ICarNumberScan>();

            // 模拟，当调用 Mock 对象的 GetCarNumber 方法时，直接返回 浙AZZZZZZ.
            mockCarNumberScan.Setup(cns => cns.GetCarNumber()).Returns("浙AZZZZZZ");

            // 指定 ICarNumberScan  接口的实现 为 Mock 对象.
            Bind<ICarNumberScan>().ToConstant(mockCarNumberScan.Object);

            // Mock 一个停车场的接口.
            var mockCarPark = new Mock<ICarPark>();

            // 当发生 InCarPark 调用的时候，输出参数信息.
            mockCarPark.Setup(cp => cp.InCarPark(It.IsAny<string>()))
                .Callback((string s) => Console.WriteLine("{0}的车子，进入了停车场...", s));

            // 当发生 InCarPark 调用的时候，输出参数信息.
            mockCarPark.Setup(cp => cp.OutCarPark(It.IsAny<string>()))
                .Callback((string s) => Console.WriteLine("{0}的车子，离开了停车场...", s));

            // 指定 ICarPark 接口的实现 为 Mock 对象.
            Bind<ICarPark>().ToConstant(mockCarPark.Object);
        }
    }
}
