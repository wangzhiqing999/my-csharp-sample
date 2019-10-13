using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace A0501_LINQ_Base2.Sample
{
    class LinqSample
    {



        /// <summary>
        /// 用于返回一个 apple 的数据源.
        /// </summary>
        /// <returns></returns>
        private static List<Apple> GetAppleDataList()
        {
            // 创建一个 apple 的数据源.
            List<Apple> appleList = new List<Apple>();

            appleList.Add(new Apple("中国", "红", "甜"));
            appleList.Add(new Apple("中国", "黄", "甜"));
            appleList.Add(new Apple("中国", "青", "甜"));

            appleList.Add(new Apple("中国", "红", "酸"));
            appleList.Add(new Apple("中国", "黄", "酸"));
            appleList.Add(new Apple("中国", "青", "酸"));

            appleList.Add(new Apple("中国", "红", "涩"));
            appleList.Add(new Apple("中国", "黄", "涩"));
            appleList.Add(new Apple("中国", "青", "涩"));


            appleList.Add(new Apple("美国", "红", "甜"));
            appleList.Add(new Apple("美国", "黄", "甜"));
            appleList.Add(new Apple("美国", "青", "甜"));

            appleList.Add(new Apple("美国", "红", "酸"));
            //appleList.Add(new Apple("美国", "黄", "酸"));
            appleList.Add(new Apple("美国", "青", "酸"));

            appleList.Add(new Apple("美国", "红", "涩"));
            //appleList.Add(new Apple("美国", "黄", "涩"));
            appleList.Add(new Apple("美国", "青", "涩"));


            appleList.Add(new Apple("日本", "红", "甜"));
            appleList.Add(new Apple("日本", "黄", "甜"));
            appleList.Add(new Apple("日本", "青", "甜"));

            //appleList.Add(new Apple("日本", "红", "酸"));
            //appleList.Add(new Apple("日本", "黄", "酸"));
            //appleList.Add(new Apple("日本", "青", "酸"));

            appleList.Add(new Apple("日本", "红", "涩"));
            appleList.Add(new Apple("日本", "黄", "涩"));
            appleList.Add(new Apple("日本", "青", "涩"));

            return appleList;
        }


        /// <summary>
        /// 用于返回一个 Orange 的数据源.
        /// </summary>
        /// <returns></returns>
        private static List<Orange> GetOrangeDataList()
        {
            // 创建一个 apple 的数据源.
            List<Orange> orangeList = new List<Orange>();

            orangeList.Add(new Orange("中国", "红", "甜"));
            orangeList.Add(new Orange("中国", "黄", "甜"));
            orangeList.Add(new Orange("中国", "青", "甜"));

            orangeList.Add(new Orange("美国", "红", "甜"));
            orangeList.Add(new Orange("美国", "黄", "甜"));
            orangeList.Add(new Orange("美国", "青", "甜"));

            orangeList.Add(new Orange("日本", "红", "甜"));
            orangeList.Add(new Orange("日本", "黄", "甜"));
            orangeList.Add(new Orange("日本", "青", "甜"));

            return orangeList;
        }



        /// <summary>
        /// 初始的数据源: 苹果
        /// </summary>
        private List<Apple> appleList = GetAppleDataList();

        /// <summary>
        /// 初始的数据源: 桔子
        /// </summary>
        private List<Orange> orangeList = GetOrangeDataList();



        /// <summary>
        /// 演示 LINQ 中的  WHERE 条件，以及  &&(与)  ||(或)   !(非) 
        /// </summary>
        public void Test1()
        {
            // 定义查询.
            var allQuery =
                from apple in appleList
                select apple;

            // 执行查询.
            Console.WriteLine("[01]查询苹果列表中所有的苹果，结果为：");
            foreach (Apple apple in allQuery)
            {
                Console.WriteLine("=={0} ", apple);
            }


            // 定义查询.
            var query1 =
                from apple in appleList
                where apple.Color == "红"
                select apple;

            // 执行查询.
            Console.WriteLine("[01]查询苹果列表中，颜色为红的，结果为：");
            foreach (Apple apple in query1)
            {
                Console.WriteLine("=={0} ", apple);
            }
            



            // 定义查询.
            var query2 =
                from apple in appleList
                where apple.Country == "中国" && apple.Color == "红" && apple.Sapor == "甜"
                select apple;

            // 执行查询.
            Console.WriteLine("[01]查询苹果列表中，产地为中国，颜色为红的 并且 味道为甜的，结果为：");
            foreach (Apple apple in query2)
            {
                Console.Write("{0} ", apple);
            }
            Console.WriteLine();


            // 定义查询.
            var query3 =
                from apple in appleList
                where apple.Country == "中国" && (apple.Color == "红" || apple.Sapor == "甜")
                select apple;

            // 执行查询.
            Console.WriteLine("[01]查询苹果列表中，产地为中国，颜色为红的 或者 味道为甜的，结果为：");
            foreach (Apple apple in query3)
            {
                Console.Write("{0} ", apple);
            }
            Console.WriteLine();


            // 定义查询.
            var query4 =
                from apple in appleList
                where apple.Country == "中国" && !(apple.Color == "红" || apple.Sapor == "甜")
                select apple;

            // 执行查询.
            Console.WriteLine("[01]查询苹果列表中， 产地为中国，排除掉 颜色为红的或者味道为甜的，结果为：");
            foreach (Apple apple in query4)
            {
                Console.Write("{0} ", apple);
            }
            Console.WriteLine();




        }



        /// <summary>
        /// 演示 LINQ 中的  orderby 排序.
        /// </summary>
        public void Test2()
        {
            // 定义查询.
            var allQuery =
                from apple in appleList
                where apple.Country == "中国"
                orderby apple.Color descending 
                select apple;

            // 执行查询.
            Console.WriteLine("[02]查询苹果列表中 产地为中国，按颜色降序排列，结果为：");
            foreach (Apple apple in allQuery)
            {
                Console.WriteLine("=={0} ", apple);
            }


            // 定义查询.
            var allQuery2 =
                from apple in appleList
                where apple.Country == "中国"
                orderby apple.Sapor ascending
                select apple;

            // 执行查询.
            Console.WriteLine("[02]查询苹果列表中 产地为中国，按味道升序排列，结果为：");
            foreach (Apple apple in allQuery2)
            {
                Console.WriteLine("=={0} ", apple);
            }
        }



        /// <summary>
        /// 演示 LINQ 中的  group  分组
        /// 
        /// 注意： LINQ 中的 group by ，将产生分组， 每个分组下面是 相应的 对象集合。
        /// </summary>
        public void Test3()
        {
            // 定义查询.
            var groupQuery =
                from apple in appleList
                group apple by apple.Country;

            // 执行查询.
            Console.WriteLine("[03]查询苹果列表中所有的苹果，按 产地 分组，结果为：");
            foreach (var appleGroup in groupQuery)
            {
                Console.WriteLine("==分组KEY：{0}",appleGroup.Key);
                foreach (Apple apple in appleGroup)
                {
                    Console.WriteLine("===={0} ", apple);
                }
            }



            // 定义查询.
            var groupQuery2 =
                from apple in appleList
                where apple.Country == "中国"
                group apple by apple.Sapor == "甜";

            // 执行查询.
            Console.WriteLine("[03]查询苹果列表中，产地为中国，按 味道 甜/非甜 分组，结果为：");
            foreach (var appleGroup in groupQuery2)
            {
                Console.WriteLine("==分组KEY：{0}", appleGroup.Key);
                foreach (Apple apple in appleGroup)
                {
                    Console.WriteLine("===={0} ", apple);
                }
            }



            // 定义查询.
            var groupQuery3 =
                from apple in appleList
                group apple by new { c1 = apple.Country, c2 = apple.Color };

            // 执行查询.
            Console.WriteLine("[03]查询苹果列表中所有的苹果，按 产地 与 颜色 分组 ，结果为：");
            foreach (var appleGroup in groupQuery3)
            {
                Console.WriteLine("==分组KEY：{0}", appleGroup.Key);
                foreach (Apple apple in appleGroup)
                {
                    Console.WriteLine("===={0} ", apple);
                }
            }



            // 定义查询.
            var groupQuery4 =
                from apple in appleList
                group apple by apple.Country into countryGroup
                where countryGroup.Count() > 6
                orderby countryGroup.Key
                select countryGroup;

            // 执行查询.
            Console.WriteLine("[03]查询苹果列表中所有的苹果，按 产地 分组 且每个分组下种类数必须大于6，结果为：");
            foreach (var appleGroup in groupQuery4)
            {
                Console.WriteLine("==分组KEY：{0}", appleGroup.Key);
                foreach (Apple apple in appleGroup)
                {
                    Console.WriteLine("===={0} ", apple);
                }
            }




            // 定义查询.
            var groupQuery5 =
                from apple in appleList
                group apple by apple.Country[0] into countryGroup
                where (countryGroup.Key == '中' || countryGroup.Key == '日')
                select countryGroup;

            // 执行查询.
            Console.WriteLine("[03]查询苹果列表中所有的苹果，按 产地的 第一个 字符分组， 只检索 中、日的，结果为：");
            foreach (var appleGroup in groupQuery5)
            {
                Console.WriteLine("==分组KEY：{0}", appleGroup.Key);
                foreach (Apple apple in appleGroup)
                {
                    Console.WriteLine("===={0} ", apple);
                }
            }



            // 定义查询.
            var groupQuery6 =
                from apple in appleList
                group apple by apple.Country into countryGroup
                from colorGroup in
                    (from apple in countryGroup
                     group apple by apple.Color)
                group colorGroup by countryGroup.Key;

            // 执行查询.
            Console.WriteLine("[03] 查询苹果列表中所有的苹果，按 产地 与 颜色 嵌套分组 ，结果为：");
            foreach (var appleGroup1 in groupQuery6)
            {
                Console.WriteLine("==分组KEY：{0}", appleGroup1.Key);

                foreach (var appleGroup2 in appleGroup1)
                {
                    Console.WriteLine("====分组KEY：{0}", appleGroup2.Key);
                    foreach (Apple apple in appleGroup2)
                    {
                        Console.WriteLine("======{0} ", apple);
                    }
                }
            }

        }




        /// <summary>
        /// 演示 LINQ 中的  Concat 
        /// </summary>
        public void Test4()
        {
            // 定义查询.
            var query =
                (from apple in appleList
                 where apple.Country == "中国"
                 select apple.ToString()).Concat(from orange in orangeList
                                                 where orange.Country == "中国"
                                                 select orange.ToString());
            // 执行查询.
            Console.WriteLine("[04]查询苹果列表中 产地为中国的 与 桔子列表中，产地为中国的 进行合并，结果为：");
            foreach (var str in query)
            {
                Console.WriteLine("=={0} ", str);
            }
        }



        /// <summary>
        /// 演示 LINQ 中的  Join 的使用
        /// </summary>
        public void Test5()
        {
            // 定义查询.
            var query =
                 from apple in appleList
                 join orange in orangeList on new { apple.Country, apple.Color, apple.Sapor } equals new { orange.Country, orange.Color, orange.Sapor }
                 select new { a = apple.ToString(), o = orange.ToString() };
            // 执行查询.
            Console.WriteLine("[05] 使用 JOIN 关联 查询苹果列表中与桔子列表中， 结果为：");
            foreach (var str in query)
            {
                Console.WriteLine("=={0} ", str);
            }



            // 定义查询.
            var query2 =
                 from apple in appleList
                 from orange in orangeList                     
                 where 
                   apple.Country == orange.Country &&
                   apple.Color == orange.Color &&
                   apple.Sapor == orange.Sapor
                 select new { a = apple.ToString(), o = orange.ToString() };
            // 执行查询.
            Console.WriteLine("[05] 不使用 JOIN 关联 查询苹果列表中与桔子列表中，结果为：");
            foreach (var str in query2)
            {
                Console.WriteLine("=={0} ", str);
            }



            // 定义查询.
            var query3 =
                 from apple in appleList
                 join orange in orangeList on
                   new { apple.Country, apple.Color, apple.Sapor } equals new { orange.Country, orange.Color, orange.Sapor } into ccs
                 from subOrange in ccs.DefaultIfEmpty()
                 select new { a = apple.ToString(), o = subOrange!=null?subOrange.ToString():String.Empty };

            // 执行查询.
            Console.WriteLine("[05] 使用 JOIN 关联[LEFT JOIN] 查询苹果列表中与桔子列表中， 结果为：");
            foreach (var str in query3)
            {
                Console.WriteLine("=={0} ", str);
            }

        }


        /// <summary>
        /// 演示 LINQ 中的  子查询 的使用
        /// </summary>
        public void Test6()
        {
            // 定义查询.
            var query =
                 from apple in appleList
                 group apple by apple.Country into countryGroup
                 select new {
                    Country = countryGroup.Key,
                    Count = (from apple in countryGroup 
                                 select apple).Count()
                 };
                    

            // 执行查询.
            Console.WriteLine("[06] 使用 GROUP 按产地关联，并基于查询的分组，进行子查询：");
            foreach (var str in query)
            {
                Console.WriteLine("=={0} ", str);
            }
        }




        /// <summary>
        /// 演示 LINQ 中的  翻页处理.
        /// </summary>
        public void Test7()
        {
            Console.WriteLine("[07] 使用 Take / Skip  进行翻页处理！");

            // 定义查询.
            var query =
                 from apple in appleList
                 select apple;


            Console.WriteLine("[07] 每页5行  （第1页） ");

            // 执行查询.
            foreach (Apple apple in query.Take(5))
            {
                Console.WriteLine("=={0} ", apple);
            }


            Console.WriteLine("[07] 每页5行  第一次翻页 （第2页）");

            // 执行查询.
            foreach (Apple apple in query.Skip(5).Take(5))
            {
                Console.WriteLine("=={0} ", apple);
            }


            Console.WriteLine("[07] 每页5行  第二次翻页 （第3页）");

            // 执行查询.
            foreach (Apple apple in query.Skip(10).Take(5))
            {
                Console.WriteLine("=={0} ", apple);
            }

            Console.WriteLine("[07] 每页5行  第三次翻页 （第4页）");

            // 执行查询.
            foreach (Apple apple in query.Skip(15).Take(5))
            {
                Console.WriteLine("=={0} ", apple);
            }



            Console.WriteLine("[07] 每页5行  第四次翻页 （第5页）");
            
            // 请注意这里是最后一页了，只有2行数据。
            // 但是 Take (5) 执行是没有抱错的.

            // 执行查询.
            foreach (Apple apple in query.Skip(20).Take(5))
            {
                Console.WriteLine("=={0} ", apple);
            }
        }





        /// <summary>
        /// 演示将 内存数据， 写入 XML.
        /// 
        /// 以及 let 的使用
        /// </summary>
        public void TestXml()
        {
            Console.WriteLine("[XML] 将桔子的数据，写入 XML 结果为：");

            // Create the query.
            var appleToXML = new XElement("水果",
                from orange in orangeList
                let goods = orange.Color == "黄"?"优良":"一般"
                select new XElement("桔子",
                    new XElement("产地", orange.Country),
                    new XElement("颜色", orange.Color),
                    new XElement("味道", orange.Sapor),
                    new XElement("品质", goods)
                )  // 桔子 结束.
            );  // 水果 结束.

            Console.WriteLine(appleToXML);
        }











        /// <summary>
        /// 排序的列.
        /// </summary>
        public string OrderByColumn = "Country";

        /// <summary>
        /// 排序的方式. 是否逆序？
        /// </summary>
        public bool IsOrderByDescending = false;

        // 测试排序.
        public void TestOrderBy()
        {
            Console.WriteLine("### TestOrderBy {0}, {1}", this.OrderByColumn, this.IsOrderByDescending);

            // 定义查询.
            var query =
                 from data in orangeList
                 select data;

            query = query.Where(p => p.Color != null);

            if(!this.IsOrderByDescending)
            {
                query = query.OrderBy(GetOrderBy);
            } 
            else
            {
                query = query.OrderByDescending(GetOrderBy);
            }

            foreach(var item in query)
            {
                Console.WriteLine(item);
            }
        }


        


        // 外部设置的 排序条件.
        private object GetOrderBy(Orange orange)
        {
            if (this.OrderByColumn == "Country")
            {
                return orange.Country;
            }
            else if (this.OrderByColumn == "Color")
            {
                return orange.Color;
            }
            else if (this.OrderByColumn == "Sapor")
            {
                return orange.Sapor;
            }
            
            return orange.Country;
        }

        


    }
}
