using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace A0076_AOPDynamicObject.Sample
{

	public class ObjectClass
	{

        /// <summary>
        /// 测试方法
        /// </summary>
		public void Test1()
		{
			Console.WriteLine("Test");
		}


        /// <summary>
        /// 测试方法
        /// </summary>
		public void Test2(string para)
		{
			Console.WriteLine("Test:" + para);
		}

        /// <summary>
        /// 测试方法
        /// </summary>
		public void Test3(int para)
		{
			Console.WriteLine("Test:" + para);
		}


        /// <summary>
        /// 测试 有 默认参数数值的方法.
        /// 参数有默认值， 为  .NET 4.0  新特性.
        /// 
        /// </summary>
        public void TestX(int para = 1024)
        {
            Console.WriteLine("TestX:" + para);
        }


        /// <summary>
        /// 测试 ref 方式的参数.
        /// </summary>
        /// <param name="para"></param>
        public void TestY(ref int para)
        {
            Console.WriteLine("TestY:" + para);
            para = 1024;
        }


        /// <summary>
        /// 测试 out 方式的参数.
        /// </summary>
        /// <param name="para"></param>
        public void TestZ(out int para)
        {
            Console.WriteLine("TestZ");
            para = 1024;
        }


	}
}
