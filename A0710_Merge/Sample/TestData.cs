using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0710_Merge.Sample
{

	///	<summary>
	///	该类用于模拟一个需要 合并 处理的数据对象.
	///	</summary>
	public class TestData
	{
		///	<summary>
		///	编号.
		///	</summary>
		public int Id {	set; get; }

		///	<summary>
		///	数值.
		///	</summary>
		public string Val {	set; get; }

		public override	string ToString()
		{
			return String.Format("测试数据[ID={0}; VAL={1}]", Id, Val);
		}
	}

	///	<summary>
	///	TestDataMerge 继承了 Merge类.
	///	</summary>
	public class TestDataMerge : Merge<TestData>
	{
		///	<summary>
		///	覆盖 Merge 的比较方式.
		///	</summary>
		///	<param name="oldData"></param>
		///	<param name="oldNew"></param>
		///	<returns></returns>
		public override	bool On(TestData oldData, TestData oldNew)
		{
			// 对于 TestData 类，以 ID 为基准进行关联.
			return oldData.Id == oldNew.Id;
		}
	}
}
