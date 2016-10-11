using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1110_AutoMapper_EF.UiModel
{


    public class UiVersion
    {


        /// <summary>
        /// 版本流水.
        /// </summary>
        public long VersionID { set; get; }


        /// <summary>
        /// 产品代码.
        /// </summary>
        public string ProductCode { set; get; }



        /// <summary>
        /// 产品名称.
        /// </summary>
        public string ProductName { set; get; }



        /// <summary>
        /// 版本号.
        /// </summary>
        public string VersionNumber { set; get; }



        /// <summary>
        /// 版本数值.
        /// </summary>
        public int VersionCode { set; get; }



        /// <summary>
        /// 版本描述.
        /// </summary>
        public string VersionDesc { set; get; }



        /// <summary>
        /// 版本文件.
        /// </summary>
        public string VersionFile { set; get; }




        public override string ToString()
        {
            return String.Format("UiVersion [ VersionID = {0}; ProductCode = {1}; ProductName = {2}; VersionNumber = {3}, VersionDesc = {4} ]",
                this.VersionID,
                this.ProductCode, 
                this.ProductName,
                this.VersionNumber,
                this.VersionDesc);
        }



    }
}
