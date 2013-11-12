using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0015_OverloadOperator.Sample
{

	/// <summary>
	/// 序列号类
	/// 长度3位
	/// 范围 000 - Z99
	/// 其中低位为十进制 范围 00 - 99
	/// 高位为 36进制 范围 0-9 A-Z
	/// </summary>
	class MySequence
	{

		/// <summary>
		/// 高位的可用 字符 数组.
		///
		/// 由于 数字 0 与 字母 O 比较难区分
		/// 因此字母 O 从可用字符中排除.
		///
		/// </summary>
		private static readonly char[] HighCharArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
												'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
												'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U',
												'V', 'W', 'X', 'Y', 'Z'};


		/// <summary>
		/// 低位数据.长度2位
		/// 十进制
		/// 范围 00 - 99
		/// </summary>
		private int lowValue;

		/// <summary>
		/// 高位数据.长度1位
		/// 36进制
		/// 范围 0-9 A-Z
		/// </summary>
		private int highValue;


		/// <summary>
		/// 默认构造函数.
		/// 默认值为 001
		/// </summary>
		public MySequence()
		{
			highValue = 0;
			lowValue = 1;
		}


		/// <summary>
		/// 构造函数.
		/// </summary>
		/// <param name="strVal"></param>
		public MySequence(string strVal)
		{
            if (strVal == null)
            {
                // 首先传入的参数要非空
                throw new ArgumentNullException();
            }            
            if (String.IsNullOrEmpty(strVal) )
			{
				// 首先传入的参数要不是空白
                throw new ArgumentException();
			}
			if (strVal.Length != 3)
			{
				// 且 长度 = 3
				throw new ArgumentException();
			}
			if (!HighCharArray.Contains(strVal[0]))
			{
				// 首字母要 大写字母， 或者数字
				// 也就是 在 高位的可用 字符 数组中.
				throw new ArgumentException();
			}
			if (!Char.IsDigit(strVal[1]) || !Char.IsDigit(strVal[2]))
			{
				// 后两个字母为数字.
				throw new ArgumentException();
			}


			// 高位 从 可用列表中找
			highValue = Array.BinarySearch(HighCharArray, strVal[0]);

			// 低位 转换为 整型
			lowValue = Convert.ToInt32(strVal.Substring(1));

		}


		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="highData"></param>
		/// <param name="lowData"></param>
		public MySequence(char highData, int lowData)
		{
			if (!HighCharArray.Contains(highData))
			{
				// 首字母要 大写字母， 或者数字
				// 也就是 在 高位的可用 字符 数组中.
				throw new ArgumentException();
			}
			if (lowData < 0 || lowData >= 100)
			{
				// 低位数据范围 0-99
				throw new ArgumentException();
			}

			// 高位 从 可用列表中找
			highValue = Array.BinarySearch(HighCharArray, highData);

			// 低位 直接赋值.
			lowValue = lowData;
		}


		/// <summary>
		/// 私有构造函数
		/// </summary>
		/// <param name="high"></param>
		/// <param name="low"></param>
		private MySequence(int high, int low)
		{
			highValue = high;
			lowValue = low;
		}


		/// <summary>
		/// 将序列号的字符串表示形式转换为它的等效 序列号对象。一个指示转换是否成功的返回值。
		/// </summary>
		/// <param name="strVal"></param>
		/// <param name="outMySequence"></param>
		/// <returns></returns>
		public static bool TryParse(string strVal, out MySequence outMySequence)
		{
			outMySequence = new MySequence();

			if (String.IsNullOrEmpty(strVal))
			{
				// 首先传入的参数要非空
				return false;
			}
			if (strVal.Length != 3)
			{
				// 且 长度 = 3
				return false;
			}
			if (!HighCharArray.Contains(strVal[0]))
			{
				// 首字母要 大写字母， 或者数字
				// 也就是 在 高位的可用 字符 数组中.
				return false;
			}
			if (!Char.IsDigit(strVal[1]) || !Char.IsDigit(strVal[2]))
			{
				// 后两个字母为数字.
				return false;
			}

			// 高位 从 可用列表中找
			outMySequence.highValue = Array.BinarySearch(HighCharArray, strVal[0]);

			// 低位 转换为 整型
			outMySequence.lowValue = Convert.ToInt32(strVal.Substring(1));

			return true;
		}



		/// <summary>
		/// 重载运算符 ++
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static MySequence operator ++ (MySequence val)
		{
			// 低位++
			val.lowValue++;

			if (val.lowValue == 100)
			{
				// 如果低位超出范围
				// 至零
				val.lowValue = 0;
				// 高位++
				val.highValue++;

				if (val.highValue >= HighCharArray.Length)
				{
					// 如果 高位大于 可用字符数组大小，溢出.
					throw new OverflowException();
				}
			}
			return val;
		}

		/// <summary>
		/// 重载运算符 --
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static MySequence operator --(MySequence val)
		{
			// 低位++
			val.lowValue--;

			if (val.lowValue == -1)
			{
				// 如果低位超出范围
				// 至零
				val.lowValue = 99;
				// 高位++
				val.highValue--;

				if (val.highValue < 0)
				{
					// 如果 高位小于0，溢出.
					throw new OverflowException();
				}
			}
			return val;
		}


		/// <summary>
		/// 重载运算符 +
		/// </summary>
		/// <param name="val"></param>
		/// <param name="step"></param>
		/// <returns></returns>
		public static MySequence operator +(MySequence val, int step)
		{
			MySequence result = new MySequence(val.highValue, val.lowValue);
			// 低位++
			result.lowValue += step;

			if (result.lowValue >= 100)
			{
				// 如果低位超出范围
				// 高位 +
				result.highValue += result.lowValue / 100;

				// 低位取余
				result.lowValue = result.lowValue % 100;

				if (result.highValue >= HighCharArray.Length)
				{
					// 如果 高位大于 可用字符数组大小，溢出.
					throw new OverflowException();
				}
			}
			return result;
		}



		/// <summary>
		/// 重载运算符 ==
		/// </summary>
		/// <param name="val"></param>
		/// <param name="val2"></param>
		/// <returns></returns>
		public static bool operator ==(MySequence val, MySequence val2)
		{
			return (val.highValue == val2.highValue && val.lowValue == val2.lowValue);
		}

		/// <summary>
		/// 重载运算符 !=
		/// </summary>
		/// <param name="val"></param>
		/// <param name="val2"></param>
		/// <returns></returns>
		public static bool operator !=(MySequence val, MySequence val2)
		{
			return (val.highValue != val2.highValue || val.lowValue != val2.lowValue);
		}



		/// <summary>
		/// 重载 ToString 方法.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return HighCharArray[highValue].ToString() + lowValue.ToString("00");
		}

		/// <summary>
		/// 重载 Equals 方法.
		/// </summary>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj is MySequence)
			{
				MySequence oSequence = obj as MySequence;
				return (oSequence.highValue == this.highValue && oSequence.lowValue == this.lowValue);
			}
			return false;
		}

		/// <summary>
		/// 重载 GetHashCode 方法.
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

	}



}
