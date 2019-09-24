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
    /// 这个类里面，定义了 ErrorMessage 
    /// 
    /// 也就是当检查数据，发现不满足要求时，将使用 ErrorMessage 中定义的错误提示信息.
    /// </summary>
    public class TestPerson2
    {


        [Required(ErrorMessage = "{0} 必须填写")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} 必须填写")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "邮件格式不正确")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} 必须填写")]
        [Range(1, 100, ErrorMessage = "超出范围")]
        public int Age { get; set; }

        [Required(ErrorMessage = "{0} 必须填写")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}输入长度不正确")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0} 必须填写")]
        [Range(typeof(decimal), "1000.00", "2000.99")]
        public decimal Salary { get; set; }

    }
}
