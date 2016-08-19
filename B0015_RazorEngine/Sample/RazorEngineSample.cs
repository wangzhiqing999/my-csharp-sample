using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using RazorEngine;
using RazorEngine.Templating;




namespace B0015_RazorEngine.Sample
{
    class RazorEngineSample
    {



        /// <summary>
        /// 最基础的测试.
        /// </summary>
        public static void TestHelloWorld()
        {

            string template = "Hello @Model.Name, welcome to RazorEngine!";
            var result =
                Engine.Razor.RunCompile(template, "templateKey", null, new { Name = "World" });

            Console.WriteLine(result);
        }






        /// <summary>
        /// 测试1:
        /// </summary>
        public static void Test1()
        {

            string template = @"
<p>
  <span> 用户名： @Model.UserName  </span> 
  <span> 区域： @Model.Area </span> 
</p>

<ul>
@foreach(var item in Model.ItemList) {
  <li>
    @item.ItemName : @item.Count 
  </li>
}
</ul>
";


            // 对于同一个模板， 首次使用时， 传递 templateSource 与 name 参数.
            var result =
                Engine.Razor.RunCompile(
                templateSource : template, 
                name : "templateKey1",
                modelType: typeof(TestUser),
                model: TestUser.defaultTestData1);

            Console.WriteLine(result);


            // 对于同一个模板， 后续使用时， 传递 name 参数即可.
            result =
               Engine.Razor.RunCompile(
               //templateSource: template,
               name: "templateKey1",
               modelType: typeof(TestUser),
               model: TestUser.defaultTestData2);

            Console.WriteLine(result);
        }





        /// <summary>
        /// 测试2:
        /// </summary>
        public static void Test2()
        {

            string template = @"
用户名： @Model.UserName
区域： @Model.Area
持有物品：
@foreach(var item in Model.ItemList) {
    @(item.ItemName +  "":"" + item.Count + ""\r\n"")
}

";

            // 注意： 
            // 由于 RazorEngine 本来是 MVC 里面使用的
            // 因此， @foreach 里面， 简单写 @item.ItemName  :  @item.Count   ，  中间那个  :  将会报语法错误。
            // 也就是说， 如果把这个引擎， 用在非 Web 的应用中， 例如生成代码什么的， 就要自己拼字符串了。



            // 对于同一个模板， 首次使用时， 传递 templateSource 与 name 参数.
            var result =
                Engine.Razor.RunCompile(
                templateSource: template,
                name: "templateKey2",
                modelType: typeof(TestUser),
                model: TestUser.defaultTestData1);

            Console.WriteLine(result);



            // 对于同一个模板， 后续使用时， 传递 name 参数即可.
            result =
               Engine.Razor.RunCompile(
                //templateSource: template,
               name: "templateKey2",
               modelType: typeof(TestUser),
               model: TestUser.defaultTestData2);

            Console.WriteLine(result);
        }




    }




    /// <summary>
    /// 测试数据类.
    /// 
    /// 该类用于向  RazorEngine 填充数据.
    /// </summary>
    public class TestUser
    {
        /// <summary>
        /// 姓名.
        /// </summary>
        public string UserName { set; get; }


        /// <summary>
        /// 区域.
        /// </summary>
        public string Area { set; get; }



        /// <summary>
        /// 物品列表.
        /// </summary>
        public List<TestItem> ItemList { set; get; }





        /// <summary>
        /// 测试数据.
        /// </summary>
        public static readonly TestUser defaultTestData1 = new TestUser()
        {
            UserName = "张三",
            Area = "东三区",
            ItemList = new List<TestItem>()
                {
                    new TestItem() {
                        ItemName = "ID卡",
                        Count = 1
                    },
                    new TestItem() {
                        ItemName = "手套",
                        Count = 2
                    },
                },
        };



        /// <summary>
        /// 测试数据2.
        /// </summary>
        public static readonly TestUser defaultTestData2 = new TestUser()
        {
            UserName = "李四",
            Area = "西四区",
            ItemList = new List<TestItem>()
                {
                    new TestItem() {
                        ItemName = "ID卡",
                        Count = 1
                    },
                    new TestItem() {
                        ItemName = "帽子",
                        Count = 4
                    },
                },
        };


    }




    /// <summary>
    /// 测试数据类.
    /// 
    /// 该类用于向  RazorEngine 填充数据.
    /// </summary>
    public class TestItem
    {
        /// <summary>
        /// 名称.
        /// </summary>
        public string ItemName { set; get; }


        /// <summary>
        /// 数量.
        /// </summary>
        public int Count { set; get; }
    }


}
