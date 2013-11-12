using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace A0006_Reflection2.Sample
{
	public class ReflectionSample
	{
		public void Test()
		{
			// 首先，创建指定的类.

			// 获取当前程序集
			Assembly assembly = Assembly.GetExecutingAssembly();

			// 注意： 这里的目标类，是自己这个程序里面的
			// 如果 目标类，在别的 DLL 里面
			// 需要使用
			// Assembly assembly = System.Reflection.Assembly.LoadFile(dll文件名);
			// 来加载.

			// 通过反射，创建对象的实例.
			Object obj = assembly.CreateInstance("A0006_Reflection2.Sample.TestObject");


			// 取得对象的 Type.
			Type myType = obj.GetType();
			
			// 取得对象的所有属性.
			PropertyInfo[] propArray = myType.GetProperties();

			foreach (PropertyInfo prop in propArray)
			{
				Console.WriteLine("属性名{0}, CanRead={1}, CanWrite={2}, 数据类型={3}", 
					prop.Name, prop.CanRead, prop.CanWrite, prop.PropertyType.Name);

				Console.WriteLine("是否是抽象类{0}, 是否是类{1}", prop.PropertyType.IsAbstract, prop.PropertyType.IsClass);
				Console.WriteLine("是否是数组{0}, 是否是枚举{1}", prop.PropertyType.IsArray, prop.PropertyType.IsEnum);
				Console.WriteLine();
			}
		}
	}
}
