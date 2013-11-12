using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0016_IMPLICIT_EXPLICIT.Sample
{

    /// <summary>
    /// 本类没有什么实际意义.
    /// 仅仅用于 测试 implicit 与 explicit 关键字的使用.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyList<T>
    {
        /// <summary>
        /// 内部列表.
        /// </summary>
        private List<T> dataList = new List<T>();

        /// <summary>
        /// 新增项目.
        /// </summary>
        /// <param name="t"></param>
        public void Add(T t)
        {
            this.dataList.Add(t);
        }

        /// <summary>
        /// 获取项目.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            return this.dataList[index];
        }



        #region 使用 explicit 实现显式的用户定义类型转换


        /// <summary>
        /// 显式的用户定义类型转换
        /// 这里是将 MyList<T>  显式装换为  T[]
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static explicit operator T[](MyList<T> d)
        {
            return d.dataList.ToArray();
        }


        /// <summary>
        /// 显式的用户定义类型转换
        /// 这里是将 T[]  显式装换为  MyList<T> 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static implicit operator MyList<T>(T[] d)
        {
            MyList<T> result = new MyList<T>();
            result.dataList.AddRange(d);
            return result;
        }

        #endregion 使用 explicit 实现显的用户定义类型转换





        #region 使用 implicit 实现 隐式的用户定义类型转换


        /// <summary>
        /// 隐式的用户定义类型转换
        /// 这里是将 MyList<T>  隐式装换为  List<T> 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static implicit operator List<T>(MyList<T> d)
        {
            return d.dataList.ToList();
        }

        /// <summary>
        /// 隐式的用户定义类型转换
        /// 这里是将 List<T>  隐式装换为  MyList<T> 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static implicit operator MyList<T>(List<T> d)
        {
            MyList<T> result = new MyList<T>();
            result.dataList.AddRange(d);
            return result;
        }


        #endregion




        #region 为了验证 数据转换的结果，重载操作符.

        /// <summary>
        /// 重载 == 操作符. 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator ==(MyList<T> m1, List<T> m2)
        {
            if (m1.dataList.Count != m2.Count)
            {
                // 长度不相等，直接忽略.
                return false;
            }
            for (int i = 0; i < m2.Count; i++)
            {
                if (!m1.dataList[i].Equals(m2[i]))
                {
                    // 只要列表中有一个不同， 就认为不同.
                    return false;
                }
            }
            // 长度相同，并且每一个元素都相等的情况下，才认为相等.
            return true;
        }

        /// <summary>
        /// 重载 != 操作符. 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator !=(MyList<T> m1, List<T> m2)
        {
            return !(m1 == m2);
        }


        /// <summary>
        /// 重载 == 操作符. 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator ==(MyList<T> m1, T[] m2)
        {
            if (m1.dataList.Count != m2.Length)
            {
                // 长度不相等，直接忽略.
                return false;
            }
            for (int i = 0; i < m2.Length; i++)
            {
                if (!m1.dataList[i].Equals(m2[i]))
                {
                    // 只要列表中有一个不同， 就认为不同.
                    return false;
                }
            }
            // 长度相同，并且每一个元素都相等的情况下，才认为相等.
            return true;
        }


        /// <summary>
        /// 重载 != 操作符. 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static bool operator !=(MyList<T> m1, T[] m2)
        {
            return !(m1 == m2);
        }

        #endregion

    }


}
