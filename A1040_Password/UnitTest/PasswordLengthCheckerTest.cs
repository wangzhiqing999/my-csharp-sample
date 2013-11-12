using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


using A1040_Password.ConcreteHandler;

namespace A1040_Password.UnitTest
{

    /// <summary>
    /// 密码长度检查处理的 单元测试.
    /// </summary>
    [TestFixture]
    public class PasswordLengthCheckerTest
    {


        [Test]
        [Category("基础测试")]
        public void TestPasswordCheck()
        {


            PasswordLengthChecker checker = new PasswordLengthChecker()
            {
                 MinPasswordLength = 6,
                 MaxPasswordLength = 15
            };

            // 为 null 将检查失败！
            Assert.False(checker.IsPasswordOk("TEST", "", null));

            // 空字符 将检查失败！
            Assert.False(checker.IsPasswordOk("TEST", "", ""));

            // 纯空白字符 将检查失败！
            Assert.False(checker.IsPasswordOk("TEST", "", "         "));

            // 小于 6个字符 将检查失败！
            Assert.False(checker.IsPasswordOk("TEST", "", "12345"));

            // 大于 6个字符 将检查通过！
            Assert.True(checker.IsPasswordOk("TEST", "", "123456"));

            // 大于 15个字符，将检查不通过！
            Assert.False(checker.IsPasswordOk("TEST", "", "1234567890123456"));

        }

    }
}
