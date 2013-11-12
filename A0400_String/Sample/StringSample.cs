using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace A0401_String.Sample
{
    class StringSample
    {


        /// <summary>
        /// 演示 String 使用.
        /// </summary>
        public void DemoStringUse()
        {

            // 定义一个字符串变量.
            String str = "Hello World!";

            // 字符串合并
            // 注意： 只有1次2次的 这样操作的话，还可以接受
            // 如果是在 大量的循环中， 作这类 字符串直接 相加的操作， 会影响性能
            // 那个时候，需要使用  System.Text 下的  StringBuilder
            String str2 = "String = " + " String + String";
            Console.WriteLine("[01]字符串合并:{0}", str2);


            // 字符串格式化
            // 格式化就是将 后面的参数，依次替换掉前面文本的{0} {1}......
            String str3 = String.Format("{0} , {1} 用得太频繁不好！", str, str2);
            Console.WriteLine("[02]字符串 Format:{0}", str3);

            
            // IndexOf 字符串中，寻找指定的字符串.
            int strIdx = str2.IndexOf("String");
            int strIdx2 = str2.IndexOf("String", strIdx + 7);
            int strIdx3 = str2.IndexOf("String", strIdx2 + 7);
            Console.WriteLine("[03]{0}中 IndexOf(String) 的位置分别为：{1};{2};{3}", str2, strIdx, strIdx2, strIdx3);

            
            // IndexOfAny 字符串中，寻找指定的字符 (字符数组中的任意一个)
            char [] testCharArray = {'H', 'W', 'S'};
            ArrayList intPlace = new ArrayList();
            int idx = 0;
            int nextIndex = 0;
            do {
                // 取得指定字符所在的位置.
                idx = str3.IndexOfAny(testCharArray, nextIndex);

                // 如果找到了，加入 列表.
                if(idx != -1) {
                    intPlace.Add(idx);
                    // 更新 开始寻找的位置.
                    nextIndex = idx + 1;
                }
            } while(idx != -1);
            Console.WriteLine("[04]{0}中 IndexOfAny(H, W, S) 的位置分别为：", str3);
            foreach (int index in intPlace)
            {
                Console.WriteLine(index);
            }


            // LastIndexOf 字符串中，寻找指定的字符串.
            strIdx = str2.LastIndexOf("String");
            strIdx2 = str2.LastIndexOf("String", strIdx -1);
            strIdx3 = str2.LastIndexOf("String", strIdx2 - 1);
            Console.WriteLine("[05]{0}中 LastIndexOf(String) 的位置分别为：{1};{2};{3}", str2, strIdx, strIdx2, strIdx3);


            // IndexOfAny 字符串中，寻找指定的字符 (字符数组中的任意一个)
            intPlace.Clear();
            idx = 0;
            nextIndex = str3.Length - 1;
            do
            {
                // 取得指定字符所在的位置.
                idx = str3.LastIndexOfAny(testCharArray, nextIndex);

                // 如果找到了，加入 列表.
                if (idx != -1)
                {
                    intPlace.Add(idx);
                    // 更新 开始寻找的位置.
                    nextIndex = idx - 1;
                }
            } while (idx != -1 && nextIndex >0);
            Console.WriteLine("[06]{0}中 LastIndexOfAny(H, W, S) 的位置分别为：", str3);
            foreach (int index in intPlace)
            {
                Console.WriteLine(index);
            }


            // Insert 在字符串中间插入 一个字符串.
            String str4 = str.Insert(6, "my ");
            Console.WriteLine("[07]{0}第{1}个位置插入{2}的结果为{3}", str, 6, "my ", str4);


            // PadLeft  与 PadRight 
            String str5 = str.PadLeft(20, '*');
            String str6 = str.PadRight(20, '*');
            Console.WriteLine("[08]{0} PadLeft 与 PadRight 20* 的结果为: {1}, {2}", str, str5, str6);


            // Replace
            String str7 = str5.Replace('*', 'x');
            Console.WriteLine("[09]{0} Replace(*, x) 的结果为: {1}", str5, str7);


            // Split 
            String dataString = "Java;C#;C++;C;DELPHI;BASIC";
            char[] divChar = {';'};
            string[] itemArray = dataString.Split(divChar);
            Console.WriteLine("[10]{0} 根据 {1} 拆分出来的结果为：", dataString, divChar[0]);
            foreach (String oneData in itemArray)
            {
                Console.WriteLine(oneData);
            }


            // SubString
            String str8 = str.Substring(1);
            String str9 = str.Substring(1, 2);
            Console.WriteLine("[11]{0} SubString(1) 的结果为：{1}", str, str8);
            Console.WriteLine("[12]{0} SubString(1,2) 拆分出来的结果为：{1}", str, str9);


        }





    }
}
