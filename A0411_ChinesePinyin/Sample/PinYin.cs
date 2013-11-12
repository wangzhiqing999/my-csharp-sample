using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


using Microsoft.International.Converters.PinYinConverter;


namespace A0411_ChinesePinyin.Sample
{

	public class PinYin
	{


		#region 中文汉字 与 拼音转换的代码. [简单的处理，不处理多音字]

		/// <summary>
		/// 取得 中文汉字字符串的 汉语拼音首字母信息.
		/// </summary>
		/// <param name="strText"></param>
		/// <returns></returns>
		public string GetChineseSpell(string strText)
		{
			// 取得 源字符串长度.
			int len = strText.Length;
			// 准备用于返回的 缓存信息.
			StringBuilder buff = new StringBuilder();
			// 依次处理每一个字符.
			for (int i = 0; i < len; i++)
			{
				buff.Append(getSpell(strText.Substring(i, 1)));
			}
			// 返回.
			return buff.ToString();
		}

		/// <summary>
		/// 取得 中文汉字字符的 汉语拼音首字母信息.
		/// </summary>
		/// <param name="cnChar"></param>
		/// <returns></returns>
		public string getSpell(string cnChar)
		{
			// 将传入的 char 信息， 拆分为 byte
			byte[] arrCN = Encoding.Default.GetBytes(cnChar);
			// 首先判断一下 传入的数据.
			if (arrCN.Length > 1)
			{
				// 传入的大于 1个字节。 应该是双字节字符.
				// 需要拆分
				int area = (short)arrCN[0];
				int pos = (short)arrCN[1];
				int code = (area << 8) + pos;
				int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
				for (int i = 0; i < 26; i++)
				{
					int max = 55290;
					if (i != 25) max = areacode[i + 1];
					if (areacode[i] <= code && code < max)
					{
						return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
					}
				}
				// 遇到无法识别的信息
				return "*";
			}
			else
			{
				// 单字节的 英文/数字 信息，直接简单返回.
				return cnChar;
			}
		}


		#endregion




		/// <summary>
		/// 使用 Microsoft Visual Studio International Pack v1.0 中的
		/// Simplified Chinese Pin-Yin Conversion Library 来处理 汉语拼音.
		/// </summary>
		/// <param name="iChar"></param>
		public void Test(char iChar)
		{
			ChineseChar chineseChar = new ChineseChar(iChar);

			Console.WriteLine("{0} 是否是多音字：{1} ", iChar, chineseChar.IsPolyphone);

			ReadOnlyCollection<string> pinyin = chineseChar.Pinyins;
			foreach (string pin in pinyin)
			{
				if (!String.IsNullOrEmpty(pin))
				{
					Console.WriteLine(iChar + " 汉语拼音为 " + pin);
				}
			}

		}




	}

}
