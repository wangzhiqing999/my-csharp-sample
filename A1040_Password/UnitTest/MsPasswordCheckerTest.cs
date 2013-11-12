using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using NUnit.Framework;


using A1040_Password.ConcreteHandler;


namespace A1040_Password.UnitTest
{

    /// <summary>
    /// 基于微软的 密码复杂度检查.
    /// </summary>
    [TestFixture]
    public class MsPasswordCheckerTest
    {

        [Test]
        [Category("综合测试")]
        public void TestPasswordCheck()
        {
            MsPasswordChecker checker = new MsPasswordChecker();

            // 为 null 将检查失败！
            Assert.False(checker.IsPasswordOk("EDWARD", "", null));

            // 空字符 将检查失败！
            Assert.False(checker.IsPasswordOk("EDWARD", "", ""));

            // 纯空白字符 将检查失败！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "         "));

            // 小于 6个字符 将检查失败！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "1Aa#"));

            // 大于 15个字符，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "12345ABCDEabcdefg"));



            // 密码中 包含  用户名的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "EdwardTest123"));
            Assert.False(checker.IsPasswordOk("EDWARD", "", "TestEdward123"));


            // ==================================================
            // 只包含 四类字符中的一类的情况.
            // ==================================================

            // 密码中仅仅包含数字的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "12345678"));

            // 密码中仅仅包含小写字母的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "abcdefg"));

            // 密码中仅仅包含大写字母的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "ABCDEFG"));

            // 密码中仅仅包含符号的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "~!@#$%^&"));



            // ==================================================
            // 只包含 四类字符中的两类的情况. 
            // ==================================================

            // 密码中仅仅包含数字 + 小写 的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "12345abcde"));

            // 密码中仅仅包含数字 + 大写 的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "12345ABCDE"));

            // 密码中仅仅包含数字 + 符号 的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "12345+_)(*"));

            // 密码中仅仅包含小写 + 大写 的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "abcdeABCDE"));

            // 密码中仅仅包含小写 + 符号 的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "abcde!@#$%"));

            // 密码中仅仅包含 大写 + 符号 的，将检查不通过！
            Assert.False(checker.IsPasswordOk("EDWARD", "", "ABCDE!@#$%"));


            // ==================================================
            // 包含 四类字符中的三类的情况. 
            // ==================================================

            // 密码中包含数字 + 小写 + 大写 的，将检查通过！
            Assert.True(checker.IsPasswordOk("EDWARD", "", "123abcABC"));

            // 密码中包含数字 + 小写 + 符号 的，将检查通过！
            Assert.True(checker.IsPasswordOk("EDWARD", "", "123abc#$%"));

            // 密码中包含数字 + 大写 + 符号  的，将检查通过！
            Assert.True(checker.IsPasswordOk("EDWARD", "", "123ABC#$%"));

            // 密码中包含小写 + 大写 + 符号  的，将检查通过！
            Assert.True(checker.IsPasswordOk("EDWARD", "", "abcABC#$%"));

            // ==================================================
            // 包含 四类字符中的四类的情况. 
            // ==================================================

            // 密码中包含数字 + 小写 + 大写 + 符号  的，将检查通过！
            Assert.True(checker.IsPasswordOk("EDWARD", "", "123abcABC#$%"));
        }

    }


}
