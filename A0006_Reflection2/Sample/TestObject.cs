using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0006_Reflection2.Sample
{

	/// <summary>
	/// 用于测试 反射 的对象类
	/// </summary>
	public class TestObject
	{
		/// <summary>
		/// 测试的 字符串类型的数据.
		/// </summary>
		private String strVal;

		/// <summary>
		/// 测试的 int 类型的数据.
		/// </summary>
		private int intVal;

		/// <summary>
		/// 测试的 字符串类型的属性.
		/// </summary>
		public String StrValue
		{
			set
			{
				strVal = value;
			}
			get
			{
				return strVal;
			}
		}

		/// <summary>
		/// 测试的 int类型的属性.
		/// </summary>
		public int IntValue
		{
			set
			{
				intVal = value;
			}
			get
			{
				return intVal;
			}
		}

		/// <summary>
		/// 测试的 布尔型的属性.
		/// </summary>
		public bool BoolValue { set; get; }


		private bool readOnly = true;

		/// <summary>
		/// 测试的 布尔型的属性.
		/// RaadOnly.
		/// </summary>
		public bool BoolValueReadOnly
		{
			get
			{
				return readOnly;
			}
		}


		private bool writeOnly;

		/// <summary>
		/// 测试的 布尔型的属性.
		/// WriteOnly.
		/// </summary>
		public bool BoolValueWriteOnly 
		{
			set
			{
				writeOnly = value;
			}
		}


		/// <summary>
		/// IList 属性.
		/// </summary>
		public IList<String> DataList { set; get; }

		/// <summary>
		/// List 属性.
		/// </summary>
		public List<String> DataList2 { set; get; }

		/// <summary>
		/// 数组的属性.
		/// </summary>
		public String[] StrArray { set; get; }



		/// <summary>
		/// 枚举
		/// </summary>
		public enum EnumColor
		{
			Red,
			Yellow,
			Green
		}

		/// <summary>
		/// 枚举的属性.
		/// </summary>
		public EnumColor Color { set; get; }

	}
}
