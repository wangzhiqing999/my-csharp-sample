using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0017_RandomCode.Sample
{


    /// <summary>
    /// 随机码生成器.
    /// 
    /// 
    /// 这个类用于 内存中, 一次性生成一批的 随机代码.
    /// 
    /// </summary>
    public class RandomCodeCreater
    {


        /// <summary>
        /// 数字的 可用字符数组.
        /// </summary>
        private static char[] numberCodeUseAbleCharArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        /// <summary>
        /// 大写字母的  可用字符数组.
        /// 
        /// 由于 数字 0 与 字母 O 比较难区分
        /// 因此字母 O 从可用字符中排除.
        /// </summary>
        private static char[] upperCodeUseAbleCharArray = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
												'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U',
												'V', 'W', 'X', 'Y', 'Z'};


        /// <summary>
        /// 小写字母的  可用字符数组.
        /// 
        /// 由于 数字 1 与 字母 l 比较难区分
        /// 因此字母 l 从可用字符中排除.
        /// </summary>
        private static char[] lowerCodeUseAbleCharArray = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
												'k', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
												'v', 'w', 'x', 'y', 'z'};



        /// <summary>
        /// 可用字符列表.
        /// </summary>
        private List<char> baseCodeUseAbleCharList = new List<char>();



        /// <summary>
        /// 随机码使用哪些字符.
        /// </summary>
        public enum CodeUseCharType
        {
            /// <summary>
            /// 使用数字.
            /// </summary>
            NumberCode = 1,

            /// <summary>
            /// 使用 大写字母.
            /// </summary>
            UpperCode = 2,

            /// <summary>
            /// 使用小写字母.
            /// </summary>
            LowerCode = 4,
        }



        /// <summary>
        /// 代码使用哪些字符
        /// </summary>
        private CodeUseCharType m_CodeCharType;


        /// <summary>
        /// 代码使用哪些字符
        /// </summary>
        public CodeUseCharType CodeCharType 
        {
            set
            {
                m_CodeCharType = value;

                // 先清除所有可用数据.
                baseCodeUseAbleCharList.Clear();


                if ((m_CodeCharType & CodeUseCharType.NumberCode) > 0)
                {
                    // 字符包含 数字.
                    baseCodeUseAbleCharList.AddRange(numberCodeUseAbleCharArray);
                }

                if ((m_CodeCharType & CodeUseCharType.UpperCode) > 0)
                {
                    // 字符包含 大写字母.
                    baseCodeUseAbleCharList.AddRange(upperCodeUseAbleCharArray);
                }

                if ((m_CodeCharType & CodeUseCharType.LowerCode) > 0)
                {
                    // 字符包含 小写字母.
                    baseCodeUseAbleCharList.AddRange(lowerCodeUseAbleCharArray);
                }

            }

            get
            {
                return m_CodeCharType;
            }
        }








        /// <summary>
        /// 生成代码的长度.
        /// </summary>
        public int CodeLength { set; get; }




        /// <summary>
        /// 生成 指定数量个随机代码.
        /// </summary>
        /// <param name="rowCount"> 生成的随机码数量 </param>
        /// <param name="existsCodeSet"> 已存在的随机码（新生成的不能和已存在的冲突） </param>
        /// <returns></returns>
        public HashSet<string> CreateRandomCode(int rowCount,  HashSet<string> existsCodeSet = null)
        {
            // 预期结果.
            HashSet<string> resultSet = new HashSet<string>();

            // 全部的随机代码.
            HashSet<string> allResultSet = null;
            
            if (existsCodeSet != null)
            {
                // 如果 已存在的随机码 存在，那么先加入  全部的随机代码
                allResultSet = new HashSet<string>(existsCodeSet);
            }
            else
            {
                // 如果 已存在的随机码 不存在， 那么创建一个空白的.
                allResultSet = new HashSet<string>();
            }

            // 成功的行数.
            int successCount = 0;

            while (successCount < rowCount)
            {
                // 生成一个随机代码.
                string oneCode = CreateOneRandomCode();

                // 判断有没有重复.
                if (allResultSet.Contains(oneCode))
                {
                    // 重复了.
                    continue;
                }


                // 不重复的， 加入已存在的随机码 和  结果 .
                allResultSet.Add(oneCode);
                resultSet.Add(oneCode);

                // 成功行数递增.
                successCount++;
            }

            // 返回.
            return resultSet;
        }




        #region 私有的方法.


        /// <summary>
        /// 生成一个随机码.
        /// </summary>
        /// <returns></returns>
        private string CreateOneRandomCode()
        {
            Random r = new Random();
            StringBuilder buff = new StringBuilder();
            for (int i = 0; i < CodeLength; i++)
            {
                buff.Append(baseCodeUseAbleCharList[r.Next(baseCodeUseAbleCharList.Count)]);
            }
            return buff.ToString();
        }


        #endregion 私有的方法.
    }


}
