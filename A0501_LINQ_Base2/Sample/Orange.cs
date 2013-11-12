using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0501_LINQ_Base2.Sample
{

    /// <summary>
    /// 用于 演示 LINQ 的数据类.
    /// </summary>
    class Orange
    {

        /// <summary>
        /// 国家
        /// </summary>
        private String country;

        /// <summary>
        /// 苹果的颜色.
        /// </summary>
        private String color;

        /// <summary>
        /// 味道
        /// </summary>
        private String sapor;


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="color"></param>
        /// <param name="sapor"></param>
        public Orange(String country, String color, String sapor)
        {
            this.country = country;
            this.color = color;
            this.sapor = sapor;
        }


        public String Country
        {
            get
            {
                return country;
            }
        }


        public String Color
        {
            get
            {
                return color;
            }
        }


        public String Sapor
        {
            get
            {
                return sapor;
            }
        }


        public override string ToString()
        {
            return country + "产" + color + "色" + sapor + "桔子";
        }

    }

}
