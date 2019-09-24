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
    /// 本类没有自定义 ErrorMessage.
    /// 
    /// 具体的错误提示信息，是使用 “System.ComponentModel.DataAnnotations.Resources” 中定义的文本.
    /// </summary>
    public class TestPerson1
    {

        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Phone { get; set; }

        [Required]
        [Range(typeof(decimal), "1000.00", "2000.99")]
        public decimal Salary { get; set; }

    }
}
