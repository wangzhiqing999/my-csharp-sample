using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1110_AutoMapper_EF.UiModel
{
    public class UiProduct
    {



        /// <summary>
        /// 产品代码.
        /// </summary>
        public string ProductCode { set; get; }




        /// <summary>
        /// 产品名称.
        /// </summary>
        public string ProductName { set; get; }




        /// <summary>
        /// 版本列表.
        /// </summary>
        public List<UiVersion> VersionList { set; get; }




        public override string ToString()
        {

            StringBuilder buff = new StringBuilder();
            buff.AppendFormat("UiProduct [ ProductCode = {0}; ProductName = {1}; ", this.ProductCode, this.ProductName);
            buff.AppendLine();

            foreach (var item in this.VersionList)
            {
                buff.AppendLine(item.ToString());
            }

            buff.Append("]");
            return buff.ToString();

        }

    }
}
