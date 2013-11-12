using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

using B0040_MOQ.Sample;

namespace B0040_MOQ
{
    /// <summary>
    /// 测试类.
    /// 启动程序, 将运行这个类下面的 Main 方法.
    /// </summary>
    class Program
    {
        /// <summary>
        /// 测试程序的主方法。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 方法测试.
            TestMethods();

            Console.WriteLine("=========================================");

            // 参数匹配 测试.
            TestMatchingArguments();

            Console.WriteLine("=========================================");

            // 测试设置属性.
            TestProperties();

            Console.WriteLine("=========================================");

            // Callback 测试
            TestCallbacks();

            Console.WriteLine("=========================================");

            TestVerification();
            TestVerification2();

            Console.ReadLine();
        }

        /// <summary>
        /// 方法测试.
        /// </summary>
        private static void TestMethods()
        {

            #region 定义 Mock 的部分.


            // 构造一个 针对 IHelloWorld  接口的 Mock 对象。
            var mock = new Mock<IHelloWorld>();

            // 当调用 IHelloWorld  接口的 IsHelloWorld 方法时，  返回  true.
            mock.Setup(h => h.IsHelloWorld()).Returns(true);


            // 对于调用 IHelloWorld  接口的 IsIncludeHelloWorld 方法时， 对于传入的任何参数， 都返回 true.
            mock.Setup(h => h.IsIncludeHelloWorld(It.IsAny<string>())).Returns(true);


            // out arguments
            var outString = "测试 out 参数结果";
            // 对于调用 IHelloWorld  接口的 TryHelloWorld 方法时。
            // 如果传入了 hello， 将返回 true , 并将设置 out 参数的数值.
            mock.Setup(foo => foo.TryHelloWorld("hello", out outString)).Returns(true);
            // 如果传入了 world， 将返回 false
            ////mock.Setup(foo => foo.TryHelloWorld("world", out outString)).Returns(false);


            // ref arguments
            var refString = "测试 ref 参数结果";
            // 对于调用 IHelloWorld  接口的 BuildHelloWorld 方法时。
            // 将返回 true, 并设置 ref 的数值.
            mock.Setup(foo => foo.BuildHelloWorld(ref refString)).Returns(true);


            #endregion





            #region 测试 Mock 的结果


            IHelloWorld hw = mock.Object;


            Console.WriteLine("IsHelloWorld() 返回结果：{0}", hw.IsHelloWorld());

            Console.WriteLine("IsIncludeHelloWorld( string ) 返回结果：{0}", hw.IsIncludeHelloWorld("Hello?"));


            string outStr = null;
            if (hw.TryHelloWorld("hello", out outStr))
            {
                Console.WriteLine("TryHelloWorld() 后 ， out 参数 = {0}", outStr);
            }
            else
            {
                Console.WriteLine("可能出错了！");
            }
            if (hw.TryHelloWorld("world", out outStr))
            {
                Console.WriteLine("真的是出错了！");
            }


            if (hw.BuildHelloWorld(ref refString))
            {
                Console.WriteLine("BuildHelloWorld() 后 ， ref 参数 = {0}", refString);
            }
            else
            {
                Console.WriteLine("可能出错了！");
            }



            #endregion

        }



        /// <summary>
        /// 参数匹配测试.
        /// </summary>
        private static void TestMatchingArguments()
        {
            #region 定义 Mock 的部分.


            // 构造一个 针对 IHelloWorld  接口的 Mock 对象。
            var mock = new Mock<IHelloWorld>();

            
            // 测试 It.IsAny
            // 当调用 IHelloWorld  接口的 IsUsableID 方法时， 对于传入的任意 int 数据，  返回  true.
            mock.Setup(h => h.IsUsableID(It.IsAny<int>())).Returns(true);


            // 测试 It.Is
            // 当调用 IHelloWorld  接口的 IsEven 方法时
            // 对于传入的 int 数据，  如果满足 参数 %2 等于零  返回  true.  否则返回 false.
            mock.Setup(h => h.IsEven(It.Is<int>(i => i % 2 == 0))).Returns(true);

            
            // 测试 It.IsInRange
            // 当调用 IHelloWorld  接口的 Add 方法时
            // 如果 满足 参数 在 0-10 之间， 那么返回 true.  否则返回 false.
            mock.Setup(h => h.Add(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns(true);


            // 测试 It.IsRegex
            // 当调用 IHelloWorld  接口的 Exists 方法时
            // 如果参数中包含数字，那么返回 true.
            mock.Setup(h => h.Exists(It.IsRegex("[0-9]+", System.Text.RegularExpressions.RegexOptions.IgnoreCase))).Returns(true);

            #endregion





            #region 测试 Mock 的结果


            IHelloWorld hw = mock.Object;


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("IsUsableID({0}) 返回结果：{1}", i, hw.IsUsableID(i));
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("IsEven( {0} ) 返回结果：{1}", i, hw.IsEven(i));
            }


            for (int i = 8; i < 13; i++)
            {
                Console.WriteLine("Add( {0} ) 返回结果：{1}", i, hw.Add(i));
            }


            string val = "ABC";
            Console.WriteLine("Exists( {0} ) 返回结果：{1}", val, hw.Exists(val));
            val = "AB12";
            Console.WriteLine("Exists( {0} ) 返回结果：{1}", val, hw.Exists(val));


            #endregion

        }



        /// <summary>
        /// 属性测试.
        /// </summary>
        private static void TestProperties()
        {

            #region 定义 Mock 的部分.


            // 构造一个 针对 DataClass  接口的 Mock 对象。
            var mock = new Mock<DataClass>();

            // TestName 属性的获取.
            mock.Setup(p => p.TestName).Returns("测试获取属性值");

            // TestName 属性的设置.
            mock.SetupSet(p => p.TestName = "测试设置属性值");


            // Setup a property so that it will automatically start tracking its value (also known as Stub).
            // TestID 属性将 设置默认值 1024.  
            mock.SetupProperty(f => f.TestID, 1024);


            // Stub all properties on a mock (not available on Silverlight): 
            // mock.SetupAllProperties();

            #endregion





            #region 测试 Mock 的结果


            DataClass dc = mock.Object;

            dc.TestName = "测试设置属性值";

            Console.WriteLine(dc.TestName);


            
            // VerifySet 方法用于验证  传入的属性， 是否满足预期.
            // 如不满足，将抛出异常.
            mock.VerifySet(p => p.TestName = "测试设置属性值");



            Console.WriteLine(dc.TestID);
            dc.TestID = 2048;
            Console.WriteLine(dc.TestID);



            #endregion

        }



        /// <summary>
        /// 测试回调.
        /// </summary>
        private static void TestCallbacks()
        {
            // 调用 IsHelloWorld 的次数.
            int callIsHelloWorldCount = 0;


            // 调用 IsIncludeHelloWorld 的参数列表.
            List<string> callIsIncludeHelloWorldParamList = new List<string>();


            #region 定义 Mock 的部分.


            // 构造一个 针对 IHelloWorld  接口的 Mock 对象。
            var mock = new Mock<IHelloWorld>();

            // 当调用 IHelloWorld  接口的 IsHelloWorld 方法时，  返回  true.
            // 每调用一次， callIsHelloWorldCount 递增1.
            mock.Setup(h => h.IsHelloWorld())
                .Callback(() => Console.WriteLine("开始运行 IsHelloWorld"))
                .Returns(true)
                .Callback(() => { Console.WriteLine("结束运行 IsHelloWorld"); callIsHelloWorldCount++; });


            // 当调用 IHelloWorld  接口的 IsIncludeHelloWorld 方法时，  返回  true.
            // 每调用一次， 将参数信息，加入 callIsIncludeHelloWorldParamList
            mock.Setup(h => h.IsIncludeHelloWorld(It.IsAny<string>())).Returns(true).Callback((string s) => callIsIncludeHelloWorldParamList.Add(s));




            #endregion





            #region 测试 Mock 的结果


            IHelloWorld hw = mock.Object;


            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("第 {0} 次调用 IsHelloWorld()", i);
                hw.IsHelloWorld();
                Console.WriteLine("调用次数 = {0}", callIsHelloWorldCount);
            }



            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("第 {0} 次调用 IsIncludeHelloWorld()", i);
                hw.IsIncludeHelloWorld("Test_" + i);
            }
            Console.WriteLine("调用完毕后的数据结果：");
            foreach (string s in callIsIncludeHelloWorldParamList)
            {
                Console.WriteLine(s);
            }


            #endregion

        }



        /// <summary>
        /// 验证 方法
        /// </summary>
        static void TestVerification()
        {

            #region 定义 Mock 的部分.

            // 构造一个 针对 IHelloWorld  接口的 Mock 对象。
            var mock = new Mock<IHelloWorld>();

            // 当调用 IHelloWorld  接口的 IsHelloWorld 方法时，  返回  true.
            // 每调用一次， callIsHelloWorldCount 递增1.
            mock.Setup(h => h.IsHelloWorld()).Returns(true);
   
            #endregion





            #region 测试 Mock 的结果


            IHelloWorld hw = mock.Object;


            // 到当前行为止。  IsHelloWorld 从来没有被调用过.
            mock.Verify(f => f.IsHelloWorld(), Times.Never());

            // 调用一次.
            hw.IsHelloWorld();

            // 到当前行为止。  IsHelloWorld 只被调用过一次.
            mock.Verify(f => f.IsHelloWorld(), Times.Once());

            // 到当前行为止。  IsHelloWorld 只被调用过  至多一次.
            mock.Verify(f => f.IsHelloWorld(), Times.AtMostOnce());

            // 到当前行为止。  IsHelloWorld 只被调用过  至少一次.
            mock.Verify(f => f.IsHelloWorld(), Times.AtLeastOnce());



            // 调用一次.
            hw.IsHelloWorld();

            // 到当前行为止。  IsHelloWorld 只被调用过  至多2次.
            mock.Verify(f => f.IsHelloWorld(), Times.AtMost(2));

            // 到当前行为止。  IsHelloWorld 只被调用过  至少一次.
            mock.Verify(f => f.IsHelloWorld(), Times.AtLeastOnce());


            // 调用一次.
            hw.IsHelloWorld();

            // 到当前行为止。  IsHelloWorld 只被调用过  至多3次.
            mock.Verify(f => f.IsHelloWorld(), Times.AtMost(3));

            // 到当前行为止。  IsHelloWorld 只被调用过  至少一次.
            mock.Verify(f => f.IsHelloWorld(), Times.AtLeastOnce());




            #endregion
        }


        /// <summary>
        /// 验证  属性.
        /// </summary>
        static void TestVerification2()
        {

            #region 定义 Mock 的部分.


            // 构造一个 针对 DataClass  接口的 Mock 对象。
            var mock = new Mock<DataClass>();

            // TestName 属性的获取.
            mock.Setup(p => p.TestName).Returns("测试获取属性值");

            // TestName 属性的设置.
            mock.SetupSet(p => p.TestName = "测试设置属性值");


            // Setup a property so that it will automatically start tracking its value (also known as Stub).
            // TestID 属性将 设置默认值 1024.  
            mock.SetupProperty(f => f.TestID, 1024);


            // Stub all properties on a mock (not available on Silverlight): 
            // mock.SetupAllProperties();

            #endregion





            #region 测试 Mock 的结果


            DataClass dc = mock.Object;

            dc.TestName = "测试设置属性值";

            // VerifySet 方法用于验证  传入的属性， 是否满足预期.
            // 如不满足，将抛出异常.
            mock.VerifySet(p => p.TestName = "测试设置属性值");




            Console.WriteLine(dc.TestName);

            // VerifyGet 方法用于验证  确实 获取了指定的属性。
            mock.VerifyGet(foo => foo.TestName);






            Console.WriteLine(dc.TestID);
            
            dc.TestID = 2048;

            // VerifySet 方法用于验证  传入的属性
            // 这里验证， 设置属性的数据， 范围应该在  1024 - 2018 之间。
            mock.VerifySet(p => p.TestID = It.IsInRange(1024, 2048, Range.Inclusive));

            Console.WriteLine(dc.TestID);



            #endregion

        }


    }
}
