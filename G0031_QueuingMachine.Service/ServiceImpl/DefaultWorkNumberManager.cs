using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using G0031_QueuingMachine.Service;


namespace G0031_QueuingMachine.ServiceImpl
{

    /// <summary>
    /// 默认的 排队号码分配
    /// </summary>
    public class DefaultWorkNumberManager : IWorkNumberManager
    {

        /// <summary>
        /// 号码前缀.
        /// </summary>
        private string workNumberPrefix;

        /// <summary>
        /// 号码前缀属性.
        /// </summary>
        public string WorkNumberPrefix
        {
            get { return workNumberPrefix; }
        }

        /// <summary>
        /// 号码长度.
        /// </summary>
        private int workNumberLength;


        /// <summary>
        /// 当前排队号码
        /// </summary>
        private int currentWorkNumber = 0;



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="prefix">号码前缀</param>
        /// <param name="length">号码长度</param>
        public DefaultWorkNumberManager(string prefix, int length)
        {
            if (prefix.Length >= length)
            {
                throw new ArgumentException("号码前缀长度大于等于号码长度！");
            }

            this.workNumberPrefix = prefix;
            this.workNumberLength = length;

            
        }



        /// <summary>
        /// 产生一个新的号码.
        /// </summary>
        /// <returns></returns>
        public string GetNextWorkNumber()
        {
            // 号码递增.
            currentWorkNumber++;
            // 格式化.
            string code = currentWorkNumber.ToString();
            code = code.PadLeft(workNumberLength - workNumberPrefix.Length, '0');
            // 返回.
            return workNumberPrefix + code;
        }



    }


}
