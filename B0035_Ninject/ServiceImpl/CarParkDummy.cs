using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Ninject;

using B0035_Ninject.Service;


namespace B0035_Ninject.ServiceImpl
{

    /// <summary>
    /// 停车场处理接口的  虚拟 实现.
    /// </summary>
    public class CarParkDummy : ICarPark
    {

        /// <summary>
        /// 停车记录
        /// </summary>
        private Dictionary<string, DateTime> inCardParkDict = new Dictionary<string, DateTime>();



        #region 依赖注入的部分.


        /// <summary>
        /// 收银机服务.
        /// </summary>
        private IPosService posService = null;

        /// <summary>
        /// 收银机服务的属性.
        /// </summary>
        [Inject]
        public IPosService PosService
        {
            set
            {
                posService = value;
            }
        }



        #endregion




        void ICarPark.InCarPark(string cardNum)
        {
            Debug.Assert(!String.IsNullOrEmpty(cardNum), "不能进入一个没有车牌的车辆！");
            Debug.Assert(!inCardParkDict.ContainsKey(cardNum), "难度遇到了套牌车？");

            inCardParkDict.Add(cardNum, DateTime.Now);

            Console.WriteLine(
                "{0} 于 {1} 进入车库！", cardNum, DateTime.Now);
        }



        void ICarPark.OutCarPark(string cardNum)
        {
            Debug.Assert(inCardParkDict.ContainsKey(cardNum), "什么车换块车牌出来了？");

            // 获取 进入车库的时间.
            DateTime inDateTime = inCardParkDict[cardNum];

            Debug.Assert(DateTime.Now > inDateTime, "这车时光隧道过来的么？");

            // 清除 入库 数据.
            inCardParkDict.Remove(cardNum);

            // 计算停车时间.
            int inTimeMs = (int)(DateTime.Now - inDateTime).TotalMilliseconds;

            Console.WriteLine(
                "{0} 于 {1} 离开车库！ 停车 {2} 毫秒。", cardNum, DateTime.Now, inTimeMs);

            // 模拟收银机收取费用.
            posService.DoSale(inTimeMs);

        }



    }

}
