using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0060_Enum.Sample
{

    /// <summary>
    /// 用于测试的， 按位存储的枚举.
    /// </summary>
    public enum ResourceMode
    {
        /// <summary>
        /// 啥也没有.
        /// </summary>
        None = 0,

        /// <summary>
        /// 可读.
        /// </summary>
        Read = 1,

        /// <summary>
        /// 可写.
        /// </summary>
        Write = 2,

        /// <summary>
        /// 可管理.
        /// </summary>
        Admin = 4,

    }

    public class EnumSample2
    {

        public void DoTestAll()
        {
            ResourceMode myNone = ResourceMode.None;
            ResourceMode myReadonly = ResourceMode.Read;
            ResourceMode myReadWrite = ResourceMode.Read | ResourceMode.Write;
            ResourceMode myAdmin = ResourceMode.Read | ResourceMode.Write | ResourceMode.Admin;


            TestAll(myNone);
            TestAll(myReadonly);
            TestAll(myReadWrite);
            TestAll(myAdmin);



            Console.WriteLine();
            Console.WriteLine("----- 测试修改 -----");

            // 初始化。
            ResourceMode myTest = ResourceMode.Read | ResourceMode.Write | ResourceMode.Admin;
            TestAll(myTest);

            // 测试修改数值.（移除）
            myTest &= ~ResourceMode.Admin;
            TestAll(myTest);

            // 测试修改数值.（移除）
            myTest &= ~ResourceMode.Write;
            TestAll(myTest);

            // 测试修改数值.（添加）
            myTest |= ResourceMode.Write;
            TestAll(myTest);

        }






        /// <summary>
        /// 测试 【是否可读取】
        /// </summary>
        /// <param name="mode"></param>
        private void TestReadAble(ResourceMode mode)
        {
            Console.WriteLine("测试 【是否可读取】: {0}", mode);

            if((mode & ResourceMode.Read) > 0)
            {
                Console.WriteLine("    结果： 可读取！");
            } else
            {
                Console.WriteLine("    结果： 不可读取！");
            }
        }


        /// <summary>
        /// 测试 【是否可写入】
        /// </summary>
        /// <param name="mode"></param>
        private void TestWriteAble(ResourceMode mode)
        {
            Console.WriteLine("测试 【是否可写入】: {0}", mode);

            if ((mode & ResourceMode.Write) > 0)
            {
                Console.WriteLine("    结果： 可写入！");
            }
            else
            {
                Console.WriteLine("    结果： 不可写入！");
            }
        }



        /// <summary>
        /// 测试 【是否可管理】
        /// </summary>
        /// <param name="mode"></param>
        private void TestAdminAble(ResourceMode mode)
        {
            Console.WriteLine("测试 【是否可管理】: {0}", mode);

            if ((mode & ResourceMode.Admin) > 0)
            {
                Console.WriteLine("    结果： 可管理！");
            }
            else
            {
                Console.WriteLine("    结果： 不可管理！");
            }
        }



        private void TestAll(ResourceMode mode)
        {
            Console.WriteLine("--------------------");
            this.TestReadAble(mode);
            this.TestWriteAble(mode);
            this.TestAdminAble(mode);
            Console.WriteLine();
        }



    }
}
