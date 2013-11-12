using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0030_Event.Sample
{

	public delegate void AgeChangeHandler(int age, object obj, ref bool cancel);


	class Person
	{

		/// <summary>
		/// 定义事件.
		/// </summary>
		public event AgeChangeHandler AgeChange;


		private int age = 0;


		public int Age
		{
			set
			{
				// 是否取消操作，默认为 false, 也就是默认是要执行的.
				bool cancel = false;

				// 如果定义了事件，那么触发该事件.
				if (AgeChange != null)
				{
					AgeChange(value, this, ref cancel);
				}

				// 如果不要求“取消”，那么设置数据.
				if (!cancel)
				{
					age = value;
				}
			}

			get
			{
				return age;
			}
		}


	}

}
