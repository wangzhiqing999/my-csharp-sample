using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;



namespace A0401_String.Sample
{

	/// <summary>
	/// 正则表达式的测试.
	/// </summary>
	class RegexSample
	{

		/*

		基本的语法字符。
		\d  0-9的数字
		\D  \d的补集（以所以字符为全集，下同），即所有非数字的字符
		\w  单词字符，指大小写字母、0-9的数字、下划线
		\W  \w的补集
		\s  空白字符，包括换行符\n、回车符\r、制表符\t、垂直制表符\v、换页符\f
		\S  \s的补集
		.  除换行符\n外的任意字符
		[…]  匹配[]内所列出的所有字符
		[^…]  匹配非[]内所列出的字符

		*/


		/// <summary>
		/// 演示 Regex 的基本使用.
		/// </summary>
		public void DemoRegexUse1()
		{
			string str = "A";
			string num = "3";
			Regex r = new Regex(@"\D");

			Console.WriteLine("[01]正则表达式{0}匹配{1}的IsMatch结果为：{2}", @"\D", str, r.IsMatch(str));
			Console.WriteLine("[01]正则表达式{0}匹配{1}的IsMatch结果为：{2}", @"\D", num, r.IsMatch(num));

			Console.WriteLine("[01]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", num, @"\D", Regex.IsMatch(num, @"\D"));


			String val = "x";
			String pat = "[a-z0-9]";
			Console.WriteLine("[01]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pat, Regex.IsMatch(val, pat));






		}


		/*

		“定位字符”所代表的是一个虚的字符，它代表一个位置，你也可以直观地认为“定位字符”所代表的是某个字符与字符间的那个微小间隙。
		^  表示其后的字符必须位于字符串的开始处
		$  表示其前面的字符必须位于字符串的结束处
		\b  匹配一个单词的边界
		\B  匹配一个非单词的边界
		另外，还包括：\A  前面的字符必须位于字符处的开始处，\z  前面的字符必须位于字符串的结束处，\Z  前面的字符必须位于字符串的结束处，或者位于换行符前

		 */

		/// <summary>
		/// 演示 Regex 的定位字符使用.
		/// </summary>
		public void DemoRegexUse2()
		{
			string val = "Hello My C# World";
			String pattern = "^H";
			Console.WriteLine("[02]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			pattern = "d$";
			Console.WriteLine("[02]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			// \b通常用于约束一个完整的单词
			pattern = @"\bMy\b";
			Console.WriteLine("[02]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			pattern = @"\bllo\b";
			Console.WriteLine("[02]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

		}



		/*
		 重复描述字符
		{n}  匹配前面的字符n次
		{n,}  匹配前面的字符n次或多于n次
		{n,m}  匹配前面的字符n到m次
		?  匹配前面的字符0或1次
		+  匹配前面的字符1次或多于1次
		*  匹配前面的字符0次或多于0次
		 */
		/// <summary>
		/// 演示 Regex 的重复描述字符使用.
		/// </summary>
		public void DemoRegexUse3()
		{

			// 以 0个或者1个 "+" 开头  然后是一个[1-9]的数字 然后是 0个或者1个 "," 然后是以3个数字结尾.
			// 匹配1000到9999的整数
			String pattern = @"^\+?[1-9],?\d{3}$";

			string val = "1024";
			Console.WriteLine("[03]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			val = "1,024";
			Console.WriteLine("[03]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			val = "+1024";
			Console.WriteLine("[03]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			val = "+1,024";
			Console.WriteLine("[03]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			val = "10,24";
			Console.WriteLine("[03]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));
		}


		/*
		 (|)  多个中选择一个
		 [a-z]也是一种择一匹配，只不过它只能匹配单个字符，
		 而(|)则提供了更大的范围，(ab|xy)表示匹配ab或匹配xy。
		 注意“|”与“()”在此是一个整体。
		 */

		/// <summary>
		/// 演示 Regex 的 选择匹配 使用.
		/// </summary>
		public void DemoRegexUse4()
		{

			// 以 0个或者1个 "+" 开头
			//     然后是 一个 100  与  0个或多个 [ .后面1个或多个0  ]
			//     或者是 0个或1个 的[1-9之间的数据] 与1个 [0-9之间的数据]  与 一个点 和 1个或多个数字 结尾
			//
			//
			String pattern = @"^\+?((100(.0+)*)|([1-9]?[0-9])(\.\d+)*)$";

			string val = "100";
			Console.WriteLine("[04]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			val = "100.0";
			Console.WriteLine("[04]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			val = "100.0.00.000";
			Console.WriteLine("[04]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			val = "0.1";
			Console.WriteLine("[04]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			val = "0.1.2.3";
			Console.WriteLine("[04]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));



            // 正则表达式检查  身份证号码.
            //   
            string cradPat = @"^\d{17}(\d|X|x)$";

            string[] cardValueArray = { 
                "11010519491231002X", 
                "110105194912310011", 
                "11010519491231001C", 
                "1101051949123100112",
                "1101051949 2310011", 
                "1101051949X2310011", 
                "11010519491231001"};

            foreach (string cardValue in cardValueArray)
            {
                Console.WriteLine("[04]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", cardValue, cradPat, Regex.IsMatch(cardValue, cradPat));
            }
		}




		/// <summary>
		/// 演示 Regex 的 组与非捕获组 使用.
		/// </summary>
		public void DemoRegexUse5()
		{

			// Live 开头， 后面是 [a-z] 的3个字母， 然后是 no 后面是 [a-z] 的5个字母.
			// 然后是 die  后面的 \1 表示 与最开始的那个 [a-z] 的3个字母 一样
			// 然后是 some 最后面的 \2 表示 与 第二个匹配的 [a-z] 的5个字母 一样
			String pattern = @"^Live ([a-z]{3}) no([a-z]{5}),die \1 some\2$";
			string val = "Live for nothing,die for something";
			Console.WriteLine("[05]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			// 这里 把 前面的 [a-z] 的3个字母 设置为 for  后面的  \1 由 for 替换为 abc
			val = "Live for nothing,die abc something";
			Console.WriteLine("[05]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

		}



		/// <summary>
		/// 演示 多次匹配，并取得匹配数据的 例子.
		/// </summary>
		public void DemoRegexUse6()
		{
			string text = "One car red car blue car";

			// (1个到多个)单词 (1个到多个)空白 car
			string pat = @"(\w+)\s+(car)";


			Console.WriteLine("[06]字符串={0}", text);
			Console.WriteLine("[06]正则表达式={0}", pat);


			// 初始化 正则表达式  忽略大小写
			Regex r = new Regex(pat, RegexOptions.IgnoreCase);

			// 指定的输入字符串中搜索 Regex 构造函数中指定的正则表达式的第一个匹配项。
			Match m = r.Match(text);

			// 匹配的 计数.
			int matchCount = 0;


			// Match类 表示单个正则表达式匹配的结果。
			// Success 属性表示：匹配是否成功
			while (m.Success)
			{

				Console.WriteLine("[06]第{0}次匹配！", (++matchCount));

				for (int i = 1; i <= 2; i++)
				{
					// Groups 为 获取由正则表达式匹配的组的集合。
					Group g = m.Groups[i];
					Console.WriteLine("==Group[{0}]={1}" , i , g );

					// Captures 为 按从里到外、从左到右的顺序获取由捕获组匹配的所有捕获的集合
					// 该集合可以有零个或更多的项。
					CaptureCollection cc = g.Captures;
					for (int j = 0; j < cc.Count; j++)
					{
						// Capture 表示来自单个子表达式捕获的结果。
						//     属性 Index 原始字符串中发现捕获的子字符串的第一个字符的位置。
						//     属性 Length 捕获的子字符串的长度。
						//     属性 Value 从输入字符串中获取捕获的子字符串。
						Capture c = cc[j];
						Console.WriteLine("====Capture[{0}] = {1}, Position={2}" , j, c, c.Index);
					}
				}
				m = m.NextMatch();

			}


            // 电子邮件地址
            string emailPat = @"^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$";

            string[] emailValueArray = { 
                "zhang3@sina.com",
                "li4@sina.com",
                "abc.def@sina.com",
                "@sina.com",
                "zhang3@",
                "zhang3@com",};

            foreach (string value in emailValueArray)
            {
                Console.WriteLine("[06]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", value, emailPat, Regex.IsMatch(value, emailPat));
            }

		}



		/// <summary>
		/// 演示 匹配 替换 的例子
		/// </summary>
		public void DemoRegexUse7()
		{
			// 匹配 匹配任意单字符(1个及以上) @ 匹配任意单字符(1个及以上) .
			String pattern = @"\w{1,}@\w{1,}\.";
			string val = "test@test.net";
			Console.WriteLine("[07]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", val, pattern, Regex.IsMatch(val, pattern));

			Console.WriteLine("[07]使用正则表达式替换 @ 为 # 后的结果为：{0}", Regex.Replace(val, "@", "#"));


			// 字符串中间有连续空格的话,仅保留一个。
			String badString = "测试本文：   中间 一个  或者    多个     空格";

			Console.WriteLine("[07]{0}\n中间有连续空格的话,仅保留一个后的结果为：\n{1}", badString, Regex.Replace(badString, " +", " "));


			char[] divChar = { ' ' };
			String [] stringSplit = badString.Split(divChar);

			String[] regexSplit = Regex.Split(badString, " +");

			Console.WriteLine("[07]{0} 根据 String.Split “{1}” 拆分出来的结果为：", badString, divChar[0]);
			foreach (String oneData in stringSplit)
			{
				Console.WriteLine(oneData);
			}


			Console.WriteLine("[07]{0} 根据 Regex.Split “{1}” 拆分出来的结果为：", badString, " +");
			foreach (String oneData in regexSplit)
			{
				Console.WriteLine(oneData);
			}

			// 说明：
			// 使用 Regex.Split 的优点在于， 可以排除掉一些 String.Split 所会遇到的 不必要的麻烦.
			// 下面的例子，就是按照 ; 来 Split， 对于 String.Split, 在拿到字符串数组之后，还要做额外的 Trim 工作，才能保证数据的正确。
			String dataString = "Java; C#; C++ ; C; DELPHI; BASIC";
			divChar[0] = ';';
			string[] itemArray = dataString.Split(divChar);
			Console.WriteLine("[07]{0} 根据 String.Split  {1} 拆分出来的结果为：", dataString, divChar[0]);
			foreach (String oneData in itemArray)
			{
				Console.WriteLine("==[{0}]", oneData);
			}

			// 使用正则表达式来进行 Split， 可以使 Split 出来的 字符创数组，不需要做额外的 Trim 工作。
			itemArray = Regex.Split(dataString, " *; *");
			Console.WriteLine("[07]{0} 根据 Regex.Split  {1} 拆分出来的结果为：", dataString, " *; *");
			foreach (String oneData in itemArray)
			{
				Console.WriteLine("==[{0}]", oneData);
			}

		}






	}

}
