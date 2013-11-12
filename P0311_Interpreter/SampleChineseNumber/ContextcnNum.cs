using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0311_Interpreter.SampleChineseNumber
{
    
    /// <summary>
    /// 环境角色
    /// </summary>
    public class ContextcnNum
    {
        /// <summary>
        /// 汉字表示的数字
        /// </summary>
        public string statement
        {
            get;
            set;
        }

        /// <summary>
        /// 阿拉伯数字
        /// </summary>
        public int data
        {
            get;
            set;
        }

        /// <summary>
        /// 构造函数
        /// 接受一个汉字表达式数字
        /// </summary>
        /// <param name="statement">汉字表达式数字</param>
        public ContextcnNum(string statement)
        {
            this.statement = statement;
        }
    }
}
