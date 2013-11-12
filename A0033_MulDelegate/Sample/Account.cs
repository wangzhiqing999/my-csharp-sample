using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0033_MulDelegate.Sample
{

    /// <summary>
    /// 这个类 仅仅存储一些基本数据.
    /// </summary>
    class Account
    {
        /// <summary>
        /// 名称
        /// </summary>
        private String name;


        /// <summary>
        /// 现金
        /// </summary>
        private double cash;


        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public double Cash
        {
            get
            {
                return cash;
            }
            set
            {
                cash = value;
            }
        }


    }

}
