using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O0101_DotNetCallPython
{

    /// <summary>
    /// 测试对象.
    /// 
    /// 用于传递数据给 Python 脚本
    /// </summary>
    public class TestDataObject
    {

        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { set; get; }


        /// <summary>
        /// 年龄.
        /// </summary>
        public int Age { set; get; }



        /// <summary>
        /// 描述信息.
        /// </summary>
        public string Desc { set; get; }



        public void AddAge(int age)
        {
            this.Age = this.Age + age;
            this.Desc = String.Format("{0}又大了{1}岁 in C#", this.UserName, age);
        }



        public override string ToString()
        {
            return String.Format("姓名：{0}; 年龄：{1}; 描述:{2}", this.UserName, this.Age, this.Desc);
        }


    }
}
