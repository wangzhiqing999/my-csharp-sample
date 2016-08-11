using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

using System.Diagnostics.Contracts;


// 注意:  本类实用了 https://msdn.microsoft.com/zh-cn/library/system.diagnostics.contracts.contract.aspx
// 这个技术需要下载 二进制重写工具
// https://visualstudiogallery.msdn.microsoft.com/1ec7db13-3363-46c9-851f-1ce455f66970
// 安装过程最好关闭 Visual Studio.

// 安装完毕以后， 需要在 Visual Studio 中， 项目的属性里面， 找到  Code Contracts 选项.
// Assembly Mode 设置为  Standard Contract Requires
// Perform Runtime Contract Check 设置为  Full.



namespace D0001_Matrix.Model
{

    /// <summary>
    /// 矩阵类.
    /// </summary>
    public class Matrix<T> where T : struct
    {

        /// <summary>
        /// 矩阵数组数据.
        /// </summary>
        private T[,] matrixData;


        protected Matrix()
        {
        }


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Matrix(int x, int y) {

            Contract.Requires<ArgumentException >(x > 0, "x");
            Contract.Requires<ArgumentException >(y > 0, "y");

            matrixData = new T[x, y];
        }


        /// <summary>
        /// 索引器.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public virtual T this[int i, int j]
        {
            get
            {
                Contract.Requires<ArgumentException >(i >=0, "i");
                Contract.Requires<ArgumentException >(j >= 0, "j");
                Contract.Requires<ArgumentException >(i < this.X, "i");
                Contract.Requires<ArgumentException >(j < this.Y, "j");

                return matrixData[i, j];
            }
            set
            {
                Contract.Requires<ArgumentException >(i >= 0, "i");
                Contract.Requires<ArgumentException >(j >= 0, "j");
                Contract.Requires<ArgumentException >(i < this.X, "i");
                Contract.Requires<ArgumentException >(j < this.Y, "j");

                matrixData[i, j] = value;
            }
        }



        /// <summary>
        /// X. 也就是 一个矩阵的行数.
        /// </summary>
        public virtual int X
        {
            get
            {
                return this.matrixData.GetUpperBound(0) + 1;
            }
        }


        /// <summary>
        /// Y. 也就是 一个矩阵的列数.
        /// </summary>
        public virtual int Y
        {
            get
            {
                return this.matrixData.GetUpperBound(1) + 1;
            }
        }




        /// <summary>
        /// 是否是对称矩阵.
        /// </summary>
        public bool IsSymmetric
        {
            get
            {
                // 对称矩阵是相对其主对角线（由左上至右下）对称， 即是 ai,j=aj,i。
                if (this.X != this.Y)
                {
                    return false;
                }


                for (int i = 0; i < this.X; i++)
                {
                    for (int j = 0; j < this.Y; j++)
                    {
                        if ((dynamic)this[i, j] != (dynamic)this[j, i])
                        {
                            return false;
                        }
                    }                    
                }

                return true;
            }
        }



        /// <summary>
        /// 转置矩阵.
        /// </summary>
        /// <returns></returns>
        public Matrix<T> Transpose()
        {
            // 把矩阵A的行换成相应的列，得到的新矩阵称为A的转置矩阵.
            Matrix<T> result = new Matrix<T>(this.Y, this.X);


            for (int i = 0; i < this.Y; i++)
            {
                for (int j = 0; j < this.X; j++)
                {
                    result[i, j] = this[j, i];
                }
            }


            return result;
        }




        #region  矩阵与数值的计算.

        /// <summary>
        /// 重载运算符 +
        /// </summary>
        /// <param name="val"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static Matrix<T> operator +(Matrix<T> val, T val2)
        {
            // 矩阵 加 数值.
            Contract.Requires<ArgumentNullException>(val != null, "val");

            // 构造结果类.
            Matrix<T> result = new Matrix<T>(val.X, val.Y);

            // 矩阵相加操作.
            for (int i = 0; i < result.X; i++)
            {
                for (int j = 0; j < result.Y; j++)
                {
                    result[i, j] = (dynamic)val[i, j] + (dynamic)val2;
                }
            }

            // 返回结果.
            return result;
        }



        /// <summary>
        /// 重载运算符 -
        /// </summary>
        /// <param name="val"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static Matrix<T> operator -(Matrix<T> val, T val2)
        {
            // 矩阵 减 数值.
            Contract.Requires<ArgumentNullException>(val != null, "val");

            // 构造结果类.
            Matrix<T> result = new Matrix<T>(val.X, val.Y);

            // 矩阵相加操作.
            for (int i = 0; i < result.X; i++)
            {
                for (int j = 0; j < result.Y; j++)
                {
                    result[i, j] = (dynamic)val[i, j] - (dynamic)val2;
                }
            }

            // 返回结果.
            return result;
        }



        /// <summary>
        /// 重载运算符 *
        /// </summary>
        /// <param name="val"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static Matrix<T> operator *(Matrix<T> val,  T val2)
        {
            // 矩阵 乘  数值..
            Contract.Requires<ArgumentNullException>(val != null, "val");

            // 构造结果类.
            Matrix<T> result = new Matrix<T>(val.X, val.Y);

            // 矩阵相加操作.
            for (int i = 0; i < result.X; i++)
            {
                for (int j = 0; j < result.Y; j++)
                {
                    result[i, j] = (dynamic)val[i, j] * (dynamic)val2;
                }
            }

            // 返回结果.
            return result;
        }





        /// <summary>
        /// 重载运算符 /
        /// </summary>
        /// <param name="val"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static Matrix<T> operator /(Matrix<T> val, T val2)
        {
            // 矩阵 除  数值..
            Contract.Requires<ArgumentNullException>(val != null, "val");

            // 构造结果类.
            Matrix<T> result = new Matrix<T>(val.X, val.Y);

            // 矩阵相加操作.
            for (int i = 0; i < result.X; i++)
            {
                for (int j = 0; j < result.Y; j++)
                {
                    result[i, j] = (dynamic)val[i, j] / (dynamic)val2;
                }
            }

            // 返回结果.
            return result;
        }



        #endregion  矩阵与数值的计算.







        #region  矩阵与矩阵的计算.


        /// <summary>
        /// 重载运算符 &
        /// </summary>
        /// <param name="val"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static Matrix<T> operator &(Matrix<T> val, Matrix<T> val2)
        {
            // 矩阵与操作.
            Contract.Requires<ArgumentNullException>(val != null, "val");
            Contract.Requires<ArgumentNullException>(val2 != null, "val2");

            // 两个矩阵的 x 与 y 要一致.
            Contract.Requires<ArgumentException>(val.X == val2.X, "X");
            Contract.Requires<ArgumentException>(val.Y == val2.Y, "Y");


            // 构造结果类.
            Matrix<T> result = new Matrix<T>(val.X, val.Y);


            // 矩阵 与 操作.
            for (int i = 0; i < result.X; i++)
            {
                for (int j = 0; j < result.Y; j++)
                {
                    result[i, j] = (dynamic)val[i, j] & (dynamic)val2[i, j];
                }
            }

            // 返回结果.
            return result;
        }


        /// <summary>
        /// 重载运算符 |
        /// </summary>
        /// <param name="val"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static Matrix<T> operator |(Matrix<T> val, Matrix<T> val2)
        {
            // 矩阵或操作.
            Contract.Requires<ArgumentNullException>(val != null, "val");
            Contract.Requires<ArgumentNullException>(val2 != null, "val2");

            // 两个矩阵的 x 与 y 要一致.
            Contract.Requires<ArgumentException>(val.X == val2.X, "X");
            Contract.Requires<ArgumentException>(val.Y == val2.Y, "Y");


            // 构造结果类.
            Matrix<T> result = new Matrix<T>(val.X, val.Y);


            // 矩阵 或 操作.
            for (int i = 0; i < result.X; i++)
            {
                for (int j = 0; j < result.Y; j++)
                {
                    result[i, j] = (dynamic)val[i, j] | (dynamic)val2[i, j];
                }
            }

            // 返回结果.
            return result;
        }




        /// <summary>
		/// 重载运算符 +
		/// </summary>
		/// <param name="val"></param>
        /// <param name="val2"></param>
		/// <returns></returns>
        public static Matrix<T> operator +(Matrix<T> val, Matrix<T> val2)
        {
            // 矩阵加法.
            Contract.Requires<ArgumentNullException>(val != null, "val");
            Contract.Requires<ArgumentNullException>(val2 != null, "val2");

            // 两个矩阵的 x 与 y 要一致.
            Contract.Requires<ArgumentException>(val.X == val2.X, "X");
            Contract.Requires<ArgumentException>(val.Y == val2.Y, "Y");


            // 构造结果类.
            Matrix<T> result = new Matrix<T>(val.X, val.Y);


            // 矩阵相加操作.
            for (int i = 0; i < result.X; i++)
            {
                for (int j = 0; j < result.Y; j++)
                {
                    result[i, j] = (dynamic)val[i, j] + (dynamic)val2[i, j];
                }
            }

            // 返回结果.
            return result;
        }



        /// <summary>
        /// 重载运算符 -
        /// </summary>
        /// <param name="val"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static Matrix<T> operator -(Matrix<T> val, Matrix<T> val2)
        {
            // 矩阵减法.
            Contract.Requires<ArgumentNullException>(val != null, "val");
            Contract.Requires<ArgumentNullException>(val2 != null, "val2");

            // 两个矩阵的 x 与 y 要一致.
            Contract.Requires<ArgumentException>(val.X == val2.X, "X");
            Contract.Requires<ArgumentException>(val.Y == val2.Y, "Y");


            // 构造结果类.
            Matrix<T> result = new Matrix<T>(val.X, val.Y);


            // 矩阵相减操作.
            for (int i = 0; i < result.X; i++)
            {
                for (int j = 0; j < result.Y; j++)
                {
                    result[i, j] = (dynamic)val[i, j] - (dynamic)val2[i, j];
                }
            }

            // 返回结果.
            return result;
        }



        /// <summary>
        /// 重载运算符 *
        /// </summary>
        /// <param name="val"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static Matrix<T> operator *(Matrix<T> val, Matrix<T> val2)
        {
            // 矩阵乘法.
            Contract.Requires<ArgumentNullException>(val != null, "val");
            Contract.Requires<ArgumentNullException>(val2 != null, "val2");

            // 只有当矩阵A的列数与矩阵B的行数相等时A×B才有意义。
            Contract.Requires<ArgumentException>(val.Y == val2.X, "val.Y != val2.X");




            // 一个m×n的矩阵a(m,n)左乘一个n×p的矩阵b(n,p)，会得到一个m×p的矩阵c(m,p)。
            // 构造结果类.
            Matrix<T> result = new Matrix<T>(val.X, val2.Y);



            // 其中的第i行第j列位置上的数为 第一个矩阵第i行上的n个数 与 第二个矩阵第j列上的n个数 对应相乘后所得的n个乘积之和。
            for (int i = 0; i < result.X; i++)
            {
                for (int j = 0; j < result.Y; j++)
                {
                    for (int k = 0; k < val.Y; k++)
                    {
                        result[i, j] += (dynamic)val[i, k] * (dynamic)val2[k, j];
                    }
                }
            }

            // 返回结果.
            return result;
        }


        #endregion  矩阵与矩阵的计算.










        public override bool Equals(object obj)
        {
            if (!(obj is Matrix<T>))
            {
                // 数据类型不一致.
                return false;
            }

            Matrix<T> otherMatrix = obj as Matrix<T>;

            if (this.X != otherMatrix.X)
            {
                // 行数不同.
                return false;
            }
            if (this.Y != otherMatrix.Y)
            {
                // 列数不同.
                return false;
            }

            for (int i = 0; i < this.X; i++)
            {
                for (int j = 0; j < this.Y; j++)
                {
                    if ((dynamic)this[i, j] != (dynamic)otherMatrix[i, j])
                    {
                        // 指定行列不同.
                        return false;
                    }
                }
            }

            // 如果能执行到这里，那么认为是一致.
            return true;
        }







        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            for (int i = 0; i < this.X; i++)
            {
                for (int j = 0; j < this.Y; j++)
                {
                    buff.AppendFormat("{0,4}", this[i,j]);
                }
                buff.AppendLine();
            }

            return buff.ToString();
        }






    }

}
