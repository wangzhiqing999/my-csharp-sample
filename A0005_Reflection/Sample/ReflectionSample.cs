using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace A0005_Reflection.Sample
{

	/// <summary>
	/// 用于测试 反射 的例子.
	/// </summary>
	public class ReflectionSample
	{

		/// <summary>
		/// 测试 只有 类全路径名的情况下, 创建实例.
		/// </summary>
		/// <returns></returns>
		public void TestNewClass()
		{
			// 获取当前程序集
			Assembly assembly = Assembly.GetExecutingAssembly();

			// 注意： 这里的目标类，是自己这个程序里面的
			// 如果 目标类，在别的 DLL 里面
			// 需要使用
			// Assembly assembly = System.Reflection.Assembly.LoadFile(dll文件名);
			// 来加载.

			// 通过反射，创建对象的实例.
			ObjectClass obj =
				(ObjectClass)assembly.CreateInstance("A0005_Reflection.Sample.ObjectClass");

			Console.WriteLine("测试是否成功的获取了实例");
			obj.HelloWorld();
		}



		/// <summary>
		/// 测试 读取/设置 属性.
		/// </summary>
		public void TestGetSetProp()
		{
			// 创建实例.
			Object obj = new ObjectClass();

			// 首先取得类型
			Type myType = obj.GetType();

			// 通过属性名字，首先获取属性 GetProperty("TestProp")
			// 然后通过属性，设置值  SetValue
			myType.GetProperty("TestProp").SetValue(obj, "HaHa", null);

			// 测试 属性的值是否被正确的设置.
			Console.WriteLine("检查 SetValue 执行结果：" + ((ObjectClass)obj).TestProp);


			// 通过属性名字，首先获取属性 GetProperty("TestProp")
			// 然后通过属性，获取值  GetValue
			Object testVal = myType.GetProperty("TestProp").GetValue(obj, null);

			// 测试 属性的值是否被正确的获取.
			Console.WriteLine("检查 GetValue 执行结果：" + testVal);

		}



		/// <summary>
		/// 测试调用 方法.
		/// </summary>
		public void TestCall()
		{
			// 创建实例.
			Object obj = new ObjectClass();

			// 首先取得类型
			Type myType = obj.GetType();

			Console.WriteLine("测试 通过反射调用 HelloWorld 方法。");
			myType.GetMethod("HelloWorld").Invoke(obj, null);

			Console.WriteLine("测试 通过反射调用 GetHelloWorld() 方法。");
			Object returnVal = myType.GetMethod("GetHelloWorld", new Type[]{}).Invoke(obj, null);
			Console.WriteLine("返回值 = " + returnVal);


			Console.WriteLine("测试 通过反射调用 GetHelloWorld(String name) 方法。");
			returnVal = myType.GetMethod("GetHelloWorld", new Type[] { typeof(String) }).Invoke(obj, new Object[]{"Xixi"});
			Console.WriteLine("返回值 = " + returnVal);

		}


	}

}
