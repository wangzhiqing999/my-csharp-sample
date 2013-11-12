using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A5050_UCbo
{

    /// <summary>
    /// 用于模拟一个  从数据库中检索出来的类
    /// </summary>
    public class TestClass
    {

        public TestClass(int code, string name)
        {
            this.Code = code;
            this.Name = name;
        }


        /// <summary>
        /// 代码.
        /// </summary>
        public int Code { set; get; }


        /// <summary>
        /// 名称.
        /// </summary>
        public string Name { set; get; }
    }


}
