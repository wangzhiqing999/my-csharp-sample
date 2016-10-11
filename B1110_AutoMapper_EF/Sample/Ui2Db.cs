using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AutoMapper;


using B1110_AutoMapper_EF.Model;
using B1110_AutoMapper_EF.DataAccess;
using B1110_AutoMapper_EF.UiModel;


namespace B1110_AutoMapper_EF.Sample
{

    /// <summary>
    /// UI类  映射 到 EF 类.
    /// </summary>
    class Ui2Db
    {

        public Ui2Db()
        {
            // 初始化配置
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UiVersion, DbVersion>()
                    // 映射后，自动填写数据.
                    .AfterMap((src, dest) => dest.LastUpdateTime = DateTime.Now)
                    // 忽略目标类中的主键属性.(数据库中的自动递增列)
                    .ForMember(dest => dest.VersionID, opt => opt.Ignore()); 


                cfg.CreateMap<UiProduct, DbProduct>()
                    .AfterMap((src, dest) => dest.LastUpdateTime = DateTime.Now);
            });

        } 



        public void DoTest1()
        {
            UiProduct p = new UiProduct() 
            { 
                ProductCode = "TEST",
                ProductName = "测试产品",                
            };


            UiVersion v1 = new UiVersion()
            {
                ProductCode = "TEST",
                VersionCode = 1,
                VersionNumber = "0.0.1",
                VersionDesc = "测试版本.",
                VersionFile = "Test.exe"
            };

            UiVersion v2 = new UiVersion()
            {
                ProductCode = "TEST",
                VersionCode = 2,
                VersionNumber = "0.0.2",
                VersionDesc = "测试版本.",
                VersionFile = "Test.exe"
            };


            DbProduct dp = Mapper.Map<UiProduct, DbProduct>(
                source: p,
                opts: opt => { opt.AfterMap((src, dest) => { dest.CreateTime = DateTime.Now; dest.CreateUser = "tester"; dest.LastUpdateUser = "tester"; dest.IsActive = true; }); }
                );

            DbVersion dv1 = Mapper.Map<UiVersion, DbVersion>(
                source: v1,
                opts: opt => { opt.AfterMap((src, dest) => { dest.CreateTime = DateTime.Now; dest.CreateUser = "tester"; dest.LastUpdateUser = "tester"; dest.IsActive = true; }); }
                );

            DbVersion dv2 = Mapper.Map<UiVersion, DbVersion>(
                source: v2,
                opts: opt => { opt.AfterMap((src, dest) => { dest.CreateTime = DateTime.Now; dest.CreateUser = "tester"; dest.LastUpdateUser = "tester"; dest.IsActive = true; }); }
                );


            using (MyVersionManagerContext context = new MyVersionManagerContext())
            {

                // 删除历史测试数据.
                context.Database.ExecuteSqlCommand("DELETE FROM db_version WHERE product_code = 'TEST'");
                context.Database.ExecuteSqlCommand("DELETE FROM db_product WHERE product_code = 'TEST'");


                // 新增最新的测试数据.
                context.DbProducts.Add(dp);
                context.DbVersions.Add(dv1);
                context.DbVersions.Add(dv2);


                // 物理保存.
                context.SaveChanges();
            }

        }





        public void DoTest2()
        {
            UiVersion v = new UiVersion()
            {
                ProductCode = "TEST",
                VersionCode = 2,
                VersionNumber = "0.0.2",
                VersionDesc = "测试版本2.",
                VersionFile = "Test2.exe"
            };

            
            using (MyVersionManagerContext context = new MyVersionManagerContext())
            {

                // 从数据库中查询数据.
                DbVersion dv = context.DbVersions.FirstOrDefault(p => p.ProductCode == "TEST" && p.VersionCode == 2);


                // UI 上面的数据， 更新到 数据库中.
                Mapper.Map<UiVersion, DbVersion>(
                    source: v, 
                    destination: dv, 
                    opts: opt => { opt.AfterMap((src, dest) => dest.LastUpdateUser = "tester2"); });


                // 物理保存.
                context.SaveChanges();
            }
        }


    }

}
