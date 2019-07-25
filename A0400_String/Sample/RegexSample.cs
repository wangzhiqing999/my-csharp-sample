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


            // 某系统创建用户名的时候， 做的检查.
            // 用户名 允许使用 小写字母/数字/下环线
            string userNamePat = @"^[\d|a-z|_]+$";

            string[] testUserName =
            {
                "1234567890",
                "test",
                "zhang3",
                "zhang_3",
                "li4",
                "li_4",
                "manager001",
                "manager_001",
                "master666",
                "master_666",
                "error1 ",
                " error2",
                " error3 ",
                "error 4",
            };

            foreach (string userName in testUserName)
            {
                Console.WriteLine("[04]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", userName, userNamePat, Regex.IsMatch(userName, userNamePat));
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
                "abc.def@sina.com.tw",
                "abc.def@sina.co.jp",
                "@sina.com",
                "zhang3@",
                "zhang3@com",};

            foreach (string value in emailValueArray)
            {
                Console.WriteLine("[06]使用正则表达式静态方法IsMatch({0}, {1})的结果为：{2}", value, emailPat, Regex.IsMatch(value, emailPat));
            }



            // 网页地址匹配.
            String[] testArray = {
                "http://localhost:7735/%E5%85%AC%E5%8F%B8%E7%BD%91%E7%AB%99/home.htm",
                "adf.htm",
                "aas/sfg.htm",
                "http://xyz.com/4-91.htm",
                                 };

            string patWeb = @"([^/]+).htm";
            // 初始化 正则表达式  忽略大小写
            Regex rWeb = new Regex(patWeb, RegexOptions.IgnoreCase);

            foreach (string str in testArray)
            {
                // 指定的输入字符串中搜索 Regex 构造函数中指定的正则表达式的第一个匹配项。
                Match mWeb = rWeb.Match(str);
                if (mWeb.Success)
                {
                    Group g = mWeb.Groups[0];
                    Console.WriteLine("[06] 原始数据：{0}, 解析后的结果：{1} ", str, g.Value);
                }
            }




            // HTML 匹配.
            string htmlText = "<a href=\"/xqzx/mrxq/538244.shtml\" class=\"load_list\"><span class=\"fr\">2016-05-17</span><i>上海黄金交易所2016年5月17日交易行情</i></a>";

            string patHtml = "<a href=\"([^ ]+)\" class=\"load_list\"><span class=\"fr\">([^/]+)</span><i>([^/]+)</i></a>";

            // 初始化 正则表达式  忽略大小写
            Regex rHtml = new Regex(patHtml, RegexOptions.IgnoreCase);

            Match mHtml = rHtml.Match(htmlText);
            if (mHtml.Success)
            {

                Console.WriteLine(@"[06] 原始数据：{0},
解析后的结果：{1}
{2}
{3}", htmlText,  mHtml.Groups[1].Value, mHtml.Groups[2].Value, mHtml.Groups[3].Value);
            }









            string htmlText2 = @"
据汇金网(www.gold678.com)周三(9月16日)监测的黄金ETFs数据显示，截止周二(9月15日)黄金ETF-SPDR Gold Trust的黄金持仓量约为678.18吨或2180.4252万盎司，较上一交易日持平。
<img[b]src=http://upload.fx678.com/upload/ht/20150916/nsy_2015091610562484.jpg[b]onload=imgresize(this);[b]style=cursor:pointer;[b]alt=图片点击可在新窗口打开查看[b]onclick=javascript:window.open(this.src);[b]/>
(SPDR Gold Trust黄金持仓历史走势)
<B>具体数据见下表：</B>
<img[b]src=http://upload.fx678.com/upload/ht/20150916/nsy_2015091610565776.png[b]onload=imgresize(this);[b]style=cursor:pointer;[b]alt=图片点击可在新窗口打开查看[b]onclick=javascript:window.open(this.src);[b]/>
";



            string patHtml2 = @"<img\[b\]src=([^ \[]+)";


            // 初始化 正则表达式  忽略大小写
            Regex rHtml2 = new Regex(patHtml2, RegexOptions.IgnoreCase);

            Match mHtml2 = rHtml2.Match(htmlText2);


            while (mHtml2.Success)
            {

                Group g2 = mHtml2.Groups[1];

                Console.WriteLine("[06] 分析 HTML 字符串，获取 <img 的 src = {0}", g2.Value);

                mHtml2 = mHtml2.NextMatch();
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




            string source = @" </tr>                        	         <script type=""text/javascript"">timeSplit('2016-10-11 08:53:46');</script> ";
            string pat = "<script .*/script>";
            string removeScript = Regex.Replace(source, pat, "", RegexOptions.IgnoreCase);
            Console.WriteLine(@"[07]尝试移除 html 中的 script.
{0}
{1}", source, removeScript);




            source = @"财经早知道(1011)：聚焦IEA月度原油市场报告	<img class=""more_end2"" src=""/Public/images/more_ads2.gif"" align=""absmiddle"">  </a></div>";
            pat = "<img [^>]*>";
            string removeImg = Regex.Replace(source, pat, "", RegexOptions.IgnoreCase);
            Console.WriteLine(@"[07]尝试移除 html 中的 Img.
{0}
{1}", source, removeImg);





            source = @"<div style='color: #000000;'>
                                <!--【北京时间16:00行情播报，英镑兑美元扩大涨幅】<br/>美元指数震荡整理，现报100.94，日跌0.15%；<br/>欧元兑美元震荡整理，现报1.0612，日升0.12%；<br/>英镑兑美元扩大涨幅，现报1.2485，日升0.19%；<br/>澳元兑美元震荡盘整，现报0.7704，日跌0.12%；<br/>美元兑日元震荡调整，现报113.96，日跌0.19%-->
                                                                    【北京时间16:00行情播报，英镑兑美元扩大涨幅】<br />美元指数震荡整理，现报100.94，日跌0.15%；<br />欧元兑美元震荡整理，现报1.0612，日升0.12%；<br />英镑兑美元扩大涨幅，现报1.2485，日升0.19%；<br />澳元兑美元震荡盘整，现报0.7704，日跌0.12%；<br />美元兑日元震荡调整，现报113.96，日跌0.19%
                            </div>
";

            pat = "<!--.*-->";
            string removeRemark = Regex.Replace(source, pat, "", RegexOptions.IgnoreCase);
            Console.WriteLine(@"[07]尝试移除 html 中的 备注.
{0}
{1}", source, removeRemark);








            source = "<img alt=\"😀\" class=\"emojioneemoji\" src=\"http://192.168.1.9/test/78/data/assets/png/1f600.png\">";

            pat = "alt=\"[^ ]+\"";

            string removeAlt = Regex.Replace(source, pat, "", RegexOptions.IgnoreCase);

            Console.WriteLine(@"[07]尝试移除 html 中的  alt=.
{0}
{1}", source, removeAlt);




            // 网站需要  http 迁移至 https
            // 所有  http://域名：端口号/... 的， 需要变更为 https://域名/...

            string[] httpUrls = { 
                    @"http://www.test.com/index.html",
                    @"http://a.test.com/Test123/",
                    @"http://b.test.com/Sample?id=12345",
                    @"http://c.test.com/A/B/C/12345/",
                    @"http://d.test.com:1234/",
                    @"http://d.test.com:1234/xyz",
                    @"http://d.test.com:1234/1234",
                    @"http://d.test.com:1234/1234/",
                    @"http://d.test.com:1234/1234/5678/",
                               };

            string httpPortPat = @"[:][0-9]+/";
            foreach (string httpulr in httpUrls)
            {
                string httpsUrl = httpulr.Replace("http://", "https://");
                httpsUrl = Regex.Replace(httpsUrl, httpPortPat, "/", RegexOptions.IgnoreCase);

                Console.WriteLine("Before: {0}", httpulr);
                Console.WriteLine("After:  {0}", httpsUrl);
            }





            // 用户昵称中，如果出现连续4位及以上连续数字时，数字部分用***替换
            string[] userNickNames =
            {
                "洗车0",
                "洗车02",
                "洗车024",
                "洗车0246",
                "洗车02468",
                "美容1234-5",
                "美容1234-56",
                "美容1234-5678",
                "美容1234-5678-9",
                "美容1234-5678-90",
                "推拿130-1234-5678",
            };

            string namePat = @"\d{4,}";


            foreach (string nickname in userNickNames)
            {
                
                string resultName = Regex.Replace(nickname, namePat, "***", RegexOptions.IgnoreCase);

                Console.WriteLine("初始值: {0};  替换后:  {1}", nickname, resultName);
            }
        }








        /// <summary>
        /// 演示 匹配 替换 的例子
        /// </summary>
        public void DemoRegexUse8()
        {


			// 字符串中间有连续空格的话,仅保留一个。
			String badString = "测试本文：   中间 一个  或者    多个     空格";

			Console.WriteLine("[08]{0}\n中间有连续空格的话,仅保留一个后的结果为：\n{1}", badString, Regex.Replace(badString, " +", " "));


			char[] divChar = { ' ' };
			String [] stringSplit = badString.Split(divChar);

			String[] regexSplit = Regex.Split(badString, " +");

			Console.WriteLine("[08]{0} 根据 String.Split “{1}” 拆分出来的结果为：", badString, divChar[0]);
			foreach (String oneData in stringSplit)
			{
				Console.WriteLine(oneData);
			}


			Console.WriteLine("[08]{0} 根据 Regex.Split “{1}” 拆分出来的结果为：", badString, " +");
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
			Console.WriteLine("[08]{0} 根据 String.Split  {1} 拆分出来的结果为：", dataString, divChar[0]);
			foreach (String oneData in itemArray)
			{
				Console.WriteLine("==[{0}]", oneData);
			}

			// 使用正则表达式来进行 Split， 可以使 Split 出来的 字符创数组，不需要做额外的 Trim 工作。
			itemArray = Regex.Split(dataString, " *; *");
			Console.WriteLine("[08]{0} 根据 Regex.Split  {1} 拆分出来的结果为：", dataString, " *; *");
			foreach (String oneData in itemArray)
			{
				Console.WriteLine("==[{0}]", oneData);
			}

		}






	}

}
