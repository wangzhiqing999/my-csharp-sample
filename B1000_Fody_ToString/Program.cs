using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1000_Fody_ToString
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("测试 ToString.Fody .");

            TestUser test = new TestUser()
            {
                UserName = "测试用户",

                Password = "123456",

                Area = "上海",
            };


            Console.WriteLine(test.ToString());


            Console.ReadKey();

        }
    }








    /// <summary>
    /// 测试用于生成 ToString 的类.
    /// </summary>
    [ToString]
    public class TestUser
    {

        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { set; get; }



        /// <summary>
        /// 密码.
        /// </summary>
        [IgnoreDuringToString]
        public string Password { set; get; }



        /// <summary>
        /// 区域.
        /// </summary>
        public string Area { set; get; }


    }


}
