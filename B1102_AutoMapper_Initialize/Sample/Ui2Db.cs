using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;


using B1100_AutoMapper.Model;



namespace B1102_AutoMapper_Initialize.Sample
{

    /// <summary>
    /// 测试  画面 的类， 转换为  数据库的类.
    /// </summary>
    class Ui2Db
    {

        public Ui2Db()
        {

            // 初始化配置
            Mapper.Initialize(cfg =>
            {
                // 这里的 .BeforeMap 与 .AfterMap  
                // 为 映射前后， 需要完成的操作.
                cfg.CreateMap<TestUiClass, TestDbClass>()
                    .BeforeMap((src, dest) => src.IsUpdate = true)
                    .AfterMap((src, dest) => dest.LastUpdateTime = DateTime.Now);



                //添加一个配置文件
                cfg.AddProfile<TestMyProfile>();

            });

        }


        /// <summary>
        /// 配置写在一个单独的类里面.
        /// </summary>
        public class TestMyProfile : Profile
        {
            protected override void Configure()
            {
                this.CreateMap<TestDbClass, TestUiClass>();





                // 设置源和目标的命名惯例。

                // 目标：小写字母与下划线的命名方式.
                DestinationMemberNamingConvention  = new LowerUnderscoreNamingConvention();

                // 源： 帕斯卡命名法 
                SourceMemberNamingConvention = new PascalCaseNamingConvention();
            }
        }






        /// <summary>
        /// 测试一个新增的操作.
        /// </summary>
        public void DoTest1()
        {
            TestUiClass uiClass = new TestUiClass()
            {
                ID = 2,
                Name = "测试2",
                IsActive = true,

                SysUserCode = "测试命名方式",
            };

            // 测试将其转换为 UI 上使用的类.
            // 这里增加了一个  opts 的参数， 用于在 映射期间， 进行调用的处理.
            TestDbClass dbClass = Mapper.Map<TestUiClass, TestDbClass>(
                source: uiClass, 
                opts: opt => { opt.AfterMap((src, dest) => dest.CreateTime = DateTime.Now); }
                );


            Console.WriteLine("UI to DB......");

            Console.WriteLine("UI类 = {0}", uiClass);
            Console.WriteLine("DB类 = {0}", dbClass);


            Console.WriteLine("UI to DB finish!!!");
        }




        /// <summary>
        /// 测试一个更新的操作.
        /// </summary>
        public void DoTest2()
        {
            // 先 手动 模拟一个  从数据库中获取的类.
            TestDbClass dbClass = new TestDbClass()
            {
                ID = 3,
                Name = "测试3",
                IsActive = true,


                CreateTime = DateTime.Now.AddSeconds(-2),
                LastUpdateTime = DateTime.Now.AddSeconds(-2),

                CreateUser = "Tester",
                LastUpdateUser = "Tester",


                sys_user_code = "Test",
            };



            // 这里模拟 画面上， 更新了数据.
            TestUiClass uiClass = new TestUiClass()
            {
                ID = 3,
                Name = "测试3x7=21",
                IsActive = false,

                SysUserCode = "测试命名方式",
            };



            // 注意： 
            // 前面的 DoTest1 中的处理， 是 通过 ui 类， 创建一个 db 类.
            // 这里的处理， 是通过 ui 类， 更新 db 类.
            Mapper.Map(uiClass, dbClass);

            Console.WriteLine("UI to DB......");

            Console.WriteLine("UI类 = {0}", uiClass);
            Console.WriteLine("DB类 = {0}", dbClass);


            Console.WriteLine("UI to DB finish!!!");

        }
    }

}
