using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using NUnit.Framework;


using A1040_Password.ConcreteHandler;


namespace A1040_Password.UnitTest
{

    /// <summary>
    /// 大写字母检查处理的 单元测试.
    /// </summary>
    [TestFixture]
    public class PasswordUpperCaseCheckerTest
    {

        [Test]
        [Category("基础测试")]
        public void TestPasswordCheck()
        {
            PasswordUpperCaseChecker checker = new PasswordUpperCaseChecker();

            // 为 null 将检查失败！
            Assert.False(checker.IsPasswordOk("TEST", "", null));

            // 空字符 将检查失败！
            Assert.False(checker.IsPasswordOk("TEST", "", ""));

            // 纯空白字符 将检查失败！
            Assert.False(checker.IsPasswordOk("TEST", "", "         "));


            // 只有数字 将检查失败！
            Assert.False(checker.IsPasswordOk("TEST", "", "12345"));

            // 只有符号 将检查失败！
            Assert.False(checker.IsPasswordOk("TEST", "", "+-*/"));

            // 只有小写字母， 将检查失败.
            Assert.False(checker.IsPasswordOk("TEST", "", "abcdef"));


            // 包含大写字母， 将检查通过.
            Assert.True(checker.IsPasswordOk("TEST", "", "ABCDEF"));
            Assert.True(checker.IsPasswordOk("TEST", "", "ABcdEF"));



        }

    }

}
