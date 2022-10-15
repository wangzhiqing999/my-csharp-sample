using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0151_Excel.Model
{

    /// <summary>
    /// 测试数据类.
    /// </summary>
    internal class TestData
    {

        /// <summary>
        /// 编号.
        /// </summary>
        public int ID { set; get; }


        /// <summary>
        /// 名称.
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        /// 成绩.
        /// </summary>
        public int Value { set; get; }



        public override string ToString()
        {
            return $"{ID}: 姓名：{Name}； 成绩：{Value}";
        }
    }
}
