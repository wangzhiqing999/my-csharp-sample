using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.International.Converters.PinYinConverter;


namespace A0412_ChinesePinyin
{


    /// <summary>
    /// 运行本项目， 需要安装 Microsoft Visual Studio International Pack 1.0
    /// </summary>
    class MyChineseConvert
    {

        /// <summary>
        /// 文本内容替换
        /// 
        /// 返回列表的原因， 是因为某些情况下， 汉字存在多音字的情况。
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="replaceStr"></param>
        /// <returns></returns>
        public List<string> PinyingConvert(string sourceStr, string replaceStr)
        {
            List<StringBuilder> bufferList = new List<StringBuilder>() {
                new StringBuilder()
            };


            for (int i = 0; i < Math.Min(sourceStr.Length, replaceStr.Length); i++)
            {
                if (sourceStr[i] == replaceStr[i])
                {
                    // 源文本 与 目标文本一致， 直接加入结果.
                    foreach (StringBuilder buff in bufferList)
                    {
                        buff.Append(sourceStr[i]);
                    }
                }
                else
                {
                    // 源文本 与 目标文本不一致， 尝试切换为   源汉字(替换汉字拼音)
                    foreach (StringBuilder buff in bufferList)
                    {
                        buff.AppendFormat("{0}(", sourceStr[i]);
                    }
                  
                    // 当前列表长度.
                    int currentCount = bufferList.Count;

                    List<string> replacePinYins = GetPinYins(replaceStr[i]);

                    if (replacePinYins.Count > 1)                    
                    {
                        // 是多音字， 需要扩充结果列表.
                        
                        for (int j = currentCount-1; j >= 0; j--)
                        {
                            foreach (string pin in replacePinYins)
                            {
                                if (pin == replacePinYins[0])
                                {
                                    // 最后再处理.
                                    continue;
                                }
                                if (String.IsNullOrEmpty(pin))
                                {
                                    // 忽略空白.
                                    continue;
                                }

                                StringBuilder buff = new StringBuilder(bufferList[j].ToString());
                                buff.Append(pin);

                                bufferList.Insert(currentCount, buff);

                            }
                        }
                    }

                    // 加入结果.
                     for (int j = currentCount-1; j >= 0; j--)
                    {
                        bufferList[j].Append(replacePinYins[0]);
                    }


                    foreach (StringBuilder buff in bufferList)
                    {
                        buff.Append(")");
                    }
                }

            }




            // 构造结果.
            List<string> resultList = new List<string>();

            foreach (StringBuilder buff in bufferList)
            {
                resultList.Add(buff.ToString());
            }

            // 返回结果.
            return resultList;
        }




        /// <summary>
        /// 获取 可用的拼音。 
        /// （不要最后的 1，2，3，4 声）
        /// </summary>
        /// <param name="charData"></param>
        /// <returns></returns>
        private List<string> GetPinYins(char charData)
        {
            List<string> resultList = new List<string>();
            ChineseChar chineseChar = new ChineseChar(charData);

            foreach (string pin in chineseChar.Pinyins)
            {
                if (String.IsNullOrEmpty(pin))
                {
                    // 忽略空白.
                    continue;
                }

                // 结果 去掉最后一个 声调的数字.
                string result = pin.Substring(0, pin.Length - 1).ToLower();

                if (!resultList.Contains(result))
                {
                    resultList.Add(result);
                }
            }

            return resultList;
        }

    }
}
