using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D0001_Matrix.Model
{


    /// <summary>
    /// 稀疏矩阵.
    /// </summary>
    public class SparseMatrix<T> : Matrix<T> where T : struct
    {
        /// <summary>
        /// 稀疏矩阵数据.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class SparseData<T2>
        {
            /// <summary>
            /// 行.
            /// </summary>
            public int X { set; get; }

            /// <summary>
            /// 列.
            /// </summary>
            public int Y { set; get; }

            /// <summary>
            /// 数值.
            /// </summary>
            public T2 Data { set; get; }


            public override string ToString()
            {
                return String.Format("[{0}, {1}] = {2}", this.X, this.Y, this.Data);
            }
        }


        /// <summary>
        /// 稀疏矩阵数据列表.
        /// </summary>
        private List<SparseData<T>> matrixDataList;


        /// <summary>
        /// 矩阵行数.
        /// </summary>
        private int x;

        /// <summary>
        /// 矩阵列数.
        /// </summary>
        private int y;


        /// <summary>
        /// 矩阵行数.
        /// </summary>
        public override int X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// 矩阵列数.
        /// </summary>
        public override int Y
        {
            get
            {
                return this.y;
            }
        }



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public SparseMatrix(int x, int y)
        {
            // 设置行列.
            this.x = x;
            this.y = y;

            // 初始化数据列表.
            this.matrixDataList = new List<SparseData<T>>();
        }



        /// <summary>
        /// 索引器.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public override T this[int i, int j]
        {
            get
            {
                var item = this.matrixDataList.Where(p => p.X == i && p.Y == j).FirstOrDefault();
                if (item == null)
                {
                    // 指定位置无数据.
                    return default(T);
                }

                return item.Data;
            }
            set
            {
                // 初始值.
                dynamic zeroValue = default(T);

                if (zeroValue == value)
                {
                    // 设置的是初始值.
                    // 那么， 如果有数据则删除.
                    // 无数据则忽略.

                    var item = this.matrixDataList.Where(p => p.X == i && p.Y == j).FirstOrDefault();

                    if (item != null)
                    {
                        // 有数据则删除。
                        this.matrixDataList.Remove(item);
                    }
                }
                else
                {
                    var item = this.matrixDataList.Where(p => p.X == i && p.Y == j).FirstOrDefault();
                    if (item == null)
                    {
                        // 指定位置无数据，新增.
                        item = new SparseData<T>
                        {
                            X = i,
                            Y = j,
                            Data = value
                        };
                        this.matrixDataList.Add(item);
                    }
                    else
                    {
                        // 数据已存在. 更新.
                        item.Data = value;
                    }
                }
            }
        }




        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("稀疏矩阵：({0}, {1})", this.x, this.y);
            buff.AppendLine();

            foreach (var item in this.matrixDataList)
            {
                buff.AppendLine(item.ToString());
            }

            return buff.ToString();
        }


    }



}
