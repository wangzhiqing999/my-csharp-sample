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
        [Display(Name = "区域代码", Prompt = "输入区域代码", ShortName = "代码", Description = "区域代码，长度8个字符以内.")]
        [StringLength(8)]
        [Required(ErrorMessageResourceName = "AreaCodeRequired", ErrorMessageResourceType = typeof(MyResource))]
        public string AreaCode { set; get; }



        /// <summary>
        /// 区域名称
        /// 
        /// 这里是 将错误信息，写在 ErrorMessage 中.
        /// 这么写，将失去 i18n 的功能.
        /// </summary>
        [Display(Name = "区域名称", Prompt = "输入区域名称", ShortName = "名称", Description = "区域名称，长度64个字符以内.")]
        [StringLength(64)]
        [Required(ErrorMessage = "{0} 不能为空")]
        public string AreaName { set; get; }


        /// <summary>
        /// 显示权重
        /// 
        /// 因为数据类型是 int， 其实也就默认是 Required.
        /// 
        /// 这里是使用 框架默认的 提示信息.
        /// 在高版本的 IIS 上，中英文切换正常.
        /// 在低版本的 IIS 上，好像提示信息一直是英文了.
        /// </summary>
        [Display(Name = "显示权重", Prompt = "输入显示权重", ShortName = "权重", Description = "显示权重，数值越大， 显示越靠前.")]
        [Range(1, 10)]
        public int DisplayWeight { get; set; }




        /// <summary>
        /// 区域备注
        /// 
        /// 上面几列是 Required 的。
        /// 这个属性是 非 Required 的。
        /// 主要是为了测试  自定义的  Html.IsRequiredFor
        /// </summary>
        [Display(Name = "区域备注", Prompt = "输入区域备注", ShortName = "备注", Description = "区域备注，长度256个字符以内.")]
        [StringLength(256)]
        public string AreaRemark { set; get; }


    }
}