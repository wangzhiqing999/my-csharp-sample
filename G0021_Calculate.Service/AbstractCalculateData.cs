using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G0021_Calculate.Service
{



    /// <summary>
    /// 计算数据.
    /// </summary>
    public abstract class AbstractCalculateData
    {

        /// <summary>
        /// 最小随机数.
        /// </summary>
        private int minRandomVal = 1;


        /// <summary>
        /// 最大随机数.
        /// </summary>
        private int maxRandomVal = 10;


        /// <summary>
        /// 默认构造函数.
        /// </summary>
        public AbstractCalculateData()
        {
        }

        /// <summary>
        /// 指定最大值 最小值的构造函数.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public AbstractCalculateData(int min, int max)
        {
            this.minRandomVal = min;
            this.maxRandomVal = max;
        }



        /// <summary>
        /// 参数1.
        /// </summary>
        public int ParamValue1 { protected set; get; }



        /// <summary>
        /// 参数2.
        /// </summary>
        public int ParamValue2 { protected  set; get; }



        /// <summary>
        /// 正确的数据结果.
        /// </summary>
        public int ResultValue { set; get; }



        /// <summary>
        /// 模拟的错误的数据结果列表.
        /// </summary>
        public List<int> WrongDataList { protected set; get; }





        /// <summary>
        /// 抽象操作符号.
        /// 该操作由子类实现.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetOperation();


        /// <summary>
        /// 完成计算处理.
        /// </summary>
        /// <returns></returns>
        protected abstract int DoCompute();




        /// <summary>
        /// 获取计算式的表示.
        /// </summary>
        public string CalculateInfo
        {
            get
            {
                return String.Format("{0} {1} {2}",
                    this.ParamValue1,  this.GetOperation(), this.ParamValue2);
            }
        }


        /// <summary>
        /// 数据准备.
        /// </summary>
        public void DoPrepare()
        {
            // 构造随机数.
            Random r = new Random();

            // 获取参数1.
            this.ParamValue1 = r.Next(this.minRandomVal, this.maxRandomVal);

            // 获取参数2.
            this.ParamValue2 = r.Next(this.minRandomVal, this.maxRandomVal);

            // 计算结果.
            this.ResultValue = DoCompute(); 
            

            // 构造错误结果列表.
            // 根据正确的结果，-10 到 +10 之间. 
            // 排除 结果值.
            // 随机排序后， 设置到 模拟的错误的数据结果列表 中.
            var query =
                from data in Enumerable.Range(this.ResultValue - 10, this.ResultValue + 10)
                where data != this.ResultValue
                orderby Guid.NewGuid()
                select data;

            WrongDataList = query.ToList();

        }





    }


}
