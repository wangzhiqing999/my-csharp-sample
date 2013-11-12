using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0411_ChinesePinyin.Sample;


namespace A0411_ChinesePinyin
{
	class Program
	{
		static void Main(string[] args)
		{
			PinYin p = new PinYin();

			Console.WriteLine(p.GetChineseSpell("甲乙丙丁"));
			Console.WriteLine(p.GetChineseSpell("重量"));
			Console.WriteLine(p.GetChineseSpell("重庆"));


			p.Test('国');
			p.Test('重');

			Console.ReadLine();
		}
	}
}
