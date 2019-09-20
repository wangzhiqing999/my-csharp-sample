using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using W1050_Mvc5.Resource;


namespace W1050_Mvc5.Models
{

    /// <summary>
    /// 用于测试 数据有效性检查的 数据类.
    /// </summary>
    [Serializable]
    public class TestModelData
    {


        /// <summary>
        /// 区域代码
        /// 
        /// 这里是 自定义了错误信息。
        /// 信息的文本，存储在资源文件中.
        /// </summary>
        [Display(Name = "区域代码")]
        [StringLength(8)]
        [Required(ErrorMessageResourceName = "AreaCodeRequired", ErrorMessageResourceType = typeof(MyResource))]
        public string AreaCode { set; get; }



        /// <summary>
        /// 区域名称
        /// </summary>
        [Display(Name = "区域名称")]
        [StringLength(64)]
        [Required]
        public string AreaName { set; get; }


        /// <summary>
        /// 显示权重
        /// </summary>
        [Display(Name = "显示权重")]
        [Required]
        [Range(1, 10)]
        public int DisplayWeight { get; set; }



    }
}