using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


using A0015_OverloadOperator.Sample;



namespace A0015_OverloadOperator.Test
{



    /// <summary>
    /// TestFixture 表明这个类，是一个测试类.
    /// </summary>
    [TestFixture]
    public class MySequenceTest
    {

        /// <summary>
        /// 测试用 最小序列号.
        /// </summary>
        private MySequence minSequenct;

        /// <summary>
        /// 测试用 最大序列号.
        /// </summary>
        private MySequence maxSequenct;


        /// <summary>
        /// 测试用 序列号.
        /// </summary>
        MySequence sequence;



        /*
        TestFixtureSetup：在当前测试类中的所有测试函数运行前调用；
        TestFixtureTearDown：在当前测试类的所有测试函数运行完毕后调用；

        例如测试项目是要访问数据库/文件/网络端口的
        那么可以在 TestFixtureSetup 那里打开数据库/文件/网络端口
        并在 TestFixtureTearDown 那里关闭数据库/文件/网络端口
        */


        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            // TestFixtureSetUp 意味着整个测试过程，本方法只执行一次.

            // 初始化最小序列号
            minSequenct = new MySequence('0', 1);

            // 初始化最大序列号
            maxSequenct = new MySequence('Z', 99);
        }



        /*
        Setup：在当前测试类的每一个测试函数运行前调用；
        TearDown：在当前测试类的每一个测试函数运行后调用。
        */

        [SetUp]
        public void Setup()
        {
            // SetUp 意味着整个测试过程，对于每一个 Test 本方法都要执行一次。

            // 默认使用初始序列号.
            sequence = new MySequence();
        }



        /*
        Test 表示这个方法是一个测试方法 (必须的)
        Category 表示 这个测试方法的 分类 (可选的)
         */

        [Test]
        [Category("初始化")]
        public void NewSequenct()
        {
            // 首先测试默认的构造函数. 结果应当等价于 001。
            Assert.AreEqual("001", sequence.ToString());

            // 再测试 几种不同的构造函数的方式，能否得出相同的序列号.
            sequence = new MySequence('0', 1);
            Assert.AreEqual("001", sequence.ToString());
        }


        /*
        ExpectedException 表明本测试将抛出异常.
        */


        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewSequenctArgument0()
        {
            MySequence sequence = new MySequence(null);

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }


        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentException))]
        public void NewSequenctArgument1()
        {
            MySequence sequence = new MySequence("");

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }


        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentException))]
        public void NewSequenctArgument2()
        {
            MySequence sequence = new MySequence("1");

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }

        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentException))]
        public void NewSequenctArgument3()
        {
            MySequence sequence = new MySequence("12");

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }

        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentException))]
        public void NewSequenctArgument4()
        {
            MySequence sequence = new MySequence("1234");

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }

        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentException))]
        public void NewSequenctArgument5()
        {
            // 字母 O 开头的，不允许.
            MySequence sequence = new MySequence("O12");

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }

        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentException))]
        public void NewSequenctArgument6()
        {
            MySequence sequence = new MySequence("AB0");

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }

        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentException))]
        public void NewSequenctArgument7()
        {
            // 字母 O 开头的，不允许.
            MySequence sequence = new MySequence('O', 0);

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }

        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentException))]
        public void NewSequenctArgument8()
        {
            // 后面数字大于99的.
            MySequence sequence = new MySequence('A', 100);

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }

        [Test]
        [Category("初始化")]
        [ExpectedException(typeof(ArgumentException))]
        public void NewSequenctArgument9()
        {
            // 后面数字小于零的.
            MySequence sequence = new MySequence('A', -1);

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }



        /*
        Ignore 表示 这个测试方法是暂时不测试的。 (可选的)
         */


        [Test]
        [Category("类型转换")]
        [Ignore("还没写完，暂时不测试处理！")]
        public void TryParse()
        {
            // 测试 TryParse 的正确性.
            bool tyrResult = MySequence.TryParse("", out sequence);
            // 空白字符串. TryParse 结果应该 无效.
            Assert.IsFalse(tyrResult);


            // 测试 TryParse 的正确性.
            tyrResult = MySequence.TryParse("1", out sequence);
            // 长度为1的字符串. TryParse 结果应该 无效.
            Assert.IsFalse(tyrResult);

            // TODO
            // 需要 TryParse 的可能性太多
            // 传入的参数，与返回结果，放在一个 Access 或者 Excel 表格里面处理更好一些.

        }



        [Test]
        [Category("数学计算")]
        public void PlusPlus()
        {
            // 001++ = 002
            sequence++;
            // 001++ 后，结果为 002
            Assert.AreEqual("002", sequence.ToString());

            // 测试 999++ = A00
            sequence = new MySequence("999");
            sequence++;
            Assert.AreEqual("A00", sequence.ToString());

            // 测试 N99++ = P00 ( 因为字母 O 被排除掉了)
            sequence = new MySequence("N99");
            sequence++;
            Assert.AreEqual("P00", sequence.ToString());

        }



        /*
         ExpectedException 表明本测试将抛出异常.
         */

        [Test]
        [Category("数学计算")]
        [ExpectedException(typeof(OverflowException))]
        public void PlusPlusOverflow()
        {
            // Z99++ 溢出.
            sequence = new MySequence("Z99");
            sequence++;

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }



        [Test]
        [Category("数学计算")]
        public void MinusMinus()
        {
            // Z99-- = Z98
            sequence = new MySequence("Z99");
            sequence--;
            Assert.AreEqual("Z98", sequence.ToString());

            // P00-- = N99 ( 因为字母 O 被排除掉了)
            sequence = new MySequence("P00");
            sequence--;
            Assert.AreEqual("N99", sequence.ToString());

            // 001-- = 000
            sequence = new MySequence("001");
            sequence--;
            Assert.AreEqual("000", sequence.ToString());

        }

        [Test]
        [Category("数学计算")]
        [ExpectedException(typeof(OverflowException))]
        public void MinusMinusOverflow()
        {
            // 000-- 溢出.
            sequence = new MySequence("000");
            sequence--;

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }





        [Test]
        [Category("数学计算")]
        public void Plus()
        {
            // 001 + 100 = 101
            sequence = new MySequence("001");
            sequence = sequence + 100;
            Assert.AreEqual("101", sequence.ToString());


            // A01 + 200 = C01
            sequence = new MySequence("A01");
            sequence = sequence + 200;
            Assert.AreEqual("C01", sequence.ToString());


            // N01 + 123 = P24
            sequence = new MySequence("N01");
            sequence = sequence + 123;
            Assert.AreEqual("P24", sequence.ToString());
        }


        [Test]
        [Category("数学计算")]
        [ExpectedException(typeof(OverflowException))]
        public void PlusOverflow()
        {
            // Z98 + 2 溢出.
            sequence = new MySequence("Z99");
            sequence = sequence + 2;

            // 由于上面的代码发生了异常，下面这句应该执行不到。
            Assert.Fail("本测试应该触发一个异常。");
        }



        /*
         Explicit 表示，不会在全部测试中，自动执行这个测试操作
         该测试操作需要手动指定，是否进行测试操作。
         这个特性主要用于：
           当某些非常耗时的测试单元，在开发过程中，不希望被频繁的执行。
           仅仅当最后整体单元测试的时候，统一的测试执行。也就是很多耗时的测试，一起执行了。

         Explicit 与 Ignore 的区别在于：
           Explicit 只是在默认全局测试的情况下，暂时不执行，可以通过设置 Category ， 指定其进行测试。
           Ignore 是不管怎样，都不执行那个测试方法了。(相当于一个 TODO 的功能，要去修改好测试代码后，删除 Ignore 标记。 )
        */

        [Test, Explicit]
        [Category("长时间测试操作")]
        public void PlusAndPlusPlus()
        {
            sequence = new MySequence("000");
            MySequence seq2 = new MySequence("000");

            // 遍历，确保每一个 ++ 操作的结果， 与 +1 的结果是一致的.
            while (sequence != maxSequenct)
            {
                sequence++;
                seq2 = seq2 + 1;

                Assert.AreEqual(sequence, seq2);
            }
        }






    }


}
