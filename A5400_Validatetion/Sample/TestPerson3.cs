using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace A5400_Validatetion.Sample
{


    /// <summary>
    /// 测试 Validatetion 的数据类.
    /// 
    /// 这个类里面，定义了 ErrorMessageResourceName 与  ErrorMessageResourceType
    /// 
    /// 也就是当检查数据，发现不满足要求时，将使用 资源文件中的 指定项目，来作为 错误提示信息.
    /// </summary>
    public class TestPerson3
    {


        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resource.TestResource))]
        [Display(Name = "用户姓名", Prompt = "输入用户姓名", ShortName = "姓名", Order = 1)]
        public string Name { get; set; }


        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resource.TestResource))]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessageResourceName = "RegexMessage", ErrorMessageResourceType = typeof(Resource.TestResource))]
        [Display(Name = "电子邮件地址", Prompt = "输入用户电子邮件地址", ShortName = "邮件", Order = 3)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resource.TestResource))]
        [Range(1, 100, ErrorMessageResourceName = "RangeMessage", ErrorMessageResourceType = typeof(Resource.TestResource))]
        [Display(Name = "用户年龄", Prompt = "输入用户年龄", ShortName = "年龄", Order = 2)]
        public int Age { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resource.TestResource))]
        [StringLength(11, MinimumLength = 11, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(Resource.TestResource))]
        [Display(Name = "用户电话", Prompt = "输入用户电话", ShortName = "电话", Order = 4)]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resource.TestResource))]
        [Range(typeof(decimal), "1000.00", "2000.99", ErrorMessageResourceName = "RangeMessage", ErrorMessageResourceType = typeof(Resource.TestResource))]
        [Display(Name = "用户收入", Prompt = "输入用户收入", ShortName = "收入", Order = 5)]
        public decimal Salary { get; set; }

    }
}
