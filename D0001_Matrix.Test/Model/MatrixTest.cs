using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;


namespace D0001_Matrix.Model
{

    [TestFixture]
    public class MatrixTest
    {


        /// <summary>
        /// 构造一个用于测试的矩阵.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected virtual Matrix<int> CreateNewTestMatrix(int x, int y)
        {
            return new Matrix<int>(x, y);
        }



        
        /// <summary>
        /// 基本 Setter/Getter 属性测试.
        /// </summary>
        [Test]
        public void BaseSetGetTest()
        {

            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val1[i, j] = i * 10 + j;
                }
            }



            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    Assert.AreEqual(i * 10 + j, val1[i, j]);
                }
            }
        }




        /// <summary>
        /// 对称矩阵测试.
        /// </summary>
        [Test]
        public void IsSymmetricTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            val1[0, 0] = 3;
            val1[0, 3] = 7;
            val1[1, 3] = -1;
            val1[2, 1] = 2;
            bool isSymmetric = val1.IsSymmetric;
            // 非对称.
            Assert.IsFalse(isSymmetric);



            Matrix<Int32> val2 = new Matrix<int>(4, 4);
            val2[0, 3] = 7;
            val2[3, 0] = 7;
            isSymmetric = val2.IsSymmetric;
            // 对称.
            Assert.IsTrue(isSymmetric);



            Matrix<Int32> val3 = new Matrix<int>(4, 4);
            val3[0, 3] = 7;
            val3[3, 0] = 6;
            isSymmetric = val3.IsSymmetric;
            // 非对称.
            Assert.IsFalse(isSymmetric);
        }



        /// <summary>
        /// 转置矩阵测试.
        /// </summary>
        [Test]
        public void TransposeTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val1[i, j] = i * 10 + j;
                }
            }


            // 转置.
            Matrix<Int32> val2 = val1.Transpose();

            // 原始矩阵 3行 4列
            // 转置后 4行 3列.
            Assert.AreEqual(4, val2.X);
            Assert.AreEqual(3, val2.Y);

            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    Assert.AreEqual(i * 10 + j, val2[j, i]);
                }
            }

        }





        #region  矩阵与数值的计算测试.



        /// <summary>
        /// 矩阵 与 数值相加 测试.
        /// </summary>
        [Test]
        public void AddValTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val1[i, j] = i * 10 + j;
                }
            }


            // 矩阵 + 数值.
            Matrix<Int32> val2 = val1 + 1024;

            // 结果非空.
            Assert.IsNotNull(val2);

            // X.
            Assert.AreEqual(3, val2.X);
            // Y.
            Assert.AreEqual(4, val2.Y);


            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    Assert.AreEqual(1024, val2[i, j] - val1[i, j]);
                }
            }
        }


        /// <summary>
        /// 矩阵 与 数值相减 测试.
        /// </summary>
        [Test]
        public void SubValTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val1[i, j] = i * 10 + j;
                }
            }


            // 矩阵 - 数值.
            Matrix<Int32> val2 = val1 - 1024;

            // 结果非空.
            Assert.IsNotNull(val2);

            // X.
            Assert.AreEqual(3, val2.X);
            // Y.
            Assert.AreEqual(4, val2.Y);


            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    Assert.AreEqual(-1024, val2[i, j] - val1[i, j]);
                }
            }
        }



        /// <summary>
        /// 矩阵 与 数值相乘 测试.
        /// </summary>
        [Test]
        public void MulValTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val1[i, j] = i * 10 + j;
                }
            }


            // 矩阵 * 数值.
            Matrix<Int32> val2 = val1 * 16;

            // 结果非空.
            Assert.IsNotNull(val2);

            // X.
            Assert.AreEqual(3, val2.X);
            // Y.
            Assert.AreEqual(4, val2.Y);


            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    if (val1[i, j] != 0)
                    {
                        Assert.AreEqual(16, val2[i, j] / val1[i, j]);
                    }
                }
            }
        }




        /// <summary>
        /// 矩阵 与 数值相除 测试.
        /// </summary>
        [Test]
        public void DivValTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val1[i, j] = (i * 10 + j) * 16;
                }
            }


            // 矩阵 / 数值.
            Matrix<Int32> val2 = val1 / 8;

            // 结果非空.
            Assert.IsNotNull(val2);

            // X.
            Assert.AreEqual(3, val2.X);
            // Y.
            Assert.AreEqual(4, val2.Y);


            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    if (val2[i, j] != 0)
                    {
                        Assert.AreEqual(8, val1[i, j] / val2[i, j]);
                    }
                }
            }
        }








        #endregion  矩阵与数值的计算测试.







        #region 矩阵与矩阵的计算测试.



        /// <summary>
        /// 矩阵 与 测试.
        /// </summary>
        [Test]
        public void AndTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 3);
            for (int i = 0; i < val1.X; i++)
            {
                val1[i, i] = 1;
            }
            // 1  0  0
            // 0  1  0
            // 0  0  1

            Matrix<Int32> val2 = CreateNewTestMatrix(3, 3);
            for (int i = 0; i < val2.X; i++)
            {
                val2[i, 2 - i] = 1;
            }
            // 0  0  1
            // 0  1  0
            // 1  0  0



            // 1  0  0        0  0  1      0  0  0
            // 0  1  0   &    0  1  0   =  0  1  0 
            // 0  0  1        1  0  0      0  0  0
            Matrix<Int32> val3 = val1 & val2;

            // 结果非空.
            Assert.IsNotNull(val3);

            // X.
            Assert.AreEqual(3, val3.X);
            // Y.
            Assert.AreEqual(3, val3.Y);


            // 与的数据核对.
            Assert.AreEqual(0, val3[0, 0]);
            Assert.AreEqual(0, val3[0, 1]);
            Assert.AreEqual(0, val3[0, 2]);

            Assert.AreEqual(0, val3[1, 0]);
            Assert.AreEqual(1, val3[1, 1]);
            Assert.AreEqual(0, val3[1, 2]);

            Assert.AreEqual(0, val3[2, 0]);
            Assert.AreEqual(0, val3[2, 1]);
            Assert.AreEqual(0, val3[2, 2]);

        }



        /// <summary>
        /// 矩阵 或 测试.
        /// </summary>
        [Test]
        public void OrTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 3);
            for (int i = 0; i < val1.X; i++)
            {
                val1[i, i] = 1;
            }
            // 1  0  0
            // 0  1  0
            // 0  0  1

            Matrix<Int32> val2 = CreateNewTestMatrix(3, 3);
            for (int i = 0; i < val2.X; i++)
            {
                val2[i, 2 - i] = 1;
            }
            // 0  0  1
            // 0  1  0
            // 1  0  0



            // 1  0  0        0  0  1      1  0  1
            // 0  1  0   |    0  1  0   =  0  1  0 
            // 0  0  1        1  0  0      1  0  1
            Matrix<Int32> val3 = val1 | val2;

            // 结果非空.
            Assert.IsNotNull(val3);

            // X.
            Assert.AreEqual(3, val3.X);
            // Y.
            Assert.AreEqual(3, val3.Y);


            // 或的数据核对.
            Assert.AreEqual(1, val3[0, 0]);
            Assert.AreEqual(0, val3[0, 1]);
            Assert.AreEqual(1, val3[0, 2]);

            Assert.AreEqual(0, val3[1, 0]);
            Assert.AreEqual(1, val3[1, 1]);
            Assert.AreEqual(0, val3[1, 2]);

            Assert.AreEqual(1, val3[2, 0]);
            Assert.AreEqual(0, val3[2, 1]);
            Assert.AreEqual(1, val3[2, 2]);

        }






        /// <summary>
        /// 矩阵相加测试.
        /// </summary>
        [Test]
        public void AddTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val1[i, j] = i * 10 + j;
                }
            }


            Matrix<Int32> val2 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val2[i, j] = i + j * 10;
                }
            }


            Matrix<Int32> val3 = val1 + val2;

            // 结果非空.
            Assert.IsNotNull(val3);

            // X.
            Assert.AreEqual(3, val3.X);
            // Y.
            Assert.AreEqual(4, val3.Y);

            // 相加的数据核对.
            for (int i = 0; i < val3.X; i++)
            {
                for (int j = 0; j < val3.Y; j++)
                {
                    Assert.AreEqual((i + j) * 11, val3[i,j]);
                }
            }

        }





        /// <summary>
        /// 矩阵相减测试.
        /// </summary>
        [Test]
        public void SubTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val1[i, j] = i * 10 + j;
                }
            }


            Matrix<Int32> val2 = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < val1.X; i++)
            {
                for (int j = 0; j < val1.Y; j++)
                {
                    val2[i, j] = i + j * 10;
                }
            }


            Matrix<Int32> val3 = val1 - val2;

            // 结果非空.
            Assert.IsNotNull(val3);

            // X.
            Assert.AreEqual(3, val3.X);
            // Y.
            Assert.AreEqual(4, val3.Y);

            // 相加的数据核对.
            for (int i = 0; i < val3.X; i++)
            {
                for (int j = 0; j < val3.Y; j++)
                {
                    Assert.AreEqual( (i - j) * 9, val3[i, j]);
                }
            }

        }





        /// <summary>
        /// 矩阵相乘测试.
        /// </summary>
        [Test]
        public void MulTest()
        {
            Matrix<Int32> val1 = CreateNewTestMatrix(3, 4);
            val1[0, 0] = 3;
            val1[0, 3] = 7;
            val1[1, 3] = -1;
            val1[2, 1] = 2;


            Matrix<Int32> val2 = CreateNewTestMatrix(4, 2);
            val2[0, 0] = 4;
            val2[0, 1] = 1;
            val2[2, 0] = 1;
            val2[2, 1] = -1;
            val2[3, 1] = 2;


            Matrix<Int32> val3 = val1 * val2;

            // 结果非空.
            Assert.IsNotNull(val3);

            // X.
            Assert.AreEqual(3, val3.X);
            // Y.
            Assert.AreEqual(2, val3.Y);


            Assert.AreEqual(12, val3[0, 0]);
            Assert.AreEqual(17, val3[0, 1]);

            Assert.AreEqual(0, val3[1, 0]);
            Assert.AreEqual(-2, val3[1, 1]);

            Assert.AreEqual(0, val3[2, 0]);
            Assert.AreEqual(0, val3[2, 1]);
        }




        #endregion 矩阵与矩阵的计算测试.






        /// <summary>
        /// 公式验证.
        /// (A±B)'=A'±B'
        /// 
        /// 本方法测试 +
        /// </summary>
        [Test]
        public void Func1Test()
        {

            // (A±B)'=A'±B'
            Matrix<Int32> a = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < a.X; i++)
            {
                for (int j = 0; j < a.Y; j++)
                {
                    a[i, j] = i * 10 + j;
                }
            }


            Matrix<Int32> b = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < b.X; i++)
            {
                for (int j = 0; j < b.Y; j++)
                {
                    b[i, j] = i + j * 10;
                }
            }


            Matrix<Int32> aT = a.Transpose();
            Matrix<Int32> bT = b.Transpose();



            // c = (a+b)
            Matrix<Int32> c = a + b;
            // cT = (a+b)T
            Matrix<Int32> cT = c.Transpose();



            Matrix<Int32> aTbT = aT + bT;


            // (A±B)'=A'±B'
            Assert.IsTrue(cT.Equals(aTbT));


        }



        /// <summary>
        /// 公式验证.
        /// (A±B)'=A'±B'
        /// 
        ///  本方法测试 -
        /// </summary>
        [Test]
        public void Func2Test()
        {

            // (A±B)'=A'±B'
            Matrix<Int32> a = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < a.X; i++)
            {
                for (int j = 0; j < a.Y; j++)
                {
                    a[i, j] = i * 10 + j;
                }
            }


            Matrix<Int32> b = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < b.X; i++)
            {
                for (int j = 0; j < b.Y; j++)
                {
                    b[i, j] = i + j * 10;
                }
            }


            Matrix<Int32> aT = a.Transpose();
            Matrix<Int32> bT = b.Transpose();



            // c = (a-b)
            Matrix<Int32> c = a - b;
            // cT = (a-b)T
            Matrix<Int32> cT = c.Transpose();



            Matrix<Int32> aTbT = aT - bT;


            // (A±B)'=A'±B'
            Assert.IsTrue(cT.Equals(aTbT));
        }






        /// <summary>
        /// 公式验证
        /// (A×B)'= B'×A'
        /// </summary>
        [Test]
        public void Func3Test()
        {
            // (A×B)'= B'×A'
            Matrix<Int32> a = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < a.X; i++)
            {
                for (int j = 0; j < a.Y; j++)
                {
                    a[i, j] = i * 10 + j;
                }
            }


            Matrix<Int32> b = CreateNewTestMatrix(4, 5);
            for (int i = 0; i < b.X; i++)
            {
                for (int j = 0; j < b.Y; j++)
                {
                    b[i, j] = i + j * 10;
                }
            }



            Matrix<Int32> aT = a.Transpose();
            Matrix<Int32> bT = b.Transpose();



            // c = (a*b)
            Matrix<Int32> c = a * b;
            // cT = (a*b)T
            Matrix<Int32> cT = c.Transpose();



            Matrix<Int32> bTaT = bT * aT;


            // (A±B)'=A'±B'
            Assert.IsTrue(cT.Equals(bTaT));
        }


		
		
		
        /// <summary>
        /// 公式验证
        /// 结合律 (A×B)×C = A×(B×C)
        /// </summary>
        [Test]
        public void Func4Test()
		{
            Matrix<Int32> a = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < a.X; i++)
            {
                for (int j = 0; j < a.Y; j++)
                {
                    a[i, j] = i * 10 + j;
                }
            }


            Matrix<Int32> b = CreateNewTestMatrix(4, 5);
            for (int i = 0; i < b.X; i++)
            {
                for (int j = 0; j < b.Y; j++)
                {
                    b[i, j] = i + j * 10;
                }
            }


            Matrix<Int32> c = CreateNewTestMatrix(5, 4);
            for (int i = 0; i < c.X; i++)
            {
                for (int j = 0; j < c.Y; j++)
                {
                    c[i, j] = i + j * 10;
                }
            }


            Matrix<Int32> abc = (a * b) * c;

            Matrix<Int32> abc2 = a * (b * c);


            // 结果非空.
            Assert.IsNotNull(abc);
            Assert.IsNotNull(abc2);


            // 一致.
            Assert.IsTrue(abc.Equals(abc2));
		}
		
		



        /// <summary>
        /// 公式验证
        /// 左分配律 A×(B+C) = A×B + A×C
        /// </summary>
        [Test]
        public void Func5Test()
		{
            Matrix<Int32> a = CreateNewTestMatrix(3, 4);
            for (int i = 0; i < a.X; i++)
            {
                for (int j = 0; j < a.Y; j++)
                {
                    a[i, j] = i * 10 + j;
                }
            }


            Matrix<Int32> b = CreateNewTestMatrix(4, 5);
            for (int i = 0; i < b.X; i++)
            {
                for (int j = 0; j < b.Y; j++)
                {
                    b[i, j] = i + j * 10;
                }
            }


            Matrix<Int32> c = CreateNewTestMatrix(4, 5);
            for (int i = 0; i < c.X; i++)
            {
                for (int j = 0; j < c.Y; j++)
                {
                    c[i, j] = i * 2 + j * 3;
                }
            }


            Matrix<Int32> abc = a * (b + c);
            Matrix<Int32> abc2 = a * b  + a * c;


            // 结果非空.
            Assert.IsNotNull(abc);
            Assert.IsNotNull(abc2);


            // 一致.
            Assert.IsTrue(abc.Equals(abc2));

		}
		


		
        /// <summary>
        /// 公式验证
        /// 右分配律 (A+B)×C = A×C + B×C
        /// </summary>
        [Test]
        public void Func6Test()
		{

            Matrix<Int32> a = CreateNewTestMatrix(4, 5);
            for (int i = 0; i < a.X; i++)
            {
                for (int j = 0; j < a.Y; j++)
                {
                    a[i, j] = i * 10 + j;
                }
            }


            Matrix<Int32> b = CreateNewTestMatrix(4, 5);
            for (int i = 0; i < b.X; i++)
            {
                for (int j = 0; j < b.Y; j++)
                {
                    b[i, j] = i + j * 10;
                }
            }


            Matrix<Int32> c = CreateNewTestMatrix(5, 4);
            for (int i = 0; i < c.X; i++)
            {
                for (int j = 0; j < c.Y; j++)
                {
                    c[i, j] = i * 2 + j * 3;
                }
            }


            Matrix<Int32> abc = (a + b) * c;
            Matrix<Int32> abc2 = a * c + b * c;


            // 结果非空.
            Assert.IsNotNull(abc);
            Assert.IsNotNull(abc2);


            // 一致.
            Assert.IsTrue(abc.Equals(abc2));

		}		
		
		


    }

}
