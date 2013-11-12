using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0070_CustomAttributes.Sample
{
	/// <summary>
	/// 用于 测试 属性类的
	///
	/// 注意： 这里的 Test3 继承了 Test2
	///
	/// Test2 与 Test3 均有属性
	/// </summary>
	[Creator("Ivy", "2010.9.13", "1.1")]
	class Test3 : Test2
	{
	}
}
