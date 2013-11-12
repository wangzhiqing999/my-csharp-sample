using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


using Ninject;


using B0035_Ninject.Service;

using B0035_Ninject.Module;



namespace B0035_Ninject
{
    class Program
    {

        static void Main(string[] args)
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
