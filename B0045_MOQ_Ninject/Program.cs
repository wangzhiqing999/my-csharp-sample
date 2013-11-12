using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using B0045_MOQ_Ninject.Service;
using B0045_MOQ_Ninject.Module;
using Ninject;

namespace B0045_MOQ_Ninject
{
    /// <summary>
    /// 启动类.
    /// 本类用于测试 停车场 进出车辆的处理。
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main 程序启动入口.
        /// </summary>
        /// <param name="args">命令行 参数</param>
        public static void Main(string[] args)
        {
            using (StandardKernel kernal = new StandardKernel(new MyModule()))
            {
                // 取得 停车场实现.
                ICarPark carpark = kernal.Get<ICarPark>();

                // 取得 车牌扫描实现.
                ICarNumberScan carNumSacn = kernal.Get<ICarNumberScan>();

                // 取得 车牌号码.
                string carNum = carNumSacn.GetCarNumber();

                for (int i = 1; i < 5; i++)
                {
                    // 进入车库.
                    carpark.InCarPark(carNum);

                    Thread.Sleep(1000 + i);

                    // 离开车库.
                    carpark.OutCarPark(carNum);
                }

                Console.ReadLine();
            }
        }
    }
}
